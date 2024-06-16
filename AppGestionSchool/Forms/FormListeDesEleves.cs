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
using System.IO;

namespace AppGestionSchool.Forms
{
    public partial class FormListeDesEleves : Form
    {
        public FormListeDesEleves()
        {
            InitializeComponent();
        }
        Connexion cnn = new Connexion();
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            affichierr();
           
        }
        public void affichierr()
        {
            cnn.Connecter();
            
            cnn.sda = new SqlDataAdapter("select cne,nom,prenom,sexe,Date_naissance,Lieu_naissance,Nationnalite,classes.niveau,photo from eleves,classes  where eleves.classe=classes.reference", cnn.con);
            cnn.dt = new DataTable();
            cnn.sda.Fill(cnn.dt);
            guna2DataGridView1.DataSource = cnn.dt;
            guna2DataGridView1.Columns["photo"].Visible = false;
            cnn.Deconnecter();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

            cnn.Connecter();
            cnn.cmd = new SqlCommand("delete from eleves where cne=@cne", cnn.con);
            cnn.cmd.Parameters.AddWithValue("@cne", txt_liste.Text);
            cnn.cmd.ExecuteNonQuery();
            affichierr();
            cnn.Deconnecter();
            MessageBox.Show("Eleves Supprimer");
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            cnn.Connecter();
            cnn.cmd = new SqlCommand("select  distinct cne,nom,prenom,sexe,Date_naissance,Lieu_naissance,Nationnalite from eleves where cne=@cne", cnn.con);
            cnn.cmd.Parameters.AddWithValue("@cne", txt_liste.Text);
            cnn.sda = new SqlDataAdapter(cnn.cmd);
            cnn.dt = new DataTable();
            cnn.sda.Fill(cnn.dt);
            guna2DataGridView1.DataSource = cnn.dt;

            cnn.Deconnecter();
           
        }

        private void guna2DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FormEleves fe = new FormEleves();
            
            fe.txt_nom.Text = guna2DataGridView1.CurrentRow.Cells[1].Value.ToString();
            fe.txt_prenom.Text = guna2DataGridView1.CurrentRow.Cells[2].Value.ToString();
            fe.combobox_gender.Text = guna2DataGridView1.CurrentRow.Cells[3].Value.ToString();
            fe.txt_cne.Text = guna2DataGridView1.CurrentRow.Cells[0].Value.ToString();
            fe.dateTimePick.Text = guna2DataGridView1.CurrentRow.Cells[4].Value.ToString();
            fe.txt_lieu.Text = guna2DataGridView1.CurrentRow.Cells[5].Value.ToString();
            fe.txt_nationalite.Text = guna2DataGridView1.CurrentRow.Cells[6].Value.ToString();
            fe.comboclasses.Text = guna2DataGridView1.CurrentRow.Cells[7].Value.ToString();
            byte[] images = Encoding.ASCII.GetBytes(guna2DataGridView1.CurrentRow.Cells[8].Value.ToString());
            if (images!=null)
            {
                var data = (byte[])(guna2DataGridView1.CurrentRow.Cells[8].Value);
                var streamm = new MemoryStream(data);
                fe.pictureBox1.Image = Image.FromStream(streamm);
            }
            
            fe.TopLevel = false;
            fe.FormBorderStyle = FormBorderStyle.None;
            fe.Dock = DockStyle.Fill;
            Form1.form1Instance.panelDesktopPanel.Controls.Add(fe);
            Form1.form1Instance.panelDesktopPanel.Tag = fe;
            fe.BringToFront();
            fe.Show();
            Form1.form1Instance.lbl_Title.Text = fe.Text;
            this.Hide();

        }
    }
}
