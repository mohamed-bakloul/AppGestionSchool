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
    public partial class FormListeDesPersonnels : Form
    {
        public FormListeDesPersonnels()
        {
            InitializeComponent();
        }
        Connexion cnn = new Connexion();
        public void affichier()
        {
            cnn.cmd = new SqlCommand("SELECT DISTINCT cin,nom,prenom,sexe,Date_naissance,email,tel,diplome,Lieu_naissance,Nationnalite,poste from prof", cnn.con);
            cnn.sda = new SqlDataAdapter(cnn.cmd);
            cnn.dt = new DataTable();
            cnn.sda.Fill(cnn.dt);
            guna2DataGridView1.DataSource = cnn.dt;

        }
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {

            cnn.Connecter();
            cnn.cmd = new SqlCommand("delete prof where cin=@cin", cnn.con);
            cnn.cmd.Parameters.AddWithValue("@cin", txt_liste.Text);
            cnn.cmd.ExecuteNonQuery();
            affichier();
            cnn.Deconnecter();
            MessageBox.Show( txt_liste.Text + "a été supprimé");
        }

        private void btn_Rechercher_Click(object sender, EventArgs e)
        {
            cnn.Connecter();
            cnn.cmd = new SqlCommand("SELECT DISTINCT cin,nom,prenom,sexe,Date_naissance,email,tel,diplome,Lieu_naissance,Nationnalite,poste from prof  where cin=@cin", cnn.con);
            cnn.cmd.Parameters.AddWithValue("@cin", txt_liste.Text);
            cnn.sda = new SqlDataAdapter(cnn.cmd);
            cnn.dt = new DataTable();
            cnn.sda.Fill(cnn.dt);
            guna2DataGridView1.DataSource = cnn.dt;

            cnn.Deconnecter();
           
        }

        private void btn_affichier_Click(object sender, EventArgs e)
        {
            cnn.Connecter();
            affichier();
            cnn.Deconnecter();
            
        }

        private void guna2DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //FormListeDesPersonnels ps = new FormListeDesPersonnels();
            //ps..Text = guna2DataGridView1.CurrentRow.Cells[1].Value.ToString();
            //fe.txt_prenom.Text = guna2DataGridView1.CurrentRow.Cells[2].Value.ToString();
            //fe.combobox_gender.Text = guna2DataGridView1.CurrentRow.Cells[3].Value.ToString();
            //fe.txt_cne.Text = guna2DataGridView1.CurrentRow.Cells[0].Value.ToString();
            //fe.dateTimePick.Text = guna2DataGridView1.CurrentRow.Cells[4].Value.ToString();
            //fe.txt_lieu.Text = guna2DataGridView1.CurrentRow.Cells[5].Value.ToString();
            //fe.txt_nationalite.Text = guna2DataGridView1.CurrentRow.Cells[6].Value.ToString();
            //fe.comboclasses.Text = guna2DataGridView1.CurrentRow.Cells[7].Value.ToString();
            //byte[] images = Encoding.ASCII.GetBytes(guna2DataGridView1.CurrentRow.Cells[8].Value.ToString());
            //if (images != null)
            //{
            //    var data = (byte[])(guna2DataGridView1.CurrentRow.Cells[8].Value);
            //    var streamm = new MemoryStream(data);
            //    fe.pictureBox1.Image = Image.FromStream(streamm);
            //}

            //fe.TopLevel = false;
            //fe.FormBorderStyle = FormBorderStyle.None;
            //fe.Dock = DockStyle.Fill;
            //Form1.form1Instance.panelDesktopPanel.Controls.Add(fe);
            //Form1.form1Instance.panelDesktopPanel.Tag = fe;
            //fe.BringToFront();
            //fe.Show();
            //Form1.form1Instance.lbl_Title.Text = fe.Text;
            //this.Hide();

        }
    }
}
