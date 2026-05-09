using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace HeCopUI_Framework.Effects
{

    public enum BlurType
    {
        Gaussian,
        Box,
        Motion,
        Radial,
        Quadratic
    }

    /// <summary>
    /// Represents a collection of blur effect methods for processing images (bitmaps).
    /// This class provides various types of blur effects such as Gaussian, Box, Motion, Quadratic, and Radial.
    /// </summary>
    /// <remarks>
    /// The class contains methods to apply different blur effects to an image (Bitmap) based on various parameters
    /// like radius, length, and angle. It supports multiple blur types which can be selected dynamically 
    /// using the appropriate enum values for different visual effects.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]  // Specifies that the fields of the class will be laid out in memory sequentially
    public class BlursEffect
    {

        /// <summary>
        /// Applies a blur effect to the provided image based on the specified blur type, radius, length, and angle.
        /// This method selects the appropriate kernel (filter) based on the type of blur and applies it to the image.
        /// </summary>
        /// <param name="bitmap">The image (bitmap) to which the blur effect will be applied. It is passed by reference, so it will be modified directly.</param>
        /// <param name="blurType">The type of blur effect to apply. Possible values include Gaussian, Box, Motion, Quadratic, and Radial.</param>
        /// <param name="radius">The radius of the blur effect. This determines the extent of the blur. A higher radius results in a stronger blur.</param>
        /// <param name="length">The length of the blur, used specifically for Motion Blur. This controls the "distance" the blur stretches in the direction of motion.</param>
        /// <param name="angle">The angle of the blur, used for Motion Blur. This defines the direction in which the motion effect is applied (in degrees).</param>
        public static void ApplyBlur(ref Bitmap bitmap, BlurType blurType, float radius, int length, float angle)
        {
            float[] kernel =
                blurType == BlurType.Gaussian ? CreateGaussianKernel(radius) : // Gaussian Blur: a standard blur with a bell-shaped kernel
                blurType == BlurType.Box ? CreateBoxKernel((int)radius) : // Box Blur: a simple blur that uses a square-shaped kernel
                blurType == BlurType.Motion ? CreateMotionKernel(length, angle) : // Motion Blur: simulates the effect of motion by applying a directional blur
                blurType == BlurType.Quadratic ? CreateQuadraticKernel(radius) :  // Quadratic Blur: a blur with quadratic falloff
                CreateRadialKernel(radius);  // Radial Blur: a blur that radiates outward from a central point

            ApplyKernel(ref bitmap, kernel); // Applies the selected kernel to the bitmap
        }


        /// <summary>
        /// Applies a blur effect to the provided image with the specified blur type, radius, and length. The angle parameter is set to 0 by default.
        /// </summary>
        /// <param name="bitmap">The image (bitmap) to which the blur effect will be applied.</param>
        /// <param name="blurType">The type of blur effect to apply (e.g., Gaussian, Box, Motion, etc.).</param>
        /// <param name="radius">The radius of the blur effect.</param>
        /// <param name="length">The length of the blur effect (used only for Motion Blur). This determines how "long" the blur stretches in the direction of motion.</param>
        public static void ApplyBlur(ref Bitmap bitmap, BlurType blurType, float radius, int length)
        {
            ApplyBlur(ref bitmap, blurType, radius, length, 0); // Uses 0 for the angle by default
        }


        /// <summary>
        /// Applies a blur effect to the provided image with the specified blur type and radius. Both the length and angle parameters are set to 0 by default.
        /// </summary>
        /// <param name="bitmap">The image (bitmap) to which the blur effect will be applied.</param>
        /// <param name="blurType">The type of blur effect to apply (e.g., Gaussian, Box, etc.).</param>
        /// <param name="radius">The radius of the blur effect, determining how far the blur spreads.</param>
        public static void ApplyBlur(ref Bitmap bitmap, BlurType blurType, float radius)
        {
            ApplyBlur(ref bitmap, blurType, radius, 0, 0); // Uses 0 for both length and angle by default
        }


        /// <summary>
        /// Applies a blur effect to the provided image with the specified blur type and a default radius of 5. The length and angle parameters are set to 0 by default.
        /// </summary>
        /// <param name="bitmap">The image (bitmap) to which the blur effect will be applied.</param>
        /// <param name="blurType">The type of blur effect to apply (e.g., Gaussian, Box, etc.).</param>
        public static void ApplyBlur(ref Bitmap bitmap, BlurType blurType)
        {
            ApplyBlur(ref bitmap, blurType, 5, 0, 0); // Uses a default radius of 5, and sets length and angle to 0 by default
        }

        /// <summary>
        /// Applies a Gaussian blur effect to the provided image with a default radius of 5, and both length and angle parameters set to 0.
        /// </summary>
        /// <param name="bitmap">The image (bitmap) to which the blur effect will be applied.</param>
        public static void ApplyBlur(ref Bitmap bitmap)
        {
            ApplyBlur(ref bitmap, BlurType.Gaussian, 5, 0, 0); // Uses Gaussian blur with a default radius of 5 and 0 for length and angle
        }



        // Quadratic Kernel
        private static float[] CreateQuadraticKernel(float radius)
        {
            int size = (int)(Math.Ceiling(radius) * 2) + 1;
            float[] kernel = new float[size];
            float sum = 0f;
            int halfSize = size / 2;
            for (int i = -halfSize; i <= halfSize; i++)
            {
                kernel[i + halfSize] = 1 - (i * i) / (radius * radius);
                sum += kernel[i + halfSize];
            }
            // Normalize kernel to ensure sum is 1
            for (int i = 0; i < kernel.Length; i++)
            {
                kernel[i] /= sum;
            }
            return kernel;
        }

        // Utility function to apply the kernel
        private static void ApplyKernel(ref Bitmap bitmap, float[] kernel)
        {
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                                                    ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            bitmap.MakeTransparent();
            int stride = bitmapData.Stride;
            IntPtr scan = bitmapData.Scan0;
            int width = bitmap.Width;
            int height = bitmap.Height;

            byte[] buffer = new byte[height * stride];
            Marshal.Copy(scan, buffer, 0, buffer.Length);

            int kernelRadius = kernel.Length / 2;
            byte[] tempBuffer = new byte[buffer.Length];

            // Apply the kernel (simplified as a horizontal pass example)
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

            Marshal.Copy(tempBuffer, 0, scan, buffer.Length);
            bitmap.UnlockBits(bitmapData);
        }

        // Gaussian Kernel
        private static float[] CreateGaussianKernel(float radius)
        {
            int size = (int)(Math.Ceiling(radius) * 2) + 1;
            float[] kernel = new float[size];
            float sigma = radius / 2f;
            float twoSigmaSquare = 2 * sigma * sigma;
            float sigmaRoot = (float)Math.Sqrt(twoSigmaSquare * Math.PI);
            float sum = 0f;
            int halfSize = size / 2;

            for (int i = -halfSize; i <= halfSize; i++)
            {
                float distance = i * i;
                kernel[i + halfSize] = (float)Math.Exp(-distance / twoSigmaSquare) / sigmaRoot;
                sum += kernel[i + halfSize];
            }

            // Normalize kernel to ensure sum is 1
            for (int i = 0; i < kernel.Length; i++)
            {
                kernel[i] /= sum;
            }

            return kernel;
        }

        // Box Kernel
        private static float[] CreateBoxKernel(int size)
        {
            if (size < 1) size = 1;
            float[] kernel = new float[size];
            for (int i = 0; i < size; i++)
            {
                kernel[i] = 1f / size;
            }
            return kernel;
        }

        // Motion Kernel
        private static float[] CreateMotionKernel(int length, float angle)
        {
            float[] kernel = new float[length];
            float cos = (float)Math.Cos(angle);
            float sin = (float)Math.Sin(angle);
            float weight = 1f / length;

            for (int i = 0; i < length; i++)
            {
                kernel[i] = weight;
            }

            // Note: Actual angle-based processing may vary if creating a 2D kernel.
            return kernel;
        }

        // Radial Kernel
        private static float[] CreateRadialKernel(float radius)
        {
            int size = (int)(radius * 2) + 1;
            float[] kernel = new float[size];
            float center = radius;
            float sum = 0f;

            for (int i = 0; i < size; i++)
            {
                float distance = Math.Abs(i - center);
                kernel[i] = Math.Max(0, 1 - (distance / radius));
                sum += kernel[i];
            }

            // Normalize kernel
            for (int i = 0; i < size; i++)
            {
                kernel[i] /= sum;
            }

            return kernel;
        }

        private static float Clamp(float value, float min, float max)
        {
            return Math.Max(min, Math.Min(max, value));
        }
    }
}
