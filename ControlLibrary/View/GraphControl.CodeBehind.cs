using ControlLibrary.ViewModel;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ControlLibrary.View
{
    public partial class GraphControl
    {
        private GraphViewModel _viewModel;

        private void InitialControlHandlers()
        {
            _viewModel = new GraphViewModel();

            label1.DataBindings.Add(new Binding("Text", _viewModel, "DisplayEntryCount", false, DataSourceUpdateMode.OnPropertyChanged));

            var series = chart1.Series.Add("ChartSeries");
            series.ChartType = SeriesChartType.Column;
            series.YValueMembers = "Freq";
            series.XValueMember = "Word";
            chart1.DataBindings.Add(new Binding("DataSource", _viewModel, "BarGraphFeed", false, DataSourceUpdateMode.OnPropertyChanged));

            //This quick hack forces a repaint of the chart every time it is loaded.
            //For some reason databinding doesn't repaint it like any sane person would expect
            chart1.VisibleChanged += (sender, e) => series.ChartType = SeriesChartType.Column;
        }
    }
}
