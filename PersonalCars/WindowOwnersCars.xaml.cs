using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
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

namespace PersonalCars
{
    /// <summary>
    /// Логика взаимодействия для WindowOwnersCars.xaml
    /// </summary>
    public partial class WindowOwnersCars : Window
    {
        public WindowOwnersCars()
        {
            InitializeComponent();
            DBCars.db.Owners.Load();
            DBCars.db.Cars.Load();
            cbOwners.ItemsSource = DBCars.db.Owners.ToList();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            new WindowMenu().Show();
            Close();
        }

        private void cbOwners_DropDownClosed(object sender, EventArgs e)
        {
            string fio = cbOwners.Text;
            int id = 0;

            Owners owners = DBCars.db.Owners.Where(o => o.LastName + " " + o.FirstName + " " + o.Patronymic == fio).FirstOrDefault();
            if (owners != null)
            {
                id = owners.OwnerId;
                var querry =
                from Cars in DBCars.db.Cars
                where Cars.OwnerId == id
                select new { Cars.Marks, Cars.StateNumber, Cars.Colors, Cars.IsForeign };
                dgCars.ItemsSource = querry.ToList();
                lForeign.Content = "Кол-во иномарок: " + ClassSQL.Count(string.Format("SELECT COUNT(*) FROM Cars WHERE OwnerId = '{0}' AND IsForeign = 'True';", id));
            }
        }
    }
}
