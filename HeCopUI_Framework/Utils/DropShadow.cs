using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace HeCopUI_Framework.Utils
{
    public partial class DropShadow
    {
        const int CHANNELS = 4;
        const int InflateMultiple = 1;


        public static Rectangle GetBounds(GraphicsPath path, int radius, out Rectangle pathBounds, out int inflate)
        {
            var bounds = pathBounds = Rectangle.Ceiling(path.GetBounds());
            inflate = radius * InflateMultiple;
            bounds.Inflate(inflate, inflate);
            return bounds;
        }


        public static Rectangle GetBounds(Rectangle source, int radius)
        {
            var inflate = radius * InflateMultiple;
            source.Inflate(inflate, inflate);
            return source;
        }


        public static Bitmap Create(GraphicsPath path, Color color, int radius = 5)
        {
            var bounds = GetBounds(path, radius, out Rectangle pathBounds, out int inflate);
            var shadow = new Bitmap(bounds.Width, bounds.Height);

            if (color.A == 0)
            {
                return shadow;
            }


            Graphics g = null;
            GraphicsPath pathCopy = null;
            Matrix matrix = null;
            SolidBrush brush = null;
            try
            {
                matrix = new Matrix();
                matrix.Translate(-pathBounds.X + inflate, -pathBounds.Y + inflate);
                pathCopy = (GraphicsPath)path.Clone();
                pathCopy.Transform(matrix);

                brush = new SolidBrush(color);

                g = Graphics.FromImage(shadow);
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.FillPath(brush, pathCopy);
            }
            finally
            {
                g?.Dispose();
                brush?.Dispose();
                pathCopy?.Dispose();
                matrix?.Dispose();
            }

            if (radius <= 0)
            {
                return shadow;
            }

            BitmapData data = null;
            try
            {
                data = shadow.LockBits(new Rectangle(0, 0, shadow.Width, shadow.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);


                //var boxes = DetermineBoxes(radius, 3);
                BoxBlur(data, radius, color);
                BoxBlur(data, radius, color);
                //BoxBlur(shadowData, radius);

                return shadow;
            }
            finally
            {
                shadow.UnlockBits(data);
            }
        }

        /// <summary>
        /// 方框模糊
        /// </summary>
        /// <param name="data">Gets or sets image data</param>
        /// <param name="radius">Gets or sets radius Blur</param>
        /// <param name="color">Gets or sets color transparent</param>
#if UNSAFE
            private static unsafe void BoxBlur(BitmapData data, int radius, Color color)
#else
        private static void BoxBlur(BitmapData data, int radius, Color color)
#endif
        {
#if UNSAFE 
                IntPtr p1 = data1.Scan0;
#else
            byte[] p1 = new byte[data.Stride * data.Height];
            Marshal.Copy(data.Scan0, p1, 0, p1.Length);
#endif

            byte R = color.R, G = color.G, B = color.B;
            for (int i = 3; i < p1.Length; i += 4)
            {
                if (p1[i] == 0)
                {
                    p1[i - 1] = R;
                    p1[i - 2] = G;
                    p1[i - 3] = B;
                }
            }

            byte[] p2 = new byte[p1.Length];
            int radius2 = 2 * radius + 1;
            int First, Last, Sum;
            int stride = data.Stride,
                width = data.Width,
                height = data.Height;

            //Xử lí Alpha

            //Nằm ngang
            for (int r = 0; r < height; r++)
            {
                int start = r * stride;
                int left = start;
                int right = start + radius * CHANNELS;

                First = p1[start + 3];
                Last = p1[start + stride - 1];
                Sum = (radius + 1) * First;

                for (int column = 0; column < radius; column++)
                {
                    Sum += p1[start + column * CHANNELS + 3];
                }
                for (var column = 0; column <= radius; column++, right += CHANNELS, start += CHANNELS)
                {
                    Sum += p1[right + 3] - First;
                    p2[start + 3] = (byte)(Sum / radius2);
                }
                for (var column = radius + 1; column < width - radius; column++, left += CHANNELS, right += CHANNELS, start += CHANNELS)
                {
                    Sum += p1[right + 3] - p1[left + 3];
                    p2[start + 3] = (byte)(Sum / radius2);
                }
                for (var column = width - radius; column < width; column++, left += CHANNELS, start += CHANNELS)
                {
                    Sum += Last - p1[left + 3];
                    p2[start + 3] = (byte)(Sum / radius2);
                }
            }

            //Thẳng đứng
            for (int column = 0; column < width; column++)
            {
                int start = column * CHANNELS;
                int top = start;
                int bottom = start + radius * stride;

                First = p2[start + 3];
                Last = p2[start + (height - 1) * stride + 3];
                Sum = (radius + 1) * First;

                for (int row = 0; row < radius; row++)
                {
                    Sum += p2[start + row * stride + 3];
                }
                for (int row = 0; row <= radius; row++, bottom += stride, start += stride)
                {
                    Sum += p2[bottom + 3] - First;
                    p1[start + 3] = (byte)(Sum / radius2);
                }
                for (int row = radius + 1; row < height - radius; row++, top += stride, bottom += stride, start += stride)
                {
                    Sum += p2[bottom + 3] - p2[top + 3];
                    p1[start + 3] = (byte)(Sum / radius2);
                }
                for (int row = height - radius; row < height; row++, top += stride, start += stride)
                {
                    Sum += Last - p2[top + 3];
                    p1[start + 3] = (byte)(Sum / radius2);
                }
            }
#if !UNSAFE
            Marshal.Copy(p1, 0, data.Scan0, p1.Length);
#endif
        }

    }
}
