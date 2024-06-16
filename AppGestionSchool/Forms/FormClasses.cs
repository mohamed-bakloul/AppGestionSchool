using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppGestionSchool.Forms
{
    public partial class FormClasses : Form
    {
        public FormClasses()
        {
            InitializeComponent();
            LoadTheme();
            affichierclasses();
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
        public void affichierclasses()
        {
            cnn.Connecter();
            cnn.cmd = new SqlCommand("select * from classes", cnn.con);
            cnn.sda = new SqlDataAdapter(cnn.cmd);
            cnn.dt = new DataTable();
            cnn.sda.Fill(cnn.dt);
            guna2DataGridView1.DataSource = cnn.dt;
            cnn.Deconnecter();
            guna2DataGridView1.ClearSelection();
        }
        private void FormClasses_Load(object sender, EventArgs e)
        {

        }
        Connexion cnn = new Connexion();
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            FormAjouterUneClass classajouter = new FormAjouterUneClass();
            classajouter.Show();
        }

        private void btn_actualiser_Click(object sender, EventArgs e)
        {
            affichierclasses();
        }

        public static CrystalReportEtudiant crystal = new CrystalReportEtudiant();

        private void guna2DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cnn.Connecter();

            cnn.sda = new SqlDataAdapter("select cne,nom,prenom,photo,Nationnalite from eleves where classe=@classe",cnn.con);
            cnn.sda.SelectCommand.Parameters.AddWithValue("@classe",guna2DataGridView1.CurrentRow.Cells[0].Value.ToString());

            DataSetEtudiant ds = new DataSetEtudiant();

            cnn.sda.Fill(ds.eleves);

            crystal.SetDataSource(ds.Tables["eleves"]);

            this.Hide();

            FormListedesetudiantCrystal form = new FormListedesetudiantCrystal();
            form.Show();

            cnn.Deconnecter();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count==1)
            {
                cnn.delete("delete from classes where reference=@refrence ", "@refrence", guna2DataGridView1.CurrentRow.Cells[0].Value.ToString());
                
                guna2DataGridView1.ClearSelection();
            }
        }
        //kit9t3 sawt
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            cnn.Connecter();
            cnn.sda = new SqlDataAdapter("select * from classes where description=@description", cnn.con);
            cnn.sda.SelectCommand.Parameters.AddWithValue("@description",txt_rech.Text);
            cnn.dt = new DataTable();
            cnn.sda.Fill(cnn.dt);
            guna2DataGridView1.DataSource = cnn.dt;
            cnn.Deconnecter();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}