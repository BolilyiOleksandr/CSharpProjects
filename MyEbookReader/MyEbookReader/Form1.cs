using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace MyEBookReader
{
    public partial class Form1 : Form
    {
        private string _theEBook = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            var wc = new WebClient();
            wc.DownloadStringCompleted += (s, eArgs) =>
            {
                _theEBook = eArgs.Result;
                txtBook.Text = _theEBook;
            };

            wc.DownloadStringAsync(new Uri("http://www.gutenberg.org/files/98/98-8.txt"));
        }

        private void btnGetStats_Click(object sender, EventArgs e)
        {
            var words = _theEBook.Split(new char[] { ' ', '\u000A', ',', '.', ';', ':', '-', '?', '/' },
                StringSplitOptions.RemoveEmptyEntries);

            string[] tenMostCommon = null;
            var longestWord = string.Empty;

            Parallel.Invoke(
                () =>
                {
                    tenMostCommon = FindTenMostCommon(words);

                },
                () =>
                {
                    longestWord = FindLongestWord(words);

                });

            var bookStats = new StringBuilder("Ten Most Common Words are:\n");

            foreach (var s in tenMostCommon)
            {
                bookStats.AppendLine(s);
            }

            bookStats.AppendFormat("Longest word is: {0}", longestWord);
            bookStats.AppendLine();

            MessageBox.Show(bookStats.ToString(), "Book info");
        }

        private static string[] FindTenMostCommon(IEnumerable<string> words)
        {
            var frequencyOrder = from word in words
                                 where word.Length > 6
                                 group word by word into g
                                 orderby g.Count() descending
                                 select g.Key;
            var commonWords = (frequencyOrder.Take(10)).ToArray();
            return commonWords;
        }

        private static string FindLongestWord(IEnumerable<string> words)
        {
            return (from w in words orderby w.Length descending select w).FirstOrDefault();
        }

    }
}
