using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace HeCopUI_Framework.Controls.Indicators
{
    public class LoadingBarIndicator : Control
    {
        private readonly Timer _timer;
        private int _pos;
        
        [Category("Appearance")]
        public int SegmentWidth { get; set; } = 40;
        
        [Category("Appearance")]
        public int Speed { get; set; } = 6;

        public LoadingBarIndicator()
        {
            SetStyle(GetAppResources.SetControlStyles(), true);
            DoubleBuffered = true;
            Size = new Size(180, 12);
            _timer = new Timer { Interval = 30 };
            _timer.Tick += (s, e) => { _pos += Speed; if (_pos > Width + SegmentWidth) _pos = -SegmentWidth; Invalidate(); };
            _timer.Start();
        }

        [Category("Appearance")]
        public Color BarColor { get; set; } = Global.PrimaryColors.ForeNormalColor1;

        [Category("Appearance")]
        public Color BaseColor { get; set; } = Color.FromArgb(30, Color.Gray);

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
            using (var back = new SolidBrush(BaseColor))
                g.FillRectangle(back, ClientRectangle);

            int h = Height - 2;
            int y = 1;
            using (var seg = new SolidBrush(BarColor))
                g.FillRectangle(seg, new Rectangle(_pos, y, SegmentWidth, h));
        }
    }
}

