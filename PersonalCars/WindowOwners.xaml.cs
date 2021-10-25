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
    /// Логика взаимодействия для WindowOwners.xaml
    /// </summary>
    public partial class WindowOwners : Window
    {
        static Owners owners { get; set; }

        public WindowOwnerEdit WindowOwnerEdit
        {
            get => default;
            set
            {
            }
        }

        WindowOwnerEdit windowOwnerEdit = new WindowOwnerEdit(owners);

        public WindowOwners()
        {
            InitializeComponent();
            DBCars.db.Owners.Load();
            dgOwners.ItemsSource = DBCars.db.Owners.ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            owners = dgOwners.SelectedItem as Owners;
            windowOwnerEdit = new WindowOwnerEdit(owners);
            windowOwnerEdit.isAdd = true;

            if (windowOwnerEdit.ShowDialog() == true)
            {
                DBCars.db.SaveChanges();
                dgOwners.ItemsSource = DBCars.db.Owners.ToList();
                dgOwners.Items.Refresh();
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            new WindowMenu().Show();
            Close();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            owners = dgOwners.SelectedItem as Owners;
            windowOwnerEdit = new WindowOwnerEdit(owners);

            windowOwnerEdit.LName.Text = owners.LastName;
            windowOwnerEdit.FName.Text = owners.FirstName;
            windowOwnerEdit.Patronymic.Text = owners.Patronymic;
            windowOwnerEdit.IDNumber.Text = owners.IDNumber;
            windowOwnerEdit.isAdd = false;

            if (windowOwnerEdit.ShowDialog() == true)
            {
                DBCars.db.SaveChanges();
                dgOwners.ItemsSource = DBCars.db.Owners.ToList();
                dgOwners.Items.Refresh();
            }
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            owners = dgOwners.SelectedItem as Owners;
            int id = -1;

            Owners owner = DBCars.db.Owners.Where(o => o.LastName + " " + o.FirstName + " " + o.Patronymic == owners.LastName + " " + owners.FirstName + " " + owners.Patronymic).FirstOrDefault();
            id = owner.OwnerId;

            if (ClassSQL.IsResult(string.Format("SELECT * FROM Cars a JOIN Owners b ON a.OwnerId = b.OwnerId WHERE b.OwnerId = '{0}'", id)) == true)
            {
                MessageBox.Show("Вы не можете удалить запись!", "Уведомление");
            }
            else
            {
                MessageBoxResult res = MessageBox.Show("Вы действительно хотите удалить запись?", "Предупреждение!", MessageBoxButton.YesNo);
                if (res == MessageBoxResult.Yes)
                {
                    MessageBox.Show("Запись удалена", "Уведомление");
                    DBCars.db.Owners.Remove(owners);
                    DBCars.db.SaveChanges();
                    dgOwners.ItemsSource = DBCars.db.Owners.ToList();
                    dgOwners.Items.Refresh();
                }
            }
        }
    }
}
