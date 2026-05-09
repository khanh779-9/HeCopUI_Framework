using HeCopUI_Framework.Animations;
using HeCopUI_Framework.Enums;
using HeCopUI_Framework.Structs;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Brush = System.Drawing.Brush;
using Color = System.Drawing.Color;
using DashStyle = System.Drawing.Drawing2D.DashStyle;
using LinearGradientBrush = System.Drawing.Drawing2D.LinearGradientBrush;
using Pen = System.Drawing.Pen;

namespace HeCopUI_Framework.Controls.Button
{
    [ToolboxBitmap(typeof(System.Windows.Forms.Button))]
    public partial class HButton : Control
    {
        #region Thành phần tối thiết
        protected override void OnTextChanged(EventArgs e)
        {
            SetAutoSize();
            Invalidate();
            base.OnTextChanged(e);
        }

        private int GetMaxPad(int num1, int num2, int num3, int num4)
        {
            int[] re = { num1, num2, num3, num4 };

            return re.Max();

        }

        protected override void OnSizeChanged(EventArgs e)
        {
            SetAutoSize();
            base.OnSizeChanged(e);
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


        #endregion

        private int _borderThickness = 0;
        private Color _borderColor = Color.DarkGray;
        private Color _normalColor1 = Global.PrimaryColors.BackNormalColor1;
        //Global.PrimaryColors.BackNormalColor1

        private Color _hoverColor1 = Global.PrimaryColors.BackHoverColor1;
        /// <summary>
        /// Gets or sets the color of the button when the mouse is over the button.
        /// </summary>
        [Description("Gets or sets the color of the button when the mouse is over the button.")]
        public Color HoverColor1
        {
            get { return _hoverColor1; }
            set { _hoverColor1 = value; Invalidate(); }
        }

        private Color _hoverColor2 = Global.PrimaryColors.BackHoverColor2;
        /// <summary>
        /// Gets or sets the second color of the button when the mouse is over the button.
        /// </summary>
        [Description("Gets or sets the second color of the button when the mouse is over the button.")]
        public Color HoverColor2
        {
            get { return _hoverColor2; }
            set { _hoverColor2 = value; Invalidate(); }
        }

        private Color _pressColor1 = Global.PrimaryColors.BackPressColor1;
        /// <summary>
        /// Gets or sets the color of the button when the mouse is pressed on the button.
        /// </summary>
        [Description("Gets or sets the color of the button when the mouse is pressed on the button.")]
        public Color PressColor1
        {
            get { return _pressColor1; }
            set { _pressColor1 = value; Invalidate(); }
        }

        private Color _pressColor2 = Global.PrimaryColors.BackPressColor2;
        /// <summary>
        /// Gets or sets the second color of the button when the mouse is pressed on the button.
        /// </summary>
        [Description("Gets or sets the second color of the button when the mouse is pressed on the button.")]
        public Color PressColor2
        {
            get { return _pressColor2; }
            set { _pressColor2 = value; Invalidate(); }
        }
        private bool _isButtonPressed = false;
        private bool _isButtonHovered = false;

        /// <summary>
        /// Gets or sets the color of the text when the mouse is over the button.
        /// </summary>
        [Description("Gets or sets the color of the text when the mouse is over the button.")]
        public Color TextHoverColor { get; set; } = Color.White;

        /// <summary>
        /// Gets or sets the color of the text when the mouse is pressed on the button.
        /// </summary>
        [Description("Gets or sets the color of the text when the mouse is pressed on the button.")]
        public Color TextPressColor { get; set; } = Color.White;
        private Color _textNormalColor = Color.WhiteSmoke;

        /// <summary>
        /// Gets or sets the color of the text when normal state.
        /// </summary>
        [Description("Gets or sets the color of the text when normal state.")]
        public Color TextNormalColor
        {
            get { return _textNormalColor; }
            set
            {
                _textNormalColor = value; Invalidate();
            }
        }

        private Color _normalColor2 = Global.PrimaryColors.BackNormalColor2;
        /// <summary>
        /// Gets or sets the second color of the button when normal state.
        /// </summary>
        [Description("Gets or sets the second color of the button when normal state.")]
        public Color NormalColor2
        {
            get
            {
                return _normalColor2;
            }
            set
            {
                _normalColor2 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the border thickness of the button.
        /// </summary>
        [Description("Gets or sets the border thickness of the button.")]
        public int BorderThickness
        {
            get { return _borderThickness; }
            set
            {
                _borderThickness = value; Invalidate();
            }
        }

        private DialogResult _dialogResult = DialogResult.None;

        /// <summary>
        /// Gets or sets the dialog result of the button.
        /// </summary>
        [Description("Gets or sets the dialog result of the button.")]
        public DialogResult DialogResult
        {
            get { return _dialogResult; }
            set
            {
                _dialogResult = value; Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the button when normal state.
        /// </summary>
        [Description("Gets or sets the color of the button when normal state.")]
        public Color NormalColor1
        {
            get
            {
                return _normalColor1;
            }
            set
            {
                _normalColor1 = value;
                Invalidate();
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Color ForeColor { get; set; }

        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value; Invalidate();
            }
        }
        public Color BorderPressColor { get; set; } = Global.PrimaryColors.BackNormalColor1;
        public Color BorderHoverColor { get; set; } = Global.PrimaryColors.BackNormalColor1;
        private LinearGradientMode _gradientMode = LinearGradientMode.Vertical;
        public LinearGradientMode GradientMode
        {
            get { return _gradientMode; }
            set
            {
                _gradientMode = value;
                Invalidate();
            }
        }


        private bool _autoSize = false;
        /// <summary>
        /// Sets or gets a value that indicates whether the control resizes based on its contents.
        /// </summary>
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public override bool AutoSize
        {
            get { return _autoSize; }
            set
            {
                _autoSize = value;
                SetAutoSize();
                Invalidate();
            }
        }


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


        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Padding Padding { get; set; } = new Padding(0);

        private Padding _shadowPadding = new Padding(0, 0, 0, 0);
        /// <summary>
        /// Gets or sets the padding of the shadow.
        /// </summary>
        [Description("Gets or sets the padding of the shadow.")]
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
                SetAutoSize();
                Invalidate();
            }
        }

        private Color _shadowColor = Color.FromArgb(60, 0, 0, 0);
        /// <summary>
        /// Gets or sets the color of the shadow.
        /// </summary>
        [Description("Gets or sets the color of the shadow.")]
        public Color ShadowColor
        {
            get { return _shadowColor; }
            set
            {
                _shadowColor = value; Invalidate();
            }
        }

        private int _shadowRadius = 5;
        public int ShadowRadius
        {
            get { return _shadowRadius; }
            set
            {
                _shadowRadius = value; Invalidate();
            }
        }

        GraphicsPath CircularGraphicsPath(RectangleF rect)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddEllipse(rect);
            return graphicsPath;
        }

        private CornerRadius _cornerRadius = new Structs.CornerRadius(5);

        /// <summary>
        /// Gets or sets radius of HButton.
        /// </summary>
        [Description("Gets or sets radius of HButton.")]
        public CornerRadius Radius
        {
            get { return _cornerRadius; }
            set
            {
                _cornerRadius = value; Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            float b = 0f;
            base.OnPaint(e);
            RectangleF RF = new RectangleF(_shadowPadding.Left + 2 + _textPadding.Left, _shadowPadding.Top + 2 + _textPadding.Top, Width - 2 - _textPadding.Right - _textPadding.Left - _shadowPadding.Left - _shadowPadding.Right, Height - 2 - _textPadding.Bottom - _textPadding.Top - _shadowPadding.Top - _shadowPadding.Bottom);
            Helper.GraphicsHelper.MakeTransparent(this, e.Graphics);
            using (GraphicsPath SGP = (_shapeType == ShapeType.RoundedRectangle) ? HeCopUI_Framework.Helper.DrawHelper.SetRoundedCornerRectangle(new RectangleF(b, b, Width - b, Height - b), new CornerRadius(_cornerRadius.TopLeft, _cornerRadius.TopRight, _cornerRadius.BottomLeft, _cornerRadius.BottomRight, 0.5f)) : CircularGraphicsPath(new RectangleF(b, b, Width - b, Height - b)))
            using (GraphicsPath GP = HeCopUI_Framework.Helper.DrawHelper.SetRoundedCornerRectangle(new RectangleF(b + (_shadowPadding.Left), b + (_shadowPadding.Top), (Width - _shadowPadding.Left) - (_shadowPadding.Right), (Height - _shadowPadding.Top) - (_shadowPadding.Bottom)), Radius, BorderThickness))

            using (LinearGradientBrush AHB =
                (AnimationMode == AnimationMode.ColorTransition) ? new LinearGradientBrush(ClientRectangle, _isButtonPressed ? PressColor1 : _isButtonHovered ? HeCopUI_Framework.Helper.DrawHelper.BlendColor(NormalColor1, HoverColor1, 255 * _animationManager.GetProgress()) : HeCopUI_Framework.Helper.DrawHelper.BlendColor(NormalColor1, HoverColor1, 255 * _animationManager.GetProgress()),
                 _isButtonPressed ? PressColor2 : _isButtonHovered ? HeCopUI_Framework.Helper.DrawHelper.BlendColor(NormalColor2, HoverColor2, 255 * _animationManager.GetProgress()) : HeCopUI_Framework.Helper.DrawHelper.BlendColor(NormalColor2, HoverColor2, 255 * _animationManager.GetProgress()), _gradientMode) :
                (AnimationMode == AnimationMode.Ripple) ? new LinearGradientBrush(ClientRectangle, _isButtonHovered ? HoverColor1 : NormalColor1, _isButtonHovered ? HoverColor2 : NormalColor2, _gradientMode) :
                 new LinearGradientBrush(ClientRectangle, _isButtonPressed ? PressColor1 : _isButtonHovered ? HoverColor1 : NormalColor1, _isButtonPressed ? PressColor2 : _isButtonHovered ? HoverColor2 : NormalColor2, _gradientMode))

            using (SolidBrush sbText = new SolidBrush(_isButtonPressed ? TextPressColor : _isButtonHovered ? TextHoverColor : TextNormalColor))
            using (StringFormat SF = new StringFormat())
            using (Bitmap bitmap = HeCopUI_Framework.Utils.DropShadow.Create(SGP, ShadowColor, _shadowRadius))
            {
                bitmap.MakeTransparent();
                Graphics g = Graphics.FromImage(bitmap);
                g.TextRenderingHint = _textRenderHint;
                if (_shapeType == ShapeType.Circular)
                {
                    Helper.GraphicsHelper.SetHightGraphics(g); Helper.GraphicsHelper.SetHightGraphics(e.Graphics);
                }
                if (_shapeType == ShapeType.RoundedRectangle)
                {
                    if (Radius.All != 0)
                    {
                        Helper.GraphicsHelper.SetHightGraphics(g);
                        Helper.GraphicsHelper.SetHightGraphics(e.Graphics);
                    }
                    else
                    {
                        g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    }
                }
                if (Radius.All == 0) g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                Helper.TextHelper.SetStringAlign(SF, _buttonTextAlignment);
                SF.Trimming = _stringTrimming;
                if (ClipRegion == true && DesignMode == false)
                {
                    if (_shapeType == ShapeType.RoundedRectangle) Region = new Region(HeCopUI_Framework.Helper.DrawHelper.SetRoundedCornerRectangle(new RectangleF(0, 0, Width, Height), new CornerRadius(_cornerRadius.TopLeft, _cornerRadius.TopRight, _cornerRadius.BottomLeft, _cornerRadius.BottomRight, 2.5f)));
                    if (_shapeType == ShapeType.Circular)
                    {
                        GraphicsPath a = new GraphicsPath(); a.AddEllipse(0, 0, Width, Height);
                        Region = new Region(a);
                    }
                }

                g.FillPath(AHB, GP);

                if (_image != null)
                {
                    if (_supportImageGif == true)
                    {
                        try
                        {
                            AnimateImage();
                            //Get the next frame ready for rendering.
                            ImageAnimator.UpdateFrames();
                        }
                        catch { }
                    }

                    RectangleF drawRectangle = RectangleF.Empty;

                    switch (_imageAlignment)
                    {
                        case ContentAlignment.MiddleLeft:
                            drawRectangle = new RectangleF(_imagePadding.Left + _cornerRadius.TopLeft + 8, Height / 2 - _imageSize.Height / 2, _imageSize.Width, _imageSize.Height);
                            break;
                        case ContentAlignment.MiddleRight:
                            drawRectangle = new RectangleF(Width - 8 - _imagePadding.Right - _imageSize.Width - _cornerRadius.TopRight, Height / 2 - _imageSize.Height / 2, _imageSize.Width, _imageSize.Height);
                            break;
                        case ContentAlignment.MiddleCenter:
                            drawRectangle = new RectangleF(Width / 2 - _imageSize.Width / 2, Height / 2 - _imageSize.Height / 2, _imageSize.Width, _imageSize.Height);
                            break;
                        case ContentAlignment.TopLeft:
                            drawRectangle = new RectangleF(_imagePadding.Left + _cornerRadius.TopLeft + 8, _imagePadding.Top + 8, _imageSize.Width, _imageSize.Height);
                            break;
                        case ContentAlignment.TopCenter:
                            drawRectangle = new RectangleF(Width / 2 - _imageSize.Width / 2, _imagePadding.Top + 8, _imageSize.Width, _imageSize.Height);
                            break;
                        case ContentAlignment.TopRight:
                            drawRectangle = new RectangleF(Width - _cornerRadius.TopRight - _imagePadding.Right - _imageSize.Width - 8, _imagePadding.Top + 8, _imageSize.Width, _imageSize.Height);
                            break;
                        case ContentAlignment.BottomLeft:
                            drawRectangle = new RectangleF(_imagePadding.Left + _cornerRadius.BottomLeft + 8, Height - 8 - _imagePadding.Bottom - _imageSize.Height, _imageSize.Width, _imageSize.Height);
                            break;
                        case ContentAlignment.BottomCenter:
                            drawRectangle = new RectangleF(Width / 2 - _imageSize.Width / 2, Height - _imagePadding.Bottom - 8 - _imageSize.Height, _imageSize.Width, _imageSize.Height);
                            break;
                        case ContentAlignment.BottomRight:
                            drawRectangle = new RectangleF(Width - _imagePadding.Right - _imageSize.Width - 8 - _cornerRadius.BottomRight, Height - _imagePadding.Bottom - 8 - _imageSize.Height, _imageSize.Width, _imageSize.Height);
                            break;
                        default:
                            drawRectangle = RectangleF.Empty;
                            break;
                    }

                    // Chỉ vẽ hình ảnh nếu hình chữ nhật vẽ đã được xác định
                    if (drawRectangle != RectangleF.Empty)
                        g.DrawImage(_image, drawRectangle, new RectangleF(0, 0, Image.Width, Image.Height), GraphicsUnit.Pixel);
                }

                g.DrawString(Text, Font, sbText, RF, SF);
                Pen pen = new Pen(new SolidBrush(_isButtonPressed ? BorderPressColor : _isButtonHovered ? BorderHoverColor : BorderColor), _borderThickness)
                {
                    Alignment = PenAlignment.Inset
                };
                if (Radius.All == 0) g.SmoothingMode = SmoothingMode.Default;
                if (_borderThickness != 0) g.DrawPath(pen, GP);
                g.SmoothingMode = SmoothingMode.HighQuality;
                if (AnimationMode == AnimationMode.Ripple && _animationManager.IsAnimating())
                    for (var i = 0; i < _animationManager.GetAnimationCount(); i++)
                    {
                        var animationValue = _animationManager.GetProgress(i);
                        var animationSource = _animationManager.GetSource(i);
                        using (Brush rippleBrush = new SolidBrush(Color.FromArgb((int)(101 - (animationValue * 100)), RippleColor)))
                        {
                            var rippleSize = (int)(animationValue * (Math.Max(Width, Height)) * 3);
                            g.FillEllipse(rippleBrush, new RectangleF(animationSource.X - rippleSize / 2, animationSource.Y - rippleSize / 2, rippleSize, rippleSize));
                        }
                    }

                //Draw focus border
                if (DesignMode == false && Focused)
                {
                    g.SmoothingMode = SmoothingMode.None;
                    using (GraphicsPath gpf = HeCopUI_Framework.Helper.DrawHelper.SetRoundedCornerRectangle(new RectangleF(b + (_shadowPadding.Left), b + (_shadowPadding.Top), (Width - _shadowPadding.Left) - (_shadowPadding.Right), (Height - _shadowPadding.Top) - (_shadowPadding.Bottom)), _cornerRadius, BorderThickness * 2 + 3))
                    using (var p = new Pen(new SolidBrush(_focusBorderColor), 1) { Alignment = PenAlignment.Inset, DashStyle = _dashStyle })
                        g.DrawPath(p, gpf);

                }
                Brush brr = new TextureBrush(bitmap);
                e.Graphics.FillPath(brr, SGP);
            }

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

        private Color _focusBorderColor = Color.White;
        public Color FocusBorderColor
        {
            get { return _focusBorderColor; }
            set { _focusBorderColor = value; Invalidate(); }
        }

        private DashStyle _dashStyle = DashStyle.Dot;
        public DashStyle DashStyle
        {
            get
            {
                return _dashStyle;
            }
            set
            {
                _dashStyle = value; Invalidate();
            }
        }

        public bool ClipRegion { get; set; } = false;

        private Padding _textPadding = new Padding(0, 0, 0, 0);
        /// <summary>
        /// Gets or sets the text padding of the button.
        /// </summary>
        [Description("Gets or sets the text padding of the button.")]
        public Padding TextPadding
        {
            get { return _textPadding; }
            set
            {
                _textPadding = value;
                if (value.Left < 0) _textPadding.Left = 0;
                if (value.Top < 0) _textPadding.Top = 0;
                if (value.Right < 0) _textPadding.Right = 0;
                if (value.Bottom < 0) _textPadding.Bottom = 0;
                SetAutoSize();
                Invalidate();
            }
        }

        protected override void OnInvalidated(InvalidateEventArgs e)
        {
            SetAutoSize();
            base.OnInvalidated(e);
        }

        void SetAutoSize()
        {
            if (AutoSize == true)
            {
                int Pad = Math.Abs(GetMaxPad(_textPadding.Left + _shadowPadding.Left, _textPadding.Top + _shadowPadding.Top, _textPadding.Right + _shadowPadding.Right, _textPadding.Bottom + _shadowPadding.Bottom));
                Size n = TextRenderer.MeasureText(Text, Font);
                Regex regex = new Regex("\n");
                int i = regex.Matches(Text).Count;
                int a = 0;
                if (i == 0) a = n.Height;
                else a += n.Height;
                int imax = 0; int imay = 0;
                if (_image != null)
                {
                    imax = _imageSize.Width; imay = _imageSize.Height;
                }
                Size = new Size(imax + n.Width + 8 + Pad, a + 8 + Pad + imay);
            }
        }

        private bool _currentlyAnimating = false;
        private void OnFrameChanged(object o, EventArgs e)
        {
            Invalidate();
        }

        private void AnimateImage()
        {
            if (!_currentlyAnimating)
            {
                ImageAnimator.Animate(_image, new EventHandler(OnFrameChanged));
                _currentlyAnimating = true;
            }
        }

        private bool _supportImageGif = false;
        public bool SupportImageGif
        {
            get { return _supportImageGif; }
            set
            {
                _supportImageGif = value; Invalidate();
            }
        }

        private Padding _imagePadding = new Padding(0, 0, 0, 0);
        public Padding ImagePadding
        {
            get { return _imagePadding; }
            set
            {
                _imagePadding = value; Invalidate();
            }
        }

        private Size _imageSize = new Size(20, 20);
        public Size ImageSize
        {
            get { return _imageSize; }
            set
            {
                _imageSize = value; Invalidate();
            }
        }

        private Image _image = null;
        public Image Image
        {
            get { return _image; }
            set
            {
                _image = value; Invalidate();
            }
        }

        private ContentAlignment _imageAlignment = ContentAlignment.MiddleLeft;
        public ContentAlignment ImageAlign
        {
            get { return _imageAlignment; }
            set
            {
                _imageAlignment = value; Invalidate();
            }
        }


        private AnimationMode _animationMode = AnimationMode.None;
        public AnimationMode AnimationMode
        {
            get { return _animationMode; }
            set
            {
                _animationMode = value;
                switch (_animationMode)
                {
                    case AnimationMode.None:
                        _animationManager.Singular = true;
                        _animationManager.Increment = 0.03;
                        break;
                    case AnimationMode.Ripple:
                        _animationManager.Singular = false;
                        _animationManager.Increment = 0.03;
                        break;
                    case AnimationMode.ColorTransition:
                        _animationManager.Singular = true;
                        _animationManager.Increment = 0.05;
                        break;
                }
                Invalidate();
            }
        }

        public HButton()
        {
            SetStyle(GetAppResources.SetControlStyles(), true);
            _animationManager = new AnimationManager(true)
            {
                Increment = 0.03,
                AnimationType = Animations.AnimationType.EaseOut
            };
            //_animationManager.SetProgress(0);
            object[] b = new object[] { new Point(0, 0) };
            _animationManager.StartNewAnimation(AnimationDirection.Out);
            _animationManager.SetData(b);


            ForeColor = Color.White;
            if (AutoSize == true)
            {
                SizeF n = TextRenderer.MeasureText(Text, Font);
                Size = new Size((int)n.Width + Padding.All, (int)n.Height + Padding.All);
            }

            _animationManager.OnAnimationProgress += _animationManager_OnAnimationProgress;
            _animationManager.OnAnimationFinished += _animationManager_OnAnimationFinished;


        }

        private void _animationManager_OnAnimationProgress(object sender)
        {
            Invalidate();
        }

        private void _animationManager_OnAnimationFinished(object sender)
        {
            _animationManager.Dispose();
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
            if (_animationMode == AnimationMode.ColorTransition)
                _animationManager.StartNewAnimation(AnimationDirection.In);

            Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            _isButtonHovered = false;
            if (AnimationMode == AnimationMode.ColorTransition)
                _animationManager.StartNewAnimation(AnimationDirection.Out);
            Invalidate();
            base.OnMouseLeave(e);
        }

        private Animations.AnimationManager _animationManager;
        protected override void OnMouseDown(MouseEventArgs e)
        {
            _isButtonPressed = true;
            if (AnimationMode == AnimationMode.Ripple)
                _animationManager.StartNewAnimation(Animations.AnimationDirection.In, e.Location);
            Invalidate();
            base.OnMouseDown(e);
        }


        public Color RippleColor { get; set; } = Color.Black;
        protected override void OnMouseClick(MouseEventArgs e)
        {
            var a = FindForm();
            if (a != null) a.DialogResult = _dialogResult;
            base.OnMouseClick(e);
        }

        private System.Drawing.Text.TextRenderingHint _textRenderHint = Helper.TextHelper.SetTextRender();
        /// <summary>
        /// Gets or sets TextRenderingHint for text button.
        /// </summary>
        public System.Drawing.Text.TextRenderingHint TextRenderHint
        {
            get { return _textRenderHint; }
            set
            {
                _textRenderHint = value; Invalidate();
            }
        }


        private StringTrimming _stringTrimming = StringTrimming.EllipsisCharacter;
        public StringTrimming TextTrim
        {
            get { return _stringTrimming; }
            set
            {
                _stringTrimming = value; Invalidate();
            }
        }

        private ContentAlignment _buttonTextAlignment = ContentAlignment.MiddleCenter;
        public ContentAlignment ButtonTextAlign
        {
            get { return _buttonTextAlignment; }
            set
            {
                _buttonTextAlignment = value; Invalidate();
            }
        }

        private ShapeType _shapeType = ShapeType.RoundedRectangle;

        public ShapeType ShapeButtonType
        {
            get { return _shapeType; }
            set
            {
                _shapeType = value; Invalidate();
            }
        }


    }
}
