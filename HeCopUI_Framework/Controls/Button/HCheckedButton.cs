using HeCopUI_Framework.Animations;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls.Button
{
    [ToolboxBitmap(typeof(System.Windows.Forms.Button), "Bitmaps.Button.bmp")]
    public partial class HCheckedButton : Control
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

        protected override void OnClick(EventArgs e)
        {

            base.OnClick(e);
        }

        public Color ButtonCheckedColor1 { get; set; } = Color.FromArgb(52, 83, 135);
        public Color ButtonCheckedColor2 { get; set; } = Color.FromArgb(12, 151, 175);

        private bool autosize = false;
        public bool IsAutoSize
        {
            get { return autosize; }
            set
            {
                autosize = value; Invalidate();
            }
        }
        #endregion

        private int _borderThickness { get; set; } = 0;
        private Color _borderColor { get; set; } = Color.DarkGray;
        private Color _normalColor1 { get; set; } = Global.PrimaryColors.BackNormalColor1;
        // Hover and press colors aligned with HButton naming
        public Color HoverColor1 { get; set; } = Global.PrimaryColors.BackHoverColor1;
        public Color PressColor1 { get; set; } = Global.PrimaryColors.BackPressColor1;
        public Color HoverColor2 { get; set; } = Global.PrimaryColors.BackHoverColor1;
        public Color PressColor2 { get; set; } = Global.PrimaryColors.BackPressColor1;
        private bool _isButtonPressed;
        private bool _isButtonHovered;
        private int _radius { get; set; } = 0;

        public Color TextHoverColor { get; set; } = Color.White;
        public Color TextDownColor { get; set; } = Color.White;
        private Color textNormalColor = Color.White;
        public Color TextNormalColor
        {
            get { return textNormalColor; }
            set
            {
                textNormalColor = value; Invalidate();
            }
        }

        public int BorderThickness
        {
            get { return _borderThickness; }
            set
            {
                _borderThickness = value; Invalidate();
            }
        }

        private DialogResult DR = DialogResult.None;
        public DialogResult DialogResult
        {
            get { return DR; }
            set
            {
                DR = value; Invalidate();
            }
        }

        public Color ButtonColor1
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
            // Normal background colors (primary/secondary) – same naming as HButton
            public Color NormalColor1
            {
                get => _normalColor1;
                set { _normalColor1 = value; Invalidate(); }
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
        public Color BorderDownColor { get; set; } = Global.PrimaryColors.BackNormalColor1;
        public Color BorderHoverColor { get; set; } = Global.PrimaryColors.BackNormalColor1;
        private LinearGradientMode _gradientMode = LinearGradientMode.Vertical;
        public LinearGradientMode GradientMode
        {
            get { return _gradientMode; }
            set
            {
                _gradientMode = value; Invalidate();
            }
        }

        /// <summary>
        /// Sets or gets a value that indicates whether the control resizes based on its contents.
        /// </summary>
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public override bool AutoSize
        {
            get { return autosize; }
            set
            {
                autosize = value;
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

        public int Radius
        {
            get { return _radius; }
            set
            {
                _radius = value; Invalidate();
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Padding Padding { get; set; } = new Padding(0);

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
                if (value.Bottom < 0) shadowPadding.Bottom = 0;
                SetAutoSize();
                Invalidate();
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

        private int shadowRadius = 5;
        public int ShadowRadius
        {
            get { return shadowRadius; }
            set
            {
                shadowRadius = value; Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (ClipRegion == true) if (DesignMode == false)
                {
                    Helper.GraphicsHelper.MakeTransparent(this, g);
                    if (ST == ShapeType.RoundRectangle)
                        Region = new Region(HeCopUI_Framework.Helper.DrawHelper.GetRoundPath(new RectangleF(0, 0, Width, Height), _radius - 2.5f));

                    if (ST == ShapeType.Circular)
                    {
                        GraphicsPath a = new GraphicsPath(); a.AddEllipse(0, 0, Width, Height);
                        Region = new Region(a);
                    }
                }
            if (ST == ShapeType.Circular)
                Helper.GraphicsHelper.SetHightGraphics(g);
            if (ST == ShapeType.RoundRectangle)
            {
                if (Radius != 0)
                {
                    Helper.GraphicsHelper.SetHightGraphics(g);
                }
                else
                {
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                }

            }
            g.TextRenderingHint = textRenderHint;
            RectangleF rec = new RectangleF(3f + shadowPadding.Left, 3f + shadowPadding.Top, Width - 4 - shadowPadding.Right - shadowPadding.Left, Height - 4 - shadowPadding.Bottom - shadowPadding.Top);
            // Use unified color property names and the rectangle "rec" for gradient bounds
            LinearGradientBrush GHB = new LinearGradientBrush(rec, Checked ? ButtonCheckedColor1 : _isButtonPressed ? PressColor1 : _isButtonHovered ? HoverColor1 : NormalColor1, Checked ? ButtonCheckedColor2 : _isButtonPressed ? PressColor2 : _isButtonHovered ? HoverColor2 : NormalColor2, _gradientMode);
            LinearGradientBrush AHB = new LinearGradientBrush(rec, Checked ? ButtonCheckedColor1 : _isButtonHovered ? HoverColor1 : NormalColor1, Checked ? ButtonCheckedColor2 : _isButtonHovered ? HoverColor2 : NormalColor2, _gradientMode);
            StringFormat SF = new StringFormat(); int b = 0;
            GraphicsPath Gp = HeCopUI_Framework.Helper.DrawHelper.GetRoundPath(new RectangleF(b + (shadowPadding.Left), b + (shadowPadding.Top), (Width - b - shadowPadding.Left) - (shadowPadding.Right), (Height - b - shadowPadding.Top) - (shadowPadding.Bottom)), _radius, _borderThickness);
            GraphicsPath SGP = HeCopUI_Framework.Helper.DrawHelper.GetRoundPath(new RectangleF(b, b, Width - b, Height - b), _radius);
            GraphicsPath FillPa = HeCopUI_Framework.Helper.DrawHelper.GetRoundPath(new RectangleF(b + (shadowPadding.Left), b + (shadowPadding.Top), (Width - b - shadowPadding.Left) - (shadowPadding.Right), (Height - b - shadowPadding.Top) - (shadowPadding.Bottom)), _radius);
            Helper.TextHelper.SetStringAlign(SF, CA);
            SF.Trimming = STA;
            RectangleF RF = new RectangleF(shadowPadding.Left + 2 + textPadding.Left, shadowPadding.Top + 2 + textPadding.Top, Width - 2 - textPadding.Right - textPadding.Left - shadowPadding.Left - shadowPadding.Right, Height - 2 - textPadding.Bottom - textPadding.Top - shadowPadding.Top - shadowPadding.Bottom);
            Pen pen = new Pen(_isButtonPressed ? BorderDownColor : _isButtonHovered ? BorderHoverColor : _borderColor, _borderThickness)
            {
                Alignment = PenAlignment.Inset
            };
            if (AnimationMode == Enums.AnimationMode.ColorTransition)
            {
                AHB = new LinearGradientBrush(rec, Checked ? ButtonCheckedColor1 : _isButtonPressed ? PressColor1 : _isButtonHovered ? HeCopUI_Framework.Helper.DrawHelper.BlendColor(NormalColor1, HoverColor1, _animationManager.GetProgress()) : HeCopUI_Framework.Helper.DrawHelper.BlendColor(NormalColor1, HoverColor1, _animationManager.GetProgress()), Checked ? ButtonCheckedColor2 : _isButtonPressed ? PressColor2 : _isButtonHovered ? HeCopUI_Framework.Helper.DrawHelper.BlendColor(NormalColor2, HoverColor2, _animationManager.GetProgress()) : HeCopUI_Framework.Helper.DrawHelper.BlendColor(NormalColor2, HoverColor2, _animationManager.GetProgress()), _gradientMode);
            }
            pen.Alignment = PenAlignment.Inset;
            Bitmap Shado = HeCopUI_Framework.Utils.DropShadow.Create(SGP, ShadowColor, shadowRadius);
            Shado.MakeTransparent();
            switch (ST)
            {
                case ShapeType.Circular:
                    SGP = new GraphicsPath();
                    SGP.AddEllipse(new RectangleF(2, 2, Width - 3, Height - 3));
                    if (shadowRadius != 0)
                        g.DrawImage(Shado, 0, 0, Width - 1, Height - 1);
                    FillPa = new GraphicsPath();
                    FillPa.AddEllipse(rec);

                    g.FillPath(AnimationMode == Enums.AnimationMode.ColorTransition ? AHB : GHB, FillPa);

                    g.DrawString(Text, Font, new SolidBrush(_isButtonPressed ? TextDownColor : _isButtonHovered ? TextHoverColor : TextNormalColor), RF, SF);
                    if (_borderThickness != 0)
                    {
                        g.DrawPath(pen, FillPa);
                    }
                    break;
                case ShapeType.RoundRectangle:
                    if (shadowRadius != 0)
                        g.DrawImage(Shado, 0, 0, Width - 1, Height - 1);

                    g.FillPath(AnimationMode != Enums.AnimationMode.None ? AHB : GHB, FillPa);

                    g.DrawString(Text, Font, new SolidBrush(_isButtonPressed ? TextDownColor : _isButtonHovered ? TextHoverColor : TextNormalColor), RF, SF);
                    if (_borderThickness != 0)
                    {
                        g.DrawPath(pen, Gp);
                    }
                    break;
            }


            if (image != null)
            {
                if (supportImageGif == true)
                {
                    try
                    {
                        AnimateImage();
                        //Get the next frame ready for rendering.
                        ImageAnimator.UpdateFrames();
                    }
                    catch { }
                }
                switch (textImageRelation)
                {
                    case ContentAlignment.MiddleLeft:
                        g.DrawImage(image, new RectangleF(imagePadding.Left + 8, Height / 2 - imgSize.Height / 2, imgSize.Width, imgSize.Height), new RectangleF(0, 0, Image.Width, Image.Height), GraphicsUnit.Pixel);
                        break;
                    case ContentAlignment.MiddleRight:
                        g.DrawImage(image, new RectangleF(Width - 8 - imagePadding.Right - imgSize.Width, Height / 2 - imgSize.Height / 2, imgSize.Width, imgSize.Height), new RectangleF(0, 0, Image.Width, Image.Height), GraphicsUnit.Pixel);
                        break;
                    case ContentAlignment.MiddleCenter:
                        g.DrawImage(image, new RectangleF(Width / 2 - imgSize.Width / 2, Height / 2 - imgSize.Height / 2, imgSize.Width, imgSize.Height), new RectangleF(0, 0, Image.Width, Image.Height), GraphicsUnit.Pixel);
                        break;
                    case ContentAlignment.TopLeft:
                        g.DrawImage(image, new RectangleF(imagePadding.Left + Radius / 2 + 8, imagePadding.Top + 8, imgSize.Width, imgSize.Height), new RectangleF(0, 0, Image.Width, Image.Height), GraphicsUnit.Pixel);
                        break;
                    case ContentAlignment.TopCenter:
                        g.DrawImage(image, new RectangleF(Width / 2 - imgSize.Width / 2, imagePadding.Top + 8, imgSize.Width, imgSize.Height), new RectangleF(0, 0, Image.Width, Image.Height), GraphicsUnit.Pixel);
                        break;
                    case ContentAlignment.TopRight:
                        g.DrawImage(image, new RectangleF(Width - Radius / 2 - imagePadding.Right - imgSize.Width - 8, imagePadding.Top + 8, imgSize.Width, imgSize.Height), new RectangleF(0, 0, Image.Width, Image.Height), GraphicsUnit.Pixel);
                        break;
                    case ContentAlignment.BottomLeft:
                        g.DrawImage(image, new RectangleF(imagePadding.Left + Radius / 2 + 8, Height - 8 - imagePadding.Bottom - imgSize.Height, imgSize.Width, imgSize.Height), new RectangleF(0, 0, Image.Width, Image.Height), GraphicsUnit.Pixel);
                        break;
                    case ContentAlignment.BottomCenter:
                        g.DrawImage(image, new RectangleF(Width / 2 - imgSize.Width / 2, Height - imagePadding.Bottom - 8 - imgSize.Height, imgSize.Width, imgSize.Height), new RectangleF(0, 0, Image.Width, Image.Height), GraphicsUnit.Pixel);
                        break;
                    case ContentAlignment.BottomRight:
                        g.DrawImage(image, new RectangleF(Width - imagePadding.Right - imgSize.Width - 8 - Radius / 2, Height - imagePadding.Bottom - 8 - imgSize.Height, imgSize.Width, imgSize.Height), new RectangleF(0, 0, Image.Width, Image.Height), GraphicsUnit.Pixel);
                        break;
                }
            }
            if (_animationManager.IsAnimating() && AnimationMode == Enums.AnimationMode.Ripple)
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
            //g.FillPath(new TextureBrush(bitmap), FillPa);
            //Brush brr = new TextureBrush(bitmap);
            //e.Graphics.FillPath(brr, Gp);
            //g.Dispose();
            if (DesignMode == false)
                if (foc)
                {
                    GraphicsPath gpf = HeCopUI_Framework.Helper.DrawHelper.GetRoundPath(new RectangleF(b + (shadowPadding.Left), b + (shadowPadding.Top),
                       (Width - shadowPadding.Left) - (shadowPadding.Right),
                       (Height - shadowPadding.Top) - (shadowPadding.Bottom)), Radius, BorderThickness * 2 + 5);
                    g.DrawPath(new Pen(new SolidBrush(fbc), 1) { Alignment = PenAlignment.Inset, DashStyle = dashStyle }, gpf);
                }
            GHB.Dispose();
            AHB.Dispose();
            Gp.Dispose();
            SGP.Dispose();
            FillPa.Dispose();
            Shado.Dispose();
            pen.Dispose();
            base.OnPaint(e);

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

        private Padding textPadding = new Padding(0, 0, 0, 0);
        public Padding TextPadding
        {
            get { return textPadding; }
            set
            {
                textPadding = value;
                if (value.Left < 0) textPadding.Left = 0;
                if (value.Top < 0) textPadding.Top = 0;
                if (value.Right < 0) textPadding.Right = 0;
                if (value.Bottom < 0) textPadding.Bottom = 0;
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
                int Pad = Math.Abs(GetMaxPad(textPadding.Left + shadowPadding.Left,
                    textPadding.Top + shadowPadding.Top,
                    textPadding.Right + shadowPadding.Right,
                    textPadding.Bottom + shadowPadding.Bottom));
                Size n = TextRenderer.MeasureText(Text, Font);
                Regex regex = new Regex("\n");
                int i = regex.Matches(Text).Count;
                int a = 0;
                if (i == 0) a = n.Height;
                else a += n.Height;
                int imax = 0; int imay = 0;
                if (image != null)
                {
                    imax = imgSize.Width; imay = imgSize.Height;
                }
                Size = new Size(imax + n.Width + 8 + Pad, a + 8 + Pad + imay);
            }
        }

        bool currentlyAnimating = false;
        private void OnFrameChanged(object o, EventArgs e)
        {

            Invalidate();
        }
        private void AnimateImage()
        {

            if (!currentlyAnimating)
            {

                //Begin the animation only once.
                ImageAnimator.Animate(image, new EventHandler(OnFrameChanged));
                currentlyAnimating = true;
            }
        }

        private bool supportImageGif = false;
        public bool SupportImageGif
        {
            get { return supportImageGif; }
            set
            {
                supportImageGif = value; Invalidate();
            }
        }

        private Padding imagePadding = new Padding(0, 0, 0, 0);
        public Padding ImagePadding
        {
            get { return imagePadding; }
            set
            {
                imagePadding = value; Invalidate();
            }
        }

        private Size imgSize = new Size(20, 20);
        public Size ImageSize
        {
            get { return imgSize; }
            set
            {
                imgSize = value; Invalidate();
            }
        }

        private Image image = null;
        public Image Image
        {
            get { return image; }
            set
            {
                image = value; Invalidate();
            }
        }

        private ContentAlignment textImageRelation = ContentAlignment.MiddleLeft;
        public ContentAlignment ImageAlign
        {
            get { return textImageRelation; }
            set
            {
                textImageRelation = value; Invalidate();
            }
        }


        private Color buttonColor2 = Global.PrimaryColors.BackNormalColor1;
        public Color ButtonColor2
        {
            get
            {
                return buttonColor2;
            }
            set
            {
                buttonColor2 = value;

                Invalidate();
            }
        }
            private Color _normalColor2 = Global.PrimaryColors.BackNormalColor1;
            public Color NormalColor2
            {
                get => _normalColor2;
                set { _normalColor2 = value; Invalidate(); }
            }

        private bool _checked = false;
        ///<summary>
        ///  Gets or sets a value indicating whether the control is checked.
        ///</summary>
        public bool Checked
        {
            get { return _checked; }
            set
            {
                _checked = value;
                UpdateState();
                CheckedChanged?.Invoke(this, null);
                Invalidate();
            }
        }

        public event EventHandler CheckedChanged;

        public bool AlwayCheckedInstance { get; set; } = false;

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (AlwayCheckedInstance == true)
                    Checked = true;
                else
                    Checked = !Checked;
            }
            base.OnMouseClick(e);
        }

        private void UpdateState()
        {
            if (!IsHandleCreated || !Checked)
                return;
            foreach (Control c in Parent.Controls)
            {
                if (!ReferenceEquals(c, this) && c is HCheckedButton)
                {
                    ((HCheckedButton)c).Checked = false;
                }
            }
        }


        public HCheckedButton()
        {
            SetStyle(GetAppResources.SetControlStyles(), true);
            DoubleBuffered = true;
            _animationManager = new AnimationManager(false)
            {
                Increment = 0.03,
                AnimationType = Animations.AnimationType.EaseOut
            };
            BackColor = Color.Transparent;
            ForeColor = Color.White;
            BackColor = Color.Transparent;
            Font = new Font("Tahoma", 11f);
            if (IsAutoSize == true)
            {
                SizeF n = TextRenderer.MeasureText(Text, Font);
                Size = new Size((int)n.Width + Padding.All, (int)n.Height + Padding.All);
            }

            //timer1.Stop();time2.Stop();
            MouseEnter += (sender, e) =>
            {
                _isButtonHovered = true;
                //timer1.Stop();
                //if (Animated==true)
                //{
                //  if (!DesignMode) timer1.Start(); else timer1.Stop();
                //}
                switch (AnimationMode)
                {

                    case Enums.AnimationMode.ColorTransition:
                        _animationManager.StartNewAnimation(AnimationDirection.In);
                        break;
                }

                Invalidate();
            };

            _animationManager.OnAnimationProgress += sender => Invalidate();
            MouseLeave += (sender, e) =>
            {
                _isButtonHovered = false;
                switch (AnimationMode)
                {

                    case Enums.AnimationMode.ColorTransition:
                        _animationManager.StartNewAnimation(AnimationDirection.Out);
                        break;
                }
                Invalidate();
            };
            MouseUp += (sender, e) =>
            {
                _isButtonPressed = false;
                Invalidate();
            };

        }

        bool foc = false;

        protected override void OnEnter(EventArgs e)
        {
            foc = true;
            Invalidate();
            base.OnEnter(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            foc = false; Invalidate();
            base.OnLeave(e);
        }


        public Enums.AnimationMode AnimationMode { get; set; } = Enums.AnimationMode.None;


        //PointF[] GetHovPoi=null;
        private Animations.AnimationManager _animationManager;
        protected override void OnMouseDown(MouseEventArgs e)
        {
            _isButtonPressed = true; Invalidate();
            if (!DesignMode)
            {
                if (AnimationMode == Enums.AnimationMode.Ripple)
                {
                    _animationManager.StartNewAnimation(Animations.AnimationDirection.In, e.Location);
                }
            }
            base.OnMouseDown(e);
        }


        private int interval = 200;
        /// <summary>
        /// Set speed animation with value type milisecond to show animate
        /// </summary>
        public int Interval
        {
            get { return interval; }
            set
            {
                interval = value; Invalidate();
            }
        }


        public Color RippleColor { get; set; } = Color.Black;


        private System.Drawing.Text.TextRenderingHint textRenderHint = Helper.TextHelper.SetTextRender();
        /// <summary>
        /// Gets or sets TextRenderingHint for text button.
        /// </summary>
        public System.Drawing.Text.TextRenderingHint TextRenderHint
        {
            get { return textRenderHint; }
            set
            {
                textRenderHint = value; Invalidate();
            }
        }




        private StringTrimming STA = StringTrimming.EllipsisCharacter;
        public StringTrimming TextTrim
        {
            get { return STA; }
            set
            {
                STA = value; Invalidate();
            }
        }

        private ContentAlignment CA = ContentAlignment.MiddleCenter;
        public ContentAlignment ButtonTextAlign
        {
            get { return CA; }
            set
            {
                CA = value; Invalidate();
            }
        }

        private ShapeType ST = ShapeType.RoundRectangle;

        public ShapeType ShapeButtonType
        {
            get { return ST; }
            set
            {
                ST = value; Invalidate();
            }
        }

        public enum ShapeType
        {
            RoundRectangle, Circular
        }
    }
}
