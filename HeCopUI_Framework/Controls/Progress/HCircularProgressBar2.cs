using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls.Progress
{
    [ToolboxBitmap(typeof(HCircularProgressBar2), "Bitmaps.CircleProgress.bmp")]
    public partial class HCircularProgressBar2 : Control
    {
        #region Enums

        public enum ProgressShapeType
        {
            Round,
            Flat
        }

        public enum TextModeVisible
        {
            None,
            Value,
            Percentage,
            Custom
        }

        #endregion

        #region Private Variables

        private long _Value;
        private long _Maximum = 100;
        private int _LineWitdh = 1;
        private float _BarWidth = 14f;

        private Color _ProgressColor1 = Global.PrimaryColors.ProgressBarColor1;
        private Color _ProgressColor2 = Global.PrimaryColors.ProgressBarColor1;
        private Color _LineColor = Color.Silver;
        private LinearGradientMode _GradientMode = LinearGradientMode.ForwardDiagonal;
        private ProgressShapeType ProgressShapeVal;
        private TextModeVisible ProgressTextMode;

        #endregion

        #region Contructor

        public HCircularProgressBar2()
        {
            SetStyle(GetAppResources.SetControlStyles(), true);
            BackColor = SystemColors.Control;
            ForeColor = Color.DimGray;

            Size = new Size(130, 130);
            Font = new Font("Segoe UI", 15);
            MinimumSize = new Size(100, 100);
            DoubleBuffered = true;

            LineWidth = 1;
            LineColor = Color.DimGray;

            Value = 57;
            ProgressShape = ProgressShapeType.Flat;
            TextMode = TextModeVisible.Percentage;
        }

        #endregion

        #region Public Custom Properties

        /// <summary>Gets or sets value to show value progress.</summary>
        [Description("Gets or sets value to show value progress.")]
        public long Value
        {
            get { return _Value; }
            set
            {
                if (value > _Maximum)
                    value = _Maximum;
                _Value = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets maximum value.
        /// </summary>

        [Description("Gets or sets maximum value.")]
        public long Maximum
        {
            get { return _Maximum; }
            set
            {
                if (value < 1)
                    value = 1;
                _Maximum = value;
                Invalidate();
            }
        }

        public Color BarColor1
        {
            get { return _ProgressColor1; }
            set
            {
                _ProgressColor1 = value;
                Invalidate();
            }
        }


        public Color BarColor2
        {
            get { return _ProgressColor2; }
            set
            {
                _ProgressColor2 = value;
                Invalidate();
            }
        }

        public float BarWidth
        {
            get { return _BarWidth; }
            set
            {
                _BarWidth = value;
                Invalidate();
            }
        }

        public LinearGradientMode GradientMode
        {
            get { return _GradientMode; }
            set
            {
                _GradientMode = value;
                Invalidate();
            }
        }


        public Color LineColor
        {
            get { return _LineColor; }
            set
            {
                _LineColor = value;
                Invalidate();
            }
        }

        public int LineWidth
        {
            get { return _LineWitdh; }
            set
            {
                _LineWitdh = value;
                Invalidate();
            }
        }

        public ProgressShapeType ProgressShape
        {
            get { return ProgressShapeVal; }
            set
            {
                ProgressShapeVal = value;
                Invalidate();
            }
        }

        public TextModeVisible TextMode
        {
            get { return ProgressTextMode; }
            set
            {
                ProgressTextMode = value;
                Invalidate();
            }
        }

        public override string Text { get; set; }

        #endregion

        #region EventArgs

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            SetStandardSize();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            SetStandardSize();
        }

        protected override void OnPaintBackground(PaintEventArgs p)
        {
            base.OnPaintBackground(p);
        }

        #endregion

        #region Methods

        private void SetStandardSize()
        {
            int _Size = Math.Max(Width, Height);
            Size = new Size(_Size, _Size);
        }

        public void Increment(int Val)
        {
            _Value += Val;
            Invalidate();
        }

        public void Decrement(int Val)
        {
            _Value -= Val;
            Invalidate();
        }
        #endregion

        #region Events

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Bitmap bitmap = new Bitmap(Width, Height, System.Drawing.Imaging.PixelFormat.Format64bppPArgb))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
                    graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                    graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                    //graphics.Clear(Color.Transparent); //<-- this.BackColor, SystemColors.Control, Color.Transparent

                    PaintTransparentBackground(this, e);

                    //Dibuja el circulo blanco interior:
                    using (Brush mBackColor = new SolidBrush(BackColor))
                    {
                        graphics.FillEllipse(mBackColor,
                                18, 18,
                                (Width - 0x30) + 12,
                                (Height - 0x30) + 12);
                    }
                    // Dibuja la delgada Linea gris del medio:
                    using (Pen pen2 = new Pen(LineColor, LineWidth))
                    {
                        graphics.DrawEllipse(pen2,
                            18, 18,
                          (Width - 0x30) + 12,
                          (Height - 0x30) + 12);
                    }

                    //Dibuja la Barra de Progreso
                    using (LinearGradientBrush brush = new LinearGradientBrush(ClientRectangle,
                        _ProgressColor1, _ProgressColor2, GradientMode))
                    {
                        using (Pen pen = new Pen(brush, BarWidth))
                        {
                            switch (ProgressShapeVal)
                            {
                                case ProgressShapeType.Round:
                                    pen.StartCap = LineCap.Round;
                                    pen.EndCap = LineCap.Round;
                                    break;

                                case ProgressShapeType.Flat:
                                    pen.StartCap = LineCap.Flat;
                                    pen.EndCap = LineCap.Flat;
                                    break;
                            }

                            //Aqui se dibuja realmente la Barra de Progreso
                            graphics.DrawArc(pen,
                                0x12, 0x12,
                                (Width - 0x23) - 2,
                                (Height - 0x23) - 2,
                                -90,
                                (int)Math.Round((double)((360.0 / _Maximum) * _Value)));
                        }
                    }

                    #region Dibuja el Texto de Progreso

                    switch (TextMode)
                    {
                        case TextModeVisible.None:
                            Text = string.Empty;
                            break;

                        case TextModeVisible.Value:
                            Text = _Value.ToString();
                            break;

                        case TextModeVisible.Percentage:
                            Text = Convert.ToString(Convert.ToInt32((100 / _Maximum) * _Value)) + "%";
                            break;

                        default:
                            break;
                    }

                    if (Text != string.Empty)
                    {
                        using (Brush FontColor = new SolidBrush(ForeColor))
                        {
                            SizeF MS = graphics.MeasureString(Text, Font);


                            //Texto del Control:
                            graphics.DrawString(Text, Font, FontColor,
                                Convert.ToInt32(Width / 2 - MS.Width / 2),
                                Convert.ToInt32(Height / 2 - MS.Height / 2));
                        }
                    }

                    #endregion

                    e.Graphics.DrawImage(bitmap, 0, 0);
                    graphics.Dispose();
                    bitmap.Dispose();
                }
            }
        }

        private static void PaintTransparentBackground(Control c, PaintEventArgs e)
        {
            if (c.Parent == null || !Application.RenderWithVisualStyles)
                return;

            ButtonRenderer.DrawParentBackground(e.Graphics, c.ClientRectangle, c);
        }

        /// <summary>Dibuja un Circulo Relleno de Color con los Bordes perfectos.</summary>
        /// <param name="g">'Canvas' del Objeto donde se va a dibujar</param>
        /// <param name="brush">Color y estilo del relleno</param>
        /// <param name="centerX">Centro del Circulo, en el eje X</param>
        /// <param name="centerY">Centro del Circulo, en el eje Y</param>
        /// <param name="radius">Radio del Circulo</param>
        private void FillCircle(Graphics g, Brush brush, float centerX, float centerY, float radius)
        {
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            using (System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath())
            {
                g.FillEllipse(brush, centerX - radius, centerY - radius,
                          radius + radius, radius + radius);
            }
        }

        #endregion
    }
}