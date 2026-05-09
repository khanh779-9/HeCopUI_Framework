using HeCopUI_Framework.Components;
using HeCopUI_Framework.Enums;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls
{
    [ToolboxBitmap(typeof(Image))]
    public partial class HImage : Control
    {
        public HImage()
        {
            SetStyle(GetAppResources.SetControlStyles(), true);
            DoubleBuffered = true;
            //ProcessImg();
            Size = new Size(100, 100);
        }


        public enum ImageSizeMode
        {
            Custom, Zoom, Fill
        }

        private ImageSizeMode _imageSizeMode = ImageSizeMode.Zoom;
        public ImageSizeMode SetImageSizeMode
        {
            get { return _imageSizeMode; }
            set
            {
                _imageSizeMode = value;
                //ProcessImg();
                Invalidate();
            }
        }

        private Size _imageSize = new Size(150, 150);
        public Size ImageSize
        {
            get { return _imageSize; }
            set
            {
                _imageSize = value;
                //ProcessImg();
                Invalidate();
            }
        }



        private ShapeType _shapeType = ShapeType.RoundedRectangle;
        public ShapeType HShapeType
        {
            get { return _shapeType; }
            set
            {
                _shapeType = value;
                // ProcessImg();
                Invalidate();
            }
        }

        int _blurIntensity = 0;
        public int BlurIntensity
        {
            get { return _blurIntensity; }
            set
            {
                _blurIntensity = value;
                //ProcessImg();
                Invalidate();
            }
        }

        private Image _image;
        public Image Image
        {
            get { return _image; }
            set
            {
                _image = value;
                //ProcessImg();
                Invalidate();
            }
        }



        Bitmap blurBitmap = null;
        int SWi = 1; int SHi = 1;


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            Helper.GraphicsHelper.SetHightGraphics(g);
            try
            {
                AnimateImage();
                int SStart = 0; int SEnd = 0;
                #region ImageSizeMode
                switch (SetImageSizeMode)
                {
                    case ImageSizeMode.Zoom:
                        if (Width <= _image.Width)
                        {
                            SWi = Width;
                            if (SEnd != 0)
                                SEnd = Height / 2 - _image.Height / 2;
                            if (SStart != 0)
                                SStart = Width / 2 - _image.Height / 2;
                        }
                        if (Width > _image.Width)
                        {
                            SWi = _image.Width;
                            SStart = Width / 2 - _image.Height / 2;
                            SEnd = Height / 2 - _image.Height / 2;
                            if (SEnd < 0) SEnd = 0;
                        }
                        if (Height <= _image.Height)
                        {
                            SHi = Height;
                            if (SStart != 0)
                                SStart = Width / 2 - _image.Height / 2;
                            if (SEnd != 0)
                                SEnd = Height / 2 - _image.Height / 2;
                        }
                        if (Height > _image.Height)
                        {
                            SHi = _image.Height;
                            SStart = Width / 2 - _image.Height / 2;
                            SEnd = Height / 2 - _image.Height / 2;
                            if (SStart < 0) SStart = 0;
                        }

                        break;
                    case ImageSizeMode.Custom:
                        SStart = Width / 2 - _imageSize.Width / 2;
                        SEnd = Height / 2 - _imageSize.Height / 2;
                        SWi = _imageSize.Width; SHi = _imageSize.Height;
                        break;
                    case ImageSizeMode.Fill:
                        SWi = Width; SHi = Height;
                        break;

                }
                #endregion
                //Get the next frame ready for rendering.
                ImageAnimator.UpdateFrames();

                //Rectangle rect = new Rectangle(0, 0, SWi, SHi);
                GraphicsPath path = new GraphicsPath();

                ProcessImg();


                if (_image != null && blurBitmap != null)
                    g.DrawImage(CropCircle(blurBitmap, path), new Rectangle(SStart, SEnd, SWi, SHi));
                blurBitmap?.Dispose();
                path?.Dispose();

            }

            catch { }

        }

        void ProcessImg()
        {
            if (_image != null)
            {
                blurBitmap?.Dispose();
                blurBitmap = new Bitmap(SWi, SHi);
                blurBitmap.MakeTransparent();
                using (var gb = Graphics.FromImage(blurBitmap))
                {
                    gb.DrawImage((Bitmap)_image, new Rectangle(0, 0, SWi, SHi));
                    if (_blurIntensity > 0)
                        blurBitmap = ImageBlur.ApplyImageBlur(blurBitmap, _blurIntensity, kernelMode);
                }
            }
        }

        private KernelMode kernelMode = KernelMode.BoxBlur;
        public KernelMode KernelMode
        {
            get { return kernelMode; }
            set
            {
                kernelMode = value;
                Invalidate();
            }
        }

        private Bitmap CropCircle(Image img, GraphicsPath gp)
        {
            var roundedImage = new Bitmap(SWi, SHi);
            roundedImage.MakeTransparent();
            using (var g = Graphics.FromImage(roundedImage))
            {
                Helper.GraphicsHelper.SetHightGraphics(g);
                g.DrawImage(img, new Rectangle(0, 0, SWi, SHi));

                using (Brush brush = new TextureBrush(roundedImage, new Rectangle(0, 0, SWi, SHi)))
                {
                    g.Clear(Color.Transparent);
                    switch (HShapeType)
                    {
                        case ShapeType.RoundedRectangle:
                            gp.AddRectangle(new RectangleF(0, 0, SWi, SHi));
                            break;
                        case ShapeType.Circular:
                            gp.AddEllipse(0, 0, SWi, SHi);
                            break;
                    }
                    g.FillPath(brush, gp);
                    brush?.Dispose();
                    gp?.Dispose();
                }


            }
            return roundedImage;
        }


        private void OnFrameChanged(object o, EventArgs e)
        {

            Invalidate();
        }



        public void AnimateImage()
        {

            if (ImageAnimator.CanAnimate(_image) && !DesignMode)
            {
                ImageAnimator.Animate(_image, new EventHandler(OnFrameChanged));
            }
        }
    }
}
