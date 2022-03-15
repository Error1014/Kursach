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

namespace Kursach
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Autorization(object sender, RoutedEventArgs e)
        {
            if (Login.Text == "rrr" )
            {
                if (Pass.Password == "123")
                {
                    MessageBox.Show("{}{}{}{}{}{}{}");
                    DispetcherWin DW = new DispetcherWin();
                    DW.Show();
                    this.Close();
                }
            }
        }
    }
}
