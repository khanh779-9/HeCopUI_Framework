using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace HeCopUI_Framework.Controls.Indicators
{
    public class PieSpinnerIndicator : Control
    {
        private readonly Timer _timer;
        private float _start;

        public PieSpinnerIndicator()
        {
            SetStyle(GetAppResources.SetControlStyles(), true);
            DoubleBuffered = true;
            Size = new Size(56, 56);
            _timer = new Timer { Interval = 30 };
            _timer.Tick += (s, e) => { _start = (_start + 6f) % 360f; Invalidate(); };
            _timer.Start();
        }

        [Category("Appearance")]
        public Color SpinnerColor { get; set; } = Global.PrimaryColors.ForeNormalColor1;

        [Category("Appearance")]
        public Color BaseColor { get; set; } = Color.FromArgb(40, Color.Gray);

        [Category("Appearance")]
        public float SweepAngle { get; set; } = 70f;

        private bool _isAnimating = true;

        [Category("Behavior")]
        public bool IsAnimating
        {
            get => _isAnimating;
            set
            {
                _isAnimating = value;
                if (value) _timer.Start(); else _timer.Stop();
                Invalidate();
            }
        }

        [Category("Behavior")]
        public int AnimationSpeed
        {
            get => _timer.Interval;
            set { if (value > 0) _timer.Interval = value; }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics; 
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int pad = 4;
            var r = new Rectangle(pad, pad, Width - 2 * pad, Height - 2 * pad);
            using (var b = new SolidBrush(SpinnerColor))
                g.FillPie(b, r, _start, SweepAngle);
            using (var p = new Pen(BaseColor, 2))
                g.DrawEllipse(p, r);
        }
    }
}

