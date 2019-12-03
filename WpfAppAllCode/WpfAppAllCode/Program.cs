using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfAppAllCode
{
    public class Program : Application
    {
        [STAThread]
        private static void Main(string[] args)
        {
            var app = new Program();
            app.Startup += new StartupEventHandler(AppStartUp);
            app.Exit += new ExitEventHandler(AppExit);
            app.Run();
        }

        private static void AppExit(object sender, ExitEventArgs e)
        {
            MessageBox.Show("App has exited");
        }

        private static void AppStartUp(object sender, StartupEventArgs e)
        {
            Application.Current.Properties["GodMode"] = false;
            foreach (var arg in e.Args)
            {
                if (arg.ToLower() == "/godmode")
                {
                    Application.Current.Properties["GodMode"] = true;
                    break;
                }
            }

            var main = new MainWindow("My better WPF App!", 200, 300);
        }

    }
}
