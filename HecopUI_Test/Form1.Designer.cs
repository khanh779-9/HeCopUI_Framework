using HeCopUI_Framework.Controls.Container;
using HeCopUI_Framework.Controls.Button;
using HeCopUI_Framework.Controls.Progress;
using HeCopUI_Framework.Controls.TextControl;
using HeCopUI_Framework.Enums;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static HeCopUI_Framework.GetAppResources;
using HScrollBar = HeCopUI_Framework.Controls.ScrollBar.VScrollBar;
using HeCopUI_Framework.Controls;
using HeCopUI_Framework.Controls.Gauge;
using HeCopUI_Framework.Controls.Clock;
using HeCopUI_Framework.Controls.Indicators;

namespace HecopUI_Test
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            HeCopUI_Framework.Controls.TreeView.TreeNode treeNode25 = new HeCopUI_Framework.Controls.TreeView.TreeNode();
            HeCopUI_Framework.Controls.TreeView.TreeNode treeNode26 = new HeCopUI_Framework.Controls.TreeView.TreeNode();
            HeCopUI_Framework.Controls.TreeView.TreeNode treeNode27 = new HeCopUI_Framework.Controls.TreeView.TreeNode();
            HeCopUI_Framework.Controls.TreeView.TreeNode treeNode28 = new HeCopUI_Framework.Controls.TreeView.TreeNode();
            HeCopUI_Framework.Controls.TreeView.TreeNode treeNode29 = new HeCopUI_Framework.Controls.TreeView.TreeNode();
            HeCopUI_Framework.Controls.TreeView.TreeNode treeNode30 = new HeCopUI_Framework.Controls.TreeView.TreeNode();
            HeCopUI_Framework.Controls.TreeView.TreeNode treeNode31 = new HeCopUI_Framework.Controls.TreeView.TreeNode();
            HeCopUI_Framework.Controls.TreeView.TreeNode treeNode32 = new HeCopUI_Framework.Controls.TreeView.TreeNode();
            HeCopUI_Framework.Controls.TreeView.TreeNode treeNode33 = new HeCopUI_Framework.Controls.TreeView.TreeNode();
            HeCopUI_Framework.Controls.TreeView.TreeNode treeNode34 = new HeCopUI_Framework.Controls.TreeView.TreeNode();
            HeCopUI_Framework.Controls.TreeView.TreeNode treeNode35 = new HeCopUI_Framework.Controls.TreeView.TreeNode();
            HeCopUI_Framework.Controls.TreeView.TreeNode treeNode36 = new HeCopUI_Framework.Controls.TreeView.TreeNode();
            HeCopUI_Framework.Controls.TreeView.TreeNode treeNode37 = new HeCopUI_Framework.Controls.TreeView.TreeNode();
            HeCopUI_Framework.Controls.TreeView.TreeNode treeNode38 = new HeCopUI_Framework.Controls.TreeView.TreeNode();
            HeCopUI_Framework.Controls.TreeView.TreeNode treeNode39 = new HeCopUI_Framework.Controls.TreeView.TreeNode();
            HeCopUI_Framework.Controls.TreeView.TreeNode treeNode40 = new HeCopUI_Framework.Controls.TreeView.TreeNode();
            HeCopUI_Framework.Controls.TreeView.TreeNode treeNode41 = new HeCopUI_Framework.Controls.TreeView.TreeNode();
            HeCopUI_Framework.Controls.TreeView.TreeNode treeNode42 = new HeCopUI_Framework.Controls.TreeView.TreeNode();
            HeCopUI_Framework.Controls.TreeView.TreeNode treeNode43 = new HeCopUI_Framework.Controls.TreeView.TreeNode();
            HeCopUI_Framework.Controls.TreeView.TreeNode treeNode44 = new HeCopUI_Framework.Controls.TreeView.TreeNode();
            HeCopUI_Framework.Controls.TreeView.TreeNode treeNode45 = new HeCopUI_Framework.Controls.TreeView.TreeNode();
            HeCopUI_Framework.Controls.TreeView.TreeNode treeNode46 = new HeCopUI_Framework.Controls.TreeView.TreeNode();
            HeCopUI_Framework.Controls.TreeView.TreeNode treeNode47 = new HeCopUI_Framework.Controls.TreeView.TreeNode();
            HeCopUI_Framework.Controls.TreeView.TreeNode treeNode48 = new HeCopUI_Framework.Controls.TreeView.TreeNode();
            HeCopUI_Framework.Controls.Chart.Series series2 = new HeCopUI_Framework.Controls.Chart.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.colorDialog2 = new System.Windows.Forms.ColorDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.hTabControl1 = new HeCopUI_Framework.Controls.Container.HTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.hLabel10 = new HeCopUI_Framework.Controls.TextControl.HLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.hLabel9 = new HeCopUI_Framework.Controls.TextControl.HLabel();
            this.hLabel8 = new HeCopUI_Framework.Controls.TextControl.HLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.hLabel7 = new HeCopUI_Framework.Controls.TextControl.HLabel();
            this.hLabel6 = new HeCopUI_Framework.Controls.TextControl.HLabel();
            this.hLabel5 = new HeCopUI_Framework.Controls.TextControl.HLabel();
            this.hLabel4 = new HeCopUI_Framework.Controls.TextControl.HLabel();
            this.hLabel3 = new HeCopUI_Framework.Controls.TextControl.HLabel();
            this.hLabel2 = new HeCopUI_Framework.Controls.TextControl.HLabel();
            this.hLabel1 = new HeCopUI_Framework.Controls.TextControl.HLabel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.hTabControl5 = new HeCopUI_Framework.Controls.Container.HTabControl();
            this.tabPage24 = new System.Windows.Forms.TabPage();
            this.hButton7 = new HeCopUI_Framework.Controls.Button.HButton();
            this.hButton8 = new HeCopUI_Framework.Controls.Button.HButton();
            this.hButton9 = new HeCopUI_Framework.Controls.Button.HButton();
            this.hButton4 = new HeCopUI_Framework.Controls.Button.HButton();
            this.hButton5 = new HeCopUI_Framework.Controls.Button.HButton();
            this.hButton6 = new HeCopUI_Framework.Controls.Button.HButton();
            this.hButton3 = new HeCopUI_Framework.Controls.Button.HButton();
            this.hButton2 = new HeCopUI_Framework.Controls.Button.HButton();
            this.hButton1 = new HeCopUI_Framework.Controls.Button.HButton();
            this.tabPage25 = new System.Windows.Forms.TabPage();
            this.HTileButton7 = new HeCopUI_Framework.Controls.Button.HTileButton();
            this.HTileButton8 = new HeCopUI_Framework.Controls.Button.HTileButton();
            this.HTileButton9 = new HeCopUI_Framework.Controls.Button.HTileButton();
            this.HTileButton4 = new HeCopUI_Framework.Controls.Button.HTileButton();
            this.HTileButton5 = new HeCopUI_Framework.Controls.Button.HTileButton();
            this.HTileButton6 = new HeCopUI_Framework.Controls.Button.HTileButton();
            this.HTileButton3 = new HeCopUI_Framework.Controls.Button.HTileButton();
            this.HTileButton2 = new HeCopUI_Framework.Controls.Button.HTileButton();
            this.HTileButton1 = new HeCopUI_Framework.Controls.Button.HTileButton();
            this.tabPage26 = new System.Windows.Forms.TabPage();
            this.HTileSubtitleButton7 = new HeCopUI_Framework.Controls.Button.HTileSubtitleButton();
            this.HTileSubtitleButton8 = new HeCopUI_Framework.Controls.Button.HTileSubtitleButton();
            this.HTileSubtitleButton9 = new HeCopUI_Framework.Controls.Button.HTileSubtitleButton();
            this.HTileSubtitleButton4 = new HeCopUI_Framework.Controls.Button.HTileSubtitleButton();
            this.HTileSubtitleButton5 = new HeCopUI_Framework.Controls.Button.HTileSubtitleButton();
            this.HTileSubtitleButton6 = new HeCopUI_Framework.Controls.Button.HTileSubtitleButton();
            this.HTileSubtitleButton3 = new HeCopUI_Framework.Controls.Button.HTileSubtitleButton();
            this.HTileSubtitleButton2 = new HeCopUI_Framework.Controls.Button.HTileSubtitleButton();
            this.HTileSubtitleButton1 = new HeCopUI_Framework.Controls.Button.HTileSubtitleButton();
            this.tabPage27 = new System.Windows.Forms.TabPage();
            this.hRadioButton3 = new HeCopUI_Framework.Controls.Button.HRadioButton();
            this.hRadioButton2 = new HeCopUI_Framework.Controls.Button.HRadioButton();
            this.hCheckBox3 = new HeCopUI_Framework.Controls.Button.HCheckBox();
            this.hCheckBox2 = new HeCopUI_Framework.Controls.Button.HCheckBox();
            this.hRadioButton1 = new HeCopUI_Framework.Controls.Button.HRadioButton();
            this.hToggleButton1 = new HeCopUI_Framework.Controls.Button.HToggleButton();
            this.hCheckBox1 = new HeCopUI_Framework.Controls.Button.HCheckBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.hEffectImage1 = new HeCopUI_Framework.Controls.Effect.HEffectImage();
            this.hImage1 = new HeCopUI_Framework.Controls.HImage();
            this.tabPage22 = new System.Windows.Forms.TabPage();
            this.hTabControl10 = new HeCopUI_Framework.Controls.Container.HTabControl();
            this.tabPage35 = new System.Windows.Forms.TabPage();
            this.hTreeView1 = new HeCopUI_Framework.Controls.TreeView.HTreeView();
            this.tabPage36 = new System.Windows.Forms.TabPage();
            this.hButton11 = new HeCopUI_Framework.Controls.Button.HButton();
            this.hTabControl4 = new HeCopUI_Framework.Controls.Container.HTabControl();
            this.tabPage15 = new System.Windows.Forms.TabPage();
            this.hBarChart1 = new HeCopUI_Framework.Controls.Chart.HBarChart();
            this.tabPage16 = new System.Windows.Forms.TabPage();
            this.hLineAreaChart1 = new HeCopUI_Framework.Controls.Chart.HLineAreaChart();
            this.tabPage17 = new System.Windows.Forms.TabPage();
            this.hPieChart1 = new HeCopUI_Framework.Controls.Chart.HPieChart();
            this.tabPage18 = new System.Windows.Forms.TabPage();
            this.hRadarChart1 = new HeCopUI_Framework.Controls.Chart.HRadarChart();
            this.tabPage14 = new System.Windows.Forms.TabPage();
            this.tabPage21 = new System.Windows.Forms.TabPage();
            this.hTextBox2 = new HeCopUI_Framework.Controls.TextControls.HTextBox();
            this.hTextBox1 = new HeCopUI_Framework.Controls.TextControls.HTextBox();
            this.hRichTextBox2 = new HeCopUI_Framework.Controls.TextControl.HRichTextBox();
            this.hRichTextBox1 = new HeCopUI_Framework.Controls.TextControl.HRichTextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.hTabControl6 = new HeCopUI_Framework.Controls.Container.HTabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.hStepIndicatorOne1 = new HeCopUI_Framework.Controls.HStepIndicatorOne();
            this.hProgressRing2 = new HeCopUI_Framework.Controls.Progress.HProgressRing();
            this.waveProgressLoading1 = new HeCopUI_Framework.Controls.Progress.WaveProgressLoading();
            this.hDotProgressRing8 = new HeCopUI_Framework.Controls.Progress.HDotProgressRing();
            this.hDotProgressRing7 = new HeCopUI_Framework.Controls.Progress.HDotProgressRing();
            this.hDotProgressRing6 = new HeCopUI_Framework.Controls.Progress.HDotProgressRing();
            this.hDotProgressRing5 = new HeCopUI_Framework.Controls.Progress.HDotProgressRing();
            this.hDotProgressRing4 = new HeCopUI_Framework.Controls.Progress.HDotProgressRing();
            this.hDotProgressRing3 = new HeCopUI_Framework.Controls.Progress.HDotProgressRing();
            this.hDotProgressRing2 = new HeCopUI_Framework.Controls.Progress.HDotProgressRing();
            this.hDotProgressRing1 = new HeCopUI_Framework.Controls.Progress.HDotProgressRing();
            this.tabPage28 = new System.Windows.Forms.TabPage();
            this.hCircularProgressBar2 = new HeCopUI_Framework.Controls.Progress.HCircularProgressBar();
            this.hCircularProgressBar21 = new HeCopUI_Framework.Controls.Progress.HCircularProgressBar2();
            this.hCircularProgressBar11 = new HeCopUI_Framework.Controls.Progress.HCircularProgressBar1();
            this.hCircularProgressBar1 = new HeCopUI_Framework.Controls.Progress.HCircularProgressBar();
            this.tabPage29 = new System.Windows.Forms.TabPage();
            this.hButton10 = new HeCopUI_Framework.Controls.Button.HButton();
            this.hProgressBar4 = new HeCopUI_Framework.Controls.Progress.HProgressBar();
            this.hProgressBar5 = new HeCopUI_Framework.Controls.Progress.HProgressBar();
            this.hProgressBar6 = new HeCopUI_Framework.Controls.Progress.HProgressBar();
            this.hProgressBar3 = new HeCopUI_Framework.Controls.Progress.HProgressBar();
            this.hProgressBar2 = new HeCopUI_Framework.Controls.Progress.HProgressBar();
            this.hProgressBar1 = new HeCopUI_Framework.Controls.Progress.HProgressBar();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.hTabControl9 = new HeCopUI_Framework.Controls.Container.HTabControl();
            this.tabPage20 = new System.Windows.Forms.TabPage();
            this.hhTrackBar1 = new HeCopUI_Framework.Controls.HHTrackBar();
            this.hCircleAnglePicker1 = new HeCopUI_Framework.Controls.HCircleAnglePicker();
            this.hRadialRangeSlider1 = new HeCopUI_Framework.Controls.HRadialRangeSlider();
            this.tabPage34 = new System.Windows.Forms.TabPage();
            this.hSolidGauge2 = new HeCopUI_Framework.Controls.Gauge.HSolidGauge();
            this.hDigitalGauge2 = new HeCopUI_Framework.Controls.Gauge.HDigitalGauge();
            this.tabPage19 = new System.Windows.Forms.TabPage();
            this.hScrollBar3 = new HeCopUI_Framework.Controls.ScrollBar.VScrollBar();
            this.hScrollBar4 = new HeCopUI_Framework.Controls.ScrollBar.VScrollBar();
            this.hScrollBar2 = new HeCopUI_Framework.Controls.ScrollBar.VScrollBar();
            this.hScrollBar1 = new HeCopUI_Framework.Controls.ScrollBar.VScrollBar();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.hTabControl8 = new HeCopUI_Framework.Controls.Container.HTabControl();
            this.tabPage32 = new System.Windows.Forms.TabPage();
            this.HPanel1 = new HeCopUI_Framework.Controls.Container.HPanel();
            this.tabPage33 = new System.Windows.Forms.TabPage();
            this.hTabControl3 = new HeCopUI_Framework.Controls.Container.HTabControl();
            this.tabPage12 = new System.Windows.Forms.TabPage();
            this.tabPage13 = new System.Windows.Forms.TabPage();
            this.hTabControl2 = new HeCopUI_Framework.Controls.Container.HTabControl();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.tabPage11 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.hTabControl7 = new HeCopUI_Framework.Controls.Container.HTabControl();
            this.tabPage30 = new System.Windows.Forms.TabPage();
            this.hClock1 = new HeCopUI_Framework.Controls.Clock.HClock();
            this.hClockDigital1 = new HeCopUI_Framework.Controls.Clock.HClockDigital();
            this.tabPage31 = new System.Windows.Forms.TabPage();
            this.calendarControl1 = new HeCopUI_Framework.Controls.Calendar.CalendarControl();
            this.simpleCalendarControl1 = new HeCopUI_Framework.Controls.Calendar.SimpleCalendarControl();
            this.hMontCalendar1 = new HeCopUI_Framework.Controls.HMontCalendar();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.tabPageIndicators = new System.Windows.Forms.TabPage();
            this.flowLayoutPanelIndicators = new System.Windows.Forms.FlowLayoutPanel();
            this.arcRotateIndicator1 = new HeCopUI_Framework.Controls.Indicators.ArcRotateIndicator();
            this.bouncingBarsIndicator1 = new HeCopUI_Framework.Controls.Indicators.BouncingBarsIndicator();
            this.circlePulseIndicator1 = new HeCopUI_Framework.Controls.Indicators.CirclePulseIndicator();
            this.dashesIndicator1 = new HeCopUI_Framework.Controls.Indicators.DashesIndicator();
            this.dualRingIndicator1 = new HeCopUI_Framework.Controls.Indicators.DualRingIndicator();
            this.fadingCircleIndicator1 = new HeCopUI_Framework.Controls.Indicators.FadingCircleIndicator();
            this.fourDotsIndicator1 = new HeCopUI_Framework.Controls.Indicators.FourDotsIndicator();
            this.growingDotsIndicator1 = new HeCopUI_Framework.Controls.Indicators.GrowingDotsIndicator();
            this.infinityIndicator1 = new HeCopUI_Framework.Controls.Indicators.InfinityIndicator();
            this.loadingBarIndicator1 = new HeCopUI_Framework.Controls.Indicators.LoadingBarIndicator();
            this.orbitIndicator1 = new HeCopUI_Framework.Controls.Indicators.OrbitIndicator();
            this.pieSpinnerIndicator1 = new HeCopUI_Framework.Controls.Indicators.PieSpinnerIndicator();
            this.pulseRingIndicator1 = new HeCopUI_Framework.Controls.Indicators.PulseRingIndicator();
            this.ringIndicator1 = new HeCopUI_Framework.Controls.Indicators.RingIndicator();
            this.spinnerIndicator1 = new HeCopUI_Framework.Controls.Indicators.SpinnerIndicator();
            this.waveDotsIndicator1 = new HeCopUI_Framework.Controls.Indicators.WaveDotsIndicator();
            this.hImageBlur1 = new HeCopUI_Framework.Controls.HImageBlur();
            this.hTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.hTabControl5.SuspendLayout();
            this.tabPage24.SuspendLayout();
            this.tabPage25.SuspendLayout();
            this.tabPage26.SuspendLayout();
            this.tabPage27.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage22.SuspendLayout();
            this.hTabControl10.SuspendLayout();
            this.tabPage35.SuspendLayout();
            this.tabPage36.SuspendLayout();
            this.hTabControl4.SuspendLayout();
            this.tabPage15.SuspendLayout();
            this.tabPage16.SuspendLayout();
            this.tabPage17.SuspendLayout();
            this.tabPage18.SuspendLayout();
            this.tabPage21.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.hTabControl6.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage28.SuspendLayout();
            this.tabPage29.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.hTabControl9.SuspendLayout();
            this.tabPage20.SuspendLayout();
            this.tabPage34.SuspendLayout();
            this.tabPage19.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.hTabControl8.SuspendLayout();
            this.tabPage32.SuspendLayout();
            this.tabPage33.SuspendLayout();
            this.hTabControl3.SuspendLayout();
            this.hTabControl2.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.hTabControl7.SuspendLayout();
            this.tabPage30.SuspendLayout();
            this.tabPage31.SuspendLayout();
            this.tabPageIndicators.SuspendLayout();
            this.flowLayoutPanelIndicators.SuspendLayout();
            this.SuspendLayout();
            // 
            // hTabControl1
            // 
            this.hTabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.hTabControl1.ApplyTabPagesColor = true;
            this.hTabControl1.BackgroundColor = System.Drawing.Color.White;
            this.hTabControl1.BorderTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hTabControl1.BorderThickness = 1;
            this.hTabControl1.Controls.Add(this.tabPage1);
            this.hTabControl1.Controls.Add(this.tabPage2);
            this.hTabControl1.Controls.Add(this.tabPage5);
            this.hTabControl1.Controls.Add(this.tabPage22);
            this.hTabControl1.Controls.Add(this.tabPage21);
            this.hTabControl1.Controls.Add(this.tabPage4);
            this.hTabControl1.Controls.Add(this.tabPage9);
            this.hTabControl1.Controls.Add(this.tabPage8);
            this.hTabControl1.Controls.Add(this.tabPage6);
            this.hTabControl1.Controls.Add(this.tabPageIndicators);
            this.hTabControl1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hTabControl1.CursorTabPages = System.Windows.Forms.Cursors.Default;
            this.hTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hTabControl1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.hTabControl1.ItemSize = new System.Drawing.Size(35, 135);
            this.hTabControl1.Location = new System.Drawing.Point(1, 42);
            this.hTabControl1.Multiline = true;
            this.hTabControl1.Name = "hTabControl1";
            this.hTabControl1.Padding = new System.Drawing.Point(0, 0);
            this.hTabControl1.SelectedIndex = 0;
            this.hTabControl1.SelectedTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(102)))));
            this.hTabControl1.SelectedTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hTabControl1.Size = new System.Drawing.Size(889, 546);
            this.hTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.hTabControl1.TabIndex = 0;
            this.hTabControl1.TabsColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.hTabControl1.TabStyle = HeCopUI_Framework.Enums.TabStyle.Style2;
            this.hTabControl1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.hTabControl1.TextPadding = new System.Windows.Forms.Padding(0);
            this.hTabControl1.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hTabControl1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hTabControl1.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            this.hTabControl1.UnSelectedBorderTabColor = System.Drawing.Color.Silver;
            this.hTabControl1.UnSelectedTabColor = System.Drawing.Color.White;
            this.hTabControl1.UnselectedTextColor = System.Drawing.Color.Gray;
            this.hTabControl1.UseAnimation = true;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.tabPage1.Controls.Add(this.hLabel10);
            this.tabPage1.Controls.Add(this.linkLabel1);
            this.tabPage1.Controls.Add(this.hLabel9);
            this.tabPage1.Controls.Add(this.hLabel8);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.hLabel2);
            this.tabPage1.Controls.Add(this.hLabel1);
            this.tabPage1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tabPage1.Location = new System.Drawing.Point(139, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(746, 538);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Home";
            // 
            // hLabel10
            // 
            this.hLabel10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.hLabel10.BackColor = System.Drawing.Color.Transparent;
            this.hLabel10.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.hLabel10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hLabel10.Location = new System.Drawing.Point(413, 165);
            this.hLabel10.Name = "hLabel10";
            this.hLabel10.Size = new System.Drawing.Size(56, 25);
            this.hLabel10.Symbol = "";
            this.hLabel10.SymbolColor = System.Drawing.Color.Gray;
            this.hLabel10.SymbolFont = new System.Drawing.Font("Segoe UI Emoji", 11F);
            this.hLabel10.SymbolVisible = false;
            this.hLabel10.TabIndex = 10;
            this.hLabel10.Text = "Github:";
            this.hLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.hLabel10.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hLabel10.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.linkLabel1.Location = new System.Drawing.Point(472, 165);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(235, 25);
            this.linkLabel1.TabIndex = 9;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://github.com/Khanh779";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            // 
            // hLabel9
            // 
            this.hLabel9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.hLabel9.BackColor = System.Drawing.Color.Transparent;
            this.hLabel9.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(122)))));
            this.hLabel9.Location = new System.Drawing.Point(413, 129);
            this.hLabel9.Name = "hLabel9";
            this.hLabel9.Size = new System.Drawing.Size(114, 23);
            this.hLabel9.Symbol = "";
            this.hLabel9.SymbolColor = System.Drawing.Color.Gray;
            this.hLabel9.SymbolFont = new System.Drawing.Font("Segoe UI Symbol", 10F);
            this.hLabel9.SymbolVisible = true;
            this.hLabel9.TabIndex = 8;
            this.hLabel9.Text = "About me:";
            this.hLabel9.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.hLabel9.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hLabel9.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // hLabel8
            // 
            this.hLabel8.BackColor = System.Drawing.Color.Transparent;
            this.hLabel8.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(122)))));
            this.hLabel8.Location = new System.Drawing.Point(22, 129);
            this.hLabel8.Name = "hLabel8";
            this.hLabel8.Size = new System.Drawing.Size(100, 23);
            this.hLabel8.Symbol = "";
            this.hLabel8.SymbolColor = System.Drawing.Color.Gray;
            this.hLabel8.SymbolFont = new System.Drawing.Font("Segoe UI Symbol", 10F);
            this.hLabel8.SymbolVisible = true;
            this.hLabel8.TabIndex = 7;
            this.hLabel8.Text = "Introduce:";
            this.hLabel8.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.hLabel8.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hLabel8.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.hLabel7);
            this.panel1.Controls.Add(this.hLabel6);
            this.panel1.Controls.Add(this.hLabel5);
            this.panel1.Controls.Add(this.hLabel4);
            this.panel1.Controls.Add(this.hLabel3);
            this.panel1.Location = new System.Drawing.Point(22, 155);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5, 12, 5, 10);
            this.panel1.Size = new System.Drawing.Size(353, 308);
            this.panel1.TabIndex = 6;
            // 
            // hLabel7
            // 
            this.hLabel7.BackColor = System.Drawing.Color.Transparent;
            this.hLabel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.hLabel7.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.hLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hLabel7.Location = new System.Drawing.Point(5, 220);
            this.hLabel7.Name = "hLabel7";
            this.hLabel7.Size = new System.Drawing.Size(343, 52);
            this.hLabel7.Symbol = "✨";
            this.hLabel7.SymbolColor = System.Drawing.Color.Gray;
            this.hLabel7.SymbolFont = new System.Drawing.Font("Segoe UI Emoji", 11F);
            this.hLabel7.SymbolVisible = true;
            this.hLabel7.TabIndex = 15;
            this.hLabel7.Text = "Explore now - Hecop UI Framework, where power meets flexibility! :D";
            this.hLabel7.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.hLabel7.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hLabel7.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // hLabel6
            // 
            this.hLabel6.BackColor = System.Drawing.Color.Transparent;
            this.hLabel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.hLabel6.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.hLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hLabel6.Location = new System.Drawing.Point(5, 168);
            this.hLabel6.Name = "hLabel6";
            this.hLabel6.Size = new System.Drawing.Size(343, 52);
            this.hLabel6.Symbol = "📱 ";
            this.hLabel6.SymbolColor = System.Drawing.Color.Gray;
            this.hLabel6.SymbolFont = new System.Drawing.Font("Segoe UI Emoji", 11F);
            this.hLabel6.SymbolVisible = true;
            this.hLabel6.TabIndex = 14;
            this.hLabel6.Text = "Cross-Platform Support: Develop for both web and mobile effortlessly.";
            this.hLabel6.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.hLabel6.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hLabel6.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // hLabel5
            // 
            this.hLabel5.BackColor = System.Drawing.Color.Transparent;
            this.hLabel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.hLabel5.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.hLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hLabel5.Location = new System.Drawing.Point(5, 116);
            this.hLabel5.Name = "hLabel5";
            this.hLabel5.Size = new System.Drawing.Size(343, 52);
            this.hLabel5.Symbol = "⚡ ";
            this.hLabel5.SymbolColor = System.Drawing.Color.Gray;
            this.hLabel5.SymbolFont = new System.Drawing.Font("Segoe UI Emoji", 11F);
            this.hLabel5.SymbolVisible = true;
            this.hLabel5.TabIndex = 13;
            this.hLabel5.Text = "Smooth Performance: A fluid and fast user experience across all devices.";
            this.hLabel5.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.hLabel5.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hLabel5.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // hLabel4
            // 
            this.hLabel4.BackColor = System.Drawing.Color.Transparent;
            this.hLabel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.hLabel4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.hLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hLabel4.Location = new System.Drawing.Point(5, 64);
            this.hLabel4.Name = "hLabel4";
            this.hLabel4.Size = new System.Drawing.Size(343, 52);
            this.hLabel4.Symbol = "🎨 ";
            this.hLabel4.SymbolColor = System.Drawing.Color.Gray;
            this.hLabel4.SymbolFont = new System.Drawing.Font("Segoe UI Emoji", 11F);
            this.hLabel4.SymbolVisible = true;
            this.hLabel4.TabIndex = 12;
            this.hLabel4.Text = "Flexible Customization: Fine-tune with progress bars, tab controls, and versatile" +
    " features.";
            this.hLabel4.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.hLabel4.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hLabel4.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // hLabel3
            // 
            this.hLabel3.BackColor = System.Drawing.Color.Transparent;
            this.hLabel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.hLabel3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.hLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hLabel3.Location = new System.Drawing.Point(5, 12);
            this.hLabel3.Name = "hLabel3";
            this.hLabel3.Size = new System.Drawing.Size(343, 52);
            this.hLabel3.Symbol = "🚀 ";
            this.hLabel3.SymbolColor = System.Drawing.Color.Gray;
            this.hLabel3.SymbolFont = new System.Drawing.Font("Segoe UI Emoji", 11F);
            this.hLabel3.SymbolVisible = true;
            this.hLabel3.TabIndex = 11;
            this.hLabel3.Text = "Diverse UI Components: Charts, buttons, checkboxes, textboxes, and more, helping " +
    "you build interfaces swiftly.";
            this.hLabel3.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.hLabel3.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hLabel3.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // hLabel2
            // 
            this.hLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hLabel2.BackColor = System.Drawing.Color.Transparent;
            this.hLabel2.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.hLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hLabel2.Location = new System.Drawing.Point(22, 57);
            this.hLabel2.Name = "hLabel2";
            this.hLabel2.Size = new System.Drawing.Size(329, 45);
            this.hLabel2.Symbol = "";
            this.hLabel2.SymbolColor = System.Drawing.Color.Gray;
            this.hLabel2.SymbolFont = new System.Drawing.Font("Segoe UI Symbol", 10F);
            this.hLabel2.SymbolVisible = true;
            this.hLabel2.TabIndex = 1;
            this.hLabel2.Text = "Hecop UI Framework - Your ideal companion for seamless app development.";
            this.hLabel2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.hLabel2.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hLabel2.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // hLabel1
            // 
            this.hLabel1.BackColor = System.Drawing.Color.Transparent;
            this.hLabel1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.hLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(122)))));
            this.hLabel1.Location = new System.Drawing.Point(22, 21);
            this.hLabel1.Name = "hLabel1";
            this.hLabel1.Size = new System.Drawing.Size(331, 30);
            this.hLabel1.Symbol = "";
            this.hLabel1.SymbolColor = System.Drawing.Color.Gray;
            this.hLabel1.SymbolFont = new System.Drawing.Font("Segoe UI Symbol", 10F);
            this.hLabel1.SymbolVisible = true;
            this.hLabel1.TabIndex = 0;
            this.hLabel1.Text = "Welcome to Hecop UI Framework!";
            this.hLabel1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.hLabel1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hLabel1.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.tabPage2.Controls.Add(this.hTabControl5);
            this.tabPage2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tabPage2.Location = new System.Drawing.Point(139, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(5);
            this.tabPage2.Size = new System.Drawing.Size(746, 538);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Buttons";
            // 
            // hTabControl5
            // 
            this.hTabControl5.ApplyTabPagesColor = true;
            this.hTabControl5.BackgroundColor = System.Drawing.Color.Transparent;
            this.hTabControl5.BorderTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hTabControl5.BorderThickness = 1;
            this.hTabControl5.Controls.Add(this.tabPage24);
            this.hTabControl5.Controls.Add(this.tabPage25);
            this.hTabControl5.Controls.Add(this.tabPage26);
            this.hTabControl5.Controls.Add(this.tabPage27);
            this.hTabControl5.CursorTabPages = System.Windows.Forms.Cursors.Default;
            this.hTabControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hTabControl5.ItemSize = new System.Drawing.Size(86, 30);
            this.hTabControl5.Location = new System.Drawing.Point(5, 5);
            this.hTabControl5.Name = "hTabControl5";
            this.hTabControl5.SelectedIndex = 0;
            this.hTabControl5.SelectedTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hTabControl5.SelectedTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hTabControl5.Size = new System.Drawing.Size(736, 528);
            this.hTabControl5.TabIndex = 27;
            this.hTabControl5.TabsColor = System.Drawing.Color.White;
            this.hTabControl5.TabStyle = HeCopUI_Framework.Enums.TabStyle.Style2;
            this.hTabControl5.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.hTabControl5.TextPadding = new System.Windows.Forms.Padding(0);
            this.hTabControl5.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hTabControl5.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hTabControl5.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            this.hTabControl5.UnSelectedBorderTabColor = System.Drawing.Color.Silver;
            this.hTabControl5.UnSelectedTabColor = System.Drawing.Color.Transparent;
            this.hTabControl5.UnselectedTextColor = System.Drawing.Color.DimGray;
            this.hTabControl5.UseAnimation = true;
            // 
            // tabPage24
            // 
            this.tabPage24.BackColor = System.Drawing.Color.White;
            this.tabPage24.Controls.Add(this.hButton7);
            this.tabPage24.Controls.Add(this.hButton8);
            this.tabPage24.Controls.Add(this.hButton9);
            this.tabPage24.Controls.Add(this.hButton4);
            this.tabPage24.Controls.Add(this.hButton5);
            this.tabPage24.Controls.Add(this.hButton6);
            this.tabPage24.Controls.Add(this.hButton3);
            this.tabPage24.Controls.Add(this.hButton2);
            this.tabPage24.Controls.Add(this.hButton1);
            this.tabPage24.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage24.Location = new System.Drawing.Point(4, 34);
            this.tabPage24.Name = "tabPage24";
            this.tabPage24.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage24.Size = new System.Drawing.Size(728, 490);
            this.tabPage24.TabIndex = 0;
            this.tabPage24.Text = "Text Button";
            // 
            // hButton7
            // 
            this.hButton7.AnimationMode = HeCopUI_Framework.Enums.AnimationMode.ColorTransition;
            this.hButton7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hButton7.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hButton7.BorderPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hButton7.BorderThickness = 0;
            this.hButton7.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hButton7.ClipRegion = false;
            this.hButton7.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.hButton7.DialogResult = System.Windows.Forms.DialogResult.None;
            this.hButton7.FocusBorderColor = System.Drawing.Color.White;
            this.hButton7.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.hButton7.HoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hButton7.HoverColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.hButton7.Image = null;
            this.hButton7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.hButton7.ImagePadding = new System.Windows.Forms.Padding(0);
            this.hButton7.ImageSize = new System.Drawing.Size(20, 20);
            this.hButton7.Location = new System.Drawing.Point(464, 287);
            this.hButton7.Name = "hButton7";
            this.hButton7.NormalColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.hButton7.NormalColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hButton7.PressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(98)))), ((int)(((byte)(78)))));
            this.hButton7.PressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hButton7.RippleColor = System.Drawing.Color.Black;
            this.hButton7.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.hButton7.ShadowPadding = new System.Windows.Forms.Padding(3, 1, 3, 4);
            this.hButton7.ShadowRadius = 5;
            this.hButton7.ShapeButtonType = HeCopUI_Framework.Enums.ShapeType.RoundedRectangle;
            this.hButton7.Size = new System.Drawing.Size(147, 57);
            this.hButton7.SupportImageGif = false;
            this.hButton7.TabIndex = 46;
            this.hButton7.Text = "Color Transition";
            this.hButton7.TextHoverColor = System.Drawing.Color.White;
            this.hButton7.TextNormalColor = System.Drawing.Color.White;
            this.hButton7.TextPadding = new System.Windows.Forms.Padding(0);
            this.hButton7.TextPressColor = System.Drawing.Color.White;
            this.hButton7.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hButton7.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // hButton8
            // 
            this.hButton8.AnimationMode = HeCopUI_Framework.Enums.AnimationMode.ColorTransition;
            this.hButton8.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hButton8.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hButton8.BorderPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hButton8.BorderThickness = 0;
            this.hButton8.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hButton8.ClipRegion = false;
            this.hButton8.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.hButton8.DialogResult = System.Windows.Forms.DialogResult.None;
            this.hButton8.FocusBorderColor = System.Drawing.Color.White;
            this.hButton8.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.hButton8.HoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hButton8.HoverColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.hButton8.Image = null;
            this.hButton8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.hButton8.ImagePadding = new System.Windows.Forms.Padding(0);
            this.hButton8.ImageSize = new System.Drawing.Size(20, 20);
            this.hButton8.Location = new System.Drawing.Point(290, 287);
            this.hButton8.Name = "hButton8";
            this.hButton8.NormalColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.hButton8.NormalColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hButton8.PressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(98)))), ((int)(((byte)(78)))));
            this.hButton8.PressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hButton8.RippleColor = System.Drawing.Color.Black;
            this.hButton8.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.hButton8.ShadowPadding = new System.Windows.Forms.Padding(0);
            this.hButton8.ShadowRadius = 5;
            this.hButton8.ShapeButtonType = HeCopUI_Framework.Enums.ShapeType.RoundedRectangle;
            this.hButton8.Size = new System.Drawing.Size(142, 52);
            this.hButton8.SupportImageGif = false;
            this.hButton8.TabIndex = 45;
            this.hButton8.Text = "Color Transition";
            this.hButton8.TextHoverColor = System.Drawing.Color.White;
            this.hButton8.TextNormalColor = System.Drawing.Color.White;
            this.hButton8.TextPadding = new System.Windows.Forms.Padding(0);
            this.hButton8.TextPressColor = System.Drawing.Color.White;
            this.hButton8.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hButton8.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // hButton9
            // 
            this.hButton9.AnimationMode = HeCopUI_Framework.Enums.AnimationMode.ColorTransition;
            this.hButton9.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hButton9.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hButton9.BorderPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hButton9.BorderThickness = 1;
            this.hButton9.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hButton9.ClipRegion = false;
            this.hButton9.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.hButton9.DialogResult = System.Windows.Forms.DialogResult.None;
            this.hButton9.FocusBorderColor = System.Drawing.Color.White;
            this.hButton9.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.hButton9.HoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.hButton9.HoverColor2 = System.Drawing.Color.White;
            this.hButton9.Image = null;
            this.hButton9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.hButton9.ImagePadding = new System.Windows.Forms.Padding(0);
            this.hButton9.ImageSize = new System.Drawing.Size(20, 20);
            this.hButton9.Location = new System.Drawing.Point(121, 287);
            this.hButton9.Name = "hButton9";
            this.hButton9.NormalColor1 = System.Drawing.Color.White;
            this.hButton9.NormalColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.hButton9.PressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.hButton9.PressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.hButton9.RippleColor = System.Drawing.Color.Black;
            this.hButton9.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.hButton9.ShadowPadding = new System.Windows.Forms.Padding(0);
            this.hButton9.ShadowRadius = 5;
            this.hButton9.ShapeButtonType = HeCopUI_Framework.Enums.ShapeType.RoundedRectangle;
            this.hButton9.Size = new System.Drawing.Size(142, 52);
            this.hButton9.SupportImageGif = false;
            this.hButton9.TabIndex = 44;
            this.hButton9.Text = "Color Transition";
            this.hButton9.TextHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hButton9.TextNormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hButton9.TextPadding = new System.Windows.Forms.Padding(0);
            this.hButton9.TextPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hButton9.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hButton9.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // hButton4
            // 
            this.hButton4.AnimationMode = HeCopUI_Framework.Enums.AnimationMode.Ripple;
            this.hButton4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hButton4.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hButton4.BorderPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hButton4.BorderThickness = 0;
            this.hButton4.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hButton4.ClipRegion = false;
            this.hButton4.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.hButton4.DialogResult = System.Windows.Forms.DialogResult.None;
            this.hButton4.FocusBorderColor = System.Drawing.Color.White;
            this.hButton4.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.hButton4.HoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hButton4.HoverColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.hButton4.Image = null;
            this.hButton4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.hButton4.ImagePadding = new System.Windows.Forms.Padding(0);
            this.hButton4.ImageSize = new System.Drawing.Size(20, 20);
            this.hButton4.Location = new System.Drawing.Point(464, 207);
            this.hButton4.Name = "hButton4";
            this.hButton4.NormalColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.hButton4.NormalColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hButton4.PressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(98)))), ((int)(((byte)(78)))));
            this.hButton4.PressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hButton4.RippleColor = System.Drawing.Color.Black;
            this.hButton4.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.hButton4.ShadowPadding = new System.Windows.Forms.Padding(3, 1, 3, 4);
            this.hButton4.ShadowRadius = 5;
            this.hButton4.ShapeButtonType = HeCopUI_Framework.Enums.ShapeType.RoundedRectangle;
            this.hButton4.Size = new System.Drawing.Size(147, 57);
            this.hButton4.SupportImageGif = false;
            this.hButton4.TabIndex = 43;
            this.hButton4.Text = "Ripple Effect";
            this.hButton4.TextHoverColor = System.Drawing.Color.White;
            this.hButton4.TextNormalColor = System.Drawing.Color.White;
            this.hButton4.TextPadding = new System.Windows.Forms.Padding(0);
            this.hButton4.TextPressColor = System.Drawing.Color.White;
            this.hButton4.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hButton4.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // hButton5
            // 
            this.hButton5.AnimationMode = HeCopUI_Framework.Enums.AnimationMode.Ripple;
            this.hButton5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hButton5.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hButton5.BorderPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hButton5.BorderThickness = 0;
            this.hButton5.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hButton5.ClipRegion = false;
            this.hButton5.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.hButton5.DialogResult = System.Windows.Forms.DialogResult.None;
            this.hButton5.FocusBorderColor = System.Drawing.Color.White;
            this.hButton5.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.hButton5.HoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hButton5.HoverColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.hButton5.Image = null;
            this.hButton5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.hButton5.ImagePadding = new System.Windows.Forms.Padding(0);
            this.hButton5.ImageSize = new System.Drawing.Size(20, 20);
            this.hButton5.Location = new System.Drawing.Point(290, 207);
            this.hButton5.Margin = new System.Windows.Forms.Padding(34, 3, 5, 6);
            this.hButton5.Name = "hButton5";
            this.hButton5.NormalColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.hButton5.NormalColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hButton5.PressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(98)))), ((int)(((byte)(78)))));
            this.hButton5.PressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hButton5.RippleColor = System.Drawing.Color.Black;
            this.hButton5.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.hButton5.ShadowPadding = new System.Windows.Forms.Padding(0);
            this.hButton5.ShadowRadius = 5;
            this.hButton5.ShapeButtonType = HeCopUI_Framework.Enums.ShapeType.RoundedRectangle;
            this.hButton5.Size = new System.Drawing.Size(142, 52);
            this.hButton5.SupportImageGif = false;
            this.hButton5.TabIndex = 42;
            this.hButton5.Text = "Ripple Effect";
            this.hButton5.TextHoverColor = System.Drawing.Color.White;
            this.hButton5.TextNormalColor = System.Drawing.Color.White;
            this.hButton5.TextPadding = new System.Windows.Forms.Padding(0);
            this.hButton5.TextPressColor = System.Drawing.Color.White;
            this.hButton5.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hButton5.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // hButton6
            // 
            this.hButton6.AnimationMode = HeCopUI_Framework.Enums.AnimationMode.Ripple;
            this.hButton6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hButton6.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hButton6.BorderPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hButton6.BorderThickness = 1;
            this.hButton6.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hButton6.ClipRegion = false;
            this.hButton6.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.hButton6.DialogResult = System.Windows.Forms.DialogResult.None;
            this.hButton6.FocusBorderColor = System.Drawing.Color.White;
            this.hButton6.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.hButton6.HoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.hButton6.HoverColor2 = System.Drawing.Color.White;
            this.hButton6.Image = null;
            this.hButton6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.hButton6.ImagePadding = new System.Windows.Forms.Padding(0);
            this.hButton6.ImageSize = new System.Drawing.Size(20, 20);
            this.hButton6.Location = new System.Drawing.Point(121, 207);
            this.hButton6.Name = "hButton6";
            this.hButton6.NormalColor1 = System.Drawing.Color.White;
            this.hButton6.NormalColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.hButton6.PressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.hButton6.PressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.hButton6.RippleColor = System.Drawing.Color.Black;
            this.hButton6.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.hButton6.ShadowPadding = new System.Windows.Forms.Padding(0);
            this.hButton6.ShadowRadius = 5;
            this.hButton6.ShapeButtonType = HeCopUI_Framework.Enums.ShapeType.RoundedRectangle;
            this.hButton6.Size = new System.Drawing.Size(142, 52);
            this.hButton6.SupportImageGif = false;
            this.hButton6.TabIndex = 41;
            this.hButton6.Text = "Ripple Effect";
            this.hButton6.TextHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hButton6.TextNormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hButton6.TextPadding = new System.Windows.Forms.Padding(0);
            this.hButton6.TextPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hButton6.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hButton6.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // hButton3
            // 
            this.hButton3.AnimationMode = HeCopUI_Framework.Enums.AnimationMode.None;
            this.hButton3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hButton3.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hButton3.BorderPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hButton3.BorderThickness = 0;
            this.hButton3.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hButton3.ClipRegion = false;
            this.hButton3.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.hButton3.DialogResult = System.Windows.Forms.DialogResult.None;
            this.hButton3.FocusBorderColor = System.Drawing.Color.White;
            this.hButton3.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.hButton3.HoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hButton3.HoverColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.hButton3.Image = null;
            this.hButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.hButton3.ImagePadding = new System.Windows.Forms.Padding(0);
            this.hButton3.ImageSize = new System.Drawing.Size(20, 20);
            this.hButton3.Location = new System.Drawing.Point(464, 130);
            this.hButton3.Name = "hButton3";
            this.hButton3.NormalColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.hButton3.NormalColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hButton3.PressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(98)))), ((int)(((byte)(78)))));
            this.hButton3.PressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hButton3.RippleColor = System.Drawing.Color.Black;
            this.hButton3.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.hButton3.ShadowPadding = new System.Windows.Forms.Padding(3, 1, 3, 4);
            this.hButton3.ShadowRadius = 5;
            this.hButton3.ShapeButtonType = HeCopUI_Framework.Enums.ShapeType.RoundedRectangle;
            this.hButton3.Size = new System.Drawing.Size(147, 57);
            this.hButton3.SupportImageGif = false;
            this.hButton3.TabIndex = 40;
            this.hButton3.Text = "No animation";
            this.hButton3.TextHoverColor = System.Drawing.Color.White;
            this.hButton3.TextNormalColor = System.Drawing.Color.White;
            this.hButton3.TextPadding = new System.Windows.Forms.Padding(0);
            this.hButton3.TextPressColor = System.Drawing.Color.White;
            this.hButton3.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hButton3.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // hButton2
            // 
            this.hButton2.AnimationMode = HeCopUI_Framework.Enums.AnimationMode.None;
            this.hButton2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hButton2.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hButton2.BorderPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hButton2.BorderThickness = 0;
            this.hButton2.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hButton2.ClipRegion = false;
            this.hButton2.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.hButton2.DialogResult = System.Windows.Forms.DialogResult.None;
            this.hButton2.FocusBorderColor = System.Drawing.Color.White;
            this.hButton2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.hButton2.HoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hButton2.HoverColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.hButton2.Image = null;
            this.hButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.hButton2.ImagePadding = new System.Windows.Forms.Padding(0);
            this.hButton2.ImageSize = new System.Drawing.Size(20, 20);
            this.hButton2.Location = new System.Drawing.Point(290, 130);
            this.hButton2.Name = "hButton2";
            this.hButton2.NormalColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.hButton2.NormalColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hButton2.PressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(98)))), ((int)(((byte)(78)))));
            this.hButton2.PressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hButton2.RippleColor = System.Drawing.Color.Black;
            this.hButton2.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.hButton2.ShadowPadding = new System.Windows.Forms.Padding(0);
            this.hButton2.ShadowRadius = 5;
            this.hButton2.ShapeButtonType = HeCopUI_Framework.Enums.ShapeType.RoundedRectangle;
            this.hButton2.Size = new System.Drawing.Size(142, 52);
            this.hButton2.SupportImageGif = false;
            this.hButton2.TabIndex = 39;
            this.hButton2.Text = "No animation";
            this.hButton2.TextHoverColor = System.Drawing.Color.White;
            this.hButton2.TextNormalColor = System.Drawing.Color.White;
            this.hButton2.TextPadding = new System.Windows.Forms.Padding(0);
            this.hButton2.TextPressColor = System.Drawing.Color.White;
            this.hButton2.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hButton2.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // hButton1
            // 
            this.hButton1.AnimationMode = HeCopUI_Framework.Enums.AnimationMode.None;
            this.hButton1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hButton1.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hButton1.BorderPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hButton1.BorderThickness = 1;
            this.hButton1.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hButton1.ClipRegion = false;
            this.hButton1.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.hButton1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.hButton1.FocusBorderColor = System.Drawing.Color.White;
            this.hButton1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.hButton1.HoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.hButton1.HoverColor2 = System.Drawing.Color.White;
            this.hButton1.Image = global::HecopUI_Test.Properties.Resources.hTextBox2_Image;
            this.hButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.hButton1.ImagePadding = new System.Windows.Forms.Padding(0);
            this.hButton1.ImageSize = new System.Drawing.Size(20, 20);
            this.hButton1.Location = new System.Drawing.Point(121, 130);
            this.hButton1.Name = "hButton1";
            this.hButton1.NormalColor1 = System.Drawing.Color.White;
            this.hButton1.NormalColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.hButton1.PressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.hButton1.PressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.hButton1.RippleColor = System.Drawing.Color.Black;
            this.hButton1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.hButton1.ShadowPadding = new System.Windows.Forms.Padding(0);
            this.hButton1.ShadowRadius = 5;
            this.hButton1.ShapeButtonType = HeCopUI_Framework.Enums.ShapeType.RoundedRectangle;
            this.hButton1.Size = new System.Drawing.Size(142, 52);
            this.hButton1.SupportImageGif = false;
            this.hButton1.TabIndex = 38;
            this.hButton1.Text = "No animation";
            this.hButton1.TextHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hButton1.TextNormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hButton1.TextPadding = new System.Windows.Forms.Padding(0);
            this.hButton1.TextPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hButton1.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hButton1.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // tabPage25
            // 
            this.tabPage25.BackColor = System.Drawing.Color.White;
            this.tabPage25.Controls.Add(this.HTileButton7);
            this.tabPage25.Controls.Add(this.HTileButton8);
            this.tabPage25.Controls.Add(this.HTileButton9);
            this.tabPage25.Controls.Add(this.HTileButton4);
            this.tabPage25.Controls.Add(this.HTileButton5);
            this.tabPage25.Controls.Add(this.HTileButton6);
            this.tabPage25.Controls.Add(this.HTileButton3);
            this.tabPage25.Controls.Add(this.HTileButton2);
            this.tabPage25.Controls.Add(this.HTileButton1);
            this.tabPage25.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage25.Location = new System.Drawing.Point(4, 34);
            this.tabPage25.Name = "tabPage25";
            this.tabPage25.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage25.Size = new System.Drawing.Size(728, 490);
            this.tabPage25.TabIndex = 1;
            this.tabPage25.Text = "Tile Button";
            // 
            // HTileButton7
            // 
            this.HTileButton7.AlphaAnimated = 180;
            this.HTileButton7.AnimationMode = HeCopUI_Framework.Enums.AnimationMode.ColorTransition;
            this.HTileButton7.BackColor = System.Drawing.Color.Transparent;
            this.HTileButton7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.HTileButton7.BorderDownColor = System.Drawing.Color.Transparent;
            this.HTileButton7.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.HTileButton7.BorderThickness = 0;
            this.HTileButton7.ButtonImage = null;
            this.HTileButton7.ClipRegion = false;
            this.HTileButton7.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.HTileButton7.FocusBorderColor = System.Drawing.Color.White;
            this.HTileButton7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.HTileButton7.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.HTileButton7.HoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.HTileButton7.HoverColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.HTileButton7.ImageOffsetY = 10F;
            this.HTileButton7.ImageSize = new System.Drawing.Size(30, 30);
            this.HTileButton7.Interval = 200;
            this.HTileButton7.Location = new System.Drawing.Point(456, 344);
            this.HTileButton7.Name = "HTileButton7";
            this.HTileButton7.NormalColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.HTileButton7.NormalColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.HTileButton7.PressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(98)))), ((int)(((byte)(78)))));
            this.HTileButton7.PressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.HTileButton7.RippleColor = System.Drawing.Color.Black;
            this.HTileButton7.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.HTileButton7.ShadowPadding = new System.Windows.Forms.Padding(3, 1, 3, 4);
            this.HTileButton7.ShadowRadius = 5;
            this.HTileButton7.Size = new System.Drawing.Size(150, 118);
            this.HTileButton7.TabIndex = 63;
            this.HTileButton7.Text = "Color Transition";
            this.HTileButton7.TextPadding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.HTileButton7.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.HTileButton7.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            this.HTileButton7.TextYOffset = 1F;
            // 
            // HTileButton8
            // 
            this.HTileButton8.AlphaAnimated = 180;
            this.HTileButton8.AnimationMode = HeCopUI_Framework.Enums.AnimationMode.ColorTransition;
            this.HTileButton8.BackColor = System.Drawing.Color.Transparent;
            this.HTileButton8.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.HTileButton8.BorderDownColor = System.Drawing.Color.Transparent;
            this.HTileButton8.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.HTileButton8.BorderThickness = 0;
            this.HTileButton8.ButtonImage = null;
            this.HTileButton8.ClipRegion = false;
            this.HTileButton8.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.HTileButton8.FocusBorderColor = System.Drawing.Color.White;
            this.HTileButton8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.HTileButton8.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.HTileButton8.HoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.HTileButton8.HoverColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.HTileButton8.ImageOffsetY = 10F;
            this.HTileButton8.ImageSize = new System.Drawing.Size(30, 30);
            this.HTileButton8.Interval = 200;
            this.HTileButton8.Location = new System.Drawing.Point(274, 344);
            this.HTileButton8.Name = "HTileButton8";
            this.HTileButton8.NormalColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.HTileButton8.NormalColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.HTileButton8.PressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(98)))), ((int)(((byte)(78)))));
            this.HTileButton8.PressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.HTileButton8.RippleColor = System.Drawing.Color.Black;
            this.HTileButton8.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.HTileButton8.ShadowPadding = new System.Windows.Forms.Padding(0);
            this.HTileButton8.ShadowRadius = 5;
            this.HTileButton8.Size = new System.Drawing.Size(150, 118);
            this.HTileButton8.TabIndex = 62;
            this.HTileButton8.Text = "Color Transition";
            this.HTileButton8.TextPadding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.HTileButton8.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.HTileButton8.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            this.HTileButton8.TextYOffset = 1F;
            // 
            // HTileButton9
            // 
            this.HTileButton9.AlphaAnimated = 180;
            this.HTileButton9.AnimationMode = HeCopUI_Framework.Enums.AnimationMode.ColorTransition;
            this.HTileButton9.BackColor = System.Drawing.Color.Transparent;
            this.HTileButton9.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.HTileButton9.BorderDownColor = System.Drawing.Color.Transparent;
            this.HTileButton9.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.HTileButton9.BorderThickness = 1;
            this.HTileButton9.ButtonImage = null;
            this.HTileButton9.ClipRegion = false;
            this.HTileButton9.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.HTileButton9.FocusBorderColor = System.Drawing.Color.White;
            this.HTileButton9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.HTileButton9.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.HTileButton9.HoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.HTileButton9.HoverColor2 = System.Drawing.Color.White;
            this.HTileButton9.ImageOffsetY = 10F;
            this.HTileButton9.ImageSize = new System.Drawing.Size(30, 30);
            this.HTileButton9.Interval = 200;
            this.HTileButton9.Location = new System.Drawing.Point(93, 344);
            this.HTileButton9.Name = "HTileButton9";
            this.HTileButton9.NormalColor1 = System.Drawing.Color.White;
            this.HTileButton9.NormalColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.HTileButton9.PressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.HTileButton9.PressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.HTileButton9.RippleColor = System.Drawing.Color.Black;
            this.HTileButton9.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.HTileButton9.ShadowPadding = new System.Windows.Forms.Padding(0);
            this.HTileButton9.ShadowRadius = 5;
            this.HTileButton9.Size = new System.Drawing.Size(150, 118);
            this.HTileButton9.TabIndex = 61;
            this.HTileButton9.Text = "Color Transition";
            this.HTileButton9.TextPadding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.HTileButton9.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.HTileButton9.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            this.HTileButton9.TextYOffset = 1F;
            // 
            // HTileButton4
            // 
            this.HTileButton4.AlphaAnimated = 180;
            this.HTileButton4.AnimationMode = HeCopUI_Framework.Enums.AnimationMode.Ripple;
            this.HTileButton4.BackColor = System.Drawing.Color.Transparent;
            this.HTileButton4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.HTileButton4.BorderDownColor = System.Drawing.Color.Transparent;
            this.HTileButton4.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.HTileButton4.BorderThickness = 0;
            this.HTileButton4.ButtonImage = null;
            this.HTileButton4.ClipRegion = false;
            this.HTileButton4.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.HTileButton4.FocusBorderColor = System.Drawing.Color.White;
            this.HTileButton4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.HTileButton4.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.HTileButton4.HoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.HTileButton4.HoverColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.HTileButton4.ImageOffsetY = 10F;
            this.HTileButton4.ImageSize = new System.Drawing.Size(30, 30);
            this.HTileButton4.Interval = 200;
            this.HTileButton4.Location = new System.Drawing.Point(456, 197);
            this.HTileButton4.Name = "HTileButton4";
            this.HTileButton4.NormalColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.HTileButton4.NormalColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.HTileButton4.PressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(98)))), ((int)(((byte)(78)))));
            this.HTileButton4.PressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.HTileButton4.RippleColor = System.Drawing.Color.Black;
            this.HTileButton4.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.HTileButton4.ShadowPadding = new System.Windows.Forms.Padding(3, 1, 3, 4);
            this.HTileButton4.ShadowRadius = 5;
            this.HTileButton4.Size = new System.Drawing.Size(150, 118);
            this.HTileButton4.TabIndex = 60;
            this.HTileButton4.Text = "Ripple Effect";
            this.HTileButton4.TextPadding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.HTileButton4.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.HTileButton4.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            this.HTileButton4.TextYOffset = 1F;
            // 
            // HTileButton5
            // 
            this.HTileButton5.AlphaAnimated = 180;
            this.HTileButton5.AnimationMode = HeCopUI_Framework.Enums.AnimationMode.Ripple;
            this.HTileButton5.BackColor = System.Drawing.Color.Transparent;
            this.HTileButton5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.HTileButton5.BorderDownColor = System.Drawing.Color.Transparent;
            this.HTileButton5.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.HTileButton5.BorderThickness = 0;
            this.HTileButton5.ButtonImage = null;
            this.HTileButton5.ClipRegion = false;
            this.HTileButton5.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.HTileButton5.FocusBorderColor = System.Drawing.Color.White;
            this.HTileButton5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.HTileButton5.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.HTileButton5.HoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.HTileButton5.HoverColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.HTileButton5.ImageOffsetY = 10F;
            this.HTileButton5.ImageSize = new System.Drawing.Size(30, 30);
            this.HTileButton5.Interval = 200;
            this.HTileButton5.Location = new System.Drawing.Point(274, 197);
            this.HTileButton5.Name = "HTileButton5";
            this.HTileButton5.NormalColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.HTileButton5.NormalColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.HTileButton5.PressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(98)))), ((int)(((byte)(78)))));
            this.HTileButton5.PressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.HTileButton5.RippleColor = System.Drawing.Color.Black;
            this.HTileButton5.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.HTileButton5.ShadowPadding = new System.Windows.Forms.Padding(0);
            this.HTileButton5.ShadowRadius = 5;
            this.HTileButton5.Size = new System.Drawing.Size(150, 118);
            this.HTileButton5.TabIndex = 59;
            this.HTileButton5.Text = "Ripple Effect";
            this.HTileButton5.TextPadding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.HTileButton5.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.HTileButton5.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            this.HTileButton5.TextYOffset = 1F;
            // 
            // HTileButton6
            // 
            this.HTileButton6.AlphaAnimated = 180;
            this.HTileButton6.AnimationMode = HeCopUI_Framework.Enums.AnimationMode.Ripple;
            this.HTileButton6.BackColor = System.Drawing.Color.Transparent;
            this.HTileButton6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.HTileButton6.BorderDownColor = System.Drawing.Color.Transparent;
            this.HTileButton6.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.HTileButton6.BorderThickness = 1;
            this.HTileButton6.ButtonImage = null;
            this.HTileButton6.ClipRegion = false;
            this.HTileButton6.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.HTileButton6.FocusBorderColor = System.Drawing.Color.White;
            this.HTileButton6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.HTileButton6.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.HTileButton6.HoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.HTileButton6.HoverColor2 = System.Drawing.Color.White;
            this.HTileButton6.ImageOffsetY = 10F;
            this.HTileButton6.ImageSize = new System.Drawing.Size(30, 30);
            this.HTileButton6.Interval = 200;
            this.HTileButton6.Location = new System.Drawing.Point(93, 197);
            this.HTileButton6.Name = "HTileButton6";
            this.HTileButton6.NormalColor1 = System.Drawing.Color.White;
            this.HTileButton6.NormalColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.HTileButton6.PressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.HTileButton6.PressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.HTileButton6.RippleColor = System.Drawing.Color.Black;
            this.HTileButton6.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.HTileButton6.ShadowPadding = new System.Windows.Forms.Padding(0);
            this.HTileButton6.ShadowRadius = 5;
            this.HTileButton6.Size = new System.Drawing.Size(150, 118);
            this.HTileButton6.TabIndex = 58;
            this.HTileButton6.Text = "Ripple Effect";
            this.HTileButton6.TextPadding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.HTileButton6.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.HTileButton6.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            this.HTileButton6.TextYOffset = 1F;
            // 
            // HTileButton3
            // 
            this.HTileButton3.AlphaAnimated = 180;
            this.HTileButton3.AnimationMode = HeCopUI_Framework.Enums.AnimationMode.None;
            this.HTileButton3.BackColor = System.Drawing.Color.Transparent;
            this.HTileButton3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.HTileButton3.BorderDownColor = System.Drawing.Color.Transparent;
            this.HTileButton3.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.HTileButton3.BorderThickness = 0;
            this.HTileButton3.ButtonImage = null;
            this.HTileButton3.ClipRegion = false;
            this.HTileButton3.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.HTileButton3.FocusBorderColor = System.Drawing.Color.White;
            this.HTileButton3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.HTileButton3.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.HTileButton3.HoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.HTileButton3.HoverColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.HTileButton3.ImageOffsetY = 10F;
            this.HTileButton3.ImageSize = new System.Drawing.Size(30, 30);
            this.HTileButton3.Interval = 200;
            this.HTileButton3.Location = new System.Drawing.Point(456, 57);
            this.HTileButton3.Name = "HTileButton3";
            this.HTileButton3.NormalColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.HTileButton3.NormalColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.HTileButton3.PressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(98)))), ((int)(((byte)(78)))));
            this.HTileButton3.PressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.HTileButton3.RippleColor = System.Drawing.Color.Black;
            this.HTileButton3.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.HTileButton3.ShadowPadding = new System.Windows.Forms.Padding(3, 1, 3, 4);
            this.HTileButton3.ShadowRadius = 5;
            this.HTileButton3.Size = new System.Drawing.Size(150, 118);
            this.HTileButton3.TabIndex = 57;
            this.HTileButton3.Text = "No animation";
            this.HTileButton3.TextPadding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.HTileButton3.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.HTileButton3.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            this.HTileButton3.TextYOffset = 1F;
            // 
            // HTileButton2
            // 
            this.HTileButton2.AlphaAnimated = 180;
            this.HTileButton2.AnimationMode = HeCopUI_Framework.Enums.AnimationMode.None;
            this.HTileButton2.BackColor = System.Drawing.Color.Transparent;
            this.HTileButton2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.HTileButton2.BorderDownColor = System.Drawing.Color.Transparent;
            this.HTileButton2.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.HTileButton2.BorderThickness = 0;
            this.HTileButton2.ButtonImage = null;
            this.HTileButton2.ClipRegion = false;
            this.HTileButton2.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.HTileButton2.FocusBorderColor = System.Drawing.Color.White;
            this.HTileButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.HTileButton2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.HTileButton2.HoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.HTileButton2.HoverColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.HTileButton2.ImageOffsetY = 10F;
            this.HTileButton2.ImageSize = new System.Drawing.Size(30, 30);
            this.HTileButton2.Interval = 200;
            this.HTileButton2.Location = new System.Drawing.Point(274, 57);
            this.HTileButton2.Name = "HTileButton2";
            this.HTileButton2.NormalColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.HTileButton2.NormalColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.HTileButton2.PressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(98)))), ((int)(((byte)(78)))));
            this.HTileButton2.PressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.HTileButton2.RippleColor = System.Drawing.Color.Black;
            this.HTileButton2.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.HTileButton2.ShadowPadding = new System.Windows.Forms.Padding(0);
            this.HTileButton2.ShadowRadius = 5;
            this.HTileButton2.Size = new System.Drawing.Size(150, 118);
            this.HTileButton2.TabIndex = 56;
            this.HTileButton2.Text = "No animation";
            this.HTileButton2.TextPadding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.HTileButton2.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.HTileButton2.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            this.HTileButton2.TextYOffset = 1F;
            // 
            // HTileButton1
            // 
            this.HTileButton1.AlphaAnimated = 180;
            this.HTileButton1.AnimationMode = HeCopUI_Framework.Enums.AnimationMode.None;
            this.HTileButton1.BackColor = System.Drawing.Color.Transparent;
            this.HTileButton1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.HTileButton1.BorderDownColor = System.Drawing.Color.Transparent;
            this.HTileButton1.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.HTileButton1.BorderThickness = 1;
            this.HTileButton1.ButtonImage = null;
            this.HTileButton1.ClipRegion = false;
            this.HTileButton1.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.HTileButton1.FocusBorderColor = System.Drawing.Color.White;
            this.HTileButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.HTileButton1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.HTileButton1.HoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.HTileButton1.HoverColor2 = System.Drawing.Color.White;
            this.HTileButton1.ImageOffsetY = 10F;
            this.HTileButton1.ImageSize = new System.Drawing.Size(30, 30);
            this.HTileButton1.Interval = 200;
            this.HTileButton1.Location = new System.Drawing.Point(93, 57);
            this.HTileButton1.Name = "HTileButton1";
            this.HTileButton1.NormalColor1 = System.Drawing.Color.White;
            this.HTileButton1.NormalColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.HTileButton1.PressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.HTileButton1.PressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.HTileButton1.RippleColor = System.Drawing.Color.BlanchedAlmond;
            this.HTileButton1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.HTileButton1.ShadowPadding = new System.Windows.Forms.Padding(0);
            this.HTileButton1.ShadowRadius = 5;
            this.HTileButton1.Size = new System.Drawing.Size(150, 118);
            this.HTileButton1.TabIndex = 55;
            this.HTileButton1.Text = "No animation";
            this.HTileButton1.TextPadding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.HTileButton1.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.HTileButton1.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            this.HTileButton1.TextYOffset = 1F;
            // 
            // tabPage26
            // 
            this.tabPage26.BackColor = System.Drawing.Color.White;
            this.tabPage26.Controls.Add(this.HTileSubtitleButton7);
            this.tabPage26.Controls.Add(this.HTileSubtitleButton8);
            this.tabPage26.Controls.Add(this.HTileSubtitleButton9);
            this.tabPage26.Controls.Add(this.HTileSubtitleButton4);
            this.tabPage26.Controls.Add(this.HTileSubtitleButton5);
            this.tabPage26.Controls.Add(this.HTileSubtitleButton6);
            this.tabPage26.Controls.Add(this.HTileSubtitleButton3);
            this.tabPage26.Controls.Add(this.HTileSubtitleButton2);
            this.tabPage26.Controls.Add(this.HTileSubtitleButton1);
            this.tabPage26.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage26.Location = new System.Drawing.Point(4, 34);
            this.tabPage26.Name = "tabPage26";
            this.tabPage26.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage26.Size = new System.Drawing.Size(728, 490);
            this.tabPage26.TabIndex = 2;
            this.tabPage26.Text = "Subtitle Button";
            // 
            // HTileSubtitleButton7
            // 
            this.HTileSubtitleButton7.AnimationMode = HeCopUI_Framework.Enums.AnimationMode.ColorTransition;
            this.HTileSubtitleButton7.BackColor = System.Drawing.Color.Transparent;
            this.HTileSubtitleButton7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.HTileSubtitleButton7.BorderDownColor = System.Drawing.Color.Transparent;
            this.HTileSubtitleButton7.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.HTileSubtitleButton7.BorderThickness = 0;
            this.HTileSubtitleButton7.ButtonImage = null;
            this.HTileSubtitleButton7.ClipRegion = false;
            this.HTileSubtitleButton7.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.HTileSubtitleButton7.FocusBorderColor = System.Drawing.Color.White;
            this.HTileSubtitleButton7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.HTileSubtitleButton7.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.HTileSubtitleButton7.HoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.HTileSubtitleButton7.HoverColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.HTileSubtitleButton7.ImageOffsetY = 15;
            this.HTileSubtitleButton7.ImageSize = new System.Drawing.Size(30, 30);
            this.HTileSubtitleButton7.Interval = 200;
            this.HTileSubtitleButton7.Location = new System.Drawing.Point(456, 344);
            this.HTileSubtitleButton7.Name = "HTileSubtitleButton7";
            this.HTileSubtitleButton7.NormalColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.HTileSubtitleButton7.NormalColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.HTileSubtitleButton7.PressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(98)))), ((int)(((byte)(78)))));
            this.HTileSubtitleButton7.PressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.HTileSubtitleButton7.RippleColor = System.Drawing.Color.Black;
            this.HTileSubtitleButton7.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.HTileSubtitleButton7.ShadowPadding = new System.Windows.Forms.Padding(3, 1, 3, 4);
            this.HTileSubtitleButton7.ShadowRadius = 5;
            this.HTileSubtitleButton7.Size = new System.Drawing.Size(150, 118);
            this.HTileSubtitleButton7.SubText = "Sub title ";
            this.HTileSubtitleButton7.SubTextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.HTileSubtitleButton7.SubTextColor = System.Drawing.Color.LightGray;
            this.HTileSubtitleButton7.SubTextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.HTileSubtitleButton7.SubTextOffSetY = -10;
            this.HTileSubtitleButton7.TabIndex = 80;
            this.HTileSubtitleButton7.Text = "Color Transition";
            this.HTileSubtitleButton7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.HTileSubtitleButton7.TextOffsetY = 1;
            this.HTileSubtitleButton7.TextOffsetY_Float = 1F;
            this.HTileSubtitleButton7.TextPadding = new System.Windows.Forms.Padding(0);
            this.HTileSubtitleButton7.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.HTileSubtitleButton7.TextTextPadding = new System.Windows.Forms.Padding(0);
            this.HTileSubtitleButton7.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            this.HTileSubtitleButton7.TextY = 10;
            // 
            // HTileSubtitleButton8
            // 
            this.HTileSubtitleButton8.AnimationMode = HeCopUI_Framework.Enums.AnimationMode.Ripple;
            this.HTileSubtitleButton8.BackColor = System.Drawing.Color.Transparent;
            this.HTileSubtitleButton8.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.HTileSubtitleButton8.BorderDownColor = System.Drawing.Color.Transparent;
            this.HTileSubtitleButton8.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.HTileSubtitleButton8.BorderThickness = 0;
            this.HTileSubtitleButton8.ButtonImage = null;
            this.HTileSubtitleButton8.ClipRegion = false;
            this.HTileSubtitleButton8.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.HTileSubtitleButton8.FocusBorderColor = System.Drawing.Color.White;
            this.HTileSubtitleButton8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.HTileSubtitleButton8.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.HTileSubtitleButton8.HoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.HTileSubtitleButton8.HoverColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.HTileSubtitleButton8.ImageOffsetY = 15;
            this.HTileSubtitleButton8.ImageSize = new System.Drawing.Size(30, 30);
            this.HTileSubtitleButton8.Interval = 200;
            this.HTileSubtitleButton8.Location = new System.Drawing.Point(456, 197);
            this.HTileSubtitleButton8.Name = "HTileSubtitleButton8";
            this.HTileSubtitleButton8.NormalColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.HTileSubtitleButton8.NormalColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.HTileSubtitleButton8.PressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(98)))), ((int)(((byte)(78)))));
            this.HTileSubtitleButton8.PressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.HTileSubtitleButton8.RippleColor = System.Drawing.Color.Black;
            this.HTileSubtitleButton8.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.HTileSubtitleButton8.ShadowPadding = new System.Windows.Forms.Padding(3, 1, 3, 4);
            this.HTileSubtitleButton8.ShadowRadius = 5;
            this.HTileSubtitleButton8.Size = new System.Drawing.Size(150, 118);
            this.HTileSubtitleButton8.SubText = "Sub title ";
            this.HTileSubtitleButton8.SubTextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.HTileSubtitleButton8.SubTextColor = System.Drawing.Color.LightGray;
            this.HTileSubtitleButton8.SubTextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.HTileSubtitleButton8.SubTextOffSetY = -10;
            this.HTileSubtitleButton8.TabIndex = 79;
            this.HTileSubtitleButton8.Text = "Ripple Effect";
            this.HTileSubtitleButton8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.HTileSubtitleButton8.TextOffsetY = 1;
            this.HTileSubtitleButton8.TextOffsetY_Float = 1F;
            this.HTileSubtitleButton8.TextPadding = new System.Windows.Forms.Padding(0);
            this.HTileSubtitleButton8.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.HTileSubtitleButton8.TextTextPadding = new System.Windows.Forms.Padding(0);
            this.HTileSubtitleButton8.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            this.HTileSubtitleButton8.TextY = 10;
            // 
            // HTileSubtitleButton9
            // 
            this.HTileSubtitleButton9.AnimationMode = HeCopUI_Framework.Enums.AnimationMode.None;
            this.HTileSubtitleButton9.BackColor = System.Drawing.Color.Transparent;
            this.HTileSubtitleButton9.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.HTileSubtitleButton9.BorderDownColor = System.Drawing.Color.Transparent;
            this.HTileSubtitleButton9.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.HTileSubtitleButton9.BorderThickness = 0;
            this.HTileSubtitleButton9.ButtonImage = null;
            this.HTileSubtitleButton9.ClipRegion = false;
            this.HTileSubtitleButton9.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.HTileSubtitleButton9.FocusBorderColor = System.Drawing.Color.White;
            this.HTileSubtitleButton9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.HTileSubtitleButton9.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.HTileSubtitleButton9.HoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.HTileSubtitleButton9.HoverColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.HTileSubtitleButton9.ImageOffsetY = 15;
            this.HTileSubtitleButton9.ImageSize = new System.Drawing.Size(30, 30);
            this.HTileSubtitleButton9.Interval = 200;
            this.HTileSubtitleButton9.Location = new System.Drawing.Point(456, 57);
            this.HTileSubtitleButton9.Name = "HTileSubtitleButton9";
            this.HTileSubtitleButton9.NormalColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.HTileSubtitleButton9.NormalColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.HTileSubtitleButton9.PressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(98)))), ((int)(((byte)(78)))));
            this.HTileSubtitleButton9.PressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.HTileSubtitleButton9.RippleColor = System.Drawing.Color.Black;
            this.HTileSubtitleButton9.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.HTileSubtitleButton9.ShadowPadding = new System.Windows.Forms.Padding(3, 1, 3, 4);
            this.HTileSubtitleButton9.ShadowRadius = 5;
            this.HTileSubtitleButton9.Size = new System.Drawing.Size(150, 118);
            this.HTileSubtitleButton9.SubText = "Sub title ";
            this.HTileSubtitleButton9.SubTextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.HTileSubtitleButton9.SubTextColor = System.Drawing.Color.LightGray;
            this.HTileSubtitleButton9.SubTextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.HTileSubtitleButton9.SubTextOffSetY = -10;
            this.HTileSubtitleButton9.TabIndex = 78;
            this.HTileSubtitleButton9.Text = "No animation";
            this.HTileSubtitleButton9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.HTileSubtitleButton9.TextOffsetY = 1;
            this.HTileSubtitleButton9.TextOffsetY_Float = 1F;
            this.HTileSubtitleButton9.TextPadding = new System.Windows.Forms.Padding(0);
            this.HTileSubtitleButton9.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.HTileSubtitleButton9.TextTextPadding = new System.Windows.Forms.Padding(0);
            this.HTileSubtitleButton9.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            this.HTileSubtitleButton9.TextY = 10;
            // 
            // HTileSubtitleButton4
            // 
            this.HTileSubtitleButton4.AnimationMode = HeCopUI_Framework.Enums.AnimationMode.ColorTransition;
            this.HTileSubtitleButton4.BackColor = System.Drawing.Color.Transparent;
            this.HTileSubtitleButton4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.HTileSubtitleButton4.BorderDownColor = System.Drawing.Color.Transparent;
            this.HTileSubtitleButton4.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.HTileSubtitleButton4.BorderThickness = 0;
            this.HTileSubtitleButton4.ButtonImage = null;
            this.HTileSubtitleButton4.ClipRegion = false;
            this.HTileSubtitleButton4.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.HTileSubtitleButton4.FocusBorderColor = System.Drawing.Color.White;
            this.HTileSubtitleButton4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.HTileSubtitleButton4.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.HTileSubtitleButton4.HoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.HTileSubtitleButton4.HoverColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.HTileSubtitleButton4.ImageOffsetY = 15;
            this.HTileSubtitleButton4.ImageSize = new System.Drawing.Size(30, 30);
            this.HTileSubtitleButton4.Interval = 200;
            this.HTileSubtitleButton4.Location = new System.Drawing.Point(274, 344);
            this.HTileSubtitleButton4.Name = "HTileSubtitleButton4";
            this.HTileSubtitleButton4.NormalColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.HTileSubtitleButton4.NormalColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.HTileSubtitleButton4.PressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(98)))), ((int)(((byte)(78)))));
            this.HTileSubtitleButton4.PressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.HTileSubtitleButton4.RippleColor = System.Drawing.Color.Black;
            this.HTileSubtitleButton4.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.HTileSubtitleButton4.ShadowPadding = new System.Windows.Forms.Padding(0);
            this.HTileSubtitleButton4.ShadowRadius = 5;
            this.HTileSubtitleButton4.Size = new System.Drawing.Size(150, 118);
            this.HTileSubtitleButton4.SubText = "Sub title ";
            this.HTileSubtitleButton4.SubTextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.HTileSubtitleButton4.SubTextColor = System.Drawing.Color.LightGray;
            this.HTileSubtitleButton4.SubTextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.HTileSubtitleButton4.SubTextOffSetY = -10;
            this.HTileSubtitleButton4.TabIndex = 77;
            this.HTileSubtitleButton4.Text = "Color Transition";
            this.HTileSubtitleButton4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.HTileSubtitleButton4.TextOffsetY = 1;
            this.HTileSubtitleButton4.TextOffsetY_Float = 1F;
            this.HTileSubtitleButton4.TextPadding = new System.Windows.Forms.Padding(0);
            this.HTileSubtitleButton4.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.HTileSubtitleButton4.TextTextPadding = new System.Windows.Forms.Padding(0);
            this.HTileSubtitleButton4.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            this.HTileSubtitleButton4.TextY = 10;
            // 
            // HTileSubtitleButton5
            // 
            this.HTileSubtitleButton5.AnimationMode = HeCopUI_Framework.Enums.AnimationMode.Ripple;
            this.HTileSubtitleButton5.BackColor = System.Drawing.Color.Transparent;
            this.HTileSubtitleButton5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.HTileSubtitleButton5.BorderDownColor = System.Drawing.Color.Transparent;
            this.HTileSubtitleButton5.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.HTileSubtitleButton5.BorderThickness = 0;
            this.HTileSubtitleButton5.ButtonImage = null;
            this.HTileSubtitleButton5.ClipRegion = false;
            this.HTileSubtitleButton5.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.HTileSubtitleButton5.FocusBorderColor = System.Drawing.Color.White;
            this.HTileSubtitleButton5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.HTileSubtitleButton5.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.HTileSubtitleButton5.HoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.HTileSubtitleButton5.HoverColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.HTileSubtitleButton5.ImageOffsetY = 15;
            this.HTileSubtitleButton5.ImageSize = new System.Drawing.Size(30, 30);
            this.HTileSubtitleButton5.Interval = 200;
            this.HTileSubtitleButton5.Location = new System.Drawing.Point(274, 197);
            this.HTileSubtitleButton5.Name = "HTileSubtitleButton5";
            this.HTileSubtitleButton5.NormalColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.HTileSubtitleButton5.NormalColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.HTileSubtitleButton5.PressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(98)))), ((int)(((byte)(78)))));
            this.HTileSubtitleButton5.PressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.HTileSubtitleButton5.RippleColor = System.Drawing.Color.Black;
            this.HTileSubtitleButton5.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.HTileSubtitleButton5.ShadowPadding = new System.Windows.Forms.Padding(0);
            this.HTileSubtitleButton5.ShadowRadius = 5;
            this.HTileSubtitleButton5.Size = new System.Drawing.Size(150, 118);
            this.HTileSubtitleButton5.SubText = "Sub title ";
            this.HTileSubtitleButton5.SubTextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.HTileSubtitleButton5.SubTextColor = System.Drawing.Color.LightGray;
            this.HTileSubtitleButton5.SubTextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.HTileSubtitleButton5.SubTextOffSetY = -10;
            this.HTileSubtitleButton5.TabIndex = 76;
            this.HTileSubtitleButton5.Text = "Ripple Effect";
            this.HTileSubtitleButton5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.HTileSubtitleButton5.TextOffsetY = 1;
            this.HTileSubtitleButton5.TextOffsetY_Float = 1F;
            this.HTileSubtitleButton5.TextPadding = new System.Windows.Forms.Padding(0);
            this.HTileSubtitleButton5.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.HTileSubtitleButton5.TextTextPadding = new System.Windows.Forms.Padding(0);
            this.HTileSubtitleButton5.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            this.HTileSubtitleButton5.TextY = 10;
            // 
            // HTileSubtitleButton6
            // 
            this.HTileSubtitleButton6.AnimationMode = HeCopUI_Framework.Enums.AnimationMode.None;
            this.HTileSubtitleButton6.BackColor = System.Drawing.Color.Transparent;
            this.HTileSubtitleButton6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.HTileSubtitleButton6.BorderDownColor = System.Drawing.Color.Transparent;
            this.HTileSubtitleButton6.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.HTileSubtitleButton6.BorderThickness = 0;
            this.HTileSubtitleButton6.ButtonImage = null;
            this.HTileSubtitleButton6.ClipRegion = false;
            this.HTileSubtitleButton6.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.HTileSubtitleButton6.FocusBorderColor = System.Drawing.Color.White;
            this.HTileSubtitleButton6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.HTileSubtitleButton6.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.HTileSubtitleButton6.HoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.HTileSubtitleButton6.HoverColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.HTileSubtitleButton6.ImageOffsetY = 15;
            this.HTileSubtitleButton6.ImageSize = new System.Drawing.Size(30, 30);
            this.HTileSubtitleButton6.Interval = 200;
            this.HTileSubtitleButton6.Location = new System.Drawing.Point(274, 57);
            this.HTileSubtitleButton6.Name = "HTileSubtitleButton6";
            this.HTileSubtitleButton6.NormalColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.HTileSubtitleButton6.NormalColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.HTileSubtitleButton6.PressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(98)))), ((int)(((byte)(78)))));
            this.HTileSubtitleButton6.PressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.HTileSubtitleButton6.RippleColor = System.Drawing.Color.Black;
            this.HTileSubtitleButton6.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.HTileSubtitleButton6.ShadowPadding = new System.Windows.Forms.Padding(0);
            this.HTileSubtitleButton6.ShadowRadius = 5;
            this.HTileSubtitleButton6.Size = new System.Drawing.Size(150, 118);
            this.HTileSubtitleButton6.SubText = "Sub title ";
            this.HTileSubtitleButton6.SubTextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.HTileSubtitleButton6.SubTextColor = System.Drawing.Color.LightGray;
            this.HTileSubtitleButton6.SubTextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.HTileSubtitleButton6.SubTextOffSetY = -10;
            this.HTileSubtitleButton6.TabIndex = 75;
            this.HTileSubtitleButton6.Text = "No animation";
            this.HTileSubtitleButton6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.HTileSubtitleButton6.TextOffsetY = 1;
            this.HTileSubtitleButton6.TextOffsetY_Float = 1F;
            this.HTileSubtitleButton6.TextPadding = new System.Windows.Forms.Padding(0);
            this.HTileSubtitleButton6.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.HTileSubtitleButton6.TextTextPadding = new System.Windows.Forms.Padding(0);
            this.HTileSubtitleButton6.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            this.HTileSubtitleButton6.TextY = 10;
            // 
            // HTileSubtitleButton3
            // 
            this.HTileSubtitleButton3.AnimationMode = HeCopUI_Framework.Enums.AnimationMode.ColorTransition;
            this.HTileSubtitleButton3.BackColor = System.Drawing.Color.Transparent;
            this.HTileSubtitleButton3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.HTileSubtitleButton3.BorderDownColor = System.Drawing.Color.Transparent;
            this.HTileSubtitleButton3.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.HTileSubtitleButton3.BorderThickness = 1;
            this.HTileSubtitleButton3.ButtonImage = null;
            this.HTileSubtitleButton3.ClipRegion = false;
            this.HTileSubtitleButton3.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.HTileSubtitleButton3.FocusBorderColor = System.Drawing.Color.White;
            this.HTileSubtitleButton3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.HTileSubtitleButton3.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.HTileSubtitleButton3.HoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.HTileSubtitleButton3.HoverColor2 = System.Drawing.Color.White;
            this.HTileSubtitleButton3.ImageOffsetY = 15;
            this.HTileSubtitleButton3.ImageSize = new System.Drawing.Size(30, 30);
            this.HTileSubtitleButton3.Interval = 200;
            this.HTileSubtitleButton3.Location = new System.Drawing.Point(93, 344);
            this.HTileSubtitleButton3.Name = "HTileSubtitleButton3";
            this.HTileSubtitleButton3.NormalColor1 = System.Drawing.Color.White;
            this.HTileSubtitleButton3.NormalColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.HTileSubtitleButton3.PressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.HTileSubtitleButton3.PressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.HTileSubtitleButton3.RippleColor = System.Drawing.Color.Black;
            this.HTileSubtitleButton3.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.HTileSubtitleButton3.ShadowPadding = new System.Windows.Forms.Padding(0);
            this.HTileSubtitleButton3.ShadowRadius = 5;
            this.HTileSubtitleButton3.Size = new System.Drawing.Size(150, 118);
            this.HTileSubtitleButton3.SubText = "Sub title";
            this.HTileSubtitleButton3.SubTextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.HTileSubtitleButton3.SubTextColor = System.Drawing.Color.Gray;
            this.HTileSubtitleButton3.SubTextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.HTileSubtitleButton3.SubTextOffSetY = -10;
            this.HTileSubtitleButton3.TabIndex = 74;
            this.HTileSubtitleButton3.Text = "Color Transition";
            this.HTileSubtitleButton3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.HTileSubtitleButton3.TextOffsetY = 1;
            this.HTileSubtitleButton3.TextOffsetY_Float = 1F;
            this.HTileSubtitleButton3.TextPadding = new System.Windows.Forms.Padding(0);
            this.HTileSubtitleButton3.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.HTileSubtitleButton3.TextTextPadding = new System.Windows.Forms.Padding(0);
            this.HTileSubtitleButton3.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            this.HTileSubtitleButton3.TextY = 10;
            // 
            // HTileSubtitleButton2
            // 
            this.HTileSubtitleButton2.AnimationMode = HeCopUI_Framework.Enums.AnimationMode.Ripple;
            this.HTileSubtitleButton2.BackColor = System.Drawing.Color.Transparent;
            this.HTileSubtitleButton2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.HTileSubtitleButton2.BorderDownColor = System.Drawing.Color.Transparent;
            this.HTileSubtitleButton2.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.HTileSubtitleButton2.BorderThickness = 1;
            this.HTileSubtitleButton2.ButtonImage = null;
            this.HTileSubtitleButton2.ClipRegion = false;
            this.HTileSubtitleButton2.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.HTileSubtitleButton2.FocusBorderColor = System.Drawing.Color.White;
            this.HTileSubtitleButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.HTileSubtitleButton2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.HTileSubtitleButton2.HoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.HTileSubtitleButton2.HoverColor2 = System.Drawing.Color.White;
            this.HTileSubtitleButton2.ImageOffsetY = 15;
            this.HTileSubtitleButton2.ImageSize = new System.Drawing.Size(30, 30);
            this.HTileSubtitleButton2.Interval = 200;
            this.HTileSubtitleButton2.Location = new System.Drawing.Point(93, 197);
            this.HTileSubtitleButton2.Name = "HTileSubtitleButton2";
            this.HTileSubtitleButton2.NormalColor1 = System.Drawing.Color.White;
            this.HTileSubtitleButton2.NormalColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.HTileSubtitleButton2.PressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.HTileSubtitleButton2.PressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.HTileSubtitleButton2.RippleColor = System.Drawing.Color.Black;
            this.HTileSubtitleButton2.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.HTileSubtitleButton2.ShadowPadding = new System.Windows.Forms.Padding(0);
            this.HTileSubtitleButton2.ShadowRadius = 5;
            this.HTileSubtitleButton2.Size = new System.Drawing.Size(150, 118);
            this.HTileSubtitleButton2.SubText = "Sub title";
            this.HTileSubtitleButton2.SubTextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.HTileSubtitleButton2.SubTextColor = System.Drawing.Color.Gray;
            this.HTileSubtitleButton2.SubTextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.HTileSubtitleButton2.SubTextOffSetY = -10;
            this.HTileSubtitleButton2.TabIndex = 73;
            this.HTileSubtitleButton2.Text = "Ripple Effect";
            this.HTileSubtitleButton2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.HTileSubtitleButton2.TextOffsetY = 1;
            this.HTileSubtitleButton2.TextOffsetY_Float = 1F;
            this.HTileSubtitleButton2.TextPadding = new System.Windows.Forms.Padding(0);
            this.HTileSubtitleButton2.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.HTileSubtitleButton2.TextTextPadding = new System.Windows.Forms.Padding(0);
            this.HTileSubtitleButton2.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            this.HTileSubtitleButton2.TextY = 10;
            // 
            // HTileSubtitleButton1
            // 
            this.HTileSubtitleButton1.AnimationMode = HeCopUI_Framework.Enums.AnimationMode.None;
            this.HTileSubtitleButton1.BackColor = System.Drawing.Color.Transparent;
            this.HTileSubtitleButton1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.HTileSubtitleButton1.BorderDownColor = System.Drawing.Color.Transparent;
            this.HTileSubtitleButton1.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.HTileSubtitleButton1.BorderThickness = 1;
            this.HTileSubtitleButton1.ButtonImage = null;
            this.HTileSubtitleButton1.ClipRegion = false;
            this.HTileSubtitleButton1.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.HTileSubtitleButton1.FocusBorderColor = System.Drawing.Color.White;
            this.HTileSubtitleButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.HTileSubtitleButton1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.HTileSubtitleButton1.HoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.HTileSubtitleButton1.HoverColor2 = System.Drawing.Color.White;
            this.HTileSubtitleButton1.ImageOffsetY = 15;
            this.HTileSubtitleButton1.ImageSize = new System.Drawing.Size(30, 30);
            this.HTileSubtitleButton1.Interval = 200;
            this.HTileSubtitleButton1.Location = new System.Drawing.Point(93, 57);
            this.HTileSubtitleButton1.Name = "HTileSubtitleButton1";
            this.HTileSubtitleButton1.NormalColor1 = System.Drawing.Color.White;
            this.HTileSubtitleButton1.NormalColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.HTileSubtitleButton1.PressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.HTileSubtitleButton1.PressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.HTileSubtitleButton1.RippleColor = System.Drawing.Color.Black;
            this.HTileSubtitleButton1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.HTileSubtitleButton1.ShadowPadding = new System.Windows.Forms.Padding(0);
            this.HTileSubtitleButton1.ShadowRadius = 5;
            this.HTileSubtitleButton1.Size = new System.Drawing.Size(150, 118);
            this.HTileSubtitleButton1.SubText = "Sub title";
            this.HTileSubtitleButton1.SubTextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.HTileSubtitleButton1.SubTextColor = System.Drawing.Color.Gray;
            this.HTileSubtitleButton1.SubTextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.HTileSubtitleButton1.SubTextOffSetY = -10;
            this.HTileSubtitleButton1.TabIndex = 72;
            this.HTileSubtitleButton1.Text = "No animation";
            this.HTileSubtitleButton1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.HTileSubtitleButton1.TextOffsetY = 1;
            this.HTileSubtitleButton1.TextOffsetY_Float = 1F;
            this.HTileSubtitleButton1.TextPadding = new System.Windows.Forms.Padding(0);
            this.HTileSubtitleButton1.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.HTileSubtitleButton1.TextTextPadding = new System.Windows.Forms.Padding(0);
            this.HTileSubtitleButton1.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            this.HTileSubtitleButton1.TextY = 10;
            // 
            // tabPage27
            // 
            this.tabPage27.BackColor = System.Drawing.Color.White;
            this.tabPage27.Controls.Add(this.hRadioButton3);
            this.tabPage27.Controls.Add(this.hRadioButton2);
            this.tabPage27.Controls.Add(this.hCheckBox3);
            this.tabPage27.Controls.Add(this.hCheckBox2);
            this.tabPage27.Controls.Add(this.hRadioButton1);
            this.tabPage27.Controls.Add(this.hToggleButton1);
            this.tabPage27.Controls.Add(this.hCheckBox1);
            this.tabPage27.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage27.Location = new System.Drawing.Point(4, 34);
            this.tabPage27.Name = "tabPage27";
            this.tabPage27.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage27.Size = new System.Drawing.Size(728, 490);
            this.tabPage27.TabIndex = 3;
            this.tabPage27.Text = "Switch/ Options";
            // 
            // hRadioButton3
            // 
            this.hRadioButton3.AlwayCheckedInstance = true;
            this.hRadioButton3.Checked = false;
            this.hRadioButton3.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.hRadioButton3.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(198)))), ((int)(((byte)(202)))));
            this.hRadioButton3.DisabledTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(187)))), ((int)(((byte)(189)))));
            this.hRadioButton3.EnabledCheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hRadioButton3.EnabledTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.hRadioButton3.EnabledUnCheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(158)))), ((int)(((byte)(161)))));
            this.hRadioButton3.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hRadioButton3.Location = new System.Drawing.Point(422, 243);
            this.hRadioButton3.Name = "hRadioButton3";
            this.hRadioButton3.RippleAlpha = 60;
            this.hRadioButton3.RippleColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(162)))));
            this.hRadioButton3.Size = new System.Drawing.Size(206, 28);
            this.hRadioButton3.TabIndex = 35;
            this.hRadioButton3.Text = "hRadioButton3";
            this.hRadioButton3.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hRadioButton3.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // hRadioButton2
            // 
            this.hRadioButton2.AlwayCheckedInstance = true;
            this.hRadioButton2.Checked = false;
            this.hRadioButton2.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.hRadioButton2.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(198)))), ((int)(((byte)(202)))));
            this.hRadioButton2.DisabledTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(187)))), ((int)(((byte)(189)))));
            this.hRadioButton2.EnabledCheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hRadioButton2.EnabledTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.hRadioButton2.EnabledUnCheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(158)))), ((int)(((byte)(161)))));
            this.hRadioButton2.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hRadioButton2.Location = new System.Drawing.Point(422, 196);
            this.hRadioButton2.Name = "hRadioButton2";
            this.hRadioButton2.RippleAlpha = 60;
            this.hRadioButton2.RippleColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(162)))));
            this.hRadioButton2.Size = new System.Drawing.Size(206, 28);
            this.hRadioButton2.TabIndex = 34;
            this.hRadioButton2.Text = "hRadioButton2";
            this.hRadioButton2.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hRadioButton2.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // hCheckBox3
            // 
            this.hCheckBox3.BorderBox = System.Drawing.Color.Transparent;
            this.hCheckBox3.CheckBoxColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hCheckBox3.CheckBoxColor2 = System.Drawing.Color.DodgerBlue;
            this.hCheckBox3.CheckColor = System.Drawing.Color.White;
            this.hCheckBox3.Checked = false;
            this.hCheckBox3.CheckedColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hCheckBox3.CheckedColor2 = System.Drawing.Color.DodgerBlue;
            this.hCheckBox3.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.hCheckBox3.DisabledColor = System.Drawing.Color.Gray;
            this.hCheckBox3.DisabledTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(187)))), ((int)(((byte)(189)))));
            this.hCheckBox3.EnabledTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.hCheckBox3.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hCheckBox3.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.hCheckBox3.Location = new System.Drawing.Point(111, 243);
            this.hCheckBox3.Name = "hCheckBox3";
            this.hCheckBox3.RippleAlpha = 60;
            this.hCheckBox3.RippleColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hCheckBox3.Size = new System.Drawing.Size(218, 28);
            this.hCheckBox3.TabIndex = 33;
            this.hCheckBox3.Text = "hCheckBox3";
            this.hCheckBox3.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hCheckBox3.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            this.hCheckBox3.UncheckedColor = System.Drawing.Color.DimGray;
            // 
            // hCheckBox2
            // 
            this.hCheckBox2.BorderBox = System.Drawing.Color.Transparent;
            this.hCheckBox2.CheckBoxColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hCheckBox2.CheckBoxColor2 = System.Drawing.Color.DodgerBlue;
            this.hCheckBox2.CheckColor = System.Drawing.Color.White;
            this.hCheckBox2.Checked = false;
            this.hCheckBox2.CheckedColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hCheckBox2.CheckedColor2 = System.Drawing.Color.DodgerBlue;
            this.hCheckBox2.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.hCheckBox2.DisabledColor = System.Drawing.Color.Gray;
            this.hCheckBox2.DisabledTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(187)))), ((int)(((byte)(189)))));
            this.hCheckBox2.EnabledTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.hCheckBox2.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hCheckBox2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.hCheckBox2.Location = new System.Drawing.Point(111, 196);
            this.hCheckBox2.Name = "hCheckBox2";
            this.hCheckBox2.RippleAlpha = 60;
            this.hCheckBox2.RippleColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hCheckBox2.Size = new System.Drawing.Size(218, 28);
            this.hCheckBox2.TabIndex = 32;
            this.hCheckBox2.Text = "hCheckBox2";
            this.hCheckBox2.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hCheckBox2.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            this.hCheckBox2.UncheckedColor = System.Drawing.Color.DimGray;
            // 
            // hRadioButton1
            // 
            this.hRadioButton1.AlwayCheckedInstance = true;
            this.hRadioButton1.Checked = true;
            this.hRadioButton1.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.hRadioButton1.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(198)))), ((int)(((byte)(202)))));
            this.hRadioButton1.DisabledTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(187)))), ((int)(((byte)(189)))));
            this.hRadioButton1.EnabledCheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hRadioButton1.EnabledTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.hRadioButton1.EnabledUnCheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(158)))), ((int)(((byte)(161)))));
            this.hRadioButton1.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hRadioButton1.Location = new System.Drawing.Point(422, 149);
            this.hRadioButton1.Name = "hRadioButton1";
            this.hRadioButton1.RippleAlpha = 60;
            this.hRadioButton1.RippleColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(162)))));
            this.hRadioButton1.Size = new System.Drawing.Size(206, 28);
            this.hRadioButton1.TabIndex = 31;
            this.hRadioButton1.Text = "hRadioButton1";
            this.hRadioButton1.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hRadioButton1.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // hToggleButton1
            // 
            this.hToggleButton1.BorderColor = System.Drawing.Color.LightGray;
            this.hToggleButton1.BorderLeverColor = System.Drawing.Color.DarkGray;
            this.hToggleButton1.IsOn = false;
            this.hToggleButton1.LeverColor = System.Drawing.Color.White;
            this.hToggleButton1.Location = new System.Drawing.Point(111, 328);
            this.hToggleButton1.Name = "hToggleButton1";
            this.hToggleButton1.OffColor = System.Drawing.Color.DimGray;
            this.hToggleButton1.OffText = "Off";
            this.hToggleButton1.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hToggleButton1.OnText = "On";
            this.hToggleButton1.Radius = 13.5F;
            this.hToggleButton1.Size = new System.Drawing.Size(54, 29);
            this.hToggleButton1.StatusColor = System.Drawing.Color.White;
            this.hToggleButton1.TabIndex = 28;
            this.hToggleButton1.Text = "hToggleButton1";
            this.hToggleButton1.TextEnabled = true;
            this.hToggleButton1.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // hCheckBox1
            // 
            this.hCheckBox1.BorderBox = System.Drawing.Color.Transparent;
            this.hCheckBox1.CheckBoxColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hCheckBox1.CheckBoxColor2 = System.Drawing.Color.DodgerBlue;
            this.hCheckBox1.CheckColor = System.Drawing.Color.White;
            this.hCheckBox1.Checked = true;
            this.hCheckBox1.CheckedColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hCheckBox1.CheckedColor2 = System.Drawing.Color.DodgerBlue;
            this.hCheckBox1.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.hCheckBox1.DisabledColor = System.Drawing.Color.Gray;
            this.hCheckBox1.DisabledTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(187)))), ((int)(((byte)(189)))));
            this.hCheckBox1.EnabledTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.hCheckBox1.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hCheckBox1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.hCheckBox1.Location = new System.Drawing.Point(111, 149);
            this.hCheckBox1.Name = "hCheckBox1";
            this.hCheckBox1.RippleAlpha = 60;
            this.hCheckBox1.RippleColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hCheckBox1.Size = new System.Drawing.Size(218, 28);
            this.hCheckBox1.TabIndex = 27;
            this.hCheckBox1.Text = "hCheckBox1";
            this.hCheckBox1.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hCheckBox1.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            this.hCheckBox1.UncheckedColor = System.Drawing.Color.DimGray;
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.tabPage5.Controls.Add(this.hEffectImage1);
            this.tabPage5.Controls.Add(this.hImage1);
            this.tabPage5.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage5.Location = new System.Drawing.Point(139, 4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(746, 538);
            this.tabPage5.TabIndex = 15;
            this.tabPage5.Text = "Images";
            // 
            // hEffectImage1
            // 
            this.hEffectImage1.Image = global::HecopUI_Test.Properties.Resources.hTitleButton1_ButtonImage;
            this.hEffectImage1.ImageSize = new System.Drawing.Size(150, 150);
            this.hEffectImage1.Intensity = 1;
            this.hEffectImage1.Location = new System.Drawing.Point(433, 81);
            this.hEffectImage1.Name = "hEffectImage1";
            this.hEffectImage1.Size = new System.Drawing.Size(270, 211);
            this.hEffectImage1.TabIndex = 1;
            this.hEffectImage1.TargetColor = System.Drawing.Color.Green;
            this.hEffectImage1.Text = "hEffectImage1";
            // 
            // hImage1
            // 
            this.hImage1.BlurIntensity = 3;
            this.hImage1.HShapeType = HeCopUI_Framework.Enums.ShapeType.RoundedRectangle;
            this.hImage1.Image = global::HecopUI_Test.Properties.Resources.hEffectImage1_Image;
            this.hImage1.ImageSize = new System.Drawing.Size(150, 150);
            this.hImage1.KernelMode = HeCopUI_Framework.Enums.KernelMode.GaussianBlur;
            this.hImage1.Location = new System.Drawing.Point(53, 58);
            this.hImage1.Name = "hImage1";
            this.hImage1.SetImageSizeMode = HeCopUI_Framework.Controls.HImage.ImageSizeMode.Custom;
            this.hImage1.Size = new System.Drawing.Size(222, 215);
            this.hImage1.TabIndex = 0;
            this.hImage1.Text = "hImage1";
            // 
            // tabPage22
            // 
            this.tabPage22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.tabPage22.Controls.Add(this.hTabControl10);
            this.tabPage22.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage22.Location = new System.Drawing.Point(139, 4);
            this.tabPage22.Name = "tabPage22";
            this.tabPage22.Padding = new System.Windows.Forms.Padding(5);
            this.tabPage22.Size = new System.Drawing.Size(746, 538);
            this.tabPage22.TabIndex = 14;
            this.tabPage22.Text = "Data View";
            // 
            // hTabControl10
            // 
            this.hTabControl10.ApplyTabPagesColor = true;
            this.hTabControl10.BackgroundColor = System.Drawing.Color.Transparent;
            this.hTabControl10.BorderTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hTabControl10.BorderThickness = 1;
            this.hTabControl10.Controls.Add(this.tabPage35);
            this.hTabControl10.Controls.Add(this.tabPage36);
            this.hTabControl10.CursorTabPages = System.Windows.Forms.Cursors.Default;
            this.hTabControl10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hTabControl10.ItemSize = new System.Drawing.Size(75, 30);
            this.hTabControl10.Location = new System.Drawing.Point(5, 5);
            this.hTabControl10.Name = "hTabControl10";
            this.hTabControl10.SelectedIndex = 0;
            this.hTabControl10.SelectedTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hTabControl10.SelectedTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hTabControl10.Size = new System.Drawing.Size(736, 528);
            this.hTabControl10.TabIndex = 3;
            this.hTabControl10.TabsColor = System.Drawing.Color.White;
            this.hTabControl10.TabStyle = HeCopUI_Framework.Enums.TabStyle.Style2;
            this.hTabControl10.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.hTabControl10.TextPadding = new System.Windows.Forms.Padding(0);
            this.hTabControl10.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hTabControl10.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hTabControl10.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            this.hTabControl10.UnSelectedBorderTabColor = System.Drawing.Color.Silver;
            this.hTabControl10.UnSelectedTabColor = System.Drawing.Color.Transparent;
            this.hTabControl10.UnselectedTextColor = System.Drawing.Color.DimGray;
            this.hTabControl10.UseAnimation = false;
            // 
            // tabPage35
            // 
            this.tabPage35.BackColor = System.Drawing.Color.White;
            this.tabPage35.Controls.Add(this.hTreeView1);
            this.tabPage35.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage35.Location = new System.Drawing.Point(4, 34);
            this.tabPage35.Name = "tabPage35";
            this.tabPage35.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage35.Size = new System.Drawing.Size(728, 490);
            this.tabPage35.TabIndex = 1;
            this.tabPage35.Text = "Tree View";
            // 
            // hTreeView1
            // 
            this.hTreeView1.AcceptNodeSelection = false;
            this.hTreeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hTreeView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.hTreeView1.CheckBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(100)))), ((int)(((byte)(252)))));
            this.hTreeView1.CheckBoxVisible = true;
            this.hTreeView1.CheckIconColor = System.Drawing.Color.White;
            this.hTreeView1.ImageList = null;
            this.hTreeView1.Indent = 20;
            this.hTreeView1.Location = new System.Drawing.Point(27, 24);
            this.hTreeView1.Name = "hTreeView1";
            this.hTreeView1.NodeBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.hTreeView1.NodeFont = new System.Drawing.Font("Arial", 10F);
            this.hTreeView1.NodeForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hTreeView1.NodeHeight = 20;
            this.hTreeView1.NodeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(238)))));
            treeNode25.Checked = false;
            treeNode25.Font = null;
            treeNode25.Image = null;
            treeNode25.ImageIndex = -1;
            treeNode25.Index = 0;
            treeNode25.IsExpanded = false;
            treeNode25.IsFocused = false;
            treeNode25.Name = "treeNode0";
            treeNode26.Checked = false;
            treeNode26.Font = null;
            treeNode26.Image = null;
            treeNode26.ImageIndex = -1;
            treeNode26.Index = 0;
            treeNode26.IsExpanded = false;
            treeNode26.IsFocused = false;
            treeNode26.Name = "treeNode0";
            treeNode26.Parent = treeNode25;
            treeNode26.Tag = null;
            treeNode26.Text = "tree Node 0";
            treeNode27.Checked = false;
            treeNode27.Font = null;
            treeNode27.Image = null;
            treeNode27.ImageIndex = -1;
            treeNode27.Index = 1;
            treeNode27.IsExpanded = false;
            treeNode27.IsFocused = false;
            treeNode27.Name = "treeNode1";
            treeNode28.Checked = false;
            treeNode28.Font = null;
            treeNode28.Image = null;
            treeNode28.ImageIndex = -1;
            treeNode28.Index = 0;
            treeNode28.IsExpanded = false;
            treeNode28.IsFocused = false;
            treeNode28.Name = "treeNode0";
            treeNode28.Parent = treeNode27;
            treeNode28.Tag = null;
            treeNode28.Text = "tree Node 0";
            treeNode29.Checked = false;
            treeNode29.Font = null;
            treeNode29.Image = null;
            treeNode29.ImageIndex = -1;
            treeNode29.Index = 1;
            treeNode29.IsExpanded = false;
            treeNode29.IsFocused = false;
            treeNode29.Name = "treeNode1";
            treeNode29.Parent = treeNode27;
            treeNode29.Tag = null;
            treeNode29.Text = "tree Node 1";
            treeNode30.Checked = false;
            treeNode30.Font = null;
            treeNode30.Image = null;
            treeNode30.ImageIndex = -1;
            treeNode30.Index = 2;
            treeNode30.IsExpanded = false;
            treeNode30.IsFocused = false;
            treeNode30.Name = "treeNode2";
            treeNode30.Parent = treeNode27;
            treeNode30.Tag = null;
            treeNode30.Text = "tree Node 2";
            treeNode31.Checked = false;
            treeNode31.Font = null;
            treeNode31.Image = null;
            treeNode31.ImageIndex = -1;
            treeNode31.Index = 3;
            treeNode31.IsExpanded = false;
            treeNode31.IsFocused = false;
            treeNode31.Name = "treeNode3";
            treeNode31.Parent = treeNode27;
            treeNode31.Tag = null;
            treeNode31.Text = "tree Node 3";
            treeNode32.Checked = false;
            treeNode32.Font = null;
            treeNode32.Image = null;
            treeNode32.ImageIndex = -1;
            treeNode32.Index = 4;
            treeNode32.IsExpanded = false;
            treeNode32.IsFocused = false;
            treeNode32.Name = "treeNode4";
            treeNode32.Parent = treeNode27;
            treeNode32.Tag = null;
            treeNode32.Text = "tree Node 4";
            treeNode33.Checked = false;
            treeNode33.Font = null;
            treeNode33.Image = null;
            treeNode33.ImageIndex = -1;
            treeNode33.Index = 5;
            treeNode33.IsExpanded = false;
            treeNode33.IsFocused = false;
            treeNode33.Name = "treeNode5";
            treeNode33.Parent = treeNode27;
            treeNode33.Tag = null;
            treeNode33.Text = "tree Node 5";
            treeNode27.Nodes.Add(treeNode28);
            treeNode27.Nodes.Add(treeNode29);
            treeNode27.Nodes.Add(treeNode30);
            treeNode27.Nodes.Add(treeNode31);
            treeNode27.Nodes.Add(treeNode32);
            treeNode27.Nodes.Add(treeNode33);
            treeNode27.Parent = treeNode25;
            treeNode27.Tag = null;
            treeNode27.Text = "tree Node 1";
            treeNode34.Checked = false;
            treeNode34.Font = null;
            treeNode34.Image = null;
            treeNode34.ImageIndex = -1;
            treeNode34.Index = 2;
            treeNode34.IsExpanded = false;
            treeNode34.IsFocused = false;
            treeNode34.Name = "treeNode2";
            treeNode34.Parent = treeNode25;
            treeNode34.Tag = null;
            treeNode34.Text = "tree Node 2";
            treeNode35.Checked = false;
            treeNode35.Font = null;
            treeNode35.Image = null;
            treeNode35.ImageIndex = -1;
            treeNode35.Index = 3;
            treeNode35.IsExpanded = false;
            treeNode35.IsFocused = false;
            treeNode35.Name = "treeNode3";
            treeNode35.Parent = treeNode25;
            treeNode35.Tag = null;
            treeNode35.Text = "tree Node 3";
            treeNode25.Nodes.Add(treeNode26);
            treeNode25.Nodes.Add(treeNode27);
            treeNode25.Nodes.Add(treeNode34);
            treeNode25.Nodes.Add(treeNode35);
            treeNode25.Parent = null;
            treeNode25.Tag = null;
            treeNode25.Text = "tree Node 0";
            treeNode36.Checked = false;
            treeNode36.Font = null;
            treeNode36.Image = null;
            treeNode36.ImageIndex = -1;
            treeNode36.Index = 1;
            treeNode36.IsExpanded = false;
            treeNode36.IsFocused = false;
            treeNode36.Name = "treeNode1";
            treeNode36.Parent = null;
            treeNode36.Tag = null;
            treeNode36.Text = "tree Node 1";
            treeNode37.Checked = false;
            treeNode37.Font = null;
            treeNode37.Image = null;
            treeNode37.ImageIndex = -1;
            treeNode37.Index = 2;
            treeNode37.IsExpanded = false;
            treeNode37.IsFocused = false;
            treeNode37.Name = "treeNode2";
            treeNode37.Parent = null;
            treeNode37.Tag = null;
            treeNode37.Text = "tree Node 2";
            treeNode38.Checked = false;
            treeNode38.Font = null;
            treeNode38.Image = null;
            treeNode38.ImageIndex = -1;
            treeNode38.Index = 3;
            treeNode38.IsExpanded = false;
            treeNode38.IsFocused = false;
            treeNode38.Name = "treeNode3";
            treeNode39.Checked = false;
            treeNode39.Font = null;
            treeNode39.Image = null;
            treeNode39.ImageIndex = -1;
            treeNode39.Index = 0;
            treeNode39.IsExpanded = false;
            treeNode39.IsFocused = false;
            treeNode39.Name = "treeNode0";
            treeNode39.Parent = treeNode38;
            treeNode39.Tag = null;
            treeNode39.Text = "tree Node 0";
            treeNode40.Checked = false;
            treeNode40.Font = null;
            treeNode40.Image = null;
            treeNode40.ImageIndex = -1;
            treeNode40.Index = 1;
            treeNode40.IsExpanded = false;
            treeNode40.IsFocused = false;
            treeNode40.Name = "treeNode1";
            treeNode40.Parent = treeNode38;
            treeNode40.Tag = null;
            treeNode40.Text = "tree Node 1";
            treeNode41.Checked = false;
            treeNode41.Font = null;
            treeNode41.Image = null;
            treeNode41.ImageIndex = -1;
            treeNode41.Index = 2;
            treeNode41.IsExpanded = false;
            treeNode41.IsFocused = false;
            treeNode41.Name = "treeNode2";
            treeNode41.Parent = treeNode38;
            treeNode41.Tag = null;
            treeNode41.Text = "tree Node 2";
            treeNode38.Nodes.Add(treeNode39);
            treeNode38.Nodes.Add(treeNode40);
            treeNode38.Nodes.Add(treeNode41);
            treeNode38.Parent = null;
            treeNode38.Tag = null;
            treeNode38.Text = "tree Node 3";
            treeNode42.Checked = false;
            treeNode42.Font = null;
            treeNode42.Image = null;
            treeNode42.ImageIndex = -1;
            treeNode42.Index = 4;
            treeNode42.IsExpanded = false;
            treeNode42.IsFocused = false;
            treeNode42.Name = "treeNode4";
            treeNode42.Parent = null;
            treeNode42.Tag = null;
            treeNode42.Text = "tree Node 4";
            treeNode43.Checked = false;
            treeNode43.Font = null;
            treeNode43.Image = null;
            treeNode43.ImageIndex = -1;
            treeNode43.Index = 5;
            treeNode43.IsExpanded = false;
            treeNode43.IsFocused = false;
            treeNode43.Name = "treeNode5";
            treeNode44.Checked = false;
            treeNode44.Font = null;
            treeNode44.Image = null;
            treeNode44.ImageIndex = -1;
            treeNode44.Index = 0;
            treeNode44.IsExpanded = false;
            treeNode44.IsFocused = false;
            treeNode44.Name = "treeNode0";
            treeNode44.Parent = treeNode43;
            treeNode44.Tag = null;
            treeNode44.Text = "tree Node 0";
            treeNode45.Checked = false;
            treeNode45.Font = null;
            treeNode45.Image = null;
            treeNode45.ImageIndex = -1;
            treeNode45.Index = 1;
            treeNode45.IsExpanded = false;
            treeNode45.IsFocused = false;
            treeNode45.Name = "treeNode1";
            treeNode45.Parent = treeNode43;
            treeNode45.Tag = null;
            treeNode45.Text = "tree Node 1";
            treeNode46.Checked = false;
            treeNode46.Font = null;
            treeNode46.Image = null;
            treeNode46.ImageIndex = -1;
            treeNode46.Index = 2;
            treeNode46.IsExpanded = false;
            treeNode46.IsFocused = false;
            treeNode46.Name = "treeNode2";
            treeNode46.Parent = treeNode43;
            treeNode46.Tag = null;
            treeNode46.Text = "tree Node 2";
            treeNode47.Checked = false;
            treeNode47.Font = null;
            treeNode47.Image = null;
            treeNode47.ImageIndex = -1;
            treeNode47.Index = 3;
            treeNode47.IsExpanded = false;
            treeNode47.IsFocused = false;
            treeNode47.Name = "treeNode3";
            treeNode47.Parent = treeNode43;
            treeNode47.Tag = null;
            treeNode47.Text = "tree Node 3";
            treeNode43.Nodes.Add(treeNode44);
            treeNode43.Nodes.Add(treeNode45);
            treeNode43.Nodes.Add(treeNode46);
            treeNode43.Nodes.Add(treeNode47);
            treeNode43.Parent = null;
            treeNode43.Tag = null;
            treeNode43.Text = "tree Node 5";
            treeNode48.Checked = false;
            treeNode48.Font = null;
            treeNode48.Image = null;
            treeNode48.ImageIndex = -1;
            treeNode48.Index = 6;
            treeNode48.IsExpanded = false;
            treeNode48.IsFocused = false;
            treeNode48.Name = "treeNode6";
            treeNode48.Parent = null;
            treeNode48.Tag = null;
            treeNode48.Text = "tree Node 6";
            this.hTreeView1.Nodes.Add(treeNode25);
            this.hTreeView1.Nodes.Add(treeNode36);
            this.hTreeView1.Nodes.Add(treeNode37);
            this.hTreeView1.Nodes.Add(treeNode38);
            this.hTreeView1.Nodes.Add(treeNode42);
            this.hTreeView1.Nodes.Add(treeNode43);
            this.hTreeView1.Nodes.Add(treeNode48);
            this.hTreeView1.NodeSelectedColor = System.Drawing.Color.LightBlue;
            this.hTreeView1.PathSeparator = "\\";
            this.hTreeView1.PlusMinusBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hTreeView1.PlusMinusColor = System.Drawing.Color.White;
            this.hTreeView1.RootLinesColor = System.Drawing.Color.Gray;
            this.hTreeView1.ShowPlusMinus = true;
            this.hTreeView1.ShowRootLines = true;
            this.hTreeView1.Size = new System.Drawing.Size(686, 357);
            this.hTreeView1.SpaceBetweenNodes = 1;
            this.hTreeView1.TabIndex = 0;
            this.hTreeView1.Text = "hTreeView1";
            this.hTreeView1.TextRenderHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.hTreeView1.AfterSelect += new HeCopUI_Framework.Controls.TreeView.HTreeView.TreeViewEventHandler(this.hTreeView1_AfterSelect);
            // 
            // tabPage36
            // 
            this.tabPage36.BackColor = System.Drawing.Color.White;
            this.tabPage36.Controls.Add(this.hButton11);
            this.tabPage36.Controls.Add(this.hTabControl4);
            this.tabPage36.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage36.Location = new System.Drawing.Point(4, 34);
            this.tabPage36.Name = "tabPage36";
            this.tabPage36.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage36.Size = new System.Drawing.Size(728, 490);
            this.tabPage36.TabIndex = 2;
            this.tabPage36.Text = "Charts";
            // 
            // hButton11
            // 
            this.hButton11.AnimationMode = HeCopUI_Framework.Enums.AnimationMode.None;
            this.hButton11.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hButton11.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hButton11.BorderPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hButton11.BorderThickness = 0;
            this.hButton11.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hButton11.ClipRegion = false;
            this.hButton11.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.hButton11.DialogResult = System.Windows.Forms.DialogResult.None;
            this.hButton11.FocusBorderColor = System.Drawing.Color.White;
            this.hButton11.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.hButton11.HoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hButton11.HoverColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.hButton11.Image = null;
            this.hButton11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.hButton11.ImagePadding = new System.Windows.Forms.Padding(0);
            this.hButton11.ImageSize = new System.Drawing.Size(20, 20);
            this.hButton11.Location = new System.Drawing.Point(710, 492);
            this.hButton11.Name = "hButton11";
            this.hButton11.NormalColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.hButton11.NormalColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hButton11.PressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(98)))), ((int)(((byte)(78)))));
            this.hButton11.PressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hButton11.RippleColor = System.Drawing.Color.Black;
            this.hButton11.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.hButton11.ShadowPadding = new System.Windows.Forms.Padding(0);
            this.hButton11.ShadowRadius = 5;
            this.hButton11.ShapeButtonType = HeCopUI_Framework.Enums.ShapeType.RoundedRectangle;
            this.hButton11.Size = new System.Drawing.Size(102, 34);
            this.hButton11.SupportImageGif = false;
            this.hButton11.TabIndex = 40;
            this.hButton11.Text = "Refresh";
            this.hButton11.TextHoverColor = System.Drawing.Color.White;
            this.hButton11.TextNormalColor = System.Drawing.Color.White;
            this.hButton11.TextPadding = new System.Windows.Forms.Padding(0);
            this.hButton11.TextPressColor = System.Drawing.Color.White;
            this.hButton11.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hButton11.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            this.hButton11.Click += new System.EventHandler(this.hButton11_Click_1);
            // 
            // hTabControl4
            // 
            this.hTabControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hTabControl4.ApplyTabPagesColor = true;
            this.hTabControl4.BackgroundColor = System.Drawing.Color.Transparent;
            this.hTabControl4.BorderTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(122)))));
            this.hTabControl4.BorderThickness = 1;
            this.hTabControl4.Controls.Add(this.tabPage15);
            this.hTabControl4.Controls.Add(this.tabPage16);
            this.hTabControl4.Controls.Add(this.tabPage17);
            this.hTabControl4.Controls.Add(this.tabPage18);
            this.hTabControl4.Controls.Add(this.tabPage14);
            this.hTabControl4.CursorTabPages = System.Windows.Forms.Cursors.Default;
            this.hTabControl4.ItemSize = new System.Drawing.Size(54, 28);
            this.hTabControl4.Location = new System.Drawing.Point(27, 21);
            this.hTabControl4.Multiline = true;
            this.hTabControl4.Name = "hTabControl4";
            this.hTabControl4.SelectedIndex = 0;
            this.hTabControl4.SelectedTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(122)))));
            this.hTabControl4.SelectedTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hTabControl4.Size = new System.Drawing.Size(695, 447);
            this.hTabControl4.TabIndex = 2;
            this.hTabControl4.TabsColor = System.Drawing.Color.White;
            this.hTabControl4.TabStyle = HeCopUI_Framework.Enums.TabStyle.Style2;
            this.hTabControl4.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.hTabControl4.TextPadding = new System.Windows.Forms.Padding(0);
            this.hTabControl4.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hTabControl4.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hTabControl4.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            this.hTabControl4.UnSelectedBorderTabColor = System.Drawing.Color.Silver;
            this.hTabControl4.UnSelectedTabColor = System.Drawing.Color.Transparent;
            this.hTabControl4.UnselectedTextColor = System.Drawing.Color.DimGray;
            this.hTabControl4.UseAnimation = false;
            // 
            // tabPage15
            // 
            this.tabPage15.BackColor = System.Drawing.Color.White;
            this.tabPage15.Controls.Add(this.hBarChart1);
            this.tabPage15.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage15.Location = new System.Drawing.Point(4, 32);
            this.tabPage15.Name = "tabPage15";
            this.tabPage15.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage15.Size = new System.Drawing.Size(687, 411);
            this.tabPage15.TabIndex = 0;
            this.tabPage15.Text = "Bar";
            // 
            // hBarChart1
            // 
            this.hBarChart1.BorderItems = false;
            this.hBarChart1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hBarChart1.ItemsTextColor = System.Drawing.Color.DimGray;
            this.hBarChart1.LegendColor = System.Drawing.Color.DarkGray;
            this.hBarChart1.LegendFont = new System.Drawing.Font("Arial", 10F);
            this.hBarChart1.LegendType = HeCopUI_Framework.Enums.LegendType.None;
            this.hBarChart1.LineChart = System.Drawing.Color.Gray;
            this.hBarChart1.Location = new System.Drawing.Point(32, 33);
            this.hBarChart1.Name = "hBarChart1";
            this.hBarChart1.NumbericChartColor = System.Drawing.Color.DarkGray;
            this.hBarChart1.ShowTitle = true;
            this.hBarChart1.Size = new System.Drawing.Size(614, 368);
            this.hBarChart1.SortMode = HeCopUI_Framework.Enums.SortMode.None;
            this.hBarChart1.SpaceBetweenItems = 50;
            this.hBarChart1.TabIndex = 0;
            this.hBarChart1.Text = "hBarChart1";
            this.hBarChart1.TitleChartAlign = HeCopUI_Framework.Enums.TitleChartAlign.TopLeft;
            this.hBarChart1.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(122)))));
            this.hBarChart1.TitleFont = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.hBarChart1.TitleText = "HBar Chart";
            this.hBarChart1.ToolTipFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hBarChart1.VisibleNumberOy = 10;
            // 
            // tabPage16
            // 
            this.tabPage16.BackColor = System.Drawing.Color.White;
            this.tabPage16.Controls.Add(this.hLineAreaChart1);
            this.tabPage16.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage16.Location = new System.Drawing.Point(4, 32);
            this.tabPage16.Name = "tabPage16";
            this.tabPage16.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage16.Size = new System.Drawing.Size(687, 411);
            this.tabPage16.TabIndex = 1;
            this.tabPage16.Text = "Line";
            // 
            // hLineAreaChart1
            // 
            this.hLineAreaChart1.AxisColor = System.Drawing.Color.Gray;
            this.hLineAreaChart1.LegendFont = new System.Drawing.Font("Arial", 10F);
            this.hLineAreaChart1.LegendType = HeCopUI_Framework.Enums.LegendType.Right;
            this.hLineAreaChart1.LineChartType = HeCopUI_Framework.Enums.LineChartType.Curve;
            this.hLineAreaChart1.Location = new System.Drawing.Point(32, 33);
            this.hLineAreaChart1.Name = "hLineAreaChart1";
            this.hLineAreaChart1.NumbericChartColor = System.Drawing.Color.DimGray;
            this.hLineAreaChart1.NumbericChartFont = new System.Drawing.Font("Arial", 8F);
            this.hLineAreaChart1.ShowTitle = true;
            this.hLineAreaChart1.Size = new System.Drawing.Size(713, 371);
            this.hLineAreaChart1.SortMode = HeCopUI_Framework.Enums.SortMode.None;
            this.hLineAreaChart1.SpaceBetweenPoints = 10;
            this.hLineAreaChart1.TabIndex = 0;
            this.hLineAreaChart1.Text = "hLineAreaChart1";
            this.hLineAreaChart1.TitleChartAlign = HeCopUI_Framework.Enums.TitleChartAlign.TopLeft;
            this.hLineAreaChart1.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hLineAreaChart1.TitleFont = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.hLineAreaChart1.TitleText = "Line Chart dạng cong";
            this.hLineAreaChart1.UseGradientBackground = true;
            this.hLineAreaChart1.VisibleNumberOy = 10;
            // 
            // tabPage17
            // 
            this.tabPage17.BackColor = System.Drawing.Color.White;
            this.tabPage17.Controls.Add(this.hPieChart1);
            this.tabPage17.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage17.Location = new System.Drawing.Point(4, 32);
            this.tabPage17.Name = "tabPage17";
            this.tabPage17.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage17.Size = new System.Drawing.Size(687, 411);
            this.tabPage17.TabIndex = 2;
            this.tabPage17.Text = "Pie";
            // 
            // hPieChart1
            // 
            this.hPieChart1.CircularColor = System.Drawing.Color.Salmon;
            this.hPieChart1.CircularWidth = 0;
            this.hPieChart1.LegendChart = HeCopUI_Framework.Enums.LegendType.Right;
            this.hPieChart1.LegendFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hPieChart1.LegendTextColor = System.Drawing.Color.DimGray;
            this.hPieChart1.Location = new System.Drawing.Point(32, 33);
            this.hPieChart1.Name = "hPieChart1";
            this.hPieChart1.PieCharSize = 200;
            this.hPieChart1.SeriesValueFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hPieChart1.ShowValuesTip = true;
            this.hPieChart1.Size = new System.Drawing.Size(599, 371);
            this.hPieChart1.StartAngle = 0;
            this.hPieChart1.TabIndex = 0;
            this.hPieChart1.Text = "hPieChart1";
            this.hPieChart1.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hPieChart1.ValueColor = System.Drawing.Color.White;
            this.hPieChart1.VisibleLegend = true;
            // 
            // tabPage18
            // 
            this.tabPage18.BackColor = System.Drawing.Color.White;
            this.tabPage18.Controls.Add(this.hRadarChart1);
            this.tabPage18.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage18.Location = new System.Drawing.Point(4, 32);
            this.tabPage18.Name = "tabPage18";
            this.tabPage18.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage18.Size = new System.Drawing.Size(687, 411);
            this.tabPage18.TabIndex = 3;
            this.tabPage18.Text = "Radar";
            // 
            // hRadarChart1
            // 
            this.hRadarChart1.LegendColor = System.Drawing.Color.DarkGray;
            this.hRadarChart1.LegendFont = new System.Drawing.Font("Segoe UI", 10F);
            this.hRadarChart1.LegendType = HeCopUI_Framework.Enums.LegendType.Right;
            this.hRadarChart1.Location = new System.Drawing.Point(32, 33);
            this.hRadarChart1.MaxValue = 100;
            this.hRadarChart1.Name = "hRadarChart1";
            this.hRadarChart1.NumberVisible = true;
            this.hRadarChart1.PointSize = 8;
            this.hRadarChart1.RadarColor = System.Drawing.Color.Gray;
            series2.Color = System.Drawing.Color.OrangeRed;
            series2.Text = "Tên mục";
            series2.Values = new float[] {
        90F,
        50F,
        70F,
        40F,
        60F};
            this.hRadarChart1.Series = new HeCopUI_Framework.Controls.Chart.Series[] {
        series2};
            this.hRadarChart1.ShowTitle = true;
            this.hRadarChart1.ShowValuesTip = false;
            this.hRadarChart1.Size = new System.Drawing.Size(599, 371);
            this.hRadarChart1.Step = 20;
            this.hRadarChart1.TabIndex = 0;
            this.hRadarChart1.Text = "hRadarChart1";
            this.hRadarChart1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.hRadarChart1.Title = "Radar Chart";
            this.hRadarChart1.TitleChartAlign = HeCopUI_Framework.Enums.TitleChartAlign.TopLeft;
            this.hRadarChart1.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(122)))));
            this.hRadarChart1.TitleFont = new System.Drawing.Font("Segoe UI", 12F);
            // 
            // tabPage14
            // 
            this.tabPage14.BackColor = System.Drawing.Color.White;
            this.tabPage14.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage14.Location = new System.Drawing.Point(4, 32);
            this.tabPage14.Name = "tabPage14";
            this.tabPage14.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage14.Size = new System.Drawing.Size(687, 411);
            this.tabPage14.TabIndex = 4;
            this.tabPage14.Text = "Chart cui";
            // 
            // tabPage21
            // 
            this.tabPage21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.tabPage21.Controls.Add(this.hTextBox2);
            this.tabPage21.Controls.Add(this.hTextBox1);
            this.tabPage21.Controls.Add(this.hRichTextBox2);
            this.tabPage21.Controls.Add(this.hRichTextBox1);
            this.tabPage21.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage21.Location = new System.Drawing.Point(139, 4);
            this.tabPage21.Name = "tabPage21";
            this.tabPage21.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage21.Size = new System.Drawing.Size(746, 538);
            this.tabPage21.TabIndex = 13;
            this.tabPage21.Text = "TextBox & Labels";
            // 
            // hTextBox2
            // 
            this.hTextBox2.AcceptReturn = false;
            this.hTextBox2.AcceptTab = false;
            this.hTextBox2.BorderColor = System.Drawing.Color.Gray;
            this.hTextBox2.BorderWidth = 1;
            this.hTextBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.hTextBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.hTextBox2.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hTextBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hTextBox2.HideSelection = true;
            this.hTextBox2.Image = null;
            this.hTextBox2.ImageAlignRight = false;
            this.hTextBox2.ImageSize = new System.Drawing.Size(20, 20);
            this.hTextBox2.ImageVisible = false;
            this.hTextBox2.Lines = new string[0];
            this.hTextBox2.Location = new System.Drawing.Point(393, 132);
            this.hTextBox2.MaxLength = 32767;
            this.hTextBox2.Name = "hTextBox2";
            this.hTextBox2.PasswordChar = '\0';
            this.hTextBox2.ReadOnly = false;
            this.hTextBox2.ShortCutKeysEnabled = true;
            this.hTextBox2.Size = new System.Drawing.Size(250, 34);
            this.hTextBox2.TabIndex = 9;
            this.hTextBox2.Text = "hTextBox2";
            this.hTextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.hTextBox2.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hTextBox2.UnderlineStyle = false;
            this.hTextBox2.UseAnimation = true;
            this.hTextBox2.Watermark = "Type watermark text here.";
            this.hTextBox2.WatermarkFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hTextBox2.WatermarkForeColor = System.Drawing.Color.Gray;
            this.hTextBox2.WordWrap = true;
            // 
            // hTextBox1
            // 
            this.hTextBox1.AcceptReturn = false;
            this.hTextBox1.AcceptTab = false;
            this.hTextBox1.BorderColor = System.Drawing.Color.Gray;
            this.hTextBox1.BorderWidth = 1;
            this.hTextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.hTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.hTextBox1.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hTextBox1.HideSelection = true;
            this.hTextBox1.Image = null;
            this.hTextBox1.ImageAlignRight = false;
            this.hTextBox1.ImageSize = new System.Drawing.Size(20, 20);
            this.hTextBox1.ImageVisible = false;
            this.hTextBox1.Lines = new string[0];
            this.hTextBox1.Location = new System.Drawing.Point(113, 132);
            this.hTextBox1.MaxLength = 32767;
            this.hTextBox1.Name = "hTextBox1";
            this.hTextBox1.PasswordChar = '\0';
            this.hTextBox1.ReadOnly = false;
            this.hTextBox1.ShortCutKeysEnabled = true;
            this.hTextBox1.Size = new System.Drawing.Size(250, 34);
            this.hTextBox1.TabIndex = 8;
            this.hTextBox1.Text = "hTextBox1";
            this.hTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.hTextBox1.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hTextBox1.UnderlineStyle = true;
            this.hTextBox1.UseAnimation = true;
            this.hTextBox1.Watermark = "Type watermark text here.";
            this.hTextBox1.WatermarkFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hTextBox1.WatermarkForeColor = System.Drawing.Color.Gray;
            this.hTextBox1.WordWrap = true;
            // 
            // hRichTextBox2
            // 
            this.hRichTextBox2.AcceptsTab = false;
            this.hRichTextBox2.AutoWordSelection = false;
            this.hRichTextBox2.BorderColor = System.Drawing.Color.Gray;
            this.hRichTextBox2.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hRichTextBox2.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(162)))));
            this.hRichTextBox2.BorderThickness = 1;
            this.hRichTextBox2.BulletIndent = 0;
            this.hRichTextBox2.DetectUrls = true;
            this.hRichTextBox2.EnableAutoDragDrop = false;
            this.hRichTextBox2.HideSelection = false;
            this.hRichTextBox2.Lines = new string[] {
        "hRichTextBox2"};
            this.hRichTextBox2.Location = new System.Drawing.Point(393, 191);
            this.hRichTextBox2.MaxLength = 2147483647;
            this.hRichTextBox2.MultiLine = true;
            this.hRichTextBox2.Name = "hRichTextBox2";
            this.hRichTextBox2.Radius = 1;
            this.hRichTextBox2.ReadOnly = false;
            this.hRichTextBox2.RichTextBoxColor = System.Drawing.Color.White;
            this.hRichTextBox2.RichTextBoxHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.hRichTextBox2.RichTextBoxScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Both;
            this.hRichTextBox2.SelectionRightIndent = 0;
            this.hRichTextBox2.ShorcutEnabled = false;
            this.hRichTextBox2.ShowSelectionMargin = false;
            this.hRichTextBox2.Size = new System.Drawing.Size(250, 268);
            this.hRichTextBox2.TabIndex = 7;
            this.hRichTextBox2.Text = "hRichTextBox2";
            this.hRichTextBox2.TextColor = System.Drawing.Color.DimGray;
            this.hRichTextBox2.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hRichTextBox2.WordWrap = true;
            // 
            // hRichTextBox1
            // 
            this.hRichTextBox1.AcceptsTab = false;
            this.hRichTextBox1.AutoWordSelection = false;
            this.hRichTextBox1.BorderColor = System.Drawing.Color.Gray;
            this.hRichTextBox1.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hRichTextBox1.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(162)))));
            this.hRichTextBox1.BorderThickness = 1;
            this.hRichTextBox1.BulletIndent = 0;
            this.hRichTextBox1.DetectUrls = true;
            this.hRichTextBox1.EnableAutoDragDrop = false;
            this.hRichTextBox1.HideSelection = false;
            this.hRichTextBox1.Lines = new string[] {
        "hRichTextBox1"};
            this.hRichTextBox1.Location = new System.Drawing.Point(113, 191);
            this.hRichTextBox1.MaxLength = 2147483647;
            this.hRichTextBox1.MultiLine = true;
            this.hRichTextBox1.Name = "hRichTextBox1";
            this.hRichTextBox1.Radius = 1;
            this.hRichTextBox1.ReadOnly = false;
            this.hRichTextBox1.RichTextBoxColor = System.Drawing.Color.White;
            this.hRichTextBox1.RichTextBoxHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.hRichTextBox1.RichTextBoxScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Both;
            this.hRichTextBox1.SelectionRightIndent = 0;
            this.hRichTextBox1.ShorcutEnabled = false;
            this.hRichTextBox1.ShowSelectionMargin = false;
            this.hRichTextBox1.Size = new System.Drawing.Size(250, 268);
            this.hRichTextBox1.TabIndex = 4;
            this.hRichTextBox1.Text = "hRichTextBox1";
            this.hRichTextBox1.TextColor = System.Drawing.Color.DimGray;
            this.hRichTextBox1.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hRichTextBox1.WordWrap = true;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.tabPage4.Controls.Add(this.hTabControl6);
            this.tabPage4.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage4.Location = new System.Drawing.Point(139, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(5);
            this.tabPage4.Size = new System.Drawing.Size(746, 538);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Progress";
            // 
            // hTabControl6
            // 
            this.hTabControl6.ApplyTabPagesColor = true;
            this.hTabControl6.BackgroundColor = System.Drawing.Color.Transparent;
            this.hTabControl6.BorderTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hTabControl6.BorderThickness = 1;
            this.hTabControl6.Controls.Add(this.tabPage3);
            this.hTabControl6.Controls.Add(this.tabPage28);
            this.hTabControl6.Controls.Add(this.tabPage29);
            this.hTabControl6.CursorTabPages = System.Windows.Forms.Cursors.Default;
            this.hTabControl6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hTabControl6.ItemSize = new System.Drawing.Size(137, 30);
            this.hTabControl6.Location = new System.Drawing.Point(5, 5);
            this.hTabControl6.Name = "hTabControl6";
            this.hTabControl6.SelectedIndex = 0;
            this.hTabControl6.SelectedTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hTabControl6.SelectedTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hTabControl6.Size = new System.Drawing.Size(736, 528);
            this.hTabControl6.TabIndex = 2;
            this.hTabControl6.TabsColor = System.Drawing.Color.White;
            this.hTabControl6.TabStyle = HeCopUI_Framework.Enums.TabStyle.Style2;
            this.hTabControl6.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.hTabControl6.TextPadding = new System.Windows.Forms.Padding(0);
            this.hTabControl6.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hTabControl6.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hTabControl6.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            this.hTabControl6.UnSelectedBorderTabColor = System.Drawing.Color.Silver;
            this.hTabControl6.UnSelectedTabColor = System.Drawing.Color.Transparent;
            this.hTabControl6.UnselectedTextColor = System.Drawing.Color.DimGray;
            this.hTabControl6.UseAnimation = true;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.White;
            this.tabPage3.Controls.Add(this.hStepIndicatorOne1);
            this.tabPage3.Controls.Add(this.hProgressRing2);
            this.tabPage3.Controls.Add(this.waveProgressLoading1);
            this.tabPage3.Controls.Add(this.hDotProgressRing8);
            this.tabPage3.Controls.Add(this.hDotProgressRing7);
            this.tabPage3.Controls.Add(this.hDotProgressRing6);
            this.tabPage3.Controls.Add(this.hDotProgressRing5);
            this.tabPage3.Controls.Add(this.hDotProgressRing4);
            this.tabPage3.Controls.Add(this.hDotProgressRing3);
            this.tabPage3.Controls.Add(this.hDotProgressRing2);
            this.tabPage3.Controls.Add(this.hDotProgressRing1);
            this.tabPage3.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage3.Location = new System.Drawing.Point(4, 34);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(728, 490);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Indicator & Loading";
            // 
            // hStepIndicatorOne1
            // 
            this.hStepIndicatorOne1.BGHeight = 5;
            this.hStepIndicatorOne1.IndicatorBarColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.hStepIndicatorOne1.IndicatorBarColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.hStepIndicatorOne1.IndicatorStepColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hStepIndicatorOne1.IndicatorStepColor2 = System.Drawing.Color.DodgerBlue;
            this.hStepIndicatorOne1.Location = new System.Drawing.Point(39, 378);
            this.hStepIndicatorOne1.Name = "hStepIndicatorOne1";
            this.hStepIndicatorOne1.RadiusBig = 20;
            this.hStepIndicatorOne1.RadiusSmall = 15;
            this.hStepIndicatorOne1.Size = new System.Drawing.Size(239, 65);
            this.hStepIndicatorOne1.Steps = 3;
            this.hStepIndicatorOne1.TabIndex = 27;
            this.hStepIndicatorOne1.Text = "hStepIndicatorOne1";
            this.hStepIndicatorOne1.Value = 2;
            // 
            // hProgressRing2
            // 
            this.hProgressRing2.Angle = -90;
            this.hProgressRing2.Duration = 50;
            this.hProgressRing2.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            this.hProgressRing2.ForegroundColor1 = System.Drawing.Color.SlateBlue;
            this.hProgressRing2.ForegroundColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hProgressRing2.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.hProgressRing2.Location = new System.Drawing.Point(542, 130);
            this.hProgressRing2.Name = "hProgressRing2";
            this.hProgressRing2.ScaleFactory = 70;
            this.hProgressRing2.Size = new System.Drawing.Size(97, 79);
            this.hProgressRing2.Speed = 1D;
            this.hProgressRing2.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            this.hProgressRing2.StepIncrement = 10;
            this.hProgressRing2.TabIndex = 26;
            this.hProgressRing2.Text = "hProgressRing2";
            this.hProgressRing2.Thickness = 5;
            // 
            // waveProgressLoading1
            // 
            this.waveProgressLoading1.BackColor = System.Drawing.Color.Transparent;
            this.waveProgressLoading1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(102)))));
            this.waveProgressLoading1.Location = new System.Drawing.Point(300, 130);
            this.waveProgressLoading1.MaxHeight = 60;
            this.waveProgressLoading1.Name = "waveProgressLoading1";
            this.waveProgressLoading1.Size = new System.Drawing.Size(168, 67);
            this.waveProgressLoading1.SpaceBetweenWave = 20;
            this.waveProgressLoading1.TabIndex = 25;
            this.waveProgressLoading1.Text = "waveProgressLoading1";
            this.waveProgressLoading1.WaveAnimationStyle = HeCopUI_Framework.Controls.Progress.WaveProgressLoading.AnimationStyle.Ascending;
            this.waveProgressLoading1.WaveCount = 5;
            this.waveProgressLoading1.WaveWidth = 10;
            // 
            // hDotProgressRing8
            // 
            this.hDotProgressRing8.DotColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(102)))));
            this.hDotProgressRing8.DotCount = 8;
            this.hDotProgressRing8.Interval = 50;
            this.hDotProgressRing8.Location = new System.Drawing.Point(521, 40);
            this.hDotProgressRing8.Name = "hDotProgressRing8";
            this.hDotProgressRing8.ProgressStyle = HeCopUI_Framework.Controls.Progress.HDotProgressRing.Style.Style8;
            this.hDotProgressRing8.Radius = 5;
            this.hDotProgressRing8.Size = new System.Drawing.Size(67, 67);
            this.hDotProgressRing8.StartAnimation = true;
            this.hDotProgressRing8.SupportTransparent = true;
            this.hDotProgressRing8.TabIndex = 24;
            this.hDotProgressRing8.Text = "hDotProgressRing8";
            // 
            // hDotProgressRing7
            // 
            this.hDotProgressRing7.DotColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(102)))));
            this.hDotProgressRing7.DotCount = 10;
            this.hDotProgressRing7.Interval = 50;
            this.hDotProgressRing7.Location = new System.Drawing.Point(197, 130);
            this.hDotProgressRing7.Name = "hDotProgressRing7";
            this.hDotProgressRing7.ProgressStyle = HeCopUI_Framework.Controls.Progress.HDotProgressRing.Style.Style5;
            this.hDotProgressRing7.Radius = 5;
            this.hDotProgressRing7.Size = new System.Drawing.Size(67, 67);
            this.hDotProgressRing7.StartAnimation = true;
            this.hDotProgressRing7.SupportTransparent = true;
            this.hDotProgressRing7.TabIndex = 23;
            this.hDotProgressRing7.Text = "hDotProgressRing7";
            // 
            // hDotProgressRing6
            // 
            this.hDotProgressRing6.DotColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(102)))));
            this.hDotProgressRing6.DotCount = 8;
            this.hDotProgressRing6.Interval = 50;
            this.hDotProgressRing6.Location = new System.Drawing.Point(39, 254);
            this.hDotProgressRing6.Name = "hDotProgressRing6";
            this.hDotProgressRing6.ProgressStyle = HeCopUI_Framework.Controls.Progress.HDotProgressRing.Style.Style6;
            this.hDotProgressRing6.Radius = 5;
            this.hDotProgressRing6.Size = new System.Drawing.Size(239, 31);
            this.hDotProgressRing6.StartAnimation = true;
            this.hDotProgressRing6.SupportTransparent = true;
            this.hDotProgressRing6.TabIndex = 22;
            this.hDotProgressRing6.Text = "hDotProgressRing6";
            // 
            // hDotProgressRing5
            // 
            this.hDotProgressRing5.DotColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(102)))));
            this.hDotProgressRing5.DotCount = 10;
            this.hDotProgressRing5.Interval = 50;
            this.hDotProgressRing5.Location = new System.Drawing.Point(39, 130);
            this.hDotProgressRing5.Name = "hDotProgressRing5";
            this.hDotProgressRing5.ProgressStyle = HeCopUI_Framework.Controls.Progress.HDotProgressRing.Style.Style7;
            this.hDotProgressRing5.Radius = 5;
            this.hDotProgressRing5.Size = new System.Drawing.Size(67, 67);
            this.hDotProgressRing5.StartAnimation = true;
            this.hDotProgressRing5.SupportTransparent = true;
            this.hDotProgressRing5.TabIndex = 21;
            this.hDotProgressRing5.Text = "hDotProgressRing5";
            // 
            // hDotProgressRing4
            // 
            this.hDotProgressRing4.DotColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(102)))));
            this.hDotProgressRing4.DotCount = 8;
            this.hDotProgressRing4.Interval = 50;
            this.hDotProgressRing4.Location = new System.Drawing.Point(401, 40);
            this.hDotProgressRing4.Name = "hDotProgressRing4";
            this.hDotProgressRing4.ProgressStyle = HeCopUI_Framework.Controls.Progress.HDotProgressRing.Style.Style4;
            this.hDotProgressRing4.Radius = 5;
            this.hDotProgressRing4.Size = new System.Drawing.Size(67, 67);
            this.hDotProgressRing4.StartAnimation = true;
            this.hDotProgressRing4.SupportTransparent = true;
            this.hDotProgressRing4.TabIndex = 7;
            this.hDotProgressRing4.Text = "hDotProgressRing4";
            // 
            // hDotProgressRing3
            // 
            this.hDotProgressRing3.DotColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(102)))));
            this.hDotProgressRing3.DotCount = 8;
            this.hDotProgressRing3.Interval = 50;
            this.hDotProgressRing3.Location = new System.Drawing.Point(277, 40);
            this.hDotProgressRing3.Name = "hDotProgressRing3";
            this.hDotProgressRing3.ProgressStyle = HeCopUI_Framework.Controls.Progress.HDotProgressRing.Style.Style3;
            this.hDotProgressRing3.Radius = 5;
            this.hDotProgressRing3.Size = new System.Drawing.Size(67, 67);
            this.hDotProgressRing3.StartAnimation = true;
            this.hDotProgressRing3.SupportTransparent = true;
            this.hDotProgressRing3.TabIndex = 6;
            this.hDotProgressRing3.Text = "hDotProgressRing3";
            // 
            // hDotProgressRing2
            // 
            this.hDotProgressRing2.DotColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(102)))));
            this.hDotProgressRing2.DotCount = 8;
            this.hDotProgressRing2.Interval = 50;
            this.hDotProgressRing2.Location = new System.Drawing.Point(161, 40);
            this.hDotProgressRing2.Name = "hDotProgressRing2";
            this.hDotProgressRing2.ProgressStyle = HeCopUI_Framework.Controls.Progress.HDotProgressRing.Style.Style2;
            this.hDotProgressRing2.Radius = 5;
            this.hDotProgressRing2.Size = new System.Drawing.Size(67, 67);
            this.hDotProgressRing2.StartAnimation = true;
            this.hDotProgressRing2.SupportTransparent = true;
            this.hDotProgressRing2.TabIndex = 5;
            this.hDotProgressRing2.Text = "hDotProgressRing2";
            // 
            // hDotProgressRing1
            // 
            this.hDotProgressRing1.DotColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(102)))));
            this.hDotProgressRing1.DotCount = 8;
            this.hDotProgressRing1.Interval = 50;
            this.hDotProgressRing1.Location = new System.Drawing.Point(39, 40);
            this.hDotProgressRing1.Name = "hDotProgressRing1";
            this.hDotProgressRing1.ProgressStyle = HeCopUI_Framework.Controls.Progress.HDotProgressRing.Style.Style1;
            this.hDotProgressRing1.Radius = 5;
            this.hDotProgressRing1.Size = new System.Drawing.Size(67, 67);
            this.hDotProgressRing1.StartAnimation = true;
            this.hDotProgressRing1.SupportTransparent = true;
            this.hDotProgressRing1.TabIndex = 4;
            this.hDotProgressRing1.Text = "hDotProgressRing1";
            // 
            // tabPage28
            // 
            this.tabPage28.BackColor = System.Drawing.Color.White;
            this.tabPage28.Controls.Add(this.hCircularProgressBar2);
            this.tabPage28.Controls.Add(this.hCircularProgressBar21);
            this.tabPage28.Controls.Add(this.hCircularProgressBar11);
            this.tabPage28.Controls.Add(this.hCircularProgressBar1);
            this.tabPage28.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage28.Location = new System.Drawing.Point(4, 34);
            this.tabPage28.Name = "tabPage28";
            this.tabPage28.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage28.Size = new System.Drawing.Size(728, 490);
            this.tabPage28.TabIndex = 1;
            this.tabPage28.Text = "Circular Progress Bar";
            // 
            // hCircularProgressBar2
            // 
            this.hCircularProgressBar2.AnimationMode = HeCopUI_Framework.Controls.Progress.HCircularProgressBar.AnimationType.Indicator;
            this.hCircularProgressBar2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hCircularProgressBar2.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.hCircularProgressBar2.InnerMargin = 2;
            this.hCircularProgressBar2.InnerWidth = -1;
            this.hCircularProgressBar2.Interval = 50;
            this.hCircularProgressBar2.Location = new System.Drawing.Point(58, 86);
            this.hCircularProgressBar2.Maximum = 100;
            this.hCircularProgressBar2.Minimum = 0;
            this.hCircularProgressBar2.Name = "hCircularProgressBar2";
            this.hCircularProgressBar2.OuterColor = System.Drawing.Color.White;
            this.hCircularProgressBar2.OuterMargin = -10;
            this.hCircularProgressBar2.OuterWidth = 10;
            this.hCircularProgressBar2.ProgressBarValue = 40;
            this.hCircularProgressBar2.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hCircularProgressBar2.ProgressTextMode = HeCopUI_Framework.Controls.Progress.HCircularProgressBar.TextMode.Percentage;
            this.hCircularProgressBar2.ProgressWidth = 10;
            this.hCircularProgressBar2.Size = new System.Drawing.Size(109, 109);
            this.hCircularProgressBar2.TabIndex = 28;
            this.hCircularProgressBar2.Text = "hCircularProgressBar2";
            this.hCircularProgressBar2.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.hCircularProgressBar2.TextRenderHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.hCircularProgressBar2.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // hCircularProgressBar21
            // 
            this.hCircularProgressBar21.BackColor = System.Drawing.Color.White;
            this.hCircularProgressBar21.BarColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hCircularProgressBar21.BarColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hCircularProgressBar21.BarWidth = 6F;
            this.hCircularProgressBar21.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.hCircularProgressBar21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.hCircularProgressBar21.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.hCircularProgressBar21.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.hCircularProgressBar21.LineWidth = 1;
            this.hCircularProgressBar21.Location = new System.Drawing.Point(359, 86);
            this.hCircularProgressBar21.Maximum = ((long)(100));
            this.hCircularProgressBar21.MinimumSize = new System.Drawing.Size(100, 100);
            this.hCircularProgressBar21.Name = "hCircularProgressBar21";
            this.hCircularProgressBar21.ProgressShape = HeCopUI_Framework.Controls.Progress.HCircularProgressBar2.ProgressShapeType.Flat;
            this.hCircularProgressBar21.Size = new System.Drawing.Size(109, 109);
            this.hCircularProgressBar21.TabIndex = 26;
            this.hCircularProgressBar21.Text = "57%";
            this.hCircularProgressBar21.TextMode = HeCopUI_Framework.Controls.Progress.HCircularProgressBar2.TextModeVisible.Percentage;
            this.hCircularProgressBar21.Value = ((long)(57));
            // 
            // hCircularProgressBar11
            // 
            this.hCircularProgressBar11.BackColor = System.Drawing.Color.Transparent;
            this.hCircularProgressBar11.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.hCircularProgressBar11.BaseColor2 = System.Drawing.Color.White;
            this.hCircularProgressBar11.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.hCircularProgressBar11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.hCircularProgressBar11.Location = new System.Drawing.Point(58, 247);
            this.hCircularProgressBar11.Maximum = ((long)(100));
            this.hCircularProgressBar11.MinimumSize = new System.Drawing.Size(100, 100);
            this.hCircularProgressBar11.Name = "hCircularProgressBar11";
            this.hCircularProgressBar11.ProgressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hCircularProgressBar11.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hCircularProgressBar11.ProgressShape = HeCopUI_Framework.Controls.Progress.HCircularProgressBar1._ProgressShape.Round;
            this.hCircularProgressBar11.ProgressThickness = 8F;
            this.hCircularProgressBar11.ProgresTextType = HeCopUI_Framework.Controls.Progress.HCircularProgressBar1.TextType.Percentage;
            this.hCircularProgressBar11.Size = new System.Drawing.Size(109, 109);
            this.hCircularProgressBar11.TabIndex = 25;
            this.hCircularProgressBar11.Text = "hCircularProgressBar11";
            this.hCircularProgressBar11.TextRenderHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.hCircularProgressBar11.Value = ((long)(21));
            // 
            // hCircularProgressBar1
            // 
            this.hCircularProgressBar1.AnimationMode = HeCopUI_Framework.Controls.Progress.HCircularProgressBar.AnimationType.None;
            this.hCircularProgressBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hCircularProgressBar1.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.hCircularProgressBar1.InnerMargin = 2;
            this.hCircularProgressBar1.InnerWidth = -1;
            this.hCircularProgressBar1.Interval = 50;
            this.hCircularProgressBar1.Location = new System.Drawing.Point(219, 86);
            this.hCircularProgressBar1.Maximum = 100;
            this.hCircularProgressBar1.Minimum = 0;
            this.hCircularProgressBar1.Name = "hCircularProgressBar1";
            this.hCircularProgressBar1.OuterColor = System.Drawing.Color.White;
            this.hCircularProgressBar1.OuterMargin = -10;
            this.hCircularProgressBar1.OuterWidth = 10;
            this.hCircularProgressBar1.ProgressBarValue = 10;
            this.hCircularProgressBar1.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hCircularProgressBar1.ProgressTextMode = HeCopUI_Framework.Controls.Progress.HCircularProgressBar.TextMode.Percentage;
            this.hCircularProgressBar1.ProgressWidth = 10;
            this.hCircularProgressBar1.Size = new System.Drawing.Size(109, 109);
            this.hCircularProgressBar1.TabIndex = 24;
            this.hCircularProgressBar1.Text = "hCircularProgressBar1";
            this.hCircularProgressBar1.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.hCircularProgressBar1.TextRenderHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.hCircularProgressBar1.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // tabPage29
            // 
            this.tabPage29.BackColor = System.Drawing.Color.White;
            this.tabPage29.Controls.Add(this.hButton10);
            this.tabPage29.Controls.Add(this.hProgressBar4);
            this.tabPage29.Controls.Add(this.hProgressBar5);
            this.tabPage29.Controls.Add(this.hProgressBar6);
            this.tabPage29.Controls.Add(this.hProgressBar3);
            this.tabPage29.Controls.Add(this.hProgressBar2);
            this.tabPage29.Controls.Add(this.hProgressBar1);
            this.tabPage29.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage29.Location = new System.Drawing.Point(4, 34);
            this.tabPage29.Name = "tabPage29";
            this.tabPage29.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage29.Size = new System.Drawing.Size(728, 490);
            this.tabPage29.TabIndex = 2;
            this.tabPage29.Text = "Rectangle Progress Bar";
            // 
            // hButton10
            // 
            this.hButton10.AnimationMode = HeCopUI_Framework.Enums.AnimationMode.None;
            this.hButton10.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hButton10.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hButton10.BorderPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hButton10.BorderThickness = 1;
            this.hButton10.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hButton10.ClipRegion = false;
            this.hButton10.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.hButton10.DialogResult = System.Windows.Forms.DialogResult.None;
            this.hButton10.FocusBorderColor = System.Drawing.Color.White;
            this.hButton10.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.hButton10.HoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.hButton10.HoverColor2 = System.Drawing.Color.White;
            this.hButton10.Image = null;
            this.hButton10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.hButton10.ImagePadding = new System.Windows.Forms.Padding(0);
            this.hButton10.ImageSize = new System.Drawing.Size(20, 20);
            this.hButton10.Location = new System.Drawing.Point(479, 373);
            this.hButton10.Name = "hButton10";
            this.hButton10.NormalColor1 = System.Drawing.Color.White;
            this.hButton10.NormalColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.hButton10.PressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.hButton10.PressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.hButton10.RippleColor = System.Drawing.Color.Black;
            this.hButton10.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.hButton10.ShadowPadding = new System.Windows.Forms.Padding(0);
            this.hButton10.ShadowRadius = 5;
            this.hButton10.ShapeButtonType = HeCopUI_Framework.Enums.ShapeType.RoundedRectangle;
            this.hButton10.Size = new System.Drawing.Size(75, 29);
            this.hButton10.SupportImageGif = false;
            this.hButton10.TabIndex = 22;
            this.hButton10.Text = "Random";
            this.hButton10.TextHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hButton10.TextNormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hButton10.TextPadding = new System.Windows.Forms.Padding(0);
            this.hButton10.TextPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hButton10.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hButton10.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            this.hButton10.MouseClick += new System.Windows.Forms.MouseEventHandler(this.hButton10_MouseClick);
            // 
            // hProgressBar4
            // 
            this.hProgressBar4.AnimationMode = HeCopUI_Framework.Enums.ProgressAnimationMode.None;
            this.hProgressBar4.BaseProgressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.hProgressBar4.BaseProgressColor2 = System.Drawing.Color.White;
            this.hProgressBar4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.hProgressBar4.BorderWidth = 1;
            this.hProgressBar4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hProgressBar4.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.hProgressBar4.Location = new System.Drawing.Point(128, 126);
            this.hProgressBar4.MaximumValue = 100;
            this.hProgressBar4.MinimumValue = 0;
            this.hProgressBar4.Name = "hProgressBar4";
            this.hProgressBar4.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.hProgressBar4.ProgressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(102)))));
            this.hProgressBar4.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(122)))));
            this.hProgressBar4.ProgressValue = 32;
            this.hProgressBar4.Size = new System.Drawing.Size(15, 297);
            this.hProgressBar4.TabIndex = 21;
            this.hProgressBar4.Text = "hProgressBar4";
            // 
            // hProgressBar5
            // 
            this.hProgressBar5.AnimationMode = HeCopUI_Framework.Enums.ProgressAnimationMode.Value;
            this.hProgressBar5.BaseProgressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.hProgressBar5.BaseProgressColor2 = System.Drawing.Color.White;
            this.hProgressBar5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.hProgressBar5.BorderWidth = 1;
            this.hProgressBar5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hProgressBar5.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.hProgressBar5.Location = new System.Drawing.Point(89, 126);
            this.hProgressBar5.MaximumValue = 100;
            this.hProgressBar5.MinimumValue = 0;
            this.hProgressBar5.Name = "hProgressBar5";
            this.hProgressBar5.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.hProgressBar5.ProgressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(102)))));
            this.hProgressBar5.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(122)))));
            this.hProgressBar5.ProgressValue = 32;
            this.hProgressBar5.Size = new System.Drawing.Size(15, 297);
            this.hProgressBar5.TabIndex = 20;
            this.hProgressBar5.Text = "hProgressBar5";
            // 
            // hProgressBar6
            // 
            this.hProgressBar6.AnimationMode = HeCopUI_Framework.Enums.ProgressAnimationMode.Indeterminate;
            this.hProgressBar6.BaseProgressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.hProgressBar6.BaseProgressColor2 = System.Drawing.Color.White;
            this.hProgressBar6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.hProgressBar6.BorderWidth = 1;
            this.hProgressBar6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hProgressBar6.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.hProgressBar6.Location = new System.Drawing.Point(50, 126);
            this.hProgressBar6.MaximumValue = 100;
            this.hProgressBar6.MinimumValue = 0;
            this.hProgressBar6.Name = "hProgressBar6";
            this.hProgressBar6.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.hProgressBar6.ProgressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(102)))));
            this.hProgressBar6.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(122)))));
            this.hProgressBar6.ProgressValue = 32;
            this.hProgressBar6.Size = new System.Drawing.Size(15, 297);
            this.hProgressBar6.TabIndex = 19;
            this.hProgressBar6.Text = "hProgressBar6";
            // 
            // hProgressBar3
            // 
            this.hProgressBar3.AnimationMode = HeCopUI_Framework.Enums.ProgressAnimationMode.None;
            this.hProgressBar3.BaseProgressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.hProgressBar3.BaseProgressColor2 = System.Drawing.Color.White;
            this.hProgressBar3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.hProgressBar3.BorderWidth = 1;
            this.hProgressBar3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hProgressBar3.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.hProgressBar3.Location = new System.Drawing.Point(50, 93);
            this.hProgressBar3.MaximumValue = 100;
            this.hProgressBar3.MinimumValue = 0;
            this.hProgressBar3.Name = "hProgressBar3";
            this.hProgressBar3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.hProgressBar3.ProgressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(102)))));
            this.hProgressBar3.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(122)))));
            this.hProgressBar3.ProgressValue = 32;
            this.hProgressBar3.Size = new System.Drawing.Size(541, 15);
            this.hProgressBar3.TabIndex = 17;
            this.hProgressBar3.Text = "hProgressBar3";
            // 
            // hProgressBar2
            // 
            this.hProgressBar2.AnimationMode = HeCopUI_Framework.Enums.ProgressAnimationMode.Value;
            this.hProgressBar2.BaseProgressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.hProgressBar2.BaseProgressColor2 = System.Drawing.Color.White;
            this.hProgressBar2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.hProgressBar2.BorderWidth = 1;
            this.hProgressBar2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hProgressBar2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.hProgressBar2.Location = new System.Drawing.Point(50, 69);
            this.hProgressBar2.MaximumValue = 100;
            this.hProgressBar2.MinimumValue = 0;
            this.hProgressBar2.Name = "hProgressBar2";
            this.hProgressBar2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.hProgressBar2.ProgressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(102)))));
            this.hProgressBar2.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(122)))));
            this.hProgressBar2.ProgressValue = 32;
            this.hProgressBar2.Size = new System.Drawing.Size(541, 15);
            this.hProgressBar2.TabIndex = 16;
            this.hProgressBar2.Text = "hProgressBar2";
            // 
            // hProgressBar1
            // 
            this.hProgressBar1.AnimationMode = HeCopUI_Framework.Enums.ProgressAnimationMode.Indeterminate;
            this.hProgressBar1.BaseProgressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.hProgressBar1.BaseProgressColor2 = System.Drawing.Color.White;
            this.hProgressBar1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.hProgressBar1.BorderWidth = 1;
            this.hProgressBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hProgressBar1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.hProgressBar1.Location = new System.Drawing.Point(50, 45);
            this.hProgressBar1.MaximumValue = 100;
            this.hProgressBar1.MinimumValue = 0;
            this.hProgressBar1.Name = "hProgressBar1";
            this.hProgressBar1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.hProgressBar1.ProgressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(102)))));
            this.hProgressBar1.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(122)))));
            this.hProgressBar1.ProgressValue = 32;
            this.hProgressBar1.Size = new System.Drawing.Size(541, 15);
            this.hProgressBar1.TabIndex = 15;
            this.hProgressBar1.Text = "hProgressBar1";
            // 
            // tabPage9
            // 
            this.tabPage9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.tabPage9.Controls.Add(this.hTabControl9);
            this.tabPage9.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage9.Location = new System.Drawing.Point(139, 4);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage9.Size = new System.Drawing.Size(746, 538);
            this.tabPage9.TabIndex = 18;
            this.tabPage9.Text = "Slider";
            // 
            // hTabControl9
            // 
            this.hTabControl9.ApplyTabPagesColor = true;
            this.hTabControl9.BackgroundColor = System.Drawing.Color.Transparent;
            this.hTabControl9.BorderTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hTabControl9.BorderThickness = 1;
            this.hTabControl9.Controls.Add(this.tabPage20);
            this.hTabControl9.Controls.Add(this.tabPage34);
            this.hTabControl9.Controls.Add(this.tabPage19);
            this.hTabControl9.CursorTabPages = System.Windows.Forms.Cursors.Default;
            this.hTabControl9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hTabControl9.ItemSize = new System.Drawing.Size(96, 30);
            this.hTabControl9.Location = new System.Drawing.Point(3, 3);
            this.hTabControl9.Name = "hTabControl9";
            this.hTabControl9.SelectedIndex = 0;
            this.hTabControl9.SelectedTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hTabControl9.SelectedTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hTabControl9.Size = new System.Drawing.Size(740, 532);
            this.hTabControl9.TabIndex = 8;
            this.hTabControl9.TabsColor = System.Drawing.Color.White;
            this.hTabControl9.TabStyle = HeCopUI_Framework.Enums.TabStyle.Style2;
            this.hTabControl9.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.hTabControl9.TextPadding = new System.Windows.Forms.Padding(0);
            this.hTabControl9.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hTabControl9.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hTabControl9.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            this.hTabControl9.UnSelectedBorderTabColor = System.Drawing.Color.Silver;
            this.hTabControl9.UnSelectedTabColor = System.Drawing.Color.Transparent;
            this.hTabControl9.UnselectedTextColor = System.Drawing.Color.DimGray;
            this.hTabControl9.UseAnimation = false;
            // 
            // tabPage20
            // 
            this.tabPage20.BackColor = System.Drawing.Color.White;
            this.tabPage20.Controls.Add(this.hhTrackBar1);
            this.tabPage20.Controls.Add(this.hCircleAnglePicker1);
            this.tabPage20.Controls.Add(this.hRadialRangeSlider1);
            this.tabPage20.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage20.Location = new System.Drawing.Point(4, 34);
            this.tabPage20.Name = "tabPage20";
            this.tabPage20.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage20.Size = new System.Drawing.Size(732, 494);
            this.tabPage20.TabIndex = 0;
            this.tabPage20.Text = "Range Slider";
            // 
            // hhTrackBar1
            // 
            this.hhTrackBar1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.hhTrackBar1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hhTrackBar1.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.hhTrackBar1.DisabledBorderColor = System.Drawing.Color.Empty;
            this.hhTrackBar1.DisabledHandlerColor = System.Drawing.Color.Empty;
            this.hhTrackBar1.DisabledValueColor = System.Drawing.Color.Empty;
            this.hhTrackBar1.HandlerColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(128)))));
            this.hhTrackBar1.IsDerivedStyle = true;
            this.hhTrackBar1.Location = new System.Drawing.Point(81, 296);
            this.hhTrackBar1.Maximum = 100;
            this.hhTrackBar1.Minimum = 0;
            this.hhTrackBar1.Name = "hhTrackBar1";
            this.hhTrackBar1.Size = new System.Drawing.Size(197, 38);
            this.hhTrackBar1.TabIndex = 20;
            this.hhTrackBar1.Text = "hhTrackBar2";
            this.hhTrackBar1.Value = 0;
            this.hhTrackBar1.ValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            // 
            // hCircleAnglePicker1
            // 
            this.hCircleAnglePicker1.AutoScroll = false;
            this.hCircleAnglePicker1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.hCircleAnglePicker1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.hCircleAnglePicker1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.hCircleAnglePicker1.CircleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.hCircleAnglePicker1.CircleColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(128)))));
            this.hCircleAnglePicker1.CoreColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(128)))));
            this.hCircleAnglePicker1.CoreType = HeCopUI_Framework.Enums.CircleAnglePickerType.Ellipse;
            this.hCircleAnglePicker1.CoreWidth = 20;
            this.hCircleAnglePicker1.InnerCircle = true;
            this.hCircleAnglePicker1.InnerCircleColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.hCircleAnglePicker1.LineCap = System.Drawing.Drawing2D.LineCap.DiamondAnchor;
            this.hCircleAnglePicker1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.hCircleAnglePicker1.LineCut = 12;
            this.hCircleAnglePicker1.LineWidth = 2;
            this.hCircleAnglePicker1.Location = new System.Drawing.Point(241, 52);
            this.hCircleAnglePicker1.Name = "hCircleAnglePicker1";
            this.hCircleAnglePicker1.Size = new System.Drawing.Size(127, 127);
            this.hCircleAnglePicker1.TabIndex = 18;
            this.hCircleAnglePicker1.Text = "hCircleAnglePicker2";
            this.hCircleAnglePicker1.ValueChanged += new System.EventHandler(this.hCircleAnglePicker1_ValueChanged);
            // 
            // hRadialRangeSlider1
            // 
            this.hRadialRangeSlider1.BarColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.hRadialRangeSlider1.BarColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(128)))));
            this.hRadialRangeSlider1.BarThickness = 2;
            this.hRadialRangeSlider1.EndAngle = 265;
            this.hRadialRangeSlider1.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.hRadialRangeSlider1.Location = new System.Drawing.Point(31, 62);
            this.hRadialRangeSlider1.MaxValue = 100;
            this.hRadialRangeSlider1.MinValue = 0;
            this.hRadialRangeSlider1.Name = "hRadialRangeSlider1";
            this.hRadialRangeSlider1.Size = new System.Drawing.Size(136, 139);
            this.hRadialRangeSlider1.SlideColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hRadialRangeSlider1.SlideColor2 = System.Drawing.Color.SeaGreen;
            this.hRadialRangeSlider1.SliderScale = 90;
            this.hRadialRangeSlider1.SlideThickness = 4;
            this.hRadialRangeSlider1.StartAngle = 137;
            this.hRadialRangeSlider1.TabIndex = 17;
            this.hRadialRangeSlider1.Text = "hRadialRangeSlider2";
            this.hRadialRangeSlider1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hRadialRangeSlider1.TextMode = HeCopUI_Framework.Controls.TextMode.FromValue1ToValue2;
            this.hRadialRangeSlider1.ThumbEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hRadialRangeSlider1.ThumbStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.hRadialRangeSlider1.Value1 = 30;
            this.hRadialRangeSlider1.Value2 = 80;
            // 
            // tabPage34
            // 
            this.tabPage34.BackColor = System.Drawing.Color.White;
            this.tabPage34.Controls.Add(this.hSolidGauge2);
            this.tabPage34.Controls.Add(this.hDigitalGauge2);
            this.tabPage34.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage34.Location = new System.Drawing.Point(4, 34);
            this.tabPage34.Name = "tabPage34";
            this.tabPage34.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage34.Size = new System.Drawing.Size(732, 494);
            this.tabPage34.TabIndex = 1;
            this.tabPage34.Text = "Knob";
            // 
            // hSolidGauge2
            // 
            this.hSolidGauge2.BackColor = System.Drawing.Color.Transparent;
            this.hSolidGauge2.BaseGauge = System.Drawing.Color.Gainsboro;
            this.hSolidGauge2.CircularDiskColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.hSolidGauge2.CircularDiskSizeType = HeCopUI_Framework.Controls.Gauge.HSolidGauge.DiskSizeMode.Auto;
            this.hSolidGauge2.CircularSize = 20;
            this.hSolidGauge2.GaugeColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hSolidGauge2.GaugeColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hSolidGauge2.GaugeMode = HeCopUI_Framework.Controls.Gauge.HSolidGauge.GaugeType.Gradient;
            this.hSolidGauge2.GaugeTextType = HeCopUI_Framework.Controls.Gauge.HSolidGauge.TextType.Percentage;
            this.hSolidGauge2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.hSolidGauge2.Interval = 10;
            this.hSolidGauge2.Location = new System.Drawing.Point(346, 81);
            this.hSolidGauge2.MaximumValue = 100;
            this.hSolidGauge2.Name = "hSolidGauge2";
            this.hSolidGauge2.NeedleColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hSolidGauge2.NeedleHeight = HeCopUI_Framework.Controls.Gauge.HSolidGauge.NeedleLongType.Auto;
            this.hSolidGauge2.NeedleLong = 50;
            this.hSolidGauge2.NeedleThickness = 2;
            this.hSolidGauge2.NeedleType = System.Drawing.Drawing2D.LineCap.Flat;
            this.hSolidGauge2.NumberOfOYVissible = 10;
            this.hSolidGauge2.ShapeType = System.Drawing.Drawing2D.LineCap.Round;
            this.hSolidGauge2.ShowMajor = true;
            this.hSolidGauge2.Size = new System.Drawing.Size(165, 165);
            this.hSolidGauge2.SolidGaugeWidth = 12;
            this.hSolidGauge2.TabIndex = 10;
            this.hSolidGauge2.Text = "hSolidGauge2";
            this.hSolidGauge2.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hSolidGauge2.UseAnimation = false;
            this.hSolidGauge2.Value = 0;
            this.hSolidGauge2.ValueTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            // 
            // hDigitalGauge2
            // 
            this.hDigitalGauge2.BackColor = System.Drawing.Color.Transparent;
            this.hDigitalGauge2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.hDigitalGauge2.BorderThickness = 2;
            this.hDigitalGauge2.GaugeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.hDigitalGauge2.Location = new System.Drawing.Point(70, 81);
            this.hDigitalGauge2.MaximumValue = 1000;
            this.hDigitalGauge2.MinimumValue = 0;
            this.hDigitalGauge2.Name = "hDigitalGauge2";
            this.hDigitalGauge2.NumberBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(30)))), ((int)(((byte)(148)))), ((int)(((byte)(128)))));
            this.hDigitalGauge2.NumberColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(128)))));
            this.hDigitalGauge2.NumberHeight = 20F;
            this.hDigitalGauge2.Radius = 0;
            this.hDigitalGauge2.Size = new System.Drawing.Size(168, 94);
            this.hDigitalGauge2.TabIndex = 9;
            this.hDigitalGauge2.Text = "hDigitalGauge2";
            this.hDigitalGauge2.Value = 0;
            // 
            // tabPage19
            // 
            this.tabPage19.BackColor = System.Drawing.Color.White;
            this.tabPage19.Controls.Add(this.hScrollBar3);
            this.tabPage19.Controls.Add(this.hScrollBar4);
            this.tabPage19.Controls.Add(this.hScrollBar2);
            this.tabPage19.Controls.Add(this.hScrollBar1);
            this.tabPage19.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage19.Location = new System.Drawing.Point(4, 34);
            this.tabPage19.Name = "tabPage19";
            this.tabPage19.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage19.Size = new System.Drawing.Size(732, 494);
            this.tabPage19.TabIndex = 2;
            this.tabPage19.Text = "Scroll Bars";
            // 
            // hScrollBar3
            // 
            this.hScrollBar3.BackColor = System.Drawing.Color.Transparent;
            this.hScrollBar3.BarColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.hScrollBar3.LargeChange = 10;
            this.hScrollBar3.Location = new System.Drawing.Point(468, 236);
            this.hScrollBar3.Maximum = 100;
            this.hScrollBar3.Minimum = 0;
            this.hScrollBar3.Name = "hScrollBar3";
            this.hScrollBar3.Size = new System.Drawing.Size(200, 10);
            this.hScrollBar3.SmallChange = 1;
            this.hScrollBar3.TabIndex = 8;
            this.hScrollBar3.Text = "hScrollBar3";
            this.hScrollBar3.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(122)))));
            this.hScrollBar3.ThumbPadding = new System.Windows.Forms.Padding(0);
            this.hScrollBar3.Value = 0;
            // 
            // hScrollBar4
            // 
            this.hScrollBar4.BackColor = System.Drawing.Color.Transparent;
            this.hScrollBar4.BarColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.hScrollBar4.LargeChange = 20;
            this.hScrollBar4.Location = new System.Drawing.Point(403, 134);
            this.hScrollBar4.Maximum = 100;
            this.hScrollBar4.Minimum = 0;
            this.hScrollBar4.Name = "hScrollBar4";
            this.hScrollBar4.Size = new System.Drawing.Size(13, 243);
            this.hScrollBar4.SmallChange = 1;
            this.hScrollBar4.TabIndex = 7;
            this.hScrollBar4.Text = "hScrollBar4";
            this.hScrollBar4.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(122)))));
            this.hScrollBar4.ThumbPadding = new System.Windows.Forms.Padding(0);
            this.hScrollBar4.Value = 0;
            // 
            // hScrollBar2
            // 
            this.hScrollBar2.BackColor = System.Drawing.Color.Transparent;
            this.hScrollBar2.BarColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.hScrollBar2.LargeChange = 10;
            this.hScrollBar2.Location = new System.Drawing.Point(139, 236);
            this.hScrollBar2.Maximum = 100;
            this.hScrollBar2.Minimum = 0;
            this.hScrollBar2.Name = "hScrollBar2";
            this.hScrollBar2.Size = new System.Drawing.Size(200, 10);
            this.hScrollBar2.SmallChange = 1;
            this.hScrollBar2.TabIndex = 6;
            this.hScrollBar2.Text = "hScrollBar2";
            this.hScrollBar2.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(122)))));
            this.hScrollBar2.ThumbPadding = new System.Windows.Forms.Padding(0);
            this.hScrollBar2.Value = 0;
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.BackColor = System.Drawing.Color.Transparent;
            this.hScrollBar1.BarColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.hScrollBar1.LargeChange = 10;
            this.hScrollBar1.Location = new System.Drawing.Point(74, 134);
            this.hScrollBar1.Maximum = 100;
            this.hScrollBar1.Minimum = 0;
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(10, 200);
            this.hScrollBar1.SmallChange = 1;
            this.hScrollBar1.TabIndex = 5;
            this.hScrollBar1.Text = "hScrollBar1";
            this.hScrollBar1.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(122)))));
            this.hScrollBar1.ThumbPadding = new System.Windows.Forms.Padding(0);
            this.hScrollBar1.Value = 0;
            // 
            // tabPage8
            // 
            this.tabPage8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.tabPage8.Controls.Add(this.hTabControl8);
            this.tabPage8.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage8.Location = new System.Drawing.Point(139, 4);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(5);
            this.tabPage8.Size = new System.Drawing.Size(746, 538);
            this.tabPage8.TabIndex = 7;
            this.tabPage8.Text = "Container controls";
            // 
            // hTabControl8
            // 
            this.hTabControl8.ApplyTabPagesColor = true;
            this.hTabControl8.BackgroundColor = System.Drawing.Color.Transparent;
            this.hTabControl8.BorderTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hTabControl8.BorderThickness = 1;
            this.hTabControl8.Controls.Add(this.tabPage32);
            this.hTabControl8.Controls.Add(this.tabPage33);
            this.hTabControl8.CursorTabPages = System.Windows.Forms.Cursors.Default;
            this.hTabControl8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hTabControl8.ItemSize = new System.Drawing.Size(54, 30);
            this.hTabControl8.Location = new System.Drawing.Point(5, 5);
            this.hTabControl8.Name = "hTabControl8";
            this.hTabControl8.SelectedIndex = 0;
            this.hTabControl8.SelectedTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hTabControl8.SelectedTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hTabControl8.Size = new System.Drawing.Size(736, 528);
            this.hTabControl8.TabIndex = 1;
            this.hTabControl8.TabsColor = System.Drawing.Color.White;
            this.hTabControl8.TabStyle = HeCopUI_Framework.Enums.TabStyle.Style2;
            this.hTabControl8.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.hTabControl8.TextPadding = new System.Windows.Forms.Padding(0);
            this.hTabControl8.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hTabControl8.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hTabControl8.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            this.hTabControl8.UnSelectedBorderTabColor = System.Drawing.Color.Silver;
            this.hTabControl8.UnSelectedTabColor = System.Drawing.Color.Transparent;
            this.hTabControl8.UnselectedTextColor = System.Drawing.Color.DimGray;
            this.hTabControl8.UseAnimation = false;
            // 
            // tabPage32
            // 
            this.tabPage32.BackColor = System.Drawing.Color.White;
            this.tabPage32.Controls.Add(this.HPanel1);
            this.tabPage32.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage32.Location = new System.Drawing.Point(4, 34);
            this.tabPage32.Name = "tabPage32";
            this.tabPage32.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage32.Size = new System.Drawing.Size(728, 490);
            this.tabPage32.TabIndex = 0;
            this.tabPage32.Text = "Panel";
            // 
            // HPanel1
            // 
            this.HPanel1.BackColor = System.Drawing.Color.Transparent;
            this.HPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(128)))));
            this.HPanel1.BorderThickness = 1;
            this.HPanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.HPanel1.Location = new System.Drawing.Point(83, 41);
            this.HPanel1.Name = "HPanel1";
            this.HPanel1.PanelColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(128)))));
            this.HPanel1.PanelColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(128)))));
            this.HPanel1.RoundBottomLeft = true;
            this.HPanel1.RoundBottomRight = true;
            this.HPanel1.RoundTopLeft = true;
            this.HPanel1.RoundTopRight = true;
            this.HPanel1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.HPanel1.ShadowPadding = new System.Windows.Forms.Padding(5, 4, 5, 8);
            this.HPanel1.ShadowRadius = 5;
            this.HPanel1.Size = new System.Drawing.Size(572, 424);
            this.HPanel1.TabIndex = 2;
            // 
            // tabPage33
            // 
            this.tabPage33.BackColor = System.Drawing.Color.White;
            this.tabPage33.Controls.Add(this.hTabControl3);
            this.tabPage33.Controls.Add(this.hTabControl2);
            this.tabPage33.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage33.Location = new System.Drawing.Point(4, 34);
            this.tabPage33.Name = "tabPage33";
            this.tabPage33.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage33.Size = new System.Drawing.Size(728, 490);
            this.tabPage33.TabIndex = 1;
            this.tabPage33.Text = "TabControl";
            // 
            // hTabControl3
            // 
            this.hTabControl3.ApplyTabPagesColor = true;
            this.hTabControl3.BackgroundColor = System.Drawing.Color.Transparent;
            this.hTabControl3.BorderTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hTabControl3.BorderThickness = 1;
            this.hTabControl3.Controls.Add(this.tabPage12);
            this.hTabControl3.Controls.Add(this.tabPage13);
            this.hTabControl3.CursorTabPages = System.Windows.Forms.Cursors.Default;
            this.hTabControl3.Location = new System.Drawing.Point(379, 31);
            this.hTabControl3.Name = "hTabControl3";
            this.hTabControl3.SelectedIndex = 0;
            this.hTabControl3.SelectedTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hTabControl3.SelectedTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hTabControl3.Size = new System.Drawing.Size(340, 444);
            this.hTabControl3.TabIndex = 3;
            this.hTabControl3.TabsColor = System.Drawing.Color.White;
            this.hTabControl3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.hTabControl3.TextPadding = new System.Windows.Forms.Padding(0);
            this.hTabControl3.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hTabControl3.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hTabControl3.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            this.hTabControl3.UnSelectedBorderTabColor = System.Drawing.Color.Silver;
            this.hTabControl3.UnSelectedTabColor = System.Drawing.Color.Transparent;
            this.hTabControl3.UnselectedTextColor = System.Drawing.Color.DimGray;
            this.hTabControl3.UseAnimation = false;
            // 
            // tabPage12
            // 
            this.tabPage12.BackColor = System.Drawing.Color.White;
            this.tabPage12.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage12.Location = new System.Drawing.Point(4, 25);
            this.tabPage12.Name = "tabPage12";
            this.tabPage12.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage12.Size = new System.Drawing.Size(332, 415);
            this.tabPage12.TabIndex = 0;
            this.tabPage12.Text = "Tab 1";
            // 
            // tabPage13
            // 
            this.tabPage13.BackColor = System.Drawing.Color.White;
            this.tabPage13.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage13.Location = new System.Drawing.Point(4, 25);
            this.tabPage13.Name = "tabPage13";
            this.tabPage13.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage13.Size = new System.Drawing.Size(332, 415);
            this.tabPage13.TabIndex = 1;
            this.tabPage13.Text = "Tab 2";
            // 
            // hTabControl2
            // 
            this.hTabControl2.ApplyTabPagesColor = true;
            this.hTabControl2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.hTabControl2.BorderTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hTabControl2.BorderThickness = 1;
            this.hTabControl2.Controls.Add(this.tabPage10);
            this.hTabControl2.Controls.Add(this.tabPage11);
            this.hTabControl2.CursorTabPages = System.Windows.Forms.Cursors.Default;
            this.hTabControl2.Location = new System.Drawing.Point(20, 31);
            this.hTabControl2.Name = "hTabControl2";
            this.hTabControl2.SelectedIndex = 0;
            this.hTabControl2.SelectedTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hTabControl2.SelectedTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hTabControl2.Size = new System.Drawing.Size(340, 444);
            this.hTabControl2.TabIndex = 2;
            this.hTabControl2.TabsColor = System.Drawing.Color.White;
            this.hTabControl2.TabStyle = HeCopUI_Framework.Enums.TabStyle.Style2;
            this.hTabControl2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.hTabControl2.TextPadding = new System.Windows.Forms.Padding(0);
            this.hTabControl2.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hTabControl2.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hTabControl2.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            this.hTabControl2.UnSelectedBorderTabColor = System.Drawing.Color.Silver;
            this.hTabControl2.UnSelectedTabColor = System.Drawing.Color.Transparent;
            this.hTabControl2.UnselectedTextColor = System.Drawing.Color.DimGray;
            this.hTabControl2.UseAnimation = false;
            // 
            // tabPage10
            // 
            this.tabPage10.BackColor = System.Drawing.Color.White;
            this.tabPage10.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage10.Location = new System.Drawing.Point(4, 25);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage10.Size = new System.Drawing.Size(332, 415);
            this.tabPage10.TabIndex = 0;
            this.tabPage10.Text = "Tab 1";
            // 
            // tabPage11
            // 
            this.tabPage11.BackColor = System.Drawing.Color.White;
            this.tabPage11.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage11.Location = new System.Drawing.Point(4, 25);
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage11.Size = new System.Drawing.Size(332, 415);
            this.tabPage11.TabIndex = 1;
            this.tabPage11.Text = "Tab 2";
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.tabPage6.Controls.Add(this.hTabControl7);
            this.tabPage6.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage6.Location = new System.Drawing.Point(139, 4);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(5);
            this.tabPage6.Size = new System.Drawing.Size(746, 538);
            this.tabPage6.TabIndex = 10;
            this.tabPage6.Text = "Pickers";
            // 
            // hTabControl7
            // 
            this.hTabControl7.ApplyTabPagesColor = true;
            this.hTabControl7.BackgroundColor = System.Drawing.Color.Transparent;
            this.hTabControl7.BorderTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hTabControl7.BorderThickness = 1;
            this.hTabControl7.Controls.Add(this.tabPage30);
            this.hTabControl7.Controls.Add(this.tabPage31);
            this.hTabControl7.Controls.Add(this.tabPage7);
            this.hTabControl7.CursorTabPages = System.Windows.Forms.Cursors.Default;
            this.hTabControl7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hTabControl7.ItemSize = new System.Drawing.Size(54, 30);
            this.hTabControl7.Location = new System.Drawing.Point(5, 5);
            this.hTabControl7.Name = "hTabControl7";
            this.hTabControl7.SelectedIndex = 0;
            this.hTabControl7.SelectedTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hTabControl7.SelectedTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hTabControl7.Size = new System.Drawing.Size(736, 528);
            this.hTabControl7.TabIndex = 7;
            this.hTabControl7.TabsColor = System.Drawing.Color.White;
            this.hTabControl7.TabStyle = HeCopUI_Framework.Enums.TabStyle.Style2;
            this.hTabControl7.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.hTabControl7.TextPadding = new System.Windows.Forms.Padding(0);
            this.hTabControl7.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hTabControl7.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hTabControl7.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            this.hTabControl7.UnSelectedBorderTabColor = System.Drawing.Color.Silver;
            this.hTabControl7.UnSelectedTabColor = System.Drawing.Color.Transparent;
            this.hTabControl7.UnselectedTextColor = System.Drawing.Color.DimGray;
            this.hTabControl7.UseAnimation = false;
            // 
            // tabPage30
            // 
            this.tabPage30.BackColor = System.Drawing.Color.White;
            this.tabPage30.Controls.Add(this.hClock1);
            this.tabPage30.Controls.Add(this.hClockDigital1);
            this.tabPage30.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage30.Location = new System.Drawing.Point(4, 34);
            this.tabPage30.Name = "tabPage30";
            this.tabPage30.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage30.Size = new System.Drawing.Size(728, 490);
            this.tabPage30.TabIndex = 0;
            this.tabPage30.Text = "Clock";
            // 
            // hClock1
            // 
            this.hClock1.ClockBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.hClock1.ClockBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
            this.hClock1.HourHandColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hClock1.Location = new System.Drawing.Point(204, 45);
            this.hClock1.MinuteHandColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(86)))), ((int)(((byte)(189)))));
            this.hClock1.Name = "hClock1";
            this.hClock1.SecondHandColor = System.Drawing.Color.DarkOrchid;
            this.hClock1.Size = new System.Drawing.Size(295, 226);
            this.hClock1.TabIndex = 4;
            this.hClock1.Text = "hClock1";
            this.hClock1.TicksColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            // 
            // hClockDigital1
            // 
            this.hClockDigital1.BackColor = System.Drawing.Color.Transparent;
            this.hClockDigital1.Font = new System.Drawing.Font("Segoe UI", 25F);
            this.hClockDigital1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(128)))));
            this.hClockDigital1.Interval = 1000;
            this.hClockDigital1.Location = new System.Drawing.Point(204, 308);
            this.hClockDigital1.Name = "hClockDigital1";
            this.hClockDigital1.ShowMillisecond = false;
            this.hClockDigital1.Size = new System.Drawing.Size(295, 107);
            this.hClockDigital1.TabIndex = 3;
            this.hClockDigital1.Text = "hClockDigital1";
            this.hClockDigital1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // tabPage31
            // 
            this.tabPage31.BackColor = System.Drawing.Color.White;
            this.tabPage31.Controls.Add(this.calendarControl1);
            this.tabPage31.Controls.Add(this.simpleCalendarControl1);
            this.tabPage31.Controls.Add(this.hMontCalendar1);
            this.tabPage31.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage31.Location = new System.Drawing.Point(4, 34);
            this.tabPage31.Name = "tabPage31";
            this.tabPage31.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage31.Size = new System.Drawing.Size(728, 490);
            this.tabPage31.TabIndex = 1;
            this.tabPage31.Text = "Calendar";
            // 
            // calendarControl1
            // 
            this.calendarControl1.BorderColor = System.Drawing.Color.Gray;
            this.calendarControl1.CalendarColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.calendarControl1.CalendarPadding = new System.Windows.Forms.Padding(5);
            this.calendarControl1.DayOfMonthColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.calendarControl1.DaysColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(136)))), ((int)(((byte)(231)))));
            this.calendarControl1.DaysFont = new System.Drawing.Font("Arial", 10F);
            this.calendarControl1.DaysHeight = 30;
            this.calendarControl1.HeaderFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.calendarControl1.HoverDateColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(136)))), ((int)(((byte)(231)))));
            this.calendarControl1.Location = new System.Drawing.Point(317, 258);
            this.calendarControl1.MaxDate = new System.DateTime(9999, 12, 31, 23, 59, 59, 999);
            this.calendarControl1.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.calendarControl1.MonthColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.calendarControl1.MonthDisplay = HeCopUI_Framework.Controls.Calendar.MonthDisplayType.Number;
            this.calendarControl1.Name = "calendarControl1";
            this.calendarControl1.NavigationButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(136)))), ((int)(((byte)(231)))));
            this.calendarControl1.NumberDayFont = new System.Drawing.Font("Arial", 10F);
            this.calendarControl1.SelectDayColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(164)))), ((int)(((byte)(80)))));
            this.calendarControl1.SelectedDate = new System.DateTime(2024, 10, 9, 0, 0, 0, 0);
            this.calendarControl1.SelectedDateColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(164)))), ((int)(((byte)(80)))));
            this.calendarControl1.ShowTime = false;
            this.calendarControl1.ShowWeekNumbers = true;
            this.calendarControl1.Size = new System.Drawing.Size(367, 226);
            this.calendarControl1.TabIndex = 15;
            this.calendarControl1.Text = "calendarControl1";
            this.calendarControl1.TimeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(136)))), ((int)(((byte)(231)))));
            this.calendarControl1.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.calendarControl1.TitleHeight = 30;
            this.calendarControl1.ToDay = new System.DateTime(2024, 10, 9, 0, 0, 0, 0);
            this.calendarControl1.WeekNumberColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(136)))), ((int)(((byte)(231)))));
            this.calendarControl1.WeekNumberFont = new System.Drawing.Font("Arial", 10F);
            // 
            // simpleCalendarControl1
            // 
            this.simpleCalendarControl1.BackColor = System.Drawing.Color.White;
            this.simpleCalendarControl1.CalendarPadding = new System.Windows.Forms.Padding(2);
            this.simpleCalendarControl1.DayColor = System.Drawing.Color.Green;
            this.simpleCalendarControl1.DayOfWeekColor = System.Drawing.Color.IndianRed;
            this.simpleCalendarControl1.DaysHeight = 30;
            this.simpleCalendarControl1.HeaderColor = System.Drawing.Color.Black;
            this.simpleCalendarControl1.HoverDateColor = System.Drawing.Color.LimeGreen;
            this.simpleCalendarControl1.Location = new System.Drawing.Point(317, 6);
            this.simpleCalendarControl1.MaxDate = new System.DateTime(9999, 12, 31, 23, 59, 59, 999);
            this.simpleCalendarControl1.MinDate = new System.DateTime(((long)(0)));
            this.simpleCalendarControl1.Name = "simpleCalendarControl1";
            this.simpleCalendarControl1.SelectedDate = new System.DateTime(((long)(0)));
            this.simpleCalendarControl1.SelectedDateColor = System.Drawing.Color.Red;
            this.simpleCalendarControl1.ShowDaysOutOfMonth = true;
            this.simpleCalendarControl1.ShowWeekNumbers = true;
            this.simpleCalendarControl1.ShowYearChange = false;
            this.simpleCalendarControl1.Size = new System.Drawing.Size(367, 235);
            this.simpleCalendarControl1.TabIndex = 14;
            this.simpleCalendarControl1.Text = "simpleCalendarControl1";
            this.simpleCalendarControl1.TitleHeight = 30;
            this.simpleCalendarControl1.ToDay = new System.DateTime(2024, 10, 9, 19, 0, 17, 958);
            this.simpleCalendarControl1.TodayColor = System.Drawing.Color.Blue;
            this.simpleCalendarControl1.WeekNumberColor = System.Drawing.Color.Gray;
            // 
            // hMontCalendar1
            // 
            this.hMontCalendar1.Date = new System.DateTime(2024, 7, 10, 0, 0, 0, 0);
            this.hMontCalendar1.DayHoverColor = System.Drawing.Color.DodgerBlue;
            this.hMontCalendar1.DaySelectedColor = System.Drawing.Color.SteelBlue;
            this.hMontCalendar1.HoverDayColor = System.Drawing.Color.White;
            this.hMontCalendar1.Location = new System.Drawing.Point(6, 6);
            this.hMontCalendar1.Name = "hMontCalendar1";
            this.hMontCalendar1.NormalDayColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.hMontCalendar1.PlaceHolderText = System.Drawing.Color.Gray;
            this.hMontCalendar1.PreviousButtonColor = System.Drawing.Color.DodgerBlue;
            this.hMontCalendar1.Size = new System.Drawing.Size(305, 324);
            this.hMontCalendar1.TabIndex = 13;
            this.hMontCalendar1.Text = "hMontCalendar1";
            this.hMontCalendar1.TextRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hMontCalendar1.TitleColor = System.Drawing.Color.DodgerBlue;
            this.hMontCalendar1.ToDayColor = System.Drawing.Color.DodgerBlue;
            this.hMontCalendar1.YearMonthColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            // 
            // tabPage7
            // 
            this.tabPage7.BackColor = System.Drawing.Color.White;
            this.tabPage7.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage7.Location = new System.Drawing.Point(4, 34);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(728, 490);
            this.tabPage7.TabIndex = 2;
            this.tabPage7.Text = "tabPage7";
            // 
            // tabPageIndicators
            // 
            this.tabPageIndicators.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.tabPageIndicators.Controls.Add(this.flowLayoutPanelIndicators);
            this.tabPageIndicators.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPageIndicators.Location = new System.Drawing.Point(139, 4);
            this.tabPageIndicators.Name = "tabPageIndicators";
            this.tabPageIndicators.Padding = new System.Windows.Forms.Padding(20);
            this.tabPageIndicators.Size = new System.Drawing.Size(746, 538);
            this.tabPageIndicators.TabIndex = 19;
            this.tabPageIndicators.Text = "Indicators && Blur";
            // 
            // flowLayoutPanelIndicators
            // 
            this.flowLayoutPanelIndicators.AutoScroll = true;
            this.flowLayoutPanelIndicators.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanelIndicators.Controls.Add(this.arcRotateIndicator1);
            this.flowLayoutPanelIndicators.Controls.Add(this.bouncingBarsIndicator1);
            this.flowLayoutPanelIndicators.Controls.Add(this.circlePulseIndicator1);
            this.flowLayoutPanelIndicators.Controls.Add(this.dashesIndicator1);
            this.flowLayoutPanelIndicators.Controls.Add(this.dualRingIndicator1);
            this.flowLayoutPanelIndicators.Controls.Add(this.fadingCircleIndicator1);
            this.flowLayoutPanelIndicators.Controls.Add(this.fourDotsIndicator1);
            this.flowLayoutPanelIndicators.Controls.Add(this.growingDotsIndicator1);
            this.flowLayoutPanelIndicators.Controls.Add(this.infinityIndicator1);
            this.flowLayoutPanelIndicators.Controls.Add(this.loadingBarIndicator1);
            this.flowLayoutPanelIndicators.Controls.Add(this.orbitIndicator1);
            this.flowLayoutPanelIndicators.Controls.Add(this.pieSpinnerIndicator1);
            this.flowLayoutPanelIndicators.Controls.Add(this.pulseRingIndicator1);
            this.flowLayoutPanelIndicators.Controls.Add(this.ringIndicator1);
            this.flowLayoutPanelIndicators.Controls.Add(this.spinnerIndicator1);
            this.flowLayoutPanelIndicators.Controls.Add(this.waveDotsIndicator1);
            this.flowLayoutPanelIndicators.Controls.Add(this.hImageBlur1);
            this.flowLayoutPanelIndicators.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelIndicators.Location = new System.Drawing.Point(20, 20);
            this.flowLayoutPanelIndicators.Name = "flowLayoutPanelIndicators";
            this.flowLayoutPanelIndicators.Size = new System.Drawing.Size(706, 498);
            this.flowLayoutPanelIndicators.TabIndex = 0;
            // 
            // arcRotateIndicator1
            // 
            this.arcRotateIndicator1.AnimationSpeed = 30;
            this.arcRotateIndicator1.BackColor = System.Drawing.Color.Transparent;
            this.arcRotateIndicator1.IsAnimating = true;
            this.arcRotateIndicator1.Location = new System.Drawing.Point(15, 15);
            this.arcRotateIndicator1.Margin = new System.Windows.Forms.Padding(15);
            this.arcRotateIndicator1.Name = "arcRotateIndicator1";
            this.arcRotateIndicator1.Size = new System.Drawing.Size(80, 80);
            this.arcRotateIndicator1.SpinnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.arcRotateIndicator1.TabIndex = 0;
            this.arcRotateIndicator1.Thickness = 6;
            // 
            // bouncingBarsIndicator1
            // 
            this.bouncingBarsIndicator1.AnimationSpeed = 100;
            this.bouncingBarsIndicator1.BackColor = System.Drawing.Color.Transparent;
            this.bouncingBarsIndicator1.BarColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.bouncingBarsIndicator1.BarCount = 5;
            this.bouncingBarsIndicator1.BarWidth = 6;
            this.bouncingBarsIndicator1.IsAnimating = true;
            this.bouncingBarsIndicator1.Location = new System.Drawing.Point(125, 15);
            this.bouncingBarsIndicator1.Margin = new System.Windows.Forms.Padding(15);
            this.bouncingBarsIndicator1.Name = "bouncingBarsIndicator1";
            this.bouncingBarsIndicator1.Size = new System.Drawing.Size(80, 80);
            this.bouncingBarsIndicator1.Spacing = 8;
            this.bouncingBarsIndicator1.TabIndex = 1;
            // 
            // circlePulseIndicator1
            // 
            this.circlePulseIndicator1.AnimationSpeed = 50;
            this.circlePulseIndicator1.BackColor = System.Drawing.Color.Transparent;
            this.circlePulseIndicator1.BaseSize = 20;
            this.circlePulseIndicator1.IsAnimating = true;
            this.circlePulseIndicator1.Location = new System.Drawing.Point(235, 15);
            this.circlePulseIndicator1.Margin = new System.Windows.Forms.Padding(15);
            this.circlePulseIndicator1.MaxScale = 1.5F;
            this.circlePulseIndicator1.Name = "circlePulseIndicator1";
            this.circlePulseIndicator1.PulseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.circlePulseIndicator1.ScaleStep = 0.05F;
            this.circlePulseIndicator1.Size = new System.Drawing.Size(80, 80);
            this.circlePulseIndicator1.TabIndex = 2;
            // 
            // dashesIndicator1
            // 
            this.dashesIndicator1.AnimationSpeed = 100;
            this.dashesIndicator1.BackColor = System.Drawing.Color.Transparent;
            this.dashesIndicator1.BaseColor = System.Drawing.Color.Transparent;
            this.dashesIndicator1.DashColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.dashesIndicator1.DashCount = 5;
            this.dashesIndicator1.DashHeight = 5;
            this.dashesIndicator1.DashWidth = 15;
            this.dashesIndicator1.IsAnimating = true;
            this.dashesIndicator1.Location = new System.Drawing.Point(345, 15);
            this.dashesIndicator1.Margin = new System.Windows.Forms.Padding(15);
            this.dashesIndicator1.Name = "dashesIndicator1";
            this.dashesIndicator1.Size = new System.Drawing.Size(80, 80);
            this.dashesIndicator1.Spacing = 10;
            this.dashesIndicator1.TabIndex = 3;
            // 
            // dualRingIndicator1
            // 
            this.dualRingIndicator1.AnimationSpeed = 50;
            this.dualRingIndicator1.ArcSweep = 120F;
            this.dualRingIndicator1.BackColor = System.Drawing.Color.Transparent;
            this.dualRingIndicator1.Color1 = System.Drawing.Color.LightGray;
            this.dualRingIndicator1.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.dualRingIndicator1.IsAnimating = true;
            this.dualRingIndicator1.Location = new System.Drawing.Point(455, 15);
            this.dualRingIndicator1.Margin = new System.Windows.Forms.Padding(15);
            this.dualRingIndicator1.Name = "dualRingIndicator1";
            this.dualRingIndicator1.RotationSpeed = 5;
            this.dualRingIndicator1.Size = new System.Drawing.Size(80, 80);
            this.dualRingIndicator1.TabIndex = 4;
            this.dualRingIndicator1.Thickness = 5;
            // 
            // fadingCircleIndicator1
            // 
            this.fadingCircleIndicator1.AnimationSpeed = 80;
            this.fadingCircleIndicator1.BackColor = System.Drawing.Color.Transparent;
            this.fadingCircleIndicator1.BaseColor = System.Drawing.Color.Transparent;
            this.fadingCircleIndicator1.DotCount = 12;
            this.fadingCircleIndicator1.DotSize = 6;
            this.fadingCircleIndicator1.IndicatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.fadingCircleIndicator1.IsAnimating = true;
            this.fadingCircleIndicator1.Location = new System.Drawing.Point(565, 15);
            this.fadingCircleIndicator1.Margin = new System.Windows.Forms.Padding(15);
            this.fadingCircleIndicator1.Name = "fadingCircleIndicator1";
            this.fadingCircleIndicator1.Size = new System.Drawing.Size(80, 80);
            this.fadingCircleIndicator1.TabIndex = 5;
            // 
            // fourDotsIndicator1
            // 
            this.fourDotsIndicator1.ActiveDotSizePlus = 3;
            this.fourDotsIndicator1.AnimationSpeed = 150;
            this.fourDotsIndicator1.BackColor = System.Drawing.Color.Transparent;
            this.fourDotsIndicator1.BaseColor = System.Drawing.Color.Transparent;
            this.fourDotsIndicator1.DotColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.fourDotsIndicator1.DotCount = 4;
            this.fourDotsIndicator1.DotSize = 10;
            this.fourDotsIndicator1.IsAnimating = true;
            this.fourDotsIndicator1.Location = new System.Drawing.Point(15, 125);
            this.fourDotsIndicator1.Margin = new System.Windows.Forms.Padding(15);
            this.fourDotsIndicator1.Name = "fourDotsIndicator1";
            this.fourDotsIndicator1.Size = new System.Drawing.Size(80, 80);
            this.fourDotsIndicator1.Spacing = 15;
            this.fourDotsIndicator1.TabIndex = 6;
            // 
            // growingDotsIndicator1
            // 
            this.growingDotsIndicator1.ActiveSizePlus = 6;
            this.growingDotsIndicator1.AnimationSpeed = 150;
            this.growingDotsIndicator1.BackColor = System.Drawing.Color.Transparent;
            this.growingDotsIndicator1.BaseColor = System.Drawing.Color.Transparent;
            this.growingDotsIndicator1.BaseSize = 10;
            this.growingDotsIndicator1.DotColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.growingDotsIndicator1.DotCount = 4;
            this.growingDotsIndicator1.IsAnimating = true;
            this.growingDotsIndicator1.Location = new System.Drawing.Point(125, 125);
            this.growingDotsIndicator1.Margin = new System.Windows.Forms.Padding(15);
            this.growingDotsIndicator1.Name = "growingDotsIndicator1";
            this.growingDotsIndicator1.Size = new System.Drawing.Size(80, 80);
            this.growingDotsIndicator1.Spacing = 20;
            this.growingDotsIndicator1.TabIndex = 7;
            // 
            // infinityIndicator1
            // 
            this.infinityIndicator1.AnimationSpeed = 20;
            this.infinityIndicator1.BackColor = System.Drawing.Color.Transparent;
            this.infinityIndicator1.BasePathColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.infinityIndicator1.DotSize = 12;
            this.infinityIndicator1.IndicatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.infinityIndicator1.IsAnimating = true;
            this.infinityIndicator1.Location = new System.Drawing.Point(235, 125);
            this.infinityIndicator1.Margin = new System.Windows.Forms.Padding(15);
            this.infinityIndicator1.MoveSpeed = 0.08F;
            this.infinityIndicator1.Name = "infinityIndicator1";
            this.infinityIndicator1.PathThickness = 2;
            this.infinityIndicator1.Size = new System.Drawing.Size(80, 80);
            this.infinityIndicator1.TabIndex = 8;
            // 
            // loadingBarIndicator1
            // 
            this.loadingBarIndicator1.AnimationSpeed = 30;
            this.loadingBarIndicator1.BackColor = System.Drawing.Color.Transparent;
            this.loadingBarIndicator1.BarColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.loadingBarIndicator1.BaseColor = System.Drawing.Color.LightGray;
            this.loadingBarIndicator1.IsAnimating = true;
            this.loadingBarIndicator1.Location = new System.Drawing.Point(345, 125);
            this.loadingBarIndicator1.Margin = new System.Windows.Forms.Padding(15);
            this.loadingBarIndicator1.Name = "loadingBarIndicator1";
            this.loadingBarIndicator1.SegmentWidth = 40;
            this.loadingBarIndicator1.Size = new System.Drawing.Size(80, 80);
            this.loadingBarIndicator1.Speed = 6;
            this.loadingBarIndicator1.TabIndex = 9;
            // 
            // orbitIndicator1
            // 
            this.orbitIndicator1.AnimationSpeed = 25;
            this.orbitIndicator1.BackColor = System.Drawing.Color.Transparent;
            this.orbitIndicator1.BaseColor = System.Drawing.Color.Silver;
            this.orbitIndicator1.CenterColor = System.Drawing.Color.DimGray;
            this.orbitIndicator1.CenterSize = 12;
            this.orbitIndicator1.IsAnimating = true;
            this.orbitIndicator1.Location = new System.Drawing.Point(455, 125);
            this.orbitIndicator1.Margin = new System.Windows.Forms.Padding(15);
            this.orbitIndicator1.Name = "orbitIndicator1";
            this.orbitIndicator1.OrbitColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.orbitIndicator1.SatelliteSize = 10;
            this.orbitIndicator1.Size = new System.Drawing.Size(80, 80);
            this.orbitIndicator1.TabIndex = 10;
            // 
            // pieSpinnerIndicator1
            // 
            this.pieSpinnerIndicator1.AnimationSpeed = 30;
            this.pieSpinnerIndicator1.BackColor = System.Drawing.Color.Transparent;
            this.pieSpinnerIndicator1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.pieSpinnerIndicator1.IsAnimating = true;
            this.pieSpinnerIndicator1.Location = new System.Drawing.Point(565, 125);
            this.pieSpinnerIndicator1.Margin = new System.Windows.Forms.Padding(15);
            this.pieSpinnerIndicator1.Name = "pieSpinnerIndicator1";
            this.pieSpinnerIndicator1.Size = new System.Drawing.Size(80, 80);
            this.pieSpinnerIndicator1.SpinnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.pieSpinnerIndicator1.SweepAngle = 70F;
            this.pieSpinnerIndicator1.TabIndex = 11;
            // 
            // pulseRingIndicator1
            // 
            this.pulseRingIndicator1.AnimationSpeed = 40;
            this.pulseRingIndicator1.BackColor = System.Drawing.Color.Transparent;
            this.pulseRingIndicator1.BaseColor = System.Drawing.Color.Transparent;
            this.pulseRingIndicator1.IsAnimating = true;
            this.pulseRingIndicator1.Location = new System.Drawing.Point(15, 235);
            this.pulseRingIndicator1.Margin = new System.Windows.Forms.Padding(15);
            this.pulseRingIndicator1.MaxScale = 1.2F;
            this.pulseRingIndicator1.MinScale = 0.7F;
            this.pulseRingIndicator1.Name = "pulseRingIndicator1";
            this.pulseRingIndicator1.RingColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.pulseRingIndicator1.ScaleStep = 0.02F;
            this.pulseRingIndicator1.Size = new System.Drawing.Size(80, 80);
            this.pulseRingIndicator1.TabIndex = 12;
            this.pulseRingIndicator1.Thickness = 6;
            // 
            // ringIndicator1
            // 
            this.ringIndicator1.AnimationSpeed = 50;
            this.ringIndicator1.ArcSweep = 270F;
            this.ringIndicator1.BackColor = System.Drawing.Color.Transparent;
            this.ringIndicator1.BaseColor = System.Drawing.Color.Transparent;
            this.ringIndicator1.IsAnimating = true;
            this.ringIndicator1.Location = new System.Drawing.Point(125, 235);
            this.ringIndicator1.Margin = new System.Windows.Forms.Padding(15);
            this.ringIndicator1.Name = "ringIndicator1";
            this.ringIndicator1.RingColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.ringIndicator1.RingThickness = 8;
            this.ringIndicator1.RotationSpeed = 10F;
            this.ringIndicator1.Size = new System.Drawing.Size(80, 80);
            this.ringIndicator1.TabIndex = 13;
            // 
            // spinnerIndicator1
            // 
            this.spinnerIndicator1.AnimationSpeed = 80;
            this.spinnerIndicator1.BackColor = System.Drawing.Color.Transparent;
            this.spinnerIndicator1.BarCount = 12;
            this.spinnerIndicator1.IsAnimating = true;
            this.spinnerIndicator1.LineLength = 10;
            this.spinnerIndicator1.LineThickness = 3;
            this.spinnerIndicator1.Location = new System.Drawing.Point(235, 235);
            this.spinnerIndicator1.Margin = new System.Windows.Forms.Padding(15);
            this.spinnerIndicator1.Name = "spinnerIndicator1";
            this.spinnerIndicator1.Size = new System.Drawing.Size(80, 80);
            this.spinnerIndicator1.SpinnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.spinnerIndicator1.TabIndex = 14;
            // 
            // waveDotsIndicator1
            // 
            this.waveDotsIndicator1.AnimationSpeed = 100;
            this.waveDotsIndicator1.BackColor = System.Drawing.Color.Transparent;
            this.waveDotsIndicator1.BaseColor = System.Drawing.Color.Transparent;
            this.waveDotsIndicator1.DotColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.waveDotsIndicator1.DotCount = 5;
            this.waveDotsIndicator1.DotSize = 10;
            this.waveDotsIndicator1.IsAnimating = true;
            this.waveDotsIndicator1.Location = new System.Drawing.Point(345, 235);
            this.waveDotsIndicator1.Margin = new System.Windows.Forms.Padding(15);
            this.waveDotsIndicator1.Name = "waveDotsIndicator1";
            this.waveDotsIndicator1.Size = new System.Drawing.Size(80, 80);
            this.waveDotsIndicator1.Spacing = 15;
            this.waveDotsIndicator1.TabIndex = 15;
            this.waveDotsIndicator1.WaveHeight = 3;
            // 
            // hImageBlur1
            // 
            this.hImageBlur1.BackColor = System.Drawing.Color.Transparent;
            this.hImageBlur1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.hImageBlur1.BlurRadius = 10;
            this.hImageBlur1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.hImageBlur1.Image = ((System.Drawing.Image)(resources.GetObject("hImageBlur1.Image")));
            this.hImageBlur1.Location = new System.Drawing.Point(455, 235);
            this.hImageBlur1.Margin = new System.Windows.Forms.Padding(15);
            this.hImageBlur1.Name = "hImageBlur1";
            this.hImageBlur1.Size = new System.Drawing.Size(150, 150);
            this.hImageBlur1.TabIndex = 16;
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(891, 589);
            this.Controls.Add(this.hTabControl1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.FormControlBox.CloseBoxColor = System.Drawing.Color.Transparent;
            this.FormControlBox.CloseBoxHoverColor = System.Drawing.Color.Red;
            this.FormControlBox.HoverColorShape = HeCopUI_Framework.Enums.ShapeType.RoundedRectangle;
            this.FormControlBox.IconCloseColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.FormControlBox.IconCloseHoverColor = System.Drawing.Color.White;
            this.FormControlBox.IconMaximizeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.FormControlBox.IconMaximizeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.FormControlBox.IconMinimizeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.FormControlBox.IconMinimizeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.FormControlBox.MaximizeBoxColor = System.Drawing.Color.Transparent;
            this.FormControlBox.MaximizeBoxHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.FormControlBox.MinimizeBoxColor = System.Drawing.Color.Transparent;
            this.FormControlBox.MinimizeBoxHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(1, 42, 1, 1);
            this.Resizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hecop UI Framework";
            this.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.TitleTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Load += new System.EventHandler(this.Form1_Load);
            this.hTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.hTabControl5.ResumeLayout(false);
            this.tabPage24.ResumeLayout(false);
            this.tabPage25.ResumeLayout(false);
            this.tabPage26.ResumeLayout(false);
            this.tabPage27.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage22.ResumeLayout(false);
            this.hTabControl10.ResumeLayout(false);
            this.tabPage35.ResumeLayout(false);
            this.tabPage36.ResumeLayout(false);
            this.hTabControl4.ResumeLayout(false);
            this.tabPage15.ResumeLayout(false);
            this.tabPage16.ResumeLayout(false);
            this.tabPage17.ResumeLayout(false);
            this.tabPage18.ResumeLayout(false);
            this.tabPage21.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.hTabControl6.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage28.ResumeLayout(false);
            this.tabPage29.ResumeLayout(false);
            this.tabPage9.ResumeLayout(false);
            this.hTabControl9.ResumeLayout(false);
            this.tabPage20.ResumeLayout(false);
            this.tabPage34.ResumeLayout(false);
            this.tabPage19.ResumeLayout(false);
            this.tabPage8.ResumeLayout(false);
            this.hTabControl8.ResumeLayout(false);
            this.tabPage32.ResumeLayout(false);
            this.tabPage33.ResumeLayout(false);
            this.hTabControl3.ResumeLayout(false);
            this.hTabControl2.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.hTabControl7.ResumeLayout(false);
            this.tabPage30.ResumeLayout(false);
            this.tabPage31.ResumeLayout(false);
            this.tabPageIndicators.ResumeLayout(false);
            this.flowLayoutPanelIndicators.ResumeLayout(false);
            this.ResumeLayout(false);

        }








        #endregion


        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ColorDialog colorDialog2;
        private System.Windows.Forms.ToolTip toolTip1;
        private HTabControl hTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage4;
        private HLabel hLabel1;
        private HLabel hLabel2;
        private System.Windows.Forms.Panel panel1;
        private HLabel hLabel8;
        private HLabel hLabel9;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private HLabel hLabel10;
        private System.Windows.Forms.TabPage tabPage8;
        private TabPage tabPage6;
        private TabPage tabPage21;
        private TabPage tabPage22;
        private TabPage tabPage5;
        private HImage hImage1;
        private HeCopUI_Framework.Controls.Effect.HEffectImage hEffectImage1;
        private HTabControl hTabControl5;
        private TabPage tabPage24;
        private TabPage tabPage25;
        private TabPage tabPage26;
        private HButton hButton7;
        private HButton hButton8;
        private HButton hButton9;
        private HButton hButton4;
        private HButton hButton5;
        private HButton hButton6;
        private HButton hButton3;
        private HButton hButton2;
        private HButton hButton1;
        private HTileButton HTileButton7;
        private HTileButton HTileButton8;
        private HTileButton HTileButton9;
        private HTileButton HTileButton4;
        private HTileButton HTileButton5;
        private HTileButton HTileButton6;
        private HTileButton HTileButton3;
        private HTileButton HTileButton2;
        private HTileButton HTileButton1;
        private TabPage tabPage27;
        private HRadioButton hRadioButton3;
        private HRadioButton hRadioButton2;
        private HCheckBox hCheckBox3;
        private HCheckBox hCheckBox2;
        private HRadioButton hRadioButton1;
        private HToggleButton hToggleButton1;
        private HCheckBox hCheckBox1;
        private HTabControl hTabControl6;
        private TabPage tabPage3;
        private WaveProgressLoading waveProgressLoading1;
        private HDotProgressRing hDotProgressRing8;
        private HDotProgressRing hDotProgressRing7;
        private HDotProgressRing hDotProgressRing6;
        private HDotProgressRing hDotProgressRing5;
        private HDotProgressRing hDotProgressRing4;
        private HDotProgressRing hDotProgressRing3;
        private HDotProgressRing hDotProgressRing2;
        private HDotProgressRing hDotProgressRing1;
        private TabPage tabPage28;
        private TabPage tabPage29;
        private HButton hButton10;
        private HProgressBar hProgressBar4;
        private HProgressBar hProgressBar5;
        private HProgressBar hProgressBar6;
        private HProgressBar hProgressBar3;
        private HProgressBar hProgressBar2;
        private HProgressBar hProgressBar1;
        private HCircularProgressBar hCircularProgressBar2;
        private HCircularProgressBar2 hCircularProgressBar21;
        private HCircularProgressBar1 hCircularProgressBar11;
        private HCircularProgressBar hCircularProgressBar1;
        private HTileSubtitleButton HTileSubtitleButton7;
        private HTileSubtitleButton HTileSubtitleButton8;
        private HTileSubtitleButton HTileSubtitleButton9;
        private HTileSubtitleButton HTileSubtitleButton4;
        private HTileSubtitleButton HTileSubtitleButton5;
        private HTileSubtitleButton HTileSubtitleButton6;
        private HTileSubtitleButton HTileSubtitleButton3;
        private HTileSubtitleButton HTileSubtitleButton2;
        private HTileSubtitleButton HTileSubtitleButton1;
        private HProgressRing hProgressRing2;
        private HStepIndicatorOne hStepIndicatorOne1;
        private HTabControl hTabControl7;
        private TabPage tabPage30;
        private TabPage tabPage31;
        private HMontCalendar hMontCalendar1;
        private HTabControl hTabControl8;
        private TabPage tabPage32;
        private HPanel HPanel1;
        private TabPage tabPage33;
        private HTabControl hTabControl3;
        private TabPage tabPage12;
        private TabPage tabPage13;
        private HTabControl hTabControl2;
        private TabPage tabPage10;
        private TabPage tabPage11;
        private HRichTextBox hRichTextBox2;
        private HRichTextBox hRichTextBox1;
        private TabPage tabPage9;
        private HTabControl hTabControl9;
        private TabPage tabPage20;
        private HHTrackBar hhTrackBar1;
        private HCircleAnglePicker hCircleAnglePicker1;
        private HRadialRangeSlider hRadialRangeSlider1;
        private TabPage tabPage34;
        private HSolidGauge hSolidGauge2;
        private HDigitalGauge hDigitalGauge2;
        private HClockDigital hClockDigital1;
        private TabPage tabPage19;
        private HScrollBar hScrollBar3;
        private HScrollBar hScrollBar4;
        private HScrollBar hScrollBar2;
        private HScrollBar hScrollBar1;
        private HeCopUI_Framework.Controls.Clock.HClock hClock1;
        private HTabControl hTabControl10;
        private TabPage tabPage35;
        private HeCopUI_Framework.Controls.TreeView.HTreeView hTreeView1;
        private TabPage tabPage36;
        private HTabControl hTabControl4;
        private TabPage tabPage15;
        private HeCopUI_Framework.Controls.Chart.HBarChart hBarChart1;
        private TabPage tabPage16;
        private TabPage tabPage17;
        private HeCopUI_Framework.Controls.Chart.HPieChart hPieChart1;
        private TabPage tabPage18;
        private HeCopUI_Framework.Controls.Chart.HRadarChart hRadarChart1;
        private HeCopUI_Framework.Controls.Calendar.SimpleCalendarControl simpleCalendarControl1;
        private HeCopUI_Framework.Controls.Calendar.CalendarControl calendarControl1;
        private HeCopUI_Framework.Controls.TextControls.HTextBox hTextBox1;
        private HeCopUI_Framework.Controls.TextControls.HTextBox hTextBox2;
        private TabPage tabPage7;
        private TabPage tabPage14;
        private HLabel hLabel7;
        private HLabel hLabel6;
        private HLabel hLabel5;
        private HLabel hLabel4;
        private HLabel hLabel3;
        private HeCopUI_Framework.Controls.Chart.HLineAreaChart hLineAreaChart1;
        
        private HButton hButton11;
        private System.Windows.Forms.TabPage tabPageIndicators;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelIndicators;
        private ArcRotateIndicator arcRotateIndicator1;
        private BouncingBarsIndicator bouncingBarsIndicator1;
        private CirclePulseIndicator circlePulseIndicator1;
        private DashesIndicator dashesIndicator1;
        private DualRingIndicator dualRingIndicator1;
        private FadingCircleIndicator fadingCircleIndicator1;
        private FourDotsIndicator fourDotsIndicator1;
        private GrowingDotsIndicator growingDotsIndicator1;
        private InfinityIndicator infinityIndicator1;
        private LoadingBarIndicator loadingBarIndicator1;
        private OrbitIndicator orbitIndicator1;
        private PieSpinnerIndicator pieSpinnerIndicator1;
        private PulseRingIndicator pulseRingIndicator1;
        private RingIndicator ringIndicator1;
        private SpinnerIndicator spinnerIndicator1;
        private WaveDotsIndicator waveDotsIndicator1;
        private HImageBlur hImageBlur1;
    }
}

