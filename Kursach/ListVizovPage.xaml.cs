using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kursach
{
    /// <summary>
    /// Логика взаимодействия для ListVizovPage.xaml
    /// </summary>
    public partial class ListVizovPage : Page
    {
        public ListVizovPage()
        {
            InitializeComponent();
            var data = from v in App.Context.Vizov.ToList()
                       where v.vrach == 9
                       select v;
            Console.WriteLine(data);
            vizovDataGrid.DataContext = data;
        }

        private void SelectedVizow(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("DEBUG + " + vizovDataGrid.SelectedItem);
            var id = (vizovDataGrid.SelectedItem as Vizov).id;

            var selectVizov = from sV in App.Context.Vizov.ToList()
                              where sV.id == id
                              select sV;
            Vizov SelectVizov = new Vizov();
            foreach (var item in selectVizov)
            {
                SelectVizov = item;
            }
            DispetcherWin DV = (DispetcherWin)Window.GetWindow(this);
            DV.DispetcherFrame.Content = new AddVizovPage(SelectVizov);
        }
    }
}
