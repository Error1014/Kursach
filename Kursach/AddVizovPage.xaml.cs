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
        private bool isUpdate = false;
        public Vizov myVizov;
        public AddVizovPage(Vizov SelectVizov)
        {
            InitializeComponent();
            if (SelectVizov==null)
            {
                isUpdate = false;
                GetListVrach();
                listTypeVizov.ItemsSource = App.Context.type_vizov.ToList();
            }
            else
            {
                myVizov = SelectVizov;
                isUpdate = true;
                Pacient pac = Meneger.GetSelectPacient(SelectVizov);
                ShowDataVizov(pac, SelectVizov);
                DeactivationElement();
                GetListVrach();
            }
            
        }

        public void ShowDataVizov(Pacient pac, Vizov vizov)
        {
            Familia.Text = pac.familia;
            Name.Text = pac.name;
            Otch.Text = pac.otch;
            Phone.Text = vizov.phone;
            Adres.Text = vizov.adres;
            Age.Text = pac.age;
            Symptom.Text = vizov.symptom;
            listTypeVizov.ItemsSource = App.Context.type_vizov.ToList();
            listVrach.SelectedItem = vizov.vrach;
        }
        public void ObnullDataVizov()
        {
            Familia.Text = "";
            Name.Text = "";
            Otch.Text = "";
            Phone.Text = "";
            Adres.Text = "";
            Age.Text = "";
            Symptom.Text = "";
            listTypeVizov.SelectedItem = null;
            listVrach.SelectedItem = null;
        }
        public void DeactivationElement()
        {
            Familia.IsEnabled = false;
            Name.IsEnabled = false;
            Otch.IsEnabled = false;
            Phone.IsEnabled = false;
            Adres.IsEnabled = false;
            Age.IsEnabled = false;
            Symptom.IsEnabled = false;
            //listTypeVizov.IsEnabled = false;
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
            if (myVizov==null)
            {
                var newID = 1;
                newID += App.Context.Vizov.Max(x=>x.id);
                vizov.id = newID;
            }
            else
            {
                vizov =App.Context.Vizov.FirstOrDefault(s => s.id.Equals(myVizov.id));
                MessageBox.Show(vizov.id.ToString());
            }
            pacient.familia = Familia.Text;
            pacient.name = Name.Text;
            pacient.otch = Otch.Text;
            App.Context.Pacient.Add(pacient);
            vizov.phone = Phone.Text;
            vizov.adres = Adres.Text;
            pacient.age = Age.Text;
            vizov.isEnd = false;
            vizov.symptom = Symptom.Text;
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
            if (selectUser.id != 9)
            {
                selectUser.is_free = false;
            }
            user_vizov uv = new user_vizov();
            uv.id_user = selectUser.id;
            uv.id_vizov = vizov.id;
            vizov.pacient = pacient.id;
            vizov.date_vizov = DateTime.Now;

            if (isUpdate==true)
            {
                App.Context.user_vizov.Add(uv);
                ObnullDataVizov();
                App.Context.SaveChanges();
            }
            else
            {
                App.Context.user_vizov.Add(uv);
                ObnullDataVizov();
                App.Context.SaveChanges();
            } 

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
