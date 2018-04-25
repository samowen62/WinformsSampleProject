using ControlLibrary.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlLibrary.Model
{
    public class ListModel : INotifyPropertyChanged
    {
        public readonly DataAccess _dal = new DataAccess();

        public ObservableCollection<string> List { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ListModel()
        {
            List = _dal.Select();

            //_dal.DatabaseUpdated += UpdataFromDal;

            //NOTE: when item is added removed etc. from list
            List.CollectionChanged += ListCollectionChanged;
        }

        private void ListCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            _dal.Update(List);
        }
    }
}
