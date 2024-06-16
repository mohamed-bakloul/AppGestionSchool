using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppGestionSchool.Forms;
using System.Data.SqlClient;

namespace AppGestionSchool.Forms
{
    public partial class FormHome : Form
    {
        public FormHome()
        {
           
            InitializeComponent();
            dernierDepense();
        }

        Connexion cnn = new Connexion();

        public string NombreHome(string query, Label label)
        {
            string Nombre = "";

            cnn.Connecter();

            cnn.sda = new SqlDataAdapter(query, cnn.con);
            cnn.dt = new DataTable();
            cnn.sda.Fill(cnn.dt);
            Nombre = cnn.dt.Rows[0][0].ToString();
            label.Text = Nombre;
            cnn.Deconnecter();

            return Nombre;
        }

        private void FormHome_Load(object sender, EventArgs e)
        {
            NombreHome("select count(*) from eleves", lblNombreEleves);

            NombreHome("select count(*) from classes", lblNombreClasses);

            NombreHome("select count(*) from prof", lblNombrePersonneles);
        }



        public void dernierDepense(){
            cnn.Connecter();
            cnn.sda = new SqlDataAdapter(" select top 10 eleves.cne,eleves.nom,eleves.prenom ,depense.date_depense  from depense,eleves where depense.cne=eleves.cne order by date_depense desc",cnn.con);
            cnn.dt = new DataTable();
            cnn.sda.Fill(cnn.dt);
            ListePayement.DataSource = cnn.dt;



            cnn.Deconnecter();



        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            FormClasses classs = new FormClasses();

            navigationHome(classs);
        }
        public void navigationHome(Form form){


            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            Form1.form1Instance.panelDesktopPanel.Controls.Add(form);
            Form1.form1Instance.panelDesktopPanel.Tag = form;
            form.BringToFront();
            form.Show();
            Form1.form1Instance.lbl_Title.Text = form.Text;
            this.Hide();
        }
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            FormEleves eleve = new FormEleves();

            navigationHome(eleve);


        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            FormPersonnel perso = new FormPersonnel();


            navigationHome(perso);
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            FormDepenses depense = new FormDepenses();

            navigationHome(depense);
        }
    }
}
