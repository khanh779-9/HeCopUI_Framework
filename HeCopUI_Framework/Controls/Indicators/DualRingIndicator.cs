using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace HeCopUI_Framework.Controls.Indicators
{
    public class DualRingIndicator : Control
    {
        private readonly Timer _timer;
        private float _angle1 = 0;
        private float _angle2 = 0;
        private int _thickness = 5;
        private int _rotationSpeed = 5;
        private float _arcSweep = 120f;

        public DualRingIndicator()
        {
            SetStyle(GetAppResources.SetControlStyles(), true);
            DoubleBuffered = true;
            Size = new Size(60, 60);

            _timer = new Timer();
            _timer.Interval = 50;
            _timer.Tick += (s, e) =>
            {
                _angle1 += _rotationSpeed;
                _angle2 -= _rotationSpeed;
                Invalidate();
            };
            _timer.Start();
        }

        [Category("Appearance")]
        public Color Color1 { get; set; } = Global.PrimaryColors.ForeNormalColor1;

        [Category("Appearance")]
        public Color Color2 { get; set; } = Color.MediumVioletRed;

        [Category("Appearance")]
        public int Thickness
        {
            get => _thickness;
            set { _thickness = value; Invalidate(); }
        }

        [Category("Appearance")]
        public float ArcSweep
        {
            get => _arcSweep;
            set { _arcSweep = value; Invalidate(); }
        }

        [Category("Behavior")]
        public int RotationSpeed
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

            Rectangle rect = new Rectangle(_thickness, _thickness, Width - _thickness * 2, Height - _thickness * 2);

            using (Pen pen = new Pen(Color1, _thickness))
            {
                pen.StartCap = LineCap.Round;
                pen.EndCap = LineCap.Round;
                g.DrawArc(pen, rect, _angle1, _arcSweep);
            }

            using (Pen pen = new Pen(Color2, _thickness))
            {
                pen.StartCap = LineCap.Round;
                pen.EndCap = LineCap.Round;
                g.DrawArc(pen, rect, _angle2, _arcSweep);
            }
        }
    }
}

