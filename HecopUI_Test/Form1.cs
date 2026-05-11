using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace HecopUI_Test
{
    public partial class Form1 : HeCopUI_Framework.Forms.HForm
    {

        public Form1()
        {
            InitializeComponent();

            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadDataChart();
        }


        private void hCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            hCheckBox1.Text = hCheckBox1.Name + " (Checked: " + hCheckBox1.Checked + ")";
        }

        private void hCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            hCheckBox2.Text = hCheckBox2.Name + " (Checked: " + hCheckBox2.Checked + ")";
        }

        private void hCheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            hCheckBox3.Text = hCheckBox3.Name + " (Checked: " + hCheckBox3.Checked + ")";
        }

        private void hButton10_MouseClick(object sender, MouseEventArgs e)
        {
            hProgressBar4.ProgressValue = hProgressBar5.ProgressValue = hProgressBar2.ProgressValue = hProgressBar3.ProgressValue = new Random().Next(0, 100);
        }

        void loadDataChart()
        {
            #region Bar Chart
            // Ví dụ mẫu đi
            Dictionary<object, float> item1 = new Dictionary<object, float>
            {
                { "A", 10 },
                { "B", 20 },
                { "C", 30 }
            };

            hBarChart1.AddItems("Example 1", item1, Color.MediumVioletRed);

            Dictionary<object, float> item2 = new Dictionary<object, float>
            {
                { "A", 30 },
                { "B", 70 },
                { "C", 20 }
            };
            hBarChart1.AddItems("Example 2", item2, Color.DodgerBlue);

            Dictionary<object, float> item3 = new Dictionary<object, float>
            {
                { "A", 50 },
                { "B", 20 },
                { "C", 10 }
            };
            hBarChart1.AddItems("Example 3", item3, Color.FromArgb(0, 168, 138));
            #endregion

            #region Pie Chart
            Dictionary<object, float> item4 = new Dictionary<object, float>
            {
                { "A", 10 },
                { "B", 20 },
                { "C", 30 }
            };

            hPieChart1.AddItems("Example 1", item4, Color.MediumVioletRed);

            Dictionary<object, float> item5 = new Dictionary<object, float>
            {
                { "A", 30 },
                { "B", 70 },
                { "C", 20 }
            };
            hPieChart1.AddItems("Example 2", item5, Color.DodgerBlue);

            Dictionary<object, float> item6 = new Dictionary<object, float>
            {
                { "A", 50 },
                { "B", 20 },
                { "C", 10 }
            };
            hPieChart1.AddItems("Example 3", item6, Color.FromArgb(0, 168, 138));
            #endregion

            #region Line Chart
            Dictionary<object, float> item7 = new Dictionary<object, float>
            {
                { "A", 10 },
                { "B", 20 },
                { "C", 30 }
            };
            hLineAreaChart1.AddItems("Example 1", item7, Color.MediumVioletRed);

            Dictionary<object, float> item8 = new Dictionary<object, float>
            {
                { "A", 30 },
                { "B", 70 },
                { "C", 20 }
            };
            hLineAreaChart1.AddItems("Example 2", item8, Color.DodgerBlue);

            Dictionary<object, float> item9 = new Dictionary<object, float>
            {
                { "A", 50 },
                { "B", 20 },
                { "C", 10 }
            };
            hLineAreaChart1.AddItems("Example 3", item9, Color.FromArgb(0, 168, 138));
            #endregion

            #region Radar Chart

            List<HeCopUI_Framework.Controls.Chart.Series> series = new List<HeCopUI_Framework.Controls.Chart.Series>();

            HeCopUI_Framework.Controls.Chart.Series s1 = new HeCopUI_Framework.Controls.Chart.Series
            {
                Text = "Example 1",
                Values = new float[] { 10, 20, 30, 40, 50, 60 },
                Color = Color.MediumVioletRed
            };

            HeCopUI_Framework.Controls.Chart.Series s2 = new HeCopUI_Framework.Controls.Chart.Series
            {
                Text = "Example 2",
                Values = new float[] { 60, 50, 40, 30, 20, 10 },
                Color = Color.MediumSeaGreen
            };

            HeCopUI_Framework.Controls.Chart.Series s3 = new HeCopUI_Framework.Controls.Chart.Series
            {
                Text = "Example 3",
                Values = new float[] { 30, 40, 50, 60, 70, 80 },
                Color = Color.MediumAquamarine
            };

            series.Add(s1);
            series.Add(s2);
            series.Add(s3);

            hRadarChart1.Series = series.ToArray();


            #endregion

        }

        private void hCircleAnglePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void hButton12_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
        }

        private void hButton11_Click(object sender, EventArgs e)
        {

        }

        private void hTreeView1_AfterSelect(object sender, HeCopUI_Framework.Controls.TreeView.TreeViewEventArgs e)
        {

        }

        private void hButton11_Click_1(object sender, EventArgs e)
        {
            hBarChart1.RefreshData();
            hLineAreaChart1.RefreshData();
        }
    }
}
