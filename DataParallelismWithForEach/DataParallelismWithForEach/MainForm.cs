using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace DataParallelismWithForEach
{
    public partial class MainForm : Form
    {
        private CancellationTokenSource cancelToken = new CancellationTokenSource();
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnProcessImages_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() => { ProcessFiles(); });
        }

        private void ProcessFiles()
        {
            var parOpts = new ParallelOptions();
            parOpts.CancellationToken = cancelToken.Token;
            parOpts.MaxDegreeOfParallelism = System.Environment.ProcessorCount;

            var files = Directory.GetFiles(@"C:\Users\JA0006284\Downloads\Images", "*.jpg", SearchOption.AllDirectories);
            const string newDir = @"C:\Users\JA0006284\Downloads\Images\ModifiedPictures";
            Directory.CreateDirectory(newDir);

            try
            {
                Parallel.ForEach(files, parOpts, currentFile =>
                    //foreach (var currentFile in files)
                {
                    parOpts.CancellationToken.ThrowIfCancellationRequested();

                    var filename = Path.GetFileName(currentFile);
                    using (Bitmap bitmap = new Bitmap(currentFile))
                    {
                        bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        bitmap.Save(Path.Combine(newDir, filename));
                        //this.Text = string.Format("Processing {0} on thread {1}", filename, Thread.CurrentThread.ManagedThreadId);
                        this.Invoke((Action) delegate
                        {
                            this.Text = string.Format("Processing {0} on thread {1}", filename,
                                Thread.CurrentThread.ManagedThreadId);
                        });
                    }
                });
                this.Invoke((Action) delegate { this.Text = "Done!"; });
            }
            catch (OperationCanceledException ex)
            {
                this.Text = ex.Message;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cancelToken.Cancel();
        }
    }
}
