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
    /// Логика взаимодействия для WindowColors.xaml
    /// </summary>
    public partial class WindowColors : Window
    {
        static Colors colors { get; set; }

        public WindowColorEdit WindowColorEdit
        {
            get => default;
            set
            {
            }
        }

        WindowColorEdit windowColorEdit = new WindowColorEdit(colors);

        public WindowColors()
        {
            InitializeComponent();
            DBCars.db.Colors.Load();
            dgColors.ItemsSource = DBCars.db.Colors.ToList();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            new WindowMenu().Show();
            Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            windowColorEdit = new WindowColorEdit(colors);
            windowColorEdit.isAdd = true;

            if (windowColorEdit.ShowDialog() == true)
            {
                DBCars.db.SaveChanges();
                dgColors.ItemsSource = DBCars.db.Colors.ToList();
                dgColors.Items.Refresh();
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            colors = dgColors.SelectedItem as Colors;
            windowColorEdit = new WindowColorEdit(colors);

            windowColorEdit.Color.Text = colors.Title;

            if (windowColorEdit.ShowDialog() == true)
            {
                DBCars.db.SaveChanges();
                dgColors.ItemsSource = DBCars.db.Colors.ToList();
                dgColors.Items.Refresh();
            }
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            colors = dgColors.SelectedItem as Colors;
            int id = -1;

            Colors color = DBCars.db.Colors.Where(c => c.Title == colors.Title).FirstOrDefault();
            id = color.ColorId;

            if (ClassSQL.IsResult(string.Format("SELECT * FROM Cars a JOIN Colors b ON a.ColorId = b.ColorId WHERE b.ColorId = '{0}'", id)) == true)
            {
                MessageBox.Show("Вы не можете удалить запись!", "Уведомление");
            }
            else
            {
                MessageBoxResult res = MessageBox.Show("Вы действительно хотите удалить запись?", "Предупреждение!", MessageBoxButton.YesNo);
                if (res == MessageBoxResult.Yes)
                {
                    MessageBox.Show("Запись удалена", "Уведомление");
                    DBCars.db.Colors.Remove(colors);
                    DBCars.db.SaveChanges();
                    dgColors.ItemsSource = DBCars.db.Colors.ToList();
                    dgColors.Items.Refresh();
                }
            } 
        }
    }
}
