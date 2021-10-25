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
    /// Логика взаимодействия для WindowColorEdit.xaml
    /// </summary>
    public partial class WindowColorEdit : Window
    {
        Colors myColor = new Colors();
        public bool isAdd = false;

        public WindowColorEdit(Colors colors)
        {
            InitializeComponent();
            if (colors != null)
            {
                myColor = colors;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            int id = -1;

            Colors color = DBCars.db.Colors.Where(c => c.Title == Color.Text).FirstOrDefault();
            if (color != null)
            {
                id = color.ColorId;
            }

            if (ClassSQL.IsResult(string.Format("SELECT * FROM Colors WHERE ColorId = '{0}'", id)) == true)
            {
                MessageBox.Show("Цвет с таким названием уже существует!", "Уведомление");
            }
            else
            {
                myColor.Title = Color.Text;

                if (isAdd == true)
                {
                    DBCars.db.Colors.Add(myColor);
                    DBCars.db.SaveChanges();
                    MessageBox.Show("Цвет успешно добавлен!", "Уведомление");
                }
                DialogResult = true;
                Close();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Color_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
