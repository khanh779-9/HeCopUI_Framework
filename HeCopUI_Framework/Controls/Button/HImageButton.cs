using HeCopUI_Framework.Enums;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls.Button
{
    [ToolboxBitmap(typeof(System.Windows.Forms.Button))]
    public partial class HImageButton : Control
    {
        ToolTip TT = null;
        public HImageButton()
        {
            SetStyle(GetAppResources.SetControlStyles(), true);
            DoubleBuffered = true;
            BackColor = Color.Transparent;
            Size = new Size(50, 50);
            Paint += PictureButton_Paint;
            MouseHover += (sender, e) =>
              {
                  Invalidate();
              };
            TT = new ToolTip();
            MouseEnter += (sender, e) =>
            {
                _isHovering = true;
                Invalidate();
            };
            MouseLeave += (sender, e) =>
            {
                _isHovering = false;
                Invalidate();
            };
            MouseDown += (sender, e) =>
              {
                  _isPressed = true;
                  Invalidate();
              };
            MouseUp += (sender, e) =>
            {
                _isPressed = false;
                Invalidate();
            };
        }

        private bool _isHovering = false;
        private bool _isPressed = false;

        public bool ShowTip { get; set; } = false;
        public string TipText { get; set; } = "Enter Text Here";


        private void PictureButton_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Helper.GraphicsHelper.SetHightGraphics(g);
            GraphicsPath path = new GraphicsPath();
            float sizex = _isPressed ? _buttonSize.Width : _isHovering ? _buttonHoverSize.Width : _buttonSize.Width;
            float sizey = _isPressed ? _buttonSize.Height : _isHovering ? _buttonHoverSize.Height : _buttonSize.Height;
            if (_buttonImage != null)
                g.DrawImage(CropCircle(_buttonImage, path), (Width / 2 - sizex / 2), (Height / 2 - sizey / 2), sizex, sizey);
        }

        protected override void OnInvalidated(InvalidateEventArgs e)
        {
            if (ShowTip == true)
            {
                TT.SetToolTip(this, TipText);

            }
            base.OnInvalidated(e);
        }

        private ShapeType _shapeType = ShapeType.RoundedRectangle;
        public ShapeType ShapeType
        {
            get { return _shapeType; }
            set
            {
                _shapeType = value; Invalidate();
            }
        }

        private Bitmap CropCircle(Image img, GraphicsPath gp)
        {
            AnimateImage();
            var roundedImage = new Bitmap(img.Width, img.Height, img.PixelFormat);
            roundedImage.MakeTransparent();
            float sizex = _isPressed ? _buttonSize.Width : _isHovering ? _buttonHoverSize.Width : _buttonSize.Width;
            float sizey = _isPressed ? _buttonSize.Height : _isHovering ? _buttonHoverSize.Height : _buttonSize.Height;
            ImageAnimator.UpdateFrames();
            using (var g = Graphics.FromImage(roundedImage))
            {
                Helper.GraphicsHelper.SetHightGraphics(g);
                Brush brush = new TextureBrush(img);
                switch (_shapeType)
                {
                    case ShapeType.RoundedRectangle:
                        gp.AddRectangle(new RectangleF(0, 0, img.Width, img.Height));
                        break;
                    case ShapeType.Circular:
                        gp.AddEllipse(new RectangleF(0, 0, img.Width, img.Height));
                        break;
                }
                g.FillPath(brush, gp);
            }
            return roundedImage;
        }


        private bool _currentlyAnimating = false;
        private void OnFrameChanged(object o, EventArgs e)
        {

            Invalidate();
        }
        public void AnimateImage()
        {
            if (!_currentlyAnimating)
            {
                ImageAnimator.Animate(_buttonImage, new EventHandler(OnFrameChanged));
                _currentlyAnimating = true;
            }
        }

        private Size _buttonHoverSize = new Size(20, 20);
        public Size ImageHoverSize
        {
            get { return _buttonHoverSize; }
            set
            {
                _buttonHoverSize = value; Invalidate();
            }
        }

        private Size _buttonSize = new Size(20, 20);
        public Size ImageSize
        {
            get { return _buttonSize; }
            set
            {
                _buttonSize = value; Invalidate();
            }
        }

        private Image _buttonImage = null;
        public Image ButtonImage
        {
            get { return _buttonImage; }
            set
            {
                _buttonImage = value; Invalidate();
            }
        }
    }
}
