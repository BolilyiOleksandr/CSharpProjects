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
using System.IO;
using System.Windows.Markup;

namespace MyXamlPad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (File.Exists("YourXaml.xaml"))
            {
                TxtXamlData.Text = File.ReadAllText("YourXaml.xaml");
            }
            else
            {
                TxtXamlData.Text = "<Window xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation \" " + 
                                   "xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml \" " +
                                   "Height =\"400\" Width =\"500\" " +
                                   "WindowStartupLocation =\"CenterScreen\">\n" +
                                    "<StackPanel>\n" +
                                    "</StackPanel>\n" +
                                    "</Window>";
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            File.WriteAllText("YourXaml.xaml", TxtXamlData.Text);
            Application.Current.Shutdown();
        }

        private void BtnViewXaml_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllText("YourXaml.xaml", TxtXamlData.Text);
            try
            {
                using (var stream = File.Open("YourXaml.xaml", FileMode.Open))
                {
                    var myWindow = (Window)XamlReader.Load(stream);
                    myWindow.ShowDialog();
                    myWindow.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
