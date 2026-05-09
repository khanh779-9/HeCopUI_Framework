using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace HeCopUI_Framework.Controls.Indicators
{
    public class CirclePulseIndicator : Control
    {
        private readonly Timer _timer;
        private float _scale = 1.0f;
        private bool _growing = true;
        private int _baseSize = 20;

        public CirclePulseIndicator()
        {
            SetStyle(GetAppResources.SetControlStyles(), true);
            DoubleBuffered = true;
            Size = new Size(60, 60);

            _timer = new Timer();
            _timer.Interval = 50; 
            _timer.Tick += (s, e) =>
            {
                if (_growing)
                    _scale += ScaleStep;
                else
                    _scale -= ScaleStep;

                if (_scale >= MaxScale) _growing = false;
                if (_scale <= 1.0f) _growing = true;

                Invalidate();
            };
            _timer.Start();
        }

        [Category("Appearance")]
        public Color PulseColor { get; set; } = Global.PrimaryColors.ForeNormalColor1;

        [Category("Appearance")]
        public int BaseSize
        {
            get => _baseSize;
            set { _baseSize = value; Invalidate(); }
        }

        [Category("Behavior")]
        public float MaxScale { get; set; } = 1.5f;

        [Category("Behavior")]
        public float ScaleStep { get; set; } = 0.05f;

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

            int size = (int)(_baseSize * _scale);
            int x = (Width - size) / 2;
            int y = (Height - size) / 2;

            using (Brush brush = new SolidBrush(PulseColor))
            {
                g.FillEllipse(brush, x, y, size, size);
            }
        }
    }
}

