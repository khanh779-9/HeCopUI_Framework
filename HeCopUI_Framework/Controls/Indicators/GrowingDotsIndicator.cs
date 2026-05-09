using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace HeCopUI_Framework.Controls.Indicators
{
    public class GrowingDotsIndicator : Control
    {
        private readonly Timer _timer;
        private int _step = 0;
        private int _dotCount = 4;
        private int _baseSize = 10;
        private int _spacing = 20;
        private int _activeSizePlus = 6;

        public GrowingDotsIndicator()
        {
            SetStyle(GetAppResources.SetControlStyles(), true);
            DoubleBuffered = true;
            Size = new Size(120, 40);

            _timer = new Timer();
            _timer.Interval = 150;
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
        public int BaseSize
        {
            get => _baseSize;
            set { _baseSize = value; Invalidate(); }
        }

        [Category("Appearance")]
        public int Spacing
        {
            get => _spacing;
            set { _spacing = value; Invalidate(); }
        }

        [Category("Appearance")]
        public int ActiveSizePlus
        {
            get => _activeSizePlus;
            set { _activeSizePlus = value; Invalidate(); }
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
                int size = (i == _step) ? _baseSize + _activeSizePlus : _baseSize;
                int alpha = (i == _step) ? 255 : 120;

                using (Brush brush = new SolidBrush(Color.FromArgb(alpha, DotColor)))
                {
                    int x = i * (_baseSize + _spacing);
                    int y = (Height - size) / 2;
                    g.FillEllipse(brush, x, y, size, size);
                }
            }
        }
    }
}

