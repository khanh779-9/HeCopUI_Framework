using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls.Button
{
    [ToolboxBitmap(typeof(CheckBox))]
    public partial class HToggleButton : Control
    {
        private float _diameter = 0;
        private RectangleF _circle = new RectangleF(0, 0, 0, 0);
        private bool _isOn = false;
        private float _animationStep = 0;
        private Color _borderColor = Color.LightGray;
        private bool _textEnabled = true;
        private string _onText = "On";
        private string _offText = "Off";
        private Color _onColor = HeCopUI_Framework.Global.PrimaryColors.OnToggleButtonColor;
        private Color _offColor = HeCopUI_Framework.Global.PrimaryColors.OffToggleButtonColor;
        private Timer _paintTicker = new Timer();
        public event SliderChangedEventHandler SliderValueChanged;
        private Point _location = new Point(0, 0);
        private float _radius = 20;
        private GraphicsPath _path = new GraphicsPath();
        private float _x = 0;
        private float _y = 0;
        private float _width = 0;
        private float _height = 0;
        private Color _leverColor = HeCopUI_Framework.Global.PrimaryColors.LeverToggleButtonColor;



        protected override void OnTextChanged(EventArgs e)
        {
            Invalidate();
            base.OnTextChanged(e);
        }

        protected override void OnFontChanged(EventArgs e)
        {
            Invalidate();
            base.OnFontChanged(e);
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            Invalidate();
            base.OnForeColorChanged(e);
        }
        public void MyRectangle(float width, float height, float radius, float x = 0f, float y = 0f)
        {
            _location = new Point(0, 0);
            this._radius = radius;
            this._x = x;
            this._y = y;
            this._width = width;
            this._height = height;
            _path = new GraphicsPath();
            if (radius <= 0f)
            {
                _path.AddRectangle(new RectangleF(x, y, width, height));
            }
            else
            {
                RectangleF ef = new RectangleF(x, y, 2f * radius, 2f * radius);
                RectangleF ef2 = new RectangleF((width - (2f * radius)) - 1f, x, 2f * radius, 2f * radius);
                RectangleF ef3 = new RectangleF(x, (height - (2f * radius)) - 1f, 2f * radius, 2f * radius);
                RectangleF ef4 = new RectangleF((width - (2f * radius)) - 1f,
                    (height - (2f * radius)) - 1f, 2f * radius, 2f * radius);

                _path.AddArc(ef, 180f, 90f);
                _path.AddArc(ef2, 270f, 90f);
                _path.AddArc(ef4, 0f, 90f);
                _path.AddArc(ef3, 90f, 90f);
                _path.CloseAllFigures();
            }
        }

        public GraphicsPath Path =>
            _path;

        public RectangleF Rect =>
            new RectangleF(_x, _y, _width, _height);

        public float Radius
        {
            get =>
                _radius;
            set
            {
                _radius = value; Invalidate();
            }
        }

        public HToggleButton()
        {
            SetStyle(GetAppResources.SetControlStyles(), true);

            _animationStep = 4f;


            _diameter = 30f;

            DoubleBuffered = true;



            MyRectangle(2f * _diameter, _diameter + 2f, _diameter / 2f, 1f, 1f);
            _circle = new RectangleF(1f, 1f, _diameter, _diameter);

            _paintTicker = new Timer();
            _paintTicker.Tick += new EventHandler(paintTicker_Tick);
            _paintTicker.Interval = 10;



        }

        protected override void OnInvalidated(InvalidateEventArgs e)
        {
            _paintTicker.Start();
            base.OnInvalidated(e);
        }



        protected override void OnCreateControl()
        {
            _paintTicker.Start();
            base.OnCreateControl();
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            Invalidate();
            base.OnEnabledChanged(e);
        }

        Color statusColor = Color.White;
        public Color StatusColor
        {
            get { return statusColor; }
            set
            {
                statusColor = value; Invalidate();
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                IsOn = !IsOn;
                // IsOn = isON;
                //base.OnMouseClick(e);
            }

            base.OnMouseClick(e);
            Invalidate();
        }


        private System.Drawing.Text.TextRenderingHint textRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
        public System.Drawing.Text.TextRenderingHint TextRenderHint
        {
            get { return textRenderHint; }
            set
            {
                textRenderHint = value; Invalidate();
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Helper.GraphicsHelper.SetHightGraphics(e.Graphics);
            e.Graphics.TextRenderingHint = TextRenderHint;
            Pen pen;
            using (SolidBrush brush = new SolidBrush(_isOn ? _onColor : _offColor))
            {
                e.Graphics.FillPath(brush, Path);
            }
            using (pen = new Pen(_borderColor, 2f))
            {
                e.Graphics.DrawPath(pen, Path);
            }
            if (_textEnabled)
            {
                using (Font font = new Font(Font.Name, (8.2f * _diameter) / 30f))
                {
                    SolidBrush b = new SolidBrush(statusColor);
                    int height = TextRenderer.MeasureText(_onText, font).Height;
                    float num2 = (_diameter - height) / 2f;
                    e.Graphics.DrawString(_onText, font, b, 5f, num2 + 1f);
                    height = TextRenderer.MeasureText(_offText, font).Height;
                    num2 = (_diameter - height) / 2f;
                    e.Graphics.DrawString(_offText, font, b, _diameter + 2f, num2 + 1f);
                }
                using (SolidBrush brush2 = new SolidBrush(_leverColor))
                {
                    e.Graphics.FillEllipse(brush2, _circle);
                }
                using (pen = new Pen(Color.LightGray, 1.2f))
                {
                    e.Graphics.DrawEllipse(pen, _circle);
                }
            }
            else
            {
                using (SolidBrush brush3 = new SolidBrush(_isOn ? _onColor : _offColor))
                {
                    using (SolidBrush brush4 = new SolidBrush(_leverColor))
                    {
                        e.Graphics.FillPath(brush3, Path);
                        e.Graphics.FillEllipse(brush4, _circle);
                        e.Graphics.DrawEllipse(Pens.DarkGray, _circle);
                    }
                }
            }
            base.OnPaint(e);
        }


        private Color BordLC = Color.DarkGray;
        public Color BorderLeverColor
        {
            get { return BordLC; }
            set
            {
                BordLC = value; Invalidate();
            }
        }

        public Color LeverColor
        {
            get { return _leverColor; }
            set
            {
                _leverColor = value; Invalidate();
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.Width = (base.Height - 2) * 2;
            _diameter = base.Width / 2;
            _animationStep = (4f * _diameter) * 30f;
            MyRectangle(2f * _diameter, _diameter + 2f, _diameter / 2f, 1f, 1f);
            _circle = new RectangleF(!_isOn ? 1f : ((base.Width - _diameter) - 1f), 1f, _diameter, _diameter);
            Invalidate();
            base.OnResize(e);
        }

        private void paintTicker_Tick(object sender, EventArgs e)
        {
            float x = _circle.X;
            if (_isOn)
            {
                if ((x + _animationStep) <= ((base.Width - _diameter) - 1f))
                {
                    x += _animationStep;
                    _circle = new RectangleF(x, 1f, _diameter, _diameter);
                    Invalidate();
                }
                else
                {
                    x = (base.Width - _diameter) - 1f;
                    _circle = new RectangleF(x, 1f, _diameter, _diameter);
                    Invalidate();
                    _paintTicker.Stop();
                }
            }
            else if ((x - _animationStep) >= 1f)
            {
                x -= _animationStep;
                _circle = new RectangleF(x, 1f, _diameter, _diameter); Invalidate();
            }
            else
            {
                x = 1f;
                _circle = new RectangleF(x, 1f, _diameter, _diameter);
                Invalidate();
                _paintTicker.Stop();
            }
            Invalidate();
        }

        public bool TextEnabled
        {
            get =>
                _textEnabled;
            set
            {
                _textEnabled = value;
                base.Invalidate();
            }
        }

        public bool IsOn
        {
            get =>
                _isOn;
            set
            {
                _paintTicker.Stop();
                _isOn = value;
                _paintTicker.Start();
                if (SliderValueChanged != null)
                {
                    SliderValueChanged(this, EventArgs.Empty);
                }

                Invalidate();
            }
        }

        public Color BorderColor
        {
            get =>
                _borderColor;
            set
            {
                _borderColor = value;
                base.Invalidate();
            }
        }

        protected override Size DefaultSize
            => new Size(60, 35);
        public delegate void SliderChangedEventHandler(object sender, EventArgs e);


        public string OnText
        {
            get =>
                _onText;
            set
            {
                _onText = value;
                base.Invalidate();
            }
        }
        public string OffText
        {
            get =>
                _offText;
            set
            {
                _offText = value;
                base.Invalidate();
            }
        }

        public Color OnColor
        {
            get =>
                _onColor;
            set
            {
                _onColor = value;
                base.Invalidate();
            }
        }

        public Color OffColor
        {
            get =>
                _offColor;
            set
            {
                _offColor = value;
                base.Invalidate();
            }
        }
    }
}
