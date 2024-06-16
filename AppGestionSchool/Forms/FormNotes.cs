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
using Guna.UI2.WinForms;

namespace AppGestionSchool.Forms
{
    public partial class FormNotes : Form
    {
        Connexion cnn = new Connexion();
        public FormNotes()
        {
           // kansmm3k
            InitializeComponent();
            
            remplirfilter(cmb_matiere,"select id,description from matiere", "description", "id");
            remplirfilter(combobox,"select id,description from matiere", "description", "id");
            remplirfilter(cmb_classe, "select reference,description from classes", "description", "reference");

            affichage();

            combobox.SelectedIndex = -1;
        }

        public void RechercherEleve(string cne)
        {
            cnn.Connecter();

            cnn.sda = new SqlDataAdapter("select classes.description as 'Classe',eleves.cne,nom,prenom,matiere.description as 'Matiere',notes,datenote from eleves,note,matiere,classes where eleves.cne=note.cne and matiere.id=note.id and eleves.classe=classes.reference and eleves.cne=@cne",cnn.con);
            cnn.sda.SelectCommand.Parameters.AddWithValue("@cne", cne);
            DataTable table = new DataTable();
            cnn.sda.Fill(table);
            guna2DataGridView1.DataSource = table;

            cnn.Deconnecter();
        }

        public void Vider()
        {
            txt_cne.Text = txt_nom.Text = txt_classe.Text = txt_note.Text = txt_prenom.Text = "";
            combobox.SelectedIndex = -1;
        }

        public bool TrouveNoteParEleve(string cne,string matiere)
        {
            bool Trouve = false;
            cnn.Connecter();

            cnn.cmd = new SqlCommand("select COUNT(*) from eleves,note,matiere,classes where eleves.cne=note.cne and matiere.id=note.id and eleves.classe=classes.reference and eleves.cne=@cne and matiere.description=@desc",cnn.con);
            cnn.cmd.Parameters.AddWithValue("@cne", cne);
            cnn.cmd.Parameters.AddWithValue("@desc", matiere);
            int Nombre = (int)cnn.cmd.ExecuteScalar();
            if (Nombre == 0)
            {
                Trouve = false;
            }
            else
            {
                Trouve = true;
            }

            cnn.Deconnecter();

            return Trouve;
        }
        
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (TrouveNoteParEleve(txt_cne.Text,combobox.Text))
            {
                MessageBox.Show("Warning !");
            }
            else
            {
                if(txt_cne.Text!="" && txt_classe.Text!="" && txt_nom.Text!="" && txt_prenom.Text!="" && txt_note.Text!="" && combobox.Text != "")
                {
                    cnn.Connecter();
                    cnn.cmd = new SqlCommand("insert into note values(@cne,@id,@notes,@datenote)", cnn.con);
                    cnn.cmd.Parameters.AddWithValue("@id", combobox.SelectedValue);
                    cnn.cmd.Parameters.AddWithValue("@cne", txt_cne.Text);
                    cnn.cmd.Parameters.AddWithValue("@notes", txt_note.Text);
                    cnn.cmd.Parameters.AddWithValue("datenote", DateTime.Now.ToString());
                    cnn.cmd.ExecuteNonQuery();
                    cnn.Deconnecter();
                    MessageBox.Show("added !!!!!!");
                    affichage();
                    Vider();
                }
                else
                {
                    MessageBox.Show("Attention, veuillez remplir les champs !");
                }
            }
        }

        public void affichage()
        {
            cnn.Connecter();
            cnn.sda = new SqlDataAdapter("select classes.description as 'Classe',eleves.cne,nom,prenom,matiere.description as 'Matiere',notes,datenote,matiere.id from eleves,note,matiere,classes where eleves.cne=note.cne and matiere.id=note.id and eleves.classe=classes.reference", cnn.con);
            cnn.dt = new DataTable();
            cnn.sda.Fill(cnn.dt);
            guna2DataGridView1.DataSource = cnn.dt;
            guna2DataGridView1.Columns[7].Visible = false;

            cnn.Deconnecter();
        }
        public void remplirfilter(Guna2ComboBox combo,string query,string display,string value)
        {
            cnn.Connecter();
            cnn.sda = new SqlDataAdapter(query, cnn.con);
            cnn.dt = new DataTable();
            cnn.sda.Fill(cnn.dt);
            combo.DisplayMember = display;
            combo.ValueMember = value;
            combo.DataSource = cnn.dt;
            cnn.Deconnecter();

        }

       



        private void guna2TextBox1_Leave(object sender, EventArgs e)
        {
            if (txt_cne.Text != "")
            {
                cnn.Connecter();
                cnn.sda = new SqlDataAdapter(" select nom,prenom,description from eleves,classes where eleves.classe =classes.reference and cne=@cne", cnn.con);
                cnn.sda.SelectCommand.Parameters.AddWithValue("@cne", txt_cne.Text);
                cnn.dt = new DataTable();
                cnn.sda.Fill(cnn.dt);
                if (cnn.dt.Rows.Count > 0)
                {
                    string nom = cnn.dt.Rows[0][0].ToString();
                    string prenom = cnn.dt.Rows[0][1].ToString();
                    string description = cnn.dt.Rows[0][2].ToString();
                    txt_nom.Text = nom;
                    txt_prenom.Text = prenom;
                    txt_classe.Text = description;
                    txt_nom.ReadOnly = txt_prenom.ReadOnly = txt_classe.ReadOnly = true;


                }
                else
                {
                    MessageBox.Show("cne invalide!");
                }


                cnn.Deconnecter();
            }
        }

        private void btn_filter_Click(object sender, EventArgs e)
        {
            cnn.Connecter();
            cnn.sda = new SqlDataAdapter("select classes.description as 'Classe',eleves.cne,nom,prenom,matiere.description as 'Matiere',notes,datenote from eleves,note,matiere,classes where eleves.cne=note.cne and matiere.id=note.id and eleves.classe=classes.reference and classes.description = @description and matiere.description = @ds",cnn.con);
            cnn.sda.SelectCommand.Parameters.AddWithValue("@description",cmb_classe.Text);
            cnn.sda.SelectCommand.Parameters.AddWithValue("@ds",cmb_matiere.Text);
            cnn.dt = new DataTable();
            cnn.sda.Fill(cnn.dt);
            guna2DataGridView1.DataSource = cnn.dt;
            cnn.Deconnecter();
        }

        private void guna2DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.Rows.Count > 0)
            {
                txt_cne.Text = guna2DataGridView1.CurrentRow.Cells[1].Value.ToString();
                txt_nom.Text = guna2DataGridView1.CurrentRow.Cells[2].Value.ToString();
                txt_prenom.Text = guna2DataGridView1.CurrentRow.Cells[3].Value.ToString();
                txt_classe.Text = guna2DataGridView1.CurrentRow.Cells[0].Value.ToString();
                combobox.Text = guna2DataGridView1.CurrentRow.Cells[4].Value.ToString();
                txt_note.Text = guna2DataGridView1.CurrentRow.Cells[5].Value.ToString();
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (TrouveNoteParEleve(txt_cne.Text, combobox.Text))
            {
                cnn.Connecter();
                cnn.cmd = new SqlCommand("update note set notes=@notes where cne=@cne and id=@id", cnn.con);
                cnn.cmd.Parameters.AddWithValue("@id", combobox.SelectedValue);
                cnn.cmd.Parameters.AddWithValue("@cne", txt_cne.Text);
                cnn.cmd.Parameters.AddWithValue("@notes", txt_note.Text);
                cnn.cmd.ExecuteNonQuery();
                cnn.Deconnecter();
                MessageBox.Show("updated !!!!!!");
                affichage();
                Vider();
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            RechercherEleve(txt_cne.Text);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count == 1)
            {
                DialogResult dr = (MessageBox.Show("Voulez-vous vraiment supprimer la note?", "Vérification", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question));
                if (dr == DialogResult.Yes)
                {

                    cnn.Connecter();

                    cnn.cmd = new SqlCommand("delete from note where cne=@cne and id=@id", cnn.con);
                    cnn.cmd.Parameters.AddWithValue("@cne", guna2DataGridView1.CurrentRow.Cells[1].Value.ToString());
                    cnn.cmd.Parameters.AddWithValue("@id", guna2DataGridView1.CurrentRow.Cells[7].Value.ToString());
                    cnn.cmd.ExecuteNonQuery();
                    MessageBox.Show("Deleted!!!");
                    affichage();
                    Vider();

                    cnn.Deconnecter();
                }
            }
        }
        private void btn_actualiser_Click(object sender, EventArgs e)
        {
            affichage();
        }
    }
}
