using HeCopUI_Framework.Animations;
using HeCopUI_Framework.Controls.Chart.Model;
using HeCopUI_Framework.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls.Chart
{
    [ToolboxBitmap(typeof(System.Windows.Forms.DataVisualization.Charting.Chart))]
    public partial class HLineAreaChart : Control
    {
        private AnimationManager animationManager;

        private Color _titleColor = Color.FromArgb(0, 168, 148);
        private Font _titleFont = new Font("Arial", 12, FontStyle.Bold);
        private TitleChartAlign _titleChartAlign = TitleChartAlign.TopLeft;
        private LegendType _legendType = LegendType.Right;
        private Color _numbericChartColor = Color.DimGray;
        private int _maximumValue = 100;
        private bool showTitle = true;
        private string title = "Line Chart";
        private int visibleNumberOy = 10;
        private int spaceBetweenPoints = 10;
        Color axisColor = Color.Gray;
        Font _numbericChartFont = new Font("Arial", 8, FontStyle.Regular);
        Font _legendFont = new Font("Arial", 8, FontStyle.Regular);


        private DataItems dataItems = new DataItems();

        public Color TitleColor { get => _titleColor; set { _titleColor = value; Invalidate(); } }
        public Font TitleFont { get => _titleFont; set { _titleFont = value; Invalidate(); } }
        public TitleChartAlign TitleChartAlign { get => _titleChartAlign; set { _titleChartAlign = value; Invalidate(); } }
        public LegendType LegendType { get => _legendType; set { _legendType = value; Invalidate(); } }
        public Color NumbericChartColor { get => _numbericChartColor; set { _numbericChartColor = value; Invalidate(); } }
        public bool ShowTitle { get => showTitle; set { showTitle = value; Invalidate(); } }
        public string TitleText { get => title; set { title = value; Invalidate(); } }
        public int VisibleNumberOy { get => visibleNumberOy; set { visibleNumberOy = value; Invalidate(); } }
        public int SpaceBetweenPoints { get => spaceBetweenPoints; set { spaceBetweenPoints = value; Invalidate(); } }
        public Color AxisColor { get => axisColor; set { axisColor = value; Invalidate(); } }

        public Font NumbericChartFont { get => _numbericChartFont; set { _numbericChartFont = value; Invalidate(); } }
        public Font LegendFont { get => _legendFont; set { _legendFont = value; Invalidate(); } }


        public HLineAreaChart()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.OptimizedDoubleBuffer, true);
            animationManager = new AnimationManager();
            animationManager.OnAnimationProgress += sender => Invalidate();
        }

        protected override void OnCreateControl()
        {
            animationManager.StartNewAnimation(AnimationDirection.In);
            if (DesignMode)
            {
                // Ví dụ mẫu đi
                Dictionary<object, float> item1 = new Dictionary<object, float>
                {
                    { "A", 10 },
                    { "B", 20 },
                    { "C", 30 }
                };

                AddItems("Example 1", item1, Color.MediumVioletRed);

                Dictionary<object, float> item2 = new Dictionary<object, float>
                {
                    { "A", 30 },
                    { "B", 70 },
                    { "C", 20 }
                };
                AddItems("Example 2", item2, Color.DodgerBlue);

                Dictionary<object, float> item3 = new Dictionary<object, float>
                {
                    { "A", 50 },
                    { "B", 20 },
                    { "C", 10 }
                };
                AddItems("Example 3", item3, Color.FromArgb(0, 168, 138));
            }

            base.OnCreateControl();
        }

        public void AddItems(string legendText, Dictionary<object, float> items, Color color)
        {
            animationManager.StartNewAnimation(AnimationDirection.In);
            dataItems.Add(legendText, items, color);
        }

        private float CalculateRoundedMaxValue()
        {
            float maxValue = 0;
            foreach (var dataset in dataItems.Items)
            {
                foreach (var value in dataset.Data.Values)
                {
                    if (value > maxValue)
                        maxValue = value;
                }
            }
            return (float)Math.Ceiling(maxValue / 10) * 10 + 10;
        }

        LineChartType lineChartType = LineChartType.Line;
        public LineChartType LineChartType
        {
            get => lineChartType;
            set
            {
                lineChartType = value;
                animationManager.ResetAll();
                animationManager.StartNewAnimation(AnimationDirection.In);
                Invalidate();
            }
        }


        bool useGradientBackground = false;
        public bool UseGradientBackground
        {
            get => useGradientBackground;
            set
            {
                useGradientBackground = value;
                Invalidate();
            }
        }

        public void RefreshData()
        {
            animationManager.ResetAll();
            animationManager.StartNewAnimation(AnimationDirection.In);
        }

        SortMode sortMode = SortMode.None;
        public SortMode SortMode { get => sortMode; set { sortMode = value; Invalidate(); } }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            _maximumValue = (int)CalculateRoundedMaxValue();
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            try
            {
                float offsetY = _titleFont.Height + 20;
                float offsetX = 40;
                float chartHeight = Height - 30;
                float chartWidth = Width - Width / 3;

                List<object> xAxisLabels = dataItems.Items.SelectMany(item => item.Data.Keys).Distinct().ToList();

                //xAxisLabels.Sort();
                if (sortMode == SortMode.Ascending)
                    xAxisLabels.Sort();
                else if (sortMode == SortMode.Descending)
                    xAxisLabels.Sort((x, y) => y.ToString().CompareTo(x.ToString()));

                float pointSpacing = (chartWidth - offsetX) / (xAxisLabels.Count - 1);

                using (Pen axisPen = new Pen(AxisColor, 1))
                {
                    g.DrawLine(axisPen, offsetX, offsetY, offsetX, chartHeight); // Oy
                    g.DrawLine(axisPen, offsetX, chartHeight, chartWidth, chartHeight); // Ox

                    using (Brush textBrush = new SolidBrush(_numbericChartColor))
                    {
                        DrawOYLabels(g, axisPen, textBrush, new Font(_titleFont.Name, 10f), offsetX, offsetY, 30);
                        DrawOXLabels(g, xAxisLabels, offsetX, offsetY, pointSpacing, textBrush, new Font(_titleFont.Name, 10f));
                    }
                }

                Helper.GraphicsHelper.SetHightGraphics(g);

                // Draw chart
                foreach (var dataset in dataItems.Items)
                {
                    List<PointF> points = new List<PointF>();

                    foreach (var label in xAxisLabels)
                    {
                        int index = xAxisLabels.IndexOf(label);
                        float x = offsetX + index * pointSpacing;
                        float y = chartHeight;

                        if (dataset.Data.TryGetValue(label, out float value))
                            y -= (value / _maximumValue) * (chartHeight - offsetY) * (float)animationManager.GetProgress();

                        points.Add(new PointF(x, y));

                    }

                    using (Pen linePen = new Pen(dataset.Color, 1))
                    {
                        switch (lineChartType)
                        {
                            case LineChartType.Line:
                                if (useGradientBackground)
                                {
                                    using (GraphicsPath gp = new GraphicsPath())
                                    {
                                        gp.AddLine(new PointF(offsetX, chartHeight), points[0]);
                                        gp.AddLines(points.ToArray());
                                        gp.AddLine(points[points.Count - 1], new PointF(chartWidth, chartHeight));
                                        using (LinearGradientBrush brush = new LinearGradientBrush(gp.GetBounds(), Color.FromArgb(30, dataset.Color), Color.Transparent, LinearGradientMode.Vertical))
                                        {
                                            g.FillPath(brush, gp);
                                        }

                                    }
                                }
                                g.DrawLines(linePen, points.ToArray());

                                break;
                            case LineChartType.Curve:
                                if (useGradientBackground)
                                {
                                    using (GraphicsPath gp = new GraphicsPath())
                                    {
                                        gp.AddLine(new PointF(offsetX, chartHeight), points[0]);
                                        gp.AddCurve(points.ToArray());
                                        gp.AddLine(points[points.Count - 1], new PointF(chartWidth, chartHeight));
                                        using (LinearGradientBrush brush = new LinearGradientBrush(gp.GetBounds(), Color.FromArgb(30, dataset.Color), Color.Transparent, LinearGradientMode.Vertical))
                                        {
                                            g.FillPath(brush, gp);
                                        }
                                    }
                                }
                                g.DrawCurve(linePen, points.ToArray());

                                break;
                            case LineChartType.Bezier:

                                //if (points.Count > 3)
                                {
                                    GraphicsPath path = new GraphicsPath();
                                    LinearGradientBrush brush = null;

                                    for (int i = 0; i < points.Count - 3; i += 3)
                                    {
                                        PointF[] bezierPoints = new PointF[]
                                        {
                                            points[i],
                                            points[i + 1],
                                            points[i + 2],
                                            points[i + 3]
                                        };

                                        path.Reset();
                                        path.AddBeziers(bezierPoints); // Thêm Bezier vào GraphicsPath

                                        if (useGradientBackground)
                                        {
                                            // Mở rộng vùng gradient
                                            path.AddLine(bezierPoints[bezierPoints.Length - 1], new PointF(chartWidth, chartHeight));
                                            path.AddLine(new PointF(offsetX, chartHeight), bezierPoints[0]);

                                            // Gradient phủ toàn khu vực
                                            brush = new LinearGradientBrush(
                                                new RectangleF(0, 0, chartWidth, chartHeight),
                                                Color.FromArgb(30, dataset.Color),
                                                Color.Transparent,
                                                LinearGradientMode.Vertical
                                            );

                                            g.FillPath(brush, path);
                                        }

                                        g.DrawBeziers(linePen, bezierPoints);
                                    }

                                    path?.Dispose();
                                    brush?.Dispose();
                                }

                                break;

                        }
                        using (Brush pointBrush = new SolidBrush(dataset.Color))
                        {
                            foreach (var point in points)
                            {
                                g.FillEllipse(pointBrush, point.X - 3, point.Y - 3, 6, 6);

                                if (new RectangleF(point.X - 3, point.Y - 3, 6, 6).Contains(PointToClient(MousePosition)))
                                {
                                    DrawPopupTip(g, dataset.LegendText + " : " + (int)((_maximumValue - (point.Y - offsetY) * _maximumValue / (chartHeight - offsetY))), point.X + 10, point.Y - 10);
                                }
                            }
                        }
                    }
                }

                if (showTitle)
                {
                    using (Brush titleBrush = new SolidBrush(_titleColor))
                    {
                        g.DrawString(title, _titleFont, titleBrush, Width / 2 - g.MeasureString(title, _titleFont).Width / 2, 10);
                    }
                }

                if (LegendType != LegendType.None)
                {
                    float legendX = chartWidth + 20;
                    float legendY = 10;
                    float legendWidth = Width - legendX - 10;
                    float legendHeight = chartHeight;
                    float y = legendY + 10;
                    foreach (var dataset in dataItems.Items)
                    {
                        g.FillRectangle(new SolidBrush(dataset.Color), legendX + 10, y, 10, 10);
                        g.DrawString(dataset.LegendText, LegendFont, new SolidBrush(NumbericChartColor), legendX + 20, y - LegendFont.Size / 2 + 2);
                        y += LegendFont.Height + 5;
                    }
                }
            }
            catch (Exception)
            {
                g.FillRectangle(new SolidBrush(Color.FromArgb(50, 50, 50)), 0, 0, Width, Height);
                g.DrawString("No Data", _titleFont, new SolidBrush(Color.White), Width / 2, Height / 2);
            }

            base.OnPaint(e);
        }

        void DrawPopupTip(Graphics g, string text, float x, float y)
        {
            using (Brush brush = new SolidBrush(Color.FromArgb(50, 50, 50)))
            {
                using (Pen pen = new Pen(Color.FromArgb(50, 50, 50)))
                {
                    SizeF size = g.MeasureString(text, _numbericChartFont);
                    g.FillRectangle(brush, x, y, size.Width + 10, size.Height + 5);
                    g.DrawRectangle(pen, x, y, size.Width + 10, size.Height + 5);
                    g.DrawString(text, _numbericChartFont, new SolidBrush(Color.White), x + 5, y + 2);
                }
            }
        }

        private void DrawOYLabels(Graphics g, Pen penOY, Brush brushOy, Font font, float offX, float offY, float offyh)
        {
            float tickSpacing = _maximumValue / visibleNumberOy;
            for (int i = 0; i <= visibleNumberOy; i++)
            {
                float tickValue = i * tickSpacing;
                float tickY = (Height - offyh) - ((tickValue / _maximumValue) * (Height - offY - offyh));
                g.DrawString(tickValue.ToString(), font, brushOy, offX - g.MeasureString(tickValue.ToString(), font).Width - 10, tickY - font.Height / 2);
                g.DrawLine(penOY, offX - 6, tickY, offX, tickY);
            }
        }

        void DrawOXLabels(Graphics g, List<object> keys, float offX, float offY, float pointSpacing, Brush brush, Font font)
        {
            for (int i = 0; i < keys.Count; i++)
            {
                float x = offX + i * pointSpacing;
                float y = Height - offY + 15;
                g.DrawString(keys[i].ToString(), font, brush, x - g.MeasureString(keys[i].ToString(), font).Width / 2, y);
            }
        }

    }
}
