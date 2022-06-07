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
    /// Логика взаимодействия для Statistic.xaml
    /// </summary>
    public partial class Statistic : Page
    {
        public Statistic(User user)
        {
            InitializeComponent();
            var data = from v in App.Context.Vizov.ToList()
                       from o in App.Context.Othot.ToList()
                       where (v.vrach == user.id) && (v.id == o.id_vizov)
                       select o ;
            

            statisticDataGrid.ItemsSource = data;
        }
    }
}
