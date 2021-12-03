using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SqlDbEncrypter
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openDialog = new OpenFileDialog())
            {
                openDialog.Filter = "SqlDb.config files (.config)|*.config";
                openDialog.FilterIndex = 0;

                if (openDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    txtFile.Text = openDialog.FileName;
                    btnEncode.Enabled = true;
                    return;
                }
            }
   
        }

        private void btnEncode_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to encode usernames and passwords in the file?\nYou will not be able to undo the encoding.", "Encode file", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (PCAxis.Encryption.SqlDbEncrypter.Encrypt(txtFile.Text))
                {
                    MessageBox.Show("The file was encrypted successfully", "Encryption completed");
                }
                else
                {
                    MessageBox.Show("The file could not be encrypted", "Encryption aborted");
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
