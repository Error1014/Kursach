using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach
{
    internal class Meneger
    {
        public static Pacient GetSelectPacient(Vizov SelectVizov)
        {
            var pacient = from p in App.Context.Pacient.ToList()
                          where p.id == SelectVizov.pacient
                          select p;
            Pacient pac = new Pacient();
            foreach (var item in pacient)
            {
                pac = item;
            }
            return pac;
        }
        public static type_vizov GetTypeVizov(Vizov vizov)
        {
            var type = from t in App.Context.type_vizov.ToList()
                       where t.id == vizov.type
                       select t;
            type_vizov thisType = new type_vizov();
            foreach (var item in type)
            {
                thisType = item;
            }
            return thisType;
        }
    }
}
