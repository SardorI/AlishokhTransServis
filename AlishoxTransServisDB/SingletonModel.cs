using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlishoxTransServisDB
{
    public class SingletonModel : INotifyPropertyChanged
    {
        private static SingletonModel instance;
        private ObservableCollection<AutoBase> autoBases;
        private ApplicationDbContext db;

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ApplicationDbContext DataBase { get => db; }

        public ObservableCollection<AutoBase> AutoBases
        {
            get => autoBases;
            set
            {
                autoBases = value;
                RaisePropertyChanged(nameof(AutoBases));
            }
        }

        private SingletonModel()
        {         
            db = new ApplicationDbContext();
            autoBases = new ObservableCollection<AutoBase>(db.AutoBase);
        }

        public static SingletonModel GetInstance()
        {
            if (instance == null)
                instance = new SingletonModel();

            return instance;
        }
    }
}
