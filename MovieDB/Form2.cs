using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
//using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Imaging;


namespace GiftaidDB
{
    public partial class Form2 : Form
    {
        public OleDbConnection database2;

        public string id ,fname ,address ,postcode,telephone , mobile, em ,nok,ad1 ,ad2 ,ad3,ad4,ad5,ad6;
        public string c1, d1, s1, c2, d2, s2, c3, d3, s3, c4, d4, s4, c5, d5, s5, c6,d6,s6, sign, house, church, prefcontact;
       
/**
        public struct cust_rec 
        { public string title; 
          public string forename; 
          public string surname;
          public string address;
          public string town;
          public string postcode;
          public string telephone;
          public string email;
          public string barcode;
          public string postme;
          public string teleme;
          public string emailme;
          public string shop;
          public cust_rec(string t, string f, string s, string a, string tw, string p, string te, string em, string ba,string pme, string tme, string eme, string sh)
          {
              title = t;
              forename = f;
              surname = s;
              address = a;
              town = tw;
              postcode = p;
              telephone = te;
              email = em;
              barcode = ba;
              postme = pme;
              teleme = tme;
              emailme = eme;
              shop = sh;
          }
        
        }
*/

        public Form1 f1;

        public int movieID;
        public Form2()
        { 
            InitializeComponent();
            f1 = new Form1();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
 //           string id = "";

            textBox4.Text = house;
            comboBox1.Text = church;

            textBox3.Text = fname;
            textBox1.Text =  address;
            textBox8.Text = postcode;
            telephone = textBox9.Text = telephone;
            mobile = textBox12.Text = mobile;
            textBox41.Text = nok;
            textBox10.Text = em;
            textBox2.Text = ad1;
            textBox14.Text = ad2;
            textBox15.Text = ad3;
            textBox27.Text = ad4;
            textBox28.Text = ad5;
            textBox29.Text = ad6;
            textBox11.Text = c1;
            textBox35.Text = d1;
            comboBox3.Text = s1;

            textBox30.Text = c2;
            textBox36.Text = d2;
            comboBox13.Text = s2;

            textBox31.Text = c3;
            textBox37.Text = d3;
            comboBox14.Text = s3;

            textBox32.Text = c4;
            textBox38.Text = d4;
            comboBox15.Text = s4;

            textBox33.Text = c5;
            textBox39.Text = d5;
            comboBox16.Text = s5;

            textBox34.Text = c6;
            textBox40.Text = d6;
            comboBox17.Text = s6;

            comboBox2.Text = prefcontact;


            if (sign == "Yes") checkBox1.Checked = true;
            else if (sign == "No") checkBox1.Checked = false;

  //          if (teleme == "Yes") checkBox2.Checked = true;
 //           else if (teleme == "No") checkBox2.Checked = true;

  //          if (emailme == "Yes") checkBox3.Checked = true;
 //           else if (emailme == "No") checkBox3.Checked = true;



    

        }

        #region Update
        private void button6_Click(object sender, EventArgs e)
        {

 //           string id;

            int id_int = Convert.ToInt32(id);

            string house = textBox4.Text;
            string church = comboBox1.Text;

            string fname = textBox3.Text;
            string address = textBox1.Text;
            string postcode = textBox8.Text;
            string telephone = textBox9.Text;
            string mobile = textBox12.Text;
            string nok = textBox41.Text;
            string email = textBox10.Text;
            string adultparent1 = textBox2.Text;
            string adultparent2 = textBox14.Text;
            string adultparent3 = textBox15.Text;
            string adultparent4 = textBox27.Text;
            string adultparent5 = textBox28.Text;
            string adultparent6 = textBox29.Text;
            string child1 = textBox11.Text;
            string dob1 = textBox35.Text;
            string school1 = comboBox3.Text;

            string child2 = textBox30.Text;
            string dob2 = textBox36.Text;
            string school2 = comboBox13.Text;

            string child3 = textBox31.Text;
            string dob3 = textBox37.Text;
            string school3 = comboBox14.Text;

            string child4 = textBox32.Text;
            string dob4 = textBox38.Text;
            string school4 = comboBox15.Text;

            string child5 = textBox33.Text;
            string dob5 = textBox39.Text;
            string school5 = comboBox16.Text;

            string child6 = textBox34.Text;
            string dob6 = textBox40.Text;
            string school6 = comboBox17.Text;

            string pcontact = comboBox2.Text;


            if (fname == "")
            {
                MessageBox.Show("You must enter a Family Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (address == "")
            {
                MessageBox.Show("You must enter an Address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (house == "")
            {
                MessageBox.Show("You must enter an House name or number ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string signed;
            if (checkBox1.Checked == true)
            {
                signed = "Yes";
            }
            else
            {
                signed = "No";
            }
            ScreenValidation sv = new ScreenValidation(adultparent1, adultparent2, adultparent3, adultparent4, adultparent5, adultparent6, dob1, dob2, dob3, dob4, dob5, dob6);
            if (!sv.vald_adp())
            {
                MessageBox.Show("You must register a Parent/Adult at this Address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!sv.vald_dob())
            {
                MessageBox.Show("You must enter a correct DOB format  dd/mm/yyyy ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ScreenValidation sv2 = new ScreenValidation(child1, dob1, school1);
            if (!sv2.vald_child())
            {
                MessageBox.Show("You must enter the name of the Child (row 1)", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sv2 = new ScreenValidation(child2, dob2, school2);
            if (!sv2.vald_child())
            {
                MessageBox.Show("You must enter the name of the Child (row 2)", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sv2 = new ScreenValidation(child3, dob3, school3);
            if (!sv2.vald_child())
            {
                MessageBox.Show("You must enter the name of the Child (row 3)", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sv2 = new ScreenValidation(child4, dob4, school4);
            if (!sv2.vald_child())
            {
                MessageBox.Show("You must enter the name of the Child (row 4)", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sv2 = new ScreenValidation(child5, dob5, school5);
            if (!sv2.vald_child())
            {
                MessageBox.Show("You must enter the name of the Child (row 5)", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sv2 = new ScreenValidation(child6, dob6, school6);
            if (!sv2.vald_child())
            {
                MessageBox.Show("You must enter the name of the Child (row 6)", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }




            string SQLUpdate1 = "UPDATE family SET fname='" + fname + "', address='" + address + "', postcode='" + postcode + "' , telephone='" + telephone + "',mobile='" + mobile + "', nok='" + nok + "', email='" + email + "', house='" + house + "', church='" + church + "',prefcontact='" + pcontact + "', signed='" + signed + "', ";
                string SQLUpdate2=" adultparent1='" + adultparent1 + "', adultparent2='" + adultparent2 + "', adultparent3='" + adultparent3 + "', adultparent4='" + adultparent4 + "', adultparent5='" + adultparent5 + "', adultparent6='" + adultparent6 + "', ";
                string SQLUpdate3=" child1='"  + child1 + "', dob1='" + dob1 + "', school1='" + school1 + "',child2='"  + child2 + "', dob2='" + dob2 + "', school2='" + school2 + "',child3='"  + child3 + "', dob3='" + dob3 + "', school3='" + school3 + "' ,child4='"  + child4 + "', dob4='" + dob4 + "', school4='" + school4 + "',child5='"  + child5 + "', dob5='" + dob5 + "', school5='" + school5 + "',child6='"  + child6 + "', dob6='" + dob6 + "', school6='" + school6 + "' WHERE id=" + id_int;

                string SQLUpdateString= SQLUpdate1 + SQLUpdate2 + SQLUpdate3;

            try
            {

                OleDbCommand SQLCommand = new OleDbCommand();
                SQLCommand.CommandText = SQLUpdateString;
//                SQLCommand.Connection = f1.database;
                SQLCommand.Connection = f1.database;
                int response = SQLCommand.ExecuteNonQuery();
                MessageBox.Show("Update successful!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
 //               string queryString = "SELECT sheetno, title, surname, forename, barcode, postcode, Telephone,address,town,email,post_me,tele_me,email_me FROM customer";
 //               f1.loadDataGrid(queryString);
   
        //        Close();

            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }

  //          if (response >= 1)
  //          {
  //              MessageBox.Show("Update successful!","Message",MessageBoxButtons.OK, MessageBoxIcon.Information);
   //             string queryString = "SELECT sheetno, title, surname, forename, barcode, postcode, Telephone, address,town,email,post_me,tele_me,email_me,shop FROM customer";
   //             f1.loadDataGrid(queryString);
   //             Close();
   //         }

 //           string queryString = "SELECT sheetno, title, surname, forename, barcode, postcode, Telephone, address,town,email,post_me,tele_me,email_me,shop FROM customer";
 //           f1.loadDataGrid(queryString);

           Close();

         //   button1.PerformClick();

        }

        #endregion

        private void button6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button6_Click(null, null);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void print_but_Click(object sender, EventArgs e)
        {
/***** following code is to print the screen 
            Bitmap printscreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics graphics = Graphics.FromImage(printscreen as Image);
            graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size);
            printscreen.Save(@"C:\Temp\printscreen.jpg", ImageFormat.Jpeg);
*****/
            ModelDTO dto = new ModelDTO();
            ModelDTO.fam_rec cr = new ModelDTO.fam_rec(id, fname,address, postcode, telephone, mobile, nok, em, ad1, ad2, ad3, ad4, ad5, ad6, c1, d1, s1, c2, d2, s2, c3, d3, s3, c4, d4, s4, c5, d5, s5, c6, d6, s6, sign, house, church, prefcontact);
            Reports rep = new Reports();

            rep.prod_repcustText(cr, database2);
        }

    }
}