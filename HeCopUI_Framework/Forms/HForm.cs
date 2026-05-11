using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using HeCopUI_Framework.Win32;
using HeCopUI_Framework.Win32.Enums;
using HeCopUI_Framework.Win32.Struct;
using HeCopUI_Framework.Controls;
using static HeCopUI_Framework.Win32.User32;

namespace HeCopUI_Framework.Forms
{
    [ToolboxItem(false)]
    public class HForm : Form
    {
        private const int TITLE_HEIGHT_DEFAULT = 34;
        private const int CAPTION_BUTTON_WIDTH = 46;
        private const int CAPTION_BUTTON_PADDING = 0;
        private const int RESIZE_BORDER = 6;
        private const int TITLE_ICON_SIZE = 18;
        private const float TITLE_FONT_SIZE = 10f;

        private Color titleBarColor = Color.FromArgb(32, 32, 32);
        private Color titleTextColor = Color.White;
        private Color borderColor = Color.FromArgb(70, 70, 70);
        private Color accentColor = Color.FromArgb(0, 120, 215);
        private Icon titleIcon = null;
        private int titleHeight = TITLE_HEIGHT_DEFAULT;
        private bool isWindowActive = true;
        private HDropShadowForm dropShadow;

        private enum CaptionButton { None, Minimize, Maximize, Close }
        private CaptionButton hotButton = CaptionButton.None;
        private CaptionButton downButton = CaptionButton.None;

        // Smooth hover animation
        private float _closeHover = 0f;
        private float _maxHover = 0f;
        private float _minHover = 0f;
        private Timer _hoverTimer;

        public HForm()
        {
            DoubleBuffered = true;
            SetStyle(
                ControlStyles.ResizeRedraw |
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer, true);
            BackColor = Color.FromArgb(30, 30, 30);

            dropShadow = new HDropShadowForm
            {
                TargetForm = this,
                ShadowVisible = true,
                HideResizeShadow = false,
                AlphaColor = 100,
                ShadowBlur = 16,
                ShadowSpread = 0,
                ShadowColor = Color.Black
            };

            _hoverTimer = new Timer { Interval = 16 };
            _hoverTimer.Tick += HoverTimer_Tick;
        }

        #region Hover Animation

        private void HoverTimer_Tick(object sender, EventArgs e)
        {
            const float speed = 0.18f;
            bool changed = false;
            changed |= StepValue(ref _closeHover, hotButton == CaptionButton.Close ? 1f : 0f, speed);
            changed |= StepValue(ref _maxHover, hotButton == CaptionButton.Maximize ? 1f : 0f, speed);
            changed |= StepValue(ref _minHover, hotButton == CaptionButton.Minimize ? 1f : 0f, speed);

            if (changed)
                InvalidateCaptionArea();
            else
                _hoverTimer.Stop();
        }

        private static bool StepValue(ref float current, float target, float speed)
        {
            float diff = target - current;
            if (Math.Abs(diff) < 0.02f)
            {
                if (current != target) { current = target; return true; }
                return false;
            }
            current += diff * speed;
            if (current < 0.02f) current = 0f;
            if (current > 0.98f) current = 1f;
            return true;
        }

        private void InvalidateCaptionArea()
        {
            Invalidate(new Rectangle(Width - CAPTION_BUTTON_WIDTH * 3 - 2, 0,
                CAPTION_BUTTON_WIDTH * 3 + 4, titleHeight + 2));
        }

        #endregion

        #region CreateParams

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ClassStyle |= 0x00020000; // CS_DROPSHADOW
                return cp;
            }
        }

        #endregion

        #region Properties

        [Category("Appearance")]
        public Color TitleBarColor
        {
            get => titleBarColor;
            set { titleBarColor = value; Invalidate(new Rectangle(0, 0, Width, titleHeight + 2)); }
        }

        [Category("Appearance")]
        public Color TitleTextColor
        {
            get => titleTextColor;
            set { titleTextColor = value; Invalidate(new Rectangle(0, 0, Width, titleHeight + 2)); }
        }

        [Category("Appearance")]
        public Color BorderColor
        {
            get => borderColor;
            set { borderColor = value; Invalidate(); }
        }

        [Category("Appearance")]
        [Description("Accent color shown as a thin line at the top of the active window.")]
        public Color AccentColor
        {
            get => accentColor;
            set { accentColor = value; Invalidate(new Rectangle(0, 0, Width, 3)); }
        }

        [Category("Appearance")]
        public Icon TitleIcon
        {
            get => titleIcon;
            set { titleIcon = value; Invalidate(new Rectangle(0, 0, 40, titleHeight)); }
        }

        [Category("Layout")]
        public int TitleHeight
        {
            get => titleHeight;
            set { titleHeight = Math.Max(24, value); Invalidate(); }
        }

        public override Rectangle DisplayRectangle
        {
            get
            {
                var cr = ClientRectangle;
                bool maximized = WindowState == FormWindowState.Maximized;
                int b = maximized ? 0 : 1;
                return new Rectangle(cr.X + b, cr.Y + titleHeight,
                    Math.Max(0, cr.Width - b * 2), Math.Max(0, cr.Height - titleHeight - b));
            }
        }

        #endregion

        #region Native Frame / Composition Properties

        private bool useNativeFrame;
        [Category("Behavior")]
        [Description("When true the OS window frame is used (FormBorderStyle=Sizable) and DWM caption colors are applied where supported.")]
        public bool UseNativeFrame
        {
            get => useNativeFrame;
            set { if (useNativeFrame == value) return; useNativeFrame = value; Invalidate(); }
        }

        private void ApplyDwmCaptionColors()
        {
            try
            {
                int caption = titleBarColor.ToArgb();
                Dwmapi.DwmSetWindowAttribute(Handle, Dwmapi.DWMWINDOWATTRIBUTE.DWMWA_CAPTION_COLOR, ref caption, sizeof(int));
                int text = titleTextColor.ToArgb();
                Dwmapi.DwmSetWindowAttribute(Handle, Dwmapi.DWMWINDOWATTRIBUTE.DWMWA_TEXT_COLOR, ref text, sizeof(int));
            }
            catch { }
        }

        private bool useAccent;
        private ACCENT_STATE accentState = ACCENT_STATE.ACCENT_ENABLE_BLURBEHIND;
        private int accentFlags = 0;
        private int accentGradient = 0;
        private bool useMica = false;
        private bool useRoundedCorners = false;

        [Category("Appearance")]
        public bool UseAccent
        {
            get => useAccent;
            set
            {
                useAccent = value;
                if (IsHandleCreated && useAccent)
                    CompositionHelper.SetAccentPolicy(Handle, accentState, accentFlags, accentGradient);
            }
        }

        [Category("Appearance")]
        public ACCENT_STATE AccentState
        {
            get => accentState;
            set { accentState = value; if (IsHandleCreated && useAccent) CompositionHelper.SetAccentPolicy(Handle, accentState, accentFlags, accentGradient); }
        }

        [Category("Appearance")]
        public Color AccentGradientColor
        {
            get => Color.FromArgb(accentGradient);
            set { accentGradient = value.ToArgb(); if (IsHandleCreated && useAccent) CompositionHelper.SetAccentPolicy(Handle, accentState, accentFlags, accentGradient); }
        }

        [Category("Appearance")]
        public bool UseMica
        {
            get => useMica;
            set
            {
                useMica = value;
                if (IsHandleCreated && useMica) CompositionHelper.EnableMica(Handle);
            }
        }

        [Category("Appearance")]
        public bool UseRoundedCorners
        {
            get => useRoundedCorners;
            set
            {
                useRoundedCorners = value;
                if (IsHandleCreated && useRoundedCorners) CompositionHelper.SetWindowCornerPreference(Handle, Dwmapi.DWM_WINDOW_CORNER_PREFERENCE.DWMWCP_ROUND);
            }
        }

        #endregion

        #region Lifecycle

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (useAccent)
                CompositionHelper.SetAccentPolicy(Handle, accentState, accentFlags, accentGradient);
            if (useMica)
                CompositionHelper.EnableMica(Handle);
            if (useRoundedCorners)
                CompositionHelper.SetWindowCornerPreference(Handle, Dwmapi.DWM_WINDOW_CORNER_PREFERENCE.DWMWCP_ROUND);
            if (useNativeFrame)
                ApplyDwmCaptionColors();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_hoverTimer != null) { _hoverTimer.Stop(); _hoverTimer.Dispose(); _hoverTimer = null; }
                if (dropShadow != null) { dropShadow.Dispose(); dropShadow = null; }
            }
            base.Dispose(disposing);
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            if (!isWindowActive) { isWindowActive = true; Invalidate(); }
        }

        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);
            if (isWindowActive) { isWindowActive = false; Invalidate(); }
        }

        #endregion

        #region Painting

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.None;
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.Clear(BackColor);

            bool maximized = WindowState == FormWindowState.Maximized;
            int inset = maximized ? 0 : 1;

            // Border (not when maximized)
            if (!maximized)
            {
                using (var borderPen = new Pen(isWindowActive ? borderColor : Color.FromArgb(50, 50, 50)))
                    g.DrawRectangle(borderPen, 0, 0, Width - 1, Height - 1);
            }

            // Title bar background
            var captionColor = isWindowActive ? titleBarColor : DarkenColor(titleBarColor, 0.25f);
            using (var brush = new SolidBrush(captionColor))
                g.FillRectangle(brush, inset, inset, Width - inset * 2, titleHeight - inset);

            // Active accent line at top
            if (isWindowActive)
            {
                using (var accentPen = new Pen(accentColor, 1f))
                    g.DrawLine(accentPen, inset, inset, Width - 1 - inset, inset);
            }

            // Separator line below titlebar
            using (var sepPen = new Pen(Color.FromArgb(isWindowActive ? 40 : 25, 255, 255, 255)))
                g.DrawLine(sepPen, inset, titleHeight, Width - 1 - inset, titleHeight);

            // Icon
            int contentLeft = 10;
            if (titleIcon != null)
            {
                int iconY = (titleHeight - TITLE_ICON_SIZE) / 2;
                g.DrawIcon(titleIcon, new Rectangle(contentLeft, iconY, TITLE_ICON_SIZE, TITLE_ICON_SIZE));
                contentLeft += TITLE_ICON_SIZE + 8;
            }

            // Title text
            int btnCount = 1 + (MaximizeBox ? 1 : 0) + (MinimizeBox ? 1 : 0);
            int titleRight = Width - (CAPTION_BUTTON_WIDTH * btnCount) - 8;
            var titleRect = new Rectangle(contentLeft, inset, Math.Max(0, titleRight - contentLeft), titleHeight - inset);
            var textColor = isWindowActive ? titleTextColor : Color.FromArgb(130, titleTextColor);
            using (var font = new Font("Segoe UI", TITLE_FONT_SIZE, FontStyle.Regular, GraphicsUnit.Point))
            {
                TextRenderer.DrawText(g, Text, font, titleRect, textColor,
                    TextFormatFlags.VerticalCenter | TextFormatFlags.Left |
                    TextFormatFlags.EndEllipsis | TextFormatFlags.SingleLine);
            }

            // Caption buttons
            DrawCaptionButtons(g);
        }

        private void DrawCaptionButtons(Graphics g)
        {
            bool maximized = WindowState == FormWindowState.Maximized;
            int topY = maximized ? 0 : 1;
            int rightEdge = maximized ? Width : Width - 1;
            int x = rightEdge;

            x -= CAPTION_BUTTON_WIDTH;
            DrawButton(g, new Rectangle(x, topY, CAPTION_BUTTON_WIDTH, titleHeight - topY), CaptionButton.Close, _closeHover);

            if (MaximizeBox)
            {
                x -= CAPTION_BUTTON_WIDTH;
                DrawButton(g, new Rectangle(x, topY, CAPTION_BUTTON_WIDTH, titleHeight - topY), CaptionButton.Maximize, _maxHover);
            }

            if (MinimizeBox)
            {
                x -= CAPTION_BUTTON_WIDTH;
                DrawButton(g, new Rectangle(x, topY, CAPTION_BUTTON_WIDTH, titleHeight - topY), CaptionButton.Minimize, _minHover);
            }
        }

        private void DrawButton(Graphics g, Rectangle rect, CaptionButton btn, float hoverProgress)
        {
            bool isDown = downButton == btn;

            // Background hover
            if (hoverProgress > 0f || isDown)
            {
                Color bgColor;
                if (btn == CaptionButton.Close)
                {
                    int alpha = isDown ? 255 : (int)(hoverProgress * 255);
                    bgColor = Color.FromArgb(alpha, isDown ? Color.FromArgb(196, 43, 28) : Color.FromArgb(232, 17, 35));
                }
                else
                {
                    int alpha = isDown ? 26 : (int)(hoverProgress * 38);
                    bgColor = Color.FromArgb(alpha, 255, 255, 255);
                }
                using (var b = new SolidBrush(bgColor))
                    g.FillRectangle(b, rect);
            }

            // Glyph color
            Color glyphColor;
            if (btn == CaptionButton.Close && (hoverProgress > 0.4f || isDown))
                glyphColor = Color.White;
            else
                glyphColor = isWindowActive ? titleTextColor : Color.FromArgb(130, titleTextColor);

            // Center of button
            int cx = rect.X + rect.Width / 2;
            int cy = rect.Y + rect.Height / 2;
            int gs = 5; // glyph half-size

            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (var p = new Pen(glyphColor, 1.15f))
            {
                if (btn == CaptionButton.Close)
                {
                    p.StartCap = LineCap.Round;
                    p.EndCap = LineCap.Round;
                    g.DrawLine(p, cx - gs, cy - gs, cx + gs, cy + gs);
                    g.DrawLine(p, cx + gs, cy - gs, cx - gs, cy + gs);
                }
                else if (btn == CaptionButton.Maximize)
                {
                    p.StartCap = LineCap.Square;
                    p.EndCap = LineCap.Square;
                    if (WindowState == FormWindowState.Maximized)
                    {
                        // Restore icon
                        int s = 4, off = 2;
                        g.DrawRectangle(p, cx - s, cy - s + off, s * 2 - off, s * 2 - off);
                        g.DrawLine(p, cx - s + off, cy - s, cx + s, cy - s);
                        g.DrawLine(p, cx + s, cy - s, cx + s, cy + s - off);
                        g.DrawLine(p, cx - s + off, cy - s, cx - s + off, cy - s + 1);
                    }
                    else
                    {
                        g.DrawRectangle(p, cx - gs, cy - gs, gs * 2, gs * 2);
                    }
                }
                else if (btn == CaptionButton.Minimize)
                {
                    p.StartCap = LineCap.Flat;
                    p.EndCap = LineCap.Flat;
                    g.DrawLine(p, cx - gs, cy, cx + gs, cy);
                }
            }
            g.SmoothingMode = SmoothingMode.None;
        }

        private static Color DarkenColor(Color c, float amount)
        {
            float r = Math.Max(0, c.R * (1f - amount));
            float gr = Math.Max(0, c.G * (1f - amount));
            float b = Math.Max(0, c.B * (1f - amount));
            return Color.FromArgb(c.A, (int)r, (int)gr, (int)b);
        }

        #endregion

        #region Mouse Handling

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            var btn = HitTestCaptionButton(e.Location);
            if (btn != hotButton)
            {
                hotButton = btn;
                if (!_hoverTimer.Enabled) _hoverTimer.Start();
                InvalidateCaptionArea();
            }

            // Set proper directional cursor for resize zones
            if (WindowState != FormWindowState.Maximized)
            {
                var ht = GetResizeHitTest(e.Location);
                Cursor = GetCursorForHitTest(ht);
            }
            else
            {
                Cursor = Cursors.Default;
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (hotButton != CaptionButton.None)
            {
                hotButton = CaptionButton.None;
                if (!_hoverTimer.Enabled) _hoverTimer.Start();
                InvalidateCaptionArea();
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button != MouseButtons.Left) return;

            var btn = HitTestCaptionButton(e.Location);
            if (btn != CaptionButton.None)
            {
                downButton = btn;
                InvalidateCaptionArea();
                return;
            }

            // Double-click title bar to toggle maximize
            if (e.Clicks == 2 && e.Y <= titleHeight && MaximizeBox)
            {
                WindowState = WindowState == FormWindowState.Maximized
                    ? FormWindowState.Normal : FormWindowState.Maximized;
                return;
            }

            // Drag to move
            if (e.Y <= titleHeight)
            {
                ReleaseCapture();
                SendMessage(Handle, 0x0112 /*WM_SYSCOMMAND*/, 0xF010 + 2 /*SC_MOVE + HTCAPTION*/, 0);
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (downButton != CaptionButton.None)
            {
                var clicked = downButton;
                downButton = CaptionButton.None;
                hotButton = HitTestCaptionButton(e.Location);
                InvalidateCaptionArea();
                if (clicked == hotButton || clicked == HitTestCaptionButton(e.Location))
                    HandleCaptionClick(clicked);
            }
        }

        private void HandleCaptionClick(CaptionButton btn)
        {
            if (btn == CaptionButton.Close)
                Close();
            else if (btn == CaptionButton.Minimize)
                WindowState = FormWindowState.Minimized;
            else if (btn == CaptionButton.Maximize)
                WindowState = WindowState == FormWindowState.Maximized
                    ? FormWindowState.Normal : FormWindowState.Maximized;
        }

        #endregion

        #region Hit Testing

        private CaptionButton HitTestCaptionButton(Point p)
        {
            if (p.Y > titleHeight) return CaptionButton.None;

            bool maximized = WindowState == FormWindowState.Maximized;
            int rightEdge = maximized ? Width : Width - 1;
            int x = rightEdge;

            var closeRect = new Rectangle(x - CAPTION_BUTTON_WIDTH, maximized ? 0 : 1, CAPTION_BUTTON_WIDTH, titleHeight);
            if (closeRect.Contains(p)) return CaptionButton.Close;

            x -= CAPTION_BUTTON_WIDTH;
            if (MaximizeBox)
            {
                var maxRect = new Rectangle(x - CAPTION_BUTTON_WIDTH, maximized ? 0 : 1, CAPTION_BUTTON_WIDTH, titleHeight);
                if (maxRect.Contains(p)) return CaptionButton.Maximize;
                x -= CAPTION_BUTTON_WIDTH;
            }

            if (MinimizeBox)
            {
                var minRect = new Rectangle(x - CAPTION_BUTTON_WIDTH, maximized ? 0 : 1, CAPTION_BUTTON_WIDTH, titleHeight);
                if (minRect.Contains(p)) return CaptionButton.Minimize;
            }

            return CaptionButton.None;
        }

        private int GetResizeHitTest(Point p)
        {
            if (WindowState == FormWindowState.Maximized) return 0;
            int rb = RESIZE_BORDER;
            bool left = p.X <= rb, right = p.X >= Width - rb;
            bool top = p.Y <= rb, bottom = p.Y >= Height - rb;

            if (top && left) return 13;    // HTTOPLEFT
            if (top && right) return 14;   // HTTOPRIGHT
            if (bottom && left) return 16; // HTBOTTOMLEFT
            if (bottom && right) return 17;// HTBOTTOMRIGHT
            if (top) return 12;            // HTTOP
            if (bottom) return 15;         // HTBOTTOM
            if (left) return 10;           // HTLEFT
            if (right) return 11;          // HTRIGHT
            return 0;
        }

        private static Cursor GetCursorForHitTest(int ht)
        {
            switch (ht)
            {
                case 12: case 15: return Cursors.SizeNS;     // top/bottom
                case 10: case 11: return Cursors.SizeWE;     // left/right
                case 13: case 17: return Cursors.SizeNWSE;   // topleft/bottomright
                case 14: case 16: return Cursors.SizeNESW;   // topright/bottomleft
                default: return Cursors.Default;
            }
        }

        #endregion

        #region WndProc

        protected override void WndProc(ref Message m)
        {
            const int WM_NCHITTEST = 0x0084;
            const int WM_NCCALCSIZE = 0x0083;
            const int WM_GETMINMAXINFO = 0x0024;
            const int WM_NCACTIVATE = 0x0086;

            // Prevent the default non-client frame from being drawn on activation changes
            if (m.Msg == WM_NCACTIVATE)
            {
                m.Result = new IntPtr(1);
                return;
            }

            // Remove non-client area; properly constrain when maximized
            if (m.Msg == WM_NCCALCSIZE)
            {
                if (m.WParam != IntPtr.Zero && WindowState == FormWindowState.Maximized)
                {
                    // Constrain client area to the monitor work area to prevent overflow
                    var nccsp = (NCCALCSIZE_PARAMS)Marshal.PtrToStructure(m.LParam, typeof(NCCALCSIZE_PARAMS));
                    var monitor = MonitorFromWindow(Handle, 2u);
                    if (monitor != IntPtr.Zero)
                    {
                        var mi = new MONITORINFO { cbSize = Marshal.SizeOf(typeof(MONITORINFO)) };
                        if (GetMonitorInfo(monitor, ref mi))
                        {
                            nccsp.rcOldWindow.left = mi.rcWork.left;
                            nccsp.rcOldWindow.top = mi.rcWork.top;
                            nccsp.rcOldWindow.right = mi.rcWork.right;
                            nccsp.rcOldWindow.bottom = mi.rcWork.bottom;
                            Marshal.StructureToPtr(nccsp, m.LParam, false);
                        }
                    }
                }
                m.Result = IntPtr.Zero;
                return;
            }

            if (m.Msg == WM_GETMINMAXINFO)
            {
                OnGetMinMaxInfo(ref m);
                return;
            }

            if (m.Msg == WM_NCHITTEST)
            {
                var mouse = PointToClient(new Point((int)m.LParam));

                // Resize borders (only when not maximized)
                if (WindowState != FormWindowState.Maximized)
                {
                    int ht = GetResizeHitTest(mouse);
                    if (ht != 0)
                    {
                        m.Result = new IntPtr(ht);
                        return;
                    }
                }

                // Caption area
                if (mouse.Y <= titleHeight)
                {
                    if (HitTestCaptionButton(mouse) == CaptionButton.None)
                    {
                        m.Result = new IntPtr(2); // HTCAPTION
                        return;
                    }
                    else
                    {
                        // Return HTCLIENT for caption buttons so mouse events work
                        m.Result = new IntPtr(1); // HTCLIENT
                        return;
                    }
                }
            }

            base.WndProc(ref m);
        }

        private void OnGetMinMaxInfo(ref Message m)
        {
            var minmax = (MINMAXINFO)Marshal.PtrToStructure(m.LParam, typeof(MINMAXINFO));
            var monitor = MonitorFromWindow(Handle, 2u);

            if (monitor != IntPtr.Zero)
            {
                var monitorInfo = new MONITORINFO { cbSize = Marshal.SizeOf(typeof(MONITORINFO)) };
                if (GetMonitorInfo(monitor, ref monitorInfo))
                {
                    var workArea = monitorInfo.rcWork;
                    var monitorArea = monitorInfo.rcMonitor;

                    minmax.maxPosition.X = Math.Abs(workArea.left - monitorArea.left);
                    minmax.maxPosition.Y = Math.Abs(workArea.top - monitorArea.top);
                    minmax.maxSize.Width = Math.Abs(workArea.Right - workArea.Left);
                    minmax.maxSize.Height = Math.Abs(workArea.Bottom - workArea.Top);
                }
            }

            if (MinimumSize.Width > 0 || MinimumSize.Height > 0)
                minmax.minTrackSize = MinimumSize;

            if (!MaximumSize.IsEmpty)
                minmax.maxTrackSize = MaximumSize;

            Marshal.StructureToPtr(minmax, m.LParam, false);
            m.Result = IntPtr.Zero;
        }

        #endregion
    }
}
