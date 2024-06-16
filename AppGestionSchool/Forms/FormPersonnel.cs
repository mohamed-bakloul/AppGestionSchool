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
    public partial class FormPersonnel : Form
    {
        public FormPersonnel()
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
        private void FormPersonnel_Load(object sender, EventArgs e)
        {
            
        }


        Connexion cnn = new Connexion();
        string imglocation = "";
        private void btn_ajouter_Click(object sender, EventArgs e)
        {
            if (txt_nom.Text != "" && txt_prenom.Text != "" && txt_cin.Text != "" && txt_lieu.Text != "" && txt_natio.Text != "" && txt_poste.Text != "" && txt_tel.Text != "" && txt_diplome.Text != "" && txt_email.Text != "" && combobox1.Text != "" && pictureBox1.Image != null) {
                cnn.Connecter();
                byte[] images = null;
                FileStream streamm = new FileStream(imglocation, FileMode.Open, FileAccess.Read);
                BinaryReader brs = new BinaryReader(streamm);
                images = brs.ReadBytes((int)streamm.Length);

                string query = "insert into prof(cin,nom,prenom,sexe,Date_naissance,email,tel,diplome,Lieu_naissance,Nationnalite,photo,poste) values (@cin,@nom,@prenom,@sexe,@Date_naissance,@email,@tel,@diplome,@Lieu_naissance,@Nationnalite,@photo,@poste)";
                cnn.cmd = new SqlCommand(query, cnn.con);
                cnn.cmd.Parameters.AddWithValue("@cin", txt_cin.Text);
                cnn.cmd.Parameters.AddWithValue("@poste", txt_poste.Text);
                cnn.cmd.Parameters.AddWithValue("@nom", txt_nom.Text);
                cnn.cmd.Parameters.AddWithValue("@prenom", txt_prenom.Text);
                cnn.cmd.Parameters.AddWithValue("@sexe", combobox1.Text.ToString());
                cnn.cmd.Parameters.AddWithValue("@Date_naissance", dateTimePicker1.Text.ToString());
                cnn.cmd.Parameters.AddWithValue("@email", txt_email.Text);
                cnn.cmd.Parameters.AddWithValue("@tel", txt_tel.Text);
                cnn.cmd.Parameters.AddWithValue("@diplome", txt_diplome.Text);
                cnn.cmd.Parameters.AddWithValue("@lieu_naissance", txt_lieu.Text);
                cnn.cmd.Parameters.AddWithValue("@Nationnalite", txt_natio.Text);
                cnn.cmd.Parameters.AddWithValue("@photo", images);
                cnn.cmd.ExecuteNonQuery();
                cnn.Deconnecter();
                MessageBox.Show("added successfully");
            }
        }

        private void btn_select_image_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "select image(*.Jpg; *.png; *Gif)| *.Jpg; *.png; *Gif";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imglocation = dialog.FileName.ToString();
                pictureBox1.ImageLocation = imglocation;

            }
        }



        private void btn_liste_Click(object sender, EventArgs e)
        {
            FormListeDesPersonnels pp = new FormListeDesPersonnels();
            pp.Show();
            pp.affichier();
        }

        private void btn_modifier_Click(object sender, EventArgs e)
        {
            if (txt_nom.Text != "" && txt_prenom.Text != "" && txt_cin.Text != "" && txt_lieu.Text != "" && txt_natio.Text != "" && txt_poste.Text != "" && txt_tel.Text != "" && txt_diplome.Text != "" && txt_email.Text != "" && combobox1.Text != "" && pictureBox1.Image != null)
            {
                byte[] images = null;
                FileStream streamm = new FileStream(imglocation, FileMode.Open, FileAccess.Read);
                BinaryReader brs = new BinaryReader(streamm);
                images = brs.ReadBytes((int)streamm.Length);
                cnn.Connecter();
                cnn.cmd = new SqlCommand("update prof set nom=@nom,prenom=@prenom,sexe=@sexe,Date_naissance=@Date_naissance,email=@email,tel=@tel,diplome=@diplome,Lieu_naissance=@Lieu_naissance,Nationnalite=@Nationnalite,photo=@photo,poste=@poste where @cin=cin", cnn.con);
                cnn.cmd.Parameters.AddWithValue("@cin", txt_cin.Text);
                cnn.cmd.Parameters.AddWithValue("@poste", txt_poste.Text);
                cnn.cmd.Parameters.AddWithValue("@nom", txt_nom.Text);
                cnn.cmd.Parameters.AddWithValue("@prenom", txt_prenom.Text);
                cnn.cmd.Parameters.AddWithValue("@sexe", combobox1.Text.ToString());
                cnn.cmd.Parameters.AddWithValue("@Date_naissance", dateTimePicker1.Text.ToString());
                cnn.cmd.Parameters.AddWithValue("@email", txt_email.Text);
                cnn.cmd.Parameters.AddWithValue("@tel", txt_tel.Text);
                cnn.cmd.Parameters.AddWithValue("@diplome", txt_diplome.Text);
                cnn.cmd.Parameters.AddWithValue("@lieu_naissance", txt_lieu.Text);
                cnn.cmd.Parameters.AddWithValue("@Nationnalite", txt_natio.Text);
                cnn.cmd.Parameters.AddWithValue("@photo", images);
                cnn.cmd.ExecuteNonQuery();
                cnn.Deconnecter();
                MessageBox.Show("updated");
            }
        }
    }
}
