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
    /// Логика взаимодействия для WindowStaff.xaml
    /// </summary>
    public partial class WindowStaff : Window
    {
        static Staff staff { get; set; }

        public WindowStaffEdit WindowStaffEdit
        {
            get => default;
            set
            {
            }
        }

        WindowStaffEdit windowStaffEdit = new WindowStaffEdit(staff);

        public WindowStaff()
        {
            InitializeComponent();
            DBCars.db.Staff.Load();
            dgStaff.ItemsSource = DBCars.db.Staff.ToList();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            new WindowMenu().Show();
            Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            windowStaffEdit = new WindowStaffEdit(staff);
            windowStaffEdit.isAdd = true;

            if (windowStaffEdit.ShowDialog() == true)
            {
                DBCars.db.SaveChanges();
                dgStaff.ItemsSource = DBCars.db.Staff.ToList();
                dgStaff.Items.Refresh();
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            staff = dgStaff.SelectedItem as Staff;
            windowStaffEdit = new WindowStaffEdit(staff);
            
            windowStaffEdit.Login.Text = staff.Login;
            windowStaffEdit.Password.Text = staff.Password;

            if (windowStaffEdit.ShowDialog() == true)
            {
                DBCars.db.SaveChanges();
                dgStaff.ItemsSource = DBCars.db.Staff.ToList();
                dgStaff.Items.Refresh();
            }
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            staff = dgStaff.SelectedItem as Staff;

            MessageBoxResult res = MessageBox.Show("Вы действительно хотите удалить запись?", "Предупреждение!", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                MessageBox.Show("Запись удалена", "Уведомление");
                DBCars.db.Staff.Remove(staff);
                DBCars.db.SaveChanges();
                dgStaff.ItemsSource = DBCars.db.Staff.ToList();
                dgStaff.Items.Refresh();
            }
        }
    }
}
