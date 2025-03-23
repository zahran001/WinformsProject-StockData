namespace SSD_Project1
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
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.button_loadData = new System.Windows.Forms.Button();
			this.dateTimePicker_startDate = new System.Windows.Forms.DateTimePicker();
			this.dateTimePicker_endDate = new System.Windows.Forms.DateTimePicker();
			this.label_startDate = new System.Windows.Forms.Label();
			this.label_endDate = new System.Windows.Forms.Label();
			this.openFileDialog_stockData = new System.Windows.Forms.OpenFileDialog();
			this.dataGridView_stockData = new System.Windows.Forms.DataGridView();
			this.chart_stockData = new System.Windows.Forms.DataVisualization.Charting.Chart();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView_stockData)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chart_stockData)).BeginInit();
			this.SuspendLayout();
			// 
			// button_loadData
			// 
			this.button_loadData.Location = new System.Drawing.Point(65, 98);
			this.button_loadData.Name = "button_loadData";
			this.button_loadData.Size = new System.Drawing.Size(86, 35);
			this.button_loadData.TabIndex = 0;
			this.button_loadData.Text = "Load";
			this.button_loadData.UseVisualStyleBackColor = true;
			this.button_loadData.Click += new System.EventHandler(this.button_loadData_Click);
			// 
			// dateTimePicker_startDate
			// 
			this.dateTimePicker_startDate.Location = new System.Drawing.Point(319, 77);
			this.dateTimePicker_startDate.Name = "dateTimePicker_startDate";
			this.dateTimePicker_startDate.Size = new System.Drawing.Size(298, 26);
			this.dateTimePicker_startDate.TabIndex = 1;
			this.dateTimePicker_startDate.Value = new System.DateTime(2024, 1, 1, 0, 0, 0, 0);
			// 
			// dateTimePicker_endDate
			// 
			this.dateTimePicker_endDate.Location = new System.Drawing.Point(319, 123);
			this.dateTimePicker_endDate.Name = "dateTimePicker_endDate";
			this.dateTimePicker_endDate.Size = new System.Drawing.Size(298, 26);
			this.dateTimePicker_endDate.TabIndex = 2;
			this.dateTimePicker_endDate.Value = new System.DateTime(2024, 12, 31, 0, 0, 0, 0);
			// 
			// label_startDate
			// 
			this.label_startDate.AutoSize = true;
			this.label_startDate.Location = new System.Drawing.Point(216, 83);
			this.label_startDate.Name = "label_startDate";
			this.label_startDate.Size = new System.Drawing.Size(83, 20);
			this.label_startDate.TabIndex = 3;
			this.label_startDate.Text = "Start Date";
			// 
			// label_endDate
			// 
			this.label_endDate.AutoSize = true;
			this.label_endDate.Location = new System.Drawing.Point(216, 123);
			this.label_endDate.Name = "label_endDate";
			this.label_endDate.Size = new System.Drawing.Size(77, 20);
			this.label_endDate.TabIndex = 4;
			this.label_endDate.Text = "End Date";
			// 
			// openFileDialog_stockData
			// 
			this.openFileDialog_stockData.FileName = "openFileDialog";
			this.openFileDialog_stockData.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_stockData_FileOk);
			// 
			// dataGridView_stockData
			// 
			this.dataGridView_stockData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView_stockData.Location = new System.Drawing.Point(671, 21);
			this.dataGridView_stockData.Name = "dataGridView_stockData";
			this.dataGridView_stockData.RowHeadersWidth = 62;
			this.dataGridView_stockData.RowTemplate.Height = 28;
			this.dataGridView_stockData.Size = new System.Drawing.Size(1019, 205);
			this.dataGridView_stockData.TabIndex = 5;
			// 
			// chart_stockData
			// 
			chartArea1.Name = "ChartArea1";
			this.chart_stockData.ChartAreas.Add(chartArea1);
			legend1.Name = "Legend1";
			this.chart_stockData.Legends.Add(legend1);
			this.chart_stockData.Location = new System.Drawing.Point(65, 245);
			this.chart_stockData.Name = "chart_stockData";
			series1.ChartArea = "ChartArea1";
			series1.Legend = "Legend1";
			series1.Name = "Series1";
			this.chart_stockData.Series.Add(series1);
			this.chart_stockData.Size = new System.Drawing.Size(1625, 701);
			this.chart_stockData.TabIndex = 6;
			this.chart_stockData.Text = "chart1";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1730, 969);
			this.Controls.Add(this.chart_stockData);
			this.Controls.Add(this.dataGridView_stockData);
			this.Controls.Add(this.label_endDate);
			this.Controls.Add(this.label_startDate);
			this.Controls.Add(this.dateTimePicker_endDate);
			this.Controls.Add(this.dateTimePicker_startDate);
			this.Controls.Add(this.button_loadData);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView_stockData)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chart_stockData)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button_loadData;
		private System.Windows.Forms.DateTimePicker dateTimePicker_startDate;
		private System.Windows.Forms.DateTimePicker dateTimePicker_endDate;
		private System.Windows.Forms.Label label_startDate;
		private System.Windows.Forms.Label label_endDate;
		private System.Windows.Forms.OpenFileDialog openFileDialog_stockData;
		private System.Windows.Forms.DataGridView dataGridView_stockData;
		private System.Windows.Forms.DataVisualization.Charting.Chart chart_stockData;
	}
}

