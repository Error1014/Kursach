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
        private User _curentUser = new User();

        public DispetcherWin()
        {
            InitializeComponent();
            DataContext = _curentUser;
            listVrach.ItemsSource = App.Context.User.ToList();
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
            //vizov.symptom = Symptom.
            vizov.pacient = pacient.id;
            vizov.date_vizov = DateTime.Now;
            vizov.time_vizov = new TimeSpan();
            //vizov.vrach = vrachComboBox.
            App.Context.Vizov.Add(vizov);
            Familia.Text = "";
            Name.Text = "";
            Otch.Text = "";
            
            Phone.Text = "";
            Adres.Text = "";
            App.Context.SaveChanges();
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            Kursach.SpeedHelp2DataSet speedHelp2DataSet = ((Kursach.SpeedHelp2DataSet)(this.FindResource("speedHelp2DataSet")));
            // Загрузить данные в таблицу User. Можно изменить этот код как требуется.
            Kursach.SpeedHelp2DataSetTableAdapters.UserTableAdapter speedHelp2DataSetUserTableAdapter = new Kursach.SpeedHelp2DataSetTableAdapters.UserTableAdapter();
            speedHelp2DataSetUserTableAdapter.Fill(speedHelp2DataSet.User);
            System.Windows.Data.CollectionViewSource userViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("userViewSource")));
            userViewSource.View.MoveCurrentToFirst();
            System.Windows.Data.CollectionViewSource vizovViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("vizovViewSource")));
            // Загрузите данные, установив свойство CollectionViewSource.Source:
            // vizovViewSource.Source = [универсальный источник данных]
        }
    }
}
