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
using System.Windows.Annotations;
using System.Windows.Annotations.Storage;
using System.Windows.Markup;

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

            PopulateDocument();
            EnableAnnotations();

            BtnSaveDoc.Click += (o, s) =>
            {
                using (var fStream = File.Open("documentData.xml", FileMode.Create))
                {
                    XamlWriter.Save(this.MyDocumentReader.Document, fStream);
                }
            };

            BtnLoadDoc.Click += (o, s) =>
            {
                using (var fStream = File.Open("documentData.xaml", FileMode.Open))
                {
                    try
                    {
                        var doc = XamlReader.Load(fStream) as FlowDocument;
                        this.MyDocumentReader.Document = doc;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error Loading Doc!");
                    }
                }
            };

            SetBindings();
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
            this.MyInkCanvas.DefaultDrawingAttributes.Color = (Color)ColorConverter.ConvertFromString(colorToUse);
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

        private void PopulateDocument()
        {
            this.ListOfFunFacts.FontSize = 14;
            this.ListOfFunFacts.MarkerStyle = TextMarkerStyle.Circle;
            this.ListOfFunFacts.ListItems.Add(
                new ListItem(new Paragraph(new Run("Fixed documents are for WYSIWYG print ready docs!"))));
            this.ListOfFunFacts.ListItems.Add(
                new ListItem(new Paragraph(new Run("The API supports tables and embedded figures!"))));
            this.ListOfFunFacts.ListItems.Add(new ListItem(new Paragraph(new Run("Flow documents are read only!"))));
            this.ListOfFunFacts.ListItems.Add(new ListItem(
                new Paragraph(new Run("BlockUIContainer allows you to embed WPF controls in the document!"))));

            var prefix = new Run("This paragraph was generated ");
            var b = new Bold();
            var infix = new Run("dynamically");

            infix.Foreground = Brushes.Red;
            infix.FontSize = 30;
            b.Inlines.Add(infix);

            var suffix = new Run(" at runtime!");

            this.ParaBodyText.Inlines.Add(prefix);
            this.ParaBodyText.Inlines.Add(infix);
            this.ParaBodyText.Inlines.Add(suffix);
        }

        private void EnableAnnotations()
        {
            var anoService = new AnnotationService(MyDocumentReader);
            var anoStream = new MemoryStream();
            var store = new XmlStreamStore(anoStream);
            anoService.Enable(store);
        }

        private void SetBindings()
        {
            var b = new Binding()
            {
                Converter = new MyDoubleConverter(),
                Source = this.MySb,
                Path = new PropertyPath("Value")
            };
            this.LabelSbThumb.SetBinding(Label.ContentProperty, b);
        }

    }
}
