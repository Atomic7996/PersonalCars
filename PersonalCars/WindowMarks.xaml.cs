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
    /// Логика взаимодействия для WindowMarks.xaml
    /// </summary>
    public partial class WindowMarks : Window
    {
        static Marks marks { get; set; }

        public WindowMarkEdit WindowMarkEdit
        {
            get => default;
            set
            {
            }
        }

        WindowMarkEdit windowMarksEdit = new WindowMarkEdit(marks);

        public WindowMarks()
        {
            InitializeComponent();
            DBCars.db.Marks.Load();
            dgMarks.ItemsSource = DBCars.db.Marks.ToList();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            new WindowMenu().Show();
            Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            windowMarksEdit = new WindowMarkEdit(marks);
            windowMarksEdit.isAdd = true;

            if (windowMarksEdit.ShowDialog() == true)
            {
                DBCars.db.SaveChanges();
                dgMarks.ItemsSource = DBCars.db.Marks.ToList();
                dgMarks.Items.Refresh();
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            marks = dgMarks.SelectedItem as Marks;
            windowMarksEdit = new WindowMarkEdit(marks);

            windowMarksEdit.Mark.Text = marks.Title;

            if (windowMarksEdit.ShowDialog() == true)
            {
                DBCars.db.SaveChanges();
                dgMarks.ItemsSource = DBCars.db.Marks.ToList();
                dgMarks.Items.Refresh();
            }
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            marks = dgMarks.SelectedItem as Marks;
            int id = -1;

            Marks mark = DBCars.db.Marks.Where(m => m.Title == marks.Title).FirstOrDefault();
            id = mark.MarkId;

            if (ClassSQL.IsResult(string.Format("SELECT * FROM Cars a JOIN Marks b ON a.markId = b.MarkId WHERE b.MarkId = '{0}'", id)) == true)
            {
                MessageBox.Show("Вы не можете удалить запись!", "Уведомление");
            }
            else
            {
                MessageBoxResult res = MessageBox.Show("Вы действительно хотите удалить запись?", "Предупреждение!", MessageBoxButton.YesNo);
                if (res == MessageBoxResult.Yes)
                {
                    MessageBox.Show("Запись удалена", "Уведомление");
                    DBCars.db.Marks.Remove(marks);
                    DBCars.db.SaveChanges();
                    dgMarks.ItemsSource = DBCars.db.Marks.ToList();
                    dgMarks.Items.Refresh();
                }
            }
        }
    }
}
