using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace HeCopUI_Framework.Controls.Indicators
{
    public class BouncingBarsIndicator : Control
    {
        private readonly Timer _timer;
        private int _step = 0;
        private int _barCount = 5;
        private int _barWidth = 6;
        private int _spacing = 8;

        public BouncingBarsIndicator()
        {
            SetStyle(GetAppResources.SetControlStyles(), true);
            DoubleBuffered = true;
            Size = new Size(80, 40);

            _timer = new Timer();
            _timer.Interval = 100;
            _timer.Tick += (s, e) =>
            {
                _step = (_step + 1) % _barCount;
                Invalidate();
            };
            _timer.Start();
        }

        [Category("Appearance")]
        public Color BarColor { get; set; } = Global.PrimaryColors.ForeNormalColor1;

        [Category("Appearance")]
        public int BarWidth
        {
            get => _barWidth;
            set { _barWidth = value; Invalidate(); }
        }

        [Category("Appearance")]
        public int Spacing
        {
            get => _spacing;
            set { _spacing = value; Invalidate(); }
        }

        [Category("Appearance")]
        public int BarCount
        {
            get => _barCount;
            set { if (value > 0) { _barCount = value; Invalidate(); } }
        }

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
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            for (int i = 0; i < _barCount; i++)
            {
                int height = (i == _step) ? Height : Height / 2;
                int x = i * (_barWidth + _spacing);
                int y = (Height - height) / 2;

                using (Brush brush = new SolidBrush(BarColor))
                {
                    g.FillRectangle(brush, x, y, _barWidth, height);
                }
            }
        }
    }
}

