using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using INVENTORY.DA;

namespace INVENTORY.UI
{
    public partial class fEncryptor : Form
    {
        public fEncryptor()
        {
            InitializeComponent();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (txtString.Text == "")
            {
                //error.SetError(txtString, "Enter the text you want to encrypt");
            }
            else
            {
               // error.Clear();
                string clearText = txtString.Text.Trim();
                string cipherText = CryptorEngine.Encrypt(clearText, true);
                txtResult.Text = cipherText;
               
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            string cipherText = txtResult.Text.Trim();
            string decryptedText = CryptorEngine.Decrypt(cipherText, true);
            txtDecryptedText.Text = decryptedText;
            
           
        }
    }
}
