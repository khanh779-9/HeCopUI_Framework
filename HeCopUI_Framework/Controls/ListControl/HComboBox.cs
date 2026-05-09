using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls.ListControl
{
    public partial class HComboBox : ComboBox
    {
        public HComboBox()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);

            BackColor = Color.Transparent;
            //AllowDrop = true;
            DrawMode = DrawMode.OwnerDrawFixed;
            ItemHeight = 20;
            base.FlatStyle = FlatStyle.Flat;
            CausesValidation = false;
            base.DropDownStyle = ComboBoxStyle.DropDownList;

        }



        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ComboBoxStyle DropDownStyle { get; set; } = ComboBoxStyle.DropDownList;

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new FlatStyle FlatStyle { get; set; } = FlatStyle.Flat;


        private Color _selectedItemForeColor = Color.White;
        public Color SelectedItemForeColor
        {
            get { return _selectedItemForeColor; }
            set
            {
                _selectedItemForeColor = value; Invalidate();
            }
        }

        private Color _itemForeColor = Color.FromArgb(80, 80, 80);
        public Color ItemForeColor
        {
            get { return _itemForeColor; }
            set
            {
                _itemForeColor = value; Invalidate();
            }
        }

        private Color _selectedItemBackColor = Color.FromArgb(0, 168, 148);
        public Color SelectedItemBackColor
        {
            get { return _selectedItemBackColor; }
            set
            {
                _selectedItemBackColor = value; Invalidate();
            }
        }

        private Font _itemsFont = Control.DefaultFont;
        public Font ItemsFont
        {
            get { return _itemsFont; }
            set
            {
                _itemsFont = value; Invalidate();
            }
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            var g = e.Graphics;
            e.DrawBackground();
            g.TextRenderingHint = _textRenderingHint;

            if (e.Index == -1)
            {
                return;
            }

            var sf = new StringFormat
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Center,
                Trimming = _textTrim
            };

            var itemState = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
            using (var bg = new SolidBrush(itemState ? SelectedItemBackColor : BackgroundColor))
            using (var tc = new SolidBrush(itemState ? SelectedItemForeColor : ItemForeColor))
            {
                SizeF a = g.MeasureString(GetItemText(Items[e.Index]), _itemsFont);
                g.FillRectangle(bg, e.Bounds);
                g.DrawString(GetItemText(Items[e.Index]), ItemsFont, tc, new RectangleF(
                    e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height), sf);
            }

            //g.DrawRectangle(new Pen(new SolidBrush(SelectedItemBackColor), 1) { Alignment = System.Drawing.Drawing2D.PenAlignment.Inset },
            // new Rectangle(0, 0, DropDownWidth, DropDownHeight));
            g.Dispose();
            base.OnDrawItem(e);
        }



        /*protected override void OnMeasureItem(MeasureItemEventArgs e)
        {
            HeCopUI_Framework.Helper.GraphicsHelper.SetHightGraphics(e.Graphics);
            e.Graphics.TextRenderingHint = textRendering;

            for (int i = 0; i < e.Index - 1;i++)
            {
                e.Graphics.DrawString(Items[i].ToString(), Font, new SolidBrush(it), 0, , null);
            }
            base.OnMeasureItem(e);
        }*/



        System.Drawing.Text.TextRenderingHint _textRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
        public System.Drawing.Text.TextRenderingHint TextRendergHint
        {
            get { return _textRenderingHint; }
            set
            {
                _textRenderingHint = value; Invalidate();
            }
        }





        private Color _borderColor = Global.PrimaryColors.BorderNormalColor1;
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value; Invalidate();
            }
        }

        private Color _backgroundColor = Color.White;
        public Color BackgroundColor
        {
            get { return _backgroundColor; }
            set
            {
                _backgroundColor = value; Invalidate();
            }
        }

        private Color _disabledBackColor = Color.WhiteSmoke;
        public Color DisabledBackColor
        {
            get { return _disabledBackColor; }
            set
            {
                _disabledBackColor = value; Invalidate();
            }
        }

        private Color _disabledBorderColor = Color.FromArgb(60, 60, 60);
        public Color DisabledBorderColor
        {
            get { return _disabledBorderColor; }
            set
            {
                _disabledBorderColor = value; Invalidate();
            }
        }


        private Color _arrowColor = Color.FromArgb(0, 168, 118);
        public Color ArrowColor
        {
            get { return _arrowColor; }
            set
            {
                _arrowColor = value; Invalidate();
            }
        }

        private Color _disabledForeColor = Color.FromArgb(64, 64, 64);
        public Color DisabledForeColor
        {
            get { return _disabledForeColor; }
            set
            {
                _disabledForeColor = value; Invalidate();
            }
        }

        private StringTrimming _textTrim = StringTrimming.EllipsisCharacter;
        public StringTrimming TextTrim
        {
            get { return _textTrim; }
            set
            {
                _textTrim = value; Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            var rect = new Rectangle(0, 0, Width - 1, Height - 1);
            var downArrow = '▼';
            var sf = new StringFormat
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Center
            };
            g.TextRenderingHint = _textRenderingHint;
            sf.Trimming = _textTrim;

            using (var bg = new SolidBrush(Enabled ? BackgroundColor : DisabledBackColor))
            {
                using (var p = new Pen(Enabled ? BorderColor : DisabledBorderColor, 1) { Alignment = System.Drawing.Drawing2D.PenAlignment.Inset })
                {
                    using (var s = new SolidBrush(Enabled ? ArrowColor : DisabledForeColor))
                    {
                        using (var tb = new SolidBrush(Enabled ? SelectedItemBackColor : DisabledForeColor))
                        {
                            g.FillRectangle(bg, rect);
                            SizeF b = g.MeasureString(downArrow.ToString(), new Font(Font.Name, 10f));
                            g.DrawString(downArrow.ToString(), new Font(Font.Name, 10f), s,
                                new RectangleF(Width - 18, 0, b.Width, Height), sf);

                            g.DrawString(Text, Font, tb, new RectangleF(4, 1, Width - 1 - b.Width, Height - 2),
                               sf);
                            g.DrawRectangle(p, rect);
                        }
                    }
                }
            }
            //g.Dispose();
            if (go)
            {
                g.DrawRectangle(new Pen(new SolidBrush(FocusBorderColor), 1f)
                {
                    Alignment = System.Drawing.Drawing2D.PenAlignment.Inset,
                    DashStyle = dashStyle
                }, new Rectangle(2, 2, Width - 5, Height - 5));
            }

            base.OnPaint(e);
        }

        bool go = false;
        protected override void OnEnter(EventArgs e)
        {
            go = true;
            Invalidate();
            base.OnEnter(e);
        }

        private DashStyle dashStyle = DashStyle.Dot;
        public DashStyle DashStyle
        {
            get { return dashStyle; }
            set
            {
                dashStyle = value; Invalidate();
            }
        }

        public Color FocusBorderColor { get; set; } = Color.DodgerBlue;

        protected override void OnLeave(EventArgs e)
        {
            go = false;
            Invalidate();

            base.OnLeave(e);
        }
    }
}
