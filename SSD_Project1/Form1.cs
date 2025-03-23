using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace SSD_Project1
{
	public partial class Form1 : Form
	{
		// List to store all candlestick data loaded from the CSV file
		private List<Candlestick> candlesticks = new List<Candlestick>();
		// List to store candlestick data filtered by the selected date range
		private List<Candlestick> filteredCandlesticks = new List<Candlestick>();

		public Form1()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Event handler for the "Load Data" button click
		/// </summary>
		private void button_loadData_Click(object sender, EventArgs e)
		{
			openFileDialog_stockData.Filter = "CSV Files (*.csv)|*.csv"; // Ensure only CSV files are selected
			openFileDialog_stockData.Title = "Select a Stock Data CSV File"; // Set the title of the file dialog
			openFileDialog_stockData.ShowDialog(); // Show the file dialog to the user
		}

		/// <summary>
		/// Event handler for when a file is selected in the file dialog
		/// </summary>
		private void openFileDialog_stockData_FileOk(object sender, CancelEventArgs e)
		{
			string filePath = openFileDialog_stockData.FileName; // Get selected file path

			try
			{
				// Read the stock data from the CSV file using the StockReader class
				candlesticks = StockReader.ReadStockData(filePath); // ReadStockData is a static method

				// Check if any data was loaded
				if (candlesticks.Count > 0)
				{
					// Show a success message with the number of records loaded
					MessageBox.Show($"Loaded {candlesticks.Count} total records successfully!\n\nNow applying date filters based on your selection.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

					FilterDataByDate(); // Automatically apply date filter after loading the data
				}
				else
				{
					// Show a warning if no valid data was found in the file
					MessageBox.Show("No valid data found in the file.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
			catch (Exception ex)
			{
				// Show an error message if there was an issue loading the file
				MessageBox.Show($"Error loading file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// Method to filter the candlestick data based on the selected date range
		/// </summary>
		private void FilterDataByDate()
		{
			// Get the start and end dates from the date pickers
			DateTime startDate = dateTimePicker_startDate.Value;
			DateTime endDate = dateTimePicker_endDate.Value;

			// Create a new filtered list based on the selected date range
			filteredCandlesticks = candlesticks
				.Where(c => c.Date >= startDate && c.Date <= endDate)
				.ToList();

			// If no data matches the selected range, show a message
			if (filteredCandlesticks.Count == 0)
			{
				MessageBox.Show("No data available for the selected date range.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}

			// Update UI components with the filtered list
			DisplayInDataGridView();
			DisplayInChart();
		}

		/// <summary>
		/// Method to display the filtered candlestick data in the DataGridView
		/// </summary>
		private void DisplayInDataGridView()
		{
			dataGridView_stockData.DataSource = null; // Reset the DataGridView
			dataGridView_stockData.DataSource = filteredCandlesticks; // Bind the list to DataGridView
		}

		/// <summary>
		/// Method to display the filtered candlestick data in the chart
		/// </summary>
		private void DisplayInChart()
		{
			chart_stockData.Series.Clear(); // Clear previous data
			chart_stockData.ChartAreas.Clear(); // Clear previous chart areas

			// Create a new chart area for the candlestick data
			ChartArea candlestickArea = new ChartArea("CandlestickArea")
			{
				Position = new ElementPosition(0, 0, 80, 60), // Set the position and size of the chart area
			};
			candlestickArea.AxisX.LabelStyle.Format = "MM/dd/yyyy"; // Format X-axis as Date
			candlestickArea.AxisX.MajorGrid.LineColor = Color.LightGray; // Set the grid line color
			candlestickArea.AxisY.MajorGrid.LineColor = Color.LightGray; // Set the grid line color
			candlestickArea.AxisY.Title = "Stock Price"; // Set the Y-axis title

			// Create a new chart area for the volume data
			ChartArea volumeArea = new ChartArea("VolumeArea")
			{
				Position = new ElementPosition(0, 70, 80, 30), // Set the position and size of the chart area - aligned below OHLC
				AlignWithChartArea = "CandlestickArea" // Align X-Axis with OHLC chart
			};
			volumeArea.AxisX.LabelStyle.Enabled = true; // Show X-axis labels on Volume chart
			volumeArea.AxisY.MajorGrid.LineColor = Color.LightGray; // Set the grid line color
			volumeArea.AxisY.Title = "Volume"; // Set the Y-axis title

			// Add chart areas to chart
			chart_stockData.ChartAreas.Add(candlestickArea);
			chart_stockData.ChartAreas.Add(volumeArea);

			// Create a new series for the candlestick data
			Series candlestickSeries = new Series("Series_OHLC")
			{
				ChartType = SeriesChartType.Candlestick, // Set the chart type to candlestick
				XValueType = ChartValueType.DateTime, // Set the X-axis values to dates
				ChartArea = "CandlestickArea" // Associate the series with the candlestick chart
			};

			// Configure candlestick appearance
			candlestickSeries["OpenCloseStyle"] = "Triangle"; // Set the style of the open/close markers to triangles
			candlestickSeries["ShowOpenClose"] = "Both"; // Display both the open and close markers on the candlestick chart
			candlestickSeries["PointWidth"] = "0.7"; // Set the width of the candlestick bars


			// Create a new series for the volume data
			Series volumeSeries = new Series("Series_Volume")
			{
				ChartType = SeriesChartType.Column, // Set the chart type to column
				XValueType = ChartValueType.DateTime, // Set the X-axis values to dates
				Color = Color.Gold, // Set the color of the volume bars
				ChartArea = "VolumeArea" // Associate the series with the volume chart area
			};

			// Check if there is any data to display
			if (filteredCandlesticks.Count == 0)
			{
				// Show a warning if no data is available
				MessageBox.Show("No data available for the selected date range.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			

			// Handle X-axis
			// Get the minimum and maximum dates for the X-axis range
			DateTime minDate = filteredCandlesticks.Min(c => c.Date);
			DateTime maxDate = filteredCandlesticks.Max(c => c.Date);

			// Set the X-axis range	for both chart areas
			candlestickArea.AxisX.Minimum = minDate.ToOADate(); // Set the minimum X-axis value for the candlestick chart area
			candlestickArea.AxisX.Maximum = maxDate.ToOADate(); // Set the maximum X-axis value for the candlestick chart area
			volumeArea.AxisX.Minimum = minDate.ToOADate(); // Align with candlestick area
			volumeArea.AxisX.Maximum = maxDate.ToOADate(); // Align with candlestick area

			// Disable automatic interval calculation for the X-axis
			candlestickArea.AxisX.Interval = 0; // Disable uniform intervals
			candlestickArea.AxisX.IntervalType = DateTimeIntervalType.Auto; // Allow dynamic intervals
			volumeArea.AxisX.Interval = 0; // Disable uniform intervals
			volumeArea.AxisX.IntervalType = DateTimeIntervalType.Auto; // Allow dynamic intervals

			// Clear any existing custom labels on the X-axis
			candlestickArea.AxisX.CustomLabels.Clear();
			volumeArea.AxisX.CustomLabels.Clear();

			// Normalize Y-axis for the candlestick chart
			NormalizeYAxis(candlestickArea, filteredCandlesticks);

			// Loop through each candlestick in the filtered list
			foreach (var candle in filteredCandlesticks)
			{
				// Create a new data point for the candlestick
				DataPoint dp = new DataPoint
				{
					XValue = candle.Date.ToOADate(), // Set the X-value to the date
					YValues = new double[] { (double)candle.Open, (double)candle.High, (double)candle.Low, (double)candle.Close } // Set the Y-values for OHLC
				};
				// Manually Assign Colors
				if (candle.Close >= candle.Open)
					dp.Color = Color.Lime;  // Price went up
				else
					dp.Color = Color.Red;   // Price went down

				candlestickSeries.Points.Add(dp); // Add the data point to the candlestick series

				// Add the volume data to the volume series
				volumeSeries.Points.AddXY(candle.Date.ToOADate(), (double)candle.Volume);

				// Add custom X-axis labels for each date
				candlestickArea.AxisX.CustomLabels.Add(new CustomLabel(
					candle.Date.ToOADate() - 0.5,  // Start position
					candle.Date.ToOADate() + 0.5,  // End position
					candle.Date.ToString("MM/dd/yyyy"), // Display format
					0,  // Label row index (use 0 for main row)
					LabelMarkStyle.None)); // No extra marking

				// Add the same custom labels to the volume area
				volumeArea.AxisX.CustomLabels.Add(new CustomLabel(
					candle.Date.ToOADate() - 0.5,  // Start position
					candle.Date.ToOADate() + 0.5,  // End position
					candle.Date.ToString("MM/dd/yyyy"), // Display format
					0,  // Label row index (use 0 for main row)
					LabelMarkStyle.None)); // No extra marking

			}

			// Add candlestick and volume series to the chart
			chart_stockData.Series.Add(candlestickSeries);
			chart_stockData.Series.Add(volumeSeries);

			// Refresh the chart to display the updated data
			chart_stockData.Invalidate();
		}

		/// <summary>
		/// Method to normalize the Y-axis for the candlestick chart
		/// </summary>
		private void NormalizeYAxis(ChartArea chartArea, List<Candlestick> candlesticks)
		{
			// Get the minimum and maximum values of the stock data
			decimal minValue = candlesticks.Min(c => c.Low);
			decimal maxValue = candlesticks.Max(c => c.High);

			// Add 2% to the maximum value
			decimal maxY = maxValue + (0.02m * maxValue);
			// Subtract 2% from the minimum value
			decimal minY = minValue - (0.02m * minValue);

			// Set the Y-axis minimum and maximum values
			chartArea.AxisY.Minimum = (double)minY;
			chartArea.AxisY.Maximum = (double)maxY;
		}
	}
}

// LINQ: https://learn.microsoft.com/en-us/dotnet/csharp/linq/get-started/write-linq-queries