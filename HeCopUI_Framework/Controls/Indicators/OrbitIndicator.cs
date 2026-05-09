using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace HeCopUI_Framework.Controls.Indicators
{
    public class OrbitIndicator : Control
    {
        private readonly Timer _timer;
        private float _angle;

        public OrbitIndicator()
        {
            SetStyle(GetAppResources.SetControlStyles(), true);
            DoubleBuffered = true;
            Size = new Size(60, 60);
            _timer = new Timer { Interval = 25 };
            _timer.Tick += (s, e) => { _angle = (_angle + 4f) % 360f; Invalidate(); };
            _timer.Start();
        }

        [Category("Appearance")]
        public Color CenterColor { get; set; } = Global.PrimaryColors.ForeNormalColor1;

        [Category("Appearance")]
        public Color OrbitColor { get; set; } = Color.MediumVioletRed;

        [Category("Appearance")]
        public Color BaseColor { get; set; } = Color.FromArgb(50, Global.PrimaryColors.ForeNormalColor1);

        [Category("Appearance")]
        public int CenterSize { get; set; } = 12;

        [Category("Appearance")]
        public int SatelliteSize { get; set; } = 10;

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

            PointF c = new PointF(Width / 2f, Height / 2f);
            int orbitR = Math.Min(Width, Height) / 2 - 10;

            using (var orbit = new Pen(BaseColor, 2))
                g.DrawEllipse(orbit, c.X - orbitR, c.Y - orbitR, 2 * orbitR, 2 * orbitR);

            using (var center = new SolidBrush(CenterColor))
                g.FillEllipse(center, c.X - CenterSize / 2f, c.Y - CenterSize / 2f, CenterSize, CenterSize);

            double rad = _angle * Math.PI / 180.0;
            float x = c.X + (float)(Math.Cos(rad) * orbitR);
            float y = c.Y + (float)(Math.Sin(rad) * orbitR);
            using (var sat = new SolidBrush(OrbitColor))
                g.FillEllipse(sat, x - SatelliteSize / 2f, y - SatelliteSize / 2f, SatelliteSize, SatelliteSize);
        }
    }
}

