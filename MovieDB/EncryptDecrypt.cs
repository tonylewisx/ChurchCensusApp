using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GiftaidDB
{
    public partial class EncryptDecrypt : Form
    {
        public EncryptDecrypt()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void but_encrypt_Click(object sender, EventArgs e)
        {
            text_decenc.Text = ScreenValidation.EncryptPlainTextToCipherText(text_plain.Text );
        }

        private void but_decrypt_Click(object sender, EventArgs e)
        {
            text_decenc.Text = ScreenValidation.DecryptCipherTextToPlainText(text_plain.Text);
        }
    }
}
