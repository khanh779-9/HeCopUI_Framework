using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace HeCopUI_Framework.Controls.Indicators
{
    public class InfinityIndicator : Control
    {
        private readonly Timer _timer;
        private float _t;
        private float _moveSpeed = 0.08f;

        public InfinityIndicator()
        {
            SetStyle(GetAppResources.SetControlStyles(), true);
            DoubleBuffered = true;
            Size = new Size(120, 60);
            _timer = new Timer { Interval = 20 };
            _timer.Tick += (s, e) => { _t += _moveSpeed; if (_t > Math.PI * 2) _t -= (float)Math.PI * 2; Invalidate(); };
            _timer.Start();
        }

        [Category("Appearance")]
        public Color IndicatorColor { get; set; } = Global.PrimaryColors.ForeNormalColor1;

        [Category("Appearance")]
        public Color BasePathColor { get; set; } = Color.FromArgb(40, Global.PrimaryColors.ForeNormalColor1);

        [Category("Appearance")]
        public int DotSize { get; set; } = 12;

        [Category("Appearance")]
        public int PathThickness { get; set; } = 2;

        [Category("Behavior")]
        public float MoveSpeed
        {
            get => _moveSpeed;
            set { _moveSpeed = value; }
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

            // vẽ dấu vô cực mờ
            using (var pathPen = new Pen(BasePathColor, PathThickness))
            {
                var path = new GraphicsPath();
                for (float a = 0; a <= Math.PI * 2; a += 0.05f)
                {
                    var p = Map(a);
                    if (a == 0) path.StartFigure();
                    path.AddLine(p.X, p.Y, p.X + 0.1f, p.Y + 0.1f);
                }
                g.DrawPath(pathPen, path);
            }

            // chấm chạy
            var pt = Map(_t);
            using (var b = new SolidBrush(IndicatorColor))
                g.FillEllipse(b, pt.X - DotSize / 2f, pt.Y - DotSize / 2f, DotSize, DotSize);
        }

        private PointF Map(float a)
        {
            // Param của lemniscate: x = cos(a) / (1 + sin^2(a)), y = cos(a)*sin(a)/(1 + sin^2(a))
            float sa = (float)Math.Sin(a), ca = (float)Math.Cos(a);
            float denom = 1 + sa * sa;
            float x = ca / denom, y = ca * sa / denom;

            // scale to control size
            float sx = (Width - 16) / 2f;     // padding
            float sy = (Height - 16) / 2f;
            return new PointF(Width / 2f + x * sx, Height / 2f + y * sy);
        }
    }
}

