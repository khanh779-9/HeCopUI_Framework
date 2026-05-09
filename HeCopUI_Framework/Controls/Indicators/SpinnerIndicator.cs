using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace HeCopUI_Framework.Controls.Indicators
{
    /// <summary>
    /// Standard spinner indicator with 12 rotating bars.
    /// </summary>
    public class SpinnerIndicator : Control
    {
        private readonly Timer _timer;
        private int _angle = 0;

        public SpinnerIndicator()
        {
            SetStyle(GetAppResources.SetControlStyles(), true);
            DoubleBuffered = true;
            Size = new Size(50, 50);

            _timer = new Timer();
            _timer.Interval = 80;
            _timer.Tick += (s, e) =>
            {
                _angle = (_angle + (360 / BarCount)) % 360;
                Invalidate();
            };
            _timer.Start();
        }

        [Category("Appearance")]
        public Color SpinnerColor { get; set; } = Global.PrimaryColors.ForeNormalColor1;

        [Category("Appearance")]
        public int BarCount { get; set; } = 12;

        [Category("Appearance")]
        public int LineLength { get; set; } = 10;

        [Category("Appearance")]
        public int LineThickness { get; set; } = 3;

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

            // Save state
            var state = g.Save();
            
            g.TranslateTransform(Width / 2f, Height / 2f);
            g.RotateTransform(_angle);

            for (int i = 0; i < BarCount; i++)
            {
                int alpha = (int)(255f * (i + 1) / BarCount);
                using (Pen pen = new Pen(Color.FromArgb(alpha, SpinnerColor), LineThickness))
                {
                    pen.StartCap = LineCap.Round;
                    pen.EndCap = LineCap.Round;
                    int startY = -Height / 2 + (Height / 2 - LineLength);
                    int endY = -Height / 2 + Height / 2; // Basically center, wait
                    // Old hardcode: 0, -Height/2+5 to 0, -Height/2+15
                    int topOffset = 5;
                    g.DrawLine(pen, 0, -Height / 2f + topOffset, 0, -Height / 2f + topOffset + LineLength);
                }
                g.RotateTransform(360f / BarCount);
            }

            g.Restore(state);
        }
    }
}
