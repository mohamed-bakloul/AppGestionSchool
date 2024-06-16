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
namespace AppGestionSchool
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

        }
        //instance classe connexion
        Connexion cnn = new Connexion();
        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2ControlBox2_Click(object sender, EventArgs e)
        {

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_username.Text == "" || txt_password.Text == "")
                {
                    throw new Exception("information empty!!");



                }

                cnn.Connecter();
                cnn.sda = new SqlDataAdapter("select * from login where username=@username and password=@password", cnn.con);
                //adding param from database
                cnn.sda.SelectCommand.Parameters.AddWithValue("@username", txt_username.Text);
                cnn.sda.SelectCommand.Parameters.AddWithValue("@password", txt_password.Text);
                //add into datatable
                DataTable dt = new DataTable();
                cnn.sda.Fill(dt);
                // if no user comes from database
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("user not found");

                }
                cnn.Deconnecter();
                this.Hide();
                Form1 f = new Form1();
                f.Show();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




        }
    }
}
