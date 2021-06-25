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
    public partial class KeyAccess : Form
    {
        public OleDbConnection dbka;
        public string connectionString = "";
        public string giftaidHome = "";  // is actually home of the church census software and database
        public string epwdkey;
        public Form1 f1;

        public KeyAccess()
        {
            InitializeComponent();

            if (Program.DB == Program.ORACLE)
                connectionString = "Provider=OraOLEDB.Oracle;User ID=giftaid;password=giftaid; Data Source=XE;Persist Security Info=False";
            else if (Program.DB == Program.ACCESS)
                connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=giftaiddb.mdb; Jet OLEDB:Database Password=javelin";
            else if (Program.DB == Program.ACCESSACE)
            {
                giftaidHome = Environment.GetEnvironmentVariable("CHURCH_CENSUS_HOME");
                connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + giftaidHome + "\\giftaiddb.mdb;Jet OLEDB:Database Password=javelin";
            }
            else if (Program.DB == Program.SQLSERVER)
                connectionString = "Provider=SQLOLEDB;Data Source=LEWIS-PC\\MSS10;Initial Catalog=GiftAidDB;User ID=giftaid;Password=javelin";
            else if (Program.DB == Program.MYSQL)
                connectionString = "Provider=MySQLProv;Data Source=giftaiddb;User Id=root;Password=javelin";
            else
                MessageBox.Show("Unknown specified database backend ! ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            textBox1.PasswordChar = '*';

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string rpwdkey;
            string enc_rpwdkey;
            string PWDKEY = "pwdkey";
            epwdkey = textBox1.Text;
            dbka = new OleDbConnection(connectionString);
            dbka.Open();
            OleDbCommand SQLQuery = new OleDbCommand();
            SQLQuery.Connection = null;
            SQLQuery.CommandText = "SELECT value from config where parameter='" + PWDKEY + "' ";
            SQLQuery.Connection = dbka;
            
            try
            {
                enc_rpwdkey = Convert.ToString(SQLQuery.ExecuteScalar());
                rpwdkey = ScreenValidation.DecryptCipherTextToPlainText(enc_rpwdkey);
                if (!epwdkey.Equals(rpwdkey))
                {
                    MessageBox.Show("Access Denied - Incorrect Access Key ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox1.Clear();
                }
                else
                {
                    Hide();
                    dbka.Close();
                    f1 = new Form1();
                    f1.ShowDialog();
                    Close();
                }
                 
            }
            catch (System.Exception)
            { dbka.Close(); }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Sorry - This functionality is not available in this Release ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            ChangeKeyAccess cakf = new ChangeKeyAccess(connectionString);
            cakf.ShowDialog();

        }
    }
}
