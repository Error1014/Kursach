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
            thisVrach = myUser;
            if (myUser.is_free == true)
            {
                MessageBox.Show("У вас нет вызовов");
            }
            else
            {
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
                string s="";
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
            if (isStart == false)
            {
                isStart = true;
                btn.Content = "Завешить вызов";
                myVrach.is_free = true;
            }
            else
            {
                isStart = false;
                btn.Content = "Принять вызов";
                myVrach.is_free = false;
            }
            App.Context.SaveChanges();

        }
    }
}
