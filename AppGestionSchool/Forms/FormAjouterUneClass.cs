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
    public partial class FormAjouterUneClass : Form
    {
        public FormAjouterUneClass()
        {
            InitializeComponent();
        }
        Connexion cnn = new Connexion();
        public void vider()
        {
            txt_reference.Text = txt_niveau.Text = txt_description.Text= "";
        }
        FormClasses ff = new FormClasses();
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            
            if (txt_reference.Text != "" && txt_description.Text != "" && txt_niveau.Text != "" )
            {
                cnn.Connecter();
                cnn.cmd = new SqlCommand("insert into classes values(@reference,@niveau,@description)", cnn.con);
                cnn.cmd.Parameters.AddWithValue("@niveau", txt_niveau.Text);
                cnn.cmd.Parameters.AddWithValue("@description", txt_description.Text);
                cnn.cmd.Parameters.AddWithValue("@reference", txt_reference.Text);

                cnn.cmd.ExecuteNonQuery();
                cnn.Deconnecter();
                vider();
                ff.affichierclasses();
                MessageBox.Show("added successfully");
            }
        }
    }
}
