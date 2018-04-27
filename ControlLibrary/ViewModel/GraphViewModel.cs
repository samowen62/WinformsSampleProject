using ControlLibrary.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

namespace ControlLibrary.ViewModel
{
    public class GraphViewModel : BaseViewModel
    {

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

        public List<NameDataPoint> BarGraphFeed
        {
            get
            {
                return _wordList
                    .GroupBy(e => e)
                    .Select(e => new NameDataPoint { Freq = e.Count(), Word = e.Key })
                    .OrderBy(e => e.Word)
                    .ToList();
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
        public GraphViewModel()
        {
            var model = new ListModel();
            model.PropertyChanged += ModelPropertyChanged;
            WordList = model.List;
        }

        void ModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            WordList = (ObservableCollection<string>)sender;
        }

        void WordListChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            NotifyPropertyChanged("BarGraphFeed");
        }

        public class NameDataPoint
        {
            public string Word { get; set; }
            public int Freq { get; set; }
        }
    }
}
