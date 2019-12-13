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
using System.Windows.Ink;

namespace WPFControlsAndAPIs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

            this.MyInkCanvas.EditingMode = InkCanvasEditingMode.Ink;
            this.InkRadio.IsChecked = true;
            this.ComboColors.SelectedIndex = 0;
        }

        private void RadioButtonClicked(object sender, RoutedEventArgs e)
        {
            switch ((sender as RadioButton)?.Content.ToString())
            {
                case "Ink Mode!":
                    this.MyInkCanvas.EditingMode = InkCanvasEditingMode.Ink;
                    break;
                case "Erase Mode!":
                    this.MyInkCanvas.EditingMode = InkCanvasEditingMode.EraseByStroke;
                    break;
                case "Select Mode!":
                    this.MyInkCanvas.EditingMode = InkCanvasEditingMode.Select;
                    break;
            }
        }

        private void ColorChanged(object sender, SelectionChangedEventArgs e)
        {
            //var colorToUse = (this.ComboColors.SelectedItem as ComboBoxItem)?.Content.ToString();
            var colorToUse = (this.ComboColors.SelectedItem as StackPanel)?.Tag.ToString();
            this.MyInkCanvas.DefaultDrawingAttributes.Color = (Color) ColorConverter.ConvertFromString(colorToUse);
        }

        private void SaveData(object sender, RoutedEventArgs e)
        {
            using (var fs = new FileStream("StrokeData.bin", FileMode.Create))
            {
                this.MyInkCanvas.Strokes.Save(fs);
                fs.Close();
            }
        }

        private void LoadData(object sender, RoutedEventArgs e)
        {
            using (var fs = new FileStream("StrokeData.bin", FileMode.Open, FileAccess.Read))
            {
                var strokes = new StrokeCollection(fs);
                this.MyInkCanvas.Strokes = strokes;
            }
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            this.MyInkCanvas.Strokes.Clear();
        }
    }
}
