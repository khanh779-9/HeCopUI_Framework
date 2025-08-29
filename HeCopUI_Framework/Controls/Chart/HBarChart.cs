using HeCopUI_Framework.Animations;
using HeCopUI_Framework.Controls.Chart.Model;
using HeCopUI_Framework.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using Brush = System.Drawing.Brush;
using Color = System.Drawing.Color;
using MouseEventArgs = System.Windows.Forms.MouseEventArgs;
using Pen = System.Drawing.Pen;

namespace HeCopUI_Framework.Controls.Chart
{
    [ToolboxBitmap(typeof(System.Windows.Forms.DataVisualization.Charting.Chart))]
    public partial class HBarChart : Control
    {
        public HBarChart()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.OptimizedDoubleBuffer, true);
            animationManager = new AnimationManager();
            animationManager.OnAnimationProgress += sender => Invalidate();
        }

        AnimationManager animationManager;

        // Tạo các biến private và public (get và set từ biến private và invalidate), biến _titleColor, _titleText, _titleFont, _titleChartAlign, _legendType, _numbericChartColor, _maximumValue, _minimumValue,... Tạo những biến có liên quan tới chart á, cụ thể là chart bar
        private Color _titleColor = Color.Black;
        private Font _titleFont = new Font("Arial", 12, FontStyle.Bold);
        private TitleChartAlign _titleChartAlign = TitleChartAlign.TopLeft;
        private LegendType _legendType = LegendType.Right;
        private Color _numbericChartColor = Color.DimGray;
        private int _maximumValue = 100;
        Color lineChart = Color.FromArgb(50, 50, 50);
        Color itemsColor = Color.FromArgb(50, 50, 50);
        bool showTitle = true;
        string title = "HBar Chart";
        int visibleNumberOy = 10;
        int spaceBetweenItems = 10;


        // Tạo các bins public để set và get từ các biến private, và không dùng [Category(...)]
        public Color TitleColor { get => _titleColor; set { _titleColor = value; Invalidate(); } }

        public Font TitleFont { get => _titleFont; set { _titleFont = value; Invalidate(); } }
        public TitleChartAlign TitleChartAlign { get => _titleChartAlign; set { _titleChartAlign = value; Invalidate(); } }

        public LegendType LegendType { get => _legendType; set { _legendType = value; Invalidate(); } }
        public Color NumbericChartColor { get => _numbericChartColor; set { _numbericChartColor = value; Invalidate(); } }

        public Color LineChart { get => lineChart; set { lineChart = value; Invalidate(); } }
        public Color ItemsTextColor { get => itemsColor; set { itemsColor = value; Invalidate(); } }
        public bool ShowTitle { get => showTitle; set { showTitle = value; Invalidate(); } }
        public string TitleText { get => title; set { title = value; Invalidate(); } }
        public int VisibleNumberOy { get => visibleNumberOy; set { visibleNumberOy = value; Invalidate(); } }
        public int SpaceBetweenItems { get => spaceBetweenItems; set { spaceBetweenItems = value; Invalidate(); } }


        protected override void OnCreateControl()
        {
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
            animationManager.StartNewAnimation(AnimationDirection.In);
            base.OnCreateControl();
        }

        bool borderItems = true;
        public bool BorderItems { get => borderItems; set { borderItems = value; animationManager.StartNewAnimation(AnimationDirection.In); Invalidate(); } }
        SortMode sortMode = SortMode.None;
        public SortMode SortMode { get => sortMode; set { sortMode = value; animationManager.StartNewAnimation(AnimationDirection.Out); animationManager.StartNewAnimation(AnimationDirection.In); Invalidate(); } }

        Font legendFont = new Font("Arial", 10, FontStyle.Regular);
        public Font LegendFont { get => legendFont; set { legendFont = value; Invalidate(); } }

        Color legenColor = Color.DimGray;
        public Color LegendColor { get => legenColor; set { legenColor = value; Invalidate(); } }

        HeCopUI_Framework.Controls.Chart.Model.DataItems dataItem = new DataItems();

        public void AddItems(string legendText, Dictionary<object, float> items, System.Drawing.Color color)
        {
            dataItem.Add(legendText, items, color);
            animationManager.StartNewAnimation(AnimationDirection.In);

        }

        private float CalculateRoundedMaxValue()
        {
            float maxValue = 0;
            List<object> strOX = new List<object>();
            dataItem.Items.ForEach(x =>
            {
                for (int i = 0; i < x.Data.Keys.Count; i++)
                    if (!strOX.Contains(x.Data.ElementAt(i).Key))
                        strOX.Add(x.Data.ElementAt(i).Key.ToString());
            });
            for (int strX = 0; strX < strOX.Count; strX++)
            {
                float a = 0;
                for (int item = 0; item < dataItem.Items.Count; item++)
                {
                    if (dataItem.Items[item].Data.ContainsKey(strOX[strX]))
                        a += dataItem.Items[item].Data[strOX[strX]];
                }
                if (a > maxValue)
                    maxValue = a;
            }

            maxValue = Convert.ToSingle(Math.Ceiling(maxValue / 10) * 10 + 10);

            return maxValue;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            _maximumValue = (int)CalculateRoundedMaxValue();

            try
            {
                float offY = _titleFont.Height + 20;
                float offX = 40;
                float offyh = 30;
                float chartWidth = Width - (Width / 3);

                using (Pen pen = new Pen(lineChart, 1))
                using (Pen penOY = new Pen(LineChart, 1))
                using (Brush brushOy = new SolidBrush(NumbericChartColor))
                using (Brush brush = new SolidBrush(itemsColor))
                using (Font oyFont = new Font(_titleFont.Name, 10f))
                {
                    DrawAxes(g, pen, offX, offY, offyh, chartWidth);
                    var strOX = GetSortedKeys();
                    DrawOYLabels(g, penOY, brushOy, oyFont, offX, offY, offyh);
                    DrawOXLabels(g, strOX, offX + 5, offY, chartWidth / strOX.Count, brush, oyFont);
                    DrawBars(g, strOX, offX + 5, offY, offyh, chartWidth, brush, oyFont);
                    DrawTitle(g, brush, chartWidth);
                    DrawLegend(g, brush, chartWidth);
                }
            }
            catch
            {
                g.FillRectangle(new SolidBrush(Color.FromArgb(50, 50, 50)), 0, 0, Width, Height);
                g.DrawString("No Data", _titleFont, new SolidBrush(Color.White), Width / 2, Height / 2);
            }

            base.OnPaint(e);
        }

        private void DrawAxes(Graphics g, Pen pen, float offX, float offY, float offyh, float chartWidth)
        {
            g.DrawLine(pen, offX, Height - offyh, chartWidth, Height - offyh); // Ox
            g.DrawLine(pen, offX, offY, offX, Height - offyh);                // Oy
        }

        private List<object> GetSortedKeys()
        {
            var keys = new HashSet<object>();
            dataItem.Items.ForEach(x => x.Data.Keys.ToList().ForEach(k => keys.Add(k)));
            var sortedKeys = keys.ToList();
            if (sortMode == SortMode.Ascending) sortedKeys.Sort();
            else if (sortMode == SortMode.Descending) sortedKeys.Sort((x, y) => y.ToString().CompareTo(x.ToString()));
            return sortedKeys;
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

        private void DrawBars(Graphics g, List<object> keys, float offX, float offY, float offyh, float chartWidth, Brush brush, Font font)
        {
            PointF mousePos = PointToClient(MousePosition);
            string tooltipText = string.Empty;

            float barWidth = (chartWidth - offX) / keys.Count - SpaceBetweenItems;
            float totalSpacing = keys.Count * SpaceBetweenItems;

            for (int i = 0; i < keys.Count; i++)
            {
                float x = offX + i * (barWidth + SpaceBetweenItems);
                float totalHeight = 0;
                float dataValue = 0;

                foreach (var item in dataItem.Items)
                {
                    if (!item.Data.ContainsKey(keys[i])) continue;

                    float value = item.Data[keys[i]];
                    dataValue += value;
                    float height = (value / _maximumValue) * (Height - offyh - offY) * (float)animationManager.GetProgress();
                    var abc = Height - offyh - height - totalHeight;
                    g.FillRectangle(new SolidBrush(item.Color), x, abc, barWidth, height);
                    totalHeight += height;
                }

                if (!DesignMode && mousePos.X >= x && mousePos.X <= x + barWidth && mousePos.Y >= Height - offyh - totalHeight && mousePos.Y <= Height - offyh)
                {
                    tooltipText = $"{keys[i]}: {dataValue} (total)\n";
                    foreach (var item in dataItem.Items)
                    {
                        if (item.Data.ContainsKey(keys[i]))
                        {
                            tooltipText += $"{item.LegendText}: {item.Data[keys[i]]}\n";

                        }
                    }
                    DrawTooltip(g, tooltipText);
                }
            }
        }

        public void RefreshData()
        {
            animationManager.ResetAll();
            animationManager.StartNewAnimation(AnimationDirection.In);
        }

        private void DrawTitle(Graphics g, Brush brush, float chartWidth)
        {
            if (!showTitle) return;

            float tx = (TitleChartAlign == TitleChartAlign.TopCenter) ? chartWidth / 2 - g.MeasureString(title, _titleFont).Width / 2 : 0;
            g.DrawString(title, _titleFont, brush, tx, 0);
        }

        private void DrawLegend(Graphics g, Brush brush, float chartWidth)
        {
            float locy = Height / 2;
            foreach (var item in dataItem.Items)
            {
                g.FillRectangle(new SolidBrush(item.Color), chartWidth + 12, locy, 12, 12);
                g.DrawString(item.LegendText, legendFont, brush, chartWidth + 26, locy - 2);
                locy += legendFont.Height;
            }
        }



        private void DrawTooltip(Graphics g, string tooltipText)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            PointF mousePos = PointToClient(MousePosition);
            SizeF textSize = g.MeasureString(tooltipText, toolTipFont);
            int padding = 10;  // Padding lớn hơn
            int cornerRadius = 12; // Góc bo tròn mượt mà
            int shadowOffset = 6;  // Bóng đổ mạnh hơn
            Color backgroundColor = Color.FromArgb(240, 255, 255, 255); // Nền trắng trong suốt nhẹ
            Color borderColor = Color.FromArgb(100, 50, 50, 50); // Viền xám đậm

            RectangleF tooltipRect = new RectangleF(
                mousePos.X - textSize.Width / 2 - padding,
                mousePos.Y - textSize.Height - 30,
                textSize.Width + padding * 2,
                textSize.Height + padding * 2);

            RectangleF shadowRect = new RectangleF(
                tooltipRect.X + shadowOffset,
                tooltipRect.Y + shadowOffset,
                tooltipRect.Width,
                tooltipRect.Height);
            using (GraphicsPath shadowPath = RoundedRect(shadowRect, cornerRadius))
            using (PathGradientBrush shadowBrush = new PathGradientBrush(shadowPath))
            {
                shadowBrush.CenterColor = Color.FromArgb(60, 0, 0, 0);
                shadowBrush.SurroundColors = new[] { Color.Transparent };
                g.FillPath(shadowBrush, shadowPath);
            }

            using (GraphicsPath tooltipPath = RoundedRect(tooltipRect, cornerRadius))
            using (Brush backgroundBrush = new SolidBrush(backgroundColor))
            {
                g.FillPath(backgroundBrush, tooltipPath);
            }

            using (GraphicsPath tooltipPath = RoundedRect(tooltipRect, cornerRadius))
            using (Pen borderPen = new Pen(borderColor, 1.8f))
            {
                g.DrawPath(borderPen, tooltipPath);
            }

            using (Brush textBrush = new SolidBrush(Color.Black))
            using (Brush shadowTextBrush = new SolidBrush(Color.FromArgb(100, 0, 0, 0)))
            {
                PointF textPos = new PointF(tooltipRect.X + padding, tooltipRect.Y + padding);
                g.DrawString(tooltipText, toolTipFont, shadowTextBrush, textPos.X + 1, textPos.Y + 1);

                g.DrawString(tooltipText, toolTipFont, textBrush, textPos);
            }
            g.SmoothingMode = SmoothingMode.Default;
        }

        private GraphicsPath RoundedRect(RectangleF rect, int cornerRadius)
        {
            GraphicsPath path = new GraphicsPath();
            float arcSize = cornerRadius * 2;

            path.AddArc(rect.X, rect.Y, arcSize, arcSize, 180, 90);
            path.AddArc(rect.Right - arcSize, rect.Y, arcSize, arcSize, 270, 90);
            path.AddArc(rect.Right - arcSize, rect.Bottom - arcSize, arcSize, arcSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - arcSize, arcSize, arcSize, 90, 90);
            path.CloseFigure();

            return path;
        }




        Font toolTipFont = DefaultFont;
        public Font ToolTipFont { get => toolTipFont; set { toolTipFont = value; Invalidate(); } }



        protected override void OnMouseMove(MouseEventArgs e)
        {
            Invalidate();
            base.OnMouseMove(e);
        }

    }


}
