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

namespace PLINQDataProcessingWithCancellation
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource cancelToken = new CancellationTokenSource();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() => { ProcessIntData(); });
        }

        private void ProcessIntData()
        {
            var source = Enumerable.Range(1, 10000000).ToArray();
            int[] modThreeIsZero = null;
            try
            {
                modThreeIsZero = (from num in source.AsParallel().WithCancellation(cancelToken.Token)
                                  where num % 3 == 0
                                  orderby num descending
                                  select num).ToArray();
                MessageBox.Show(string.Format("Found {0} numbers that match query!", modThreeIsZero.Count()));
            }
            catch (OperationCanceledException ex)
            {
                this.Invoke((Action)delegate { this.Text = ex.Message; });
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cancelToken.Cancel();
        }
    }
}
