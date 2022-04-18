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
                       select o;
            List <OthotVrach> stat = new List<OthotVrach>();
            foreach (var item in data)
            {
                stat.Add(new OthotVrach(item.id, item.id_vizov.Value, item.date_othot.Value, item.is_hospitalisir.Value, item.is_dead.Value));
            }
            
            statisticDataGrid.DataContext = data;
        }
        public class OthotVrach
        {
            int id;
            int id_vizov;
            DateTime date;
            string isHosp;
            string isDead;

            public OthotVrach()
            {

            }
            public OthotVrach(int id, int id_vizov,DateTime date, bool isHosp, bool isDead)
            {
                this.id = id;
                this.id_vizov = id_vizov;
                this.date = date;
                if (isHosp)
                {
                    this.isHosp = "Госпиталезирован";
                }
                else
                {
                    this.isHosp = "Не госпиталезирован";
                }
                if (isDead)
                {
                    this.isDead = "Умер";
                }
                else
                {
                    this.isDead = "Выжил";
                }
            }
        }
    }
}
