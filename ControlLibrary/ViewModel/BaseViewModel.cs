using System.ComponentModel;

namespace ControlLibrary.ViewModel
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Execute(object sender, object parameter)
        {
            ((IViewModelCommand)sender).Execute(parameter);
        }

        public abstract class ViewModelCommand : IViewModelCommand
        {
            public BaseViewModel _viewModel { get; set; }

            public ViewModelCommand(BaseViewModel viewModel)
            {
                _viewModel = viewModel;
            }

            public abstract void Execute(object sender);
        }

    }
}
