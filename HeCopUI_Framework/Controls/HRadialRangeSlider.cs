using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls
{
    public enum TextMode
    {
        None,
        FromValue1ToValue2,
        Value1_Value2
    }

    public class HRadialRangeSlider : Control
    {
        private int minValue = 0;
        private int maxValue = 100;
        private int startAngle = 137;
        private int endAngle = 265;
        private bool isDraggingStart = false;
        private bool isDraggingEnd = false;

        public int MinValue
        {
            get { return minValue; }
            set
            {
                minValue = value;
                Invalidate();
            }
        }

        public int MaxValue
        {
            get { return maxValue; }
            set
            {
                maxValue = value;
                Invalidate();
            }
        }

        public int StartAngle
        {
            get { return startAngle; }
            set
            {
                startAngle = value;
                Invalidate();
            }
        }

        public int EndAngle
        {
            get { return endAngle; }
            set
            {
                endAngle = value;
                Invalidate();
            }
        }

        int value1 = 0;
        public int Value1
        {
            get
            {
                return value1;
            }
            set
            {
                if (value < MinValue) value1 = MinValue;
                else if (value >= Value2 - 1) value1 = Value2 - 1;
                else value1 = value;
                Invalidate();
            }
        }

        int value2 = 100;
        public int Value2
        {
            get
            {
                return value2;
            }
            set
            {
                if (value <= Value1)
                    value2 = Value1 + 1;
                else if (value > MaxValue)
                    value2 = MaxValue;
                else
                    value2 = value;

                Invalidate();
            }
        }

        public HRadialRangeSlider()
        {
            SetStyle(ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.Opaque, false);

        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            isDraggingStart = isDraggingEnd = false;
            base.OnMouseUp(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (!DesignMode)
            {
                if (IsPointInStartHandle(e.Location)) isDraggingStart = true;
                else if (IsPointInEndHandle(e.Location)) isDraggingEnd = true;
                else isDraggingStart = isDraggingEnd = false;
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (!DesignMode)
            {
                if (isDraggingStart)
                {
                    int tmp1 = CalculateValue(e.Location);
                    if (tmp1 >= MinValue && tmp1 < Value2)
                        Value1 = tmp1;
                }
                else if (isDraggingEnd)
                {
                    int tmp2 = CalculateValue(e.Location);
                    if (tmp2 > Value1 && tmp2 <= MaxValue)
                        Value2 = tmp2;
                }
            }
            Invalidate();
            base.OnMouseMove(e);
        }

        private PointF CalculateHandlePosition(int value)
        {
            float angle = (value - minValue) * EndAngle / (maxValue - minValue);
            float radius = ((Math.Min(Width, Height) - 10) * arcSize / 100) / 2;
            float x = Width / 2 + radius * (float)Math.Cos((angle + StartAngle) * Math.PI / 180);
            float y = Height / 2 + radius * (float)Math.Sin((angle + StartAngle) * Math.PI / 180);
            return new PointF(x, y);
        }

        private int CalculateValue(PointF point)
        {
            return (CalculateAngle(point) * (maxValue - minValue)) / EndAngle;

        }

        private int CalculateAngle(PointF point)
        {
            int dx = (int)(point.X - Width / 2);
            int dy = (int)(point.Y - Height / 2);
            int angle = (int)(Math.Atan2(dy, dx) * 180 / Math.PI);
            if (angle < 0) angle += 360;
            // Áp dụng StartAngle vào góc tính được
            angle = (angle + 360 - StartAngle) % 360;
            return angle;
        }

        private bool IsPointInStartHandle(PointF point)
        {
            return Math.Abs(point.X - CalculateHandlePosition(Value1).X) < 10 && Math.Abs(point.Y - CalculateHandlePosition(Value1).Y) < 10;
        }

        private bool IsPointInEndHandle(PointF point)
        {
            return Math.Abs(point.X - CalculateHandlePosition(Value2).X) < 10 && Math.Abs(point.Y - CalculateHandlePosition(Value2).Y) < 10;
        }

        int arcSize = 80;

        public int SliderScale
        {
            get { return arcSize; }
            set
            {
                if (value <= 40)
                    arcSize = 40;
                else if (value > 100)
                    arcSize = 100;
                else
                    arcSize = value;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawRadialRangeSlider(e.Graphics);
        }

        Color thumbStart = Color.Gray;
        Color thumbEnd = Color.FromArgb(0, 168, 148);

        public Color ThumbStartColor
        {
            get { return thumbStart; }
            set { thumbStart = value; Invalidate(); }
        }

        public Color ThumbEndColor
        {
            get { return thumbEnd; }
            set
            {
                thumbEnd = value; Invalidate();
            }
        }

        Color bar1 = Color.FromArgb(70, 70, 70);
        Color bar2 = Color.FromArgb(0, 68, 48);
        Color slide1 = Color.DarkSlateGray;
        Color slide2 = Color.SeaGreen;

        public Color BarColor1
        {
            get { return bar1; }
            set
            {
                bar1 = value; Invalidate();
            }
        }

        public Color BarColor2
        {
            get { return bar2; }
            set
            {
                bar2 = value; Invalidate();
            }
        }

        public Color SlideColor1
        {
            get { return slide1; }
            set
            {
                slide1 = value; Invalidate();
            }
        }

        public Color SlideColor2
        {
            get { return slide2; }
            set
            {
                slide2 = value; Invalidate();
            }
        }

        int barThick = 2;
        public int BarThickness
        {
            get { return barThick; }
            set
            {
                barThick = value; Invalidate();
            }
        }

        int slideThic = 4;
        public int SlideThickness
        {
            get
            {
                return slideThic;
            }
            set
            {
                slideThic = value; Invalidate();
            }
        }



        TextMode textMode = TextMode.Value1_Value2;
        public TextMode TextMode
        {
            get { return textMode; }
            set
            {
                textMode = value; Invalidate();
            }
        }

        LinearGradientMode linearGradientMode = LinearGradientMode.Horizontal;
        public LinearGradientMode LinearGradientMode
        {
            get { return linearGradientMode; }
            set
            {
                linearGradientMode = value; Invalidate();
            }
        }

        Color textColor = Color.WhiteSmoke;
        public Color TextColor
        {
            get { return textColor; }
            set
            {
                textColor = value; Invalidate();
            }
        }

        private void DrawRadialRangeSlider(Graphics g)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            float radius = ((Math.Min(Width, Height) - 10) * arcSize / 100) / 2;
            float centerX = (Width) / 2;
            float centerY = (Height) / 2;


            // Draw the range
            using (var pen = new Pen(new LinearGradientBrush(ClientRectangle, slide1, slide2, linearGradientMode), slideThic))
            {

                g.DrawArc(new Pen(new LinearGradientBrush(ClientRectangle, bar1, bar2, linearGradientMode), barThick), centerX - radius, centerY - radius,
                    radius * 2, radius * 2, StartAngle, endAngle);

                g.DrawArc(pen, centerX - radius, centerY - radius, radius * 2, radius * 2, StartAngle + (Value1 * EndAngle / MaxValue),
                  (Value2 * EndAngle / MaxValue) - (Value1 * EndAngle / MaxValue));

            }

            // Draw the handles
            using (var brush = new SolidBrush(thumbStart))
            {
                PointF startHandlePos = CalculateHandlePosition(Value1);
                g.FillEllipse(brush, startHandlePos.X - 5, startHandlePos.Y - 5, 10, 10);
            }

            using (var brush = new SolidBrush(thumbEnd))
            {
                PointF endHandlePos = CalculateHandlePosition(Value2);
                g.FillEllipse(brush, endHandlePos.X - 5, endHandlePos.Y - 5, 10, 10);
            }

            StringFormat s = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            string te = "";
            switch (textMode)
            {
                case TextMode.Value1_Value2:
                    te = Value1 + " - " + Value2;
                    break;
                case TextMode.FromValue1ToValue2:
                    te = "From: " + Value1 + "\nTo: " + Value2;
                    break;
            }
            if (textMode != TextMode.None)
                g.DrawString(te, Font, new SolidBrush(textColor), new RectangleF(0, 0, Width, Height), s);
        }
    }
}
