using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace HeCopUI_Framework.Controls.Indicators
{
    public class FadingCircleIndicator : Control
    {
        private readonly Timer _timer;
        private int _step;
        private int _dotCount = 12;
        private int _dotSize = 6;

        public FadingCircleIndicator()
        {
            SetStyle(GetAppResources.SetControlStyles(), true);
            DoubleBuffered = true;
            Size = new Size(60, 60);
            _timer = new Timer { Interval = 80 };
            _timer.Tick += (s, e) => { _step = (_step + 1) % _dotCount; Invalidate(); };
            _timer.Start();
        }

        [Category("Appearance")]
        public Color IndicatorColor { get; set; } = Global.PrimaryColors.ForeNormalColor1;

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

            if (BaseColor != Color.Transparent)
            {
                using (Brush b = new SolidBrush(BaseColor))
                    g.FillRectangle(b, ClientRectangle);
            }

            int r = Math.Min(Width, Height) / 2 - _dotSize;
            Point c = new Point(Width / 2, Height / 2);

            for (int i = 0; i < _dotCount; i++)
            {
                double ang = (Math.PI * 2 / _dotCount) * i;
                int x = c.X + (int)(Math.Cos(ang) * r) - _dotSize / 2;
                int y = c.Y + (int)(Math.Sin(ang) * r) - _dotSize / 2;
                int rank = (i - _step + _dotCount) % _dotCount;
                int alpha = 50 + (int)(205.0 * (_dotCount - rank) / _dotCount);
                using (var b = new SolidBrush(Color.FromArgb(alpha, IndicatorColor)))
                    g.FillEllipse(b, x, y, _dotSize, _dotSize);
            }
        }
    }
}

