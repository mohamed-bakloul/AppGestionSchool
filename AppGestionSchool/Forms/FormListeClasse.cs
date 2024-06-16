using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AppGestionSchool.Forms
{
    public partial class FormListeClasse : Form
    {
        public FormListeClasse()
        {
            InitializeComponent();
            LoadTheme();

        }
        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
        }

        private void FormListeClasse_Load(object sender, EventArgs e)
        {
            affichage_Classe();
        }

        Connexion cnn = new Connexion();
        public void affichage_Classe()
        {
            cnn.Connecter();
            cnn.sda = new SqlDataAdapter("Select * from classes",cnn.con);
            cnn.dt = new DataTable();
            cnn.sda.Fill(cnn.dt);
            Dgv_Listeclasse.DataSource = cnn.dt;
            cnn.Deconnecter();
        }
        private void Dgv_Listeclasse_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Dgv_Listeclasse_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FormEmploi femploi = new FormEmploi();

            femploi.lbl_nomclasse.Text = Dgv_Listeclasse.CurrentRow.Cells[2].Value.ToString();


            femploi.TopLevel = false;
            femploi.FormBorderStyle = FormBorderStyle.None;
            femploi.Dock = DockStyle.Fill;
            Form1.form1Instance.panelDesktopPanel.Controls.Add(femploi);
            Form1.form1Instance.panelDesktopPanel.Tag = femploi;
            femploi.BringToFront();
            femploi.Show();
            Form1.form1Instance.lbl_Title.Text = femploi.Text;
            this.Hide();
        }
    }
}
