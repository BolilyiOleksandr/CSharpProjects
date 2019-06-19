using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using CommonSnappableTypes;

namespace MyExtendableApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void snapInModuleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (dlg.FileName.Contains("CommonSnappableTypes"))
                    MessageBox.Show("CommonSnappableTypes has no snappins!");
                else if (!LoadExternalModule(dlg.FileName))
                    MessageBox.Show("Nothing implements IAppFunctionliy!");
            }
        }

        private bool LoadExternalModule(string path)
        {
            var foundSnapIn = false;
            Assembly theSnapInAsm = null;
            try
            {
                theSnapInAsm = Assembly.LoadFrom(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return foundSnapIn;
            }

            var theClassTypes = from t in theSnapInAsm.GetTypes()
                                where t.IsClass && (t.GetInterface("IAppFunctionality") != null)
                                select t;

            foreach (var t in theClassTypes)
            {
                var itfApp = (IAppFunctionality)theSnapInAsm.CreateInstance(t.FullName, true);
                itfApp.DoIt();
                lstLoadedSnapIns.Items.Add(t.FullName);
                DisplayCompanyData(t);
            }

            return foundSnapIn;
        }

        private void DisplayCompanyData(Type t)
        {
            var compInfo = from ci in t.GetCustomAttributes(false)
                           where (ci.GetType() == typeof(CompanyInfoAttribute))
                           select ci;

            foreach (CompanyInfoAttribute c in compInfo)
            {
                MessageBox.Show(c.CompanyUrl, string.Format("More info about {0} can be found at", c.CompanyName));
            }
        }

    }
}
