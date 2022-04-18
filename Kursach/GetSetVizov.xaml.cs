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
    /// Логика взаимодействия для GetSetVizov.xaml
    /// </summary>
    public partial class GetSetVizov : Page
    {
        public User thisVrach;
        private bool isStart = false;
        public GetSetVizov(User myUser)
        {
            InitializeComponent();
            thisVrach = myUser;
            if (myUser == null)
            {
                return;
            }
            if (myUser.is_free == true)
            {
                
            }
            else
            {
                info.Text = "";
                Vizov thisVizov = GetVizov();
                int idVizov = thisVizov.id;
                textBlockAdres.Text = thisVizov.adres.ToString();
                Pacient thisPacient = GetPacient(idVizov);
                textBlockFamilia.Text = thisPacient.familia;
                textBlockName.Text = thisPacient.name;
                textBlockOtch.Text = thisPacient.otch;
                textBlockAge.Text = thisPacient.age;
                textBlockPhone.Text = thisVizov.phone;
                textBlockSymptom.Text = thisVizov.symptom;
                var typeVizov = from t in App.Context.type_vizov.ToList()
                                where thisVizov.type == t.id
                                select t;
                string s = "";
                foreach (var item in typeVizov)
                {
                    s = item.type;
                }
                textBlockType.Text = s;
            }
        }
        private Pacient GetPacient(int idVizov)
        {
            var pac = from v in App.Context.Vizov
                      join p in App.Context.Pacient on v.pacient equals p.id
                      where v.id == idVizov
                      select p;
            Pacient thisPacient = new Pacient();
            foreach (var item in pac)
            {
                thisPacient = item;
            }
            return thisPacient;
        }


        private Vizov GetVizov()
        {
            var vizov = from v in App.Context.Vizov
                        join uv in App.Context.user_vizov on v.id equals uv.id_vizov
                        where uv.id_user == thisVrach.id
                        select v;
            Vizov thisVizov = new Vizov();
            foreach (var item in vizov)
            {
                thisVizov = item;
            }
            int idVizov = thisVizov.id;
            return thisVizov;
        }
        private User GetVrach()
        {
            var vrach = from v in App.Context.User
                        where v.id == thisVrach.id
                        select v;
            User myVrachs = new User();
            foreach (var item in vrach)
            {
                myVrachs = item;
            }
            return myVrachs;
        }

        private void AcceptVizov(object sender, RoutedEventArgs e)
        {
            User myVrach = GetVrach();
            Othot otch = new Othot();
            if (isStart == false)
            {//принял вызов
                isStart = true;
                btn.Content = "Завешить вызов";
                myVrach.is_free = false;
                textBlockDiagnoz.IsEnabled = true;
                textBlockDiagnoz.Visibility = Visibility.Visible;
                checkDead.Visibility = Visibility.Visible;
                checkHospital.Visibility = Visibility.Visible;
            }
            else
            {//завершил вызов
                isStart = false;
                btn.Content = "Принять вызов";
                myVrach.is_free = true;
                Vizov myViz = new Vizov();
                var viz = from v in App.Context.Vizov
                        select v;
                foreach (var item in viz)
                {
                    myViz = item;
                }
                myViz.isEnd = true;
                otch.diagnoz = textBlockDiagnoz.Text;
                otch.is_hospitalisir = checkHospital.IsChecked;
                otch.is_dead = checkDead.IsChecked;
                otch.date_othot = DateTime.Now;
                otch.id_vizov = GetVizov().id;
                App.Context.Othot.Add(otch);
                App.Context.SaveChanges();
                VrachWin VW = (VrachWin)Window.GetWindow(this);
                VW.VrachFrame.Content = new GetSetVizov(thisVrach);

            }

        }
    }
}
