using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlLibrary.DAL
{
    public class DataAccess
    {
        public DataAccess()
        {
        }

        public static ObservableCollection<string> Data = new ObservableCollection<string>();

        public ObservableCollection<string> Select()
        {
            var temp = new ObservableCollection<string>();

            foreach (var s in Data)
            {
                temp.Add(s);
            }

            return temp;
        }

        public void Update(ObservableCollection<string> data)
        {
            Data = new ObservableCollection<string>();

            foreach (string s in data)
            {
                Data.Add(s);
            }

            //if (DatabaseUpdated != null)
            //    DatabaseUpdated(Data);
        }

        //NOTE: These would be necessary if the data changed in the background
        //public delegate void UpdateHandler(ObservableCollection<string> list);
        //public UpdateHandler DatabaseUpdated;
    }
}
