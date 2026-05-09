/*
 * Example
 * GaussianBlur a = new GaussianBlur(Bitmap bitmap); 
 * a.Process(int radial);
*/

using HeCopUI_Framework.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace HeCopUI_Framework.Components
{
    /// <summary>
    /// Làm mở hình ảnh siêu nhanh
    /// </summary>
    public partial class GaussianBlur
    {
        #region Quick GaussianBlur
        private readonly int[] _alpha;
        private readonly int[] _red;
        private readonly int[] _green;
        private readonly int[] _blue;

        private readonly int _width;
        private readonly int _height;

        private readonly ParallelOptions _pOptions = new ParallelOptions { MaxDegreeOfParallelism = 1 };

        public GaussianBlur(Bitmap image)
        {
            var rct = new Rectangle(0, 0, image.Width, image.Height);
            var source = new int[rct.Width * rct.Height];
            var bits = image.LockBits(rct, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            Marshal.Copy(bits.Scan0, source, 0, source.Length);
            image.UnlockBits(bits);

            _width = image.Width;
            _height = image.Height;

            _alpha = new int[_width * _height];
            _red = new int[_width * _height];
            _green = new int[_width * _height];
            _blue = new int[_width * _height];

            Parallel.For(0, source.Length, _pOptions, i =>
            {
                _alpha[i] = (int)((source[i] & 0xff000000) >> 24);
                _red[i] = (source[i] & 0xff0000) >> 16;
                _green[i] = (source[i] & 0x00ff00) >> 8;
                _blue[i] = (source[i] & 0x0000ff);
            });

        }

        public Bitmap Process(int radial)
        {
            var newAlpha = new int[_width * _height];
            var newRed = new int[_width * _height];
            var newGreen = new int[_width * _height];
            var newBlue = new int[_width * _height];
            var dest = new int[_width * _height];

            Parallel.Invoke(
                () => gaussBlur_4(_alpha, newAlpha, radial),
                () => gaussBlur_4(_red, newRed, radial),
                () => gaussBlur_4(_green, newGreen, radial),
                () => gaussBlur_4(_blue, newBlue, radial));

            Parallel.For(0, dest.Length, _pOptions, i =>
            {
                if (newAlpha[i] > 255) newAlpha[i] = 255;
                if (newRed[i] > 255) newRed[i] = 255;
                if (newGreen[i] > 255) newGreen[i] = 255;
                if (newBlue[i] > 255) newBlue[i] = 255;

                if (newAlpha[i] < 0) newAlpha[i] = 0;
                if (newRed[i] < 0) newRed[i] = 0;
                if (newGreen[i] < 0) newGreen[i] = 0;
                if (newBlue[i] < 0) newBlue[i] = 0;

                dest[i] = (int)((uint)(newAlpha[i] << 24) | (uint)(newRed[i] << 16) | (uint)(newGreen[i] << 8) | (uint)newBlue[i]);
            });

            var image = new Bitmap(_width, _height);
            var rct = new Rectangle(0, 0, image.Width, image.Height);
            var bits2 = image.LockBits(rct, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            Marshal.Copy(dest, 0, bits2.Scan0, dest.Length);
            image.UnlockBits(bits2);

            return image;
        }

        private void gaussBlur_4(int[] source, int[] dest, int r)
        {
            var bxs = boxesForGauss(r, 3);
            boxBlur_4(source, dest, _width, _height, (bxs[0] - 1) / 2);
            boxBlur_4(dest, source, _width, _height, (bxs[1] - 1) / 2);
            boxBlur_4(source, dest, _width, _height, (bxs[2] - 1) / 2);
        }

        private int[] boxesForGauss(int sigma, int n)
        {
            var wIdeal = Math.Sqrt((12 * sigma * sigma / n) + 1);
            var wl = (int)Math.Floor(wIdeal);
            if (wl % 2 == 0) wl--;
            var wu = wl + 2;

            var mIdeal = (double)(12 * sigma * sigma - n * wl * wl - 4 * n * wl - 3 * n) / (-4 * wl - 4);
            var m = Math.Round(mIdeal);

            var sizes = new List<int>();
            for (var i = 0; i < n; i++) sizes.Add(i < m ? wl : wu);
            return sizes.ToArray();
        }

        private void boxBlur_4(int[] source, int[] dest, int w, int h, int r)
        {
            for (var i = 0; i < source.Length; i++) dest[i] = source[i];
            boxBlurH_4(dest, source, w, h, r);
            boxBlurT_4(source, dest, w, h, r);
        }

        private void boxBlurH_4(int[] source, int[] dest, int w, int h, int r)
        {
            var iar = (double)1 / (r + r + 1);
            Parallel.For(0, h, _pOptions, i =>
            {
                var ti = i * w;
                var li = ti;
                var ri = ti + r;
                var fv = source[ti];
                var lv = source[ti + w - 1];
                var val = (r + 1) * fv;
                for (var j = 0; j < r; j++) val += source[ti + j];
                for (var j = 0; j <= r; j++)
                {
                    val += source[ri++] - fv;
                    dest[ti++] = (int)Math.Round(val * iar);
                }
                for (var j = r + 1; j < w - r; j++)
                {
                    val += source[ri++] - dest[li++];
                    dest[ti++] = (int)Math.Round(val * iar);
                }
                for (var j = w - r; j < w; j++)
                {
                    val += lv - source[li++];
                    dest[ti++] = (int)Math.Round(val * iar);
                }
            });
        }

        private void boxBlurT_4(int[] source, int[] dest, int w, int h, int r)
        {
            var iar = (double)1 / (r + r + 1);
            Parallel.For(0, w, _pOptions, i =>
            {
                var ti = i;
                var li = ti;
                var ri = ti + r * w;
                var fv = source[ti];
                var lv = source[ti + w * (h - 1)];
                var val = (r + 1) * fv;
                for (var j = 0; j < r; j++) val += source[ti + j * w];
                for (var j = 0; j <= r; j++)
                {
                    val += source[ri] - fv;
                    dest[ti] = (int)Math.Round(val * iar);
                    ri += w;
                    ti += w;
                }
                for (var j = r + 1; j < h - r; j++)
                {
                    val += source[ri] - source[li];
                    dest[ti] = (int)Math.Round(val * iar);
                    li += w;
                    ri += w;
                    ti += w;
                }
                for (var j = h - r; j < h; j++)
                {
                    val += lv - source[li];
                    dest[ti] = (int)Math.Round(val * iar);
                    li += w;
                    ti += w;
                }
            });
        }
        #endregion
    }


    public partial class BoxBlurs
    {
        #region BoxBlur
        /// <summary>
        /// Làm mờ hình ảnh với thuật toán Box Blur, chiếm ít dung lượng ram nhất.
        /// </summary>
        /// <param name="image">Lấy hình ảnh để làm mờ.</param>
        /// <param name="blurSize">Kích cỡ làm mờ cho ảnh, nên xài từ 1 đến 10 để tối ưu nhất</param>
        /// <returns></returns>
        public static Bitmap BoxBlur(Bitmap image, int blurSize)
        {
            var blurred = (Bitmap)image.Clone();

            for (var xx = 0; xx < blurred.Width; xx++)
            {
                for (var yy = 0; yy < blurred.Height; yy++)
                {
                    int avgR = 0;
                    int avgG = 0;
                    int avgB = 0;
                    int avgA = 0;
                    int blurPixelCount = 0;

                    // average the color of the pixels around this one
                    for (var x = xx; (x < xx + blurSize && x < image.Width); x++)
                    {
                        for (var y = yy; (y < yy + blurSize && y < image.Height); y++)
                        {
                            var pixel = image.GetPixel(x, y);

                            avgR += pixel.R;
                            avgG += pixel.G;
                            avgB += pixel.B;
                            avgA += pixel.A;
                            blurPixelCount++;
                        }
                    }

                    avgR = avgR / blurPixelCount;
                    avgG = avgG / blurPixelCount;
                    avgB = avgB / blurPixelCount;
                    avgA = avgA / blurPixelCount;

                    // now that we know the average for the surrounding pixels, set the pixel in the blurred image
                    for (var x = xx; x < xx + blurSize && x < image.Width && x < blurred.Width; x++)
                        for (var y = yy; y < yy + blurSize && y < image.Height && y < blurred.Height; y++)
                            blurred.SetPixel(x, y, Color.FromArgb(avgA, avgR, avgG, avgB));

                }
            }

            return blurred;
        }
        #endregion
    }


    #region Filter and tools
    /// <summary>
    /// Tạo blur size từ 4 trở đi (Mặc định là 4). Có thể không dùng được
    /// </summary>
    public partial class BitmapFilter
    {

        public class ConvMatrix
        {
            public int TopLeft = 0, TopMid = 0, TopRight = 0;
            public int MidLeft = 0, Pixel = 1, MidRight = 0;
            public int BottomLeft = 0, BottomMid = 0, BottomRight = 0;
            public int Factor = 1;
            public int Offset = 0;
            public void SetAll(int nVal)
            {
                TopLeft = TopMid = TopRight = MidLeft = Pixel = MidRight = BottomLeft = BottomMid = BottomRight = nVal;
            }
        }

        public static bool Invert(Bitmap b)
        {
            // GDI+ still lies to us - the return format is BGR, NOT RGB.
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int stride = bmData.Stride;
            System.IntPtr Scan0 = bmData.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;

                int nOffset = stride - b.Width * 3;
                int nWidth = b.Width * 3;

                for (int y = 0; y < b.Height; ++y)
                {
                    for (int x = 0; x < nWidth; ++x)
                    {
                        p[0] = (byte)(255 - p[0]);
                        ++p;
                    }
                    p += nOffset;
                }
            }

            b.UnlockBits(bmData);

            return true;
        }

        public static bool GrayScale(Bitmap b)
        {
            // GDI+ still lies to us - the return format is BGR, NOT RGB.
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int stride = bmData.Stride;
            System.IntPtr Scan0 = bmData.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;

                int nOffset = stride - b.Width * 3;

                byte red, green, blue;

                for (int y = 0; y < b.Height; ++y)
                {
                    for (int x = 0; x < b.Width; ++x)
                    {
                        blue = p[0];
                        green = p[1];
                        red = p[2];

                        p[0] = p[1] = p[2] = (byte)(.299 * red + .587 * green + .114 * blue);

                        p += 3;
                    }
                    p += nOffset;
                }
            }

            b.UnlockBits(bmData);

            return true;
        }

        public static bool Brightness(Bitmap b, int nBrightness)
        {
            if (nBrightness < -255 || nBrightness > 255)
                return false;

            // GDI+ still lies to us - the return format is BGR, NOT RGB.
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int stride = bmData.Stride;
            System.IntPtr Scan0 = bmData.Scan0;

            int nVal = 0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;

                int nOffset = stride - b.Width * 3;
                int nWidth = b.Width * 3;

                for (int y = 0; y < b.Height; ++y)
                {
                    for (int x = 0; x < nWidth; ++x)
                    {
                        nVal = p[0] + nBrightness;

                        if (nVal < 0) nVal = 0;
                        if (nVal > 255) nVal = 255;

                        p[0] = (byte)nVal;

                        ++p;
                    }
                    p += nOffset;
                }
            }

            b.UnlockBits(bmData);

            return true;
        }

#pragma warning disable CS3001 // Argument type is not CLS-compliant
        public static bool Contrast(Bitmap b, sbyte nContrast)
#pragma warning restore CS3001 // Argument type is not CLS-compliant
        {
            if (nContrast < -100) return false;
            if (nContrast > 100) return false;

            double pixel = 0, contrast = (100.0 + nContrast) / 100.0;

            contrast *= contrast;

            int red, green, blue;

            // GDI+ still lies to us - the return format is BGR, NOT RGB.
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int stride = bmData.Stride;
            System.IntPtr Scan0 = bmData.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;

                int nOffset = stride - b.Width * 3;

                for (int y = 0; y < b.Height; ++y)
                {
                    for (int x = 0; x < b.Width; ++x)
                    {
                        blue = p[0];
                        green = p[1];
                        red = p[2];

                        pixel = red / 255.0;
                        pixel -= 0.5;
                        pixel *= contrast;
                        pixel += 0.5;
                        pixel *= 255;
                        if (pixel < 0) pixel = 0;
                        if (pixel > 255) pixel = 255;
                        p[2] = (byte)pixel;

                        pixel = green / 255.0;
                        pixel -= 0.5;
                        pixel *= contrast;
                        pixel += 0.5;
                        pixel *= 255;
                        if (pixel < 0) pixel = 0;
                        if (pixel > 255) pixel = 255;
                        p[1] = (byte)pixel;

                        pixel = blue / 255.0;
                        pixel -= 0.5;
                        pixel *= contrast;
                        pixel += 0.5;
                        pixel *= 255;
                        if (pixel < 0) pixel = 0;
                        if (pixel > 255) pixel = 255;
                        p[0] = (byte)pixel;

                        p += 3;
                    }
                    p += nOffset;
                }
            }

            b.UnlockBits(bmData);

            return true;
        }

        public static bool Gamma(Bitmap b, double red, double green, double blue)
        {
            if (red < .2 || red > 5) return false;
            if (green < .2 || green > 5) return false;
            if (blue < .2 || blue > 5) return false;

            byte[] redGamma = new byte[256];
            byte[] greenGamma = new byte[256];
            byte[] blueGamma = new byte[256];

            for (int i = 0; i < 256; ++i)
            {
                redGamma[i] = (byte)Math.Min(255, (int)((255.0 * Math.Pow(i / 255.0, 1.0 / red)) + 0.5));
                greenGamma[i] = (byte)Math.Min(255, (int)((255.0 * Math.Pow(i / 255.0, 1.0 / green)) + 0.5));
                blueGamma[i] = (byte)Math.Min(255, (int)((255.0 * Math.Pow(i / 255.0, 1.0 / blue)) + 0.5));
            }

            // GDI+ still lies to us - the return format is BGR, NOT RGB.
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int stride = bmData.Stride;
            System.IntPtr Scan0 = bmData.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;

                int nOffset = stride - b.Width * 3;

                for (int y = 0; y < b.Height; ++y)
                {
                    for (int x = 0; x < b.Width; ++x)
                    {
                        p[2] = redGamma[p[2]];
                        p[1] = greenGamma[p[1]];
                        p[0] = blueGamma[p[0]];

                        p += 3;
                    }
                    p += nOffset;
                }
            }

            b.UnlockBits(bmData);

            return true;
        }

        public static bool Color(Bitmap b, int red, int green, int blue)
        {
            if (red < -255 || red > 255) return false;
            if (green < -255 || green > 255) return false;
            if (blue < -255 || blue > 255) return false;

            // GDI+ still lies to us - the return format is BGR, NOT RGB.
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int stride = bmData.Stride;
            System.IntPtr Scan0 = bmData.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;

                int nOffset = stride - b.Width * 3;
                int nPixel;

                for (int y = 0; y < b.Height; ++y)
                {
                    for (int x = 0; x < b.Width; ++x)
                    {
                        nPixel = p[2] + red;
                        nPixel = Math.Max(nPixel, 0);
                        p[2] = (byte)Math.Min(255, nPixel);

                        nPixel = p[1] + green;
                        nPixel = Math.Max(nPixel, 0);
                        p[1] = (byte)Math.Min(255, nPixel);

                        nPixel = p[0] + blue;
                        nPixel = Math.Max(nPixel, 0);
                        p[0] = (byte)Math.Min(255, nPixel);

                        p += 3;
                    }
                    p += nOffset;
                }
            }

            b.UnlockBits(bmData);

            return true;
        }

        public static bool Conv3x3(Bitmap b, ConvMatrix m)
        {
            // Avoid divide by zero errors
            if (0 == m.Factor) return false;

            Bitmap bSrc = (Bitmap)b.Clone();

            // GDI+ still lies to us - the return format is BGR, NOT RGB.
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData bmSrc = bSrc.LockBits(new Rectangle(0, 0, bSrc.Width, bSrc.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int stride = bmData.Stride;
            int stride2 = stride * 2;
            System.IntPtr Scan0 = bmData.Scan0;
            System.IntPtr SrcScan0 = bmSrc.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;
                byte* pSrc = (byte*)(void*)SrcScan0;

                int nOffset = stride + 6 - b.Width * 3;
                int nWidth = b.Width - 2;
                int nHeight = b.Height - 2;

                int nPixel;

                for (int y = 0; y < nHeight; ++y)
                {
                    for (int x = 0; x < nWidth; ++x)
                    {
                        nPixel = ((((pSrc[2] * m.TopLeft) + (pSrc[5] * m.TopMid) + (pSrc[8] * m.TopRight) +
                            (pSrc[2 + stride] * m.MidLeft) + (pSrc[5 + stride] * m.Pixel) + (pSrc[8 + stride] * m.MidRight) +
                            (pSrc[2 + stride2] * m.BottomLeft) + (pSrc[5 + stride2] * m.BottomMid) + (pSrc[8 + stride2] * m.BottomRight)) / m.Factor) + m.Offset);

                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;

                        p[5 + stride] = (byte)nPixel;

                        nPixel = ((((pSrc[1] * m.TopLeft) + (pSrc[4] * m.TopMid) + (pSrc[7] * m.TopRight) +
                            (pSrc[1 + stride] * m.MidLeft) + (pSrc[4 + stride] * m.Pixel) + (pSrc[7 + stride] * m.MidRight) +
                            (pSrc[1 + stride2] * m.BottomLeft) + (pSrc[4 + stride2] * m.BottomMid) + (pSrc[7 + stride2] * m.BottomRight)) / m.Factor) + m.Offset);

                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;

                        p[4 + stride] = (byte)nPixel;

                        nPixel = ((((pSrc[0] * m.TopLeft) + (pSrc[3] * m.TopMid) + (pSrc[6] * m.TopRight) +
                            (pSrc[0 + stride] * m.MidLeft) + (pSrc[3 + stride] * m.Pixel) + (pSrc[6 + stride] * m.MidRight) +
                            (pSrc[0 + stride2] * m.BottomLeft) + (pSrc[3 + stride2] * m.BottomMid) + (pSrc[6 + stride2] * m.BottomRight)) / m.Factor) + m.Offset);

                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;

                        p[3 + stride] = (byte)nPixel;

                        p += 3;
                        pSrc += 3;
                    }

                    p += nOffset;
                    pSrc += nOffset;
                }
            }

            b.UnlockBits(bmData);
            bSrc.UnlockBits(bmSrc);

            return true;
        }
        public static bool Smooth(Bitmap b, int nWeight /* default to 1 */)
        {
            ConvMatrix m = new ConvMatrix();
            m.SetAll(1);
            m.Pixel = nWeight;
            m.Factor = nWeight + 8;

            return BitmapFilter.Conv3x3(b, m);
        }

        public static bool GaussianBlur(Bitmap b, int nWeight /* default to 4*/)
        {
            ConvMatrix m = new ConvMatrix();
            m.SetAll(1);

            m.Pixel = nWeight;
            m.TopMid = m.MidLeft = m.MidRight = m.BottomMid = 2;
            m.Factor = nWeight + 12;

            return BitmapFilter.Conv3x3(b, m);
        }
        public static bool MeanRemoval(Bitmap b, int nWeight /* default to 9*/ )
        {
            ConvMatrix m = new ConvMatrix();
            m.SetAll(-1);
            m.Pixel = nWeight;
            m.Factor = nWeight - 8;

            return BitmapFilter.Conv3x3(b, m);
        }
        public static bool Sharpen(Bitmap b, int nWeight /* default to 11*/ )
        {
            ConvMatrix m = new ConvMatrix();
            m.SetAll(0);
            m.Pixel = nWeight;
            m.TopMid = m.MidLeft = m.MidRight = m.BottomMid = -2;
            m.Factor = nWeight - 8;

            return BitmapFilter.Conv3x3(b, m);
        }
        public static bool EmbossLaplacian(Bitmap b)
        {
            ConvMatrix m = new ConvMatrix();
            m.SetAll(-1);
            m.TopMid = m.MidLeft = m.MidRight = m.BottomMid = 0;
            m.Pixel = 4;
            m.Offset = 127;

            return BitmapFilter.Conv3x3(b, m);
        }
        public static bool EdgeDetectQuick(Bitmap b)
        {
            ConvMatrix m = new ConvMatrix();
            m.TopLeft = m.TopMid = m.TopRight = -1;
            m.MidLeft = m.Pixel = m.MidRight = 0;
            m.BottomLeft = m.BottomMid = m.BottomRight = 1;

            m.Offset = 127;

            return BitmapFilter.Conv3x3(b, m);
        }
    }


    public class ImageTools
    {
        public class ExposedBitmap
        {
            public PinnedByteArray pinnedArray;
            public Bitmap exBitmap;

            public readonly PixelFormat pixelFormat;
            public readonly int bytesPerPixel;
            public readonly int stride;
            public readonly int Height;
            public readonly int Width;

            private int horizontalCoords = -1;
            private int verticalCoords = -1;
            private int horizontalLoc = 0;
            private int verticalLoc = 0;
            private int location = 0;

            public void GetPixel(int x, int y, out byte red, out byte green, out byte blue)
            {
                if (x == horizontalCoords && y == verticalCoords)
                {
                    blue = pinnedArray.bytes[location];
                    green = pinnedArray.bytes[location + 1];
                    red = pinnedArray.bytes[location + 2];
                    return;
                }
                else
                {
                    if (x != horizontalCoords)
                    {
                        horizontalCoords = x;
                        horizontalLoc = horizontalCoords * bytesPerPixel;
                    }

                    if (y != verticalCoords)
                    {
                        verticalCoords = y;
                        verticalLoc = verticalCoords * stride;
                    }

                    location = verticalLoc + horizontalLoc;
                }

                blue = pinnedArray.bytes[location];
                green = pinnedArray.bytes[location + 1];
                red = pinnedArray.bytes[location + 2];
            }

            public void SetPixel(int x, int y, byte red, byte green, byte blue)
            {
                if (x == horizontalCoords && y == verticalCoords)
                {
                    pinnedArray.bytes[location] = blue;
                    pinnedArray.bytes[location + 1] = green;
                    pinnedArray.bytes[location + 2] = red;
                    return;
                }
                else
                {
                    if (x != horizontalCoords)
                    {
                        horizontalCoords = x;
                        horizontalLoc = horizontalCoords * bytesPerPixel;
                    }

                    if (y != verticalCoords)
                    {
                        verticalCoords = y;
                        verticalLoc = verticalCoords * stride;
                    }

                    location = verticalLoc + horizontalLoc;
                }

                pinnedArray.bytes[location] = blue;
                pinnedArray.bytes[location + 1] = green;
                pinnedArray.bytes[location + 2] = red;
            }

            public byte GetRed(int x, int y)
            {
                if (x == horizontalCoords && y == verticalCoords)
                {
                    return pinnedArray.bytes[location + 2];
                }
                else
                {
                    if (x != horizontalCoords)
                    {
                        horizontalCoords = x;
                        horizontalLoc = horizontalCoords * bytesPerPixel;
                    }

                    if (y != verticalCoords)
                    {
                        verticalCoords = y;
                        verticalLoc = verticalCoords * stride;
                    }

                    location = verticalLoc + horizontalLoc;
                }

                return pinnedArray.bytes[location + 2];
            }

            public byte GetGreen(int x, int y)
            {
                if (x == horizontalCoords && y == verticalCoords)
                {
                    return pinnedArray.bytes[location + 1];
                }
                else
                {
                    if (x != horizontalCoords)
                    {
                        horizontalCoords = x;
                        horizontalLoc = horizontalCoords * bytesPerPixel;
                    }

                    if (y != verticalCoords)
                    {
                        verticalCoords = y;
                        verticalLoc = verticalCoords * stride;
                    }

                    location = verticalLoc + horizontalLoc;
                }

                return pinnedArray.bytes[location + 1];
            }

            public byte GetBlue(int x, int y)
            {
                if (x == horizontalCoords && y == verticalCoords)
                {
                    return pinnedArray.bytes[location];
                }
                else
                {
                    if (x != horizontalCoords)
                    {
                        horizontalCoords = x;
                        horizontalLoc = horizontalCoords * bytesPerPixel;
                    }

                    if (y != verticalCoords)
                    {
                        verticalCoords = y;
                        verticalLoc = verticalCoords * stride;
                    }

                    location = verticalLoc + horizontalLoc;
                }

                return pinnedArray.bytes[location];
            }

            public void SetRed(int x, int y, Byte byt)
            {
                if (x == horizontalCoords && y == verticalCoords)
                {
                    pinnedArray.bytes[location + 2] = byt;
                    return;
                }
                else
                {
                    if (x != horizontalCoords)
                    {
                        horizontalCoords = x;
                        horizontalLoc = horizontalCoords * bytesPerPixel;
                    }

                    if (y != verticalCoords)
                    {
                        verticalCoords = y;
                        verticalLoc = verticalCoords * stride;
                    }

                    location = verticalLoc + horizontalLoc;
                }

                pinnedArray.bytes[location + 2] = byt;
            }

            public void SetGreen(int x, int y, Byte byt)
            {
                if (x == horizontalCoords && y == verticalCoords)
                {
                    pinnedArray.bytes[location + 1] = byt;
                    return;
                }
                else
                {
                    if (x != horizontalCoords)
                    {
                        horizontalCoords = x;
                        horizontalLoc = horizontalCoords * bytesPerPixel;
                    }

                    if (y != verticalCoords)
                    {
                        verticalCoords = y;
                        verticalLoc = verticalCoords * stride;
                    }

                    location = verticalLoc + horizontalLoc;
                }

                pinnedArray.bytes[location + 1] = byt;
            }

            public void SetBlue(int x, int y, Byte byt)
            {
                if (x == horizontalCoords && y == verticalCoords)
                {
                    pinnedArray.bytes[location] = byt;
                    return;
                }
                else
                {
                    if (x != horizontalCoords)
                    {
                        horizontalCoords = x;
                        horizontalLoc = horizontalCoords * bytesPerPixel;
                    }

                    if (y != verticalCoords)
                    {
                        verticalCoords = y;
                        verticalLoc = verticalCoords * stride;
                    }

                    location = verticalLoc + horizontalLoc;
                }

                pinnedArray.bytes[location] = byt;
            }

            public class PinnedByteArray
            {
                public byte[] bytes;
                internal GCHandle handle;
                internal IntPtr ptr;
                private int referenceCount;
                private bool destroyed;

                public PinnedByteArray(int length)
                {
                    bytes = new byte[length];
                    handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
                    ptr = Marshal.UnsafeAddrOfPinnedArrayElement(bytes, 0);
                    referenceCount++;
                }

                internal void AddReference()
                {
                    referenceCount++;
                }

                internal void ReleaseReference()
                {
                    referenceCount--;
                    if (referenceCount <= 0) Destroy();
                }

                private void Destroy()
                {
                    if (!destroyed)
                    {
                        handle.Free();
                        bytes = null;
                        destroyed = true;
                    }
                }

                ~PinnedByteArray()
                {
                    Destroy();
                }
            }

            public ExposedBitmap(ref Bitmap sourceBmp)
            {
                // Get the basic info from sourceBmp and store it locally (improves performance)
                Height = sourceBmp.Height;
                Width = sourceBmp.Width;
                pixelFormat = sourceBmp.PixelFormat;

                // Create exBitmap, associating it with our pinned array so we can access the bitmap bits directly:
                bytesPerPixel = System.Drawing.Image.GetPixelFormatSize(pixelFormat) / 8;
                stride = Width * bytesPerPixel;
                pinnedArray = new PinnedByteArray(stride * Height);
                exBitmap = new Bitmap(Width, Height, stride, pixelFormat, pinnedArray.ptr);

                // Copy the image from sourceBmp to exBitmap:
                Graphics g = Graphics.FromImage(exBitmap);
                g.DrawImage(sourceBmp, 0, 0, Width, Height);
                g.Dispose();
            }
        }

        public static void Blur(ref Bitmap image)
        {
            Blur(ref image, new Rectangle(0, 0, image.Width, image.Height), 2);
        }

        public static void Blur(ref Bitmap image, Int32 blurSize)
        {
            Blur(ref image, new Rectangle(0, 0, image.Width, image.Height), blurSize);
        }

        private static void Blur(ref Bitmap image, Rectangle rectangle, Int32 blurSize)
        {
            ExposedBitmap blurred = new ExposedBitmap(ref image);

            // Store height & width locally (improives performance)
            int height = blurred.Height;
            int width = blurred.Width;

            for (int xx = rectangle.X; xx < rectangle.X + rectangle.Width; xx++)
            {
                for (int yy = rectangle.Y; yy < rectangle.Y + rectangle.Height; yy++)
                {
                    //byte red, green, blue;
                    double avgA = 0, avgR = 0, avgG = 0, avgB = 0;
                    int blurPixelCount = 0;
                    int horizontalLocation;
                    int verticalLocation;
                    int pixelPointer;

                    // Average the color of the red, green and blue for each pixel in the
                    // blur size while making sure you don't go outside the image bounds:
                    for (int x = xx; (x < xx + blurSize && x < width); x++)
                    {
                        horizontalLocation = x * blurred.bytesPerPixel;
                        for (int y = yy; (y < yy + blurSize && y < height); y++)
                        {
                            verticalLocation = y * blurred.stride;
                            pixelPointer = verticalLocation + horizontalLocation;

                            avgB += blurred.pinnedArray.bytes[pixelPointer];
                            avgG += blurred.pinnedArray.bytes[pixelPointer + 1];
                            avgR += blurred.pinnedArray.bytes[pixelPointer + 2];
                            avgA += blurred.pinnedArray.bytes[pixelPointer + 3];

                            blurPixelCount++;
                        }
                    }

                    double bavgr = (avgR / blurPixelCount);
                    double bavgg = (avgG / blurPixelCount);
                    double bavgb = (avgB / blurPixelCount);
                    double bavga = (avgA / blurPixelCount);

                    // Now that we know the average for the blur size, set each pixel to that color
                    for (int x = xx; x < xx + blurSize && x < width && x < rectangle.Width; x++)
                    {
                        horizontalLocation = x * blurred.bytesPerPixel;
                        for (int y = yy; y < yy + blurSize && y < height && y < rectangle.Height; y++)
                        {
                            verticalLocation = y * blurred.stride;
                            pixelPointer = verticalLocation + horizontalLocation;

                            blurred.pinnedArray.bytes[pixelPointer] = Convert.ToByte((int)bavgb);
                            blurred.pinnedArray.bytes[pixelPointer + 1] = Convert.ToByte((int)bavgg);
                            blurred.pinnedArray.bytes[pixelPointer + 2] = Convert.ToByte((int)bavgr);
                            blurred.pinnedArray.bytes[pixelPointer + 3] = Convert.ToByte((int)bavga);
                        }
                    }
                }
            }

            image = blurred.exBitmap;
        }
    }

    #endregion

    public partial class ImageBlur
    {

        public KernelMode Kernel { get; set; } = KernelMode.BoxBlur;


        public static Bitmap ApplyImageBlur(Bitmap sourceImage, int blurIntensity, KernelMode kernelMode)
        {
            return ApplyConvolution(sourceImage, kernelMode == KernelMode.BoxBlur ? GenerateBoxBlurKernel(blurIntensity) : GenerateGaussianKernel(blurIntensity));
        }

        static ParallelOptions po = new ParallelOptions() { MaxDegreeOfParallelism = Environment.ProcessorCount };

        private static Bitmap ApplyConvolution(Bitmap sourceImage, double[,] kernel)
        {
            int width = sourceImage.Width;
            int height = sourceImage.Height;
            Bitmap result = new Bitmap(width, height);
            result.MakeTransparent();
            int kernelSize = kernel.GetLength(0);
            int kernelRadius = kernelSize / 2;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    double r = 0, g = 0, b = 0, a = 0;
                    for (int ky = -kernelRadius; ky <= kernelRadius; ky++)
                    {
                        for (int kx = -kernelRadius; kx <= kernelRadius; kx++)
                        {
                            int pixelX = Clamp(x + kx, 0, width - 1);
                            int pixelY = Clamp(y + ky, 0, height - 1);

                            Color pixelColor = sourceImage.GetPixel(pixelX, pixelY);
                            r += pixelColor.R * kernel[ky + kernelRadius, kx + kernelRadius];
                            g += pixelColor.G * kernel[ky + kernelRadius, kx + kernelRadius];
                            b += pixelColor.B * kernel[ky + kernelRadius, kx + kernelRadius];
                            a += pixelColor.A * kernel[ky + kernelRadius, kx + kernelRadius];
                        }
                    }

                    int r1 = Clamp((int)Math.Round(r), 0, 255);
                    int g1 = Clamp((int)Math.Round(g), 0, 255);
                    int b1 = Clamp((int)Math.Round(b), 0, 255);
                    int a1 = Clamp((int)Math.Round(a), 0, 255);

                    result.SetPixel(x, y, Color.FromArgb(a1, r1, g1, b1));
                }
            }
            ;


            return result;
        }

        private static Bitmap ApplyConvolution1(Bitmap sourceImage, double[,] kernel)
        {
            int width = sourceImage.Width;
            int height = sourceImage.Height;
            Bitmap result = new Bitmap(width, height);
            result.MakeTransparent();
            int kernelSize = kernel.GetLength(0);
            int kernelRadius = kernelSize / 2;

            Parallel.For(0, height, po, y =>
            {
                for (int x = 0; x < width; x++)
                {
                    double r = 0, g = 0, b = 0, a = 0;
                    for (int ky = -kernelRadius; ky <= kernelRadius; ky++)
                    {
                        for (int kx = -kernelRadius; kx <= kernelRadius; kx++)
                        {
                            int pixelX = Clamp(x + kx, 0, width - 1);
                            int pixelY = Clamp(y + ky, 0, height - 1);

                            Color pixelColor = sourceImage.GetPixel(pixelX, pixelY);
                            Parallel.Invoke(
                            () => r += pixelColor.R * kernel[ky + kernelRadius, kx + kernelRadius],
                            () => g += pixelColor.G * kernel[ky + kernelRadius, kx + kernelRadius],
                            () => b += pixelColor.B * kernel[ky + kernelRadius, kx + kernelRadius],
                            () => a += pixelColor.A * kernel[ky + kernelRadius, kx + kernelRadius]
                            );
                        }
                    }

                    int r1 = Clamp((int)Math.Round(r), 0, 255);
                    int g1 = Clamp((int)Math.Round(g), 0, 255);
                    int b1 = Clamp((int)Math.Round(b), 0, 255);
                    int a1 = Clamp((int)Math.Round(a), 0, 255);

                    result.SetPixel(x, y, Color.FromArgb(a1, r1, g1, b1));
                }
                ;
            });

            return result;
        }

        #region Blur Kernel

        private static double[,] GenerateGaussianKernel(int radius)
        {
            int size = 2 * radius + 1;
            double[,] kernel = new double[size, size];
            double sigma = radius / 3.0;

            double twoSigmaSquare = 2.0 * sigma * sigma;
            double constant = 1.0 / (twoSigmaSquare * Math.PI);

            for (int x = -radius; x <= radius; x++)
            {
                for (int y = -radius; y <= radius; y++)
                {
                    double exponent = -(x * x + y * y) / twoSigmaSquare;
                    kernel[x + radius, y + radius] = constant * Math.Exp(exponent);
                }
            }

            return kernel;
        }

        private static double[,] GenerateBoxBlurKernel(int radius)
        {
            int size = 2 * radius + 1; // Đảm bảo kích thước kernel là số lẻ
            double[,] kernel = new double[size, size];
            double value = 1.0 / (size * size);

            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    kernel[x, y] = value;
                }
            }

            return kernel;
        }

        #endregion

        private static int Clamp(int value, int min, int max)
        {
            return Math.Max(min, Math.Min(max, value));
        }
    }
}