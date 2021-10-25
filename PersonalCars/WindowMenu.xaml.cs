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
    /// Логика взаимодействия для WindowMenu.xaml
    /// </summary>
    public partial class WindowMenu : Window
    {
        public WindowMenu()
        {
            InitializeComponent();
        }

        public WindowOwnersCars WindowOwnersCars
        {
            get => default;
            set
            {
            }
        }

        public WindowMarkColorOwners WindowMarkColorOwners
        {
            get => default;
            set
            {
            }
        }

        public WindowCars WindowCars
        {
            get => default;
            set
            {
            }
        }

        public WindowColors WindowColors
        {
            get => default;
            set
            {
            }
        }

        public WindowMarks WindowMarks
        {
            get => default;
            set
            {
            }
        }

        public WindowOwners WindowOwners
        {
            get => default;
            set
            {
            }
        }

        public WindowStaff WindowStaff
        {
            get => default;
            set
            {
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }

        private void btnCars_Click(object sender, RoutedEventArgs e)
        {
            new WindowCars().Show();
            Close();
        }

        private void btnColors_Click(object sender, RoutedEventArgs e)
        {
            new WindowColors().Show();
            Close();
        }

        private void btnMarks_Click(object sender, RoutedEventArgs e)
        {
            new WindowMarks().Show();
            Close();
        }

        private void btnOwners_Click(object sender, RoutedEventArgs e)
        {
            new WindowOwners().Show();
            Close();
        }

        private void btnStaff_Click(object sender, RoutedEventArgs e)
        {
            new WindowStaff().Show();
            Close();
        }

        private void btnOC_Click(object sender, RoutedEventArgs e)
        {
            new WindowOwnersCars().Show();
            Close();
        }

        private void btnMAO_Click(object sender, RoutedEventArgs e)
        {
            new WindowMarkColorOwners().Show();
            Close();
        }
    }
}
