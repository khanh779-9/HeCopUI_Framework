using HeCopUI_Framework.Structs;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls.Progress
{
    [ToolboxBitmap(typeof(HProgressBar), "Bitmaps.Progress.bmp")]
    public partial class HProgressBar : Control
    {
        int interval = 10;
        int locx = 0;

        public HProgressBar()
        {
            SetStyle(GetAppResources.SetControlStyles(), true);
            ForeColor = Color.White;
            BorderColor = Color.Silver;
            tmrIndi = new System.Windows.Forms.Timer();
            tmrIndi.Tick += TmrIndi_Tick1;
            tmrIndi.Interval = interval;
        }

        protected override void OnCreateControl()
        {
            if (IsHandleCreated)
                tmrIndi.Start();
            base.OnCreateControl();
        }

        private void TmrIndi_Tick1(object sender, EventArgs e)
        {
            switch (animationMode)
            {
                case Enums.ProgressAnimationMode.Indeterminate:
                    int a = ((Or == Orientation.Horizontal) ? Width - 1 : Height - 1);
                    if (locx >= a) locx = 0 - ((_progressValue - _minimumValue) * a) / _maximumValue;
                    else locx += 2;
                    break;

                case Enums.ProgressAnimationMode.Value:
                    if (AnV != _progressValue)
                    {
                        if (AnV < _progressValue) AnV += 1;
                        else if (AnV > _progressValue) AnV -= 1;
                    }
                    else tmrIndi.Stop();
                    break;

                case Enums.ProgressAnimationMode.None:
                    tmrIndi.Stop();
                    break;
            }

            Invalidate();
        }

        private System.Windows.Forms.Timer tmrIndi;

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

        protected override void OnPaint(PaintEventArgs e)
        {
            RectangleF recPro;
            RectangleF recf;

            if (Or == Orientation.Horizontal)
            {
                recPro = new RectangleF(0.5f, 0.5f, Width - 1, Height - 1);
                recf = new RectangleF(0, 0, Width - 0.5f, Height);
            }
            else // Orientation.Vertical
            {
                recPro = new RectangleF(0.5f, 0.5f, Width - 1, Height - 1);
                recf = new RectangleF(0, 0, Width, Height - 0.5f);
            }

            Helper.GraphicsHelper.SetHightGraphics(e.Graphics);

            using (Bitmap bitm = new Bitmap(Width, Height))
            using (Graphics g = Graphics.FromImage(bitm))
            using (GraphicsPath GP = HeCopUI_Framework.Helper.DrawHelper.SetRoundedCornerRectangle(recf, Radius, 0))
            using (LinearGradientBrush LB = new LinearGradientBrush(recPro, BaseProgressColor1, BaseProgressColor2, Linear))
            using (LinearGradientBrush LB1 = new LinearGradientBrush(recPro, ProgressColor1, ProgressColor2, Linear))
            {
                switch (AnimationMode)
                {
                    case Enums.ProgressAnimationMode.None:
                        if (Or == Orientation.Horizontal)
                            recPro.Width = (float)(((_progressValue - _minimumValue) * (float)recf.Width) / _maximumValue);
                        else recPro.Height = (float)(((_progressValue - _minimumValue) * (float)recf.Height) / _maximumValue);
                        break;
                    case Enums.ProgressAnimationMode.Value:
                        if (Or == Orientation.Horizontal)
                            recPro.Width = (float)(((AnV - _minimumValue) * (float)recf.Width) / _maximumValue);
                        else recPro.Height = (float)(((AnV - _minimumValue) * (float)recf.Height) / _maximumValue);
                        break;
                    case Enums.ProgressAnimationMode.Indeterminate:
                        break;
                }

                using (GraphicsPath GPV = (AnimationMode == Enums.ProgressAnimationMode.Indeterminate) ? HeCopUI_Framework.Helper.DrawHelper.SetRoundedCornerRectangle(new RectangleF(
                    0.5f + (Or == Orientation.Horizontal ? locx : 0),
                    0.5f + (Or == Orientation.Vertical ? locx : 0),
                    (Or == Orientation.Horizontal ? 30 : Width - 1),
                    (Or == Orientation.Vertical ? 30 : Height - 1)), Radius, 0) :
                    HeCopUI_Framework.Helper.DrawHelper.SetRoundedCornerRectangle(recPro, Radius, 0))
                {
                    Helper.GraphicsHelper.SetHightGraphics(g);
                    g.FillPath(LB, GP);
                    if (_progressValue != 0 || AnimationMode == Enums.ProgressAnimationMode.Indeterminate) g.FillPath(LB1, GPV);
                    if (_borderThickness != 0)
                    {
                        using (Pen pen = new Pen(new SolidBrush(_borderColor), _borderThickness))
                        {
                            pen.Alignment = PenAlignment.Inset;
                            g.DrawPath(pen, HeCopUI_Framework.Helper.DrawHelper.SetRoundedCornerRectangle(recf, Radius, _borderThickness));
                        }
                    }
                    e.Graphics.FillPath(new TextureBrush(bitm), GP);
                }
            }

            base.OnPaint(e);
        }

        Orientation Or = Orientation.Horizontal;
        public Orientation Orientation
        {
            get { return Or; }
            set
            {
                Or = value; Invalidate();
            }
        }

        private LinearGradientMode Linear = LinearGradientMode.Horizontal;
        public LinearGradientMode GradientMode
        {
            get { return Linear; }
            set
            {
                Linear = value; Invalidate();
            }
        }

        int AnV = 0;
        public int ProgressValue
        {
            get { return _progressValue; }
            set
            {
                if (value > _maximumValue) _progressValue = _maximumValue;
                else if (value < _minimumValue) _progressValue = _minimumValue;
                else _progressValue = value;

                if (AnimationMode == Enums.ProgressAnimationMode.Value && IsHandleCreated) tmrIndi.Start();
                Invalidate();
            }
        }

        private Enums.ProgressAnimationMode animationMode = Enums.ProgressAnimationMode.Value;
        public Enums.ProgressAnimationMode AnimationMode
        {
            get { return animationMode; }
            set
            {
                animationMode = value;
                locx = 0;
                if (animationMode != Enums.ProgressAnimationMode.None)
                {
                    if (IsHandleCreated)
                        tmrIndi.Start();
                }
                Invalidate();
            }
        }

        private CornerRadius _cornerRadius = new CornerRadius(2);
        private int _borderThickness = 1;

        private int _maximumValue = 100;
        private int _minimumValue = 0;
        private int _progressValue = 0;
        private Color _borderColor = Global.PrimaryColors.BorderProgressBarColor1;
        private Color _baseProgressColor2 = Global.PrimaryColors.BaseProgressBarColor1;
        private Color _progressColor2 = Global.PrimaryColors.ProgressBarColor1;

        public Color ProgressColor2
        {
            get { return _progressColor2; }
            set
            {
                _progressColor2 = value; Invalidate();
            }
        }

        public Color BaseProgressColor2
        {
            get { return _baseProgressColor2; }
            set
            {
                _baseProgressColor2 = value; Invalidate();
            }
        }

        private Color _baseProgressColor1 = Global.PrimaryColors.BaseProgressBarColor1;
        private Color _progressColor1 = Global.PrimaryColors.ProgressBarColor1;

        public Color ProgressColor1
        {
            get { return _progressColor1; }
            set
            {
                _progressColor1 = value; Invalidate();
            }
        }

        public Color BaseProgressColor1
        {
            get { return _baseProgressColor1; }
            set
            {
                _baseProgressColor1 = value; Invalidate();
            }
        }

        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value; Invalidate();
            }
        }

        [Localizable(true)]
        public CornerRadius Radius
        {
            get { return _cornerRadius; }
            set
            {
                _cornerRadius = value; Invalidate();
            }
        }

        public int BorderWidth
        {
            get { return _borderThickness; }
            set
            {
                _borderThickness = value; Invalidate();
            }
        }

        public int MinimumValue
        {
            get { return _minimumValue; }
            set
            {
                if (value < 0) _minimumValue = 0;
                else _minimumValue = value; Invalidate();
            }
        }

        public int MaximumValue
        {
            get { return _maximumValue; }
            set
            {
                if (value < _progressValue) _maximumValue = _progressValue;
                else _maximumValue = value; Invalidate();
            }
        }
    }
}
