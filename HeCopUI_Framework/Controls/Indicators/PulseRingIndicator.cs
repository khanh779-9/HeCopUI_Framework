using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace HeCopUI_Framework.Controls.Indicators
{
    public class PulseRingIndicator : Control
    {
        private readonly Timer _timer;
        private float _scale = 0.7f;
        private bool _up = true;
        private int _thickness = 6;
        private float _maxScale = 1.2f;
        private float _minScale = 0.7f;
        private float _scaleStep = 0.02f;

        public PulseRingIndicator()
        {
            SetStyle(GetAppResources.SetControlStyles(), true);
            DoubleBuffered = true;
            Size = new Size(64, 64);
            _timer = new Timer { Interval = 40 };
            _timer.Tick += (s, e) =>
            {
                _scale += (_up ? _scaleStep : -_scaleStep);
                if (_scale >= _maxScale) _up = false;
                if (_scale <= _minScale) _up = true;
                Invalidate();
            };
            _timer.Start();
        }

        [Category("Appearance")]
        public Color RingColor { get; set; } = Global.PrimaryColors.ForeNormalColor1;

        [Category("Appearance")]
        public Color BaseColor { get; set; } = Color.Transparent;

        [Category("Appearance")]
        public int Thickness
        {
            get => _thickness;
            set { _thickness = value; Invalidate(); }
        }

        [Category("Behavior")]
        public float MaxScale
        {
            get => _maxScale;
            set { _maxScale = value; Invalidate(); }
        }

        [Category("Behavior")]
        public float MinScale
        {
            get => _minScale;
            set { _minScale = value; Invalidate(); }
        }

        [Category("Behavior")]
        public float ScaleStep
        {
            get => _scaleStep;
            set { _scaleStep = value; Invalidate(); }
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

            int baseR = Math.Min(Width, Height) - (Thickness * 2);
            int w = (int)(baseR * _scale);
            int x = (Width - w) / 2, y = (Height - w) / 2;

            float range = _maxScale - _minScale;
            int alpha = 80 + (int)(120 * (_scale - _minScale) / (range == 0 ? 1 : range));
            using (var p = new Pen(Color.FromArgb(alpha, RingColor), _thickness) { LineJoin = LineJoin.Round })
                g.DrawEllipse(p, x, y, w, w);
        }
    }
}

