using HeCopUI_Framework.Animations;
using HeCopUI_Framework.Structs;
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
    [ToolboxBitmap(typeof(HTileSubtitleButton), "Bitmaps.Button.bmp")]
    public partial class HTileSubtitleButton : Control
    {
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Padding Padding { get; set; }

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

        protected override void OnCreateControl()
        {
            Invalidate();
            base.OnCreateControl();
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            Invalidate();
            base.OnForeColorChanged(e);
        }

        public HTileSubtitleButton()
        {
            SetStyle(GetAppResources.SetControlStyles(), true);
            DoubleBuffered = true;
            _animationManager = new AnimationManager(true)
            {
                Increment = 0.03,
                AnimationType = Animations.AnimationType.EaseOut
            };

            _animationManager.StartNewAnimation(AnimationDirection.Out);
            _animationManager.SetData(new object[] { new Point(0, 0) });

            Size = new Size(111, 123);
            BackColor = Color.Transparent;

            _animationManager.OnAnimationProgress += delegate { Invalidate(); };
            ForeColor = Color.White;
        }

        private bool _isButtonPressed = false;
        private bool _isButtonHovered = false;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            _isButtonPressed = true;
            if (AnimationMode == Enums.AnimationMode.Ripple)
                _animationManager.StartNewAnimation(Animations.AnimationDirection.In, e.Location);
            Invalidate();
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            _isButtonPressed = false;
            Invalidate();
            base.OnMouseUp(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            _isButtonHovered = true;
            if (AnimationMode == Enums.AnimationMode.ColorTransition)
                _animationManager.StartNewAnimation(Animations.AnimationDirection.In);
            Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            _isButtonHovered = false;
            if (AnimationMode == Enums.AnimationMode.ColorTransition)
                _animationManager.StartNewAnimation(Animations.AnimationDirection.Out);
            Invalidate();
            base.OnMouseLeave(e);
        }

        // Hover and press colors (secondary)
        public Color HoverColor2 { get; set; } = Global.PrimaryColors.BackHoverColor1;
        public Color PressColor2 { get; set; } = Global.PrimaryColors.BackPressColor1;
        private Color _normalColor2 = Global.PrimaryColors.BackNormalColor1;
        public Color NormalColor2
        {
            get => _normalColor2;
            set { _normalColor2 = value; Invalidate(); }
        }

        private Animations.AnimationManager _animationManager;

        Enums.AnimationMode animationMode = Enums.AnimationMode.None;
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

        private int _interval = 200;
        public int Interval
        {
            get { return _interval; }
            set { _interval = value; Invalidate(); }
        }

        public Color RippleColor { get; set; } = Color.Black;

        private CornerRadius _radiusValue = new CornerRadius(5);
        [Description("Get or set radius of button")]
        public CornerRadius Radius
        {
            get { return _radiusValue; }
            set { _radiusValue = value; Invalidate(); }
        }

        private int _borderThickness = 0;
        public int BorderThickness
        {
            get { return _borderThickness; }
            set { _borderThickness = value; Invalidate(); }
        }

        private Color _normalColor1 = Global.PrimaryColors.BackNormalColor1;
        // Hover and press colors (primary)
        public Color HoverColor1 { get; set; } = Global.PrimaryColors.BackHoverColor1;
        public Color PressColor1 { get; set; } = Global.PrimaryColors.BackPressColor1;
        public Color NormalColor1
        {
            get => _normalColor1;
            set { _normalColor1 = value; Invalidate(); }
        }

        private Color _borderColor = Color.Transparent;
        public Color BorderColor
        {
            get { return _borderColor; }
            set { _borderColor = value; Invalidate(); }
        }

        private Image _buttonImage;
        public Image ButtonImage
        {
            get { return _buttonImage; }
            set { _buttonImage = value; Invalidate(); }
        }

        private int _imageOffsetY = 5;
        public int ImageOffsetY
        {
            get { return _imageOffsetY; }
            set { _imageOffsetY = value; Invalidate(); }
        }

        private Size _imageSize = new Size(50, 50);
        public Size ImageSize
        {
            get { return _imageSize; }
            set { _imageSize = value; Invalidate(); }
        }

        private float _textOffsetY_Float = 1;
        public float TextOffsetY_Float
        {
            get { return _textOffsetY_Float; }
            set { _textOffsetY_Float = value; Invalidate(); }
        }

        bool _currentlyAnimating = false;
        private void OnFrameChanged(object o, EventArgs e)
        {
            Invalidate();
        }

        public void AnimateImage()
        {
            if (_buttonImage != null && !_currentlyAnimating)
            {
                ImageAnimator.Animate(_buttonImage, new EventHandler(OnFrameChanged));
                _currentlyAnimating = true;
            }
        }

        private LinearGradientMode _gradientMode = LinearGradientMode.Vertical;
        public LinearGradientMode GradientMode
        {
            get { return _gradientMode; }
            set { _gradientMode = value; Invalidate(); }
        }

        public Color BorderHoverColor { get; set; } = Color.Transparent;
        public Color BorderDownColor { get; set; } = Color.Transparent;

        private Padding _shadowPadding = new Padding(0);
        public Padding ShadowPadding
        {
            get { return _shadowPadding; }
            set
            {
                _shadowPadding = value;
                if (value.Left < 0) _shadowPadding.Left = 0;
                if (value.Top < 0) _shadowPadding.Top = 0;
                if (value.Right < 0) _shadowPadding.Right = 0;
                if (value.Bottom < 0) _shadowPadding.Bottom = 0;
                Invalidate();
            }
        }

        private Color _shadowColor = Color.FromArgb(60, 0, 0, 0);
        public Color ShadowColor
        {
            get { return _shadowColor; }
            set { _shadowColor = value; Invalidate(); }
        }

        private int _shadowRadius = 5;
        public int ShadowRadius
        {
            get { return _shadowRadius; }
            set { _shadowRadius = value; Invalidate(); }
        }

        private System.Drawing.Text.TextRenderingHint textRenderHint = Helper.TextHelper.SetTextRender();
        public System.Drawing.Text.TextRenderingHint TextRenderHint
        {
            get { return textRenderHint; }
            set { textRenderHint = value; Invalidate(); }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            float b = 0f;
            // Define gradient rectangle similar to other button controls
            RectangleF rec = new RectangleF(3f + ShadowPadding.Left, 3f + ShadowPadding.Top, Width - 4 - ShadowPadding.Right - ShadowPadding.Left, Height - 4 - ShadowPadding.Bottom - ShadowPadding.Top);

            using (GraphicsPath SGP = HeCopUI_Framework.Helper.DrawHelper.SetRoundedCornerRectangle(new RectangleF(b, b, Width, Height), Radius))
            using (GraphicsPath GP = HeCopUI_Framework.Helper.DrawHelper.SetRoundedCornerRectangle(new RectangleF(b + ShadowPadding.Left, b + ShadowPadding.Top, (Width - ShadowPadding.Left) - ShadowPadding.Right, (Height - ShadowPadding.Top) - ShadowPadding.Bottom), Radius, BorderThickness))
            using (Bitmap bitmap = HeCopUI_Framework.Utils.DropShadow.Create(SGP, ShadowColor, ShadowRadius))
            using (Graphics g = Graphics.FromImage(bitmap))
            using (Pen pen = new Pen(new SolidBrush(_isButtonPressed ? BorderDownColor : _isButtonHovered ? BorderHoverColor : BorderColor), BorderThickness))
            using (LinearGradientBrush LA = (AnimationMode == Enums.AnimationMode.ColorTransition) ? 
                new LinearGradientBrush(rec, 
                    _isButtonPressed ? PressColor1 : _isButtonHovered ? HeCopUI_Framework.Helper.DrawHelper.BlendColor(NormalColor1, HoverColor1, (int)(255 * _animationManager.GetProgress())) : HeCopUI_Framework.Helper.DrawHelper.BlendColor(NormalColor1, HoverColor1, (int)(255 * _animationManager.GetProgress())),
                    _isButtonPressed ? PressColor2 : _isButtonHovered ? HeCopUI_Framework.Helper.DrawHelper.BlendColor(NormalColor2, HoverColor2, (int)(255 * _animationManager.GetProgress())) : HeCopUI_Framework.Helper.DrawHelper.BlendColor(NormalColor2, HoverColor2, (int)(255 * _animationManager.GetProgress())), GradientMode) :
               (AnimationMode == Enums.AnimationMode.Ripple) ? new LinearGradientBrush(rec, _isButtonHovered ? HoverColor1 : NormalColor1, _isButtonHovered ? HoverColor2 : NormalColor2, GradientMode) :
                new LinearGradientBrush(rec, _isButtonPressed ? PressColor1 : _isButtonHovered ? HoverColor1 : NormalColor1, _isButtonPressed ? PressColor2 : _isButtonHovered ? HoverColor2 : NormalColor2, GradientMode))
            {
                bitmap.MakeTransparent();
                if (ClipRegion == true && DesignMode == false && Radius.All != 0)
                {
                    Helper.GraphicsHelper.MakeTransparent(this, g);
                    Region = new Region(HeCopUI_Framework.Helper.DrawHelper.SetRoundedCornerRectangle(new RectangleF(0, 0, Width, Height), new CornerRadius(Radius.TopLeft, Radius.TopRight, Radius.BottomLeft, Radius.BottomRight, 2.5f)));
                }
                g.TextRenderingHint = TextRenderHint;
                if (Radius.All != 0)
                {
                    Helper.GraphicsHelper.SetHightGraphics(g);
                    Helper.GraphicsHelper.SetHightGraphics(e.Graphics);
                }
                if (Radius.All == 0)
                {
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                }

                pen.Alignment = PenAlignment.Inset;
                g.FillPath(LA, GP);
                
                try
                {
                    if (ButtonImage != null)
                    {
                        AnimateImage();
                        ImageAnimator.UpdateFrames();
                        g.DrawImage(ButtonImage, new RectangleF(Width / 2 - ImageSize.Width / 2, ImageOffsetY, ImageSize.Width, ImageSize.Height));
                    }
                }
                catch { }

                StringFormat SF = new StringFormat { Trimming = TextTrim };
                Helper.TextHelper.SetStringAlign(SF, TextAlign);
                StringFormat SAF = new StringFormat { Trimming = TextTrim };
                Helper.TextHelper.SetStringAlign(SAF, SubTextAlign);

                g.DrawString(Text, Font, new SolidBrush(ForeColor), new RectangleF(2 + TextPadding.Left, Font.Height + (ImageOffsetY + ImageSize.Height + TextOffsetY) + TextPadding.Top, Width - 2 - TextPadding.Right, TextY + Font.Height - TextPadding.Bottom), SF);
                g.DrawString(SubText, SubTextFont, new SolidBrush(SubTextColor), new RectangleF(2 + TextTextPadding.Left, TextY + Font.Height * 2 + TextTextPadding.Top + 4 + (ImageOffsetY + ImageSize.Height + TextOffsetY) + SubTextOffSetY, Width - 2 - TextTextPadding.Right, (Height - SubTextOffSetY - SubTextFont.Height - ImageOffsetY - ImageSize.Height - TextOffsetY - TextY) - TextTextPadding.Bottom), SAF);

                if (BorderThickness != 0) g.DrawPath(pen, GP);

                if (AnimationMode == Enums.AnimationMode.Ripple && _animationManager.IsAnimating())
                {
                    g.SmoothingMode = SmoothingMode.AntiAlias;
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

                if (DesignMode == false && Focused)
                {
                    using (GraphicsPath gpf = HeCopUI_Framework.Helper.DrawHelper.SetRoundedCornerRectangle(new RectangleF(b + ShadowPadding.Left, b + ShadowPadding.Top,
                        (Width - ShadowPadding.Left) - ShadowPadding.Right,
                        (Height - ShadowPadding.Top) - ShadowPadding.Bottom), Radius, BorderThickness * 2 + 5))
                        g.DrawPath(new Pen(new SolidBrush(FocusBorderColor), 1) { Alignment = PenAlignment.Inset, DashStyle = DashStyle }, gpf);
                }
                
                TextureBrush tb = new TextureBrush(bitmap);
                e.Graphics.FillPath(tb, SGP);
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

        public Color FocusBorderColor { get; set; } = Color.White;

        private DashStyle dashStyle = DashStyle.Dot;
        public DashStyle DashStyle
        {
            get { return dashStyle; }
            set { dashStyle = value; Invalidate(); }
        }

        public bool ClipRegion { get; set; } = false;

        private Padding _itpadd = new Padding(0);
        public Padding TextTextPadding
        {
            get { return _itpadd; }
            set { _itpadd = value; Invalidate(); }
        }

        private Padding _tpadd = new Padding(0);
        public Padding TextPadding
        {
            get { return _tpadd; }
            set { _tpadd = value; Invalidate(); }
        }

        private ContentAlignment _subTextAlign = ContentAlignment.TopCenter;
        public ContentAlignment SubTextAlign
        {
            get { return _subTextAlign; }
            set { _subTextAlign = value; Invalidate(); }
        }

        private ContentAlignment _textAlign = ContentAlignment.TopCenter;
        public ContentAlignment TextAlign
        {
            get { return _textAlign; }
            set { _textAlign = value; Invalidate(); }
        }

        private int _subTextOffSetY = 0;
        public int SubTextOffSetY
        {
            get { return _subTextOffSetY; }
            set { _subTextOffSetY = value; Invalidate(); }
        }

        private int _textOffsetY = 10;
        public int TextY
        {
            get { return _textOffsetY; }
            set { _textOffsetY = value; Invalidate(); }
        }

        private int _textOffsetY_Property = 1;
        public int TextOffsetY
        {
            get { return _textOffsetY_Property; }
            set { _textOffsetY_Property = value; Invalidate(); }
        }

        private Font _subTextFont = new Font(DefaultFont, FontStyle.Regular);
        public Font SubTextFont
        {
            get { return _subTextFont; }
            set { _subTextFont = value; Invalidate(); }
        }

        private Color _subTextColor = Color.Silver;
        public Color SubTextColor
        {
            get { return _subTextColor; }
            set { _subTextColor = value; Invalidate(); }
        }

        private string _subText = "Enter Sub Text Here";
        public string SubText
        {
            get { return _subText; }
            set { _subText = value; Invalidate(); }
        }

        private StringTrimming _textTrim = StringTrimming.EllipsisCharacter;
        public StringTrimming TextTrim
        {
            get { return _textTrim; }
            set { _textTrim = value; Invalidate(); }
        }
    }
}
