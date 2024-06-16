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
    public partial class FormEmploi : Form
    {
        public FormEmploi()
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
        string query_prof = "select cin,nom from prof where poste like 'pro%'";
        string query_matiere = "select id,description from matiere";
        private void FormEmploi_Load(object sender, EventArgs e)
        {
            //liste_matiere();
            //liste_prof();
            //med();
            //prof
            RemplirCombo(lundi_prof_8h15, query_prof, "nom", "cin");
            RemplirCombo(lundi_prof_10h05, query_prof, "nom", "cin");
            RemplirCombo(lundi_prof_14h15, query_prof, "nom", "cin");
            RemplirCombo(lundi_prof_16h05, query_prof, "nom", "cin");

            RemplirCombo(mardi_prof_8h15, query_prof, "nom", "cin");
            RemplirCombo(mardi_prof_10h05, query_prof, "nom", "cin");
            RemplirCombo(mardi_prof_14h15, query_prof, "nom", "cin");
            RemplirCombo(mardi_prof_16h05, query_prof, "nom", "cin");

            RemplirCombo(mercredi_prof_8h15, query_prof, "nom", "cin");
            RemplirCombo(mercredi_prof_10h05, query_prof, "nom", "cin");
            RemplirCombo(mercredi_prof_14h15, query_prof, "nom", "cin");
            RemplirCombo(mercredi_prof_16h05, query_prof, "nom", "cin");

            RemplirCombo(jeudi_prof_8h15, query_prof, "nom", "cin");
            RemplirCombo(jeudi_prof_10h05, query_prof, "nom", "cin");
            RemplirCombo(jeudi_prof_14h15, query_prof, "nom", "cin");
            RemplirCombo(jeudi_prof_16h05, query_prof, "nom", "cin");

            RemplirCombo(vendredi_prof_8h15, query_prof, "nom", "cin");
            RemplirCombo(vendredi_prof_10h05, query_prof, "nom", "cin");
            RemplirCombo(vendredi_prof_14h15, query_prof, "nom", "cin");
            RemplirCombo(vendredi_prof_16h05, query_prof, "nom", "cin");
            //matiere
            RemplirCombo(lundi_matiere_8h15, query_matiere, "description", "id");
            RemplirCombo(lundi_matiere_10h05, query_matiere, "description", "id");
            RemplirCombo(lundi_matiere_14h15, query_matiere, "description", "id");
            RemplirCombo(lundi_matiere_16h05, query_matiere, "description", "id");

            RemplirCombo(mardi_matiere_8h15, query_matiere, "description", "id");
            RemplirCombo(mardi_matiere_10h05, query_matiere, "description", "id");
            RemplirCombo(mardi_matiere_14h15, query_matiere, "description", "id");
            RemplirCombo(mardi_matiere_16h05, query_matiere, "description", "id");

            RemplirCombo(mercredi_matiere_8h15, query_matiere, "description", "id");
            RemplirCombo(mercredi_matiere_10h05, query_matiere, "description", "id");
            RemplirCombo(mercredi_matiere_14h15, query_matiere, "description", "id");
            RemplirCombo(mercredi_matiere_16h05, query_matiere, "description", "id");

            RemplirCombo(jeudi_matiere_8h15, query_matiere, "description", "id");
            RemplirCombo(jeudi_matiere_10h05, query_matiere, "description", "id");
            RemplirCombo(jeudi_matiere_14h15, query_matiere, "description", "id");
            RemplirCombo(jeudi_matiere_16h05, query_matiere, "description", "id");

            RemplirCombo(vendredi_matiere_8h15, query_matiere, "description", "id");
            RemplirCombo(vendredi_matiere_10h05, query_matiere, "description", "id");
            RemplirCombo(vendredi_matiere_14h15, query_matiere, "description", "id");
            RemplirCombo(vendredi_matiere_16h05, query_matiere, "description", "id");


            EmploiByClass();

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        Connexion cnn = new Connexion();

        public void EmploiByClass()
        {
            if (trouve_emploi())
            {
                cnn.Connecter();

                string query = "select * from emploi where classename=@classename";
                
                cnn.sda = new SqlDataAdapter(query,cnn.con);
                cnn.sda.SelectCommand.Parameters.AddWithValue("@classename", lbl_nomclasse.Text);
                cnn.dt = new DataTable();
                cnn.sda.Fill(cnn.dt);
                if (cnn.dt.Rows.Count > 0)
                {//lundi
                    lundi_matiere_8h15.Text = cnn.dt.Rows[0][1].ToString();
                    lundi_prof_8h15.Text = cnn.dt.Rows[0][2].ToString();

                    lundi_matiere_10h05.Text = cnn.dt.Rows[0][3].ToString();
                    lundi_prof_10h05.Text = cnn.dt.Rows[0][4].ToString();

                    lundi_matiere_14h15.Text = cnn.dt.Rows[0][5].ToString();
                    lundi_prof_14h15.Text = cnn.dt.Rows[0][6].ToString();

                    lundi_matiere_16h05.Text = cnn.dt.Rows[0][7].ToString();
                    lundi_prof_16h05.Text = cnn.dt.Rows[0][8].ToString();
                    //mardi
                    mardi_matiere_8h15.Text = cnn.dt.Rows[0][9].ToString();
                    mardi_prof_8h15.Text = cnn.dt.Rows[0][10].ToString();

                    mardi_matiere_10h05.Text = cnn.dt.Rows[0][11].ToString();
                    mardi_prof_10h05.Text = cnn.dt.Rows[0][12].ToString();

                    mardi_matiere_14h15.Text = cnn.dt.Rows[0][13].ToString();
                    mardi_prof_14h15.Text = cnn.dt.Rows[0][14].ToString();

                    mardi_matiere_16h05.Text = cnn.dt.Rows[0][15].ToString();
                    mardi_prof_16h05.Text = cnn.dt.Rows[0][16].ToString();
                    //mercredi
                    mercredi_matiere_8h15.Text = cnn.dt.Rows[0][17].ToString();
                    mercredi_prof_8h15.Text = cnn.dt.Rows[0][18].ToString();

                    mercredi_matiere_10h05.Text = cnn.dt.Rows[0][19].ToString();
                    mercredi_prof_10h05.Text = cnn.dt.Rows[0][20].ToString();

                    mercredi_matiere_14h15.Text = cnn.dt.Rows[0][21].ToString();
                    mercredi_prof_14h15.Text = cnn.dt.Rows[0][22].ToString();

                    mercredi_matiere_16h05.Text = cnn.dt.Rows[0][23].ToString();
                    mercredi_prof_16h05.Text = cnn.dt.Rows[0][24].ToString();
                    //jeudi
                    jeudi_matiere_8h15.Text = cnn.dt.Rows[0][25].ToString();
                    jeudi_prof_8h15.Text = cnn.dt.Rows[0][26].ToString();

                    jeudi_matiere_10h05.Text = cnn.dt.Rows[0][27].ToString();
                    jeudi_prof_10h05.Text = cnn.dt.Rows[0][28].ToString();

                    jeudi_matiere_14h15.Text = cnn.dt.Rows[0][29].ToString();
                    jeudi_prof_14h15.Text = cnn.dt.Rows[0][30].ToString();

                    jeudi_matiere_16h05.Text = cnn.dt.Rows[0][31].ToString();
                    jeudi_prof_16h05.Text = cnn.dt.Rows[0][32].ToString();
                    //vendredi
                    vendredi_matiere_8h15.Text = cnn.dt.Rows[0][33].ToString();
                    vendredi_prof_8h15.Text = cnn.dt.Rows[0][34].ToString();

                    vendredi_matiere_10h05.Text = cnn.dt.Rows[0][35].ToString();
                    vendredi_prof_10h05.Text = cnn.dt.Rows[0][36].ToString();

                    vendredi_matiere_14h15.Text = cnn.dt.Rows[0][37].ToString();
                    vendredi_prof_14h15.Text = cnn.dt.Rows[0][38].ToString();

                    vendredi_matiere_16h05.Text = cnn.dt.Rows[0][39].ToString();
                    vendredi_prof_16h05.Text = cnn.dt.Rows[0][40].ToString();




                }

                cnn.Deconnecter();
            }
            else
            {
                //Nothing to do
            }
        }
        
        public bool trouve_emploi()
        {
            bool trouve = false;
            cnn.Connecter();
            cnn.cmd = new SqlCommand("select count(*) from emploi where classename=@classename", cnn.con);
            cnn.cmd.Parameters.AddWithValue("@classename", lbl_nomclasse.Text);
            int nbr = (int)cnn.cmd.ExecuteScalar();
            if (nbr == 0)
            {
                trouve = false;
            }
            else
            {
                trouve = true;
            }
            return trouve;
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show(lbl_nomclasse.Text);

            MessageBox.Show(trouve_emploi().ToString());

            if (trouve_emploi())
            {
                cnn.Connecter();
                string query = "update emploi set " +
                    " lundi_8H15_9h50   = @lundi_8H15_9h50, proflundi_8H15_9h50 = @proflundi_8H15_9h50," +
                    " lundi_10H05_11h35 = @lundi_10H05_11h35, proflundi_10H05_11h35 =@proflundi_10H05_11h35," +
                    " lundi_14H15_15h50 = @lundi_14H15_15h50, proflundi_14H15_15h50 = @proflundi_14H15_15h50," +
                    " lundi_16H05_17h35 = @lundi_16H05_17h35, proflundi_16H05_17h35 = @proflundi_16H05_17h35," +

                    " mardi_8H15_9h50   = @mardi_8H15_9h50,   profmardi_8H15_9h50 = @profmardi_8H15_9h50," +
                    " mardi_10H05_11h35 = @mardi_10H05_11h35, profmardi_10H05_11h35 = @profmardi_10H05_11h35," +
                    " mardi_14H15_15h50 = @mardi_14H15_15h50, profmardi_14H15_15h50 = @profmardi_14H15_15h50," +
                    " mardi_16H05_17h35 = @mardi_16H05_17h35, profmardi_16H05_17h35 = @profmardi_16H05_17h35," +

                    " mercredi_8H15_9h50   = @mercredi_8H15_9h50, profmercredi_8H15_9h50 = @profmercredi_8H15_9h50," +
                    " mercredi_10H05_11h35 = @mercredi_10H05_11h35, profmercredi_10H05_11h35 = @profmercredi_10H05_11h35," +
                    " mercredi_14H15_15h50 = @mercredi_14H15_15h50, profmercredi_14H15_15h50 = @profmercredi_14H15_15h50," +
                    " mercredi_16H05_17h35 = @mercredi_16H05_17h35, profmercredi_16H05_17h35 = @profmercredi_16H05_17h35," +

                    " jeudi_8H15_9h50   = @jeudi_8H15_9h50, profjeudi_8H15_9h50 = @profjeudi_8H15_9h50," +
                    " jeudi_10H05_11h35 = @jeudi_10H05_11h35, profjeudi_10H05_11h35 = @profjeudi_10H05_11h35," +
                    " jeudi_14H15_15h50 = @jeudi_14H15_15h50, profjeudi_14H15_15h50 = @profjeudi_14H15_15h50," +
                    " jeudi_16H05_17h35 = @jeudi_16H05_17h35, profjeudi_16H05_17h35 = @profjeudi_16H05_17h35," +

                    " vendredi_8H15_9h50   = @vendredi_8H15_9h50, profvendredi_8H15_9h50 = @profvendredi_8H15_9h50, " +
                    " vendredi_10H05_11h35 = @vendredi_10H05_11h35, profvendredi_10H05_11h35 = @profvendredi_10H05_11h35," +
                    " vendredi_14H15_15h50 = @vendredi_14H15_15h50, profvendredi_14H15_15h50 = @profvendredi_14H15_15h50," +
                    " vendredi_16H05_17h35 = @vendredi_16H05_17h35, profvendredi_16H05_17h35 = @profvendredi_16H05_17h35  where classename=@classname";

                cnn.cmd = new SqlCommand(query, cnn.con);

                cnn.cmd.Parameters.AddWithValue("@classname", lbl_nomclasse.Text);

                cnn.cmd.Parameters.AddWithValue("@lundi_8H15_9h50", lundi_matiere_8h15.Text);
                cnn.cmd.Parameters.AddWithValue("@lundi_10H05_11h35", lundi_matiere_10h05.Text);
                cnn.cmd.Parameters.AddWithValue("@lundi_14H15_15h50", lundi_matiere_14h15.Text);
                cnn.cmd.Parameters.AddWithValue("@lundi_16H05_17h35", lundi_matiere_16h05.Text);

                cnn.cmd.Parameters.AddWithValue("@proflundi_8H15_9h50", lundi_prof_8h15.Text);
                cnn.cmd.Parameters.AddWithValue("@proflundi_10H05_11h35", lundi_prof_10h05.Text);
                cnn.cmd.Parameters.AddWithValue("@proflundi_14H15_15h50", lundi_prof_14h15.Text);
                cnn.cmd.Parameters.AddWithValue("@proflundi_16H05_17h35", lundi_prof_16h05.Text);

                cnn.cmd.Parameters.AddWithValue("@mardi_8H15_9h50", mardi_matiere_8h15.Text);
                cnn.cmd.Parameters.AddWithValue("@mardi_10H05_11h35", mardi_matiere_10h05.Text);
                cnn.cmd.Parameters.AddWithValue("@mardi_14H15_15h50", mardi_matiere_14h15.Text);
                cnn.cmd.Parameters.AddWithValue("@mardi_16H05_17h35", mardi_matiere_16h05.Text);

                cnn.cmd.Parameters.AddWithValue("@profmardi_8H15_9h50", mardi_prof_8h15.Text);
                cnn.cmd.Parameters.AddWithValue("@profmardi_10H05_11h35", mardi_prof_10h05.Text);
                cnn.cmd.Parameters.AddWithValue("@profmardi_14H15_15h50", mardi_prof_14h15.Text);
                cnn.cmd.Parameters.AddWithValue("@profmardi_16H05_17h35", mardi_prof_16h05.Text);

                cnn.cmd.Parameters.AddWithValue("@mercredi_8H15_9h50", mercredi_matiere_8h15.Text);
                cnn.cmd.Parameters.AddWithValue("@mercredi_10H05_11h35", mercredi_matiere_10h05.Text);
                cnn.cmd.Parameters.AddWithValue("@mercredi_14H15_15h50", mercredi_matiere_14h15.Text);
                cnn.cmd.Parameters.AddWithValue("@mercredi_16H05_17h35", mercredi_matiere_16h05.Text);

                cnn.cmd.Parameters.AddWithValue("@profmercredi_8H15_9h50", mercredi_prof_8h15.Text);
                cnn.cmd.Parameters.AddWithValue("@profmercredi_10H05_11h35", mercredi_prof_10h05.Text);
                cnn.cmd.Parameters.AddWithValue("@profmercredi_14H15_15h50", mercredi_prof_14h15.Text);
                cnn.cmd.Parameters.AddWithValue("@profmercredi_16H05_17h35", mercredi_prof_16h05.Text);

                cnn.cmd.Parameters.AddWithValue("@jeudi_8H15_9h50", jeudi_matiere_8h15.Text);
                cnn.cmd.Parameters.AddWithValue("@jeudi_10H05_11h35", jeudi_matiere_10h05.Text);
                cnn.cmd.Parameters.AddWithValue("@jeudi_14H15_15h50", jeudi_matiere_14h15.Text);
                cnn.cmd.Parameters.AddWithValue("@jeudi_16H05_17h35", jeudi_matiere_16h05.Text);

                cnn.cmd.Parameters.AddWithValue("@profjeudi_8H15_9h50", jeudi_prof_8h15.Text);
                cnn.cmd.Parameters.AddWithValue("@profjeudi_10H05_11h35", jeudi_prof_10h05.Text);
                cnn.cmd.Parameters.AddWithValue("@profjeudi_14H15_15h50", jeudi_prof_14h15.Text);
                cnn.cmd.Parameters.AddWithValue("@profjeudi_16H05_17h35", jeudi_prof_16h05.Text);

                cnn.cmd.Parameters.AddWithValue("@vendredi_8H15_9h50", vendredi_matiere_8h15.Text);
                cnn.cmd.Parameters.AddWithValue("@vendredi_10H05_11h35", vendredi_matiere_10h05.Text);
                cnn.cmd.Parameters.AddWithValue("@vendredi_14H15_15h50", vendredi_matiere_14h15.Text);
                cnn.cmd.Parameters.AddWithValue("@vendredi_16H05_17h35", vendredi_matiere_16h05.Text);

                cnn.cmd.Parameters.AddWithValue("@profvendredi_8H15_9h50", vendredi_prof_8h15.Text);
                cnn.cmd.Parameters.AddWithValue("@profvendredi_10H05_11h35", vendredi_prof_10h05.Text);
                cnn.cmd.Parameters.AddWithValue("@profvendredi_14H15_15h50", vendredi_prof_14h15.Text);
                cnn.cmd.Parameters.AddWithValue("@profvendredi_16H05_17h35", vendredi_prof_16h05.Text);


                cnn.cmd.ExecuteNonQuery();
                cnn.Deconnecter();
                MessageBox.Show("modified !");
            }
            else
            {
                cnn.Connecter();
                string query = "insert into emploi values( " +

                    " @classname," +

                    " @lundi_8H15_9h50,   @proflundi_8H15_9h50," +
                    " @lundi_10H05_11h35, @proflundi_10H05_11h35," +
                    " @lundi_14H15_15h50, @proflundi_14H15_15h50," +
                    " @lundi_16H05_17h35, @proflundi_16H05_17h35," +

                    " @mardi_8H15_9h50,   @profmardi_8H15_9h50," +
                    " @mardi_10H05_11h35, @profmardi_10H05_11h35," +
                    " @mardi_14H15_15h50, @profmardi_14H15_15h50," +
                    " @mardi_16H05_17h35, @profmardi_16H05_17h35," +

                    " @mercredi_8H15_9h50,  @profmercredi_8H15_9h50," +
                    " @mercredi_10H05_11h35, @profmercredi_10H05_11h35," +
                    " @mercredi_14H15_15h50, @profmercredi_14H15_15h50," +
                    " @mercredi_16H05_17h35, @profmercredi_16H05_17h35," +

                    " @jeudi_8H15_9h50,   @profjeudi_8H15_9h50," +
                    " @jeudi_10H05_11h35, @profjeudi_10H05_11h35," +
                    " @jeudi_14H15_15h50, @profjeudi_14H15_15h50," +
                    " @jeudi_16H05_17h35, @profjeudi_16H05_17h35," +

                    " @vendredi_8H15_9h50,   @profvendredi_8H15_9h50, " +
                    " @vendredi_10H05_11h35, @profvendredi_10H05_11h35," +
                    " @vendredi_14H15_15h50, @profvendredi_14H15_15h50," +
                    " @vendredi_16H05_17h35, @profvendredi_16H05_17h35)";

                cnn.cmd = new SqlCommand(query, cnn.con);

                cnn.cmd.Parameters.AddWithValue("@classname", lbl_nomclasse.Text);

                cnn.cmd.Parameters.AddWithValue("@lundi_8H15_9h50", lundi_matiere_8h15.Text);
                cnn.cmd.Parameters.AddWithValue("@lundi_10H05_11h35", lundi_matiere_10h05.Text);
                cnn.cmd.Parameters.AddWithValue("@lundi_14H15_15h50", lundi_matiere_14h15.Text);
                cnn.cmd.Parameters.AddWithValue("@lundi_16H05_17h35", lundi_matiere_16h05.Text);

                cnn.cmd.Parameters.AddWithValue("@proflundi_8H15_9h50", lundi_prof_8h15.Text);
                cnn.cmd.Parameters.AddWithValue("@proflundi_10H05_11h35", lundi_prof_10h05.Text);
                cnn.cmd.Parameters.AddWithValue("@proflundi_14H15_15h50", lundi_prof_14h15.Text);
                cnn.cmd.Parameters.AddWithValue("@proflundi_16H05_17h35", lundi_prof_16h05.Text);

                cnn.cmd.Parameters.AddWithValue("@mardi_8H15_9h50", mardi_matiere_8h15.Text);
                cnn.cmd.Parameters.AddWithValue("@mardi_10H05_11h35", mardi_matiere_10h05.Text);
                cnn.cmd.Parameters.AddWithValue("@mardi_14H15_15h50", mardi_matiere_14h15.Text);
                cnn.cmd.Parameters.AddWithValue("@mardi_16H05_17h35", mardi_matiere_16h05.Text);

                cnn.cmd.Parameters.AddWithValue("@profmardi_8H15_9h50", mardi_prof_8h15.Text);
                cnn.cmd.Parameters.AddWithValue("@profmardi_10H05_11h35", mardi_prof_10h05.Text);
                cnn.cmd.Parameters.AddWithValue("@profmardi_14H15_15h50", mardi_prof_14h15.Text);
                cnn.cmd.Parameters.AddWithValue("@profmardi_16H05_17h35", mardi_prof_16h05.Text);

                cnn.cmd.Parameters.AddWithValue("@mercredi_8H15_9h50", mercredi_matiere_8h15.Text);
                cnn.cmd.Parameters.AddWithValue("@mercredi_10H05_11h35", mercredi_matiere_10h05.Text);
                cnn.cmd.Parameters.AddWithValue("@mercredi_14H15_15h50", mercredi_matiere_14h15.Text);
                cnn.cmd.Parameters.AddWithValue("@mercredi_16H05_17h35", mercredi_matiere_16h05.Text);

                cnn.cmd.Parameters.AddWithValue("@profmercredi_8H15_9h50", mercredi_prof_8h15.Text);
                cnn.cmd.Parameters.AddWithValue("@profmercredi_10H05_11h35", mercredi_prof_10h05.Text);
                cnn.cmd.Parameters.AddWithValue("@profmercredi_14H15_15h50", mercredi_prof_14h15.Text);
                cnn.cmd.Parameters.AddWithValue("@profmercredi_16H05_17h35", mercredi_prof_16h05.Text);

                cnn.cmd.Parameters.AddWithValue("@jeudi_8H15_9h50", jeudi_matiere_8h15.Text);
                cnn.cmd.Parameters.AddWithValue("@jeudi_10H05_11h35", jeudi_matiere_10h05.Text);
                cnn.cmd.Parameters.AddWithValue("@jeudi_14H15_15h50", jeudi_matiere_14h15.Text);
                cnn.cmd.Parameters.AddWithValue("@jeudi_16H05_17h35", jeudi_matiere_16h05.Text);

                cnn.cmd.Parameters.AddWithValue("@profjeudi_8H15_9h50", jeudi_prof_8h15.Text);
                cnn.cmd.Parameters.AddWithValue("@profjeudi_10H05_11h35", jeudi_prof_10h05.Text);
                cnn.cmd.Parameters.AddWithValue("@profjeudi_14H15_15h50", jeudi_prof_14h15.Text);
                cnn.cmd.Parameters.AddWithValue("@profjeudi_16H05_17h35", jeudi_prof_16h05.Text);

                cnn.cmd.Parameters.AddWithValue("@vendredi_8H15_9h50", vendredi_matiere_8h15.Text);
                cnn.cmd.Parameters.AddWithValue("@vendredi_10H05_11h35", vendredi_matiere_10h05.Text);
                cnn.cmd.Parameters.AddWithValue("@vendredi_14H15_15h50", vendredi_matiere_14h15.Text);
                cnn.cmd.Parameters.AddWithValue("@vendredi_16H05_17h35", vendredi_matiere_16h05.Text);

                cnn.cmd.Parameters.AddWithValue("@profvendredi_8H15_9h50", vendredi_prof_8h15.Text);
                cnn.cmd.Parameters.AddWithValue("@profvendredi_10H05_11h35", vendredi_prof_10h05.Text);
                cnn.cmd.Parameters.AddWithValue("@profvendredi_14H15_15h50", vendredi_prof_14h15.Text);
                cnn.cmd.Parameters.AddWithValue("@profvendredi_16H05_17h35", vendredi_prof_16h05.Text);

                cnn.cmd.ExecuteNonQuery();
                cnn.Deconnecter();
                MessageBox.Show("added");
            }
        }
        //public void med()
        //{

        //    cnn.Connecter();
        //    cnn.sda = new SqlDataAdapter("select cin,nom from prof where poste like 'pro%'", cnn.con);
        //    cnn.dt = new DataTable();
        //    cnn.sda.Fill(cnn.dt);
        //    //lundi
        //    lundi_prof_10h05.DisplayMember = "nom";
        //    lundi_prof_10h05.ValueMember = "cin";
        //    lundi_prof_10h05.DataSource = cnn.dt;
        //    cnn.Deconnecter();
        //}
        //public void liste_prof()
        //{
        //    cnn.Connecter();
        //    cnn.sda = new SqlDataAdapter("select cin,nom from prof where poste like 'pro%'", cnn.con);
        //    cnn.dt = new DataTable();
        //    cnn.sda.Fill(cnn.dt);
        //    //lundi
        //    lundi_prof_8h15.DisplayMember = "nom";
        //    lundi_prof_8h15.ValueMember = "cin";
        //    lundi_prof_8h15.DataSource = cnn.dt;

        //    cnn.dt = new DataTable();
        //    cnn.sda.Fill(cnn.dt);

        //    lundi_prof_10h05.DisplayMember = "nom";
        //    lundi_prof_10h05.ValueMember = "cin";
        //    lundi_prof_10h05.DataSource = cnn.dt;

        //    lundi_prof_14h15.displaymember = "nom";
        //    lundi_prof_14h15.valuemember = "cin";
        //    lundi_prof_14h15.datasource = cnn.dt;

        //    lundi_prof_16h05.displaymember = "nom";
        //    lundi_prof_16h05.valuemember = "cin";
        //    lundi_prof_16h05.datasource = cnn.dt;


        //    //mardi
        //    mardi_prof_8h15.displaymember = "nom";
        //    mardi_prof_8h15.valuemember = "cin";
        //    mardi_prof_8h15.datasource = cnn.dt;

        //    mardi_prof_10h05.displaymember = "nom";
        //    mardi_prof_10h05.valuemember = "cin";
        //    mardi_prof_10h05.datasource = cnn.dt;

        //    mardi_prof_10h05.displaymember = "nom";
        //    mardi_prof_10h05.valuemember = "cin";
        //    mardi_prof_10h05.datasource = cnn.dt;

        //    mardi_prof_10h05.displaymember = "nom";
        //    mardi_prof_10h05.valuemember = "cin";
        //    mardi_prof_10h05.datasource = cnn.dt;
        //    //mercredi
        //    mercredi_prof_8h15.displaymember = "nom";
        //    mercredi_prof_8h15.valuemember = "cin";
        //    mercredi_prof_8h15.datasource = cnn.dt;

        //    mercredi_prof_10h05.displaymember = "nom";
        //    mercredi_prof_10h05.valuemember = "cin";
        //    mercredi_prof_10h05.datasource = cnn.dt;

        //    mercredi_prof_10h05.displaymember = "nom";
        //    mercredi_prof_10h05.valuemember = "cin";
        //    mercredi_prof_10h05.datasource = cnn.dt;

        //    mercredi_prof_10h05.displaymember = "nom";
        //    mercredi_prof_10h05.valuemember = "cin";
        //    mercredi_prof_10h05.datasource = cnn.dt;
        //    //jeudi
        //    jeudi_prof_8h15.displaymember = "nom";
        //    jeudi_prof_8h15.valuemember = "cin";
        //    jeudi_prof_8h15.datasource = cnn.dt;

        //    jeudi_prof_10h05.displaymember = "nom";
        //    jeudi_prof_10h05.valuemember = "cin";
        //    jeudi_prof_10h05.datasource = cnn.dt;

        //    jeudi_prof_10h05.displaymember = "nom";
        //    jeudi_prof_10h05.valuemember = "cin";
        //    jeudi_prof_10h05.datasource = cnn.dt;

        //    jeudi_prof_10h05.displaymember = "nom";
        //    jeudi_prof_10h05.valuemember = "cin";
        //    jeudi_prof_10h05.datasource = cnn.dt;
        //    //vendredi
        //    vendredi_prof_8h15.displaymember = "nom";
        //    vendredi_prof_8h15.valuemember = "cin";
        //    vendredi_prof_8h15.datasource = cnn.dt;

        //    vendredi_prof_10h05.displaymember = "nom";
        //    vendredi_prof_10h05.valuemember = "cin";
        //    vendredi_prof_10h05.datasource = cnn.dt;

        //    vendredi_prof_10h05.displaymember = "nom";
        //    vendredi_prof_10h05.valuemember = "cin";
        //    vendredi_prof_10h05.datasource = cnn.dt;

        //    vendredi_prof_10h05.displaymember = "nom";
        //    vendredi_prof_10h05.valuemember = "cin";
        //    vendredi_prof_10h05.datasource = cnn.dt;

        //    cnn.Deconnecter();

        //}

        //Méthode remplir Combo

        public void RemplirCombo(Guna.UI2.WinForms.Guna2ComboBox comboBox, string requet, string Display, string value)
        {
            cnn.Connecter();
            cnn.sda = new SqlDataAdapter(requet, cnn.con);
            cnn.dt = new DataTable();
            cnn.sda.Fill(cnn.dt);
            comboBox.DisplayMember = Display;
            comboBox.ValueMember = value;
            comboBox.DataSource = cnn.dt;
            comboBox.SelectedIndex = -1;
            cnn.Deconnecter();
        }

        //public void liste_matiere()
        //{
        //    cnn.Connecter();
        //    cnn.sda = new SqlDataAdapter("select id,description from matiere", cnn.con);
        //    cnn.dt = new DataTable();
        //    cnn.sda.Fill(cnn.dt);
        //    //lundi
        //    lundi_matiere_8h15.DisplayMember = "description";
        //    lundi_matiere_8h15.ValueMember = "id";
        //    lundi_matiere_8h15.DataSource = cnn.dt;

        //    lundi_matiere_10h05.DisplayMember = "description";
        //    lundi_matiere_10h05.ValueMember = "id";
        //    lundi_matiere_10h05.DataSource = cnn.dt;

        //    lundi_matiere_14h15.DisplayMember = "description";
        //    lundi_matiere_14h15.ValueMember = "id";
        //    lundi_matiere_14h15.DataSource = cnn.dt;

        //    lundi_matiere_16h05.DisplayMember = "description";
        //    lundi_matiere_16h05.ValueMember = "id";
        //    lundi_matiere_16h05.DataSource = cnn.dt;
        //    //mardi
        //    mardi_matiere_8h15.DisplayMember = "description";
        //    mardi_matiere_8h15.ValueMember = "id";
        //    mardi_matiere_8h15.DataSource = cnn.dt;

        //    mardi_matiere_10h05.DisplayMember = "description";
        //    mardi_matiere_10h05.ValueMember = "id";
        //    mardi_matiere_10h05.DataSource = cnn.dt;

        //    mardi_matiere_14h15.DisplayMember = "description";
        //    mardi_matiere_14h15.ValueMember = "id";
        //    mardi_matiere_14h15.DataSource = cnn.dt;

        //    mardi_matiere_16h05.DisplayMember = "description";
        //    mardi_matiere_16h05.ValueMember = "id";
        //    mardi_matiere_16h05.DataSource = cnn.dt;
        //    //mercredi
        //    mercredi_matiere_8h15.DisplayMember = "description";
        //    mercredi_matiere_8h15.ValueMember = "id";
        //    mercredi_matiere_8h15.DataSource = cnn.dt;

        //    mercredi_matiere_10h05.DisplayMember = "description";
        //    mercredi_matiere_10h05.ValueMember = "id";
        //    mercredi_matiere_10h05.DataSource = cnn.dt;

        //    mercredi_matiere_14h15.DisplayMember = "description";
        //    mercredi_matiere_14h15.ValueMember = "id";
        //    mercredi_matiere_14h15.DataSource = cnn.dt;

        //    mercredi_matiere_16h05.DisplayMember = "description";
        //    mercredi_matiere_16h05.ValueMember = "id";
        //    mercredi_matiere_16h05.DataSource = cnn.dt;
        //    //jeudi
        //    jeudi_matiere_8h15.DisplayMember = "description";
        //    jeudi_matiere_8h15.ValueMember = "id";
        //    jeudi_matiere_8h15.DataSource = cnn.dt;

        //    jeudi_matiere_10h05.DisplayMember = "description";
        //    jeudi_matiere_10h05.ValueMember = "id";
        //    jeudi_matiere_10h05.DataSource = cnn.dt;

        //    jeudi_matiere_14h15.DisplayMember = "description";
        //    jeudi_matiere_14h15.ValueMember = "id";
        //    jeudi_matiere_14h15.DataSource = cnn.dt;

        //    jeudi_matiere_16h05.DisplayMember = "description";
        //    jeudi_matiere_16h05.ValueMember = "id";
        //    jeudi_matiere_16h05.DataSource = cnn.dt;
        //    //vendredi
        //    vendredi_matiere_8h15.DisplayMember = "description";
        //    vendredi_matiere_8h15.ValueMember = "id";
        //    vendredi_matiere_8h15.DataSource = cnn.dt;

        //    vendredi_matiere_10h05.DisplayMember = "description";
        //    vendredi_matiere_10h05.ValueMember = "id";
        //    vendredi_matiere_10h05.DataSource = cnn.dt;

        //    vendredi_matiere_14h15.DisplayMember = "description";
        //    vendredi_matiere_14h15.ValueMember = "id";
        //    vendredi_matiere_14h15.DataSource = cnn.dt;

        //    vendredi_matiere_16h05.DisplayMember = "description";
        //    vendredi_matiere_16h05.ValueMember = "id";
        //    vendredi_matiere_16h05.DataSource = cnn.dt;
        //    cnn.Deconnecter();

        //}

        public void vider()
        {
            txt_idds.Text = txt_idmat.Text = "";
        }
        private void guna2Button7_Click(object sender, EventArgs e)
        {
            cnn.Connecter();
            cnn.cmd = new SqlCommand("insert into matiere values(@id,@ds);", cnn.con);
            cnn.cmd.Parameters.AddWithValue("@id",txt_idmat.Text);
            cnn.cmd.Parameters.AddWithValue("@ds",txt_idds.Text);
            cnn.cmd.ExecuteNonQuery();
            MessageBox.Show("matiere ajouter ");
            vider();
            cnn.Deconnecter();

        }

        private void btn_ajt_matiere_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;

        }

        private void lundi_matiere_8h15_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lundi_prof_8h15_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            cnn.delete(" delete from matiere where description=@ds","@ds",txt_idds.Text);
            vider();

        }
    }
}
