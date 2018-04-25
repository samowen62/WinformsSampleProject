using ControlLibrary.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlLibrary.ViewModel
{
    public class ListViewModel : INotifyPropertyChanged
    {
        //bound to view
        public string NewWordText { get; set; }

        private ICommand _addToListCommand;
        public ICommand AddToListCommand
        {
            get
            {
                return _addToListCommand ?? (_addToListCommand = new AddToListCommand(this));
            }
        }

        private ICommand _textChangedCommand;
        public ICommand TextChangedCommand
        {
            get
            {
                return _textChangedCommand ?? (_textChangedCommand = new TextChangedCommand(this));
            }
        }

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

        // attach view model to model.
        public ListViewModel()
        {
            var model = new ListModel();
            model.PropertyChanged += ModelPropertyChanged;
            WordList = model.List;
        }

        public string DisplayList()
        {
            return string.Join("\n", _wordList);
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
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        //TODO: good to abstract to view model parent
        public void Execute(object sender, object parameter)
        {
            ((ICommand)sender).Execute(parameter);
        }

    }

    //these ICommands will basically tell how to react to events
    public class AddToListCommand : ICommand
    {
        public ListViewModel _viewModel { get; set; }

        public AddToListCommand(ListViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public void Execute(object sender)
        {
            _viewModel.WordList.Add(_viewModel.NewWordText);
        }
    }

    public class TextChangedCommand : ICommand
    {
        public TextChangedCommand(ListViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public ListViewModel _viewModel { get; set; }

        public void Execute(object sender)
        {
            _viewModel.NewWordText = sender.ToString();
        }
    }
}

