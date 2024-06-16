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
    public partial class FormEleves : Form
    {
        public FormEleves()
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
        private void FormEleves_Load(object sender, EventArgs e)
        {
            remplircombo();
        }
        Connexion cnn = new Connexion();
        public void remplircombo()
        {
            cnn.Connecter();
            cnn.sda = new SqlDataAdapter("select reference,niveau from classes", cnn.con);
            cnn.dt = new DataTable();
            cnn.sda.Fill(cnn.dt);
            comboclasses.DisplayMember = "niveau";
            comboclasses.ValueMember = "reference";
            comboclasses.DataSource = cnn.dt;
            cnn.Deconnecter();

        }
        string imglocation = "";
        private void btn_ajouter_Click(object sender, EventArgs e)
        {
            if (txt_nom.Text!=""&& txt_prenom.Text != "" && txt_cne.Text != "" && txt_lieu.Text != "" && txt_lieu.Text != "" && txt_nationalite.Text != "" &&combobox_gender.Text!=""&&pictureBox1.Image!=null&&comboclasses.Text!="") {
                cnn.Connecter();
                byte[] images = null;
                FileStream streamm = new FileStream(imglocation, FileMode.Open, FileAccess.Read);
                BinaryReader brs = new BinaryReader(streamm);
                images = brs.ReadBytes((int)streamm.Length);
                cnn.cmd = new SqlCommand("insert into eleves values(@cne,@nom,@prenom,@sexe,@Date_naissance,@Lieu_naissance,@Nationnalite,@classe,@photo);", cnn.con);
                cnn.cmd.Parameters.AddWithValue("@cne", txt_cne.Text);
                cnn.cmd.Parameters.AddWithValue("@nom", txt_nom.Text);
                cnn.cmd.Parameters.AddWithValue("@prenom", txt_prenom.Text);
                cnn.cmd.Parameters.AddWithValue("@sexe", combobox_gender.Text.ToString());
                cnn.cmd.Parameters.AddWithValue("@Date_naissance", dateTimePick.Text.ToString());
                cnn.cmd.Parameters.AddWithValue("@Lieu_naissance", txt_lieu.Text);
                cnn.cmd.Parameters.AddWithValue("@Nationnalite", txt_nationalite.Text);
                cnn.cmd.Parameters.AddWithValue("@classe", comboclasses.SelectedValue);
                cnn.cmd.Parameters.AddWithValue("@photo", images);
                cnn.cmd.ExecuteNonQuery();
                cnn.Deconnecter();
                MessageBox.Show("added !!!!!!"); 
            }
            
        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "select image(*.Jpg; *.png; *Gif)| *.Jpg; *.png; *Gif";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imglocation = dialog.FileName.ToString();
                pictureBox1.ImageLocation = imglocation;

            }
        }

        private void btn_modifier_Click(object sender, EventArgs e)
        {
            if (txt_nom.Text != "" && txt_prenom.Text != "" && txt_cne.Text != "" && txt_lieu.Text != "" && txt_lieu.Text != "" && txt_nationalite.Text != "" && combobox_gender.Text != "" && pictureBox1.Image != null && comboclasses.Text != "")
            {
                byte[] images = null;
                FileStream streamm = new FileStream(imglocation, FileMode.Open, FileAccess.Read);
                BinaryReader brs = new BinaryReader(streamm);
                images = brs.ReadBytes((int)streamm.Length);
                cnn.Connecter();
                cnn.cmd = new SqlCommand("update eleves set nom=@nom,prenom=@prenom,sexe=@sexe,Date_naissance=@Date_naissance,Lieu_naissance=@Lieu_naissance,Nationnalite=@Nationnalite,classe=@classe,photo=@photo where @cne=cne", cnn.con);
                cnn.cmd.Parameters.AddWithValue("@cin", txt_cne.Text);
                cnn.cmd.Parameters.AddWithValue("@nom", txt_nom.Text);
                cnn.cmd.Parameters.AddWithValue("@prenom", txt_prenom.Text);
                cnn.cmd.Parameters.AddWithValue("@sexe", combobox_gender.Text.ToString());
                cnn.cmd.Parameters.AddWithValue("@Date_naissance", dateTimePick.Text.ToString());
                cnn.cmd.Parameters.AddWithValue("@lieu_naissance", txt_lieu.Text);
                cnn.cmd.Parameters.AddWithValue("@Nationnalite", txt_nationalite.Text);
                cnn.cmd.Parameters.AddWithValue("@photo", images);
                cnn.cmd.ExecuteNonQuery();
                cnn.Deconnecter();
                MessageBox.Show("updated");
            }
        }

        private void btn_liste_Click(object sender, EventArgs e)
        {
            FormListeDesEleves ee = new FormListeDesEleves();
            ee.Show();
            ee.affichierr();

        }
    }
}
