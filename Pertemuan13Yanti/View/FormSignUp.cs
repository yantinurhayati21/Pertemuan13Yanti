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
    public partial class FormSignUp : Form
    {
        public FormSignUp()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            try
            {
                string psw = txtPsw.Text;
                string confirm = txtConfirm.Text;

                if (psw == confirm)
                {
                    LoginController loginController = new LoginController();
                    loginController.addAkun(txtUs.Text, psw);

                    MessageBox.Show("Saved Successfully");

                    this.Controls.Clear();
                    this.InitializeComponent();
                    txtUs.Focus();

                    FormLogin login = new FormLogin();
                    login.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Password and confirm password do not match");
                    txtConfirm.Clear();
                    txtConfirm.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
            this.Hide();
        }

        private void FormSignUp_Load(object sender, EventArgs e)
        {
            pictureOpen.Visible = false;
            pictureClose.Visible = true;
        }

        private void pictureClose_Click_1(object sender, EventArgs e)
        {
            if (pictureOpen.Visible == false)
            {
                pictureOpen.Visible = true;
                txtPsw.UseSystemPasswordChar = false;
            }
        }

        private void pictureOpen_Click_1(object sender, EventArgs e)
        {
            if (pictureOpen.Visible == true)
            {
                pictureOpen.Visible = false;
                txtPsw.UseSystemPasswordChar = true;
            }
        }
        
    }
}
