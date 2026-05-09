using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls.TreeView
{
    [DefaultEvent("AfterSelect")]
    public class HTreeView : Control
    {
        private int _indent = 20;
        private int _nodeHeight = 20;
        private bool _showPlusMinus = true;
        private bool _showRootLines = true;
        bool checkBoxVisible = false;
        bool acceptNodeSelection = false;
        string pathSeparator = "\\";

        private int spaceBetweenNodes = 0;

        private ImageList _imageList;

        private Color nodeForeColor = Color.Black;
        private Color nodeBackColor = Color.White;
        private Color nodeHoverColor = Color.LightGray;
        private Color nodeSelectedColor = Color.LightBlue;
        private Color plusMinusColor = Color.White;
        private Color rootLinesColor = Color.Gray;

        Color checkBoxBack = Color.FromArgb(102, 100, 252);
        Color checkIconColor = Color.White;

        private TreeNodeCollection nodes;

        [Localizable(true)]
        [MergableProperty(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public TreeNodeCollection Nodes => nodes;

        public Color NodeForeColor
        {
            get => nodeForeColor;
            set { nodeForeColor = value; Invalidate(); }
        }

        public Color NodeBackColor
        {
            get => nodeBackColor;
            set { nodeBackColor = value; Invalidate(); }
        }

        public Color NodeHoverColor
        {
            get => nodeHoverColor;
            set { nodeHoverColor = value; Invalidate(); }
        }

        public Color NodeSelectedColor
        {
            get => nodeSelectedColor;
            set { nodeSelectedColor = value; Invalidate(); }
        }

        public Color PlusMinusColor
        {
            get => plusMinusColor;
            set { plusMinusColor = value; Invalidate(); }
        }

        public Color RootLinesColor
        {
            get => rootLinesColor;
            set { rootLinesColor = value; Invalidate(); }
        }

        public Color CheckBoxBackColor
        {
            get => checkBoxBack;
            set { checkBoxBack = value; Invalidate(); }
        }

        public Color CheckIconColor
        {
            get => checkIconColor;
            set { checkIconColor = value; Invalidate(); }
        }


        public int Indent
        {
            get => _indent;
            set { _indent = value; Invalidate(); }
        }

        public int NodeHeight
        {
            get => _nodeHeight;
            set { _nodeHeight = value; Invalidate(); }
        }

        public int SpaceBetweenNodes
        {
            get => spaceBetweenNodes;
            set { spaceBetweenNodes = value; Invalidate(); }
        }

        public bool ShowPlusMinus
        {
            get => _showPlusMinus;
            set { _showPlusMinus = value; Invalidate(); }
        }

        public bool ShowRootLines
        {
            get => _showRootLines;
            set { _showRootLines = value; Invalidate(); }
        }

        public bool CheckBoxVisible
        {
            get => checkBoxVisible;
            set { checkBoxVisible = value; Invalidate(); }
        }

        public bool AcceptNodeSelection
        {
            get => acceptNodeSelection;
            set { acceptNodeSelection = value; Invalidate(); }
        }

        public ImageList ImageList
        {
            get => _imageList;
            set { _imageList = value; Invalidate(); }
        }

        public string PathSeparator
        {
            get => pathSeparator;
            set { pathSeparator = value; Invalidate(); }
        }

        Font nodeFont = new Font("Arial", 10);
        public Font NodeFont
        {
            get => nodeFont;
            set { nodeFont = value; Invalidate(); }
        }

        System.Drawing.Text.TextRenderingHint renderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

        public System.Drawing.Text.TextRenderingHint TextRenderHint
        {
            get { return renderingHint; }
            set
            {
                renderingHint = value;
                Invalidate();
            }
        }

        Color plusMinusBoxColor = Color.Gray;

        public Color PlusMinusBoxColor
        {
            get { return plusMinusBoxColor; }
            set
            {
                plusMinusBoxColor = value;
                Invalidate();
            }
        }

        HeCopUI_Framework.Controls.ScrollBar.VScrollBar vScroll;

        public HTreeView()
        {
            SetStyle(GetAppResources.SetControlStyles(), true);
            nodes = new TreeNodeCollection(this);

            vScroll = new HeCopUI_Framework.Controls.ScrollBar.VScrollBar
            {
                ThumbPadding = new Padding(2),
                Dock = DockStyle.Right,
                Width = 15,
                Visible = false
            };

            Controls.Add(vScroll);
            vScroll.Scroll += VScroll_Scroll;

            UpdateScroll();
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            UpdateScroll();
        }

        private void VScroll_Scroll(object sender, ScrollEventArgs e)
        {
            UpdateScroll();
            Invalidate();
        }

        void UpdateScroll()
        {
            int totalHeight = CalculateHeight(nodes);
            int clientArea = Height - treeNodeBitmapPadding.Vertical;
            vScroll.Visible = totalHeight > clientArea;

            if (vScroll.Visible == true)
            {
                vScroll.Maximum = totalHeight - clientArea + (NodeHeight + spaceBetweenNodes * 2);
                vScroll.LargeChange = NodeHeight;
            }

        }

        private int CalculateHeight(TreeNodeCollection nodes)
        {
            int totalHeight = nodes.Count * (NodeHeight + SpaceBetweenNodes);
            foreach (TreeNode node in nodes)
            {
                if (node.IsExpanded == true)
                {
                    totalHeight += CalculateHeight(node.Nodes);
                }
            }

            return totalHeight;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            e.Graphics.TextRenderingHint = TextRenderHint;


            Bitmap bitmapTreeNodes = new Bitmap(Width - vScroll.Width - treeNodeBitmapPadding.Horizontal, Height - treeNodeBitmapPadding.Vertical); // Adjust width to account for scrollbar
            bitmapTreeNodes.MakeTransparent();
            using (Graphics g = Graphics.FromImage(bitmapTreeNodes))
            {
                g.TextRenderingHint = TextRenderHint;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                int y = -vScroll.Value + 1;
                DrawNodes(g, nodes, 0, ref y);
            }

            e.Graphics.DrawImage(bitmapTreeNodes, treeNodeBitmapPadding.Left, treeNodeBitmapPadding.Top);
            bitmapTreeNodes?.Dispose();

            e.Graphics.DrawRectangle(Pens.Black, 0, 0, Width - (vScroll.Visible ? vScroll.Width : 0), Height);
        }

        Padding treeNodeBitmapPadding = new Padding(5, 5, 5, 5);

        private void DrawNodes(Graphics g, TreeNodeCollection nodes, int x, ref int y, TreeNode parentNode = null)
        {
            StringFormat sf = new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center };
            Point mp = PointToClient(new Point(MousePosition.X - treeNodeBitmapPadding.Left, MousePosition.Y - treeNodeBitmapPadding.Top));
            foreach (TreeNode node in nodes)
            {
                node.Parent = parentNode;
                // Vẽ đường nối ngang giữa các node
                if (node.Parent != null)
                {
                    int lineX = x - Indent / 2;
                    int lineY = y + NodeHeight / 2;
                    using (Pen pen = new Pen(rootLinesColor, 1))
                        g.DrawLine(pen, lineX, lineY, lineX + Indent / 2, lineY);


                }

                int offsetCheckBox = CheckBoxVisible ? 20 : 0;
                Rectangle nodeBounds = new Rectangle(x + 15 + Indent / 2, y, Width - node.Bounds.X - 28 - (ImageList != null && node.Image != null ? ImageList.ImageSize.Width : 0) -
                    (vScroll.Visible ? vScroll.Width : 0) - Indent / 2, NodeHeight + 1);
                node.Bounds = nodeBounds;

                bool isHover = node.Bounds.Contains(mp);
                bool isSelected = node.IsSelected;

                using (var brush = new SolidBrush(isHover ? NodeHoverColor : isSelected ? NodeSelectedColor : NodeBackColor))
                {
                    g.FillRectangle(brush, nodeBounds);
                }

                using (var brush = new SolidBrush(nodeForeColor))
                {
                    g.DrawString(node.Text, nodeFont != null ? nodeFont : node.Font, brush, new RectangleF(nodeBounds.X + offsetCheckBox, nodeBounds.Y, nodeBounds.Width - offsetCheckBox, nodeBounds.Height), sf);
                }


                if (CheckBoxVisible)
                {
                    var checkBoxBound = new RectangleF(nodeBounds.X + checkBoxOffSetX, nodeBounds.Y + (NodeHeight / 2 - 7), 14, 14);
                    using (var brushCheckBoxBackground = new SolidBrush(checkBoxBack))
                    {
                        g.FillRectangle(brushCheckBoxBackground, checkBoxBound);
                    }
                    using (var brushCheckSign = new SolidBrush(checkIconColor))
                    {
                        if (node.CheckState == CheckState.Checked)
                        {
                            var bitmapCheck = CheckSign(brushCheckSign);
                            g.DrawImage(bitmapCheck, checkBoxBound);
                            bitmapCheck?.Dispose();
                        }
                    }
                }

                if (ImageList != null && node.Image != null)
                {
                    g.DrawImage(node.Image, x, y + ImageList.ImageSize.Height / 2, ImageList.ImageSize.Width, ImageList.ImageSize.Height);
                }


                if (node.IsFocused)
                {
                    using (var focusBrush = new SolidBrush(RevertColor(NodeBackColor)))
                    using (var penFocus = new Pen(focusBrush, 1) { Alignment = System.Drawing.Drawing2D.PenAlignment.Inset, DashStyle = System.Drawing.Drawing2D.DashStyle.Dot })
                    {
                        g.DrawRectangle(penFocus, nodeBounds);
                    }
                }

                if (ShowPlusMinus && node.Nodes.Count > 0)
                {
                    DrawPlusMinus(g, node, x, y);
                }

                if (ShowRootLines && node.Nodes.Count > 0 && node.IsExpanded)
                {
                    // Draw connecting vertical line
                    float lineX = node.Bounds.X - Indent + 5;
                    float lineY = node.Bounds.Y + NodeHeight;
                    using (Pen pen = new Pen(rootLinesColor, 1))
                    {
                        g.DrawLine(pen, lineX, lineY, lineX, node.Nodes[node.Nodes.Count - 1].Bounds.Y + NodeHeight / 2);
                    }
                }


                y += NodeHeight + SpaceBetweenNodes;

                if (node.IsExpanded)
                {
                    DrawNodes(g, node.Nodes, x + Indent, ref y, node);  // Truyền tham chiếu để cập nhật y
                }
            }


        }



        Color RevertColor(Color color)
        {
            return Color.FromArgb(255 - color.R, 255 - color.G, 255 - color.B);
        }

        Bitmap CheckSign(Brush signColor, int size = 14)
        {
            Bitmap bitmap = new Bitmap(size, size, System.Drawing.Imaging.PixelFormat.Format64bppPArgb);
            bitmap.MakeTransparent();
            using (Graphics g = Graphics.FromImage(bitmap))
            using (Pen pen = new Pen(signColor, 2))
            {
                size -= 2;
                g.TranslateTransform((size + 2) / 2 - size / 2, (size + 2) / 2 - size / 2);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.DrawLine(pen, 1, size - 5, size / 2 - 1, size - 1);
                g.DrawLine(pen, size / 2 - 1, size - 1, size - 1, 1);
            }
            return bitmap;
        }


        private void DrawPlusMinus(Graphics g, TreeNode node, int x, int y)
        {
            int iconSize = 16;
            RectangleF iconRect = new RectangleF(x + Indent / 2 - iconSize / 2, y + NodeHeight / 2 - iconSize / 2, iconSize, iconSize);

            using (var brushPlusMinus = new SolidBrush(PlusMinusColor))
            using (var brushPlusMinusBox = new SolidBrush(PlusMinusBoxColor))
            using (var pen = new Pen(brushPlusMinus))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.FillEllipse(brushPlusMinusBox, iconRect);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
                if (node.IsExpanded)
                {
                    g.DrawLine(pen, iconRect.Left + 4, iconRect.Top + 8, iconRect.Right - 4, iconRect.Top + 8); // Horizontal line
                }
                else
                {
                    g.DrawLine(pen, iconRect.Left + 8, iconRect.Top + 4, iconRect.Left + 8, iconRect.Bottom - 4); // Vertical line
                    g.DrawLine(pen, iconRect.Left + 4, iconRect.Top + 8, iconRect.Right - 4, iconRect.Top + 8); // Horizontal line
                }
            }
        }

        int checkBoxOffSetX = 5;

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (e.Button == MouseButtons.Left && !DesignMode)
            {
                Point p = new Point(e.Location.X - treeNodeBitmapPadding.Left, e.Location.Y - treeNodeBitmapPadding.Top);
                TreeNode node = GetNodeAtPoint(nodes, p);

                if (node != null && node.Bounds.Contains(p))
                {
                    var checkBoxBound = new RectangleF(node.Bounds.X + checkBoxOffSetX, node.Bounds.Y + (node.Bounds.Height / 2 - 7), 14, 14);
                    if (checkBoxVisible && checkBoxBound.Contains(p))
                    {
                        if (node.CheckState == CheckState.Checked)
                        {
                            OnAfterCheck(new TreeViewEventArgs(node));
                        }
                        else
                        {
                            OnBeforeCheck(new TreeViewCancelEventArgs(node));
                        }

                        node.Checked = !node.Checked;
                    }

                    if (acceptNodeSelection)
                    {

                        if (node.IsSelected)
                        {
                            OnAfterSelect(new TreeViewEventArgs(node));
                        }
                        else
                        {
                            OnBeforeSelect(new TreeViewCancelEventArgs(node));
                        }

                        node.IsSelected = !node.IsSelected;

                    }

                    Invalidate();
                }
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button == MouseButtons.Left && !DesignMode)
            {

                #region Focus node

                // Before, set IsFocused to false for all nodes
                foreach (TreeNode _node in nodes)
                {
                    _node.IsFocused = false;
                    SetIsFocused(_node.Nodes);
                }

                Point p = new Point(e.Location.X, e.Location.Y - treeNodeBitmapPadding.Top);
                TreeNode node = GetNodeAtPoint(nodes, p);

                if (node != null && node.Bounds.Contains(p))
                {
                    if (node.IsFocused)
                    {
                        // Trigger AfterSelect if already focused
                        OnAfterSelect(new TreeViewEventArgs(node));
                    }
                    else
                    {
                        // Trigger BeforeSelect and check if it should proceed
                        TreeViewCancelEventArgs beforeSelectArgs = new TreeViewCancelEventArgs(node);
                        OnBeforeSelect(beforeSelectArgs);
                        if (beforeSelectArgs.Cancel)
                            return;

                        // Update focus state if not cancelled
                        node.IsFocused = true;
                        OnAfterSelect(new TreeViewEventArgs(node));
                    }

                    Invalidate();
                }


                #endregion
            }

            Focus();
        }

        void SetIsFocused(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                node.IsFocused = false;
                SetIsFocused(node.Nodes);
            }
        }


        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            base.OnMouseDoubleClick(e);

            if (e.Button == MouseButtons.Left && !DesignMode)
            {
                Point p = new Point(e.Location.X, e.Location.Y - treeNodeBitmapPadding.Top);
                TreeNode clickedNode = GetNodeAtPoint(nodes, p);

                if (clickedNode != null && clickedNode.IsFocused)
                {
                    bool shouldExpand = !clickedNode.IsExpanded;

                    if (shouldExpand)
                    {
                        // Trigger BeforeExpand and check if it should proceed
                        TreeViewCancelEventArgs beforeExpandArgs = new TreeViewCancelEventArgs(clickedNode);
                        OnBeforeExpand(beforeExpandArgs);
                        if (beforeExpandArgs.Cancel)
                            return;

                        clickedNode.IsExpanded = true;
                        OnAfterExpand(new TreeViewEventArgs(clickedNode));
                    }
                    else
                    {
                        // Trigger BeforeCollapse and check if it should proceed
                        TreeViewCancelEventArgs beforeCollapseArgs = new TreeViewCancelEventArgs(clickedNode);
                        OnBeforeCollapse(beforeCollapseArgs);
                        if (beforeCollapseArgs.Cancel)
                            return;

                        clickedNode.IsExpanded = false;
                        OnAfterCollapse(new TreeViewEventArgs(clickedNode));
                    }

                    Invalidate();
                }
            }


        }


        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            base.OnPreviewKeyDown(e);

            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                if (!DesignMode)
                    e.IsInputKey = true;
            }
        }


        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (!DesignMode)
            {
                TreeNode focusedNode = GetNodeFocused(nodes);
                if (focusedNode == null)
                {
                    focusedNode = nodes[0];
                }
                // Deselect the currently focused node
                focusedNode.IsFocused = false;

                switch (e.KeyCode)
                {
                    case Keys.Down:

                        if (focusedNode.IsRoot && focusedNode.IsExpanded == false && focusedNode.Index >= 0 && focusedNode.Index < focusedNode.Nodes.Count)
                        {
                            int index = focusedNode.Index + 1;
                            if (index >= 0)
                                focusedNode = Nodes[index];
                        }

                        else if (focusedNode.IsExpanded && focusedNode.Nodes.Count > 0)
                        {
                            focusedNode = focusedNode.Nodes[0];
                        }
                        else
                        {
                            TreeNode nextNode = focusedNode.NextNode;
                            if (nextNode != null)
                            {
                                focusedNode = nextNode;
                            }
                        }


                        break;

                    case Keys.Up:

                        TreeNode prevNode = focusedNode.PreviousNode;
                        if (focusedNode.IsRoot && focusedNode.IsExpanded == false && focusedNode.Index >= 0 && focusedNode.Index < focusedNode.Nodes.Count)
                        {
                            int index = focusedNode.Index - 1;
                            if (index >= 0)
                                focusedNode = Nodes[index];

                        }
                        else if (prevNode != null)
                        {
                            focusedNode = prevNode;
                        }
                        else
                        {
                            focusedNode = focusedNode.Parent;
                            if (focusedNode != null)
                            {
                                focusedNode = focusedNode.LastNode;
                            }
                        }


                        break;

                    case Keys.Left:
                        if (focusedNode.IsExpanded)
                        {
                            focusedNode.IsExpanded = false;
                        }
                        else
                        {
                            focusedNode = focusedNode.Parent;
                        }
                        break;

                    case Keys.Right:
                        if (focusedNode.IsLeaf)
                            return;

                        if (!focusedNode.IsExpanded)
                        {
                            focusedNode.IsExpanded = true;
                        }
                        else
                        {
                            focusedNode = focusedNode.FirstNode;
                        }
                        break;
                }

                // Select the new focused node
                if (focusedNode != null)
                {
                    focusedNode.IsFocused = true;
                    Invalidate(); // Redraw the control
                }
            }
        }



        private TreeNode GetNodeAtPoint(TreeNodeCollection nodes, Point point)
        {
            foreach (TreeNode node in nodes)
            {
                Rectangle adjustedBounds = new Rectangle(node.Bounds.X, node.Bounds.Y, node.Bounds.Width, node.Bounds.Height);

                if (adjustedBounds.Contains(point))
                {
                    return node;
                }

                if (node.IsExpanded)
                {
                    TreeNode childNode = GetNodeAtPoint(node.Nodes, point);
                    if (childNode != null)
                    {
                        return childNode;
                    }
                }
            }

            return null;
        }

        TreeNode GetNodeFocused(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.IsFocused)
                {
                    return node;
                }

                if (node.IsExpanded)
                {
                    TreeNode childNode = GetNodeFocused(node.Nodes);
                    if (childNode != null)
                    {
                        return childNode;
                    }
                }
            }

            return null;
        }


        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            Invalidate();
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            if (!DesignMode)
            {
                UpdateScroll();
                if (vScroll.Visible)
                {
                    vScroll.Value -= e.Delta / 120 * SystemInformation.MouseWheelScrollLines;
                }
            }

            Refresh();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Invalidate(); // Update hover effects
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            Invalidate(); // Reset hover effects
        }


        // Declare the delegate
        public delegate void TreeViewEventHandler(object sender, TreeViewEventArgs e);
        public delegate void TreeViewCancelEventHandler(object sender, TreeViewCancelEventArgs e);

        // Declare the events
        public event TreeViewEventHandler AfterSelect;
        public event TreeViewCancelEventHandler BeforeSelect;
        public event TreeViewEventHandler AfterCheck;
        public event TreeViewEventHandler AfterCollapse;
        public event TreeViewEventHandler AfterExpand;
        public event TreeViewCancelEventHandler BeforeCheck;
        public event TreeViewCancelEventHandler BeforeCollapse;
        public event TreeViewCancelEventHandler BeforeExpand;

        // Method to raise the events
        protected virtual void OnAfterSelect(TreeViewEventArgs e)
        {
            AfterSelect?.Invoke(this, e);
            UpdateScroll();
            Refresh();
        }

        protected virtual void OnBeforeSelect(TreeViewCancelEventArgs e)
        {
            BeforeSelect?.Invoke(this, e);
            UpdateScroll();
            Refresh();
        }

        protected virtual void OnAfterCheck(TreeViewEventArgs e)
        {
            AfterCheck?.Invoke(this, e);
            UpdateScroll();
            Refresh();
        }

        protected virtual void OnAfterCollapse(TreeViewEventArgs e)
        {
            AfterCollapse?.Invoke(this, e);
            UpdateScroll();
            Refresh();
        }

        protected virtual void OnAfterExpand(TreeViewEventArgs e)
        {
            AfterExpand?.Invoke(this, e);
            UpdateScroll();
            Refresh();
        }

        protected virtual void OnBeforeCheck(TreeViewCancelEventArgs e)
        {
            BeforeCheck?.Invoke(this, e);
            UpdateScroll();
            Refresh();
        }

        protected virtual void OnBeforeCollapse(TreeViewCancelEventArgs e)
        {
            BeforeCollapse?.Invoke(this, e);
            UpdateScroll();
            Refresh();
        }

        protected virtual void OnBeforeExpand(TreeViewCancelEventArgs e)
        {
            BeforeExpand?.Invoke(this, e);
            UpdateScroll();
            Refresh();
        }



    }
}
