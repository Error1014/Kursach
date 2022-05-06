using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Kursach
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static SpeedHelp2Entities Context;

        void Application_Start(object sender, StartupEventArgs args)
        {
            Context = new SpeedHelp2Entities();
        }
    }
}
