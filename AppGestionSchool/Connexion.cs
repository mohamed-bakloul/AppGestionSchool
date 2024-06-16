using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AppGestionSchool
{
    class Connexion
    {   //connexion for SQL SERVER
        //Mohammed Bakloul: MSI
        //Abderrahim Anjar: .\SQLEXPRESS01
        //Hicham labani: .

        public SqlConnection con = new SqlConnection(@"Data Source = MSI\MSSQLSERVER01; Initial Catalog = gestionschool; Integrated Security = True");
        public SqlCommand cmd;
        public SqlDataAdapter sda;
        public DataTable dt;

        // methode open connexion
        public void Connecter()
        {
            if (con.State==ConnectionState.Closed)
            {
                con.Open();

            }
           

        }
        //methode close connexion
        public void Deconnecter()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();

            }

        }
        public void delete(string query,string idsup,string value)
        {
            DialogResult dr = (MessageBox.Show("Voulez-vous vraiment supprimer la note?", "Vérification", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question));
            if (dr == DialogResult.Yes)
            {
               
                Connecter();
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue(idsup, value);
                cmd.ExecuteNonQuery();
                MessageBox.Show("deleted");
                Deconnecter();

               
            }
            
        }
        



    }
}
