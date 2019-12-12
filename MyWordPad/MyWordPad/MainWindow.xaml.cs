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

namespace MyWordPad
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

        private void MouseEnterExitArea(object sender, MouseEventArgs e)
        {
            StatBarText.Text = "Exit the Application";
        }

        private void MouseLeaveArea(object sender, MouseEventArgs e)
        {
            StatBarText.Text = "Ready";
        }

        private void FileExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MouseEnterToolsHintsArea(object sender, MouseEventArgs e)
        {
            StatBarText.Text = "Show Spelling Suggestions";
        }

        private void ToolsSpellingHints_Click(object sender, RoutedEventArgs e)
        {
            var spellingHints = string.Empty;
            var error = TxtData.GetSpellingError(TxtData.CaretIndex);
            if (error != null)
            {
                foreach (var s in error.Suggestions)
                {
                    spellingHints += $"{s}\n";
                }

                LblSpellingHints.Content = spellingHints;
                ExpanderSpelling.IsExpanded = true;
            }
        }
    }
}
