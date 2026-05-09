using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace HeCopUI_Framework.Controls.Progress
{

    [ToolboxBitmap(typeof(HCircularProgressBar), "Bitmaps.CircleProgress.bmp")]
    public partial class HCircularProgressBar : Control
    {
#pragma warning disable CS0649 // Field 'HCircularProgressBar._animatedStartAngle' is never assigned to, and will always have its default value
        private int? _animatedStartAngle;
#pragma warning restore CS0649 // Field 'HCircularProgressBar._animatedStartAngle' is never assigned to, and will always have its default value
        private float? _animatedValue;
        private Brush _backBrush;

        public delegate void ProgressColorChangedEventHandler(object sender, EventArgs e);
        public event ProgressColorChangedEventHandler SliderValueChanged;




        /// <summary>
        ///     Initializes a new instance of the <see cref="HCircularProgressBar1" /> class.
        /// </summary>
        public HCircularProgressBar()
        {
            SetStyle(GetAppResources.SetControlStyles(), true);

            DoubleBuffered = true;
            Size = new Size(120, 120);
            Init();

        }

        protected override void OnInvalidated(InvalidateEventArgs e)
        {
            if (animationMode != AnimationType.None)
            {
                timeAnimator.Start();
            }
            else
            {
                timeAnimator.Stop();
            }
            base.OnInvalidated(e);
        }

        void Init()
        {

            timeAnimator = new Timer();
            //timeAnimator.Interval = interval;

            timeAnimator.Tick += TimeAnimator_Tick;

        }


        protected override void OnCreateControl()
        {
            // Init();

            Invalidate();
            base.OnCreateControl();
        }

        private void TimeAnimator_Tick(object sender, EventArgs e)
        {

            switch (animationMode)
            {
                case AnimationType.Value:
                    StartAngle = -90;
                    if (_AnimaValue > Value) Value++;
                    if (_AnimaValue < Value) Value--;
                    if (_AnimaValue == Value) timeAnimator.Stop();
                    break;
                case AnimationType.Indicator:
                    if (StartAngle < 360) StartAngle += 10;
                    if (StartAngle >= 360) StartAngle = 0;
                    break;
            }
            Invalidate();

        }

        int _AnimaValue = 0;

        Timer timeAnimator;

        int interval = 50;
        /// <summary>
        /// Sets or gets time to animate.
        /// </summary>
        public int Interval
        {
            get { return interval; }
            set
            {
                interval = value;
                if (IsHandleCreated) timeAnimator.Interval = value;
                Invalidate();
            }
        }
        public enum AnimationType
        {
            /// <summary>
            /// No animations of progress bar.
            /// </summary>
            None,
            /// <summary>
            /// Animation for progress bar value.
            /// </summary>
            Value,
            /// <summary>
            /// Animation with Indicator.
            /// </summary>
            Indicator

        }
        private AnimationType animationMode = AnimationType.None;
        public AnimationType AnimationMode
        {
            get { return animationMode; }
            set
            {
                animationMode = value;

                if (value == AnimationType.None || value == AnimationType.Value)
                {
                    StartAngle = -90;
                }


                Invalidate();
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            SetStandardSize();
            base.OnSizeChanged(e);
        }
        private void SetStandardSize()
        {
            int _Size = Math.Max(Width, Height);
            Size = new Size(_Size, _Size);
        }


        /// <summary>
        ///     Gets or sets the font of text in the <see cref="HCircularProgressBar1" />.
        /// </summary>
        /// <returns>
        ///     The <see cref="T:System.Drawing.Font" /> of the text. The default is the font set by the container.
        /// </returns>
        /// 

        int StartAngle = 270;

        private int Value = 10;
        public int ProgressBarValue
        {
            get
            {
                int val = 0;

                if (AnimationMode == AnimationType.Value)
                    val = _AnimaValue;
                if (AnimationMode != AnimationType.Value)
                    val = Value;
                return val;

            }
            set
            {
                if (AnimationMode == AnimationType.None)
                {
                    if (value < Minimum)
                    {
                        _AnimaValue = Value = Minimum;
                    }
                    else if (value > Maximum)
                    {
                        _AnimaValue = Value = Maximum;
                    }
                    else _AnimaValue = Value = value;

                }
                if (AnimationMode == AnimationType.Indicator)
                {
                    if (value < Minimum)
                    {
                        Value = Minimum;
                    }
                    else if (value > Maximum)
                    {
                        Value = Maximum;
                    }
                    else _AnimaValue = Value = value;

                }
                if (AnimationMode == AnimationType.Value)
                {
                    if (value < Minimum)
                    {
                        _AnimaValue = Minimum;
                    }
                    else if (value > Maximum)
                    {
                        _AnimaValue = Maximum;
                    }
                    else _AnimaValue = value;

                }
                Invalidate();
            }
        }


        /// <summary>
        /// </summary>
        [Category("Appearance")]
        public Color InnerColor { get; set; } = Color.WhiteSmoke;

        /// <summary>
        /// </summary>
        [Category("Layout")]
        public int InnerMargin { get; set; } = 2;

        /// <summary>
        /// </summary>
        [Category("Layout")]
        public int InnerWidth { get; set; } = -1;

        /// <summary>
        /// </summary>
        [Category("Appearance")]
        public Color OuterColor { get; set; } = Color.Silver;

        /// <summary>
        /// </summary>
        [Category("Layout")]
        public int OuterMargin { get; set; } = -10;

        /// <summary>
        /// </summary>
        [Category("Layout")]
        public int OuterWidth { get; set; } = 10;

        private Color progressColor = Global.PrimaryColors.BorderNormalColor1;
        /// <summary>
        /// </summary>
        [Category("Appearance")]
        public Color ProgressColor
        {
            get { return progressColor; }
            set
            {
                progressColor = value;
                if (SliderValueChanged != null)
                {
                    SliderValueChanged(this, EventArgs.Empty);
                }
                ;
                Invalidate();
            }
        }

        /// <summary>
        /// </summary>
        [Category("Layout")]
        public int ProgressWidth { get; set; } = 10;

        ///     Gets or sets the text in the <see cref="HCircularProgressBar1" />.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        public override string Text
        {
            get => base.Text;
            set => base.Text = value;
        }

        /// <summary>
        /// </summary>
        [Category("Layout")]
        public Padding TextMargin { get; set; } = new Padding(8, 8, 0, 0);

        private static PointF AddPoint(PointF p, int v)
        {
            p.X += v;
            p.Y += v;

            return p;
        }

        private static SizeF AddSize(SizeF s, int v)
        {
            s.Height += v;
            s.Width += v;

            return s;
        }

        private static Rectangle ToRectangle(RectangleF rect)
        {
            return new Rectangle((int)rect.X, (int)rect.Y, (int)rect.Width, (int)rect.Height);
        }

        /// <inheritdoc />
        protected override void OnLocationChanged(EventArgs e)
        {
            base.OnLocationChanged(e);
            Invalidate();
        }


        /// <summary>
        ///     Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data. </param>
        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                if (_backBrush == null)
                {
                    RecreateBackgroundBrush();
                }

                StartPaint(e.Graphics);
            }
            catch
            {
                // ignored
            }

        }

        /// <inheritdoc />
        protected override void OnParentBackColorChanged(EventArgs e)
        {
            RecreateBackgroundBrush();
        }

        /// <inheritdoc />
        protected override void OnParentBackgroundImageChanged(EventArgs e)
        {
            RecreateBackgroundBrush();
        }

        /// <inheritdoc />
        protected override void OnParentChanged(EventArgs e)
        {
            if (Parent != null)
            {
                Parent.Invalidated -= ParentOnInvalidated;
                Parent.Resize -= ParentOnResize;
            }

            base.OnParentChanged(e);

            if (Parent != null)
            {
                Parent.Invalidated += ParentOnInvalidated;
                Parent.Resize += ParentOnResize;
            }
        }

        /// <inheritdoc />
        protected override void OnStyleChanged(EventArgs e)
        {
            base.OnStyleChanged(e);
            Invalidate();
        }



        /// <summary>
        ///     Initialize the animation for the marquee styling
        /// </summary>
        /// <param name="firstTime">True if it is the first execution of this function, otherwise false</param>
        protected virtual void InitializeMarquee(bool firstTime)
        {

            _animatedValue = null;

        }

        /// <summary>
        ///     Occurs when parent's display requires redrawing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="invalidateEventArgs"></param>
        protected virtual void ParentOnInvalidated(object sender, InvalidateEventArgs invalidateEventArgs)
        {
            RecreateBackgroundBrush();
        }

        /// <summary>
        ///     Occurs when the parent resized.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        protected virtual void ParentOnResize(object sender, EventArgs eventArgs)
        {
            RecreateBackgroundBrush();
        }

        /// <summary>
        ///     Update or create the brush used for drawing the background
        /// </summary>
        protected virtual void RecreateBackgroundBrush()
        {
            //lock (this)
            {
                _backBrush?.Dispose();
                _backBrush = new SolidBrush(BackColor);

                if (BackColor.A == 255)
                {
                    return;
                }

                if (Parent != null && Parent.Width > 0 && Parent.Height > 0)
                {
                    using (var parentImage = new Bitmap(Parent.Width, Parent.Height))
                    {
                        using (var parentGraphic = Graphics.FromImage(parentImage))
                        {
                            var pe = new PaintEventArgs(parentGraphic,
                                new Rectangle(new Point(0, 0), parentImage.Size));
                            InvokePaintBackground(Parent, pe);
                            InvokePaint(Parent, pe);

                            if (BackColor.A > 0) // Translucent
                            {
                                parentGraphic.FillRectangle(_backBrush, Bounds);
                            }
                        }

                        _backBrush = new TextureBrush(parentImage);
                        ((TextureBrush)_backBrush).TranslateTransform(-Bounds.X, -Bounds.Y);
                    }
                }
                else
                {
                    _backBrush = new SolidBrush(Color.FromArgb(255, BackColor));
                }
            }
        }


        private System.Drawing.Text.TextRenderingHint textRenderHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
        public System.Drawing.Text.TextRenderingHint TextRenderHint
        {
            get { return textRenderHint; }
            set
            {
                textRenderHint = value; Invalidate();
            }
        }

        /// <summary>
        ///     The function responsible for painting the control
        /// </summary>
        /// <param name="g">The <see cref="Graphics" /> object to draw into</param>
        protected virtual void StartPaint(Graphics g)
        {
            try
            {
                g.TextRenderingHint = TextRenderHint;
                lock (this)
                {
                    g.TextRenderingHint = TextRenderingHint.AntiAlias;
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    var point = AddPoint(Point.Empty, 2);
                    var size = AddSize(Size, -2 * 2);

                    if (OuterWidth + OuterMargin < 0)
                    {
                        var offset = Math.Abs(OuterWidth + OuterMargin);
                        point = AddPoint(Point.Empty, offset);
                        size = AddSize(Size, -2 * offset);
                    }

                    if (OuterColor != Color.Empty && OuterColor != Color.Transparent && OuterWidth != 0)
                    {
                        g.FillEllipse(new SolidBrush(OuterColor), new RectangleF(point, size));

                        if (OuterWidth >= 0)
                        {
                            point = AddPoint(point, OuterWidth);
                            size = AddSize(size, -2 * OuterWidth);
                            g.FillEllipse(_backBrush, new RectangleF(point, size));
                        }
                    }

                    point = AddPoint(point, OuterMargin);
                    size = AddSize(size, -2 * OuterMargin);

                    g.FillPie(
                        new SolidBrush(progressColor),
                        ToRectangle(new RectangleF(point, size)),
                        _animatedStartAngle ?? StartAngle,
                        ((_animatedValue ?? Value) - Minimum) / (Maximum - Minimum) * 360);

                    if (ProgressWidth >= 0)
                    {
                        point = AddPoint(point, ProgressWidth);
                        size = AddSize(size, -2 * ProgressWidth);
                        g.FillEllipse(_backBrush, new RectangleF(point, size));
                    }

                    point = AddPoint(point, InnerMargin);
                    size = AddSize(size, -2 * InnerMargin);

                    if (InnerColor != Color.Empty && InnerColor != Color.Transparent && InnerWidth != 0)
                    {
                        g.FillEllipse(new SolidBrush(InnerColor), new RectangleF(point, size));

                        if (InnerWidth >= 0)
                        {
                            point = AddPoint(point, InnerWidth);
                            size = AddSize(size, -2 * InnerWidth);
                            g.FillEllipse(_backBrush, new RectangleF(point, size));
                        }
                    }

                    if (Text == string.Empty)
                    {
                        return;
                    }


                    var stringFormat =
                        new StringFormat();
                    stringFormat.Alignment = stringFormat.LineAlignment = StringAlignment.Center;
                    stringFormat.Trimming = TextTrim;
                    switch (ProgressTextMode)
                    {
                        case TextMode.Text:
                            g.DrawString(
                       Text,
                       Font,
                       new SolidBrush(ForeColor), ClientRectangle, stringFormat);
                            break;
                        case TextMode.Value:
                            g.DrawString(Value.ToString(), Font, new SolidBrush(ForeColor), ClientRectangle, stringFormat);
                            break;
                        case TextMode.Percentage:
                            g.DrawString(Value.ToString() + "%", Font, new SolidBrush(ForeColor), ClientRectangle, stringFormat);
                            break;
                    }
                }

            }
            catch
            {
                // ignored
            }
        }

        public int Minimum { get; set; } = 0;
        public int Maximum { get; set; } = 100;



        public enum TextMode
        {
            None, Value, Percentage, Text
        }

        public TextMode ProgressTextMode { get; set; } = TextMode.Percentage;

        public StringTrimming TextTrim { get; set; } = StringTrimming.EllipsisCharacter;

    }
}
