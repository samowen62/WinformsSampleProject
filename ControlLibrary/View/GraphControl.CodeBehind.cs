using ControlLibrary.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlLibrary.View
{
    public partial class GraphControl
    {
        private ListViewModel _viewModel;

        private void InitialControlHandlers()
        {
            _viewModel = new ListViewModel();

            /*var list = _viewModel.WordList.ToDictionary(e => e, e => e.Count());
			foreach(var item in list)
            {
                chart1.Series.Add(item.Key);
                chart1.Series[item.Key].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                chart1.Series[item.Key].Points.AddY(item.Value);
                chart1.Series[item.Key].ChartArea = item.Key;
            }*/

            //chart1.DataBindings
			//label1.Tag 
            label1.DataBindings.Add(new Binding("Text", _viewModel, "Display", false, DataSourceUpdateMode.OnPropertyChanged));//this last part will keep it bound on enter press
        }
    }
}
