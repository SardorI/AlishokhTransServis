using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace AlishoxTransServisDB
{
    /// <summary>
    /// Логика взаимодействия для AddNewUser.xaml
    /// </summary>
    public partial class AddNewUser : Window
    {
        private SingletonModel model;

        public AddNewUser()
        {
            InitializeComponent();
            model = SingletonModel.GetInstance();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckData())
                return;

            var missingId = MissingId(model.AutoBases);

            model.AutoBases.Add(new AutoBase()
            {
                Id = missingId,
                Name = nameTB.Text,
                Number = numberTB.Text,
                LicenseDate = DateTime.Parse(licenseDateTB.Text),
                InsuranceDate = DateTime.Parse(insuranceDateTB.Text)
            });
            model.DataBase.AutoBase.Add(new AutoBase()
            {
                Id = missingId,
                Name = nameTB.Text,
                Number = numberTB.Text,
                LicenseDate = DateTime.Parse(licenseDateTB.Text),
                InsuranceDate = DateTime.Parse(insuranceDateTB.Text)
            });

            model.DataBase.SaveChanges();

            nameTB.Text = String.Empty;
            numberTB.Text = String.Empty;
            licenseDateTB.Text = String.Empty;
            insuranceDateTB.Text = String.Empty;
        }

        private int MissingId(IEnumerable<AutoBase> autoBases)
        {
            var missingIds = Enumerable.Range(1, autoBases.LastOrDefault().Id + 1).Except(autoBases.Select(u => u.Id));
            return missingIds.FirstOrDefault();
        }

        private bool CheckData()
        {
            DateTime date;
            //Please fill the name data
            if (nameTB.Text == String.Empty)
            {
                MessageBox.Show(this, "Али кутогим давоминиям ёз оти юхтике", "Error ХАТО", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if(numberTB.Text == String.Empty)
            //Please fill the number data
            {
                MessageBox.Show(this, "Али кутогим давоминиям ёз, автобус номерины йозмисанми?", "Error ХАТО", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (!DateTime.TryParse(licenseDateTB.Text, out date))
            //Please fill or correct the license date
            {
                MessageBox.Show(this, "Али кутогим давоминиям ёз, числоси нотугри БЛЯ", "Error ХАТО", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (!DateTime.TryParse(insuranceDateTB.Text, out date))
            //Please fill or correct the insurance date
            {
                MessageBox.Show(this, "Али кутогим давоминиям ёз, числоси нотугри БЛЯ", "Error ХАТО", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }
    }
}
