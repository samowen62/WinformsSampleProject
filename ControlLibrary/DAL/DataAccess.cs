using System.Collections.ObjectModel;

namespace ControlLibrary.DAL
{
    public class DataAccess
    {
        private DataAccess()
        {

        }

        private static DataAccess _instance;
        public static DataAccess Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DataAccess();
                }
                return _instance;
            }
        }

        public static ObservableCollection<string> Data = new ObservableCollection<string>();

        public ObservableCollection<string> Select()
        {
            return Data;
        }

        public void Update(ObservableCollection<string> data)
        {
            Data = new ObservableCollection<string>();

            foreach (string s in data)
            {
                Data.Add(s);
            }

            DatabaseUpdated?.Invoke(Data);
        }

        public delegate void UpdateHandler(ObservableCollection<string> list);
        public UpdateHandler DatabaseUpdated;
    }
}
