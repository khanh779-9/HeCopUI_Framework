using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls
{
    public class HStepIndicatorOne : Control
    {
        public HStepIndicatorOne()
        {

            SetStyle(GetAppResources.SetControlStyles(), true);
        }

        private int _steps = 3;
        public int Steps
        {
            get { return _steps; }
            set
            {
                if (value <= 1) _steps = 2;
                else _steps = value;
                Invalidate();
            }
        }

        private int _radiusBig = 20;
        public int RadiusBig
        {
            get { return _radiusBig; }
            set
            {
                _radiusBig = value; Invalidate();
            }
        }

        private int _radiusSmall = 15;
        public int RadiusSmall
        {
            get { return _radiusSmall; }
            set
            {
                _radiusSmall = value; Invalidate();
            }
        }

        private int _backgroundHeight = 10;
        public int BGHeight
        {
            get { return _backgroundHeight; }
            set
            {
                _backgroundHeight = value; Invalidate();
            }
        }

        Color _indicatorBarColor1 = Global.PrimaryColors.BaseProgressBarColor1;
        public Color IndicatorBarColor1
        {
            get { return _indicatorBarColor1; }
            set
            {
                _indicatorBarColor1 = value; Invalidate();
            }
        }

        private Color _indicatorStepColor1 = Global.PrimaryColors.ProgressBarColor1;

        public Color IndicatorStepColor1
        {
            get { return _indicatorStepColor1; }
            set
            {
                _indicatorStepColor1 = value; Invalidate();
            }
        }

        Color _indicatorBarColor2 = Global.PrimaryColors.BaseProgressBarColor2;
        public Color IndicatorBarColor2
        {
            get { return _indicatorBarColor2; }
            set
            {
                _indicatorBarColor2 = value; Invalidate();
            }
        }

        private Color _indicatorStepColor2 = Color.DodgerBlue;

        public Color IndicatorStepColor2
        {
            get { return _indicatorStepColor2; }
            set
            {
                _indicatorStepColor2 = value; Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int steps = _steps;
            int radiusBig = _radiusBig;
            int radiusSmall = _radiusSmall;
            int bgHeight = _backgroundHeight;

            var gradientRect = new Rectangle(ClientRectangle.X + (ClientRectangle.Width - radiusBig * 2) / (steps - 1),
                                             ClientRectangle.Y + ClientRectangle.Height / 2 - radiusBig - 1, radiusBig * 2, radiusBig * 2);

            var lightGrayBrush = new LinearGradientBrush(ClientRectangle, _indicatorBarColor1, _indicatorBarColor2, LinearGradientMode.Vertical);
            //var darkGrayBrush = new LinearGradientBrush(gradientRect, Color.DarkGray, Color.Gray, LinearGradientMode.Vertical);
            var lightGreenBrush = new LinearGradientBrush(ClientRectangle, _indicatorStepColor1, _indicatorStepColor2, LinearGradientMode.Vertical);
            //var darkGreenBrush = new LinearGradientBrush(ClientRectangle, Color.YellowGreen, Color.ForestGreen, LinearGradientMode.Vertical);

            //g.FillRectangle(darkGrayBrush, ClientRectangle.X + radiusBig, ClientRectangle.Y + ClientRectangle.Height / 2 - bgHeight / 2 - 1,
            //                ClientRectangle.Width - radiusBig * 2, bgHeight);

            g.FillRectangle(lightGrayBrush, ClientRectangle.X + radiusBig, ClientRectangle.Y + ClientRectangle.Height / 2 - bgHeight / 2,
                            ClientRectangle.Width - radiusBig * 2, bgHeight);

            for (int i = 1; i <= steps; i++)
            {
                //g.FillEllipse(darkGrayBrush, ClientRectangle.X + ((ClientRectangle.Width - radiusBig * 2) / (steps - 1)) * (i - 1),
                //              ClientRectangle.Y + ClientRectangle.Height / 2 - radiusBig - 1, radiusBig * 2, radiusBig * 2);
                g.FillEllipse(lightGrayBrush, ClientRectangle.X + ((ClientRectangle.Width - radiusBig * 2) / (steps - 1)) * (i - 1),
                              ClientRectangle.Y + ClientRectangle.Height / 2 - radiusBig, radiusBig * 2, radiusBig * 2);
            }
            //-1
            for (int i = 1; i <= values; i++)
            {
                //g.FillEllipse(darkGreenBrush,
                //              ClientRectangle.X + ((ClientRectangle.Width - radiusBig * 2) / (steps - 1)) * (i - 1) + radiusBig - radiusSmall,
                //              ClientRectangle.Y + ClientRectangle.Height / 2 - radiusSmall - 1, radiusSmall * 2, radiusSmall * 2);
                g.FillEllipse(lightGreenBrush,
                              ClientRectangle.X + ((ClientRectangle.Width - radiusBig * 2) / (steps - 1)) * (i - 1) + radiusBig - radiusSmall,
                              ClientRectangle.Y + ClientRectangle.Height / 2 - radiusSmall, radiusSmall * 2, radiusSmall * 2);
            }

        }

        private int values = 1;
        public int Value
        {
            get { return values; }
            set
            {
                if (value <= 2) values = 2;
                else values = value;
                Invalidate();
            }
        }
    }
}
