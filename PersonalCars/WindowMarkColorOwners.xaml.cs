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

namespace PersonalCars
{
    /// <summary>
    /// Логика взаимодействия для WindowMarkColorOwners.xaml
    /// </summary>
    public partial class WindowMarkColorOwners : Window
    {
        public WindowMarkColorOwners()
        {
            InitializeComponent();
            cbColors.ItemsSource = DBCars.db.Colors.ToList();
            cbMarks.ItemsSource = DBCars.db.Marks.ToList();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            new WindowMenu().Show();
            Close();
        }

        private void cbColors_DropDownClosed(object sender, EventArgs e)
        {
            string color = cbColors.Text;
            string mark = cbMarks.Text;
            Colors colors = DBCars.db.Colors.Where(c => c.Title == color).FirstOrDefault();
            Marks marks = DBCars.db.Marks.Where(m => m.Title == mark).FirstOrDefault();

            if (colors != null && marks != null)
            {
                int colorId = colors.ColorId;
                int markId = marks.MarkId;

                var querry =
                from Cars in DBCars.db.Cars
                where Cars.ColorId == colorId && Cars.MarkId == markId
                select new { Cars.StateNumber, Cars.Owners, Cars.Owners.IDNumber };
                dgCars.ItemsSource = querry.ToList();
            }
        }
    }
}
