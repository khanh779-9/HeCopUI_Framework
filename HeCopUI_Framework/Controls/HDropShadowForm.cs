using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls
{
    public partial class HDropShadowForm : Component
    {
        Dropshadow DS;

        public HDropShadowForm()
        {

        }

        private Form _targetform;

        public Form TargetForm
        {
            get { return _targetform; }
            set
            {
                _targetform = value;
                if (!DesignMode) _targetform.Load += _targetform_Load;
            }
        }

        public int ShadowSpread { get; set; } = 0;
        public int ShadowBlur { get; set; } = 10;

        public Color ShadowColor { get; set; } = Color.Black;
        
        private int _alphaColor = 150;
        
#pragma warning disable CS3005 // Identifier differing only in case is not CLS-compliant
        public int AlphaColor
#pragma warning restore CS3005 // Identifier differing only in case is not CLS-compliant
        {
            get { return _alphaColor; }
            set
            {
                if (value >= 255) _alphaColor = 255;
                else if (value <= 0) _alphaColor = 0;
                else _alphaColor = value;
            }
        }

        private void _targetform_Load(object sender, EventArgs e)
        {
            try
            {
                DS = new Dropshadow(_targetform)
                {
                    ShadowColor = Color.FromArgb(_alphaColor, ShadowColor.R, ShadowColor.G, ShadowColor.B),
                    ShadowSpread = ShadowSpread,
                    ShadowBlur = ShadowBlur,
                    ShadowVisible = ShadowVisible,
                    HideResizeShadow = HideResizeShadow
                };
                DS.RefreshShadow();
            }
            catch { }
        }
        public bool HideResizeShadow
        { get; set; } = false;

        public bool ShadowVisible { get; set; } = true;


        private int BorderRadius { get; set; } = 5;

        class Dropshadow : Form
        {
            private Bitmap _shadowBitmap;
            private Color _shadowColor;
            private int _shadowH;
            private byte _shadowOpacity = 255;
            private int _shadowV;
            public bool HideResizeShadow { get; set; } = false;
            public bool ShadowVisible { get; set; } = true;

            public Dropshadow(Form f)
            {
                Owner = f;
                // default style
                FormBorderStyle = FormBorderStyle.None;
                ShowInTaskbar = false;
                //Location = new Point(Width - Owner.Width, Height - Owner.Height);

                // bind event
                Owner.LocationChanged += UpdateLocation;
                Owner.FormClosing += (sender, eventArgs) => Close();
                Owner.VisibleChanged += (sender, eventArgs) =>
                {
                    if (Owner != null)
                    {
                        if (ShadowVisible == true)
                            Visible = Owner.Visible;
                    }
                };
                Owner.ResizeBegin += (sender, e) =>
                {
                    try
                    {
                        if (ShadowVisible == true)
                            if (HideResizeShadow == true)
                                Visible = false;
                    }
                    catch { }
                };
                Owner.SizeChanged += (seder, e) =>
                {
                    RefreshShadow();
                };
                Owner.ResizeEnd += (seder, e) =>
                {
                    RefreshShadow();
                    Visible = ShadowVisible;
                };
                Owner.Activated += (sender, args) =>
                {
                    try
                    {
                        Owner.BringToFront();
                    }
                    catch { }
                };
            }



            protected override void OnMouseClick(MouseEventArgs e)
            {
                try
                {
                    Owner.Activate();
                }
                catch { }
                base.OnMouseClick(e);
            }


            public Color ShadowColor
            {
                get { return _shadowColor; }
                set
                {
                    _shadowColor = value;
                    _shadowOpacity = _shadowColor.A;
                }
            }

            public Bitmap ShadowBitmap
            {
                get { return _shadowBitmap; }
                set
                {
                    _shadowBitmap = value;
                    SetBitmap(_shadowBitmap, ShadowOpacity);
                }
            }

            public byte ShadowOpacity
            {
                get { return _shadowOpacity; }
                set
                {
                    _shadowOpacity = value;
                    SetBitmap(ShadowBitmap, _shadowOpacity);
                }
            }

            public int ShadowH
            {
                get { return _shadowH; }
                set
                {
                    _shadowH = value;
                    RefreshShadow(false);
                }
            }

            /// <summary>
            ///     Offset X relate to Owner
            /// </summary>
            public int OffsetX
            {
                get { return ShadowH - (ShadowBlur + ShadowSpread); }
            }

            /// <summary>
            ///     Offset Y relate to Owner
            /// </summary>
            public int OffsetY
            {
                get { return ShadowV - (ShadowBlur + ShadowSpread); }
            }

            public new int Width
            {
                get { return Owner.Width + (ShadowSpread + ShadowBlur) * 2; }
            }

            public new int Height
            {
                get { return Owner.Height + (ShadowSpread + ShadowBlur) * 2; }
            }

            public int ShadowSpread { get; set; } = 0;
            public int ShadowBlur { get; set; } = 10;

            public int ShadowV
            {
                get { return _shadowV; }
                set
                {
                    _shadowV = value;
                    RefreshShadow(false);
                }
            }

            protected override CreateParams CreateParams
            {
                get
                {
                    CreateParams cp = base.CreateParams;
                    cp.ExStyle = 0x00080000; // This form has to have the WS_EX_LAYERED extended style

                    return cp;
                }

            }

            public Dropshadow()
            {

            }

            public static Bitmap DrawShadowBitmap(int width, int height, int borderRadius, int blur, int spread, Color color)
            {
                int ex = blur + spread;
                int w = width + ex * 2;
                int h = height + ex * 2;
                int solidW = width + spread * 2;
                int solidH = height + spread * 2;

                var bitmap = new Bitmap(w, h);
                Graphics g = Graphics.FromImage(bitmap);
                Helper.GraphicsHelper.SetHightGraphics(g);
                // fill background
                //+1
                //int add = 1;
                //g.FillRectangle(new SolidBrush(color)
                //, blur, blur, width + spread * 2 + add, height + spread * 2 + add);
                // +1 to fill the gap

                if (blur > 0)
                {
                    // four dir gradiant
                    {
                        // left
                        var brush = new LinearGradientBrush(new Point(0, 0), new Point(blur, 0), Color.Transparent, color);
                        // will thorw ArgumentException
                        //brush.WrapMode = WrapMode.Clamp; 
                        g.FillRectangle(brush, 0, blur, blur, solidH);
                        // up
                        brush.RotateTransform(90);
                        g.FillRectangle(brush, blur, 0, solidW, blur);

                        brush.ResetTransform();
                        brush.TranslateTransform(w % blur, h % blur);

                        brush.RotateTransform(180);
                        g.FillRectangle(brush, w - blur, blur, blur, solidH);
                        // down
                        brush.RotateTransform(90);
                        g.FillRectangle(brush, blur, h - blur, solidW, blur);
                    }


                    // four corner
                    {
                        var gp = new GraphicsPath();
                        //gp.AddPie(0,0,blur*2,blur*2, 180, 90);
                        gp.AddEllipse(0, 0, blur * 2, blur * 2);


                        var pgb = new PathGradientBrush(gp)
                        {
                            CenterColor = color,
                            SurroundColors = new[] { Color.Transparent },
                            CenterPoint = new Point(blur, blur)
                        };

                        // lt
                        g.FillPie(pgb, 0, 0, blur * 2, blur * 2, 180, 90);
                        // rt
                        var matrix = new Matrix();
                        matrix.Translate(w - blur * 2, 0);

                        pgb.Transform = matrix;
                        //pgb.Transform.Translate(w-blur*2, 0);
                        g.FillPie(pgb, w - blur * 2, 0, blur * 2, blur * 2, 270, 90);
                        // rb
                        matrix.Translate(0, h - blur * 2);
                        pgb.Transform = matrix;
                        g.FillPie(pgb, w - blur * 2, h - blur * 2, blur * 2, blur * 2, 0, 90);
                        // lb
                        matrix.Reset();
                        matrix.Translate(0, h - blur * 2);
                        pgb.Transform = matrix;
                        g.FillPie(pgb, 0, h - blur * 2, blur * 2, blur * 2, 90, 90);
                    }
                }

                //
                return bitmap;
            }

            public void UpdateLocation(Object sender = null, EventArgs eventArgs = null)
            {
                Point pos = Owner.Location;

                pos.Offset(OffsetX, OffsetY);
                Location = pos;
            }

            /// <summary>
            ///     Refresh shadow.
            /// </summary>
            /// <param name="redraw"> (optional) redraw the background bitmap. </param>
            public void RefreshShadow(bool redraw = true)
            {
                if (redraw)
                {
                    //ShadowBitmap = DrawShadow();
                    ShadowBitmap = DrawShadowBitmap(Owner.Width, Owner.Height, 0, ShadowBlur, ShadowSpread, ShadowColor);
                }

                //SetBitmap(ShadowBitmap, ShadowOpacity);
                UpdateLocation();

                // 设置显示区域
                //Region r = Region.FromHrgn(Win32.CreateRoundRectRgn(0, 0, Width, Height, new HDropShadowForm().BorderRadius, new HDropShadowForm()));
                var r = new Region(new Rectangle(0, 0, Width, Height));
                Region or;
                if (Owner.Region == null)
                    or = new Region(Owner.ClientRectangle);
                else
                    or = Owner.Region.Clone();

                or.Translate(-OffsetX, -OffsetY);
                r.Exclude(or);
                //Region = r;

                Owner.Refresh();
            }

            /// <para>Changes the current bitmap with a custom opacity level.  Here is where all happens!</para>
            public void SetBitmap(Bitmap bitmap, byte opacity = 255)
            {
                if (bitmap.PixelFormat != PixelFormat.Format32bppArgb)
                    throw new ApplicationException("The bitmap must be 32ppp with alpha-channel.");

                // The ideia of this is very simple,
                // 1. Create a compatible DC with screen;
                // 2. Select the bitmap with 32bpp with alpha-channel in the compatible DC;
                // 3. Call the UpdateLayeredWindow.

                IntPtr screenDc = Win32.GetDC(IntPtr.Zero);
                IntPtr memDc = Win32.CreateCompatibleDC(screenDc);
                IntPtr hBitmap = IntPtr.Zero;
                IntPtr oldBitmap = IntPtr.Zero;

                try
                {
                    hBitmap = bitmap.GetHbitmap(Color.FromArgb(0)); // grab a GDI handle from this GDI+ bitmap
                    oldBitmap = Win32.SelectObject(memDc, hBitmap);

                    var size = new Win32.Size(bitmap.Width, bitmap.Height);
                    var pointSource = new Win32.Point(0, 0);
                    var topPos = new Win32.Point(Left, Top);
                    var blend = new Win32.BLENDFUNCTION
                    {
                        BlendOp = Win32.AC_SRC_OVER,
                        BlendFlags = 0,
                        SourceConstantAlpha = opacity,
                        AlphaFormat = Win32.AC_SRC_ALPHA
                    };

                    Win32.UpdateLayeredWindow(Handle, screenDc, ref topPos, ref size, memDc, ref pointSource, 0, ref blend,
                        Win32.ULW_ALPHA);
                }
                finally
                {
                    Win32.ReleaseDC(IntPtr.Zero, screenDc);
                    if (hBitmap != IntPtr.Zero)
                    {
                        Win32.SelectObject(memDc, oldBitmap);
                        //Windows.DeleteObject(hBitmap); // The documentation says that we have to use the Windows.DeleteObject... but since there is no such method I use the normal DeleteObject from Win32 GDI and it's working fine without any resource leak.
                        Win32.DeleteObject(hBitmap);
                    }
                    Win32.DeleteDC(memDc);
                }
            }
        }


        // class that exposes needed win32 gdi functions.
        internal static class Win32
        {
            public enum Bool
            {
                False = 0,
                True
            };

            public const Int32 ULW_COLORKEY = 0x00000001;
            public const Int32 ULW_ALPHA = 0x00000002;
            public const Int32 ULW_OPAQUE = 0x00000004;

            public const byte AC_SRC_OVER = 0x00;
            public const byte AC_SRC_ALPHA = 0x01;

            [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
            public static extern IntPtr CreateRoundRectRgn
                (
                int nLeftRect, // x-coordinate of upper-left corner
                int nTopRect, // y-coordinate of upper-left corner
                int nRightRect, // x-coordinate of lower-right corner
                int nBottomRect, // y-coordinate of lower-right corner
                int nWidthEllipse, // height of ellipse
                int nHeightEllipse // width of ellipse
                );

            [DllImport("User32.dll", SetLastError = true)]
            public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

            /// <summary>
            ///     Changes an attribute of the specified window. The function also sets the 32-bit (long) value at the specified
            ///     offset into the extra window memory.
            /// </summary>
            /// <param name="hWnd">A handle to the window and, indirectly, the class to which the window belongs..</param>
            /// <param name="nIndex">
            ///     The zero-based offset to the value to be set. Valid values are in the range zero through the
            ///     number of bytes of extra window memory, minus the size of an integer. To set any other value, specify one of the
            ///     following values: GWL_EXSTYLE, GWL_HINSTANCE, GWL_ID, GWL_STYLE, GWL_USERDATA, GWL_WNDPROC
            /// </param>
            /// <param name="dwNewLong">The replacement value.</param>
            /// <returns>
            ///     If the function succeeds, the return value is the previous value of the specified 32-bit integer.
            ///     If the function fails, the return value is zero. To get extended error information, call GetLastError.
            /// </returns>
            [DllImport("User32.dll")]
            public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);


            [DllImport("User32.dll", ExactSpelling = true, SetLastError = true)]
            public static extern Bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref Point pptDst, ref Size psize,
                IntPtr hdcSrc, ref Point pprSrc, Int32 crKey, ref BLENDFUNCTION pblend, Int32 dwFlags);

            [DllImport("User32.dll", ExactSpelling = true, SetLastError = true)]
            public static extern IntPtr GetDC(IntPtr hWnd);

            [DllImport("User32.dll", ExactSpelling = true)]
            public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

            [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
            public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

            [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
            public static extern Bool DeleteDC(IntPtr hdc);

            [DllImport("gdi32.dll", ExactSpelling = true)]
            public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

            [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
            public static extern Bool DeleteObject(IntPtr hObject);

            [StructLayout(LayoutKind.Sequential, Pack = 1)]
            private struct ARGB
            {
                public readonly byte Blue;
                public readonly byte Green;
                public readonly byte Red;
                public readonly byte Alpha;
            }


            [StructLayout(LayoutKind.Sequential, Pack = 1)]
            public struct BLENDFUNCTION
            {
                public byte BlendOp;
                public byte BlendFlags;
                public byte SourceConstantAlpha;
                public byte AlphaFormat;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct Point
            {
                public Int32 x;
                public Int32 y;

                public Point(Int32 x, Int32 y)
                {
                    this.x = x;
                    this.y = y;
                }
            }


            [StructLayout(LayoutKind.Sequential)]
            public struct Size
            {
                public Int32 cx;
                public Int32 cy;

                public Size(Int32 cx, Int32 cy)
                {
                    this.cx = cx;
                    this.cy = cy;
                }
            }
        }

    }

}
