using ControlLibrary.DAL;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ControlLibrary.Model
{
    /// <summary>
    /// Implemented as a singleton
    /// </summary>
    public class ListModel : INotifyPropertyChanged
    {
        public readonly DataAccess _dal = DataAccess.Instance;

        public ObservableCollection<string> List { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ListModel()
        {
            List = _dal.Select();
            List.CollectionChanged += ListCollectionChanged;
            //TODO:not sure if necessary
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("List"));
        }

        private void ListCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            _dal.Update(List);
        }
    }
}
