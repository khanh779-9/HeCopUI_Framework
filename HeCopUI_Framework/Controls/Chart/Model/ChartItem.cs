using System.Drawing;

namespace HeCopUI_Framework.Controls.Chart.Model
{
    public class ChartItem
    {
        public string Text { get; set; }
        public int Index { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public Color Color { get; set; }

        public ChartItem() { }

        public ChartItem(string text, int index, string name, double value, Color color)
        {
            Text = text;
            Index = index;
            Name = name;
            Value = value;
            Color = color;
        }
    }
}
