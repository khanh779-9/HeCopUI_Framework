using HeCopUI_Framework.Controls;
using HeCopUI_Framework.Enums;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Color = System.Drawing.Color;
using Pen = System.Drawing.Pen;
using Point = System.Drawing.Point;
using Size = System.Drawing.Size;
namespace HeCopUI_Framework.Forms
{
    public partial class HForm : Form
    {
        public HForm()
        {
            InitializeComponent();
            // Ensure the client area matches the designer's intended size
            // Designer sets ClientSize to 321x229; enforce it explicitly to avoid runtime differences
            this.ClientSize = new System.Drawing.Size(321, 229);
            SetStyle(GetAppResources.SetControlStyles(), true);
            base.FormBorderStyle = FormBorderStyle.None;

            CalcSystemBoxPos();
            MouseLeave += HForm_MouseLeave;
        }

        private void HForm_MouseLeave(object sender, EventArgs e)
        {
            _isMinHovered = false;
            _isMaxHovered = false;
            _isCloseHovered = false;
            Invalidate();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            Invalidate();
            base.OnTextChanged(e);
        }

        [Category("Shadow")]
        public int AlphaShadowColor { get; set; } = 150;
        [Category("Shadow")]
        public int ShadowBlur { get; set; } = 10;
        [Category("Shadow")]
        public int ShadowSpread { get; set; } = 0;
        [Category("Shadow")]
        public Color ShadowColor { get; set; } = Color.Black;
        [Category("Shadow")]
        public bool HideResizeShadow { get; set; } = false;
        [Category("Shadow")]
        public bool ShadowVisible { get; set; } = true;

        protected override void OnLoad(EventArgs e)
        {
            hDropShadowForm = new HDropShadowForm
            {
                ShadowSpread = ShadowSpread,
                HideResizeShadow = HideResizeShadow,
                ShadowBlur = ShadowBlur,
                ShadowColor = ShadowColor,
                AlphaColor = AlphaShadowColor,
                ShadowVisible = ShadowVisible
            };
            if (!DesignMode)
            {
                hDropShadowForm.TargetForm = this;
            }
            base.OnLoad(e);
        }



        HDropShadowForm hDropShadowForm = new HDropShadowForm();
        //[Browsable(false)]
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public new FormBorderStyle FormBorderStyle
        //{ get; set; } = FormBorderStyle.None;

        int _closeStep = 0;
        int _maxStep = 0;
        int _minStep = 0;

        ControlsBox _controlBox = new ControlsBox();
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlsBox FormControlBox
        {
            get
            {
                if (_controlBox == null) _controlBox = new ControlsBox();
                return _controlBox;
            }
            set
            {
                _controlBox = value;
                Invalidate();
            }
        }

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        protected override void OnMouseLeave(EventArgs e)
        {
            _isMinHovered = false;
            _isMaxHovered = false;
            _isCloseHovered = false;
            Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            _isMinHovered = false;
            _isMaxHovered = false;
            _isCloseHovered = false;
            Invalidate();
            base.OnLeave(e);
        }

        bool _isMinHovered, _isMaxHovered, _isCloseHovered = false;
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (ControlBox)
            {
                if (ControlBoxRect.Contains(e.Location))
                {
                    _isMinHovered = false;
                    _isMaxHovered = false;
                    _isCloseHovered = true; _closeStep = 255; _maxStep = 0; _minStep = 0;
                }
                else if (MaximizeBoxRect.Contains(e.Location))
                {
                    _isMinHovered = false;
                    _isMaxHovered = true;
                    _isCloseHovered = false; _closeStep = 0; _maxStep = 255; _minStep = 0;
                }
                else if (MinimizeBoxRect.Contains(e.Location))
                {
                    _isMinHovered = true;
                    _isMaxHovered = false;
                    _isCloseHovered = false; _closeStep = 0; _maxStep = 0; _minStep = 255;
                }
                else
                {
                    _isMinHovered = false;
                    _isMaxHovered = false;
                    _isCloseHovered = false; _closeStep = 0; _maxStep = 0; _minStep = 0;
                }
            }
            Invalidate();
            base.OnMouseMove(e);
        }


        public bool MaximizeFullScreen { get; set; } = false;

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Focus();
            if (e.Button == MouseButtons.Left)
            {
                if (MaximizeBox)
                    if (_isMaxHovered)
                    {
                        switch (WindowState)
                        {
                            case FormWindowState.Normal:
                                if (MaximizeFullScreen == true)
                                    MaximumSize = new Size(0, 0);
                                else MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
                                WindowState = FormWindowState.Maximized;
                                break;
                            case FormWindowState.Maximized:
                                WindowState = FormWindowState.Normal;
                                break;
                        }
                    }
                if (MinimizeBox)
                {
                    if (_isMinHovered)
                        WindowState = FormWindowState.Minimized;
                }
                if (_isCloseHovered) Close();
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Location.Y <= 37 && e.X < Width - 36 * 3)
            {
                ReleaseCapture();
                SendMessage(Handle, 0x112, 0xf012, 0);
            }
            Invalidate();
            base.OnMouseDown(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {

            if (WindowState == FormWindowState.Normal)
            {
                if (Size.Width <= 200)
                    Size = new Size(200, Height);
                if (Size.Height <= 40)
                    Size = new Size(Width, 40);

            }

            CalcSystemBoxPos(); Invalidate();
            base.OnSizeChanged(e);
        }

        protected override void OnResize(EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                if (Size.Width <= 200)
                    Size = new Size(200, Height);
                if (Size.Height <= 40)
                    Size = new Size(Width, 40);

            }
            AdjustForm();
            CalcSystemBoxPos(); Invalidate();
            base.OnResize(e);
        }



        const int resizeAreaSize = 10;
        const int HTCLIENT = 1; //Represents the client area of the window
        const int HTLEFT = 10;  //Left border of a window, allows resize horizontally to the left
        const int HTRIGHT = 11; //Right border of a window, allows resize horizontally to the right
        const int HTTOP = 12;   //Upper-horizontal border of a window, allows resize vertically up
        const int HTTOPLEFT = 13;//Upper-left corner of a window border, allows resize diagonally to the left
        const int HTTOPRIGHT = 14;//Upper-right corner of a window border, allows resize diagonally to the right
        const int HTBOTTOM = 15; //Lower-horizontal border of a window, allows resize vertically down
        const int HTBOTTOMLEFT = 16;//Lower-left corner of a window border, allows resize diagonally to the left
        const int HTBOTTOMRIGHT = 17;//Lower-right corner of a window border, allows resize diagonally to the right     
        int WS_MINIMIZEBOX = 0x00020000;

        [DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);

        [DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        [DllImport("dwmapi.dll")]
        public static extern int DwmIsCompositionEnabled(ref int pfEnabled);

        [System.Runtime.InteropServices.DllImport("User32.dll")]
        public static extern int GetSystemMetrics(int nIndex);

        public struct MARGINS
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }

        private const int WS_EX_DLGMODALFRAME = 0x00000001;
        private const int WS_EX_STATICEDGE = 0x00020000;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= WS_MINIMIZEBOX;
                cp.ClassStyle |= 0x8;   // CS_DBLCLKS
                //cp.Style = WS_SIZEBOX;
                //cp.Style &= ~WS_CAPTION;
                //cp.Style &= ~WS_THICKFRAME;
                //cp.Style &= ~WS_MINIMIZE;
                //cp.Style &= ~WS_MAXIMIZE;
                //cp.ExStyle &= ~WS_EX_DLGMODALFRAME;
                //cp.ExStyle &= ~WS_EX_STATICEDGE;
                return cp;
            }
        }

        const int WM_NCPAINT = 0x85;
        const int WM_NCCALCSIZE = 0x83;
        const int WM_NCHITTEST = 0x84;
        const int HTCAPTION = 0x2;
        const int WS_SIZEBOX = 0x40000;
        const int WS_CAPTION = 0x00C00000, WS_BORDE = 0x800000,
        WS_SYSMENU = 0x80000,
        WS_MAXIMIZEBOX = 0x10000,
        WS_THICKFRAME = 0x00040000,
        WS_MINIMIZE = 0x20000000,
        WS_MAXIMIZE = 0x1000000;



        protected override void WndProc(ref Message m)
        {
            //base.WndProc(ref m);

            switch (m.Msg)
            {

                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    if (Resizable && (int)m.Result == HTCLIENT && WindowState == FormWindowState.Normal)
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32()); //Gets screen point coordinates(X and Y coordinate of the pointer)                           
                        Point clientPoint = PointToClient(screenPoint); //Computes the location of the screen point into client coordinates                          
                        if (clientPoint.Y <= resizeAreaSize)//If the pointer is at the top of the form (within the resize area- X coordinate)
                        {
                            if (clientPoint.X <= resizeAreaSize) //If the pointer is at the coordinate X=0 or less than the resizing area(X=10) in 
                                m.Result = (IntPtr)HTTOPLEFT; //Resize diagonally to the left
                            else if (clientPoint.X < (Size.Width - resizeAreaSize))//If the pointer is at the coordinate X=11 or less than the width of the form(X=Form.Width-resizeArea)
                                m.Result = (IntPtr)HTTOP; //Resize vertically up
                            else //Resize diagonally to the right
                                m.Result = (IntPtr)HTTOPRIGHT;
                        }
                        else if (clientPoint.Y <= (Size.Height - resizeAreaSize)) //If the pointer is inside the form at the Y coordinate(discounting the resize area size)
                        {
                            if (clientPoint.X <= resizeAreaSize)//Resize horizontally to the left
                                m.Result = (IntPtr)HTLEFT;
                            else if (clientPoint.X > (Width - resizeAreaSize))//Resize horizontally to the right
                                m.Result = (IntPtr)HTRIGHT;
                        }
                        else
                        {
                            if (clientPoint.X <= resizeAreaSize)//Resize diagonally to the left
                                m.Result = (IntPtr)HTBOTTOMLEFT;
                            else if (clientPoint.X < (Size.Width - resizeAreaSize)) //Resize vertically down
                                m.Result = (IntPtr)HTBOTTOM;
                            else //Resize diagonally to the right
                                m.Result = (IntPtr)HTBOTTOMRIGHT;
                        }
                    }

                    return;
            }

            base.WndProc(ref m);
        }


        private void AdjustForm()
        {
            switch (WindowState)
            {
                case FormWindowState.Maximized: //Maximized form (After)
                    //this.Padding = new Padding(8, 8, 8, 0);
                    MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
                    break;
                case FormWindowState.Normal: //Restored form (After)
                    //if (this.Padding.Top != Border.Top)
                    //    this.Padding = Border;
                    break;
            }
        }




        private Padding _borderP = new Padding(1, 2, 1, 1);
        public Padding Border
        {
            get { return _borderP; }
            set
            {
                _borderP = value; Invalidate();
            }
        }

        protected override void OnLocationChanged(EventArgs e)
        {
            Invalidate();
            base.OnLocationChanged(e);
        }

        private System.Drawing.Text.TextRenderingHint texg = Helper.TextHelper.SetTextRender();
        public System.Drawing.Text.TextRenderingHint TextRendering
        {
            get { return texg; }
            set
            {
                texg = value; Invalidate();
            }
        }

        private Color _titleColor = Color.White;
        public Color TitleColor
        {
            get { return _titleColor; }
            set
            {
                _titleColor = value; Invalidate();
            }
        }

        int _shadowTitleHeight = 4;
        public int ShadowTitleHeight
        {
            get { return _shadowTitleHeight; }
            set
            {
                _shadowTitleHeight = value; Invalidate();
            }
        }

        Color _shadowTitleColor = Color.Black;
        public Color ShadowTitleColor
        {
            get { return _shadowTitleColor; }
            set
            {
                _shadowTitleColor = value; Invalidate();
            }
        }

        private Font titleFont = new Font("Arial", 12f);
        public Font TitleFont
        {
            get { return titleFont; }
            set
            {
                titleFont = value; Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets border color if window is deactivate.
        /// </summary>
        public Color DeactivateBorderColor { get; set; } = Color.Gray;
        /// <summary>
        /// Gets or sets control box icon color if window is deactivate.
        /// </summary>
        public Color DeactivateControlButtonIconColor { get; set; } = Color.Gray;
        bool DeAct = false;

        private Color titleColor = Color.DimGray;
        /// <summary>
        /// Gets or sets color for title text on window.
        /// </summary>
        public Color TitleTextColor
        {
            get { return titleColor; }
            set
            {
                titleColor = value; Invalidate();
            }
        }

        private bool showTitle = true;
        /// <summary>
        /// Show title text on window.
        /// </summary>
        public bool ShowTitleText
        {
            get { return showTitle; }
            set
            {
                showTitle = value; Invalidate();
            }
        }

        private Color borderColor = Global.PrimaryColors.BorderNormalColor1;
        /// <summary>
        /// Gets or sets border color of window.
        /// </summary>
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value; Invalidate();
            }
        }

        private RectangleF ControlBoxRect;
        private RectangleF MaximizeBoxRect;
        private RectangleF MinimizeBoxRect;
        float ControlBoxLeft = 0;

        private void CalcSystemBoxPos()
        {
            ControlBoxLeft = Width;
            if (ControlBox)
            {
                ControlBoxRect = new Rectangle(Width - 8 - 28, 37 / 2 - 14, 28, 28);//37 Is Title Height
                ControlBoxLeft = ControlBoxRect.Left - 2;
                if (MaximizeBox)
                {
                    MaximizeBoxRect = new RectangleF(ControlBoxRect.Left - 28 - 2, ControlBoxRect.Top, 28, 28);
                    ControlBoxLeft = MaximizeBoxRect.Left - 2;
                }
                else
                {
                    MaximizeBoxRect = new RectangleF(Width + 1, Height + 1, 1, 1);
                }
                if (MinimizeBox)
                {
                    MinimizeBoxRect = new RectangleF(MaximizeBox ? MaximizeBoxRect.Left - 28 - 2 : ControlBoxRect.Left - 28 - 2, ControlBoxRect.Top, 28, 28);
                    ControlBoxLeft = MinimizeBoxRect.Left - 2;
                }
                else MinimizeBoxRect = new RectangleF(Width + 1, Height + 1, 1, 1);

            }

            Invalidate();
        }

        public new bool MaximizeBox
        {
            get { return base.MaximizeBox; }
            set
            {
                base.MaximizeBox = value; Refresh();
            }
        }

        public new bool ControlBox
        {
            get { return base.ControlBox; }
            set
            {
                base.ControlBox = value; Refresh();
            }
        }

        public new bool MinimizeBox
        {
            get { return base.MinimizeBox; }
            set
            {
                base.MinimizeBox = value; Refresh();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            System.Drawing.Graphics g = e.Graphics;
            using (SolidBrush sb = new SolidBrush(DeAct ? DeactivateBorderColor : borderColor))
            {
                HeCopUI_Framework.Helper.GraphicsHelper.SetHightGraphics(g);
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.TextRenderingHint = texg;
                using (SolidBrush fillBrush = new SolidBrush(TitleColor))
                    g.FillRectangle(fillBrush, new RectangleF(0, 0, Width, 37));

                using (LinearGradientBrush gradientBrush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 37, Width, ShadowTitleHeight), Color.FromArgb(60, ShadowTitleColor), Color.Transparent, LinearGradientMode.Vertical))
                    g.FillRectangle(gradientBrush, 0, 37, Width, ShadowTitleHeight);

                if (Border.Top > 0)
                    g.DrawLine(new Pen(sb, Border.Top) { Alignment = PenAlignment.Inset }, new Point(0, 0), new Point(Width, 0));
                //Vẽ viền bên phải
                if (Border.Right > 0)
                    g.DrawLine(new Pen(sb, Border.Right) { Alignment = PenAlignment.Inset }, new Point(Width, 0), new Point(Width, Height));
                //Vẽ viền bên trái
                if (Border.Left > 0)
                    g.DrawLine(new Pen(sb, Border.Left) { Alignment = PenAlignment.Inset }, new Point(0, 0), new Point(0, Height));
                //Vẽ viền dưới
                if (Border.Bottom > 0)
                    g.DrawLine(new Pen(sb, Border.Bottom) { Alignment = PenAlignment.Inset }, new Point(0, Height), new Point(Width, Height));

                int iconsize = 18;
                if (ShowIcon == true) g.DrawIcon(Icon, new Rectangle(10, 37 / 2 - iconsize / 2, iconsize, iconsize));
                if (showTitle == true)
                {
                    using (SolidBrush brush = new SolidBrush(titleColor))
                        if (ShowIcon == false) g.DrawString(Text, titleFont, brush, new PointF(6, 37 / 2 - titleFont.Height / 2));
                        else g.DrawString(Text, titleFont, brush, new Point(15 + 14, (int)(38 / 2 - g.MeasureString(Text, titleFont).Height / 2)));

                }

                if (ControlBox == true)
                {
                    int sc = 12;
                    using (SolidBrush closeBrush = new SolidBrush(HeCopUI_Framework.Helper.DrawHelper.BlendColor(FormControlBox.CloseBoxColor, FormControlBox.CloseBoxHoverColor, _closeStep)))
                        g.FillPath(closeBrush, (FormControlBox.HoverColorShape == ShapeType.RoundedRectangle) ? HeCopUI_Framework.Helper.DrawHelper.GetRoundPath(ControlBoxRect, 5) : HeCopUI_Framework.Helper.DrawHelper.GetRoundPath(ControlBoxRect, sc));

                    if (MaximizeBox)
                        using (SolidBrush maximizeBrush = new SolidBrush(HeCopUI_Framework.Helper.DrawHelper.BlendColor(FormControlBox.MaximizeBoxColor, FormControlBox.MaximizeBoxHoverColor, _maxStep)))
                            g.FillPath(maximizeBrush, (FormControlBox.HoverColorShape == ShapeType.RoundedRectangle) ? HeCopUI_Framework.Helper.DrawHelper.GetRoundPath(MaximizeBoxRect, 5) : HeCopUI_Framework.Helper.DrawHelper.GetRoundPath(MaximizeBoxRect, sc));

                    if (MinimizeBox)
                        using (SolidBrush minimizeBrush = new SolidBrush(HeCopUI_Framework.Helper.DrawHelper.BlendColor(FormControlBox.MinimizeBoxColor, FormControlBox.MinimizeBoxHoverColor, _minStep)))
                            g.FillPath(minimizeBrush, (FormControlBox.HoverColorShape == ShapeType.RoundedRectangle) ? HeCopUI_Framework.Helper.DrawHelper.GetRoundPath(MinimizeBoxRect, 5) : HeCopUI_Framework.Helper.DrawHelper.GetRoundPath(MinimizeBoxRect, sc));

                    if (MaximizeBox == false)
                        using (SolidBrush minimizeBrush = new SolidBrush(HeCopUI_Framework.Helper.DrawHelper.BlendColor(FormControlBox.MinimizeBoxColor, FormControlBox.MinimizeBoxHoverColor, _minStep)))
                            g.FillPath(minimizeBrush, (FormControlBox.HoverColorShape == ShapeType.RoundedRectangle) ? HeCopUI_Framework.Helper.DrawHelper.GetRoundPath(MinimizeBoxRect, 5) : HeCopUI_Framework.Helper.DrawHelper.GetRoundPath(MinimizeBoxRect, sc));

                    #region CB
                    g.PixelOffsetMode = PixelOffsetMode.Default;
                    using (Pen closePen = new Pen(new SolidBrush(HeCopUI_Framework.Helper.DrawHelper.BlendColor(FormControlBox.IconCloseColor, FormControlBox.IconCloseHoverColor, _closeStep)), 1.5f))
                        DrawClose(g, closePen);

                    if (MaximizeBox == true)
                        using (Pen maximizePen = new Pen(new SolidBrush(HeCopUI_Framework.Helper.DrawHelper.BlendColor(FormControlBox.IconMaximizeColor, FormControlBox.IconMinimizeHoverColor, _maxStep)), 1.5f))
                            DrawMaximize_Restore(g, maximizePen);

                    //if (MaximizeBox == false)
                    using (Pen minimizePen = new Pen(new SolidBrush(HeCopUI_Framework.Helper.DrawHelper.BlendColor(FormControlBox.IconMinimizeColor, FormControlBox.IconMinimizeHoverColor, _minStep)), 1.5f))
                        DrawMinimize(g, minimizePen);

                    #endregion
                }
            }

        }

        #region DrawControlBox
        void DrawClose(Graphics g, System.Drawing.Pen pen)
        {
            g.DrawLine(pen, ControlBoxRect.Left + ControlBoxRect.Width / 2 - 6,
                    ControlBoxRect.Top + ControlBoxRect.Height / 2 - 6,
                    ControlBoxRect.Left + ControlBoxRect.Width / 2 + 5,
                    ControlBoxRect.Top + ControlBoxRect.Height / 2 + 5);
            g.DrawLine(pen, ControlBoxRect.Left + ControlBoxRect.Width / 2 - 6,
                    ControlBoxRect.Top + ControlBoxRect.Height / 2 + 5,
                    ControlBoxRect.Left + ControlBoxRect.Width / 2 + 5,
                    ControlBoxRect.Top + ControlBoxRect.Height / 2 - 6);
        }

        void DrawMaximize_Restore(Graphics g, System.Drawing.Pen pen)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                g.DrawRectangle(pen, MaximizeBoxRect.Left + MaximizeBoxRect.Width / 2 - 6,
                        MaximizeBoxRect.Top + MaximizeBoxRect.Height / 2 - 1,
                        7, 7);

                g.DrawLine(pen,
                          MaximizeBoxRect.Left + MaximizeBoxRect.Width / 2 - 2,
                          MaximizeBoxRect.Top + MaximizeBoxRect.Height / 2 - 1,
                          MaximizeBoxRect.Left + MaximizeBoxRect.Width / 2 - 2,
                          MaximizeBoxRect.Top + MaximizeBoxRect.Height / 2 - 4);

                g.DrawLine(pen,
                    MaximizeBoxRect.Left + MaximizeBoxRect.Width / 2 - 2,
                    MaximizeBoxRect.Top + MaximizeBoxRect.Height / 2 - 4,
                    MaximizeBoxRect.Left + MaximizeBoxRect.Width / 2 + 5,
                    MaximizeBoxRect.Top + MaximizeBoxRect.Height / 2 - 4);

                g.DrawLine(pen,
                    MaximizeBoxRect.Left + MaximizeBoxRect.Width / 2 + 5,
                    MaximizeBoxRect.Top + MaximizeBoxRect.Height / 2 - 4,
                    MaximizeBoxRect.Left + MaximizeBoxRect.Width / 2 + 5,
                    MaximizeBoxRect.Top + MaximizeBoxRect.Height / 2 + 3);

                g.DrawLine(pen,
                    MaximizeBoxRect.Left + MaximizeBoxRect.Width / 2 + 5,
                    MaximizeBoxRect.Top + MaximizeBoxRect.Height / 2 + 3,
                    MaximizeBoxRect.Left + MaximizeBoxRect.Width / 2 + 2,
                    MaximizeBoxRect.Top + MaximizeBoxRect.Height / 2 + 3);

            }
            else
            {
                g.DrawRectangle(pen, MaximizeBoxRect.Left + MaximizeBoxRect.Width / 2 - 6,
                       MaximizeBoxRect.Top + MaximizeBoxRect.Height / 2 - 5, 10, 10);
            }
        }

        void DrawMinimize(Graphics g, System.Drawing.Pen pen)
        {
            g.DrawLine(pen, MinimizeBoxRect.Left + MinimizeBoxRect.Width / 2 - 6,
                  MinimizeBoxRect.Top + MinimizeBoxRect.Height / 2,
                  MinimizeBoxRect.Left + MinimizeBoxRect.Width / 2 + 5,
                  MinimizeBoxRect.Top + MinimizeBoxRect.Height / 2);

        }
        #endregion

        public bool Resizable { get; set; } = true;
    }

    #region object properties
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class ControlsBox
    {
        ShapeType sd = ShapeType.RoundedRectangle;
        public ShapeType HoverColorShape
        {
            get { return sd; }
            set
            {
                sd = value;
            }
        }

        public Color IconMaximizeColor
        {
            get; set;
        } = Color.FromArgb(80, 80, 80);

        public Color IconMaximizeHoverColor
        {
            get; set;
        } = Color.FromArgb(60, 60, 60);

        public Color IconMinimizeColor
        {
            get; set;
        } = Color.FromArgb(80, 80, 80);

        public Color IconMinimizeHoverColor
        {
            get; set;
        } = Color.FromArgb(60, 60, 60);

        public Color IconCloseColor
        {
            get; set;
        } = Color.FromArgb(80, 80, 80);

        public Color IconCloseHoverColor
        {
            get; set;
        } = Color.WhiteSmoke;

        public Color MaximizeBoxColor
        {
            get; set;
        } = Color.White;

        public Color MinimizeBoxColor
        {
            get; set;
        } = Color.White;

        public Color CloseBoxColor
        {
            get; set;
        } = Color.White;

        public Color MaximizeBoxHoverColor
        {
            get; set;
        } = Color.FromArgb(230, 230, 230);

        public Color MinimizeBoxHoverColor
        {
            get; set;
        } = Color.FromArgb(230, 230, 230);

        public Color CloseBoxHoverColor
        {
            get; set;
        } = Color.Red;

    }
    #endregion
}
