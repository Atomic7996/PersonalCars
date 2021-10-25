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
    /// Логика взаимодействия для WindowOwnerEdit.xaml
    /// </summary>
    public partial class WindowOwnerEdit : Window
    {
        Owners myOwner = new Owners();
        public bool isAdd = false;

        public WindowOwnerEdit(Owners owners)
        {
            InitializeComponent();
            if (owners != null)
            {
                myOwner = owners;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (IDNumber.Text.Length != 10)
            {
                MessageBox.Show("Введите корректный номер паспорта", "Уведомление");
            }
            else
            {
                int id = -1;

                Owners owner = DBCars.db.Owners.Where(o => o.IDNumber == IDNumber.Text).FirstOrDefault();
                if (owner != null)
                {
                    id = owner.OwnerId;
                }

                if (ClassSQL.IsResult(string.Format("SELECT * FROM  Owners WHERE OwnerId = '{0}'", id)) == true)
                {
                    MessageBox.Show("Владелец с таким паспортом уже существует!", "Уведомление");
                }
                else
                {
                    myOwner.LastName = LName.Text;
                    myOwner.FirstName = FName.Text;
                    myOwner.Patronymic = Patronymic.Text;
                    myOwner.IDNumber = IDNumber.Text;

                    if (isAdd == true)
                    {
                        DBCars.db.Owners.Add(myOwner);
                        DBCars.db.SaveChanges();
                        MessageBox.Show("Владелец успешно добавлен!", "Уведомление");
                    }
                    DialogResult = true;
                    Close();
                }
            }            
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void IDNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0)) || (IDNumber.Text.Length == 10))
            {
                e.Handled = true;
            }
        }

        private void LName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void FName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void Patronymic_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
