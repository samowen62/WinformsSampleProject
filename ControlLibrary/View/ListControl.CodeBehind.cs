using ControlLibrary.ViewModel;
using System.Windows.Forms;

namespace ControlLibrary.View
{
    public partial class ListControl
    {
        private ListViewModel _viewModel;

        //Defining all Control handler methods
        private void InitialControlHandlers()
        {
            _viewModel = new ListViewModel();
            //ENTER KEY!!!
            InputText.KeyPress += (sender, e) =>
            {
                if (e.KeyChar == (char)13)
                    AddToList();
            };

            AddBtn.Click += (sender, e) => AddToList();
            AddBtn.Tag = _viewModel.AddToListCommand;

            InputText.Tag = _viewModel.TextChangedCommand;
            InputText.DataBindings.Add(new Binding("Text", _viewModel, "NewWordText", 
                false, DataSourceUpdateMode.OnPropertyChanged));//this last part will keep it bound on enter press

            ListText.DataBindings.Add(new Binding("Text", _viewModel, "DisplayEntries",
                false, DataSourceUpdateMode.OnPropertyChanged));
        }

        private void AddToList()
        {

            _viewModel.Execute(AddBtn.Tag, null);
            InputText.Text = string.Empty;
            InputText.Focus();
        }
    }
}
