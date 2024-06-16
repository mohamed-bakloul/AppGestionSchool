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
    public partial class FormDepenses : Form
    {
        Connexion cnn = new Connexion();
        public FormDepenses()
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
        private void FormDepenses_Load(object sender, EventArgs e)
        {
            Vider();
        }
        public void Vider()
        {
            txt_septembre.Text = txt_octobre.Text = txt_november.Text = txt_december.Text = txt_janvier.Text = txt_fevrier.Text = txt_mars.Text = txt_avril.Text = txt_mai.Text= txt_juillet.Text = txt_juin.Text = "";
            
        }
        private void btn_ajouter_payement_Click(object sender, EventArgs e)
        {
            if (txt_cne.Text!=""&& txt_septembre.Text != "" && txt_septembre.Text != "" && txt_november.Text != "" && txt_december.Text != "" && txt_janvier.Text != "" && txt_fevrier.Text != "" && txt_mars.Text != "" && txt_avril.Text != "" && txt_juin.Text != "" && txt_juillet.Text != "" )
            {
                cnn.Connecter();
                cnn.cmd = new SqlCommand("insert into depense values(@cne,@octobre,@septembre,@november,@december,@janvier,@fevrier,@mars,@avril,@mai,@juin,@juillet,@date)", cnn.con);
                cnn.cmd.Parameters.AddWithValue("@cne", txt_cne.Text);
                cnn.cmd.Parameters.AddWithValue("@septembre", txt_septembre.Text);
                cnn.cmd.Parameters.AddWithValue("@octobre", txt_octobre.Text);
                cnn.cmd.Parameters.AddWithValue("@november", txt_november.Text);
                cnn.cmd.Parameters.AddWithValue("@december", txt_december.Text);
                cnn.cmd.Parameters.AddWithValue("@janvier", txt_janvier.Text);
                cnn.cmd.Parameters.AddWithValue("@fevrier", txt_fevrier.Text);
                cnn.cmd.Parameters.AddWithValue("@mars", txt_mars.Text);
                cnn.cmd.Parameters.AddWithValue("@avril", txt_avril.Text);
                cnn.cmd.Parameters.AddWithValue("@mai",txt_mai.Text);
                cnn.cmd.Parameters.AddWithValue("@juin", txt_juin.Text);
                cnn.cmd.Parameters.AddWithValue("@juillet", txt_juillet.Text);
                cnn.cmd.Parameters.AddWithValue("@date", DateTime.Now.ToShortDateString());
                cnn.cmd.ExecuteNonQuery();
                MessageBox.Show("ajouter !!!!!!!");
                Vider();
                cnn.Deconnecter();
            }
        }

        private void txt_septembre_Leave(object sender, EventArgs e)
        {
            if (txt_septembre.Text=="")
            {
                txt_septembre.Text = "0";
            }

            if (txt_octobre.Text == "")
            {
                txt_octobre.Text = "0";
            }

            if (txt_november.Text == "")
            {
                txt_november.Text = "0";
            }

            if (txt_december.Text == "")
            {
                txt_december.Text = "0";
            }

            if (txt_janvier.Text == "")
            {
                txt_janvier.Text = "0";
            }

            if (txt_fevrier.Text == "")
            {
                txt_fevrier.Text = "0";
            }

            if (txt_mars.Text == "")
            {
                txt_mars.Text = "0";
            }

            if (txt_avril.Text == "")
            {
                txt_avril.Text = "0";
            }

            if (txt_mai.Text == "")
            {
                txt_mai.Text = "0";
            }

            if (txt_juin.Text == "")
            {
                txt_juin.Text = "0";
            }

            if (txt_juillet.Text == "")
            {
                txt_juillet.Text = "0";
            }
        }
        public void affichier()
        {
            cnn.Connecter();
            cnn.cmd = new SqlCommand("select eleves.cne ,eleves.nom ,eleves.prenom ,depense.septembre,depense.octobre,depense.novembrer,depense.decembrer,depense.janvier,depense.fevrier,depense.mars,depense.avril,depense.mai,depense.juin,depense.juillet from eleves,depense where eleves.cne=depense.cne", cnn.con);
            cnn.sda = new SqlDataAdapter(cnn.cmd);
            cnn.dt = new DataTable();
            cnn.sda.Fill(cnn.dt);
            guna2DataGridView1.DataSource = cnn.dt;
            
            cnn.Deconnecter();
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            affichier();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (txt_cne.Text != "" && txt_septembre.Text != "" && txt_septembre.Text != "" && txt_november.Text != "" && txt_december.Text != "" && txt_janvier.Text != "" && txt_fevrier.Text != "" && txt_mars.Text != "" && txt_avril.Text != "" && txt_juin.Text != "" && txt_juillet.Text != "")
            {
                cnn.Connecter();
                cnn.cmd = new SqlCommand("update depense set octobre=@octobre,septembre=@septembre,novembrer=@novembrer,decembrer=@december,janvier=@janvier,fevrier=@fevrier,mars=@mars,avril=@avril,mai=@mai,juin=@juin,juillet=@juillet,date_depense=@date where cne=@cne", cnn.con);
                cnn.cmd.Parameters.AddWithValue("@cne", txt_cne.Text);
                cnn.cmd.Parameters.AddWithValue("@septembre", txt_septembre.Text);
                cnn.cmd.Parameters.AddWithValue("@octobre", txt_octobre.Text);
                cnn.cmd.Parameters.AddWithValue("@novembrer", txt_november.Text);
                cnn.cmd.Parameters.AddWithValue("@december", txt_december.Text);
                cnn.cmd.Parameters.AddWithValue("@janvier", txt_janvier.Text);
                cnn.cmd.Parameters.AddWithValue("@fevrier", txt_fevrier.Text);
                cnn.cmd.Parameters.AddWithValue("@mars", txt_mars.Text);
                cnn.cmd.Parameters.AddWithValue("@avril", txt_avril.Text);
                cnn.cmd.Parameters.AddWithValue("@mai", txt_mai.Text);
                cnn.cmd.Parameters.AddWithValue("@juin", txt_juin.Text);
                cnn.cmd.Parameters.AddWithValue("@juillet", txt_juillet.Text);
                cnn.cmd.Parameters.AddWithValue("@date", DateTime.Now.ToShortDateString());
                cnn.cmd.ExecuteNonQuery();
                MessageBox.Show("modified ! ");
                affichier();
                Vider();
                cnn.Deconnecter();
            }
        }

        private void guna2DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count>0)
            {
                txt_cne.Text =guna2DataGridView1.CurrentRow.Cells[0].Value.ToString();
                txt_septembre.Text =guna2DataGridView1.CurrentRow.Cells[3].Value.ToString();
                txt_december.Text =guna2DataGridView1.CurrentRow.Cells[6].Value.ToString();
                txt_octobre.Text =guna2DataGridView1.CurrentRow.Cells[4].Value.ToString();
                txt_november.Text =guna2DataGridView1.CurrentRow.Cells[5].Value.ToString();
                txt_janvier.Text =guna2DataGridView1.CurrentRow.Cells[7].Value.ToString();
                txt_fevrier.Text =guna2DataGridView1.CurrentRow.Cells[8].Value.ToString();
                txt_mars.Text =guna2DataGridView1.CurrentRow.Cells[9].Value.ToString();
                txt_avril.Text =guna2DataGridView1.CurrentRow.Cells[10].Value.ToString();
                txt_mai.Text =guna2DataGridView1.CurrentRow.Cells[11].Value.ToString();
                txt_juin.Text =guna2DataGridView1.CurrentRow.Cells[12].Value.ToString();
                txt_juillet.Text =guna2DataGridView1.CurrentRow.Cells[13].Value.ToString();
              
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            cnn.Connecter();
            cnn.sda = new SqlDataAdapter(" select eleves.cne ,eleves.nom ,eleves.prenom ,depense.septembre,depense.octobre,depense.novembrer,depense.decembrer,depense.janvier,depense.fevrier,depense.mars,depense.avril,depense.mai,depense.juin,depense.juillet from eleves,depense where eleves.cne=depense.cne and depense.cne=@cne", cnn.con);
            cnn.sda.SelectCommand.Parameters.AddWithValue("@cne", txt_cne.Text);
            cnn.dt = new DataTable();
            cnn.sda.Fill(cnn.dt);
            guna2DataGridView1.DataSource = cnn.dt;
            Vider();
            cnn.Deconnecter();
        }
    }
}
