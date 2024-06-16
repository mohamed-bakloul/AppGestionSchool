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

namespace AppGestionSchool
{
    public partial class Form1 : Form
    {
        //Fields
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;

        public static Form1 form1Instance;

        public Form1()
        {
            InitializeComponent();
            random = new Random();
            btnCloseChildForm.Visible = false;
            this.Text = string.Empty;
            this.ControlBox = false;
            //maximize window with drag
            //this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            form1Instance = this;
        }

        //drag
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        //Colors Selection
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
              index=  random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        //active button
        private void ActivateButton(object btnSender) 
        {
            if (btnSender!= null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panelTitle.BackColor = color;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color,-0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    btnCloseChildForm.Visible =true;
                }

            }
        }
        //disable button
        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.White;
                    previousBtn.ForeColor = Color.FromArgb(0, 0, 64);
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }
        //buttons theme in forms
        private void OpenChildForm(Form childForm,object btnSender)
        {
            if(activeForm != null)
            {
                activeForm.Close();
            }
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPanel.Controls.Add(childForm);
            this.panelDesktopPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lbl_Title.Text = childForm.Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (panelDesktopPanel.Controls.Count == 0)
            {
                FormHome fr = new FormHome();
                fr.TopLevel = false;
                fr.FormBorderStyle = FormBorderStyle.None;
                fr.Dock = DockStyle.Fill;
                this.panelDesktopPanel.Controls.Add(fr);
                this.panelDesktopPanel.Tag = fr;
                fr.BringToFront();
                fr.Show();
                lbl_Title.Text = "Home";
            }
        }
        Connexion cnn = new Connexion();
        
        private void button1_Click(object sender, EventArgs e)
        {//Classes
            OpenChildForm(new Forms.FormClasses(),sender);
           // FormClasses fc = new FormClasses();
           // fc.affichierclasses();
        }

        private void button3_Click(object sender, EventArgs e)
        {//Notes
            OpenChildForm(new Forms.FormNotes(), sender);
        }

        private void btnAbs_Click(object sender, EventArgs e)
        {//Absense
            OpenChildForm(new FormAbsences(), sender);
        }

        private void btnEleves_Click(object sender, EventArgs e)
        {//Eleves
            OpenChildForm(new Forms.FormEleves(), sender);
        }

        private void btnEmploi_Click(object sender, EventArgs e)
        {//Emploidutemps
            OpenChildForm(new FormListeClasse(), sender);
        }
        //button close *reset*
        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();

            FormHome fr = new FormHome();
            fr.TopLevel = false;
            fr.FormBorderStyle = FormBorderStyle.None;
            fr.Dock = DockStyle.Fill;
            this.panelDesktopPanel.Controls.Add(fr);
            this.panelDesktopPanel.Tag = fr;
            fr.BringToFront();
            fr.Show();
            lbl_Title.Text = "Home";

            //Reset();
        }

        //private void Reset()
        //{
        //    DisableButton();
        //    lbl_Title.Text = "HOME";
        //    panelTitle.BackColor = Color.Indigo;
        //    panelLogo.BackColor = Color.FromArgb(0, 0, 64);
        //    currentButton = null;
        //    btnCloseChildForm.Visible = false;
        //}
        //mouse event 
        private void panelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {//Depenses
            OpenChildForm(new Forms.FormDepenses(), sender);
        }

        private void btnPersonnel_Click(object sender, EventArgs e)
        {//Personnel
            OpenChildForm(new Forms.FormPersonnel(), sender);
        }

        private void panelDesktopPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            //Login lg = new Login();
            //lg.ShowDialog();
        }
    }
}
