using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace HeCopUI_Framework.Controls.Indicators
{
    public class WaveDotsIndicator : Control
    {
        private readonly Timer _timer;
        private int _step = 0;
        private int _dotCount = 5;
        private int _dotSize = 10;
        private int _spacing = 15;
        private int _waveHeight = 3;

        public WaveDotsIndicator()
        {
            SetStyle(GetAppResources.SetControlStyles(), true);
            DoubleBuffered = true;
            Size = new Size(120, 40);

            _timer = new Timer();
            _timer.Interval = 100;
            _timer.Tick += (s, e) =>
            {
                _step = (_step + 1) % _dotCount;
                Invalidate();
            };
            _timer.Start();
        }

        [Category("Appearance")]
        public Color DotColor { get; set; } = Global.PrimaryColors.ForeNormalColor1;

        [Category("Appearance")]
        public Color BaseColor { get; set; } = Color.Transparent;

        [Category("Appearance")]
        public int DotCount
        {
            get => _dotCount;
            set { if (value > 0) { _dotCount = value; Invalidate(); } }
        }

        [Category("Appearance")]
        public int DotSize
        {
            get => _dotSize;
            set { _dotSize = value; Invalidate(); }
        }

        [Category("Appearance")]
        public int Spacing
        {
            get => _spacing;
            set { _spacing = value; Invalidate(); }
        }

        [Category("Appearance")]
        public int WaveHeight
        {
            get => _waveHeight;
            set { _waveHeight = value; Invalidate(); }
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

            if (BaseColor != Color.Transparent)
            {
                using (Brush b = new SolidBrush(BaseColor))
                    g.FillRectangle(b, ClientRectangle);
            }

            for (int i = 0; i < _dotCount; i++)
            {
                int offsetY = ((i + _step) % _dotCount) * _waveHeight;
                int x = i * (_dotSize + _spacing);
                int y = (Height - _dotSize) / 2 - offsetY;

                using (Brush brush = new SolidBrush(DotColor))
                {
                    g.FillEllipse(brush, x, y, _dotSize, _dotSize);
                }
            }
        }
    }
}

