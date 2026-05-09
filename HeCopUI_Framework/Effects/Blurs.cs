using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace HeCopUI_Framework.Effects
{
    public static class Blurs
    {
        public static class GaussianBlur
        {
            public static void Apply(ref Bitmap bitmap, float radius)
            {
                if (radius < 0.1f)
                {
                    return;
                }
                BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                int stride = bitmapData.Stride;
                int width = bitmap.Width;
                int height = bitmap.Height;

                // Sao chép dữ liệu bitmap vào mảng byte
                byte[] buffer = new byte[height * stride];
                Marshal.Copy(bitmapData.Scan0, buffer, 0, buffer.Length);

                float[] kernel = CreateGaussianKernel(radius);
                int kernelRadius = kernel.Length / 2;

                byte[] tempBuffer = new byte[buffer.Length];
                buffer.CopyTo(tempBuffer, 0);

                // Áp dụng kernel Gaussian blur theo chiều ngang
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        float sumR = 0f, sumG = 0f, sumB = 0f, weightSum = 0f;
                        for (int k = -kernelRadius; k <= kernelRadius; k++)
                        {
                            int nx = x + k;
                            if (nx >= 0 && nx < width)
                            {
                                int offset = y * stride + nx * 3;
                                float weight = kernel[kernelRadius + k];
                                sumB += tempBuffer[offset] * weight;
                                sumG += tempBuffer[offset + 1] * weight;
                                sumR += tempBuffer[offset + 2] * weight;
                                weightSum += weight;
                            }
                        }
                        int writeOffset = y * stride + x * 3;
                        buffer[writeOffset] = (byte)Clamp(sumB / weightSum, 0f, 255f);
                        buffer[writeOffset + 1] = (byte)Clamp(sumG / weightSum, 0f, 255f);
                        buffer[writeOffset + 2] = (byte)Clamp(sumR / weightSum, 0f, 255f);
                    }
                }

                // Áp dụng kernel Gaussian blur theo chiều dọc
                tempBuffer = (byte[])buffer.Clone();
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        float sumR = 0f, sumG = 0f, sumB = 0f, weightSum = 0f;
                        for (int k = -kernelRadius; k <= kernelRadius; k++)
                        {
                            int ny = y + k;
                            if (ny >= 0 && ny < height)
                            {
                                int offset = ny * stride + x * 3;
                                float weight = kernel[kernelRadius + k];
                                sumB += tempBuffer[offset] * weight;
                                sumG += tempBuffer[offset + 1] * weight;
                                sumR += tempBuffer[offset + 2] * weight;
                                weightSum += weight;
                            }
                        }
                        int writeOffset = y * stride + x * 3;
                        buffer[writeOffset] = (byte)Clamp(sumB / weightSum, 0f, 255f);
                        buffer[writeOffset + 1] = (byte)Clamp(sumG / weightSum, 0f, 255f);
                        buffer[writeOffset + 2] = (byte)Clamp(sumR / weightSum, 0f, 255f);
                    }
                }

                // Sao chép dữ liệu trở lại bitmap
                Marshal.Copy(buffer, 0, bitmapData.Scan0, buffer.Length);
                bitmap.UnlockBits(bitmapData);
            }

            private static float[] CreateGaussianKernel(float radius)
            {
                int size = (int)(Math.Ceiling(radius) * 2.0) + 1;
                float[] kernel = new float[size];
                float sigma = radius / 2f;
                float normalization = 1f / (float)(Math.Sqrt(2 * Math.PI) * sigma);
                float twoSigmaSquared = 2f * sigma * sigma;

                for (int i = 0; i < size; i++)
                {
                    int x = i - size / 2;
                    kernel[i] = normalization * (float)Math.Exp(-(x * x) / twoSigmaSquared);
                }

                return kernel;
            }


        }


        public static class QuadraticBlur
        {
            public static void Apply(ref Bitmap bitmap, float radius)
            {
                if (radius < 0.1f)
                {
                    return;
                }

                BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                                                        ImageLockMode.ReadWrite,
                                                        PixelFormat.Format24bppRgb);

                int stride = bitmapData.Stride;
                IntPtr scan = bitmapData.Scan0;
                int width = bitmap.Width;
                int height = bitmap.Height;

                byte[] buffer = new byte[height * stride];
                Marshal.Copy(scan, buffer, 0, buffer.Length);

                float[] kernel = CreateQuadraticKernel(radius);
                int kernelSize = kernel.Length;
                int kernelRadius = kernelSize / 2;

                byte[] tempBuffer = new byte[buffer.Length];

                // Horizontal pass
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        float rSum = 0f, gSum = 0f, bSum = 0f, weightSum = 0f;

                        for (int k = -kernelRadius; k <= kernelRadius; k++)
                        {
                            int x = j + k;
                            if (x >= 0 && x < width)
                            {
                                int offset = i * stride + x * 3;
                                float weight = kernel[kernelRadius + k];

                                bSum += buffer[offset] * weight;
                                gSum += buffer[offset + 1] * weight;
                                rSum += buffer[offset + 2] * weight;
                                weightSum += weight;
                            }
                        }

                        int tempOffset = i * stride + j * 3;
                        tempBuffer[tempOffset] = (byte)Clamp(bSum / weightSum, 0f, 255f);
                        tempBuffer[tempOffset + 1] = (byte)Clamp(gSum / weightSum, 0f, 255f);
                        tempBuffer[tempOffset + 2] = (byte)Clamp(rSum / weightSum, 0f, 255f);
                    }
                }

                // Vertical pass
                for (int j = 0; j < width; j++)
                {
                    for (int i = 0; i < height; i++)
                    {
                        float rSum = 0f, gSum = 0f, bSum = 0f, weightSum = 0f;

                        for (int k = -kernelRadius; k <= kernelRadius; k++)
                        {
                            int y = i + k;
                            if (y >= 0 && y < height)
                            {
                                int offset = y * stride + j * 3;
                                float weight = kernel[kernelRadius + k];

                                bSum += tempBuffer[offset] * weight;
                                gSum += tempBuffer[offset + 1] * weight;
                                rSum += tempBuffer[offset + 2] * weight;
                                weightSum += weight;
                            }
                        }

                        int offsetFinal = i * stride + j * 3;
                        buffer[offsetFinal] = (byte)Clamp(bSum / weightSum, 0f, 255f);
                        buffer[offsetFinal + 1] = (byte)Clamp(gSum / weightSum, 0f, 255f);
                        buffer[offsetFinal + 2] = (byte)Clamp(rSum / weightSum, 0f, 255f);
                    }
                }

                Marshal.Copy(buffer, 0, scan, buffer.Length);
                bitmap.UnlockBits(bitmapData);
            }

            private static float[] CreateQuadraticKernel(float radius)
            {
                int size = (int)(Math.Ceiling(radius) * 2.0) + 1;
                float[] kernel = new float[size];
                float radiusSquared = radius * radius;

                for (int i = 0; i < size; i++)
                {
                    float distance = i - radius;
                    kernel[i] = 1f - (distance * distance / radiusSquared);
                    if (kernel[i] < 0f)
                    {
                        kernel[i] = 0f;
                    }
                }
                return kernel;
            }


        }



        private static float Clamp(float value, float min, float max)
        {
            return Math.Max(min, Math.Min(max, value));
        }
    }
}
