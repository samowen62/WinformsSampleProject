using ControlLibrary.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ControlLibrary.ViewModel
{
    /// <summary>
    /// Mainly just listens to the model and updates on changes
    /// </summary>
    public class GraphViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<string> _wordList;
        public ObservableCollection<string> WordList
        {
            get
            {
                return _wordList;
            }

            set
            {
                _wordList = value;
                _wordList.CollectionChanged += MyPropertyCollectionChanged;
            }
        }
        //TODO:delete
        public string TestText { get; set; }
        public string SomeText { get { return WordList.Count + "!"; } }

        // attach view model to model.
        public GraphViewModel()
        {
            var model = new ListModel();
            model.PropertyChanged += ModelPropertyChanged;
            WordList = model.List;
        }

        void ModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            WordList = (ObservableCollection<string>)sender; //For Get any new entity Changed 
        }

        void MyPropertyCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            {
                NotifyPropertyChanged("WordList");
            }
        }

        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        //TODO: good to abstract to view model parent
        public void Execute(object sender, object parameter)
        {
            ((ICommand)sender).Execute(parameter);
        }

    }
}

