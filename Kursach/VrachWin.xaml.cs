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
    /// Логика взаимодействия для VrachWin.xaml
    /// </summary>
    public partial class VrachWin : Window
    {
        public User thisVrach;
        private bool isStart = false;
        public VrachWin(User myUser)
        {
            InitializeComponent();
            thisVrach= myUser;
            VrachFrame.Content =new GetSetVizov(myUser);
        }


        public void RestartPage(User myUser)
        {
            VrachFrame.Content = new GetSetVizov(myUser);
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            MainWindow MW = new MainWindow();
            MW.Show();
            this.Close();
        }

        private void ShowMyVizov(object sender, RoutedEventArgs e)
        {
            VrachFrame.Content = new GetSetVizov(thisVrach);
        }

        private void ShowStatisic(object sender, RoutedEventArgs e)
        {
            VrachFrame.Content = new Statistic(thisVrach);
        }
    }
}
