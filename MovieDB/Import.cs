using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;


namespace GiftaidDB
{
    public partial class Import : Form
    {
        public OleDbConnection database;
        public Import()
        {
            InitializeComponent();
        }

        private void b_ok_Click(object sender, EventArgs e)
        {
            string shop = c_shop.Text;
            string deleteString = "DELETE FROM customer where shop in ( '" + shop + "')";

    // delete old shop data from customer for new shop data file import 
            OleDbCommand sqlDelete = new OleDbCommand();
            sqlDelete.CommandText = deleteString;
            sqlDelete.Connection = database;
            sqlDelete.ExecuteNonQuery();
// Now import the new customer data for the shop by HAND 
            MessageBox.Show("New Customer data ready for import Manually", "", MessageBoxButtons.OK, MessageBoxIcon.None);

            Close();
    
        }

        private void b_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
