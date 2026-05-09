using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace HeCopUI_Framework.Controls.Indicators
{
    public class ArcRotateIndicator : Control
    {
        private readonly Timer _timer;
        private float _angle;

        public ArcRotateIndicator()
        {
            SetStyle(GetAppResources.SetControlStyles(), true);
            DoubleBuffered = true;
            Size = new Size(64, 64);
            _timer = new Timer { Interval = 30 };
            _timer.Tick += (s, e) => { _angle = (_angle + 6f) % 360f; Invalidate(); };
            _timer.Start();
        }

        [Category("Appearance")]
        public Color SpinnerColor { get; set; } = Global.PrimaryColors.ForeNormalColor1;

        [Category("Appearance")]
        public int Thickness { get; set; } = 6;

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
            var g = e.Graphics; g.SmoothingMode = SmoothingMode.AntiAlias;

            var rect = new Rectangle(Thickness, Thickness, Width - 2 * Thickness, Height - 2 * Thickness);
            using (var p = new Pen(SpinnerColor, Thickness))
            {
                p.StartCap = LineCap.Round; p.EndCap = LineCap.Round;
                float sweep = 280f;                 // có khoảng hở
                g.DrawArc(p, rect, _angle, sweep);
            }
        }
    }
}
