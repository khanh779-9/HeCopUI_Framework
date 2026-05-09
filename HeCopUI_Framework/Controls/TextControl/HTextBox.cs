using HeCopUI_Framework.Animations;
using HeCopUI_Framework.Helper;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;


namespace HeCopUI_Framework.Controls.TextControls
{
    [DefaultEvent("TextChanged")]
    [ToolboxBitmap(typeof(TextBox))]
    public class HTextBox : Control
    {
        private bool _underlineStyle = true;
        private TextBox _innerTextBox;
        private WatermarkControl _watermarkControl = new WatermarkControl();
        private Color _watermarkForeColor = Color.Gray;
        private Color _borderColor = Color.Gray;
        private Color _focusBorderColor = Color.FromArgb(86, 169, 128);
        private Image _image;


        AnimationManager _animationManager;

        public HTextBox()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            Cursor = Cursors.IBeam;
            base.ForeColor = Color.DimGray;

            // Animation
            _animationManager = new AnimationManager(true);
            _animationManager.OnAnimationProgress += sender => Invalidate();
            _animationManager.Increment = 0.08;

            _innerTextBox = new TextBox();
            Text = _innerTextBox.Text;
            _innerTextBox.BorderStyle = BorderStyle.None;
            _innerTextBox.TextChanged += InnerTextBox_TextChanged;

            _innerTextBox.GotFocus += InnerTextBox_GotFocus;
            _innerTextBox.LostFocus += InnerTextBox_LostFocus;


            _watermarkControl.Click += Watermark_Click;


            UpdateInnerTextBoxPosition();


        }

        private void InnerTextBox_LostFocus(object sender, EventArgs e)
        {
            if (_innerTextBox != null && _innerTextBox.IsHandleCreated && _useAnimation && !DesignMode)
            {
                _animationManager.StartNewAnimation(AnimationDirection.Out);
            }
        }

        private void InnerTextBox_GotFocus(object sender, EventArgs e)
        {
            if (_innerTextBox != null && _innerTextBox.IsHandleCreated && _useAnimation && !DesignMode)
            {
                _animationManager.StartNewAnimation(AnimationDirection.In);
            }
        }

        private void InnerTextBox_TextChanged(object sender, EventArgs e)
        {
            Text = _innerTextBox.Text;
            if (_innerTextBox != null && _innerTextBox.IsHandleCreated)
                _innerTextBox.Text = Text;
            Invalidate();
        }

        #region Properties for innerTextBox

        [Browsable(true)]
        [Category("Misc")]
        [Description("The font used by the text box.")]
        public new Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
                Invalidate();
            }
        }

        [Browsable(true)]
        [Category("Misc")]
        [Description("The background color of the text box.")]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                base.BackColor = value;
                Invalidate();
            }
        }

        [Browsable(true)]
        [Category("Misc")]
        [Description("The foreground color of the text box.")]
        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set
            {
                base.ForeColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the foreground color of watermark text.
        /// </summary>
        [Browsable(true)]
        [Category("Misc")]
        [Description("The foreground color of watermark text.")]
        public Color WatermarkForeColor
        {
            get { return _watermarkForeColor; }
            set
            {
                _watermarkForeColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the image of the TextBox control.
        /// </summary>
        [Description("The image of the TextBox control.")]
        public Image Image
        {
            get { return _image; }
            set
            {
                _image = value;
                Invalidate();
            }
        }

        private Size _imageSize = new Size(20, 20);
        /// <summary>
        /// Gets or sets the size of the image in the TextBox control.
        /// </summary>
        [Description("The size of the image in the TextBox control.")]
        public Size ImageSize
        {
            get { return _imageSize; }
            set
            {
                _imageSize = value;
                Invalidate();
            }
        }

        private bool _imageVisible = false;
        /// <summary>
        /// Gets or sets a value indicating whether the image is visible in the TextBox control.
        /// </summary>
        [Description("Indicates whether the image is visible in the TextBox control.")]
        public bool ImageVisible
        {
            get { return _imageVisible; }
            set
            {
                _imageVisible = value;
                Invalidate();
            }
        }

        private bool _imageAlignRight = false;
        /// <summary>
        /// Gets or sets a value indicating whether the image is aligned to the right in the TextBox control.
        /// </summary>
        [Description("Indicates whether the image is aligned to the right in the TextBox control.")]
        public bool ImageAlignRight
        {
            get { return _imageAlignRight; }
            set
            {
                _imageAlignRight = value;
                Invalidate();
            }
        }

        bool _multiline = false;
        /// <summary>
        /// Gets or sets a value indicating whether the text box is multiline.
        /// </summary>
        [Browsable(true)]
        [DefaultValue(false)]
        [Description("Indicates whether the text box is multiline.")]
        public bool Multiline
        {
            get { return _multiline; }
            set
            {
                _multiline = value;
                Invalidate();
            }
        }

        bool _readOnly = false;
        /// <summary>
        /// Gets or sets a value indicating whether the text box is read-only.
        /// </summary>
        [Browsable(true)]
        [Description("Indicates whether the text box is read-only.")]
        public bool ReadOnly
        {
            get { return _readOnly; }
            set
            {
                _readOnly = value;
                if (_innerTextBox != null && _innerTextBox.IsHandleCreated)
                    _innerTextBox.ReadOnly = value;
                Invalidate();
            }
        }

        bool _useSystemPasswordChar = false;

        /// <summary>
        /// Gets or sets a value indicating whether the text box control displays characters in the password character.
        /// </summary>
        [Browsable(true)]
        [DefaultValue(false)]
        [Description("Indicates whether the text box uses the password character.")]
        public bool UseSystemPasswordChar
        {
            get { return _useSystemPasswordChar; }
            set
            {
                _useSystemPasswordChar = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the border color of the TextBox control when it has focus.
        /// </summary>
        [Description("The border color of the TextBox control when it has focus.")]
        public Color FocusBorderColor
        {
            get { return _focusBorderColor; }
            set
            {
                _focusBorderColor = value;
                Invalidate();
            }
        }


        /// <summary>
        /// Gets or sets the text alignment within the text box.
        /// </summary>
        HorizontalAlignment _textAlign = HorizontalAlignment.Left;
        [Browsable(true)]
        [Description("The text alignment within the text box.")]
        public HorizontalAlignment TextAlign
        {
            get { return _textAlign; }
            set
            {
                _textAlign = value;
                Invalidate();
            }
        }

        #endregion

        #region Properties for CustomTextBox

        int _borderWidth = 1;
        /// <summary>
        /// Gets or sets the border width of the TextBox control.
        /// </summary>
        [Description("The border width of the TextBox control.")]
        public int BorderWidth
        {
            get { return _borderWidth; }
            set
            {
                _borderWidth = value;

                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the border color of the TextBox control.
        /// </summary>
        [Description("The border color of the TextBox control.")]
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                Invalidate();
            }
        }

        private string _watermark = "Type watermark text here.";
        [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [SettingsBindable(true)]
        /// <summary>
        /// Gets or sets the watermark text of the TextBox control.
        /// </summary>
        [Description("The watermark text of the TextBox control.")]
        public string Watermark
        {
            get { return _watermark; }
            set
            {
                _watermark = value;
                Invalidate();
            }
        }


        /// <summary>
        /// Gets or sets the underline style of the TextBox control.
        /// </summary>
        [Description("The underline style of the TextBox control.")]
        public bool UnderlineStyle
        {
            get { return _underlineStyle; }
            set
            {
                _underlineStyle = value;
                Invalidate();
            }
        }

        private TextRenderingHint _textRenderingHint = TextRenderingHint.ClearTypeGridFit;
        /// <summary>
        /// Gets or sets the text rendering hint of the text in the TextBox control.
        /// </summary>
        [Description("The text rendering hint of the text in the TextBox control.")]
        public TextRenderingHint TextRenderHint
        {
            get { return _textRenderingHint; }
            set
            {
                _textRenderingHint = value;
                Invalidate();
            }
        }

        private Font _watermarkFont = Control.DefaultFont;
        /// <summary>
        /// Gets or sets the font of the watermark text in the TextBox control.
        /// </summary>
        [Description("The font of the watermark text in the TextBox control.")]
        public Font WatermarkFont
        {
            get { return _watermarkFont; }
            set
            {
                _watermarkFont = value;
                Invalidate();
            }
        }

        [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [SettingsBindable(true)]
        [Category("Misc")]
        /// <summary>
        /// Gets or sets the text associated with this control.
        /// </summary>
        [Description("The text associated with this control.")]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                if (_innerTextBox != null && _innerTextBox.IsHandleCreated)
                    _innerTextBox.Text = value;
                Invalidate();
            }
        }

        private CharacterCasing _characterCasing = CharacterCasing.Normal;

        /// <summary>
        /// Gets or sets the character casing of the text in the TextBox control.
        /// </summary>
        /// <param name="e"></param>
        [Description("The character casing of the text in the TextBox control.")]
        public CharacterCasing CharacterCasing
        {
            get { return _characterCasing; }
            set
            {
                _characterCasing = value;
                Invalidate();
            }
        }

        private int _maxLength = 32767;
        /// <summary>
        /// Gets or sets the maximum number of characters the user can type or paste into the text box control.
        /// </summary>
        [Description("The maximum number of characters the user can type or paste into the text box control.")]
        public int MaxLength
        {
            get { return _maxLength; }
            set
            {
                _maxLength = value;
                Invalidate();
            }
        }

        private char _passwordChar = '\0';
        /// <summary>
        /// Gets or sets the character used to mask characters of a password in a single-line TextBox control.
        /// </summary>
        [Description("The character used to mask characters of a password in a single-line TextBox control.")]
        public char PasswordChar
        {
            get { return _passwordChar; }
            set
            {
                _passwordChar = value;
                Invalidate();
            }
        }

        private bool _shortCutKeysEnabled = true;
        /// <summary>
        /// Gets or sets a value indicating whether the defined shortcuts are enabled.
        /// </summary>
        [Description("A value indicating whether the defined shortcuts are enabled.")]
        public bool ShortCutKeysEnabled
        {
            get { return _shortCutKeysEnabled; }
            set
            {
                _shortCutKeysEnabled = value;
                Invalidate();
            }
        }

        private bool _hideSelection = true;
        /// <summary>
        /// Gets or sets a value indicating whether the selected text in the text box control remains highlighted when the control loses focus.
        /// </summary>
        public bool HideSelection
        {
            get { return _hideSelection; }
            set
            {
                _hideSelection = value;
                Invalidate();
            }
        }

        private bool _acceptReturn = false;
        /// <summary>
        /// Gets or sets a value indicating whether pressing ENTER in a multiline TextBox control creates a new line of text in the control or activates the default button for the form.
        /// </summary>
        [Description("A value indicating whether pressing ENTER in a multiline TextBox control creates a new line of text in the control or activates the default button for the form.")]
        public bool AcceptReturn
        {
            get { return _acceptReturn; }
            set
            {
                _acceptReturn = value;
                Invalidate();
            }
        }

        private bool _acceptTab = false;
        /// <summary>
        /// Gets or sets a value indicating whether pressing the TAB key in a multiline text box control types a TAB character in the control instead of moving the focus to the next control in the tab order.
        /// </summary>
        [Description("A value indicating whether pressing the TAB key in a multiline text box control types a TAB character in the control instead of moving the focus to the next control in the tab order.")]
        public bool AcceptTab
        {
            get { return _acceptTab; }
            set
            {
                _acceptTab = value;
                Invalidate();
            }
        }

        private bool _wordWrap = true;
        /// <summary>
        /// Gets or sets a value indicating whether text in the text box control is displayed using multiple lines.
        /// </summary>
        [Description("A value indicating whether text in the text box control is displayed using multiple lines.")]
        public bool WordWrap
        {
            get { return _wordWrap; }
            set
            {
                _wordWrap = value;
                Invalidate();
            }
        }

        private AutoCompleteStringCollection _autoCompleteCustomSource = new AutoCompleteStringCollection();
        /// <summary>
        /// Gets or sets the custom source for auto-complete strings.
        /// </summary>
        ///   [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Localizable(true)]
        [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Misc_AutoComplete")]
        public AutoCompleteStringCollection AutoCompleteCustomSource
        {
            get { return _autoCompleteCustomSource; }
            set
            {
                _autoCompleteCustomSource = value;
                Invalidate();
            }
        }

        private AutoCompleteMode _autoCompleteMode = AutoCompleteMode.None;
        /// <summary>
        /// Gets or sets an option that controls how automatic completion works for the TextBox.
        /// </summary>
        [Category("Misc_AutoComplete")]
        [DefaultValue(AutoCompleteMode.None)]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public AutoCompleteMode AutoCompleteMode
        {
            get { return _autoCompleteMode; }
            set
            {
                _autoCompleteMode = value;
                Invalidate();
            }
        }

        private AutoCompleteSource _autoCompleteSource = AutoCompleteSource.None;
        /// <summary>
        /// Gets or sets a value specifying the source of complete strings used for automatic completion.
        /// </summary>
        [Category("Misc_AutoComplete")]
        [DefaultValue(AutoCompleteSource.None)]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public AutoCompleteSource AutoCompleteSource
        {
            get { return _autoCompleteSource; }
            set
            {
                _autoCompleteSource = value;
                Invalidate();
            }
        }


        string[] lines = new string[] { };
        /// <summary>
        /// Gets the lines of text in a multiline TextBox control.
        /// </summary>
        public string[] Lines
        {
            get { return lines; }
            set
            {
                lines = value;
                Invalidate();
            }
        }

        private RightToLeft _rightToLeft = RightToLeft.No;
        /// <summary>
        /// Gets or sets a value indicating whether control's elements are aligned to support locales using right-to-left fonts.
        /// </summary>
        [Localizable(true)]
        [Category("Misc")]
        //[AmbientValue(RightToLeft.Inherit)]
        public override RightToLeft RightToLeft
        {
            get { return _rightToLeft; }
            set
            {
                _rightToLeft = value;
                Invalidate();
            }
        }

        private bool _useAnimation = false;
        /// <summary>
        /// Gets or sets a value indicating whether the TextBox control uses animation.
        /// </summary>
        /// <param name="e"></param>
        [Description("A value indicating whether the TextBox control uses animation.")]
        public bool UseAnimation
        {
            get { return _useAnimation; }
            set
            {
                _useAnimation = value;
                Invalidate();
            }
        }

        #endregion

        #region Events and methods

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            Pen pen = new Pen(new SolidBrush(_innerTextBox.Focused ?
                (_useAnimation ? ColorHelper.BlendColor(_borderColor, _focusBorderColor, _animationManager.GetProgress() * 255) : _focusBorderColor) :
                _borderColor), _underlineStyle ? BorderWidth + 1 : BorderWidth);


            // Draw image
            if (Image != null && ImageVisible)
            {
                if (ImageAlignRight)
                {
                    g.DrawImage(Image, Width - ImageSize.Width - 2 - BorderWidth, (Height - ImageSize.Height) / 2, ImageSize.Width, ImageSize.Height);
                }
                else
                {
                    g.DrawImage(Image, 2 + BorderWidth, (Height - ImageSize.Height) / 2, ImageSize.Width, ImageSize.Height);
                }
            }


            if (_underlineStyle)
            {
                // Calculate the progress of the animation
                float progress = (float)_animationManager.GetProgress();
                float midPoint = Width / 2;
                float startX = midPoint * (1 - progress);
                float endX = midPoint + (midPoint * progress);

                if (_useAnimation)
                {
                    var pen1 = new Pen(new SolidBrush(BorderColor), BorderWidth);
                    g.DrawLine(pen1, 0, Height - 1, Width, Height - 1);
                    pen1.Dispose();
                    // Draw the animated line from the center to the sides
                    g.DrawLine(pen, startX, Height - 1, endX, Height - 1);
                }
                else
                {
                    // Draw the line from the center to the sides
                    g.DrawLine(pen, 0, Height - 1, Width, Height - 1);
                }
            }
            else
            {
                // Draw the border
                g.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
            }

            pen.Dispose();
        }



        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            UpdateInnerTextBoxSize();
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            if (_innerTextBox != null && _innerTextBox.IsHandleCreated)
                _innerTextBox.Focus();
            Invalidate();
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            Invalidate();
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            if (_innerTextBox != null && _innerTextBox.IsHandleCreated)
                _innerTextBox.Focus();
            Invalidate();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            _innerTextBox.Text = Text;
            Invalidate();
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            Invalidate();
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            if (_innerTextBox != null && _innerTextBox.IsHandleCreated)
                _innerTextBox.Focus();
        }

        private void Watermark_Click(object sender, EventArgs e)
        {
            if (_innerTextBox != null && _innerTextBox.IsHandleCreated)
                _innerTextBox.Focus();
            Invalidate();
        }


        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            UpdateTextAndWatermark();
            UpdateInnerTextBoxPosition();

        }

        protected override void OnInvalidated(InvalidateEventArgs e)
        {
            UpdateInnerTextBoxPosition();
            base.OnInvalidated(e);
        }

        void UpdateTextAndWatermark()
        {
            if (_innerTextBox != null && !Controls.Contains(_innerTextBox))
                Controls.Add(_innerTextBox);

            if (_watermarkControl != null && !Controls.Contains(_watermarkControl))
            {
                Controls.Add(_watermarkControl);
                _watermarkControl.BringToFront();
            }
            Invalidate();
        }

        protected override void OnCursorChanged(EventArgs e)
        {
            base.OnCursorChanged(e);
            if (_innerTextBox != null && _innerTextBox.IsHandleCreated)
            {
                _innerTextBox.Cursor = Cursor;
            }
            if (_watermarkControl != null && _watermarkControl.IsHandleCreated)
            {
                _watermarkControl.Cursor = Cursor;

            }
            Invalidate();
        }

        int _offsetX = 1;

        void UpdateInnerTextBoxPosition()
        {

            if (_innerTextBox != null && _innerTextBox.IsHandleCreated)
            {
                _innerTextBox.Location = new Point(BorderWidth + (_imageVisible && _image != null ? ImageSize.Width : 0) + _offsetX, (Height - _innerTextBox.Height) / 2);

                if (_watermarkControl != null && _watermarkControl.IsHandleCreated)
                {
                    _watermarkControl.Size = new Size(Width - _offsetX - 1 - BorderWidth * 2 - (_imageVisible && _image != null ? ImageSize.Width : 0) - 3, _innerTextBox.Height);
                    _watermarkControl.Location = new Point(_innerTextBox.Location.X + (TextAlign == HorizontalAlignment.Left ? 1 : TextAlign == HorizontalAlignment.Right ? -1 : 0),
                        _innerTextBox.Location.Y);

                    _watermarkControl.Text = _watermark;
                    _watermarkControl.Font = WatermarkFont;
                    _watermarkControl.ForeColor = WatermarkForeColor;
                    _watermarkControl.TextRenderHint = TextRenderHint;
                    _watermarkControl.TextAlign = TextAlign;
                    _watermarkControl.BackColor = BackColor;

                }
                if (_innerTextBox != null && _innerTextBox.IsHandleCreated)
                {
                    if (_watermarkControl != null && _watermarkControl.IsHandleCreated)
                        _watermarkControl.Visible = string.IsNullOrEmpty(_innerTextBox.Text) && !Multiline && TextAlign != HorizontalAlignment.Center;

                    _innerTextBox.Font = Font;
                    _innerTextBox.BackColor = BackColor;
                    _innerTextBox.ForeColor = ForeColor;
                    _innerTextBox.Multiline = Multiline;
                    _innerTextBox.ReadOnly = ReadOnly;
                    _innerTextBox.UseSystemPasswordChar = UseSystemPasswordChar;
                    _innerTextBox.TextAlign = TextAlign;
                    _innerTextBox.CharacterCasing = CharacterCasing;
                    _innerTextBox.MaxLength = MaxLength;
                    _innerTextBox.PasswordChar = PasswordChar;
                    _innerTextBox.ShortcutsEnabled = ShortCutKeysEnabled;
                    _innerTextBox.HideSelection = HideSelection;
                    _innerTextBox.AcceptsReturn = AcceptReturn;
                    _innerTextBox.AcceptsTab = AcceptTab;
                    _innerTextBox.WordWrap = WordWrap;

                    _innerTextBox.RightToLeft = RightToLeft;

                    //innerTextBox.AutoCompleteCustomSource = AutoCompleteCustomSource;
                    //if (innerTextBox.Created && innerTextBox.IsHandleCreated)
                    //{
                    //    innerTextBox.AutoCompleteMode = AutoCompleteMode;
                    //}
                    //innerTextBox.AutoCompleteSource = AutoCompleteSource;

                    if (Lines.Length > 0)
                        _innerTextBox.Lines = Lines;
                }


                UpdateInnerTextBoxSize();
            }
        }

        void UpdateInnerTextBoxSize()
        {
            if (_innerTextBox != null && _innerTextBox.IsHandleCreated)
            {
                _innerTextBox.Width = Width - _offsetX - 2 - BorderWidth * 2 - (_imageVisible && _image != null ? ImageSize.Width : 0);


                if (Height <= (Multiline ? 40 : _innerTextBox.Height + BorderWidth * 2 + 4))
                {
                    Height = Multiline ? 40 : _innerTextBox.Height + BorderWidth * 2 + 4;

                }
                if (Multiline)
                    _innerTextBox.Height = Height - 2 - BorderWidth * 2;

                if (Width < 100)
                {
                    Width = _innerTextBox.Width + BorderWidth * 2 + 4;
                }

            }
        }

        #endregion

        private class WatermarkControl : Control
        {
            public WatermarkControl()
            {
                SetStyle(ControlStyles.OptimizedDoubleBuffer |
                         ControlStyles.SupportsTransparentBackColor, true);
            }

            private TextRenderingHint _textRenderingHint = TextRenderingHint.ClearTypeGridFit;
            /// <summary>
            /// Gets or sets the text rendering hint of the text in the TextBox control.
            /// </summary>
            [Description("The text rendering hint of the text in the TextBox control.")]
            public TextRenderingHint TextRenderHint
            {
                get
                {
                    return _textRenderingHint;
                }
                set
                {
                    _textRenderingHint = value;
                    Invalidate();
                }
            }

            private HorizontalAlignment _textAlign = HorizontalAlignment.Left;
            /// <summary>
            /// Gets or sets the text alignment within the text box.
            /// </summary>
            [Description("The text alignment within the text box.")]
            public HorizontalAlignment TextAlign
            {
                get
                {
                    return _textAlign;
                }
                set
                {
                    _textAlign = value;
                    Invalidate();
                }
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                Graphics g = e.Graphics;

                g.TextRenderingHint = _textRenderingHint;

                using (StringFormat sf = new StringFormat
                {
                    LineAlignment = StringAlignment.Center
                })
                {
                    switch (_textAlign)
                    {
                        case HorizontalAlignment.Left:
                            sf.Alignment = StringAlignment.Near;
                            break;
                        case HorizontalAlignment.Center:
                            sf.Alignment = StringAlignment.Center;
                            break;
                        case HorizontalAlignment.Right:
                            sf.Alignment = StringAlignment.Far;
                            break;
                    }
                    sf.Trimming = StringTrimming.EllipsisCharacter;

                    using (var bru = new SolidBrush(ForeColor))
                        g.DrawString(Text, Font, bru, ClientRectangle, sf);
                }
            }
        }
    }
}
