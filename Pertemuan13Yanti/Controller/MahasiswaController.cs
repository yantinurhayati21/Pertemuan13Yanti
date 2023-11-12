using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pertemuan13Yanti.Controller
{
    internal class MahasiswaController:Model.Connection
    {
        public DataTable selectStudent(MySqlCommand command)
        {
            DataTable date = new DataTable();
            try
            {
                string show = "select * from Mahasiswa";
                da = new MySqlConnector.MySqlDataAdapter(show, GetConn());
                da.Fill(date);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return date;
        }

        public void insertStudent(string nim, string name, DateTime tanggalLahir, byte[] photo)
        {
            string add = "insert into Mahasiswa values (" + "@NIM, @Nama, @Tanggal_lahir, @Photo)";
            try
            {
                cmd = new MySqlConnector.MySqlCommand(add, GetConn());
                cmd.Parameters.Add("@NIM", MySqlConnector.MySqlDbType.VarChar).Value = nim;
                cmd.Parameters.Add("@Nama", MySqlConnector.MySqlDbType.VarChar).Value = name;
                cmd.Parameters.Add("@Tanggal_lahir", MySqlConnector.MySqlDbType.Date).Value = tanggalLahir;
                cmd.Parameters.Add("@Photo", MySqlConnector.MySqlDbType.Blob).Value = photo;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) 
            { 
                MessageBox.Show("Add Date Failed!! " + ex.Message);
            }
        }

        public void deleteStudent(string NIM)
        {
            string delete = "delete from mahasiswa where NIM=" + NIM;

            try
            {
                cmd = new MySqlConnector.MySqlCommand(delete, GetConn());
                cmd.Parameters.Add("@NIM", MySqlConnector.MySqlDbType.VarChar).Value = NIM;
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Delete failed!!" + ex.Message);
            }
        }
    }
}
