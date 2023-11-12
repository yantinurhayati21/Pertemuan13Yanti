using MySqlConnector;
using Pertemuan13Yanti.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pertemuan13Yanti.View
{
    public partial class Home : Form
    {
        private MahasiswaController mhsController = new MahasiswaController();
        private ValidasiController validasiController = new ValidasiController();
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            txtNim.MaxLength = 11;
            txtNama.MaxLength = 25;
            showStudent();
        }

        bool showStudent()
        {
            DataGridView_mahasiswa.DataSource = mhsController.selectStudent
                (new MySqlCommand("select * from Mahasiswa"));
            DataGridView_mahasiswa.RowTemplate.Height = 80;
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)DataGridView_mahasiswa.Columns[3];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            return true;
        }

        bool verify()
        {
            if((txtNama.Text=="") || (txtNim.Text =="") || (picturePhoto.Image == null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtNim.Clear();
            txtNama.Clear();
            DtTtl.Value = DateTime.Now;
            picturePhoto.Image = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int born_year = DtTtl.Value.Year;
            int this_year = DateTime.Now.Year;
            if ((this_year - born_year) <= 17 || (this_year - born_year) >= 25)
            {
                MessageBox.Show("Umur harus diantara 17 s/d 25", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(verify() && validasiController.ValidateName(txtNama.Text))
            {
                try
                {
                    MemoryStream memori = new MemoryStream();
                    picturePhoto.Image.Save(memori, picturePhoto.Image.RawFormat);
                    byte[] img = memori.ToArray();
                    mhsController.insertStudent(txtNim.Text, txtNama.Text, DtTtl.Value, img);
                    MessageBox.Show("Add Student Success", "Save data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    showStudent();
                    txtNim.Focus();

                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Input is Empty", "Add Data", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "select Photo(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif;";

            if(opf.ShowDialog() == DialogResult.OK)
            {
                picturePhoto.Image = Image.FromFile(opf.FileName);
            }
        }

        private void DataGridView_mahasiswa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNim.Text = DataGridView_mahasiswa.CurrentRow.Cells[0].Value.ToString();
            txtNama.Text = DataGridView_mahasiswa.CurrentRow.Cells[1].Value.ToString();
            DtTtl.Value = (DateTime)DataGridView_mahasiswa.CurrentRow.Cells[2].Value;
            byte[] img = (byte[])DataGridView_mahasiswa.CurrentRow.Cells[3].Value;
            MemoryStream gambar = new MemoryStream(img);
            picturePhoto.Image = Image.FromStream(gambar);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(verify())
            {
                try
                {
                    mhsController.deleteStudent(txtNim.Text);
                    showStudent();
                    btnClear.PerformClick();
                    MessageBox.Show("Delete student success", "Delete data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNim.Focus();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Delete Data Error", "Delete data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtNim_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void txtNama_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FormLogin fl = new FormLogin();
            fl.Show();
            this.Close();
        }
    }
}
