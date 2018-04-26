using ControlLibrary.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

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

        public List<NameDataPoint> BarGraphFeed {
            get
            {
                return _wordList
                    .GroupBy(e => e)
                    .Select(e => new NameDataPoint { Freq = e.Count(), Word = e.Key })
                    .OrderBy(e => e.Word)
                    .ToList();
            }
        }

        public string DisplayEntries {
            get {
                return string.Join("\n",_wordList);
            }
        }

        public string DisplayEntryCount
        {
            get
            {
                return $"{_wordList.Count()} entries";
            }
        }

        #endregion

        // attach view model to model.
        public ListViewModel()
        {
            var model = new ListModel();
            model.PropertyChanged += ModelPropertyChanged;
            WordList = model.List;
        }

        void ModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            WordList = (ObservableCollection<string>)sender; //For Get any new entity Changed 
        }

        void WordListChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            {
                NotifyPropertyChanged("WordList");
                NotifyPropertyChanged("DisplayEntries");
                NotifyPropertyChanged("BarGraphFeed");
            }
        }

        public class NameDataPoint
        {
            public string Word { get; set; }
            public int Freq { get; set; }
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

