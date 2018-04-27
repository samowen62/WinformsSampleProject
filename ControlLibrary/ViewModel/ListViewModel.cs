using ControlLibrary.Model;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace ControlLibrary.ViewModel
{
    public class ListViewModel : BaseViewModel
    {
        //bound to view
        public string NewWordText { get; set; }

        private IViewModelCommand _addToListCommand;
        public IViewModelCommand AddToListCommand
        {
            get
            {
                return _addToListCommand ?? (_addToListCommand = new AddToList(this));
            }
        }

        private IViewModelCommand _textChangedCommand;
        public IViewModelCommand TextChangedCommand
        {
            get
            {
                return _textChangedCommand ?? (_textChangedCommand = new TextChanged(this));
            }
        }

        #region view bindings

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
                _wordList.CollectionChanged += WordListChanged;
            }
        }

        public string DisplayEntries {
            get {
                return string.Join("\r\n",_wordList);
            }
        }

        #endregion

        // attach view model to model.
        public ListViewModel()
        {
            var model = new ListModel();
            model.PropertyChanged += ModelPropertyChanged; //effectively functions as a subscriber to events changing
            WordList = model.List;
        }

        void ModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            WordList = (ObservableCollection<string>)sender; //will trigger WordListChanged which triggers NotifyPropertyChanged
        }

        void WordListChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            NotifyPropertyChanged("WordList");
        }

        //these ICommands will basically tell how to react to events
        public class AddToList : ViewModelCommand
        {
            public AddToList(BaseViewModel viewModel) : base(viewModel)
            {
            }

            public override void Execute(object sender)
            {
                (_viewModel as ListViewModel).WordList.Add((_viewModel as ListViewModel).NewWordText);
            }
        }

        public class TextChanged : ViewModelCommand
        {
            public TextChanged(BaseViewModel viewModel) : base(viewModel)
            {
            }

            public override void Execute(object sender)
            {
                (_viewModel as ListViewModel).NewWordText = sender.ToString();
            }
        }
    }
}

