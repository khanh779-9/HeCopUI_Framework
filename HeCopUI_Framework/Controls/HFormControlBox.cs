using HeCopUI_Framework.Enums;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls
{
    [ToolboxBitmap(typeof(HFormControlBox), "Bitmaps.ControlButton.bmp")]
    public partial class HFormControlBox : Control
    {
        public HFormControlBox()
        {
            SetStyle(GetAppResources.SetControlStyles(), true);
            Paint += HFormControlBox1_Paint;

        }

        protected override void OnHandleCreated(EventArgs e)
        {
            _timer = new System.Windows.Forms.Timer();
            _timer.Tick += Timer_Tick;
            base.OnHandleCreated(e);
        }

        protected override void OnInvalidated(InvalidateEventArgs e)
        {
            _timer.Interval = 15;
            base.OnInvalidated(e);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (_hovered == true)
            {
                _step += (_step < 255) ? 15 : 0;
                if (_step >= 255) _timer.Stop();
            }
            else
            {
                _step -= (_step > 0) ? 15 : 0;
                if (_step <= 0) _timer.Stop();
            }
            Invalidate();
        }

        private int _step = 0;
        private System.Windows.Forms.Timer _timer;
        private bool _hovered = false;

        protected override void OnMouseEnter(EventArgs e)
        {
            _hovered = true; if (IsHandleCreated) _timer.Start();
            Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {

            Invalidate();
            base.OnMouseDown(e);
        }


        protected override void OnMouseLeave(EventArgs e)
        {
            _hovered = false; if (IsHandleCreated) _timer.Start();
            Invalidate();
            base.OnMouseLeave(e);
        }

        public bool MaximizeToFullScreen { get; set; } = false;

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                switch (_iconType)
                {
                    case IconType.Hide:
                        TargetForm.Hide();
                        break;
                    case IconType.Close:
                        try
                        {
                            TargetForm.Close();
                        }
                        catch
                        {
                        }
                        break;
                    case IconType.NormalAndMaximize:
                        if (!DesignMode)
                        {
                            switch (TargetForm.WindowState)
                            {
                                case FormWindowState.Normal:
                                    if (MaximizeToFullScreen == false) TargetForm.MaximumSize = Screen.GetWorkingArea(this).Size;
                                    else TargetForm.MaximumSize = new Size(0, 0);
                                    TargetForm.WindowState = FormWindowState.Maximized;
                                    if (MaximizeToFullScreen == false) TargetForm.MaximumSize = new Size(0, 0);
                                    break;
                                case FormWindowState.Maximized:
                                    TargetForm.WindowState = FormWindowState.Normal;
                                    break;
                            }
                        }
                        break;
                    case IconType.Minimize:
                        TargetForm.WindowState = FormWindowState.Minimized;
                        break;
                }
            }
            base.OnMouseClick(e);
        }

        protected override void OnResize(EventArgs e)
        {
            Size = new Size(28, 28);
            base.OnResize(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            Size = new Size(28, 28);
            base.OnSizeChanged(e);
        }

        public ShapeType HoverColorType { get; set; } = ShapeType.RoundedRectangle;

        private int _radius = 5;
        public int Radius
        {
            get { return _radius; }
            set
            {
                _radius = value; Invalidate();
            }
        }

        private void HFormControlBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Helper.GraphicsHelper.SetHightGraphics(g);
            SolidBrush SB = new SolidBrush(_hovered ? HeCopUI_Framework.Helper.DrawHelper.BlendColor(ControlBoxColor, ControlBoxHoverColor, _step) : ControlBoxColor);
            switch (HoverColorType)
            {

                case ShapeType.Circular:
                    g.FillEllipse(SB, new Rectangle(0, 0, Width, Height));
                    break;
                case ShapeType.RoundedRectangle:
                    g.FillPath(SB, HeCopUI_Framework.Helper.DrawHelper.GetRoundPath(ClientRectangle, _radius));
                    break;
            }

            Bitmap bit = new Bitmap(12, 12);
            bit.MakeTransparent();
            Graphics gb = Graphics.FromImage(bit);
            DrawIcon2(gb, new RectangleF(0, 0, bit.Width, bit.Height));
            g.TranslateTransform(Width / 2 - bit.Width / 2, Height / 2 - bit.Height / 2);
            g.DrawImage(bit, 0, 0);

        }

        private System.Drawing.Color _iconColor = System.Drawing.Color.FromArgb(80, 80, 80);
        public System.Drawing.Color IconColor
        {
            get
            {
                return _iconColor;
            }
            set
            {
                _iconColor = value; Invalidate();
            }
        }

        public System.Drawing.Color IconHoverColor { get; set; } = System.Drawing.Color.FromArgb(120, 120, 120);

        private System.Drawing.Color _controlBoxColor = System.Drawing.Color.WhiteSmoke;
        public System.Drawing.Color ControlBoxColor
        {
            get
            {
                return _controlBoxColor;
            }
            set
            {
                _controlBoxColor = value; Invalidate();
            }
        }

        public System.Drawing.Color ControlBoxHoverColor { get; set; } = System.Drawing.Color.White;

        void DrawIcon2(Graphics g, RectangleF rect)
        {
            float penw = 2f;
            System.Drawing.Pen pen = new System.Drawing.Pen(new SolidBrush(HeCopUI_Framework.Helper.DrawHelper.BlendColor(IconColor, IconHoverColor, _step)), penw) { Alignment = PenAlignment.Inset };
            float offs = penw - 1;
            switch (_iconType)
            {
                case IconType.Hide:
                    g.DrawLine(pen, rect.X, rect.Y, rect.Width - offs, rect.Height - offs);
                    g.DrawLine(pen, rect.X, rect.Height - offs, rect.Width - offs, rect.Y);
                    break;
                case IconType.Close:
                    g.DrawLine(pen, rect.X, rect.Y, rect.Width - offs, rect.Height - offs);
                    g.DrawLine(pen, rect.X, rect.Height - offs, rect.Width - offs, rect.Y);
                    break;
                case IconType.NormalAndMaximize:
                    if (TargetForm.WindowState == FormWindowState.Maximized)
                    {
                        // Khoi phuc kich thuoc cua so
                        offs++;
                        g.DrawRectangle(pen, rect.X, rect.Y + offs, rect.Width - offs, rect.Height - offs);
                        //g.DrawRectangle(pen, rect.X + offs, rect.Y, rect.Width - offs , rect.Height - offs);
                        g.DrawLine(pen, rect.X + offs, rect.Y + offs, rect.X + offs, rect.Y);
                        g.DrawLine(pen, rect.X + offs, rect.Y + 1, (rect.Width) - 1, rect.Y);
                        g.DrawLine(pen, rect.Width - 1, rect.Y, rect.Width - 1, rect.Height - offs);
                        g.DrawLine(pen, rect.Width - offs - 1, rect.Height - offs, Width - 1, rect.Height - offs);
                    }
                    else
                    {
                        g.DrawRectangle(pen, rect.X, rect.Y, rect.Width, rect.Height);
                        //g.DrawPath(pen, HeCopUI_Framework.Helper.DrawHelper.GetRoundPath(new RectangleF(rect.X,rect.Y,rect.Width-1,rect.Height-1), 3,3));
                    }
                    break;
                case IconType.Minimize:
                    g.DrawLine(pen, rect.X, rect.Y + rect.Height / 2, rect.Width, rect.Y + rect.Height / 2);
                    break;
            }

        }

        public Form TargetForm => FindForm();
        public enum IconType { NormalAndMaximize, Minimize, Close, Hide }
        private IconType _iconType = IconType.Close;
        public IconType IconButtonType
        {
            get { return _iconType; }
            set
            {
                _iconType = value; Invalidate();
            }
        }

    }
}
