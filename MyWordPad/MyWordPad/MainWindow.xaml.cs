using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;

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
            SetF1CommandBinding();
        }

        private void SetF1CommandBinding()
        {
            var helpBinding = new CommandBinding(ApplicationCommands.Help);
            helpBinding.CanExecute += CanHelpExecute;
            helpBinding.Executed += HelpExecuted;
            CommandBindings.Add(helpBinding);
        }

        private void CanHelpExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void HelpExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Look, it is not that difficult. Just type something!", "Help!");
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

        private void OpenCmdExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var openDlg = new OpenFileDialog
            {
                Filter = "Text Files |*.txt"
            };
            if (true == openDlg.ShowDialog())
            {
                var dataFromFile = File.ReadAllText(openDlg.FileName);
                TxtData.Text = dataFromFile;
            }
        }

        private void OpenCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void SaveCmdExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var saveDlg = new SaveFileDialog
            {
                Filter = "Text Files |*.txt"
            };
            if (true == saveDlg.ShowDialog())
            {
                File.WriteAllText(saveDlg.FileName, TxtData.Text);
            }
        }

        private void SaveCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}
