using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppGestionSchool.Forms
{
    public partial class FormListedesetudiantCrystal : Form
    {
        public FormListedesetudiantCrystal()
        {
            InitializeComponent();
        }

        private void FormListedesetudiantCrystal_Load(object sender, EventArgs e)
        {
            crystalReportViewer1.ReportSource =FormClasses.crystal;
            crystalReportViewer1.Refresh();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
