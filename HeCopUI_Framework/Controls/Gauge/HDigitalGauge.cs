using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls.Gauge
{
    [ToolboxBitmap(typeof(ProgressBar))]
    public partial class HDigitalGauge : Control
    {
        public HDigitalGauge()
        {
            SetStyle(GetAppResources.SetControlStyles(), true);
            BackColor = Color.Transparent;
            NumberHeigh = 50;
            NumberColor = Color.FromArgb(0, 104, 255);
            GaugeColor = Color.FromArgb(60, 60, 60);
            BorderColor = Color.DarkGray;
            NumberBaseColor = Color.FromArgb(30, 0, 104, 255);
            BorderThickness = 5;
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            Helper.GraphicsHelper.SetHightGraphics(g);
            GraphicsPath gp = HeCopUI_Framework.Helper.DrawHelper.GetRoundPath(ClientRectangle, _radius);
            g.FillPath(new SolidBrush(_GaugeColor), gp);
            g.DrawPath(new Pen(new SolidBrush(_borderColor), _borderThickness) { Alignment = PenAlignment.Inset }, HeCopUI_Framework.Helper.DrawHelper.GetRoundPath(ClientRectangle, _radius, BorderThickness));
            DisplayNumber(g, _value, new RectangleF(Width / 2 - recw / 2 - 2, Height / 2 - NumberHeigh / 2, recw - 4, NumberHeigh));

        }

        private Color _borderColor = Color.Gray;
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value; Invalidate();
            }
        }

        private int _borderThickness = 2;
        public int BorderThickness
        {
            get { return _borderThickness; }
            set
            {
                _borderThickness = value; Invalidate();
            }
        }

        private Color _GaugeColor = Color.FromArgb(64, 64, 64);
        public Color GaugeColor
        {
            get { return _GaugeColor; }
            set
            {
                _GaugeColor = value; Invalidate();
            }
        }




        private int _radius = 0;
        public int Radius
        {
            get { return _radius; }
            set
            {
                _radius = value; Invalidate();
            }
        }

        float recw;

        private float NumberHeigh = 20;
        public float NumberHeight
        {
            get { return NumberHeigh; }
            set
            {
                NumberHeigh = value;
                PerformLayout();
                Invalidate();
                ResumeLayout();
            }
        }

        public int MinimumValue { get; set; } = 0;

        private int _maximumValue = 100;
        public int MaximumValue
        {
            get { return _maximumValue; }
            set
            {
                _maximumValue = value; Invalidate();
            }
        }

#pragma warning disable CS3008 // Identifier is not CLS-compliant
        public int _value = 0;
#pragma warning restore CS3008 // Identifier is not CLS-compliant
        public int Value
        {
            get { return _value; }
            set
            {
                if (value <= MinimumValue) _value = MinimumValue;
                else if (value >= MaximumValue) _value = MaximumValue;
                else _value = value;
                PerformLayout();
                Invalidate();
                ResumeLayout();
            }
        }

        /// <summary>
        /// Displays the given number in the 7-Segement format.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="number"></param>
        /// <param name="drect"></param>
        private void DisplayNumber(Graphics g, float number, RectangleF drect)
        {
            try
            {
                string numa = "";
                for (int i = 0; i < MaximumValue.ToString().Length; i++)
                {
                    numa += "0";
                }
                string num = number.ToString(numa);
                num.PadLeft(3, '0');
                float shift = 0;
                if (number < 0)
                {
                    shift -= Width / 17;
                }
                bool drawDPS = false;
                char[] chars = num.ToCharArray();
                for (int i = 0; i < chars.Length; i++)
                {
                    char c = chars[i];
                    if (i < chars.Length - 1 && chars[i + 1] == '.')
                        drawDPS = true;
                    else
                        drawDPS = false;
                    if (c != '.')
                    {
                        if (c == '-')
                        {
                            DrawDigit(g, -1, new PointF(drect.X + shift, drect.Y), drawDPS, drect.Height);
                        }
                        else
                        {
                            DrawDigit(g, Int16.Parse(c.ToString()), new PointF(drect.X + shift, drect.Y), drawDPS, drect.Height);
                        }
                        recw = shift += 10 + NumberHeigh / 2;
                    }
                    else
                    {
                        recw = shift += 10 + NumberHeigh / 2;
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private Color outColor = (Color.FromArgb(40, Color.Black));
        private Color fillColor = Color.Black;

        public Color NumberBaseColor
        {
            get { return outColor; }
            set
            {
                outColor = value; Invalidate();
            }
        }

        public Color NumberColor
        {
            get { return fillColor; }
            set
            {
                fillColor = value; Invalidate();
            }
        }

        /// <summary>
        /// Draws a digit in 7-Segement format.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="number"></param>
        /// <param name="position"></param>
        /// <param name="dp"></param>
        /// <param name="height"></param>
        private void DrawDigit(Graphics g, int number, PointF position, bool dp, float height)
        {
            float width;
            width = 10F * height / 13;

            Pen outline = new Pen(outColor);
            Pen fillPen = new Pen(fillColor);

            #region Form Polygon Points
            //Segment A
            PointF[] segmentA = new PointF[5];
            segmentA[0] = segmentA[4] = new PointF(position.X + GetX(2.8F, width), position.Y + GetY(1F, height));
            segmentA[1] = new PointF(position.X + GetX(10, width), position.Y + GetY(1F, height));
            segmentA[2] = new PointF(position.X + GetX(8.8F, width), position.Y + GetY(2F, height));
            segmentA[3] = new PointF(position.X + GetX(3.8F, width), position.Y + GetY(2F, height));

            //Segment B
            PointF[] segmentB = new PointF[5];
            segmentB[0] = segmentB[4] = new PointF(position.X + GetX(10, width), position.Y + GetY(1.4F, height));
            segmentB[1] = new PointF(position.X + GetX(9.3F, width), position.Y + GetY(6.8F, height));
            segmentB[2] = new PointF(position.X + GetX(8.4F, width), position.Y + GetY(6.4F, height));
            segmentB[3] = new PointF(position.X + GetX(9F, width), position.Y + GetY(2.2F, height));

            //Segment C
            PointF[] segmentC = new PointF[5];
            segmentC[0] = segmentC[4] = new PointF(position.X + GetX(9.2F, width), position.Y + GetY(7.2F, height));
            segmentC[1] = new PointF(position.X + GetX(8.7F, width), position.Y + GetY(12.7F, height));
            segmentC[2] = new PointF(position.X + GetX(7.6F, width), position.Y + GetY(11.9F, height));
            segmentC[3] = new PointF(position.X + GetX(8.2F, width), position.Y + GetY(7.7F, height));

            //Segment D
            PointF[] segmentD = new PointF[5];
            segmentD[0] = segmentD[4] = new PointF(position.X + GetX(7.4F, width), position.Y + GetY(12.1F, height));
            segmentD[1] = new PointF(position.X + GetX(8.4F, width), position.Y + GetY(13F, height));
            segmentD[2] = new PointF(position.X + GetX(1.3F, width), position.Y + GetY(13F, height));
            segmentD[3] = new PointF(position.X + GetX(2.2F, width), position.Y + GetY(12.1F, height));

            //Segment E
            PointF[] segmentE = new PointF[5];
            segmentE[0] = segmentE[4] = new PointF(position.X + GetX(2.2F, width), position.Y + GetY(11.8F, height));
            segmentE[1] = new PointF(position.X + GetX(1F, width), position.Y + GetY(12.7F, height));
            segmentE[2] = new PointF(position.X + GetX(1.7F, width), position.Y + GetY(7.2F, height));
            segmentE[3] = new PointF(position.X + GetX(2.8F, width), position.Y + GetY(7.7F, height));

            //Segment F
            PointF[] segmentF = new PointF[5];
            segmentF[0] = segmentF[4] = new PointF(position.X + GetX(3F, width), position.Y + GetY(6.4F, height));
            segmentF[1] = new PointF(position.X + GetX(1.8F, width), position.Y + GetY(6.8F, height));
            segmentF[2] = new PointF(position.X + GetX(2.6F, width), position.Y + GetY(1.3F, height));
            segmentF[3] = new PointF(position.X + GetX(3.6F, width), position.Y + GetY(2.2F, height));

            //Segment G
            PointF[] segmentG = new PointF[7];
            segmentG[0] = segmentG[6] = new PointF(position.X + GetX(2F, width), position.Y + GetY(7F, height));
            segmentG[1] = new PointF(position.X + GetX(3.1F, width), position.Y + GetY(6.5F, height));
            segmentG[2] = new PointF(position.X + GetX(8.3F, width), position.Y + GetY(6.5F, height));
            segmentG[3] = new PointF(position.X + GetX(9F, width), position.Y + GetY(7F, height));
            segmentG[4] = new PointF(position.X + GetX(8.2F, width), position.Y + GetY(7.5F, height));
            segmentG[5] = new PointF(position.X + GetX(2.9F, width), position.Y + GetY(7.5F, height));

            //Segment DP
            #endregion

            #region Draw Segments Outline
            g.FillPolygon(outline.Brush, segmentA);
            g.FillPolygon(outline.Brush, segmentB);
            g.FillPolygon(outline.Brush, segmentC);
            g.FillPolygon(outline.Brush, segmentD);
            g.FillPolygon(outline.Brush, segmentE);
            g.FillPolygon(outline.Brush, segmentF);
            g.FillPolygon(outline.Brush, segmentG);
            #endregion

            #region Fill Segments
            //Fill SegmentA
            if (IsNumberAvailable(number, 0, 2, 3, 5, 6, 7, 8, 9))
            {
                g.FillPolygon(fillPen.Brush, segmentA);
            }

            //Fill SegmentB
            if (IsNumberAvailable(number, 0, 1, 2, 3, 4, 7, 8, 9))
            {
                g.FillPolygon(fillPen.Brush, segmentB);
            }

            //Fill SegmentC
            if (IsNumberAvailable(number, 0, 1, 3, 4, 5, 6, 7, 8, 9))
            {
                g.FillPolygon(fillPen.Brush, segmentC);
            }

            //Fill SegmentD
            if (IsNumberAvailable(number, 0, 2, 3, 5, 6, 8, 9))
            {
                g.FillPolygon(fillPen.Brush, segmentD);
            }

            //Fill SegmentE
            if (IsNumberAvailable(number, 0, 2, 6, 8))
            {
                g.FillPolygon(fillPen.Brush, segmentE);
            }

            //Fill SegmentF
            if (IsNumberAvailable(number, 0, 4, 5, 6, 7, 8, 9))
            {
                g.FillPolygon(fillPen.Brush, segmentF);
            }

            //Fill SegmentG
            if (IsNumberAvailable(number, 2, 3, 4, 5, 6, 8, 9, -1))
            {
                g.FillPolygon(fillPen.Brush, segmentG);
            }
            #endregion

            //Draw decimal point
            if (dp)
            {
                g.FillEllipse(fillPen.Brush, new RectangleF(
                    position.X + GetX(10F, width),
                    position.Y + GetY(12F, height),
                    width / 7,
                    width / 7));
            }
        }

        private bool IsNumberAvailable(int number, params int[] listOfNumbers)
        {
            if (listOfNumbers.Length > 0)
            {
                foreach (int i in listOfNumbers)
                {
                    if (i == number)
                        return true;
                }
            }
            return false;
        }



        private float GetX(float x, float width)
        {
            return x * width / 12;
        }

        /// <summary>
        /// Gets relative Y for the given height to draw digit
        /// </summary>
        /// <param name="y"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        private float GetY(float y, float height)
        {
            return y * height / 15;
        }

    }


}
