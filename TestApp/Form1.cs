using System;
using System.Drawing;
using System.Windows.Forms;

namespace TestApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeUiDefaults();
        }

        private void InitializeUiDefaults()
        {
            comboBoxColor.Items.AddRange(new object[]
            {
                "Red",
                "Blue",
                "Green",
                "Black",
                "Orange",
                "Purple"
            });

            comboBoxColor.SelectedIndex = 0;

            checkBoxVisible.Checked = true;
            checkBoxGrid.Checked = true;
            checkBoxAutoScale.Checked = true;
            checkBoxZoomX.Checked = false;
            checkBoxZoomY.Checked = false;

            textBoxXAxis.Text = "X";
            textBoxYAxis.Text = "Y";

            numericUpDownTransparency.Minimum = 0;
            numericUpDownTransparency.Maximum = 255;
            numericUpDownTransparency.Value = 255;
        }

        private void buttonAddBar_Click(object sender, EventArgs e)
        {
            string input = BuildInputString();

            barChartControl1.InputString = input;
            ApplyCommonSettings(barChartControl1);
        }

        private void buttonAddXY_Click(object sender, EventArgs e)
        {
            string input = BuildInputString();

            xyChartControl1.InputString = input;
            ApplyCommonSettings(xyChartControl1);
        }

        private string BuildInputString()
        {
            string name = textBoxName.Text.Trim();
            string data = textBoxData.Text.Trim();
            string color = comboBoxColor.Text.Trim();
            string visible = checkBoxVisible.Checked.ToString().ToLower();

            return string.Format("color={0};data:[{1}];visible={2};name={3}", color, data, visible, name);
        }

        private void ApplyCommonSettings(dynamic chartControl)
        {
            chartControl.XAxisTitle = textBoxXAxis.Text;
            chartControl.YAxisTitle = textBoxYAxis.Text;
            chartControl.ShowGrid = checkBoxGrid.Checked;
            chartControl.AutoScale = checkBoxAutoScale.Checked;
            chartControl.EnableZoomX = checkBoxZoomX.Checked;
            chartControl.EnableZoomY = checkBoxZoomY.Checked;
            chartControl.Transparency = (int)numericUpDownTransparency.Value;
        }

        private void xyChartControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
