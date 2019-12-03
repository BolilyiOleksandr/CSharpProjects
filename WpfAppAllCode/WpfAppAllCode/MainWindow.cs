using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Windows.Input;

namespace WpfAppAllCode
{
    public class MainWindow : Window
    {
        private Button btnExitApp = new Button();
        public MainWindow(string windowTitle, int height, int width)
        {
            btnExitApp.Click += new RoutedEventHandler(btnExitApp_Clicked);
            btnExitApp.Content = "Exit Application";
            btnExitApp.Height = 25;
            btnExitApp.Width = 100;

            this.Content = btnExitApp;
            this.Title = windowTitle;
            this.Height = height;
            this.Width = width;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Closing += MainWindow_Closing;
            this.Closed += MainWindow_Closed;
            this.MouseMove += MainWindow_MouseMove;
            this.KeyDown += MainWindow_KeyDown;
            this.Show();
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            btnExitApp.Content = e.Key.ToString();
        }

        private void MainWindow_MouseMove(object sender, MouseEventArgs e)
        {
            this.Title = e.GetPosition(this).ToString();
        }

        private static void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            const string msg = "Do you want to close without saving?";
            var result = MessageBox.Show(msg, "My App", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

        private static void MainWindow_Closed(object sender, EventArgs e)
        {
            MessageBox.Show("See ya!");
        }

        private void btnExitApp_Clicked(object sender, RoutedEventArgs e)
        {
            if ((bool)Application.Current.Properties["GodMode"])
            {
                MessageBox.Show("Cheater!");
            }
            this.Close();
        }

    }
}
