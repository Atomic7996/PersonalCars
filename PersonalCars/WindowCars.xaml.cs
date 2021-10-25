using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для WindowCars.xaml
    /// </summary>
    public partial class WindowCars : Window
    {
        static Cars cars { get; set; }

        public WindowCarEdit WindowCarEdit
        {
            get => default;
            set
            {
            }
        }

        WindowCarEdit windowCarEdit = new WindowCarEdit(cars);

        public WindowCars()
        {
            InitializeComponent();
            DBCars.db.Cars.Load();
            dgCars.ItemsSource = DBCars.db.Cars.ToList();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            new WindowMenu().Show();
            Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            cars = dgCars.SelectedItem as Cars;
            windowCarEdit = new WindowCarEdit(cars);
            windowCarEdit.isAdd = true;
            if (windowCarEdit.ShowDialog() == true)
            {
                DBCars.db.SaveChanges();
                dgCars.ItemsSource = DBCars.db.Cars.ToList();
                dgCars.Items.Refresh();
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            cars = dgCars.SelectedItem as Cars;
            windowCarEdit = new WindowCarEdit(cars);

            windowCarEdit.RegNumber.Text = cars.RegNumber;
            windowCarEdit.Owner.SelectedIndex = (int)cars.OwnerId - 1;
            windowCarEdit.StateNumber.Text = cars.StateNumber;
            windowCarEdit.ReleaseYear.Text = cars.ReleaseYear.ToString();
            windowCarEdit.Color.SelectedIndex = (int)cars.ColorId - 1;
            windowCarEdit.Mark.SelectedIndex = (int)cars.MarkId - 1;
            windowCarEdit.IsForeign.IsChecked = cars.IsForeign;

            if (windowCarEdit.ShowDialog() == true)
            {
                DBCars.db.SaveChanges();
                dgCars.ItemsSource = DBCars.db.Cars.ToList();
                dgCars.Items.Refresh();
            }
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            cars = dgCars.SelectedItem as Cars;

            MessageBoxResult res = MessageBox.Show("Вы действительно хотите удалить запись?", "Предупреждение!", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                MessageBox.Show("Запись удалена", "Уведомление");
                DBCars.db.Cars.Remove(cars);
                DBCars.db.SaveChanges();
                dgCars.ItemsSource = DBCars.db.Cars.ToList();
                dgCars.Items.Refresh();
            }
        }
    }
}
