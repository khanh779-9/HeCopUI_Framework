using HeCopUI_Framework.Animations;
using HeCopUI_Framework.Enums;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls.Container
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(HTabControl), "Bitmaps.TabControl.bmp")]
    public partial class HTabControl : TabControl
    {

        #region Internal Vars

        private bool _useAnimation;
        private Color _unselectedTextColor = Color.Black;
        private Color _selectedTextColor = Color.White;
        private TabStyle _tabStyle;

        #endregion Internal Vars

        #region Constructors

        public HTabControl()
        {
            SetStyle(ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.SupportsTransparentBackColor, true);


            _animationManager = new AnimationManager(true)
            {
                AnimationType = AnimationType.Linear,
                Increment = 0.08
            };
            _animationManager.OnAnimationProgress += sender =>
            {
                if (IsHandleCreated) Invalidate();
            };

            _oldIndex = SelectedIndex == -1 ? 0 : SelectedIndex;
        }


        private readonly AnimationManager _animationManager;

        #endregion Constructors

        #region Properties

        //private Color borderTaCo = Color.Silver;

        private int borderthick = 1;
        /// <summary>
        /// Gets or sets width border for tab button.
        /// </summary>
        public int BorderThickness
        {
            get { return borderthick; }
            set
            {
                borderthick = value; Invalidate();

            }
        }

        private Color borderColor = Global.PrimaryColors.BackNormalColor1;
        private Color unborderColor = Color.Silver;
        /// <summary>
        /// Gets or sets the color for border tab.
        /// </summary>
        public Color BorderTabColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value; Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color for border tab (unselected).
        /// </summary>
        public Color UnSelectedBorderTabColor
        {
            get { return unborderColor; }
            set
            {
                unborderColor = value; Invalidate();
            }
        }

        private Color UnseTab = Color.FromArgb(250, 250, 250);
        /// <summary>
        /// Gets or sets the color for tab when unselected.
        /// </summary>
        public Color UnSelectedTabColor
        {
            get { return UnseTab; }
            set
            {
                UnseTab = value; Invalidate();
            }
        }


        /// <summary>
        /// Gets or sets whether the tab control use animation or not.
        /// </summary>
        public bool UseAnimation
        {
            get { return _useAnimation; }
            set
            {
                _useAnimation = value;
                Invalidate();
            }
        }


        /// <summary>
        /// Gets or sets the background color.
        /// </summary>
        private Color backgro = Color.White;
        public Color BackgroundColor
        {
            get { return backgro; }
            set
            {
                backgro = value; Invalidate();
            }
        }

        bool _applyTabPagesColor = true;

        /// <summary>
        /// Gets or sets whether the tab pages color will be applied to the tab control or not.
        /// </summary>
        public bool ApplyTabPagesColor
        {
            get { return _applyTabPagesColor; }
            set
            {
                _applyTabPagesColor = value;
                Invalidate();
            }
        }


        /// <summary>
        /// Gets or sets the foreground color.
        /// </summary>
        private Color foregrou = Global.PrimaryColors.BackNormalColor1;
        public Color SelectedTabColor
        {
            get { return foregrou; }
            set
            {
                foregrou = value; Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the tab page text while un-selected.
        /// </summary>

        public Color UnselectedTextColor
        {
            get { return _unselectedTextColor; }
            set
            {
                _unselectedTextColor = value;
                Invalidate();
            }
        }


        /// <summary>
        /// Gets or sets the tab page text while selected.
        /// </summary>

        public Color SelectedTextColor
        {
            get { return _selectedTextColor; }
            set
            {
                _selectedTextColor = value;
                Invalidate();
            }
        }


        /// <summary>
        /// Gets or sets the tab control appearance style
        /// </summary>

        [DefaultValue(TabStyle.Style1)]
        public TabStyle TabStyle
        {
            get { return _tabStyle; }
            set
            {
                _tabStyle = value;
                Invalidate();
            }
        }

        protected override void OnCreateControl()
        {
            _oldIndex = SelectedIndex == -1 ? 0 : SelectedIndex;

            base.OnCreateControl();
        }

        #endregion Properties

        #region Draw Control

        private ContentAlignment CA = ContentAlignment.MiddleLeft;
        public ContentAlignment TextAlignment
        {
            get { return CA; }
            set
            {
                CA = value; Invalidate();
            }
        }

        private StringTrimming ST = StringTrimming.EllipsisCharacter;
        public StringTrimming TextTrim
        {
            get { return ST; }
            set
            {
                ST = value; Invalidate();
            }
        }

        Cursor cursors = Cursors.Default;
        public Cursor CursorTabPages
        {
            get { return cursors; }
            set
            {
                cursors = value;
                foreach (TabPage tp in TabPages)
                    tp.Cursor = cursors;
                Invalidate();
            }
        }

        private System.Drawing.Text.TextRenderingHint TR = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
        public System.Drawing.Text.TextRenderingHint TextRenderHint
        {
            get { return TR; }
            set
            {

                TR = value; Invalidate();
            }
        }

        private Padding _textPadding = new Padding(0, 0, 0, 0);
        public Padding TextPadding
        {
            get { return _textPadding; }
            set
            {
                _textPadding = value; Invalidate();
            }
        }

        protected override void CreateHandle()
        {
            changeTabColor();
            base.CreateHandle();
        }

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public new ImageList ImageList
        {
            get { return base.ImageList; }
            set
            {
                base.ImageList = value; Invalidate();
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _animationManager.StartNewAnimation(AnimationDirection.InOutIn, e.Location);
            }
            base.OnMouseDown(e);
        }

        protected override void OnTabIndexChanged(EventArgs e)
        {
            _oldIndex = SelectedIndex == -1 ? 0 : SelectedIndex;
            changeTabColor();
            base.OnTabIndexChanged(e);
        }

        protected override void OnSelected(TabControlEventArgs e)
        {

            base.OnSelected(e);
        }

        protected override void OnDeselected(TabControlEventArgs e)
        {

            base.OnDeselected(e);
        }

        int _oldIndex = 0;

        Color _tabsColor = Color.White;
        public Color TabsColor
        {
            get { return _tabsColor; }
            set
            {
                _tabsColor = value;
                changeTabColor();
                Invalidate();
            }
        }

        void changeTabColor()
        {
            if (ApplyTabPagesColor)
                foreach (TabPage tp in TabPages)
                {
                    tp.BackColor = _tabsColor;
                    tp.Refresh();
                }
        }

        private System.Drawing.Text.TextRenderingHint textRen = Helper.TextHelper.SetTextRender();
        public System.Drawing.Text.TextRenderingHint TextRenderingHint
        {
            get { return textRen; }
            set
            {
                textRen = value;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            using (StringFormat SF = new StringFormat())
            using (var BrBac = new SolidBrush(BackgroundColor))
            using (var selTab = new SolidBrush(SelectedTabColor))
            {
                //g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.TextRenderingHint = TR;
                var h = ItemSize.Height + 2;

                if (BackgroundColor == Color.Transparent)
                {
                    InvokePaintBackground(Parent, e);
                }
                if (BackgroundColor != Color.Transparent)
                    g.FillRectangle(BrBac, ClientRectangle);
                g.TextRenderingHint = textRen;
                SF.Trimming = ST;
                Helper.TextHelper.SetStringAlign(SF, CA);

                switch (TabStyle)
                {
                    case TabStyle.Style1:
                        for (var i = 0; i <= TabCount - 1; i++)
                        {
                            var r = GetTabRect(i);
                            using (var sb = new SolidBrush(i == SelectedIndex ? SelectedTabColor : UnSelectedTabColor))
                                g.FillRectangle(sb, r);

                            if (ImageList != null && TabPages[i].ImageIndex != -1)
                            {
                                var img = ImageList.Images[TabPages[i].ImageIndex];
                                var imgRect = new RectangleF(r.X + 6, r.Y + ImageList.ImageSize.Height / 2 - (Alignment == TabAlignment.Top ? 3 : 0), ImageList.ImageSize.Width, ImageList.ImageSize.Height);
                                g.DrawImage(img, imgRect);
                            }

                            using (var tb = new SolidBrush(i == SelectedIndex ? SelectedTextColor : UnselectedTextColor))
                                g.DrawString(TabPages[i].Text, Font, tb, new RectangleF(3 + GetTabRect(i).X + _textPadding.Left + (ImageList != null ? ImageList.ImageSize.Width + 6 : 0),
                                    GetTabRect(i).Y + _textPadding.Top + (Alignment == TabAlignment.Bottom ? 3 : 0), GetTabRect(i).Width - _textPadding.Right - 2 - (ImageList != null ? ImageList.ImageSize.Width + 6 : 0)
                                    , GetTabRect(i).Height - _textPadding.Bottom - (Alignment == TabAlignment.Bottom ? 3 : 0)), SF);
                        }


                        using (var sb = new Pen(SelectedTabColor, 2))
                            DrawSelectedTabLine(g, h, sb);

                        break;

                    case TabStyle.Style2:
                        for (var i = 0; i < TabCount; i++)
                            g.FillRectangle(new SolidBrush(UnSelectedTabColor), GetTabRect(i));

                        RectangleF tabRect = RectangleF.Empty;

                        if (SelectedIndex >= 0 && SelectedIndex < TabPages.Count)
                            tabRect = GetTabRect(SelectedIndex);


                        if (UseAnimation == false)
                        {
                            g.FillRectangle(selTab, tabRect.X, tabRect.Height + 1, tabRect.Width, 3);
                        }
                        else
                        {
                            float _navBarWidth = tabRect.Width;
                            float _navBarOffset = tabRect.X;

                            // Hiệu ứng thanh điều hướng
                            var animationProgress = 1 - (float)(_animationManager.IsAnimating() ? _animationManager.GetProgress() : 0);
                            var animatedWidth = (Alignment == TabAlignment.Top || Alignment == TabAlignment.Bottom ? (float)(_navBarWidth * animationProgress) : 3);
                            var animatedOffset = (Alignment == TabAlignment.Bottom || Alignment == TabAlignment.Top ? (float)(_navBarOffset + (_navBarWidth - animatedWidth) / 2) :
                                (Alignment == TabAlignment.Left ? ItemSize.Height : GetTabRect(SelectedIndex).X));
                            g.FillRectangle(selTab, animatedOffset, Alignment == TabAlignment.Top ? tabRect.Height + 1 : ((Alignment == TabAlignment.Bottom || Alignment == TabAlignment.Top) ? tabRect.Top
                                : tabRect.Top + (GetTabRect(SelectedIndex).Height - (GetTabRect(SelectedIndex).Height * animationProgress)) / 2), animatedWidth,
                               (Alignment == TabAlignment.Top || Alignment == TabAlignment.Bottom) ? 3 : GetTabRect(SelectedIndex).Height * animationProgress);
                        }

                        for (var i = 0; i <= TabCount - 1; i++)
                            using (var tb = new SolidBrush(SelectedTab == TabPages[i] ? SelectedTextColor : UnselectedTextColor))
                            {
                                if (ImageList != null && TabPages[i].ImageIndex != -1)
                                {
                                    var r = GetTabRect(i);
                                    var img = ImageList.Images[TabPages[i].ImageIndex];
                                    var imgRect = new RectangleF(r.X + 6, r.Y + ImageList.ImageSize.Height / 2 - (Alignment == TabAlignment.Top ? 3 : 0), ImageList.ImageSize.Width, ImageList.ImageSize.Height);
                                    g.DrawImage(img, imgRect);
                                }
                                g.DrawString(TabPages[i].Text, Font, tb, new RectangleF(3 + GetTabRect(i).X + _textPadding.Left + (ImageList != null ? ImageList.ImageSize.Width + 6 : 0),
                                    GetTabRect(i).Y + _textPadding.Top + (Alignment == TabAlignment.Bottom ? 3 : 0), GetTabRect(i).Width - _textPadding.Right - 2 - (ImageList != null ? ImageList.ImageSize.Width + 6 : 0)
                                    , GetTabRect(i).Height - _textPadding.Bottom - (Alignment == TabAlignment.Bottom ? 3 : 0)), SF);
                            }

                        break;
                }
            }
        }

        private void DrawSelectedTabLine(Graphics g, int h, Pen sb)
        {
            if (Alignment == TabAlignment.Top)
                g.DrawLine(sb, 2, h, Width - 3, h);
            else if (Alignment == TabAlignment.Bottom)
                g.DrawLine(sb, 2, Height - h, Width - 3, Height - h);
            else if (Alignment == TabAlignment.Left)
                g.DrawLine(sb, h, 2, h, Height - 4);
            else if (Alignment == TabAlignment.Right)
                g.DrawLine(sb, Width - h, 2, Width - h, Height - 4);
        }

        #endregion Events

    }
}