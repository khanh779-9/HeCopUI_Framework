using HeCopUI_Framework.Global;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls.Gauge
{
    [ToolboxBitmap(typeof(ProgressBar))]
    [DefaultEvent("ValueChanged")]
    public partial class HSolidGauge : Control
    {
        public HSolidGauge()
        {
            SetStyle(GetAppResources.SetControlStyles(), true);
            DoubleBuffered = true;
            //ForeColor = Color.FromArgb(64, 64, 64);
            Size = new Size(91, 54);
            timerAni = new Timer
            {
                Interval = Interval
            };
            timerAni.Tick += TimerAni_Tick;

            BackColor = Color.Transparent;
        }

        private void TimerAni_Tick(object sender, EventArgs e)
        {

            if (UseAnimation == false) timerAni.Stop();
            else
            {
                if (AniVa != _Value)
                {
                    if (AniVa > _Value)
                    {
                        _Value++;


                    }
                    if (AniVa < _Value)
                    {
                        _Value--;

                    }
                    Invalidate();
                }
                else timerAni.Stop();

            }
        }

        int AniVa = 0;

        public int Interval { get; set; } = 10;
        public bool UseAnimation { get; set; } = false;

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

        private Color _GaugeColor1 = PrimaryColors.GaugeBarColor;
        private Color _GaugeColor2 = PrimaryColors.GaugeBarColor;
        private LineCap LC = LineCap.Round;
        public LineCap ShapeType
        {
            get { return LC; }
            set
            {
                LC = value; Invalidate();
            }

        }

        Timer timerAni = new Timer();

        private int _Value = 0;

        public int MaximumValue
        {
            get { return m_MaxValue; }
            set
            {
                m_MaxValue = value; Invalidate();
            }
        }

        public int Value
        {
            get
            {
                if (UseAnimation == false) return _Value;
                else return AniVa;
            }
            set
            {

                if (UseAnimation == false)
                {
                    if (value > m_MaxValue) _Value = m_MaxValue;
                    else if (value < m_MinValue) _Value = m_MinValue;
                    else AniVa = _Value = value;
                }
                if (UseAnimation == true)
                {
                    if (value > m_MaxValue)
                    {
                        AniVa = m_MaxValue;



                    }
                    else if (value < m_MinValue)
                    {
                        AniVa = m_MinValue;


                    }
                    else AniVa = value; timerAni.Start();
                }
                if (ValueChanged != null)
                {
                    ValueChanged(this, EventArgs.Empty);
                }
                Invalidate();
            }
        }

        public Color GaugeColor1
        {
            get { return _GaugeColor1; }
            set
            {
                _GaugeColor1 = value; Invalidate();
            }
        }

        public Color GaugeColor2
        {
            get { return _GaugeColor2; }
            set
            {
                _GaugeColor2 = value; Invalidate();
            }
        }

        private int _solidGaugeWidth = 12;
        public int SolidGaugeWidth
        {
            get { return _solidGaugeWidth; }
            set
            {
                _solidGaugeWidth = value; Invalidate();
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            SetStandardSize();
            base.OnSizeChanged(e);
        }

        private void SetStandardSize()
        {
            if (Size.Width < 101) Size = new Size(100, 100);
            int _Size = Math.Max(Width, Height);
            Size = new Size(_Size, _Size);
        }

        private Color _baseGauge = HeCopUI_Framework.Global.PrimaryColors.BaseGaugeColor;
        public Color BaseGauge
        {
            get { return _baseGauge; }
            set
            {
                _baseGauge = value; Invalidate();
            }

        }

        private System.Drawing.Text.TextRenderingHint textRenderHint = Helper.TextHelper.SetTextRender();
        public System.Drawing.Text.TextRenderingHint TextRenderHint
        {
            get { return textRenderHint; }
            set
            {
                textRenderHint = value; Invalidate();
            }
        }

        private Color _circularDiskColor = Color.DimGray;
        public Color CircularDiskColor
        {
            get { return _circularDiskColor; }
            set
            {
                _circularDiskColor = value; Invalidate();
            }
        }

        private int _circularSize = 20;
        public int CircularSize
        {
            get { return _circularSize; }
            set
            {
                _circularSize = value; Invalidate();
            }
        }

        public enum DiskSizeMode { Auto, Custom }
        private DiskSizeMode circularSizeType = DiskSizeMode.Auto;
        public DiskSizeMode CircularDiskSizeType
        {
            get { return circularSizeType; }
            set
            {
                circularSizeType = value; Invalidate();
            }
        }

        public delegate void ValueChangedEventHandler(object sender, EventArgs e);
        public event ValueChangedEventHandler ValueChanged;

        public enum GaugeType { Transition, Gradient }
        private GaugeType gaugeMode = GaugeType.Gradient;
        /// <summary>
        /// Sets or gets mode for gauge to fill color of value.
        /// </summary>
        public GaugeType GaugeMode
        {
            get { return gaugeMode; }
            set
            {
                gaugeMode = value; Invalidate();
            }
        }

        int numberOfDivisions = 10;
        public int NumberOfOYVissible
        {
            get { return numberOfDivisions; }
            set
            {
                numberOfDivisions = value; Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Helper.GraphicsHelper.SetHightGraphics(e.Graphics);
            e.Graphics.TextRenderingHint = TextRenderHint;
            using (Bitmap bitmap = new Bitmap(Width, Height, System.Drawing.Imaging.PixelFormat.Format64bppPArgb))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    Helper.GraphicsHelper.SetHightGraphics(graphics);
                    graphics.TextRenderingHint = TextRenderHint;
                    Brush brush = null;
                    if (gaugeMode == GaugeType.Gradient)
                        brush = new LinearGradientBrush(ClientRectangle, _GaugeColor1, _GaugeColor2, LBV);
                    if (gaugeMode == GaugeType.Transition)
                    {
                        double blend = (double)_Value / m_MaxValue;
                        brush = new SolidBrush(HeCopUI_Framework.Helper.DrawHelper.BlendColor(GaugeColor1, GaugeColor2, (int)(blend * 255)));
                    }
                    using (Pen pen = new Pen(brush, _solidGaugeWidth))
                    using (Pen BasePen = new Pen(new SolidBrush(_baseGauge), _solidGaugeWidth - 1.5f))
                    {
                        BasePen.StartCap = BasePen.EndCap = LC;
                        graphics.DrawArc(BasePen, 10, 10, (Width - 20) - 2, (Height - 20) - 2, 135, 270);
                        pen.StartCap = pen.EndCap = LC;
                        graphics.DrawArc(pen, 10, 10, (Width - 20) - 2, (Height - 20) - 2, 135, _Value * 270 / m_MaxValue);
                    }

                    Single brushAngle = (m_BaseArcStart + (_Value - m_MinValue) * m_BaseArcSweep / (m_MaxValue - m_MinValue)) % 360;
                    if (brushAngle < 0) brushAngle += 360;
                    Double needleAngle = brushAngle * Math.PI / 180;
                    #region Needle
                    int needleRadius = 0;
                    switch (NeedleHeight)
                    {
                        case NeedleLongType.Custom:
                            needleRadius = needleLong;
                            break;
                        case NeedleLongType.Auto:
                            needleRadius = Width / 2 - _solidGaugeWidth;
                            //center = new Point((int)(Center.X * widthFactor), (int)(Center.Y * heightFactor));
                            break;
                    }
                    Point startPoint = new Point((int)(Width / 2 - needleRadius / 8 * Math.Cos(needleAngle)), (int)(Height / 2 - needleRadius / 8 * Math.Sin(needleAngle)));
                    Point endPoint = new Point((int)(Width / 2 + needleRadius * Math.Cos(needleAngle)), (Int32)(Height / 2 + needleRadius * Math.Sin(needleAngle)));
                    int needleWidth = needleThickness;

                    SizeF TextSize = new SizeF(0, 0);
                    switch (TT)
                    {
                        case TextType.Value:
                            TextSize = graphics.MeasureString(_Value.ToString(), Font);
                            break;
                        case TextType.Percentage:
                            TextSize = graphics.MeasureString(_Value.ToString() + "%", Font);
                            break;
                    }

                    using (var pnLine = new Pen(needleColor, needleWidth))
                    {
                        pnLine.EndCap = needleType;
                        graphics.DrawLine(pnLine, Width / 2, Height / 2, endPoint.X, endPoint.Y);
                        //e.Graphics.DrawLine(pnLine, Width/2, Height /2, startPoint.X, startPoint.Y);
                    }
                    using (var brDisk = new SolidBrush(_circularDiskColor))
                    {

                        switch (circularSizeType)
                        {
                            case DiskSizeMode.Auto:
                                SizeF Di = graphics.MeasureString(m_MaxValue + "%", Font);
                                float ma = Math.Max(Di.Width, Di.Height);
                                graphics.FillEllipse(brDisk, Width / 2 - ma / 2 - 4, Height / 2 - ma / 2 - 4, ma + 6, ma + 6);
                                break;
                            case DiskSizeMode.Custom:
                                graphics.FillEllipse(brDisk, Width / 2 - _circularSize / 2, Height / 2 - _circularSize / 2, _circularSize, _circularSize);
                                break;
                        }
                    }
                    #endregion


                    #region MajorLocation

                    // Vẽ các chỉ số trên đường tròn, dựa trên numberOfDivisions theo đường vòng cung
                    for (int i = 0; i <= numberOfDivisions; i++)
                    {
                        Single minAngle = (m_BaseArcStart + (i * 10) * m_BaseArcSweep / (100 - 0)) % 360;
                        if (minAngle < 0) minAngle += 360;
                        Double aneedleAngle = minAngle * Math.PI / 180;

                        // Giảm bán kính với hệ số chung
                        int smallerRadius = Width / 2 - SolidGaugeWidth - 16;
                        PointF minPoint = new PointF((float)(Width / 2 + smallerRadius * Math.Cos(aneedleAngle)), (float)(Height / 2 + smallerRadius * Math.Sin(aneedleAngle)));

                        if (ShowMajor == true)
                        {
                            //SizeF minRe = graphics.MeasureString(m_MinValue.ToString(), Font);
                            e.Graphics.DrawString((i * 10).ToString(), new Font(Font.Name, 8), new SolidBrush(ForeColor), minPoint.X - SolidGaugeWidth / 2 - 2, minPoint.Y + SolidGaugeWidth / 2 - 14);
                        }
                    }


                    #endregion
                    e.Graphics.DrawImage(bitmap, 0, 0);

                    switch (TT)
                    {
                        case TextType.Value:
                            //TextSize = graphics.MeasureString(_Value.ToString(), Font);
                            e.Graphics.DrawString(_Value.ToString(), Font, new SolidBrush(valueTextColor), Width / 2 - TextSize.Width / 2, Height / 2 - TextSize.Height / 2);
                            break;
                        case TextType.Percentage:
                            //TextSize = graphics.MeasureString(_Value.ToString() + "%", Font);
                            e.Graphics.DrawString(_Value.ToString() + "%", Font, new SolidBrush(valueTextColor), Width / 2 - TextSize.Width / 2, Height / 2 - TextSize.Height / 2);
                            break;
                    }
                    graphics.Dispose();
                }
            }
            base.OnPaint(e);
        }

        private Color valueTextColor = Color.White;
        public Color ValueTextColor
        {
            get { return valueTextColor; }
            set
            {
                valueTextColor = value; Invalidate();
            }
        }

        private System.Drawing.Drawing2D.LinearGradientMode LBV = LinearGradientMode.Horizontal;
        public System.Drawing.Drawing2D.LinearGradientMode GradientMode
        {
            get { return LBV; }
            set
            {
                LBV = value; Invalidate();
            }
        }

        private LineCap needleType = LineCap.Flat;
        public LineCap NeedleType
        {
            get { return needleType; }
            set
            {
                needleType = value; Invalidate();
            }
        }

        private Color needleColor = Global.PrimaryColors.BackNormalColor1;
        public Color NeedleColor
        {
            get { return needleColor; }
            set
            {
                needleColor = value; Invalidate();
            }
        }

        private bool showMajor = true;
        public bool ShowMajor
        {
            get { return showMajor; }
            set
            {
                showMajor = value; Invalidate();
            }
        }

        public enum NeedleLongType { Auto, Custom }
        public NeedleLongType NeedleHeight { get; set; } = NeedleLongType.Auto;

        private int needleThickness = 2;
        public int NeedleThickness
        {
            get { return needleThickness; }
            set
            {
                needleThickness = value; Invalidate();
            }
        }

        private int needleLong = 50;
        public int NeedleLong
        {
            get { return needleLong; }
            set
            {
                needleLong = value; Invalidate();
            }
        }

        private int m_MinValue = 0;
        private int m_MaxValue = 100;

        //private Int32 m_BaseArcRadius = 50;
        private Int32 m_BaseArcStart = 135;
        private Int32 m_BaseArcSweep = 270;
        //private Int32 m_BaseArcWidth = 2;

        public enum TextType
        {
            Value, Percentage, None
        }

        private TextType TT = TextType.Percentage;
        public TextType GaugeTextType
        {
            get { return TT; }
            set
            {
                TT = value; Invalidate();
            }
        }
    }
}
