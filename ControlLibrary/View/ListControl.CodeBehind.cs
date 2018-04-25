using ControlLibrary.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            InputText.DataBindings.Add(new System.Windows.Forms.Binding("Text", _viewModel, "NewWordText", 
                false, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));//this last part will keep it bound on enter press
        }

        private void AddToList()
        {

            _viewModel.Execute(AddBtn.Tag, null);
            InputText.Text = string.Empty;
            InputText.Focus();
            ListText.Text = _viewModel.DisplayList();
        }
    }
}
