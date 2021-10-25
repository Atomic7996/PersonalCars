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
    /// Логика взаимодействия для WindowStaffEdit.xaml
    /// </summary>
    public partial class WindowStaffEdit : Window
    {
        Staff myStaff = new Staff();
        public bool isAdd = false;

        public WindowStaffEdit(Staff staff)
        {
            InitializeComponent();
            if (staff != null)
            {
                myStaff = staff;
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            int id = -1;

            Staff staff = DBCars.db.Staff.Where(s => s.Login == Login.Text).FirstOrDefault();
            if (staff != null)
            {
                id = staff.StaffId;
            }

            if (ClassSQL.IsResult(string.Format("SELECT * FROM  Staff WHERE StaffId = '{0}'", id)) == true)
            {
                MessageBox.Show("Сотрудник с таким логином уже существует!", "Уведомление");
            }
            else
            {
                myStaff.Login = Login.Text;
                myStaff.Password = Password.Text;

                if (isAdd == true)
                {
                    DBCars.db.Staff.Add(myStaff);
                    DBCars.db.SaveChanges();
                    MessageBox.Show("Сотрудник успешно добавлен!", "Уведомление");
                }
                DialogResult = true;
                Close();
            }
        }
    }
}
