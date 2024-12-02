using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FtpApplication
{
    public partial class CreateFileName : Form
    {
        public string FileName { get; set; }
        public CreateFileName()
        {
            InitializeComponent();
        }

        private void b_OK_Click(object sender, EventArgs e)
        {
            if (tb_FileName.Text == "")
            {
                MessageBox.Show
                    (
                        $"No Name Set",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                return;
            }
            FileName = tb_FileName.Text;
        }

        private void b_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
