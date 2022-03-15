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
        }

        private void AddNewVizov(object sender, RoutedEventArgs e)
        {
            Pacient pacient = new Pacient();
            Vizov vizov = new Vizov();
            pacient.familia = Familia.Text;
            pacient.name = Name.Text;
            pacient.otch = Otch.Text;
            App.Context.Pacient.Add(pacient);
            vizov.phone = Phone.Text;
            vizov.adres = Adres.Text;
            vizov.symptom = Symptom.Document.ToString();
            vizov.pacient = pacient.id;
            vizov.date_vizov = DateTime.Now;
            //vizov.time_vizov = DateTime.;
            App.Context.Vizov.Add(vizov);
            App.Context.SaveChanges();
        }
    }
}
