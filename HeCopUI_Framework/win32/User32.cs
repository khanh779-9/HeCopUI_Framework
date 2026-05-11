using HeCopUI_Framework.Win32.Enums;
using HeCopUI_Framework.Win32.Struct;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Windows.Forms;

namespace HeCopUI_Framework.Win32
{
    public class User32
    {

        public static bool IsRunningOnMono
        {
            get
            {
                // Check if the runtime is Mono
                return Type.GetType("Mono.Runtime") != null;
            }
        }

        private static HandleRef HWND_TOPMOST = new HandleRef(null, new IntPtr(-1));



        public AnimateWindowFlags AW_HIDE { get; set; }

        [DllImport("user32.dll")]
        public static extern int GetWindowRgn(IntPtr hWnd, IntPtr hRgn);

        [DllImport("User32.dll")]
        public static extern bool AnimateWindow(IntPtr handle, int msec, int flags);

        [DllImport("User32.dll")]
        public static extern int ShowCaret(IntPtr hwnd);

        [DllImport("User32.dll")]
        public static extern int HideCaret(IntPtr hwnd);

        [DllImport("User32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("User32.dll")]
#pragma warning disable CS3001 // Argument type is not CLS-compliant
        public static extern bool SetWindowPos(uint hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("User32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref Point pptDst, ref Size psize, IntPtr hdcSrc, ref Point pprSrc, int crKey, ref BLENDFUNCTION pblend, int dwFlags);

        [DllImport("User32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref POINT pptDst, ref SIZE psize, IntPtr hdcSrc, ref POINT pprSrc, int crKey, ref BLENDFUNCTION pblend, int dwFlags);

        [DllImport("User32.dll")]
        public static extern bool IsIconic(IntPtr handle);

        public static int RegisterWindowMessage(string format, params object[] args)
        {
            string lpString = string.Format(format, args);
            return RegisterWindowMessage(lpString);
        }

        [DllImport("User32.dll")]
        public static extern bool PostMessage(IntPtr hwnd, int User32, IntPtr wparam, IntPtr lparam);

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool GetWindowInfo(IntPtr hwnd, ref WINDOWINFO pwi);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool MessageBeep(uint type);


        public static void ShowToFront(IntPtr window)
        {
            ShowWindow(window, 1);
            SetForegroundWindow(window);
        }

        internal static int HIWORD(int n)
        {
            return (short)((n >> 16) & 0xFFFF);
        }

        internal static int LOWORD(int n)
        {
            return (short)(n & 0xFFFF);
        }

        [DllImport("User32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("User32.dll", SetLastError = true)]
#pragma warning disable CS3002 // Return type is not CLS-compliant
        public static extern uint GetWindowLong(IntPtr hWnd, int nIndex);
#pragma warning restore CS3002 // Return type is not CLS-compliant

        [DllImport("User32.dll")]
#pragma warning disable CS3001 // Argument type is not CLS-compliant
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);
#pragma warning restore CS3001 // Argument type is not CLS-compliant

        [DllImport("User32.dll")]
#pragma warning disable CS3001 // Argument type is not CLS-compliant
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int W, int H, uint uFlags);
#pragma warning restore CS3001 // Argument type is not CLS-compliant

        [DllImport("User32.dll")]
        public static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("User32.dll")]
        public static extern int GetMenuItemCount(IntPtr hMenu);

        [DllImport("User32.dll")]
        public static extern bool DrawMenuBar(IntPtr hWnd);

        [DllImport("User32.dll")]
#pragma warning disable CS3001 // Argument type is not CLS-compliant
        public static extern bool RemoveMenu(IntPtr hMenu, uint uPosition, uint uFlags);

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern IntPtr SetCapture(IntPtr hWnd);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        [SuppressUnmanagedCodeSecurity]
        private static extern int AnimateWindow(HandleRef windowHandle, int time, AnimationFlags flags);

        internal static void AnimateWindow(Control control, int time, AnimationFlags flags)
        {
            try
            {
                SecurityPermission securityPermission = new SecurityPermission(SecurityPermissionFlag.UnmanagedCode);
                securityPermission.Demand();
                AnimateWindow(new HandleRef(control, control.Handle), time, flags);
            }
            catch (SecurityException)
            {
            }
        }

        [DllImport("User32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        [SuppressUnmanagedCodeSecurity]
        private static extern bool SetWindowPos(HandleRef hWnd, HandleRef hWndInsertAfter, int x, int y, int cx, int cy, int flags);

        internal static void SetTopMost(Control control)
        {
            try
            {
                SecurityPermission securityPermission = new SecurityPermission(SecurityPermissionFlag.UnmanagedCode);
                securityPermission.Demand();
                SetWindowPos(new HandleRef(control, control.Handle), HWND_TOPMOST, 0, 0, 0, 0, 19);
            }
            catch (SecurityException)
            {
            }
        }

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int User32, int wParam, int lParam);

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr wnd, int User32, bool param, int lparam);

        [DllImport("User32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("User32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("User32.dll")]
#pragma warning disable CS3001 // Argument type is not CLS-compliant
        public static extern IntPtr GetDCEx(IntPtr hwnd, IntPtr hrgnclip, uint fdwOptions);
#pragma warning restore CS3001 // Argument type is not CLS-compliant

        [DllImport("User32.dll")]
        public static extern bool ShowScrollBar(IntPtr hWnd, int bar, int cmd);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetWindowDC(IntPtr handle);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr ReleaseDC(IntPtr handle, IntPtr hDC);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClassName(IntPtr hwnd, char[] className, int maxCount);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetWindow(IntPtr hwnd, int uCmd);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool IsWindowVisible(IntPtr hwnd);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClientRect(IntPtr hwnd, ref RECT lpRect);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClientRect(IntPtr hwnd, [In][Out] ref Rectangle rect);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool MoveWindow(IntPtr hwnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool UpdateWindow(IntPtr hwnd);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool InvalidateRect(IntPtr hwnd, ref Rectangle rect, bool bErase);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool ValidateRect(IntPtr hwnd, ref Rectangle rect);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern bool GetWindowRect(IntPtr hWnd, [In][Out] ref Rectangle rect);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int User32, int wParam, string lParam);

        [DllImport("User32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr LoadCursor(IntPtr hInstance, int lpCursorName);

        [DllImport("User32.dll")]
        public static extern bool AnimateWindow(IntPtr hwnd, int time, AnimateWindowFlags flags);

        public void AnimateWindow(IntPtr handle, int v, object p)
        {
        }

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int SetWindowCompositionAttribute(IntPtr hWnd, ref WINCOMPATTRDATA data);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool SetForegroundWindow(HandleRef hWnd);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, int wUser32, IntPtr wParam, IntPtr lParam);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool PostMessage(HandleRef hWnd, WindowMessages User32, IntPtr wParam, IntPtr lParam);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr DefWindowProc(IntPtr hWnd, int User32, IntPtr wParam, IntPtr lParam);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int RegisterWindowMessage(string lpString);



        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern bool TrackMouseEvent(ref TRACKMOUSEEVENTS tme);

        [DllImport("User32.dll")]
        internal static extern IntPtr GetParent(IntPtr hWnd);

        [DllImport("User32.dll")]
        internal static extern IntPtr GetTopWindow(IntPtr hWnd);

        [DllImport("User32.dll")]
        internal static extern IntPtr GetWindow(IntPtr hWnd, uint wCmd);

        [DllImport("User32.dll")]
        internal static extern IntPtr TrackPopupMenu(IntPtr menuHandle, int uFlags, int x, int y, int nReserved, IntPtr hwnd, IntPtr par);



        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern void AdjustWindowRectEx(ref RECT rect, int dwStyle, bool hasMenu, int dwExSytle);

        [DllImport("User32.dll")]
        public static extern int SetWindowRgn(IntPtr hWnd, IntPtr hRgn, bool bRedraw);



        [DllImport("User32.dll")]
        public static extern IntPtr DefWindowProc(IntPtr hWnd, WindowMessages uUser32, IntPtr wParam, IntPtr lParam);

        [DllImport("User32.dll")]
        public static extern bool IsZoomed(IntPtr hwnd);



        public static float GetOriginalDeviceScaleFactor(IntPtr hWnd)
        {
            IntPtr hMonitor = MonitorFromWindow(hWnd, 2u);
            try
            {
                GetDpiForMonitor(hMonitor, MonitorDpiType.MDT_EFFECTIVE_DPI, out var dpiX, out var _);
                return dpiX / 96f;
            }
            catch
            {
                return 1f;
            }
        }

        public static int GetOriginalDeviceDpi(IntPtr hWnd)
        {
            IntPtr hMonitor = MonitorFromWindow(hWnd, 2u);
            try
            {
                GetDpiForMonitor(hMonitor, MonitorDpiType.MDT_EFFECTIVE_DPI, out var dpiX, out var _);
                return dpiX;
            }
            catch
            {
                return 96;
            }
        }

        [DllImport("Shcore.dll")]
        public static extern int GetDpiForMonitor(IntPtr hMonitor, MonitorDpiType dpiType, out int dpiX, out int dpiY);

        [DllImport("User32.dll")]
#pragma warning disable CS3001 // Argument type is not CLS-compliant
        public static extern IntPtr MonitorFromWindow(IntPtr hWnd, uint dwFlags);
#pragma warning restore CS3001 // Argument type is not CLS-compliant

        [DllImport("User32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetMonitorInfo(IntPtr hMonitor, ref MONITORINFO lpmi);



        [DllImport("Shcore.dll")]
        public static extern int GetScaleFactorForMonitor(IntPtr hMonitor, ref DeviceScaleFactor pScale);

        [DllImport("Shcore.dll")]
        public static extern int GetScaleFactorForMonitor(IntPtr hMonitor, ref int pScale);

        [DllImport("User32.dll")]
        public static extern int FillRect(IntPtr hDC, [In] ref RECT lprc, IntPtr hbr);

        [DllImport("User32.dll")]
        public static extern bool InflateRect(ref RECT lprc, int dx, int dy);

        [DllImport("User32.dll")]
        public static extern int GetSystemMetrics(SystemMetricFlags smIndex);

        [DllImport("User32.dll")]
        public static extern IntPtr GetDCEx(IntPtr hwnd, IntPtr hrgnclip, int fdwOptions);

        [DllImport("User32.dll")]
        public static extern void DisableProcessWindowsGhosting();

        [DllImport("User32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
#pragma warning disable CS3001 // Argument type is not CLS-compliant
        public static extern bool RedrawWindow(IntPtr hWnd, IntPtr lprcUpdate, IntPtr hrgnUpdate, uint flags);
#pragma warning restore CS3001 // Argument type is not CLS-compliant

        [DllImport("User32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
#pragma warning disable CS3001 // Argument type is not CLS-compliant
        public static extern bool RedrawWindow(IntPtr hWnd, IntPtr lprcUpdate, IntPtr hrgnUpdate, RedrawWindowFlags flags);
#pragma warning restore CS3001 // Argument type is not CLS-compliant


        public static void InvalidateWindow(IntPtr hWnd)
        {
            RedrawWindow(hWnd, IntPtr.Zero, IntPtr.Zero, 1285u);
        }

        public static void SendFrameChanged(IntPtr hWnd)
        {
            SetWindowPos(hWnd, IntPtr.Zero, 0, 0, 0, 0, (SetWindowPosFlags)1847);
        }

        [DllImport("User32.dll")]
        public static extern int OffsetRect(ref RECT lpRect, int x, int y);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
#pragma warning disable CS3001 // Argument type is not CLS-compliant
        public static extern bool SetWindowPos(int hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);
#pragma warning restore CS3001 // Argument type is not CLS-compliant

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int SetWindowPos(IntPtr hWnd, IntPtr hWndAfter, int x, int y, int width, int height, SetWindowPosFlags flags);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool ShowWindow(int hWnd, int nCmdShow);

        [DllImport("User32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int ShowWindow(IntPtr hWnd, short cmdShow);

        [DllImport("User32.dll", SetLastError = true)]
        public static extern int CloseWindow(IntPtr hWnd);

        [DllImport("User32.dll")]
        public static extern int SetParent(int hWndChild, int hWndParent);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("User32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DestroyWindow(IntPtr hWnd);

        [DllImport("User32.dll", SetLastError = true)]
#pragma warning disable CS3002 // Return type is not CLS-compliant
        public static extern ushort RegisterClassW([In] ref WNDCLASS lpWndClass);
#pragma warning restore CS3002 // Return type is not CLS-compliant

        [DllImport("User32.dll", SetLastError = true)]
#pragma warning disable CS3001 // Argument type is not CLS-compliant
#pragma warning disable CS3001 // Argument type is not CLS-compliant
        public static extern IntPtr CreateWindowExW(uint dwExStyle, [MarshalAs(UnmanagedType.LPWStr)] string lpClassName, [MarshalAs(UnmanagedType.LPWStr)] string lpWindowName, uint dwStyle, int x, int y, int nWidth, int nHeight, IntPtr hWndParent, IntPtr hMenu, IntPtr hInstance, IntPtr lpParam);
#pragma warning restore CS3001 // Argument type is not CLS-compliant
#pragma warning restore CS3001 // Argument type is not CLS-compliant

        [DllImport("User32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern IntPtr CreateWindowEx(int dwExStyle, IntPtr classAtom, string lpWindowName, int dwStyle, int x, int y, int nWidth, int nHeight, IntPtr hWndParent, IntPtr hMenu, IntPtr hInstance, IntPtr lpParam);

        [DllImport("User32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern IntPtr CreateWindowEx(long dwExStyle, IntPtr classAtom, string lpWindowName, long dwStyle, int x, int y, int nWidth, int nHeight, IntPtr hWndParent, IntPtr hMenu, IntPtr hInstance, IntPtr lpParam);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
#pragma warning disable CS3002 // Return type is not CLS-compliant
        public static extern uint GetWindowLong(IntPtr hWnd, GetWindowLongFlags nIndex);
#pragma warning restore CS3002 // Return type is not CLS-compliant

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int SetWindowLong(IntPtr hWnd, GetWindowLongFlags nIndex, IntPtr newLong);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
#pragma warning disable CS3001 // Argument type is not CLS-compliant
        public static extern int SetWindowLong(IntPtr hWnd, GetWindowLongFlags nIndex, uint newLong);
#pragma warning restore CS3001 // Argument type is not CLS-compliant

        [DllImport("User32.dll", SetLastError = true)]
#pragma warning disable CS3001 // Argument type is not CLS-compliant
        public static extern IntPtr DefWindowProcW(IntPtr hWnd, uint User32, IntPtr wParam, IntPtr lParam);
#pragma warning restore CS3001 // Argument type is not CLS-compliant

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetWindowRect(IntPtr hWnd, ref RECT rect);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
#pragma warning disable CS3001 // Argument type is not CLS-compliant
        public static extern IntPtr LoadCursor(IntPtr hInstance, uint cursor);
#pragma warning restore CS3001 // Argument type is not CLS-compliant

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetCursor(IntPtr hCursor);

        [DllImport("User32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetCursorPos(ref POINT lpPoint);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool ScreenToClient(IntPtr hWnd, ref POINT pt);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool ClientToScreen(IntPtr hWnd, ref POINT lpPoint);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int ShowWindow(IntPtr hWnd, ShowWindowStyles cmdShow);

        [DllImport("User32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        [DllImport("User32.dll")]
        public static extern IntPtr GetActiveWindow();

        [DllImport("User32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
#pragma warning disable CS3001 // Argument type is not CLS-compliant
        public static extern IntPtr SendMessage(IntPtr hWnd, uint User32, IntPtr wParam, IntPtr lParam);
#pragma warning restore CS3001 // Argument type is not CLS-compliant

        [DllImport("User32.dll")]
#pragma warning disable CS3001 // Argument type is not CLS-compliant
        public static extern int TrackPopupMenu(IntPtr hMenu, uint uFlags, int x, int y, int nReserved, IntPtr hWnd, IntPtr prcRect);
#pragma warning restore CS3001 // Argument type is not CLS-compliant

#pragma warning disable CS3002 // Return type is not CLS-compliant
        public static uint LOWORD(IntPtr ptr)
#pragma warning restore CS3002 // Return type is not CLS-compliant
        {
            return LoWord(ptr);
        }

#pragma warning disable CS3002 // Return type is not CLS-compliant
        public static uint HIWORD(IntPtr ptr)
#pragma warning restore CS3002 // Return type is not CLS-compliant
        {
            return HiWord(ptr);
        }

#pragma warning disable CS3002 // Return type is not CLS-compliant
#pragma warning disable CS3005 // Identifier differing only in case is not CLS-compliant
        public static uint HiWord(IntPtr ptr)
#pragma warning restore CS3005 // Identifier differing only in case is not CLS-compliant
#pragma warning restore CS3002 // Return type is not CLS-compliant
        {
            if (((int)ptr & int.MinValue) == int.MinValue)
            {
                return (uint)(int)ptr >> 16;
            }
            return ((uint)(int)ptr >> 16) & 0xFFFFu;
        }

#pragma warning disable CS3005 // Identifier differing only in case is not CLS-compliant
#pragma warning disable CS3002 // Return type is not CLS-compliant
        public static uint LoWord(IntPtr ptr)
#pragma warning restore CS3002 // Return type is not CLS-compliant
#pragma warning restore CS3005 // Identifier differing only in case is not CLS-compliant
        {
            return (uint)ptr.ToInt32() & 0xFFFFu;
        }

        public static void SendMessage(IntPtr handle, WindowMessages nCLBUTTONDOWN, IntPtr cAPTION, IntPtr zero)
        {
            throw new NotImplementedException();
        }
    }
}
