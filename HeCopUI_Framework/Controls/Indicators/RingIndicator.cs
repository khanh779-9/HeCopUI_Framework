using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace HeCopUI_Framework.Controls.Indicators
{
    public class RingIndicator : Control
    {
        private readonly Timer _timer;
        private float _angle = 0;
        private int _ringSize = 8; // Độ dày vòng tròn
        private float _arcSweep = 270f;
        private float _rotationSpeed = 10f;

        public RingIndicator()
        {
            SetStyle(GetAppResources.SetControlStyles(), true);
            DoubleBuffered = true;
            Size = new Size(50, 50);

            _timer = new Timer();
            _timer.Interval = 50; // Tốc độ quay
            _timer.Tick += (s, e) =>
            {
                _angle += _rotationSpeed; // Quay 10 độ mỗi lần tick
                if (_angle >= 360) _angle = 0;
                Invalidate();
            };
            _timer.Start();
        }

        [Category("Appearance")]
        public Color RingColor { get; set; } = Global.PrimaryColors.ForeNormalColor1;

        [Category("Appearance")]
        public int RingThickness
        {
            get => _ringSize;
            set { _ringSize = value; Invalidate(); }
        }

        [Category("Appearance")]
        public float ArcSweep
        {
            get => _arcSweep;
            set { _arcSweep = value; Invalidate(); }
        }

        [Category("Appearance")]
        public Color BaseColor { get; set; } = Color.Transparent;

        [Category("Behavior")]
        public float RotationSpeed
        {
            get => _rotationSpeed;
            set { _rotationSpeed = value; }
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

            Rectangle rect = new Rectangle(_ringSize, _ringSize, Width - _ringSize * 2, Height - _ringSize * 2);

            using (Pen pen = new Pen(RingColor, _ringSize))
            {
                pen.StartCap = LineCap.Round;
                pen.EndCap = LineCap.Round;
                g.DrawArc(pen, rect, _angle, _arcSweep); // Vẽ cung tròn
            }
        }
    }
}

