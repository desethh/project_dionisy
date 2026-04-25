using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CustomCharts
{
    public partial class BaseChartControl : UserControl
    {
        private const int MaxGraphs = 20;
        private const int RefreshIntervalMs = 200;

        private class GraphInfo
        {
            public GraphInfo()
            {
                Name = "Series";
                Data = new List<double>();
                Color = Color.Blue;
                Visible = true;
            }

            public string Name { get; set; }
            public List<double> Data { get; set; }
            public Color Color { get; set; }
            public bool Visible { get; set; }
        }

        private readonly Dictionary<string, GraphInfo> _graphs = new Dictionary<string, GraphInfo>(StringComparer.OrdinalIgnoreCase);
        private readonly Timer _refreshTimer;
        private string _inputString = string.Empty;
        private string _xAxisTitle;
        private string _yAxisTitle;
        private bool _showGrid;
        private bool _autoScale;
        private bool _enableZoomX;
        private bool _enableZoomY;
        private Color _axisColor = Color.Black;
        private Color _axisLabelColor = Color.Black;
        private Color _chartBackColor = Color.White;
        private Color _plotBackColor = Color.White;
        private int _transparency = 255;
        private bool _redrawPending;
        private bool _isRedrawing;

        public BaseChartControl()
        {
            InitializeComponent();

            if (chart1.ChartAreas.Count == 0)
                chart1.ChartAreas.Add(new ChartArea("MainArea"));

            if (chart1.Legends.Count == 0)
                chart1.Legends.Add(new Legend("MainLegend"));

            SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer,
                true);

            UpdateStyles();
            _refreshTimer = new Timer { Interval = RefreshIntervalMs };
            _refreshTimer.Tick += RefreshTimer_Tick;

            ApplyAppearance();
            _redrawPending = true;
            RedrawChartNow();
        }

        [Browsable(true)]
        [Category("Data")]
        public string InputString
        {
            get { return _inputString; }
            set
            {
                _inputString = value ?? string.Empty;
                ParseAndApply(_inputString);
            }
        }

        [Browsable(true)]
        [Category("Axes")]
        public string XAxisTitle
        {
            get { return _xAxisTitle; }
            set
            {
                if (_xAxisTitle == value)
                    return;

                _xAxisTitle = value;
                ScheduleRedraw();
            }
        }

        [Browsable(true)]
        [Category("Axes")]
        public string YAxisTitle
        {
            get { return _yAxisTitle; }
            set
            {
                if (_yAxisTitle == value)
                    return;

                _yAxisTitle = value;
                ScheduleRedraw();
            }
        }

        [Browsable(true)]
        [Category("Appearance")]
        public bool ShowGrid
        {
            get { return _showGrid; }
            set
            {
                if (_showGrid == value)
                    return;

                _showGrid = value;
                ScheduleRedraw();
            }
        }

        [Browsable(true)]
        [Category("Behavior")]
        public bool AutoScale
        {
            get { return _autoScale; }
            set
            {
                if (_autoScale == value)
                    return;

                _autoScale = value;
                ScheduleRedraw();
            }
        }

        [Browsable(true)]
        [Category("Behavior")]
        public bool EnableZoomX
        {
            get { return _enableZoomX; }
            set
            {
                if (_enableZoomX == value)
                    return;

                _enableZoomX = value;
                ScheduleRedraw();
            }
        }

        [Browsable(true)]
        [Category("Behavior")]
        public bool EnableZoomY
        {
            get { return _enableZoomY; }
            set
            {
                if (_enableZoomY == value)
                    return;

                _enableZoomY = value;
                ScheduleRedraw();
            }
        }

        [Browsable(true)]
        [Category("Colors")]
        public Color AxisColor
        {
            get { return _axisColor; }
            set
            {
                if (_axisColor == value)
                    return;

                _axisColor = value;
                ScheduleRedraw();
            }
        }

        [Browsable(true)]
        [Category("Colors")]
        public Color AxisLabelColor
        {
            get { return _axisLabelColor; }
            set
            {
                if (_axisLabelColor == value)
                    return;

                _axisLabelColor = value;
                ScheduleRedraw();
            }
        }

        [Browsable(true)]
        [Category("Colors")]
        public Color ChartBackColor
        {
            get { return _chartBackColor; }
            set
            {
                if (_chartBackColor == value)
                    return;

                _chartBackColor = value;
                ScheduleRedraw();
            }
        }

        [Browsable(true)]
        [Category("Colors")]
        public Color PlotBackColor
        {
            get { return _plotBackColor; }
            set
            {
                if (_plotBackColor == value)
                    return;

                _plotBackColor = value;
                ScheduleRedraw();
            }
        }

        [Browsable(true)]
        [Category("Appearance")]
        public int Transparency
        {
            get { return _transparency; }
            set
            {
                int clampedValue = Math.Max(0, Math.Min(255, value));
                if (_transparency == clampedValue)
                    return;

                _transparency = clampedValue;
                ScheduleRedraw();
            }
        }

        private void ParseAndApply(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                ScheduleRedraw();
                return;
            }

            string seriesName = "Series1";
            bool isVisible = true;
            Color seriesColor = Color.Blue;
            List<double> data = new List<double>();

            try
            {
                var parts = input.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var rawPart in parts)
                {
                    var part = rawPart.Trim();

                    if (part.StartsWith("color=", StringComparison.OrdinalIgnoreCase))
                    {
                        string colorValue = part.Substring("color=".Length).Trim();
                        Color parsedColor = Color.FromName(colorValue);

                        if (parsedColor.A != 0 || colorValue.Equals("Black", StringComparison.OrdinalIgnoreCase))
                            seriesColor = parsedColor;
                    }
                    else if (part.StartsWith("visible=", StringComparison.OrdinalIgnoreCase))
                    {
                        string visibleValue = part.Substring("visible=".Length).Trim();
                        bool visible;
                        if (bool.TryParse(visibleValue, out visible))
                            isVisible = visible;
                    }
                    else if (part.StartsWith("name=", StringComparison.OrdinalIgnoreCase))
                    {
                        seriesName = part.Substring("name=".Length).Trim();
                        if (string.IsNullOrWhiteSpace(seriesName))
                            seriesName = "Series1";
                    }
                    else if (part.StartsWith("data:", StringComparison.OrdinalIgnoreCase))
                    {
                        int start = part.IndexOf('[');
                        int end = part.LastIndexOf(']');

                        if (start >= 0 && end > start)
                        {
                            string numbers = part.Substring(start + 1, end - start - 1);

                            data = ParseDataPoints(numbers);
                        }
                    }
                }
            }
            catch
            {
                return;
            }

            if (_graphs.ContainsKey(seriesName))
            {
                _graphs[seriesName].Data = data;
                _graphs[seriesName].Color = seriesColor;
                _graphs[seriesName].Visible = isVisible;
            }
            else
            {
                if (_graphs.Count >= MaxGraphs)
                    return;

                _graphs[seriesName] = new GraphInfo
                {
                    Name = seriesName,
                    Data = data,
                    Color = seriesColor,
                    Visible = isVisible
                };
            }

            ScheduleRedraw();
        }

        private List<double> ParseDataPoints(string numbers)
        {
            var values = new List<double>();
            string[] parts = numbers.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string rawValue in parts)
            {
                double value;
                if (double.TryParse(rawValue.Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out value))
                    values.Add(value);
            }

            return values;
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            _refreshTimer.Stop();

            if (_redrawPending)
                RedrawChartNow();
        }

        private void ScheduleRedraw()
        {
            if (IsDisposed)
                return;

            _redrawPending = true;

            if (_isRedrawing)
                return;

            if (_refreshTimer.Enabled)
                return;

            _refreshTimer.Start();
        }

        private void RedrawChartNow()
        {
            if (_isRedrawing || !_redrawPending)
                return;

            _isRedrawing = true;
            _redrawPending = false;
            string areaName = chart1.ChartAreas[0].Name;
            string legendName = chart1.Legends[0].Name;
            var visibleSeriesNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            chart1.BeginInit();
            chart1.SuspendLayout();

            try
            {
                foreach (var graph in _graphs.Values)
                {
                    if (!graph.Visible)
                        continue;

                    visibleSeriesNames.Add(graph.Name);

                    Series series = chart1.Series.FindByName(graph.Name);
                    if (series == null)
                    {
                        series = new Series(graph.Name);
                        chart1.Series.Add(series);
                    }

                    UpdateSeriesSettings(series, graph, areaName, legendName);
                    UpdateSeriesPoints(series, graph.Data);
                }

                RemoveUnusedSeries(visibleSeriesNames);

                ApplyAppearance();
            }
            finally
            {
                chart1.ResumeLayout(false);
                chart1.EndInit();
                chart1.Invalidate();
                _isRedrawing = false;

                if (_redrawPending)
                    ScheduleRedraw();
            }
        }

        private void UpdateSeriesSettings(Series series, GraphInfo graph, string areaName, string legendName)
        {
            series.ChartType = GetChartType();
            series.Color = Color.FromArgb(Transparency, graph.Color);
            series.BorderWidth = 2;
            series.ChartArea = areaName;
            series.Legend = legendName;
            series.IsVisibleInLegend = true;
        }

        private void UpdateSeriesPoints(Series series, IList<double> data)
        {
            if (series.Points.Count != data.Count)
            {
                series.Points.Clear();

                for (int i = 0; i < data.Count; i++)
                    series.Points.AddXY(i, data[i]);

                return;
            }

            for (int i = 0; i < data.Count; i++)
            {
                DataPoint point = series.Points[i];
                if (point.XValue != i)
                    point.XValue = i;

                if (point.YValues.Length == 0 || point.YValues[0] != data[i])
                    point.SetValueY(data[i]);
            }
        }

        private void RemoveUnusedSeries(ISet<string> visibleSeriesNames)
        {
            for (int i = chart1.Series.Count - 1; i >= 0; i--)
            {
                Series series = chart1.Series[i];
                if (!visibleSeriesNames.Contains(series.Name))
                    chart1.Series.RemoveAt(i);
            }
        }

        private void ApplyAppearance()
        {
            var area = chart1.ChartAreas[0];

            area.AxisX.Title = XAxisTitle;
            area.AxisY.Title = YAxisTitle;

            area.AxisX.MajorGrid.Enabled = ShowGrid;
            area.AxisY.MajorGrid.Enabled = ShowGrid;

            if (AutoScale)
            {
                area.AxisX.Minimum = double.NaN;
                area.AxisX.Maximum = double.NaN;
                area.AxisY.Minimum = double.NaN;
                area.AxisY.Maximum = double.NaN;
            }

            area.AxisX.ScaleView.Zoomable = EnableZoomX;
            area.AxisY.ScaleView.Zoomable = EnableZoomY;

            area.CursorX.IsUserEnabled = EnableZoomX;
            area.CursorX.IsUserSelectionEnabled = EnableZoomX;
            area.CursorY.IsUserEnabled = EnableZoomY;
            area.CursorY.IsUserSelectionEnabled = EnableZoomY;

            area.CursorX.Interval = 0;
            area.CursorY.Interval = 0;

            area.AxisX.LineColor = AxisColor;
            area.AxisY.LineColor = AxisColor;

            area.AxisX.LabelStyle.ForeColor = AxisLabelColor;
            area.AxisY.LabelStyle.ForeColor = AxisLabelColor;
            area.AxisX.TitleForeColor = AxisLabelColor;
            area.AxisY.TitleForeColor = AxisLabelColor;

            chart1.BackColor = ChartBackColor;
            area.BackColor = PlotBackColor;
        }

        protected virtual SeriesChartType GetChartType()
        {
            return SeriesChartType.Line;
        }
    }
}
