using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GiftaidDB
{
    public partial class Reportformat : Form
    {
        public Boolean repformatHTML;
        public Boolean repformatTEXT;

        public Boolean ok;

        public Reportformat()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ok = false;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (rbut_html.Checked)
            {
//                repformatHTML = true;
 //               ok = true;
                 MessageBox.Show("Sorry - The HTML facilty is not available in this release  ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
                Close();
             }
            else if (rbut_text.Checked)
            {
                repformatTEXT = true;
                ok = true;
 //               MessageBox.Show("Sorry - The TEXT facilty is not available in this release  ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                Close();
            }
            else
            {
                repformatHTML = false;
                repformatTEXT = false;
                MessageBox.Show("Please specify a format, either Text or HTML ! ");

            }

 
        }
    }
}
