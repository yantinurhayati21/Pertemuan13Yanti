using MySqlConnector;
using Pertemuan13Yanti.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pertemuan13Yanti.View
{
    public partial class FormLogin : Form
    {
        GetDataController getDataController;
        public FormLogin()
        {
            getDataController = new GetDataController();
            InitializeComponent();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            if((txtUs.Text =="") || (txtPsw.Text==""))
            {
                MessageBox.Show("Need login data", "Wrong Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string name = txtUs.Text;
                string pass = txtPsw.Text;
                DataTable table = getDataController.getList(new MySqlCommand
                    ("select * from Admin where username = '" + name + "' and pass='" + pass + "'"));

                if(table.Rows.Count > 0 )
                {
                    MessageBox.Show("Login Success");
                    Home home = new Home();
                    this.Hide();
                    home.Show();
                }
                else
                {
                    MessageBox.Show("Your admin and password are not exist", "WrongLogin", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void pictureClose_Click(object sender, EventArgs e)
        {
            if(pictureOpen.Visible==false)
            {
                pictureOpen.Visible = true;
                txtPsw.UseSystemPasswordChar = false;
            }
        }

        private void pictureOpen_Click(object sender, EventArgs e)
        {
            if (pictureOpen.Visible == true)
            {
                pictureOpen.Visible = false;
                txtPsw.UseSystemPasswordChar = true;
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            pictureOpen.Visible = false;
            pictureClose.Visible = true;
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            txtUs.Clear();
            txtPsw.Clear();
            FormSignUp formSignUp = new FormSignUp();
            formSignUp.Show();
            this.Hide();
        }
    }
}
