namespace TestApp
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
        /// Required method for Designer support.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.settingsPanel = new System.Windows.Forms.TableLayoutPanel();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelData = new System.Windows.Forms.Label();
            this.textBoxData = new System.Windows.Forms.TextBox();
            this.labelColor = new System.Windows.Forms.Label();
            this.comboBoxColor = new System.Windows.Forms.ComboBox();
            this.checkBoxVisible = new System.Windows.Forms.CheckBox();
            this.labelXAxis = new System.Windows.Forms.Label();
            this.textBoxXAxis = new System.Windows.Forms.TextBox();
            this.labelYAxis = new System.Windows.Forms.Label();
            this.textBoxYAxis = new System.Windows.Forms.TextBox();
            this.checkBoxGrid = new System.Windows.Forms.CheckBox();
            this.checkBoxAutoScale = new System.Windows.Forms.CheckBox();
            this.checkBoxZoomX = new System.Windows.Forms.CheckBox();
            this.checkBoxZoomY = new System.Windows.Forms.CheckBox();
            this.labelTransparency = new System.Windows.Forms.Label();
            this.numericUpDownTransparency = new System.Windows.Forms.NumericUpDown();
            this.buttonAddBar = new System.Windows.Forms.Button();
            this.buttonAddXY = new System.Windows.Forms.Button();
            this.chartsScrollPanel = new System.Windows.Forms.Panel();
            this.chartsLayout = new System.Windows.Forms.TableLayoutPanel();
            this.barChartControl1 = new CustomCharts.BarChartControl();
            this.xyChartControl1 = new CustomCharts.XyChartControl();
            this.mainLayout.SuspendLayout();
            this.settingsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTransparency)).BeginInit();
            this.chartsLayout.SuspendLayout();
            this.SuspendLayout();
            //
            // mainLayout
            //
            this.mainLayout.ColumnCount = 2;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 280F));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Controls.Add(this.settingsPanel, 0, 0);
            this.mainLayout.Controls.Add(this.chartsScrollPanel, 1, 0);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(0, 0);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.RowCount = 1;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Size = new System.Drawing.Size(1280, 720);
            this.mainLayout.TabIndex = 0;
            //
            // settingsPanel
            //
            this.settingsPanel.ColumnCount = 1;
            this.settingsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.settingsPanel.Controls.Add(this.labelName, 0, 0);
            this.settingsPanel.Controls.Add(this.textBoxName, 0, 1);
            this.settingsPanel.Controls.Add(this.labelData, 0, 2);
            this.settingsPanel.Controls.Add(this.textBoxData, 0, 3);
            this.settingsPanel.Controls.Add(this.labelColor, 0, 4);
            this.settingsPanel.Controls.Add(this.comboBoxColor, 0, 5);
            this.settingsPanel.Controls.Add(this.checkBoxVisible, 0, 6);
            this.settingsPanel.Controls.Add(this.labelXAxis, 0, 7);
            this.settingsPanel.Controls.Add(this.textBoxXAxis, 0, 8);
            this.settingsPanel.Controls.Add(this.labelYAxis, 0, 9);
            this.settingsPanel.Controls.Add(this.textBoxYAxis, 0, 10);
            this.settingsPanel.Controls.Add(this.checkBoxGrid, 0, 11);
            this.settingsPanel.Controls.Add(this.checkBoxAutoScale, 0, 12);
            this.settingsPanel.Controls.Add(this.checkBoxZoomX, 0, 13);
            this.settingsPanel.Controls.Add(this.checkBoxZoomY, 0, 14);
            this.settingsPanel.Controls.Add(this.labelTransparency, 0, 15);
            this.settingsPanel.Controls.Add(this.numericUpDownTransparency, 0, 16);
            this.settingsPanel.Controls.Add(this.buttonAddBar, 0, 17);
            this.settingsPanel.Controls.Add(this.buttonAddXY, 0, 18);
            this.settingsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingsPanel.Location = new System.Drawing.Point(12, 12);
            this.settingsPanel.Margin = new System.Windows.Forms.Padding(12);
            this.settingsPanel.Name = "settingsPanel";
            this.settingsPanel.RowCount = 20;
            this.settingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.settingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.settingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.settingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.settingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.settingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.settingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.settingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.settingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.settingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.settingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.settingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.settingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.settingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.settingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.settingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.settingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.settingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.settingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.settingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.settingsPanel.Size = new System.Drawing.Size(256, 696);
            this.settingsPanel.TabIndex = 0;
            //
            // labelName
            //
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(3, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(66, 16);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Series ID";
            //
            // textBoxName
            //
            this.textBoxName.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxName.Location = new System.Drawing.Point(3, 19);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(250, 22);
            this.textBoxName.TabIndex = 1;
            this.textBoxName.Text = "Series1";
            //
            // labelData
            //
            this.labelData.AutoSize = true;
            this.labelData.Location = new System.Drawing.Point(3, 44);
            this.labelData.Name = "labelData";
            this.labelData.Size = new System.Drawing.Size(151, 16);
            this.labelData.TabIndex = 2;
            this.labelData.Text = "Data (comma-separated)";
            //
            // textBoxData
            //
            this.textBoxData.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxData.Location = new System.Drawing.Point(3, 63);
            this.textBoxData.Name = "textBoxData";
            this.textBoxData.Size = new System.Drawing.Size(250, 22);
            this.textBoxData.TabIndex = 3;
            this.textBoxData.Text = "10,20,15,30,25";
            //
            // labelColor
            //
            this.labelColor.AutoSize = true;
            this.labelColor.Location = new System.Drawing.Point(3, 88);
            this.labelColor.Name = "labelColor";
            this.labelColor.Size = new System.Drawing.Size(39, 16);
            this.labelColor.TabIndex = 4;
            this.labelColor.Text = "Color";
            //
            // comboBoxColor
            //
            this.comboBoxColor.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxColor.FormattingEnabled = true;
            this.comboBoxColor.Location = new System.Drawing.Point(3, 107);
            this.comboBoxColor.Name = "comboBoxColor";
            this.comboBoxColor.Size = new System.Drawing.Size(250, 24);
            this.comboBoxColor.TabIndex = 5;
            //
            // checkBoxVisible
            //
            this.checkBoxVisible.AutoSize = true;
            this.checkBoxVisible.Location = new System.Drawing.Point(3, 137);
            this.checkBoxVisible.Name = "checkBoxVisible";
            this.checkBoxVisible.Size = new System.Drawing.Size(68, 20);
            this.checkBoxVisible.TabIndex = 6;
            this.checkBoxVisible.Text = "Visible";
            this.checkBoxVisible.UseVisualStyleBackColor = true;
            //
            // labelXAxis
            //
            this.labelXAxis.AutoSize = true;
            this.labelXAxis.Location = new System.Drawing.Point(3, 160);
            this.labelXAxis.Name = "labelXAxis";
            this.labelXAxis.Size = new System.Drawing.Size(78, 16);
            this.labelXAxis.TabIndex = 7;
            this.labelXAxis.Text = "X axis label";
            //
            // textBoxXAxis
            //
            this.textBoxXAxis.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxXAxis.Location = new System.Drawing.Point(3, 179);
            this.textBoxXAxis.Name = "textBoxXAxis";
            this.textBoxXAxis.Size = new System.Drawing.Size(250, 22);
            this.textBoxXAxis.TabIndex = 8;
            //
            // labelYAxis
            //
            this.labelYAxis.AutoSize = true;
            this.labelYAxis.Location = new System.Drawing.Point(3, 204);
            this.labelYAxis.Name = "labelYAxis";
            this.labelYAxis.Size = new System.Drawing.Size(78, 16);
            this.labelYAxis.TabIndex = 9;
            this.labelYAxis.Text = "Y axis label";
            //
            // textBoxYAxis
            //
            this.textBoxYAxis.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxYAxis.Location = new System.Drawing.Point(3, 223);
            this.textBoxYAxis.Name = "textBoxYAxis";
            this.textBoxYAxis.Size = new System.Drawing.Size(250, 22);
            this.textBoxYAxis.TabIndex = 10;
            //
            // checkBoxGrid
            //
            this.checkBoxGrid.AutoSize = true;
            this.checkBoxGrid.Location = new System.Drawing.Point(3, 251);
            this.checkBoxGrid.Name = "checkBoxGrid";
            this.checkBoxGrid.Size = new System.Drawing.Size(89, 20);
            this.checkBoxGrid.TabIndex = 11;
            this.checkBoxGrid.Text = "Show grid";
            this.checkBoxGrid.UseVisualStyleBackColor = true;
            //
            // checkBoxAutoScale
            //
            this.checkBoxAutoScale.AutoSize = true;
            this.checkBoxAutoScale.Location = new System.Drawing.Point(3, 277);
            this.checkBoxAutoScale.Name = "checkBoxAutoScale";
            this.checkBoxAutoScale.Size = new System.Drawing.Size(92, 20);
            this.checkBoxAutoScale.TabIndex = 12;
            this.checkBoxAutoScale.Text = "Auto scale";
            this.checkBoxAutoScale.UseVisualStyleBackColor = true;
            //
            // checkBoxZoomX
            //
            this.checkBoxZoomX.AutoSize = true;
            this.checkBoxZoomX.Location = new System.Drawing.Point(3, 303);
            this.checkBoxZoomX.Name = "checkBoxZoomX";
            this.checkBoxZoomX.Size = new System.Drawing.Size(113, 20);
            this.checkBoxZoomX.TabIndex = 13;
            this.checkBoxZoomX.Text = "Enable X zoom";
            this.checkBoxZoomX.UseVisualStyleBackColor = true;
            //
            // checkBoxZoomY
            //
            this.checkBoxZoomY.AutoSize = true;
            this.checkBoxZoomY.Location = new System.Drawing.Point(3, 329);
            this.checkBoxZoomY.Name = "checkBoxZoomY";
            this.checkBoxZoomY.Size = new System.Drawing.Size(113, 20);
            this.checkBoxZoomY.TabIndex = 14;
            this.checkBoxZoomY.Text = "Enable Y zoom";
            this.checkBoxZoomY.UseVisualStyleBackColor = true;
            //
            // labelTransparency
            //
            this.labelTransparency.AutoSize = true;
            this.labelTransparency.Location = new System.Drawing.Point(3, 352);
            this.labelTransparency.Name = "labelTransparency";
            this.labelTransparency.Size = new System.Drawing.Size(89, 16);
            this.labelTransparency.TabIndex = 15;
            this.labelTransparency.Text = "Transparency";
            //
            // numericUpDownTransparency
            //
            this.numericUpDownTransparency.Dock = System.Windows.Forms.DockStyle.Top;
            this.numericUpDownTransparency.Location = new System.Drawing.Point(3, 371);
            this.numericUpDownTransparency.Name = "numericUpDownTransparency";
            this.numericUpDownTransparency.Size = new System.Drawing.Size(250, 22);
            this.numericUpDownTransparency.TabIndex = 16;
            //
            // buttonAddBar
            //
            this.buttonAddBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonAddBar.Location = new System.Drawing.Point(3, 399);
            this.buttonAddBar.Name = "buttonAddBar";
            this.buttonAddBar.Size = new System.Drawing.Size(250, 32);
            this.buttonAddBar.TabIndex = 17;
            this.buttonAddBar.Text = "Update Bar Chart";
            this.buttonAddBar.UseVisualStyleBackColor = true;
            this.buttonAddBar.Click += new System.EventHandler(this.buttonAddBar_Click);
            //
            // buttonAddXY
            //
            this.buttonAddXY.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonAddXY.Location = new System.Drawing.Point(3, 437);
            this.buttonAddXY.Name = "buttonAddXY";
            this.buttonAddXY.Size = new System.Drawing.Size(250, 32);
            this.buttonAddXY.TabIndex = 18;
            this.buttonAddXY.Text = "Update XY Chart";
            this.buttonAddXY.UseVisualStyleBackColor = true;
            this.buttonAddXY.Click += new System.EventHandler(this.buttonAddXY_Click);
            //
            // chartsScrollPanel
            //
            this.chartsScrollPanel.AutoScroll = true;
            this.chartsScrollPanel.Controls.Add(this.chartsLayout);
            this.chartsScrollPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartsScrollPanel.Location = new System.Drawing.Point(292, 12);
            this.chartsScrollPanel.Margin = new System.Windows.Forms.Padding(12);
            this.chartsScrollPanel.Name = "chartsScrollPanel";
            this.chartsScrollPanel.Size = new System.Drawing.Size(976, 696);
            this.chartsScrollPanel.TabIndex = 1;
            //
            // chartsLayout
            //
            this.chartsLayout.AutoSize = true;
            this.chartsLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.chartsLayout.ColumnCount = 1;
            this.chartsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.chartsLayout.Controls.Add(this.barChartControl1, 0, 0);
            this.chartsLayout.Controls.Add(this.xyChartControl1, 0, 1);
            this.chartsLayout.Dock = System.Windows.Forms.DockStyle.Top;
            this.chartsLayout.Location = new System.Drawing.Point(0, 0);
            this.chartsLayout.Name = "chartsLayout";
            this.chartsLayout.RowCount = 2;
            this.chartsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 360F));
            this.chartsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 360F));
            this.chartsLayout.Size = new System.Drawing.Size(976, 720);
            this.chartsLayout.TabIndex = 0;
            //
            // barChartControl1
            //
            this.barChartControl1.AutoScale = true;
            this.barChartControl1.AxisColor = System.Drawing.Color.Black;
            this.barChartControl1.AxisLabelColor = System.Drawing.Color.Black;
            this.barChartControl1.ChartBackColor = System.Drawing.Color.White;
            this.barChartControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.barChartControl1.EnableZoomX = false;
            this.barChartControl1.EnableZoomY = false;
            this.barChartControl1.InputString = "";
            this.barChartControl1.Location = new System.Drawing.Point(3, 3);
            this.barChartControl1.Name = "barChartControl1";
            this.barChartControl1.PlotBackColor = System.Drawing.Color.White;
            this.barChartControl1.ShowGrid = true;
            this.barChartControl1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 12);
            this.barChartControl1.MinimumSize = new System.Drawing.Size(640, 320);
            this.barChartControl1.Size = new System.Drawing.Size(970, 345);
            this.barChartControl1.TabIndex = 0;
            this.barChartControl1.Transparency = 255;
            this.barChartControl1.XAxisTitle = "X";
            this.barChartControl1.YAxisTitle = "Y";
            //
            // xyChartControl1
            //
            this.xyChartControl1.AutoScale = true;
            this.xyChartControl1.AxisColor = System.Drawing.Color.Black;
            this.xyChartControl1.AxisLabelColor = System.Drawing.Color.Black;
            this.xyChartControl1.ChartBackColor = System.Drawing.Color.White;
            this.xyChartControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xyChartControl1.EnableZoomX = false;
            this.xyChartControl1.EnableZoomY = false;
            this.xyChartControl1.InputString = "";
            this.xyChartControl1.Location = new System.Drawing.Point(3, 363);
            this.xyChartControl1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 12);
            this.xyChartControl1.MinimumSize = new System.Drawing.Size(640, 320);
            this.xyChartControl1.Name = "xyChartControl1";
            this.xyChartControl1.PlotBackColor = System.Drawing.Color.White;
            this.xyChartControl1.ShowGrid = true;
            this.xyChartControl1.Size = new System.Drawing.Size(970, 345);
            this.xyChartControl1.TabIndex = 1;
            this.xyChartControl1.Transparency = 255;
            this.xyChartControl1.XAxisTitle = "X";
            this.xyChartControl1.YAxisTitle = "Y";
            this.xyChartControl1.Load += new System.EventHandler(this.xyChartControl1_Load);
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.mainLayout);
            this.MinimumSize = new System.Drawing.Size(960, 600);
            this.Name = "Form1";
            this.Text = "Custom Charts Demo";
            this.mainLayout.ResumeLayout(false);
            this.settingsPanel.ResumeLayout(false);
            this.settingsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTransparency)).EndInit();
            this.chartsLayout.ResumeLayout(false);
            this.chartsLayout.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.TableLayoutPanel settingsPanel;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelData;
        private System.Windows.Forms.TextBox textBoxData;
        private System.Windows.Forms.Label labelColor;
        private System.Windows.Forms.ComboBox comboBoxColor;
        private System.Windows.Forms.CheckBox checkBoxVisible;
        private System.Windows.Forms.Label labelXAxis;
        private System.Windows.Forms.TextBox textBoxXAxis;
        private System.Windows.Forms.Label labelYAxis;
        private System.Windows.Forms.TextBox textBoxYAxis;
        private System.Windows.Forms.CheckBox checkBoxGrid;
        private System.Windows.Forms.CheckBox checkBoxAutoScale;
        private System.Windows.Forms.CheckBox checkBoxZoomX;
        private System.Windows.Forms.CheckBox checkBoxZoomY;
        private System.Windows.Forms.Label labelTransparency;
        private System.Windows.Forms.NumericUpDown numericUpDownTransparency;
        private System.Windows.Forms.Button buttonAddBar;
        private System.Windows.Forms.Button buttonAddXY;
        private System.Windows.Forms.Panel chartsScrollPanel;
        private System.Windows.Forms.TableLayoutPanel chartsLayout;
        private CustomCharts.BarChartControl barChartControl1;
        private CustomCharts.XyChartControl xyChartControl1;
    }
}
