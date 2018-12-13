using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AlishoxTransServisDB
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private SingletonModel model;
        private AutoBase selectedAuto;

        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<AutoBase> AutoBases { get; set; }
        public AutoBase SelectedAuto { get => selectedAuto; set { selectedAuto = value; RaisePropertyChanged("SelectedAuto"); } }

        public MainWindow()
        {
            InitializeComponent();
            model = SingletonModel.GetInstance();
            AutoBases = model.AutoBases;
            DataContext = this;
        }

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void DeleteItem()
        {
            if (SelectedAuto == null)
                return;

            model.DataBase.AutoBase.Remove(SelectedAuto);
            AutoBases.Remove(SelectedAuto);
            model.DataBase.SaveChanges();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var newItems = AutoBases.Except(model.AutoBases);
            model.DataBase.AutoBase.AddRange(newItems);
            model.DataBase.SaveChanges();
            MessageBox.Show(this, "Данные сохранены <Булли дам ол>", "Сообщения", MessageBoxButton.OK, MessageBoxImage.Information);
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DeleteItem();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var AddUser = new AddNewUser();
            AddUser.Show();
        }
    
        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
                DeleteItem();
        }
    }
}
