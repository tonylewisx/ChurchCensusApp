using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GiftaidDB
{
    public partial class ChangeKeyAccess : Form
    {
        public string connectString;
        public OleDbConnection db;
        public OleDbCommand SQLQuery;
        public EncryptDecrypt encdec;

        public ChangeKeyAccess(string st)
        {
            InitializeComponent();
            connectString = st;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string oldp = textBox1.Text;
            string newp = textBox2.Text;
            string rp = textBox3.Text;
            string PWDKEY = "pwdkey";
            string rpwdkey = "";
            string enc_rpwdkey = "";

            db = new OleDbConnection(connectString);
            db.Open();
            SQLQuery = new OleDbCommand();
            SQLQuery.Connection = null;
            SQLQuery.CommandText = "SELECT value from config where parameter='" + PWDKEY + "' ";
            SQLQuery.Connection = db;

            try
             {
                enc_rpwdkey = Convert.ToString(SQLQuery.ExecuteScalar());
                rpwdkey = ScreenValidation.DecryptCipherTextToPlainText(enc_rpwdkey);
             }
            catch (System.Exception)
               { }

            db.Close();

            if (!newp.Equals(rp))
            {
                MessageBox.Show("New Access Key is different from re-entered New Access key, try again", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!oldp.Equals(rpwdkey))
            {
                MessageBox.Show("Old Access Key is Incorrect, enter present Access Key ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string enc_newp = ScreenValidation.EncryptPlainTextToCipherText(newp);
                db = new OleDbConnection(connectString);
                db.Open();
                SQLQuery = new OleDbCommand();
                SQLQuery.Connection = null;
                SQLQuery.CommandText = "update config set [value] = '" + enc_newp + "' where [parameter]='" + PWDKEY + "'";
                SQLQuery.Connection = db;

                try
                {
                    int response = SQLQuery.ExecuteNonQuery();
                    MessageBox.Show("Access Key changed successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (System.Exception)
                { db.Close(); }

                db.Close();
                Close();
            }
        

        }

        private void ChangeKeyAccess_Load(object sender, EventArgs e)
        {

        }

        private void encrptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            encdec = new EncryptDecrypt();
            encdec.ShowDialog();
        }
    }
}
