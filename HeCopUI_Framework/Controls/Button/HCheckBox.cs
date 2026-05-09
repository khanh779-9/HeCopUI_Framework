using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls.Button
{
    [DefaultEvent("CheckedChanged")]
    public partial class HCheckBox : Control
    {
        #region Variables

        static Point[] CHECKMARK_LINE = { new Point(3, 8), new Point(7, 12), new Point(14, 5) };

        private Color _disabledColor = Color.Gray;
        private Color _enabledTextColor = ColorTranslator.FromHtml("#999999");
        private Color _disabledTextColor = ColorTranslator.FromHtml("#babbbd");

        private Color _checkedColor1 = Color.FromArgb(0, 168, 148);
        private Color _checkedColor2 = Color.DodgerBlue;
        private Color _uncheckedColor = Color.DimGray;

        private Color _borderColor = Color.Transparent;
        public Color BorderBox
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value; Invalidate();
            }
        }

        public Color UncheckedColor
        {
            get { return _uncheckedColor; }
            set
            {
                _uncheckedColor = value; Invalidate();
            }
        }

        public Color CheckedColor1
        {
            get { return _checkedColor1; }
            set
            {
                _checkedColor1 = value; Invalidate();
            }
        }

        public Color CheckedColor2
        {
            get { return _checkedColor2; }
            set
            {
                _checkedColor2 = value; Invalidate();
            }
        }

        public Color DisabledColor
        {
            get { return _disabledColor; }
            set
            {
                _disabledColor = value; Invalidate();
            }
        }

        public Color EnabledTextColor
        {
            get { return _enabledTextColor; }
            set
            {
                _enabledTextColor = value; Invalidate();
            }
        }

        public Color DisabledTextColor
        {
            get { return _disabledTextColor; }
            set
            {
                _disabledTextColor = value; Invalidate();
            }
        }


        private Timer _animationTimer = new Timer { Interval = 17 };

        private int _sizeAnimationNum = 14;
        private int _pointAnimationNum = 3;
        private int _alpha = 0;

        #endregion


        public HCheckBox()
        {
            SetStyle(HeCopUI_Framework.GetAppResources.SetControlStyles(), true);
            _animationTimer = new Timer() { Interval = 10 };
            _animationTimer.Tick += new EventHandler(AnimationTick);
            _rippleAnimate = new Timer() { Interval = 5 };
            _rippleAnimate.Tick += RippleAnimate_Tick;
        }



        protected override void OnMouseEnter(EventArgs e)
        {
            _hover = true;
            _rippleAnimate.Start();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            _hover = false;
            _rippleAnimate.Start();
            base.OnMouseLeave(e);
        }

        private int _rippleCenter = 30;
        private int _rippleWidth = 0;
        private void RippleAnimate_Tick(object sender, EventArgs e)
        {
            if (_hover == true)
            {
                if (_rippleWidth < 28)
                {
                    _rippleWidth += 2;
                }
                else _rippleAnimate.Stop();
            }
            else
            {
                if (_rippleWidth > 0)
                {
                    _rippleWidth -= 2;
                }
                else _rippleAnimate.Stop();
            }
            Invalidate();
        }

        private Timer _rippleAnimate;
        private bool _hover = false;

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
                _animationTimer.Start();
                CheckedChanged?.Invoke(this, null);
                Invalidate();
            }
        }

        public event EventHandler CheckedChanged;

        protected override void OnSizeChanged(EventArgs e)
        {
            if (Size.Height <= 28) Size = new Size(Width, 28);
            if (Size.Width <= 28)
                Size = new Size(28, Height);

            base.OnSizeChanged(e);
        }


        [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public new string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value; Invalidate();
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Checked = !Checked;
            }
            base.OnMouseClick(e);
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

        private Color _checkBoxColor1 = Global.PrimaryColors.BackNormalColor1;
        public Color CheckBoxColor1
        {
            get { return _checkBoxColor1; }
            set
            {
                _checkBoxColor1 = value; Invalidate();
            }
        }

        private Color _checkBoxColor2 = Global.PrimaryColors.BackNormalColor2;
        public Color CheckBoxColor2
        {
            get { return _checkBoxColor2; }
            set
            {
                _checkBoxColor2 = value; Invalidate();
            }
        }

        private LinearGradientMode _gradientMode = LinearGradientMode.Vertical;
        public LinearGradientMode GradientMode
        {
            get { return _gradientMode; }
            set
            {
                _gradientMode = value; Invalidate();
            }
        }


        protected override void OnPaint(PaintEventArgs pevent)
        {

            using (var checkmarkPath = HeCopUI_Framework.Helper.DrawHelper.GetRoundPath(new RectangleF(6f, 6, 15, 15), 0))
            using (var BG = new LinearGradientBrush(new RectangleF(0, 0, checkBoxSize, checkBoxSize), Enabled ? (Checked ? _checkedColor1 : _uncheckedColor) : _disabledColor,
                Enabled ? (Checked ? _checkedColor2 : _uncheckedColor) : _disabledColor, _gradientMode))
            using (Pen Pen = new Pen(new SolidBrush(BorderBox), 1) { Alignment = PenAlignment.Inset })

            using (var ripplebac = new SolidBrush(Color.FromArgb(RippleAlpha, RippleColor)))
            using (var penfoc = new Pen(new SolidBrush(fbc), 1f) { Alignment = PenAlignment.Inset, DashStyle = dashStyle })
            {
                var g = pevent.Graphics;
                StringFormat SF = new StringFormat();
                Helper.GraphicsHelper.SetHightGraphics(g);
                g.TextRenderingHint = TextRenderHint;
                g.FillPath(BG, checkmarkPath);
                g.DrawPath(Pen, checkmarkPath);
                //CheckBox Text
                SF.Alignment = SF.LineAlignment = StringAlignment.Near;
                SF.Trimming = ST;
                g.DrawString(Text, Font, new SolidBrush(Enabled ? EnabledTextColor : DisabledTextColor),
                    new RectangleF(28, 30 / 2 - g.MeasureString(Text, Font).Height / 2, Width - 30, Height - 6), SF);
                //Draw Ripple when mouse horver.
                g.FillEllipse(ripplebac,
                       new RectangleF((_rippleCenter - _rippleWidth) / 2 - 1.25f, (_rippleCenter - _rippleWidth) / 2 - 1.25f, _rippleWidth, _rippleWidth));
                //CheckMark
                g.DrawImage(CheckMarkBitmap(), 5f, 5);
                if (DesignMode == false)
                    if (Focused)
                    {
                        g.SmoothingMode = SmoothingMode.None;
                        g.PixelOffsetMode = PixelOffsetMode.Default;
                        g.DrawRectangle(penfoc, new Rectangle(
                          0, 0, Width - 1, Height - 1));
                    }
            }

            base.OnPaint(pevent);
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

        Color fbc = Global.PrimaryColors.BorderNormalColor1;
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

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color ForeColor { get; set; }

        private StringTrimming ST = StringTrimming.EllipsisCharacter;
        public StringTrimming TextTrim
        {
            get { return ST; }
            set
            {
                ST = value; Invalidate();
            }
        }


        public int RippleAlpha { get; set; } = 60;
        public Color RippleColor { get; set; } = Color.FromArgb(0, 168, 148);

        void AnimationTick(object sender, EventArgs e)
        {
            if (Checked)
            {
                if (_alpha < 250)
                {
                    _alpha += 25;
                    Invalidate();

                    if (_sizeAnimationNum > 0)
                    {
                        _sizeAnimationNum -= 2;
                        Invalidate();
                    }

                    if (_pointAnimationNum < 10)
                    {
                        _pointAnimationNum += 1;
                        Invalidate();
                    }
                }
                else if (_alpha > 250) _animationTimer.Stop();
            }
            else if (_alpha > 0)
            {
                _alpha -= 25;
                Invalidate();

                if (_sizeAnimationNum < 14)
                {
                    _sizeAnimationNum += 2;
                    Invalidate();
                }


                if (_pointAnimationNum > 3)
                {
                    _pointAnimationNum -= 1;
                    Invalidate();
                }
            }
            else if (_alpha < -250) _animationTimer.Stop();
        }

        private Color checkColor = Color.White;
        public Color CheckColor
        {
            get { return checkColor; }
            set
            {
                checkColor = value; Invalidate();
            }
        }

        int checkBoxSize = 16;

        private Bitmap CheckMarkBitmap()
        {
            var checkMark = new Bitmap(checkBoxSize, checkBoxSize);
            checkMark.MakeTransparent();
            var g = Graphics.FromImage(checkMark);
            g.SmoothingMode = SmoothingMode.HighQuality;
            using (var pen = new Pen(new SolidBrush(Color.FromArgb(_alpha, checkColor)), 2))
                g.DrawLines(pen, CHECKMARK_LINE);
            return checkMark;
        }
    }
}