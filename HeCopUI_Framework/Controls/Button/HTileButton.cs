using HeCopUI_Framework.Animations;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Brush = System.Drawing.Brush;
using Color = System.Drawing.Color;
using DashStyle = System.Drawing.Drawing2D.DashStyle;
using LinearGradientBrush = System.Drawing.Drawing2D.LinearGradientBrush;
using Pen = System.Drawing.Pen;

namespace HeCopUI_Framework.Controls.Button
{
    [ToolboxBitmap(typeof(HTileButton), "Bitmaps.Button.bmp")]
    public partial class HTileButton : Control
    {

        /// <summary>
        ///   Gets or sets the text associated with this control.
        /// </summary>
        [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public new string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value; Invalidate();
            }
        }
        protected override void OnTextChanged(EventArgs e)
        {
            Invalidate();
            base.OnTextChanged(e);
        }

        protected override void OnFontChanged(EventArgs e)
        {
            Invalidate();
            base.OnFontChanged(e);
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            Invalidate();
            base.OnForeColorChanged(e);
        }

        private System.Drawing.Text.TextRenderingHint textRenderHint = Helper.TextHelper.SetTextRender();
        public System.Drawing.Text.TextRenderingHint TextRenderHint
        {
            get { return textRenderHint; }
            set
            {
                textRenderHint = value; Invalidate();
            }
        }




        public HTileButton()
        {
            SetStyle(GetAppResources.SetControlStyles(), true);
            DoubleBuffered = true;
            _animationManager = new AnimationManager(true)
            {
                Increment = 0.03,
                AnimationType = Animations.AnimationType.EaseOut
            };

            object[] b = new object[] { new Point(0, 0) };
            _animationManager.StartNewAnimation(AnimationDirection.Out);
            _animationManager.SetData(b);

            _animationManager.OnAnimationProgress += _animationManager_OnAnimationProgress;
            _animationManager.OnAnimationFinished += _animationManager_OnAnimationFinished;
            Size = new Size(111, 123);

            DoubleBuffered = true;
            ForeColor = Color.White;

        }

        private void _animationManager_OnAnimationFinished(object sender)
        {
            _animationManager.Dispose();
        }

        private void _animationManager_OnAnimationProgress(object sender)
        {
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            butDo = false;
            Invalidate();
            base.OnMouseUp(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            butDo = true;
            if (PressColor1 == Color.Empty)
            {
                PressColor1 = Color.FromArgb(NormalColor1.R - 5, NormalColor1.G - 5, NormalColor1.B - 5);
            }
            if (AnimationMode == Enums.AnimationMode.Ripple)
                _animationManager.StartNewAnimation(AnimationDirection.In, e.Location);
            Invalidate();
            base.OnMouseDown(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            butHo = true;
            if (AnimationMode == Enums.AnimationMode.ColorTransition)
            {
                _animationManager.StartNewAnimation(AnimationDirection.In);
            }
            Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            butHo = false;
            if (AnimationMode == Enums.AnimationMode.ColorTransition)
            {
                _animationManager.StartNewAnimation(AnimationDirection.Out);
            }

            Invalidate();
            base.OnMouseLeave(e);
        }


        private Enums.AnimationMode animationMode = Enums.AnimationMode.None;
        public Enums.AnimationMode AnimationMode
        {
            get { return animationMode; }
            set
            {
                animationMode = value;
                switch (animationMode)
                {
                    case Enums.AnimationMode.None:
                        _animationManager.Singular = true;
                        break;
                    case Enums.AnimationMode.Ripple:
                        _animationManager.Singular = false;
                        _animationManager.Increment = 0.03;
                        break;
                    case Enums.AnimationMode.ColorTransition:
                        _animationManager.Singular = true;
                        _animationManager.Increment = 0.05;
                        break;
                }
                Invalidate();
            }
        }


        bool butHo;
        bool butDo;

        private Structs.CornerRadius Ra = new Structs.CornerRadius(5);

        /// <summary>
        /// Get or set radius of button
        /// </summary>
        [Description("Get or set radius of button")]
        public Structs.CornerRadius Radius
        {
            get { return Ra; }
            set
            {
                Ra = value; Invalidate();
            }
        }

        private int _borderThickness = 0;
        public int BorderThickness
        {
            get { return _borderThickness; }
            set
            {
                _borderThickness = value; Invalidate();
            }
        }

        // Base colors – renamed to follow HButton naming convention
        private Color _normalColor1 = Global.PrimaryColors.BackNormalColor1;
        private Color _normalColor2 = Global.PrimaryColors.BackNormalColor1;

        // Hover colors
        public Color HoverColor1 { get; set; } = Global.PrimaryColors.BackHoverColor1;
        public Color HoverColor2 { get; set; } = Global.PrimaryColors.BackHoverColor1;

        // Press colors
        public Color PressColor1 { get; set; } = Global.PrimaryColors.BackPressColor1;
        public Color PressColor2 { get; set; } = Global.PrimaryColors.BackPressColor1;

        // Normal background colors (primary/secondary)
        public Color NormalColor1
        {
            get => _normalColor1;
            set { _normalColor1 = value; Invalidate(); }
        }
        public Color NormalColor2
        {
            get => _normalColor2;
            set { _normalColor2 = value; Invalidate(); }
        }

        private Color _borderColor = Color.Transparent;
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value; Invalidate();
            }
        }

        private Image _buttonImage;
        public Image ButtonImage
        {
            get { return _buttonImage; }
            set
            {
                _buttonImage = value; Invalidate();

            }
        }



        private float _imageOffsetY = 5;
        public float ImageOffsetY
        {
            get { return _imageOffsetY; }
            set
            {
                _imageOffsetY = value; Invalidate();
            }
        }

        private Size _imageSize = new Size(50, 50);
        public Size ImageSize
        {
            get { return _imageSize; }
            set
            {
                _imageSize = value; Invalidate();
            }
        }

        private float _textYOffset = 1;
        public float TextYOffset
        {
            get { return _textYOffset; }
            set
            {
                _textYOffset = value; Invalidate();
            }
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

                //Begin the animation only once.
                ImageAnimator.Animate(_buttonImage, new EventHandler(OnFrameChanged));
                _currentlyAnimating = true;
            }
        }


        private StringFormat _stringFormat = new StringFormat();
        private Pen _pen;

        private int _interval = 200;
        /// <summary>
        /// Set speed animation with value type milisecond to show animate
        /// </summary>
        public int Interval
        {
            get { return _interval; }
            set
            {
                _interval = value; Invalidate();
            }
        }


        public Color RippleColor { get; set; } = Color.Black;


        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
        }

        private Padding textPadding = new Padding(0, 0, 0, 0);
        public Padding TextPadding
        {
            get
            {
                return textPadding;
            }
            set
            {
                textPadding = value;
                if (value.Left < 0) textPadding.Left = 0;
                if (value.Top < 0) textPadding.Top = 0;
                if (value.Right < 0) textPadding.Right = 0;
                if (value.Bottom < 0) textPadding.Bottom = 0; Invalidate();
            }
        }





        public Color BorderHoverColor { get; set; } = Color.Transparent;
        public Color BorderDownColor { get; set; } = Color.Transparent;

        private Padding shadowPadding = new Padding(0, 0, 0, 0);
        public Padding ShadowPadding
        {
            get { return shadowPadding; }
            set
            {
                shadowPadding = value;
                if (value.Left < 0) shadowPadding.Left = 0;
                if (value.Top < 0) shadowPadding.Top = 0;
                if (value.Right < 0) shadowPadding.Right = 0;
                if (value.Bottom < 0) shadowPadding.Bottom = 0; Invalidate();
            }
        }

        private Color shadowColor = Color.FromArgb(60, 0, 0, 0);
        public Color ShadowColor
        {
            get { return shadowColor; }
            set
            {
                shadowColor = value; Invalidate();
            }
        }

        private int shadowRad = 5;
        public int ShadowRadius
        {
            get { return shadowRad; }
            set
            {
                shadowRad = value; Invalidate();
            }

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            float b = 0f;
            // Define gradient rectangle similar to other button controls
            RectangleF rec = new RectangleF(3f + shadowPadding.Left, 3f + shadowPadding.Top, Width - 4 - shadowPadding.Right - shadowPadding.Left, Height - 4 - shadowPadding.Bottom - shadowPadding.Top);
            using (LinearGradientBrush LB1 =
               (AnimationMode == Enums.AnimationMode.ColorTransition) ? new LinearGradientBrush(rec, butDo ? PressColor1 : butHo ? HeCopUI_Framework.Helper.DrawHelper.BlendColor(NormalColor1, HoverColor1, 255 * _animationManager.GetProgress()) : HeCopUI_Framework.Helper.DrawHelper.BlendColor(NormalColor1, HoverColor1, 255 * _animationManager.GetProgress()),
                butDo ? PressColor2 : butHo ? HeCopUI_Framework.Helper.DrawHelper.BlendColor(NormalColor2, HoverColor2, 255 * _animationManager.GetProgress()) : HeCopUI_Framework.Helper.DrawHelper.BlendColor(NormalColor2, HoverColor2, 255 * _animationManager.GetProgress()), _gradientMode) :
               (AnimationMode == Enums.AnimationMode.Ripple) ? new LinearGradientBrush(rec, butHo ? HoverColor1 : NormalColor1, butHo ? HoverColor2 : NormalColor2, _gradientMode) :
                new LinearGradientBrush(rec, butDo ? PressColor1 : butHo ? HoverColor1 : NormalColor1, butDo ? PressColor2 : butHo ? HoverColor2 : NormalColor2, _gradientMode))

            using (GraphicsPath GP = HeCopUI_Framework.Helper.DrawHelper.SetRoundedCornerRectangle(new RectangleF(b + (shadowPadding.Left), b + (shadowPadding.Top),
                (Width - shadowPadding.Left) - (shadowPadding.Right), (Height - shadowPadding.Top) - (shadowPadding.Bottom)), Radius, _borderThickness))

            using (GraphicsPath SGP = HeCopUI_Framework.Helper.DrawHelper.SetRoundedCornerRectangle(new RectangleF(b, b, Width - b, Height - b), Radius))
            using (Bitmap bitmap = HeCopUI_Framework.Utils.DropShadow.Create(SGP, ShadowColor, shadowRad))
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                bitmap.MakeTransparent();
                if (ClipRegion == true && DesignMode == false && Ra.All != 0)
                {
                    Helper.GraphicsHelper.MakeTransparent(this, g);
                    Region = new Region(HeCopUI_Framework.Helper.DrawHelper.SetRoundedCornerRectangle(new RectangleF(0, 0, Width, Height), new Structs.CornerRadius(Ra.TopLeft, Ra.TopRight, Ra.BottomLeft, Ra.BottomRight, 2.5f)));
                }
                g.TextRenderingHint = TextRenderHint;
                if (Radius.All != 0)
                {
                    Helper.GraphicsHelper.SetHightGraphics(g);
                    Helper.GraphicsHelper.SetHightGraphics(e.Graphics);
                }
                if (Ra.All == 0)
                {
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                }
                _stringFormat.Trimming = ST;
                _stringFormat.Alignment = StringAlignment.Center;
                _stringFormat.LineAlignment = StringAlignment.Near;
                _pen = new Pen(new SolidBrush(butDo ? BorderDownColor : butHo ? BorderHoverColor : _borderColor), _borderThickness)
                {
                    Alignment = PenAlignment.Inset
                };

                g.FillPath(LB1, GP);

                if (_borderThickness != 0) g.DrawPath(_pen, GP);

                try
                {
                    AnimateImage();
                    ImageAnimator.UpdateFrames();
                    g.DrawImage(_buttonImage, new RectangleF(Width / 2 - _imageSize.Width / 2, _imageOffsetY, _imageSize.Width, _imageSize.Height));
                }
                catch { }
                if (Text != String.Empty)
                    g.DrawString(Text, Font, new SolidBrush(ForeColor), new RectangleF(2 + textPadding.Left, textPadding.Top + (_imageOffsetY + _imageSize.Height + _textYOffset), Width - 2 - textPadding.Right - textPadding.Left, (Height) - (_imageOffsetY + _imageSize.Height + _textYOffset) - textPadding.Bottom - textPadding.Top), _stringFormat);

                if (_animationManager.IsAnimating() && animationMode == Enums.AnimationMode.Ripple)
                {
                    for (var i = 0; i < _animationManager.GetAnimationCount(); i++)
                    {
                        var animationValue = _animationManager.GetProgress(i);
                        var animationSource = _animationManager.GetSource(i);
                        using (Brush rippleBrush = new SolidBrush(Color.FromArgb((int)(101 - (animationValue * 100)), RippleColor)))
                        {
                            var rippleSize = (int)(animationValue * (Math.Max(Width, Height)) * 3);
                            g.FillEllipse(rippleBrush, new Rectangle(animationSource.X - rippleSize / 2, animationSource.Y - rippleSize / 2, rippleSize, rippleSize));
                        }
                    }
                }
                if (Focused)
                {
                    using (GraphicsPath gpf = HeCopUI_Framework.Helper.DrawHelper.SetRoundedCornerRectangle(new RectangleF(b + (shadowPadding.Left), b + (shadowPadding.Top),
                    (Width - shadowPadding.Left) - (shadowPadding.Right),
                    (Height - shadowPadding.Top) - (shadowPadding.Bottom)), Radius, BorderThickness * 2 + 5))
                        g.DrawPath(new Pen(new SolidBrush(fbc), 1) { Alignment = PenAlignment.Inset, DashStyle = dashStyle }, gpf);
                }
                Brush br = new TextureBrush(bitmap);
                e.Graphics.FillPath(br, SGP);
            }

            base.OnPaint(e);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            Invalidate();
            base.OnGotFocus(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            Invalidate();
            base.OnLostFocus(e);
        }


        Color fbc = Color.White;
        public Color FocusBorderColor
        {
            get { return fbc; }
            set { fbc = value; Invalidate(); }
        }

        private DashStyle dashStyle = DashStyle.Dot;
        public DashStyle DashStyle
        {
            get
            {
                return dashStyle;
            }
            set
            {
                dashStyle = value; Invalidate();
            }
        }

        public bool ClipRegion { get; set; } = false;

        private readonly AnimationManager _animationManager;

        private LinearGradientMode _gradientMode = LinearGradientMode.Vertical;
        public LinearGradientMode GradientMode
        {
            get { return _gradientMode; }
            set
            {
                _gradientMode = value; Invalidate();
            }
        }

        public int AlphaAnimated { get; set; } = 180;




        private StringTrimming ST = StringTrimming.EllipsisCharacter;
        public StringTrimming TextTrim
        {
            get { return ST; }
            set
            {
                ST = value; Invalidate();
            }
        }


    }
}
