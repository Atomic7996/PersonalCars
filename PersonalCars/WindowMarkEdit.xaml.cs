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
    /// Логика взаимодействия для WindowMarkEdit.xaml
    /// </summary>
    public partial class WindowMarkEdit : Window
    {
        Marks myMark = new Marks();
        public bool isAdd = false;

        public WindowMarkEdit(Marks marks)
        {
            InitializeComponent();
            if (marks != null)
            {
                myMark = marks;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            int id = -1;

            Marks mark = DBCars.db.Marks.Where(m => m.Title == Mark.Text).FirstOrDefault();
            if (mark != null)
            {
                id = mark.MarkId;
            }

            if (ClassSQL.IsResult(string.Format("SELECT * FROM Marks WHERE MarkId = '{0}'", id)) == true)
            {
                MessageBox.Show("Марка с таким названием уже существует!", "Уведомление");
            }
            else
            {
                myMark.Title = Mark.Text;

                if (isAdd == true)
                {
                    DBCars.db.Marks.Add(myMark);
                    DBCars.db.SaveChanges();
                    MessageBox.Show("Марка успешно добавлена!", "Уведомление");
                }
                DialogResult = true;
                Close();
            }           
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
