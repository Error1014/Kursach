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
    /// Логика взаимодействия для AddVizovPage.xaml
    /// </summary>
    public partial class AddVizovPage : Page
    {

        private User _curentUser = new User();
        public AddVizovPage()
        {
            InitializeComponent();
            List<User> u = new List<User>();
            foreach (var item in App.Context.User)
            {
                u.Add(item);
            }
            GetListVrach();
            listTypeVizov.ItemsSource = App.Context.type_vizov.ToList();
        }

        public void GetListVrach()
        {
            listVrach.ItemsSource = from p in App.Context.User.ToList()
                                    where (p.role == 1) && (p.is_free == true)
                                    select p;
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
            if (string.IsNullOrWhiteSpace(Adres.Text) == false)
            {
                vizov.adres = Adres.Text;
            }
            else
            {
                MessageBox.Show("Куда врачей посылаешь?");
                return;
            }
            vizov.isEnd = false;

            vizov.symptom = Symptom.Text;

            if (string.IsNullOrWhiteSpace(Age.Text) == false)
            {
                pacient.age = Age.Text;
            }
            else
            {
                pacient.age = null;
            }
            int indexUser = 0;
            if (listVrach.SelectedValue == null)
            {
                MessageBox.Show("Укажите врача");
                return;
            }
            else
            {
                vizov.vrach = (int)listVrach.SelectedValue;
                indexUser = listVrach.SelectedIndex;
            }
            User selectUser = (User)listVrach.Items[indexUser];
            selectUser.is_free = false;
            GetListVrach();
            if (listTypeVizov.SelectedValue == null)
            {
                MessageBox.Show("Укажите тип вызова");
                return;
            }
            else
            {
                vizov.type = (int)listTypeVizov.SelectedValue;
            }
            user_vizov uv = new user_vizov();
            uv.id_user = selectUser.id;
            uv.id_vizov = vizov.id;
            vizov.pacient = pacient.id;
            vizov.date_vizov = DateTime.Now;
            App.Context.Vizov.Add(vizov);
            App.Context.user_vizov.Add(uv);
            Familia.Text = "";
            Name.Text = "";
            Otch.Text = "";
            Phone.Text = "";
            Adres.Text = "";
            Age.Text = "";
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
