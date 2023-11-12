using MySqlConnector;
using Pertemuan13Yanti.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pertemuan13Yanti.Controller
{
    internal class GetDataController:Model.Connection
    {
        Connection koneksi = new Connection();
        
        public DataTable getList(MySqlCommand command)
        {
            command.Connection= koneksi.GetConn();
            DataTable table = new DataTable();
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return table;
        }
    }  
}
