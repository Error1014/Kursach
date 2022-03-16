﻿using System;
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
                if (Login.Text == item.login.ToString())
                {
                    if (Pass.Password == item.password.ToString())
                    {
                        Pass.Password = item.password.ToString();
                        DispetcherWin DW = new DispetcherWin();
                        DW.Show();
                        this.Close();
                        return;
                    }
                    break;
                }
            }
            MessageBox.Show("Неверный логин или пароль");

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            Kursach.SpeedHelp2DataSet speedHelp2DataSet = ((Kursach.SpeedHelp2DataSet)(this.FindResource("speedHelp2DataSet")));
            // Загрузить данные в таблицу User. Можно изменить этот код как требуется.
            Kursach.SpeedHelp2DataSetTableAdapters.UserTableAdapter speedHelp2DataSetUserTableAdapter = new Kursach.SpeedHelp2DataSetTableAdapters.UserTableAdapter();
            speedHelp2DataSetUserTableAdapter.Fill(speedHelp2DataSet.User);
            System.Windows.Data.CollectionViewSource userViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("userViewSource")));
            userViewSource.View.MoveCurrentToFirst();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DispetcherWin DW = new DispetcherWin();
            DW.Show();
        }
    }
}
