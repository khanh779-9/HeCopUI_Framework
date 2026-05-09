using HeCopUI_Framework.Structs;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System;

namespace HeCopUI_Framework.Controls.Container
{
    [ToolboxBitmap(typeof(Panel))]
    public partial class HPanel : Panel
    {
        public HPanel()
        {
            SetStyle(GetAppResources.SetControlStyles(), true);
            BackColor = Color.Transparent;
        }

        private Color panelColor1 = Color.LightGray;
        public Color PanelColor1
        {
            get { return panelColor1; }
            set
            {
                panelColor1 = value; Invalidate();
            }
        }

        private Color panelColor2 = Color.PeachPuff;
        public Color PanelColor2
        {
            get { return panelColor2; }
            set
            {
                panelColor2 = value; Invalidate();
            }
        }

        private Color _borderColor = Color.Transparent;
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value; Invalidate();
            }
        }

        private CornerRadius _radius = new CornerRadius();
        public CornerRadius Radius
        {
            get { return _radius; }
            set
            {
                _radius = value; Invalidate();
            }
        }

        private int _borderThickness = 0;
        public int BorderThickness
        {
            get { return _borderThickness; }
            set
            {
                _borderThickness = value; Invalidate();
            }
        }

        private bool roundTopLeft = true;
        public bool RoundTopLeft
        {
            get => roundTopLeft;
            set
            {
                roundTopLeft = value; Invalidate();
            }
        }

        private bool roundTopRight = true;
        public bool RoundTopRight
        {
            get => roundTopRight;
            set
            {
                roundTopRight = value; Invalidate();
            }
        }

        private bool roundBottomLeft = true;
        public bool RoundBottomLeft
        {
            get => roundBottomLeft;
            set
            {
                roundBottomLeft = value; Invalidate();
            }
        }

        private bool roundBottomRight = true;
        public bool RoundBottomRight
        {
            get => roundBottomRight;
            set
            {
                roundBottomRight = value; Invalidate();
            }
        }

        private LinearGradientMode LinearGradient = LinearGradientMode.Vertical;
        public LinearGradientMode GradientMode
        {
            get { return LinearGradient; }
            set
            {
                LinearGradient = value; Invalidate();
            }
        }

        private Padding shadowPadding = new Padding(0, 0, 0, 0);
        public Padding ShadowPadding
        {
            get { return shadowPadding; }
            set
            {
                shadowPadding = value; Invalidate();
            }
        }

        private Color shadownColor = Color.FromArgb(100, 0, 0, 0);
        public Color ShadowColor
        {
            get { return shadownColor; }
            set
            {
                shadownColor = value; Invalidate();
            }
        }

        private int shadowRad = 5;
        public int ShadowRadius
        {
            get { return shadowRad; }
            set
            {
                shadowRad = value; Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (GraphicsPath gp = HeCopUI_Framework.Helper.DrawHelper.SetRoundedCornerRectangle(new RectangleF(ShadowPadding.Left, ShadowPadding.Top,
              Width - ShadowPadding.Right - ShadowPadding.Left, Height - ShadowPadding.Bottom - ShadowPadding.Top), Radius, BorderThickness))
            using (LinearGradientBrush LB = new LinearGradientBrush(gp.GetBounds(), panelColor1, panelColor2, LinearGradient))
            using (GraphicsPath sgp = HeCopUI_Framework.Helper.DrawHelper.SetRoundedCornerRectangle(new RectangleF(0, 0, Width, Height), Radius))
            using (Bitmap Shado = HeCopUI_Framework.Utils.DropShadow.Create(sgp, ShadowColor, shadowRad))
            {
                Shado.MakeTransparent();
                using (Graphics shadowGraphics = Graphics.FromImage(Shado))
                {
                    Helper.GraphicsHelper.SetHightGraphics(shadowGraphics);
                    Helper.GraphicsHelper.SetHightGraphics(e.Graphics);
                    shadowGraphics.FillPath(LB, gp);
                    if (BorderThickness > 0)
                        shadowGraphics.DrawPath(new Pen(_borderColor, BorderThickness) { Alignment = PenAlignment.Inset }, gp);
                }

                using (var a = new TextureBrush(Shado))
                    e.Graphics.FillPath(a, sgp);
            }
        }
    }
}
