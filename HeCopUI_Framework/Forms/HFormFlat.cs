using HeCopUI_Framework.Enums;
using HeCopUI_Framework.Win32.Enums;
using HeCopUI_Framework.Win32.Struct;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Forms;
using Point = System.Drawing.Point;
using Size = System.Drawing.Size;

namespace HeCopUI_Framework.Forms
{
    public class HFormFlat : Form
    {
        private Color headerColor1 = Color.FromArgb(70, 70, 70);
        private Color headerColor2 = Color.FromArgb(50, 50, 50);
        private Color closeColor = Color.FromArgb(241, 53, 53);
        private Color minimizeColor = Color.Green;
        private Color maximizeColor = Color.CornflowerBlue;
        private Color borderColor1 = Global.PrimaryColors.ProgressBarColor2;
        private Color borderColor2 = Global.PrimaryColors.ProgressBarColor2;

        /// <summary>
        /// The background color for the form's header.
        /// </summary>
        [Description("The background color 1 for the form's header.")]
        public Color HeaderColor1
        {
            get { return headerColor1; }
            set { headerColor1 = value; Invalidate(); }
        }

        /// <summary>
        /// The background color for the form's header.
        /// </summary>
        [Description("The background color 2 for the form's header.")]
        public Color HeaderColor2
        {
            get { return headerColor2; }
            set { headerColor2 = value; Invalidate(); }
        }

        /// <summary>
        /// The foreground color for the form's close button.
        /// </summary>
        [Description("The foreground color for the form's close button.")]
        public Color CloseColor
        {
            get { return closeColor; }
            set { closeColor = value; Invalidate(); }
        }

        /// <summary>
        /// The foreground color for the form's minimize button.
        /// </summary>
        [Description("The foreground color for the form's minimize button.")]
        public Color MinimizeColor
        {
            get { return minimizeColor; }
            set { minimizeColor = value; Invalidate(); }
        }

        /// <summary>
        /// The foreground color for the form's maximize button.
        /// </summary>
        [Description("The foreground color for the form's maximize button.")]
        public Color MaximizeColor
        {
            get { return maximizeColor; }
            set { maximizeColor = value; Invalidate(); }
        }

        /// <summary>
        /// The background color for the form's border.
        /// </summary>
        [Description("The background color 1 for the form's border.")]
        public Color BorderColor1
        {
            get { return borderColor1; }
            set { borderColor1 = value; Invalidate(); }
        }

        /// <summary>
        /// The background color for the form's border.
        /// </summary>
        [Description("The background color 1 for the form's border.")]
        public Color BorderColor2
        {
            get { return borderColor2; }
            set { borderColor2 = value; Invalidate(); }
        }


        private Rectangle close, minimize, maximize, titleBounds;

        int headerHeight = 35;

        /// <summary>
        /// Gets or sets the height of the form's header.
        /// </summary>
        public int TitleBarHeight
        {
            get { return headerHeight; }
            set
            {
                headerHeight = value;
                Invalidate();
            }
        }

        Point mouseClient
        {
            get
            {
                return PointToClient(MousePosition);
            }
        }

        bool hoveredMinimize
        {
            get
            {
                return minimize.Contains(mouseClient.X, mouseClient.Y * (mouseClient.Y < 0 ? -1 : 1));
            }
        }

        bool hoveredMaximize
        {
            get
            {
                return maximize.Contains(mouseClient.X, mouseClient.Y * (mouseClient.Y < 0 ? -1 : 1));
            }
        }

        bool hoveredClose
        {
            get
            {
                return close.Contains(mouseClient.X, mouseClient.Y * (mouseClient.Y < 0 ? -1 : 1));
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            Invalidate();
            base.OnTextChanged(e);
        }



        int controlBoxSize = 26;

        /// <summary>
        /// Gets or sets the size of the control box icons.
        /// </summary>
        public int ControlBoxSize
        {
            get { return controlBoxSize; }
            set
            {
                controlBoxSize = value;
                Invalidate();
            }
        }

        Font titleFont = new Font("Segoe UI", 10.0f);
        /// <summary>
        /// Gets or sets the font of the form's title.
        /// </summary>
        public Font TitleFont
        {
            get { return titleFont; }
            set
            {
                titleFont = value; Invalidate();
            }

        }

        Color titleColor = Color.FromArgb(200, 200, 200);
        /// <summary>
        /// Gets or sets the color of the form's title.
        /// </summary>
        public Color TitleForeColor
        {
            get { return titleColor; }
            set
            {
                titleColor = value; Invalidate();
            }
        }

        LinearGradientMode titleLinearGradientMode = LinearGradientMode.Horizontal;

        /// <summary>
        /// Gets or sets the linear gradient mode of the form's title.
        /// </summary>
        public LinearGradientMode TitleLinearGradientMode
        {
            get { return titleLinearGradientMode; }
            set
            {
                titleLinearGradientMode = value; Invalidate();
            }
        }

        LinearGradientMode borderLinear = LinearGradientMode.Vertical;

        /// <summary>
        /// Gets or sets the linear gradient mode of the form's border.
        /// </summary>
        /// <param name="e"></param>
        public LinearGradientMode BorderLinearGradientMode
        {
            get { return borderLinear; }
            set
            {
                borderLinear = value; Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            close = new Rectangle(Width - borderPadding.Horizontal - controlBoxSize, TitleBarHeight / 2 - controlBoxSize / 2, controlBoxSize, controlBoxSize);
            maximize = new Rectangle(close.X - controlBoxSize, TitleBarHeight / 2 - controlBoxSize / 2, controlBoxSize, controlBoxSize);

            switch (MaximizeBox)
            {
                case true:
                    minimize = new Rectangle(maximize.X - controlBoxSize, TitleBarHeight / 2 - controlBoxSize / 2, controlBoxSize, controlBoxSize);
                    break;
                case false:
                    minimize = new Rectangle(close.X - controlBoxSize, TitleBarHeight / 2 - controlBoxSize / 2, controlBoxSize, controlBoxSize);
                    break;
            }

            titleBounds = new Rectangle(borderPadding.Left, borderPadding.Top, Width - borderPadding.Horizontal, headerHeight);

            // Draw the header
            if (FormBorderStyle != FormBorderStyle.None)
            {
                using (var brush = new LinearGradientBrush(new Rectangle(0, 0, Width, TitleBarHeight), headerColor1, headerColor2, borderLinear))
                {
                    e.Graphics.FillRectangle(brush, new Rectangle(0, 0, Width, TitleBarHeight));
                    // Draw icon
                    e.Graphics.DrawImage(Icon.ToBitmap(), 5, TitleBarHeight / 2 - IconSize.Height / 2, iconSize.Width, iconSize.Height);
                    // Draw title
                    StringFormat sf = new StringFormat
                    {
                        LineAlignment = StringAlignment.Center,
                        Trimming = StringTrimming.EllipsisCharacter
                    };
                    switch (textAlignment)
                    {
                        case TextAlignment.Left:
                            sf.Alignment = StringAlignment.Near;
                            break;
                        case TextAlignment.Center:
                            sf.Alignment = StringAlignment.Center;
                            break;
                        case TextAlignment.Right:
                            sf.Alignment = StringAlignment.Far;
                            break;
                    }
                    e.Graphics.DrawString(Text, titleFont, new SolidBrush(titleColor), new RectangleF(IconSize.Width + 10, 0, Width, TitleBarHeight), sf);
                }

                // Fill control boxes
                if (!DesignMode)
                {
                    using (var alphaBrush = new SolidBrush(Color.FromArgb(30, Color.White)))
                    {
                        if (hoveredClose)
                        {
                            e.Graphics.FillRectangle(alphaBrush, close);
                        }
                        if (hoveredMaximize)
                        {
                            e.Graphics.FillRectangle(alphaBrush, maximize);
                        }
                        if (hoveredMinimize)
                        {
                            e.Graphics.FillRectangle(alphaBrush, minimize);
                        }
                    }
                }

                int iconControSize = controlBoxSize * 65 / 100;

                // Draw the control boxes
                using (var closeBrush = new SolidBrush(closeColor))
                using (var closePen = new Pen(closeBrush, 1))
                {
                    DrawClose(e.Graphics, closePen, controlBoxSize - iconControSize);
                }

                if (MinimizeBox)
                {
                    using (var minimizeBrush = new SolidBrush(minimizeColor))
                    using (var minimizePen = new Pen(minimizeBrush, 1))
                    {
                        DrawMinimize(e.Graphics, minimizePen, controlBoxSize - iconControSize);
                    }
                }

                if (MaximizeBox)
                {
                    using (var maximizeBrush = new SolidBrush(maximizeColor))
                    using (var maximizePen = new Pen(maximizeBrush, 1))
                    {
                        DrawMaximize_Restore(e.Graphics, maximizePen, controlBoxSize - iconControSize);
                    }
                }
            }






            if (BorderPadding.All > 0)
            {
                // Draw the border
                using (var lineBrush = new LinearGradientBrush(ClientRectangle, borderColor1, borderColor2, borderLinear))
                {
                    int borderSizeMax = Math.Max(borderPadding.Left, Math.Max(borderPadding.Top, Math.Max(borderPadding.Right, borderPadding.Bottom)));

                    // Draw the border as a rectangle
                    using (Pen pen = new Pen(lineBrush, borderSizeMax))
                    {
                        // Calculate position and size to ensure negative values are respected
                        RectangleF adjustBorder = new RectangleF(1 + borderPadding.Left - borderSizeMax, 1 + borderPadding.Top - borderSizeMax,
                            Width - 1 - (borderPadding.Right - borderSizeMax), Height - 1 - (borderPadding.Bottom - borderSizeMax));

                        e.Graphics.DrawRectangle(pen, adjustBorder.Left, adjustBorder.Top, adjustBorder.Right - adjustBorder.Left, adjustBorder.Bottom - adjustBorder.Top);
                    }
                }
            }

        }



        void DrawClose(Graphics g, System.Drawing.Pen pen, int size)
        {
            float halfSize = size / 2;
            g.DrawLine(pen, (float)close.X + close.Width / 2 - halfSize,
                    close.Y + close.Height / 2 - halfSize,
                    close.X + close.Width / 2 + halfSize,
                    close.Y + close.Height / 2 + halfSize);
            g.DrawLine(pen, (float)close.X + close.Width / 2 - halfSize,
                    close.Y + close.Height / 2 + halfSize,
                    close.X + close.Width / 2 + halfSize,
                    close.Y + close.Height / 2 - halfSize);
        }

        void DrawMaximize_Restore(Graphics g, System.Drawing.Pen pen, int size)
        {
            float halfSize = size / 2;

            if (WindowState == FormWindowState.Maximized)
            {
                // Vẽ biểu tượng "Restore"
                g.DrawRectangle(pen, (int)(maximize.X + maximize.Width / 2 - halfSize),
                    (int)(maximize.Y + maximize.Height / 2 - halfSize + 3), size - 4, size - 4);

                //g.DrawRectangle(pen, (float)maximize.X + maximize.Width / 2 - halfSize + 3,
                //    maximize.Y + maximize.Height / 2 - halfSize, size - 4, size - 4);

                g.DrawLine(pen, maximize.X + maximize.Width / 2 - 1, (int)(maximize.Y + maximize.Height / 2 - halfSize - pen.Width),
                    maximize.X + maximize.Width / 2 - 1, maximize.Y + maximize.Height / 2 - halfSize + 3);

                g.DrawLine(pen, maximize.X + maximize.Width / 2 - 1, maximize.Y + maximize.Height / 2 - halfSize - pen.Width,
                   maximize.X + maximize.Width / 2 + halfSize + 2, maximize.Y + maximize.Height / 2 - halfSize - pen.Width);

                g.DrawLine(pen, maximize.X + maximize.Width / 2 + halfSize + 2, maximize.Y + maximize.Height / 2 - halfSize - pen.Width,
                    maximize.X + maximize.Width / 2 + halfSize + 2, maximize.Y + maximize.Height / 2 + halfSize - 3);



            }
            else if (WindowState == FormWindowState.Minimized || WindowState == FormWindowState.Normal)
            {
                g.DrawRectangle(pen, (int)(maximize.X + maximize.Width / 2 - halfSize),
                       (int)(maximize.Y + maximize.Height / 2 - halfSize), size, size);
            }
        }

        void DrawMinimize(Graphics g, System.Drawing.Pen pen, int size)
        {
            g.DrawLine(pen, (float)minimize.X + minimize.Width / 2 - size / 2,
                  minimize.Y + minimize.Height / 2,
                  minimize.X + minimize.Width / 2 + size / 2,
                  minimize.Y + minimize.Height / 2);
        }




        Padding borderPadding = new Padding(1, 2, 1, 1);
        /// <summary>
        /// Gets or sets the padding of the form's border.
        /// </summary>
        public Padding BorderPadding
        {
            get { return borderPadding; }
            set
            {
                borderPadding = value;
                Invalidate();
            }
        }

        TextAlignment textAlignment = TextAlignment.Left;
        /// <summary>
        /// Gets or sets the text alignment of the form's title.
        /// </summary>
        public TextAlignment TitleTextAlignment
        {
            get { return textAlignment; }
            set
            {
                textAlignment = value; Invalidate();
            }
        }

        Size iconSize = new Size(20, 20);
        /// <summary>
        /// Gets or sets the size of the icon.
        /// </summary>
        public Size IconSize
        {
            get { return iconSize; }
            set
            {
                iconSize = value;
                Invalidate();
            }
        }



        public HFormFlat()
        {
            SetStyle(
               ControlStyles.OptimizedDoubleBuffer |
               ControlStyles.ResizeRedraw |
               ControlStyles.UserPaint |
               ControlStyles.AllPaintingInWmPaint, true);

            base.FormBorderStyle = FormBorderStyle.None;

            BackColor = Color.FromArgb(25, 25, 25);
            ForeColor = Color.FromArgb(200, 200, 200);

            _hitTests = new[] {
                new[] {
                    HitTests.HTTOPLEFT, HitTests.HTTOP, HitTests.HTTOPRIGHT
                },
                new[] {
                    HitTests.HTLEFT, HitTests.HTCLIENT,HitTests.HTRIGHT
                },
                new[] {
                    HitTests.HTBOTTOMLEFT, HitTests.HTBOTTOM, HitTests.HTBOTTOMRIGHT
                },
            };


        }

        FormBorderStyle formBorderStyle = FormBorderStyle.Sizable;
        /// <summary>
        /// Gets or sets the form border style.
        /// </summary>
        public new FormBorderStyle FormBorderStyle
        {
            get { return formBorderStyle; }
            set
            {
                formBorderStyle = value;
                Invalidate();
            }
        }

        public bool IsPopup { get; set; } = false;
        public bool DontShowInAltTab { get; set; } = false;

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;

                if (DesignMode)
                    return cp;

                if (IsPopup)
                {
                    cp.Style = (int)(HeCopUI_Framework.Win32.Enums.WindowStyles.WS_POPUP
                        | HeCopUI_Framework.Win32.Enums.WindowStyles.WS_CLIPCHILDREN // allows to not send paint requests to children when this form is invalidated
                        | HeCopUI_Framework.Win32.Enums.WindowStyles.WS_CLIPSIBLINGS);
                    // i don't control the exstyle because i can't get it right and it throws an incorrect param
                    // exception no matter what i put here
                    cp.ExStyle = cp.ExStyle | (int)(HeCopUI_Framework.Win32.Enums.WindowStyles.WS_EX_OVERLAPPEDWINDOW);
                }
                else
                {
                    // below is what makes the windows borderless but resizable
                    cp.Style = (int)(HeCopUI_Framework.Win32.Enums.WindowStyles.WS_CAPTION // enables aero minimize animation/transition
                        | HeCopUI_Framework.Win32.Enums.WindowStyles.WS_CLIPCHILDREN
                        | HeCopUI_Framework.Win32.Enums.WindowStyles.WS_CLIPSIBLINGS
                        | HeCopUI_Framework.Win32.Enums.WindowStyles.WS_OVERLAPPED
                        | HeCopUI_Framework.Win32.Enums.WindowStyles.WS_SYSMENU // enables the context menu with the move, close, maximize, minize... commands (shift + right-click on the task bar item)
                        | HeCopUI_Framework.Win32.Enums.WindowStyles.WS_MINIMIZEBOX // need to be able to minimize from taskbar
                        | HeCopUI_Framework.Win32.Enums.WindowStyles.WS_MAXIMIZEBOX // same for maximize
                        | HeCopUI_Framework.Win32.Enums.WindowStyles.WS_THICKFRAME); // without this the window cannot be resized and so aero snap, de-maximizing and minimizing won't work

                    cp.ExStyle = (int)(HeCopUI_Framework.Win32.Enums.WindowStyles.WS_EX_COMPOSITED
                        | HeCopUI_Framework.Win32.Enums.WindowStyles.WS_EX_LEFT
                        | HeCopUI_Framework.Win32.Enums.WindowStyles.WS_EX_LTRREADING
                        | HeCopUI_Framework.Win32.Enums.WindowStyles.WS_EX_APPWINDOW
                        | HeCopUI_Framework.Win32.Enums.WindowStyles.WS_EX_WINDOWEDGE
                        | HeCopUI_Framework.Win32.Enums.WindowStyles.WS_EX_OVERLAPPEDWINDOW
                        | HeCopUI_Framework.Win32.Enums.WindowStyles.WS_EX_CONTROLPARENT);
                }

                if (DontShowInAltTab)
                {
                    cp.ExStyle = cp.ExStyle | (int)HeCopUI_Framework.Win32.Enums.WindowStyles.WS_EX_TOOLWINDOW;
                }

                //if (AlwaysOnTop)
                //{
                //    cp.ExStyle = cp.ExStyle | (int)WinApi.WindowStylesEx.WS_EX_TOPMOST;
                //}

                //if (Unselectable)
                //{
                //    cp.ExStyle = cp.ExStyle | (int)WinApi.WindowStylesEx.WS_EX_TRANSPARENT;
                //    cp.ExStyle = cp.ExStyle | (int)WinApi.WindowStylesEx.WS_EX_NOACTIVATE;
                //    cp.Style = cp.Style | (int)WinApi.WindowStyles.WS_DISABLED;
                //}

                cp.ClassStyle = 0;

                return cp;
            }
        }




        protected override void WndProc(ref Message m)
        {
            if (DesignMode)
            {
                base.WndProc(ref m);
                return;
            }

            switch ((HeCopUI_Framework.Win32.Enums.WindowMessages)m.Msg)
            {
                case HeCopUI_Framework.Win32.Enums.WindowMessages.WM_NCMOUSEMOVE:
                    if (!mouseInTitleBar && (hoveredClose || hoveredMaximize || hoveredMinimize))
                    {
                        Cursor = Cursors.Hand;
                        Refresh();
                    }
                    else
                    {
                        Cursor = Cursors.Default;
                        Refresh();
                    }

                    return;

                case WindowMessages.WM_NCLBUTTONDOWN:
                    if (hoveredClose)
                    {
                        Close();
                    }
                    else if (hoveredMaximize)
                    {
                        if (WindowState == FormWindowState.Maximized)
                            WindowState = FormWindowState.Normal;
                        else
                            WindowState = FormWindowState.Maximized;
                    }
                    else if (hoveredMinimize)
                    {
                        WindowState = FormWindowState.Minimized;
                    }
                    break;



                case HeCopUI_Framework.Win32.Enums.WindowMessages.WM_NCRBUTTONDOWN:
                    if (mouseInTitleBar)
                    {
                        IntPtr hMenu = HeCopUI_Framework.Win32.User32.GetSystemMenu(Handle, false);
                        HeCopUI_Framework.Win32.User32.TrackPopupMenu(hMenu, (int)HeCopUI_Framework.Win32.Enums.TrackPopupMenuFlags.TPM_RETURNCMD,
                            MousePosition.X, MousePosition.Y, 0, m.HWnd, IntPtr.Zero);
                    }
                    break;

                case HeCopUI_Framework.Win32.Enums.WindowMessages.WM_SYSCOMMAND:
                    switch ((HeCopUI_Framework.Win32.Enums.SystemCommands)m.WParam)
                    {
                        // prevent the window from moving
                        case HeCopUI_Framework.Win32.Enums.SystemCommands.SC_MOVE:
                            if (!mouseInTitleBar)
                                return;
                            break;

                        case HeCopUI_Framework.Win32.Enums.SystemCommands.SC_CLOSE:

                            Close();
                            break;
                        case HeCopUI_Framework.Win32.Enums.SystemCommands.SC_MINIMIZE:

                            WindowState = FormWindowState.Minimized;
                            break;
                        case HeCopUI_Framework.Win32.Enums.SystemCommands.SC_MAXIMIZE:

                            WindowState = FormWindowState.Maximized;
                            break;
                        case HeCopUI_Framework.Win32.Enums.SystemCommands.SC_RESTORE:

                            WindowState = FormWindowState.Normal;
                            break;
                    }

                    break;

                case HeCopUI_Framework.Win32.Enums.WindowMessages.WM_NCHITTEST:
                    // here we return on which part of the window the cursor currently is :
                    // this allows to resize the windows when grabbing edges
                    // and allows to move/double click to maximize the window if the cursor is on the caption (title) bar
                    var ht = HitTestNca(m.LParam);
                    if (!mouseInTitleBar && ht == HitTests.HTCAPTION)
                    {
                        ht = HeCopUI_Framework.Win32.Enums.HitTests.HTNOWHERE;
                    }
                    if (FormBorderStyle != FormBorderStyle.Sizable && (int)ht >= (int)HeCopUI_Framework.Win32.Enums.HitTests.HTRESIZESTARTNUMBER && (int)ht <= (int)HeCopUI_Framework.Win32.Enums.HitTests.HTRESIZEENDNUMBER)
                    {
                        ht = HeCopUI_Framework.Win32.Enums.HitTests.HTNOWHERE;
                    }

                    HeCopUI_Framework.Win32.User32.RedrawWindow(new HandleRef(this, Handle).Handle, IntPtr.Zero, IntPtr.Zero, (uint)HeCopUI_Framework.Win32.Enums.RedrawWindowFlags.RDW_INVALIDATE);

                    m.Result = (IntPtr)ht;
                    return;

                //case HeCopUI_Framework.Win32.Enums.WindowMessages.WM_WINDOWPOSCHANGING:
                //    //https://msdn.microsoft.com/fr-fr/library/windows/desktop/ms632653(v=vs.85).aspx?f=255&MSPPError=-2147217396
                //    //https://blogs.msdn.microsoft.com/oldnewthing/20080116-00/?p=23803
                //    //    The WM_WINDOWPOSCHANGING message is sent early in the window state changing process, unlike WM_WINDOWPOSCHANGED,
                //    //    which tells you about what already happened
                //    // A crucial difference(aside from the timing) is that you can influence the state change by handling
                //    // the WM_WINDOWPOSCHANGING message and modifying the WINDOWPOS structure
                //    var windowpos = (HeCopUI_Framework.Win32.Struct.WINDOWPOS)Marshal.PtrToStructure(m.LParam, typeof(HeCopUI_Framework.Win32.Struct.WINDOWPOS));
                //    break;

                case HeCopUI_Framework.Win32.Enums.WindowMessages.WM_ENTERSIZEMOVE:
                    // Useful if your window contents are dependent on window size but expensive to compute, as they give you a way to defer paints until the end of the resize action. We found WM_WINDOWPOSCHANGING/ED wasn’t reliable for that purpose.

                    break;

                case HeCopUI_Framework.Win32.Enums.WindowMessages.WM_EXITSIZEMOVE:
                    //if (Resizing)
                    //{
                    //    // restore caption style
                    //CreateParams.Style |= (int)WindowStyles.WS_CAPTION;
                    //}
                    //Resizing = false;
                    //Moving = false;

                    break;

                case HeCopUI_Framework.Win32.Enums.WindowMessages.WM_SIZING:
                    //if (!Resizing)
                    //{
                    //    // disable caption style to avoid seeing it when resizing 
                    //CreateParams.Style &= ~(int)WindowStyles.WS_CAPTION;
                    //}
                    //Resizing = true;

                    break;


                //case Window.Msg.WM_MOVING:
                //    Moving = true;
                //    break;

                case HeCopUI_Framework.Win32.Enums.WindowMessages.WM_MBUTTONDOWN:
                    //var state = (WinApi.WmSizeEnum) m.WParam;
                    //if (state == WinApi.WmSizeEnum.SIZE_MAXIMIZED || state == WinApi.WmSizeEnum.SIZE_MAXSHOW) {
                    // Refresh();
                    //}
                    // var wid = m.LParam.LoWord();
                    // var h = m.LParam.HiWord();
                    break;

                case HeCopUI_Framework.Win32.Enums.WindowMessages.WM_SIZE:
                    var state = (HeCopUI_Framework.Win32.Enums.WmSizeEnum)m.WParam;
                    if (state == HeCopUI_Framework.Win32.Enums.WmSizeEnum.SIZE_MAXIMIZED || state == HeCopUI_Framework.Win32.Enums.WmSizeEnum.SIZE_MAXSHOW || state == HeCopUI_Framework.Win32.Enums.WmSizeEnum.SIZE_RESTORED)
                    {
                        _needRedraw = true;
                    }
                    // var wid = m.LParam.LoWord();
                    // var h = m.LParam.HiWord();

                    break;

                case HeCopUI_Framework.Win32.Enums.WindowMessages.WM_NCPAINT:
                    //Return Zero
                    m.Result = IntPtr.Zero;
                    break;

                case HeCopUI_Framework.Win32.Enums.WindowMessages.WM_GETMINMAXINFO:
                    // allows the window to be maximized at the size of the working area instead of the whole screen size
                    OnGetMinMaxInfo(ref m);
                    //Return Zero
                    m.Result = IntPtr.Zero;
                    return;

                case HeCopUI_Framework.Win32.Enums.WindowMessages.WM_NCCALCSIZE:
                    // we respond to this message to say we do not want a non client area
                    if (OnNcCalcSize(ref m))
                        return;

                    break;

                case HeCopUI_Framework.Win32.Enums.WindowMessages.WM_ACTIVATEAPP:
                    //IsActive = (int)m.WParam != 0;
                    break;

                case HeCopUI_Framework.Win32.Enums.WindowMessages.WM_ACTIVATE:
                    //IsActive = ((int)WinApi.WAFlags.WA_ACTIVE == (int)m.WParam || (int)WinApi.WAFlags.WA_CLICKACTIVE == (int)m.WParam);

                    break;

                case HeCopUI_Framework.Win32.Enums.WindowMessages.WM_NCACTIVATE:
                    /* Prevent Windows from drawing the default title bar by temporarily
                        toggling the WS_VISIBLE style. This is recommended in:
                        https://blogs.msdn.microsoft.com/wpfsdk/2008/09/08/custom-window-chrome-in-wpf/ */
                    //var oldStyle = WindowStyle;
                    //WindowStyle = oldStyle & ~HeCopUI_Framework.Win32.Enums.WindowStyles.WS_VISIBLE;
                    DefWndProc(ref m);
                    //WindowStyle = oldStyle;

                    return;

                case HeCopUI_Framework.Win32.Enums.WindowMessages.WM_WINDOWPOSCHANGED:
                    // the default From handler for this message messes up the restored height/width for non client area window
                    // var newwindowpos = (WinApi.WINDOWPOS) Marshal.PtrToStructure(m.LParam, typeof(WinApi.WINDOWPOS));
                    DefWndProc(ref m);
                    UpdateBounds();

                    m.Result = IntPtr.Zero;
                    return;

                case HeCopUI_Framework.Win32.Enums.WindowMessages.WM_ERASEBKGND:
                    // https://msdn.microsoft.com/en-us/library/windows/desktop/ms648055(v=vs.85).aspx
                    m.Result = IntPtr.Zero;
                    if (_needRedraw)
                    {
                        _needRedraw = false;
                        HeCopUI_Framework.Win32.User32.RedrawWindow(new HandleRef(this, Handle).Handle, IntPtr.Zero, IntPtr.Zero, (uint)HeCopUI_Framework.Win32.Enums.RedrawWindowFlags.RDW_INVALIDATE);
                    }
                    return;

                case HeCopUI_Framework.Win32.Enums.WindowMessages.WM_NCUAHDRAWCAPTION:
                case HeCopUI_Framework.Win32.Enums.WindowMessages.WM_NCUAHDRAWFRAME:
                    /* These undocumented messages are sent to draw themed window borders
                       Block them to prevent drawing borders over the client area */


                    m.Result = IntPtr.Zero;
                    return;



            }

            base.WndProc(ref m);
        }



        bool mouseInTitleBar
        {
            get
            {
                return titleBounds.Contains(PointToClient(MousePosition));
            }
        }

        Padding _nonClientAreaPadding = new Padding(2);
        /// <summary>
        /// Gets or sets the padding of the non client area.
        /// </summary>
        public Padding NonClientAreaPadding
        {
            get { return _nonClientAreaPadding; }
            set { _nonClientAreaPadding = value; Invalidate(); }
        }


        protected virtual HitTests HitTestNca(IntPtr lparam)
        {
            var cursorLocation = PointToClient(new Point(lparam.ToInt32()));

            bool resizeBorder = false;
            int uRow = 1;
            int uCol = 1;

            // Determine if the point is at the top or bottom of the window
            if (cursorLocation.Y >= 0 && cursorLocation.Y <= TitleBarHeight)
            {
                resizeBorder = cursorLocation.Y <= NonClientAreaPadding.Top && WindowState != FormWindowState.Maximized;
                uRow = 0;
            }
            else if (cursorLocation.Y <= Height && cursorLocation.Y >= Height - NonClientAreaPadding.Bottom)
            {
                uRow = 2;
            }

            // Determine if the point is at the left or right of the window
            if (cursorLocation.X >= 0 && cursorLocation.X <= NonClientAreaPadding.Left)
            {
                uCol = 0;
            }
            else if (cursorLocation.X <= Width && cursorLocation.X >= Width - NonClientAreaPadding.Right)
            {
                uCol = 2;
            }
            else if (uRow == 0 && !resizeBorder)
            {
                return HitTests.HTCAPTION;
            }

            return _hitTests[uRow][uCol];

        }

        HitTests[][] _hitTests;

        private bool OnNcCalcSize(ref Message m)
        {
            // by default, the proposed rect is already equals to the window size (=no NC area) so we just respond 0
            // however, in a default windows, the non client border of the window "hangs" outside the screen
            // since we don't have this non client border we don't want the window to go outside the screen...
            // we handle it here

            if (m.WParam != IntPtr.Zero)
            {
                // When TRUE, LPARAM Points to a NCCALCSIZE_PARAMS structure
                var nccsp = (NCCALCSIZE_PARAMS)Marshal.PtrToStructure(m.LParam, typeof(NCCALCSIZE_PARAMS));
                if (OnNcCalcSize_ModifyProposedRectangle(ref nccsp.rcClient))
                {
                    Marshal.StructureToPtr(nccsp, m.LParam, true);
                }
            }
            else
            {
                // When FALSE, LPARAM Points to a RECT structure
                var clnRect = (RECT)Marshal.PtrToStructure(m.LParam, typeof(RECT));
                if (OnNcCalcSize_ModifyProposedRectangle(ref clnRect))
                {
                    Marshal.StructureToPtr(clnRect, m.LParam, true);
                }
            }

            //Return Zero (we can return flags, see the manual)
            m.Result = IntPtr.Zero;
            return true;
        }

        private bool OnNcCalcSize_ModifyProposedRectangle(ref RECT rect)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                var s = Screen.FromHandle(Handle);
                // the proposed rect is the maximized position/size that window suggest using the "out of screen" borders
                // we change that here
                rect.Set(s.WorkingArea);
                return true;
            }
            return false;
        }

        private void OnGetMinMaxInfo(ref Message m, int offSet = 0)
        {
            _lastMinMaxInfo = (MINMAXINFO)Marshal.PtrToStructure(m.LParam, typeof(MINMAXINFO));
            var s = Screen.FromHandle(Handle);
            _lastMinMaxInfo.maxPosition.X = Math.Abs(s.WorkingArea.Left - s.Bounds.Left) + offSet;
            _lastMinMaxInfo.maxPosition.Y = Math.Abs(s.WorkingArea.Top - s.Bounds.Top) + offSet;
            _lastMinMaxInfo.maxSize.Width = s.WorkingArea.Width - offSet * 2;
            _lastMinMaxInfo.maxSize.Height = s.WorkingArea.Height - offSet * 2;
            Marshal.StructureToPtr(_lastMinMaxInfo, m.LParam, true);
        }



        MINMAXINFO _lastMinMaxInfo;
        bool _needRedraw = false;

        /// <summary>
        /// Resizes the form so that it doesn't go out of screen
        /// </summary>
        protected void ResizeFormToFitScreen()
        {
            var loc = Location;
            loc.Offset(Width / 2, Height / 2);
            var screen = Screen.FromPoint(loc);
            if (Location.X < screen.WorkingArea.X)
            {
                var rightPos = Location.X + Width;
                Location = new Point(screen.WorkingArea.X, Location.Y);
                Width = rightPos - Location.X;
            }

            if (Location.X + Width > screen.WorkingArea.X + screen.WorkingArea.Width)
            {
                Width -= (Location.X + Width) - (screen.WorkingArea.X + screen.WorkingArea.Width);
            }

            if (Location.Y < screen.WorkingArea.Y)
            {
                var bottomPos = Location.Y + Height;
                Location = new Point(Location.X, screen.WorkingArea.Y);
                Height = bottomPos - Location.Y;
            }

            if (Location.Y + Height > screen.WorkingArea.Y + screen.WorkingArea.Height)
            {
                Height -= (Location.Y + Height) - (screen.WorkingArea.Y + screen.WorkingArea.Height);
            }
        }

        /// <summary>
        /// Retrieves information about this window
        /// </summary>
        protected WINDOWINFO GetWindowInfo()
        {
            WINDOWINFO info = new WINDOWINFO();
            info.cbSize = (uint)Marshal.SizeOf(info);
            HeCopUI_Framework.Win32.User32.GetWindowInfo(Handle, ref info);
            return info;
        }
    }
}
