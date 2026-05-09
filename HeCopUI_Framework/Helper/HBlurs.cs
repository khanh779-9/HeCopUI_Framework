using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace HeCopUI_Framework.Helper
{
    /// <summary>
    /// Provides various optimized bitmap blurring methods.
    /// </summary>
    public static class HBlurs
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static byte Clamp(float v, float min = 0, float max = 255) => (byte)(v < 0 ? 0 : (v > 255 ? 255 : v));

        private static ParallelOptions parallelOptions => new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount };

        private static Bitmap To24bppRgb(Bitmap src)
        {
            if (src.PixelFormat == PixelFormat.Format24bppRgb)
                return (Bitmap)src.Clone();

            Bitmap bmp = new Bitmap(src.Width, src.Height, PixelFormat.Format24bppRgb);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.DrawImage(src, new Rectangle(0, 0, src.Width, src.Height));
            }
            return bmp;
        }

        private static void NormalizeKernel(float[] kernel)
        {
            float sum = 0;
            for (int i = 0; i < kernel.Length; i++) sum += kernel[i];
            if (sum == 0) return;
            for (int i = 0; i < kernel.Length; i++) kernel[i] /= sum;
        }

        private static void ApplySeparableKernel(Bitmap bmp, float[] kernel)
        {
            int width = bmp.Width, height = bmp.Height;
            Rectangle rect = new Rectangle(0, 0, width, height);
            BitmapData data = bmp.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int stride = data.Stride;
            int ksize = kernel.Length;
            int half = ksize / 2;

            unsafe
            {
                byte* scan0 = (byte*)data.Scan0.ToPointer();
                byte* tmp = (byte*)Marshal.AllocHGlobal(stride * height);

                // ---- Horizontal pass ----
                Parallel.For(0, height, parallelOptions, y =>
                {
                    byte* rowSrc = scan0 + y * stride;
                    byte* rowDst = tmp + (y * stride);

                    for (int x = 0; x < width; x++)
                    {
                        float b = 0, g = 0, r = 0;
                        for (int k = -half; k <= half; k++)
                        {
                            int px = x + k;
                            if (px < 0) px = 0;
                            else if (px >= width) px = width - 1;

                            byte* p = rowSrc + px * 3;
                            float w = kernel[half + k];
                            b += p[0] * w;
                            g += p[1] * w;
                            r += p[2] * w;
                        }
                        byte* dst = rowDst + x * 3;
                        dst[0] = (byte)Clamp(b, 0, 255);
                        dst[1] = (byte)Clamp(g, 0, 255);
                        dst[2] = (byte)Clamp(r, 0, 255);
                    }
                });

                // ---- Vertical pass ----
                Parallel.For(0, height, parallelOptions, y =>
                {
                    for (int x = 0; x < width; x++)
                    {
                        float b = 0, g = 0, r = 0;
                        for (int k = -half; k <= half; k++)
                        {
                            int py = y + k;
                            if (py < 0) py = 0;
                            else if (py >= height) py = height - 1;

                            byte* p = tmp + py * stride + x * 3;
                            float w = kernel[half + k];
                            b += p[0] * w;
                            g += p[1] * w;
                            r += p[2] * w;
                        }
                        byte* dst = scan0 + y * stride + x * 3;
                        dst[0] = (byte)Clamp(b, 0, 255);
                        dst[1] = (byte)Clamp(g, 0, 255);
                        dst[2] = (byte)Clamp(r, 0, 255);
                    }
                });

                Marshal.FreeHGlobal((IntPtr)tmp);
            }
            bmp.UnlockBits(data);
        }

        private static float[] CreateBoxKernel(int radius)
        {
            int size = radius * 2 + 1;
            float[] k = new float[size];
            for (int i = 0; i < size; i++) k[i] = 1f;
            NormalizeKernel(k);
            return k;
        }

        private static float[] CreateGaussianKernel(int radius)
        {
            int size = radius * 2 + 1;
            float[] k = new float[size];
            double sigma = Math.Max(0.0001, radius / 2.0);
            double denom = 2 * sigma * sigma;
            for (int i = 0; i < size; i++)
            {
                int x = i - radius;
                k[i] = (float)Math.Exp(-(x * x) / denom);
            }
            NormalizeKernel(k);
            return k;
        }

        public static Bitmap BoxBlur(Bitmap src, int radius)
        {
            if (radius < 1) return (Bitmap)src.Clone();
            Bitmap bmp = To24bppRgb(src);
            float[] kernel = CreateBoxKernel(radius);
            ApplySeparableKernel(bmp, kernel);
            return bmp;
        }

        public static Bitmap GaussianBlur(Bitmap src, int radius)
        {
            if (radius < 1) return (Bitmap)src.Clone();
            Bitmap bmp = To24bppRgb(src);
            float[] kernel = CreateGaussianKernel(radius);
            ApplySeparableKernel(bmp, kernel);
            return bmp;
        }

        public static Bitmap StackBlur(Bitmap src, int radius)
        {
            if (radius < 1) return (Bitmap)src.Clone();

            Bitmap bmp = To24bppRgb(src);
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData data = bmp.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int w = bmp.Width, h = bmp.Height, stride = data.Stride;
            int div = radius * 2 + 1;

            int[] dv = new int[256 * div];
            for (int i = 0; i < dv.Length; i++) dv[i] = i / div;

            unsafe
            {
                byte* scan0 = (byte*)data.Scan0;

                int[,] r = new int[h, w];
                int[,] g = new int[h, w];
                int[,] b = new int[h, w];

                Parallel.For(0, h, parallelOptions, y =>
                {
                    int rsum = 0, gsum = 0, bsum = 0;
                    byte* row = scan0 + y * stride;

                    for (int i = -radius; i <= radius; i++)
                    {
                        int px = Math.Min(w - 1, Math.Max(0, i));
                        byte* p = row + px * 3;
                        bsum += p[0];
                        gsum += p[1];
                        rsum += p[2];
                    }

                    for (int x = 0; x < w; x++)
                    {
                        r[y, x] = dv[rsum];
                        g[y, x] = dv[gsum];
                        b[y, x] = dv[bsum];

                        int remove = x - radius;
                        int add = x + radius + 1;
                        if (remove < 0) remove = 0;
                        if (add > w - 1) add = w - 1;

                        byte* pRemove = row + remove * 3;
                        byte* pAdd = row + add * 3;

                        bsum += pAdd[0] - pRemove[0];
                        gsum += pAdd[1] - pRemove[1];
                        rsum += pAdd[2] - pRemove[2];
                    }
                });

                Parallel.For(0, w, parallelOptions, x =>
                {
                    int rsum = 0, gsum = 0, bsum = 0;

                    for (int i = -radius; i <= radius; i++)
                    {
                        int py = Math.Min(h - 1, Math.Max(0, i));
                        bsum += b[py, x];
                        gsum += g[py, x];
                        rsum += r[py, x];
                    }

                    for (int y = 0; y < h; y++)
                    {
                        byte* p = scan0 + y * stride + x * 3;
                        p[0] = (byte)dv[bsum];
                        p[1] = (byte)dv[gsum];
                        p[2] = (byte)dv[rsum];

                        int remove = y - radius;
                        int add = y + radius + 1;
                        if (remove < 0) remove = 0;
                        if (add > h - 1) add = h - 1;

                        bsum += b[add, x] - b[remove, x];
                        gsum += g[add, x] - g[remove, x];
                        rsum += r[add, x] - r[remove, x];
                    }
                });
            }

            bmp.UnlockBits(data);
            return bmp;
        }
    }
}
