using System;
using System.Security.Cryptography;
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
            foreach (var item in App.Context.User)
            {
                if ((item.login == null) || (item.password == null)) continue;
                if (Login.Text == item.login.ToString())
                {
                    if (Pass.Password == item.password.ToString())
                    {
                        DispetcherWin DW = new DispetcherWin();
                        VrachWin VW = new VrachWin(item);
                        if (item.role == 2)
                        {
                            DW.Show();
                            this.Close();
                            return;
                        }
                        else
                        {
                            VW.Show();
                            this.Close();
                            return;
                        }
                    }

                }
            }
            MessageBox.Show("Введён неверный логин или пароль!");

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DispetcherWin DW = new DispetcherWin();
            DW.Show();
            this.Close();
        }
        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            var us = from u in App.Context.User
                     where u.id == 3
                     select u;
            User user = new User();
            foreach (var item in us)
            {
                user = item;
            }
            VrachWin VW = new VrachWin(user);
            VW.Show();
            this.Close();
        }
    }
}
