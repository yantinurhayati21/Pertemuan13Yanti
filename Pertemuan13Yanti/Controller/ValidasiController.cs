using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pertemuan13Yanti.Controller
{
    internal class ValidasiController
    {
        public bool ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Name field is empty", "Add Mahasiswa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            char[] invalidChars = { '!', '@', '#', '$', '%', '^', '&', '*', ';', '_', ':', ',', '-', '/', '\\', '?', '+', '=' };

            if (invalidChars.Contains(name[0]) || invalidChars.Contains(name[name.Length - 1]))
            {
                MessageBox.Show("Invalid starting or ending character in Name field", "Add Mahasiswa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            foreach (char c in invalidChars)
            {
                if (name.Contains(c))
                {
                    MessageBox.Show("Invalid character in Name field", "Add Mahasiswa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }
    }
}
