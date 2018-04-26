using ControlLibrary.ViewModel;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ControlLibrary.View
{
    public partial class GraphControl
    {
        private ListViewModel _viewModel;

        private void InitialControlHandlers()
        {
            _viewModel = new ListViewModel();

            label1.DataBindings.Add(new Binding("Text", _viewModel, "DisplayEntryCount", false, DataSourceUpdateMode.OnPropertyChanged));

            chart1.Series.Add("Series1");
            chart1.Series["Series1"].ChartType = SeriesChartType.Column;
            chart1.Series["Series1"].YValueMembers = "Freq";
            chart1.Series["Series1"].XValueMember = "Word";
            chart1.DataBindings.Add(new Binding("DataSource", _viewModel, "BarGraphFeed", false, DataSourceUpdateMode.OnPropertyChanged));

            //This quick hack forces a repaint of the chart every time it is loaded.
            //For some reason databinding doesn't repaint it like any sane person would expect
            chart1.VisibleChanged += (sender, e) => chart1.Series["Series1"].ChartType = SeriesChartType.Column;
        }
    }
}
