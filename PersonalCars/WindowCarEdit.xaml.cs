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
    /// Логика взаимодействия для WindowCarEdit.xaml
    /// </summary>
    public partial class WindowCarEdit : Window
    {
        Cars myCar = new Cars();
        public bool isAdd = false;

        public WindowCarEdit(Cars cars)
        {
            InitializeComponent();
            if (cars != null)
            {
                myCar = cars;
            }
            Owner.ItemsSource = DBCars.db.Owners.ToList();
            Color.ItemsSource = DBCars.db.Colors.ToList();
            Mark.ItemsSource = DBCars.db.Marks.ToList();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if ((ReleaseYear.Text.Length != 4) || (RegNumber.Text.Length != 10) || (StateNumber.Text.Length != 9) || (int.Parse(ReleaseYear.Text) < 1885))
            {
                MessageBox.Show("Введите корректный данные", "Уведомление");
            }
            else
            {
                int id = -1;

                Cars car = DBCars.db.Cars.Where(c => c.RegNumber == RegNumber.Text || c.StateNumber == StateNumber.Text).FirstOrDefault();
                if (car != null)
                {
                    id = car.CarId;
                }

                if (ClassSQL.IsResult(string.Format("SELECT * FROM Cars WHERE CarId = '{0}'", id)) == true)
                {
                    MessageBox.Show("Автомобиль с таким номером уже существует!", "Уведомление");
                }
                else
                {
                    myCar.RegNumber = RegNumber.Text;
                    myCar.Owners = Owner.SelectedItem as Owners;
                    myCar.StateNumber = StateNumber.Text;
                    myCar.ReleaseYear = int.Parse(ReleaseYear.Text);
                    myCar.Colors = Color.SelectedItem as Colors;
                    myCar.Marks = Mark.SelectedItem as Marks;
                    myCar.IsForeign = (bool)IsForeign.IsChecked;

                    if (isAdd == true)
                    {
                        DBCars.db.Cars.Add(myCar);
                        DBCars.db.SaveChanges();
                        MessageBox.Show("Автомобиль успешно добавлен!", "Уведомление");
                        DialogResult = true;
                        Close();
                    }
                }
            }
        }

        private void ReleaseYear_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0)) || (ReleaseYear.Text.Length == 4))
            {
                e.Handled = true;
            }
        }

        private void RegNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (RegNumber.Text.Length == 10)
            {
                e.Handled = true;
            }
        }

        private void StateNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (StateNumber.Text.Length == 9)
            {
                e.Handled = true;
            }
        }
    }
}
