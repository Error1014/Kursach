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

namespace Kursach
{
    /// <summary>
    /// Логика взаимодействия для DispetcherWin.xaml
    /// </summary>
    public partial class DispetcherWin : Window
    {

        public DispetcherWin()
        {
            InitializeComponent();
            DispetcherFrame.Content = new AddVizovPage(null);
        }

        private void AddVizov(object sender, RoutedEventArgs e)
        {
            DispetcherFrame.Content = new AddVizovPage(null);
        }
        private void Exit(object sender, RoutedEventArgs e)
        {
            MainWindow MW = new MainWindow();
            MW.Show();
            this.Close();
        }

        private void ListVizov(object sender, RoutedEventArgs e)
        {
            DispetcherFrame.Content = new ListVizovPage(0);
        }
        private void ListActivVizov(object sender, RoutedEventArgs e)
        {
            DispetcherFrame.Content = new ListVizovPage(1);
        }
        public void AddVizov(Vizov vizov)
        {
            DispetcherFrame.Content = new AddVizovPage(vizov);
        }

    }
}
