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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PersonalCars
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Staff staff { get; set; }

        public WindowMenu WindowMenu
        {
            get => default;
            set
            {
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Staff staff = DBCars.db.Staff.Where(s => s.Login == Login.Text).FirstOrDefault();

            if (staff != null)
            {
                if (staff.Password == Pass.Password)
                {
                    new WindowMenu().Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Введите верный пароль", "Уведомление");
                }
            }
            else
            {
                MessageBox.Show("Введите верный логин", "Уведомление");
            }
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            WindowStaffEdit windowStaffEdit = new WindowStaffEdit(staff);
            windowStaffEdit.isAdd = true;
            windowStaffEdit.ShowDialog();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
