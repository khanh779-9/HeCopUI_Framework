using HeCopUI_Framework.Animations;
using HeCopUI_Framework.Controls.Chart.Model;
using HeCopUI_Framework.Enums;
using HeCopUI_Framework.Extensions;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls.Chart
{
    public class HStackBarChart : Control
    {
        #region Constructor

        public HStackBarChart()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);

            _animationManager = new AnimationManager
            {
                Increment = 0.05
            };
            _animationManager.AnimationProgress += sender => Invalidate();

            if (!DesignMode)
                _animationManager.StartNewAnimation(AnimationType.In);
        }

        #endregion

        #region Private Fields

        private AnimationManager _animationManager;
        private int _radius = 5;
        private int _itemRadius = 5;
        private int _borderThickness = 0;
        private Color _borderColor = Color.Gray;
        private bool _useTransparent = false;

        #endregion

        #region Public Properties

        public List<ChartItem> Items = new List<ChartItem>();

        /// <summary>
        /// Gets or sets the radius of the chart corners.
        /// </summary>
        public int Radius
        {
            get { return _radius; }
            set
            {
                _radius = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the radius of each item in the chart.
        /// </summary>
        public int ItemRadius
        {
            get { return _itemRadius; }
            set
            {
                _itemRadius = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the thickness of the border.
        /// </summary>
        public int BorderThickness
        {
            get { return _borderThickness; }
            set
            {
                _borderThickness = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets whether to use transparent background.
        /// </summary>
        public bool UseTransparent
        {
            get { return _useTransparent; }
            set
            {
                _useTransparent = value;
                Invalidate();
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Reloads the chart data and animation.
        /// </summary>
        public void ReloadData()
        {
            _animationManager.StartNewAnimation(AnimationType.In);
        }

        #endregion

        #region Protected Methods

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

            if (_useTransparent)
                GraphicsHelper.MakeTransparent(this, e.Graphics);

            if (Items == null || Items.Count == 0)
            {
                e.Graphics.FillRectangle(Brushes.White, ClientRectangle);
                e.Graphics.DrawString("No data ;))", Font, Brushes.Black, ClientRectangle, 
                    new StringFormat { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center });
                e.Graphics.DrawRectangle(Pens.Black, 0, 0, Width, Height);
                return;
            }

            using (Bitmap bitmap = new Bitmap(Width - 2, Height))
            using (Graphics g = Graphics.FromImage(bitmap))
            using (GraphicsPath gp = GraphicsHelper.GetRoundPath(new Rectangle(0, 0, Width, Height), _radius))
            {
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                float total = (float)Items.Sum(x => x.Value);
                if (total == 0) return;

                float startX = 0f;

                for (int i = 0; i < Items.Count; i++)
                {
                    var item = Items[i];
                    float itemWidth = (float)(item.Value / total) * (Width - 2 + _radius * 2);
                    itemWidth *= (float)_animationManager.GetProgress();

                    RectangleF rect = new RectangleF(startX, 0, itemWidth - 2, Height);

                    using (SolidBrush brush = new SolidBrush(item.Color))
                    using (GraphicsPath gpv = GraphicsHelper.GetRoundPath(rect, _itemRadius, _borderThickness))
                    {
                        g.FillPath(brush, gpv);
                    }

                    startX += itemWidth - _radius;
                }

                if (_borderThickness > 0)
                {
                    using (GraphicsPath bgp = GraphicsHelper.GetRoundPath(new Rectangle(0, 0, Width - 2, Height), _radius, _borderThickness))
                    using (Pen pen = new Pen(_borderColor, _borderThickness))
                        g.DrawPath(pen, bgp);
                }

                using (TextureBrush brush = new TextureBrush(bitmap))
                {
                    brush.WrapMode = WrapMode.Clamp;
                    e.Graphics.FillPath(brush, gp);
                }
            }
        }

        #endregion
    }
}
