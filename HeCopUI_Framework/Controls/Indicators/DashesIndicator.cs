using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace HeCopUI_Framework.Controls.Indicators
{
    public class DashesIndicator : Control
    {
        private readonly Timer _timer;
        private int _offset = 0;
        private int _dashCount = 5;
        private int _dashWidth = 15;
        private int _dashHeight = 5;
        private int _spacing = 10;

        public DashesIndicator()
        {
            SetStyle(GetAppResources.SetControlStyles(), true);
            DoubleBuffered = true;
            Size = new Size(100, 20);

            _timer = new Timer();
            _timer.Interval = 100;
            _timer.Tick += (s, e) =>
            {
                _offset = (_offset + 1) % _dashCount;
                Invalidate();
            };
            _timer.Start();
        }

        [Category("Appearance")]
        public Color DashColor { get; set; } = Global.PrimaryColors.ForeNormalColor1;

        [Category("Appearance")]
        public int DashCount
        {
            get => _dashCount;
            set { _dashCount = value; Invalidate(); }
        }

        [Category("Appearance")]
        public int DashWidth
        {
            get => _dashWidth;
            set { _dashWidth = value; Invalidate(); }
        }

        [Category("Appearance")]
        public int DashHeight
        {
            get => _dashHeight;
            set { _dashHeight = value; Invalidate(); }
        }

        [Category("Appearance")]
        public int Spacing
        {
            get => _spacing;
            set { _spacing = value; Invalidate(); }
        }

        [Category("Appearance")]
        public Color BaseColor { get; set; } = Color.Transparent;

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

            for (int i = 0; i < _dashCount; i++)
            {
                int alpha = 255 - ((i + _dashCount - _offset) % _dashCount) * (255 / _dashCount);
                using (Brush brush = new SolidBrush(Color.FromArgb(alpha, DashColor)))
                {
                    int x = i * (_dashWidth + _spacing);
                    int y = (Height - _dashHeight) / 2;
                    g.FillRectangle(brush, x, y, _dashWidth, _dashHeight);
                }
            }
        }
    }
}

