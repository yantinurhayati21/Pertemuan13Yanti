using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pertemuan13Yanti.Controller
{
    internal class LoginController:Model.Connection
    {
        public void addAkun(string user, string password)
        {
            string add = "insert into Admin values (" + "@username, @pass)";
            try
            {
                cmd = new MySqlConnector.MySqlCommand(add, GetConn());
                cmd.Parameters.Add("@username", MySqlConnector.MySqlDbType.VarChar).Value = user;
                cmd.Parameters.Add("@pass", MySqlConnector.MySqlDbType.VarChar).Value = password;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Add Date Failed!! " + ex.Message);
            }
        }
    }
}
