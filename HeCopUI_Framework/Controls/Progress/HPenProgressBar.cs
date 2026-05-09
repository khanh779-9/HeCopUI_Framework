using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls.Progress
{
    [ToolboxBitmap(typeof(HPenProgressBar), "Bitmaps.Progress.bmp")]
    public partial class HPenProgressBar : Control
    {
        public HPenProgressBar()
        {

            SetStyle(GetAppResources.SetControlStyles(), true);
            DoubleBuffered = true;
            Paint += HHAdvancedProgressBar_Paint;
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

        public int MaximumValue { get; set; } = 100;
        private int _Value = 0;


        [Category("Property Changed")]
        public event EventHandler ValueChanged;
        public int Value
        {
            get { return _Value; }
            set
            {
                if (value > MaximumValue) _Value = MaximumValue;
                else if (value < 0) _Value = 0;
                else _Value = value;
                OnAgeChanged();
                Invalidate();
            }
        }

        protected virtual void OnAgeChanged()
        {
            if (ValueChanged != null) ValueChanged(Value, EventArgs.Empty);
        }

        private Color trackcolor1 = Global.PrimaryColors.BackNormalColor1;
        public Color ProgressBarColor1
        {
            get { return trackcolor1; }
            set
            {
                trackcolor1 = value; Invalidate();
            }
        }

        private Color trackcolor2 = Color.FromArgb(0, 125, 250);
        public Color ProgressBarColor2
        {
            get { return trackcolor2; }
            set
            {
                trackcolor2 = value; Invalidate();
            }
        }

        private DashStyle TDS = DashStyle.Solid;
        public DashStyle ProgressBarDaskType
        {
            get { return TDS; }
            set
            {
                TDS = value; Invalidate();
            }
        }

        private Color trackColor1 = HeCopUI_Framework.Global.PrimaryColors.BaseGaugeColor;
        public Color ProgressBaseColor1
        {
            get { return trackColor1; }
            set
            {
                trackColor1 = value; Invalidate();
            }
        }

        private Color trackColor2 = Color.FromArgb(230, 230, 230);
        public Color ProgressBaseColor2
        {
            get { return trackColor2; }
            set
            {
                trackColor2 = value; Invalidate();
            }
        }

        private int _progressWidth = 10;
        public int ProgressBarWidth
        {
            get { return _progressWidth; }
            set
            {
                _progressWidth = value; Invalidate();
            }
        }

        private void HHAdvancedProgressBar_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Helper.GraphicsHelper.SetHightGraphics(g);
            //g.FillRectangle(new SolidBrush(trackColor), new RectangleF(Width / 2 - _TS / 2, 2, _TS, Height - 6));
            LinearGradientBrush B1 = new LinearGradientBrush(ClientRectangle, trackColor1, trackColor2, _baseGradientMode);
            LinearGradientBrush B2 = new LinearGradientBrush(ClientRectangle, trackcolor1, trackcolor2, _progressGradientMode);
            Pen pen = new Pen(B1, _progressWidth)
            {
                StartCap = startpen,
                EndCap = endpen,
                DashStyle = TDS
            };
            Pen pent = new Pen((B2), _progressWidth)
            {
                StartCap = startpenv,
                EndCap = endpenv,
                DashStyle = TDS
            };

            g.DrawLine(pen, new PointF(6, Height / 2), new PointF(Width - 6, Height / 2));
            g.DrawLine(pent, new PointF(6, Height / 2), new PointF(6 + _Value * (Width - 6) / MaximumValue, Height / 2));
        }

        private LinearGradientMode _progressGradientMode = LinearGradientMode.Vertical;
        public LinearGradientMode ProgressGradientMode
        {
            get { return _progressGradientMode; }
            set
            {
                _progressGradientMode = value; Invalidate();
            }
        }

        private LinearGradientMode _baseGradientMode = LinearGradientMode.Vertical;
        public LinearGradientMode BaseGradientMode
        {
            get { return _baseGradientMode; }
            set
            {
                _baseGradientMode = value; Invalidate();
            }
        }

        private LineCap endpenv = LineCap.Round;
        public LineCap EndValue
        {
            get { return endpenv; }
            set
            {
                endpenv = value; Invalidate();
            }
        }

        private LineCap startpenv = LineCap.Round;
        public LineCap StartValue
        {
            get { return startpenv; }
            set
            {
                startpenv = value; Invalidate();
            }
        }

        private LineCap endpen = LineCap.Round;
        public LineCap EndProgressPoint
        {
            get { return endpen; }
            set
            {
                endpen = value; Invalidate();
            }
        }

        private LineCap startpen = LineCap.Round;
        public LineCap StartProgressPoint
        {
            get { return startpen; }
            set
            {
                startpen = value; Invalidate();
            }
        }

    }
}
