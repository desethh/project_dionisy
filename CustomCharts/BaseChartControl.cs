using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CustomCharts
{
    public partial class BaseChartControl : UserControl
    {
        private const int MaxGraphs = 20;

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
        private string _inputString = string.Empty;

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
            ApplyAppearance();
            RedrawChart();
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
        public string XAxisTitle { get; set; }

        [Browsable(true)]
        [Category("Axes")]
        public string YAxisTitle { get; set; }

        [Browsable(true)]
        [Category("Appearance")]
        public bool ShowGrid { get; set; }

        [Browsable(true)]
        [Category("Behavior")]
        public bool AutoScale { get; set; }

        [Browsable(true)]
        [Category("Behavior")]
        public bool EnableZoomX { get; set; }

        [Browsable(true)]
        [Category("Behavior")]
        public bool EnableZoomY { get; set; }

        [Browsable(true)]
        [Category("Colors")]
        public Color AxisColor { get; set; }

        [Browsable(true)]
        [Category("Colors")]
        public Color AxisLabelColor { get; set; }

        [Browsable(true)]
        [Category("Colors")]
        public Color ChartBackColor { get; set; }

        [Browsable(true)]
        [Category("Colors")]
        public Color PlotBackColor { get; set; }

        [Browsable(true)]
        [Category("Appearance")]
        public int Transparency { get; set; }

        private void ParseAndApply(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                RedrawChart();
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
                        if (bool.TryParse(visibleValue, out bool visible))
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

                            data = numbers
                                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(x => double.Parse(x.Trim(), CultureInfo.InvariantCulture))
                                .ToList();
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

            RedrawChart();
        }

        private void RedrawChart()
        {
            chart1.Series.Clear();

            string areaName = chart1.ChartAreas[0].Name;
            string legendName = chart1.Legends[0].Name;

            foreach (var graph in _graphs.Values)
            {
                if (!graph.Visible)
                    continue;

                var series = new Series(graph.Name)
                {
                    ChartType = GetChartType(),
                    Color = Color.FromArgb(
                        Math.Max(0, Math.Min(255, Transparency)),
                        graph.Color),
                    BorderWidth = 2,
                    ChartArea = areaName,
                    Legend = legendName,
                    IsVisibleInLegend = true
                };

                for (int i = 0; i < graph.Data.Count; i++)
                {
                    series.Points.AddXY(i, graph.Data[i]);
                }

                chart1.Series.Add(series);
            }

            ApplyAppearance();
            chart1.Invalidate();
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
