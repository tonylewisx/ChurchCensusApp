using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Data.OleDb; // <- for database methods
using System.Data.Linq;

namespace GiftaidDB
{
    public partial class Form1 : Form
    {
        public OleDbConnection database;
        DataGridViewButtonColumn editButton;
        DataGridViewButtonColumn deleteButton;
        public string localshop;
        public Form2 f2;
        
        #region Form1 constructor
        public Form1()
        {

            InitializeComponent();
            // iniciate DB connection
    //        string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=moviedb.mdb";
            string connectionString = "";
            string giftaidHome = "";  // is actually home of the church census software and database

           
            if (Program.DB == Program.ORACLE)
                connectionString = "Provider=OraOLEDB.Oracle;User ID=giftaid;password=giftaid; Data Source=XE;Persist Security Info=False";
            else if (Program.DB == Program.ACCESS)
                connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=giftaiddb.mdb; Jet OLEDB:Database Password=javelin";
            else if (Program.DB == Program.ACCESSACE)
            {
 //               giftaidHome = Environment.GetEnvironmentVariable("GIFTAID_HOME");
                giftaidHome = Environment.GetEnvironmentVariable("CHURCH_CENSUS_HOME");
 //               MessageBox.Show("giftaidHome =  " + giftaidHome, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
 
//                MessageBox.Show("GHOME=> "+giftaidHome, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + giftaidHome + "\\giftaiddb.mdb;Jet OLEDB:Database Password=javelin";
//                MessageBox.Show("CS=> " + connectionString, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
      
            else if (Program.DB == Program.SQLSERVER)
                 connectionString = "Provider=SQLOLEDB;Data Source=LEWIS-PC\\MSS10;Initial Catalog=GiftAidDB;User ID=giftaid;Password=javelin";
    //            connectionString = "Provider=SQLOLEDB;Data Source=LEWIS-PC\\MSS10;Initial Catalog=GiftAidDB;Integrated Security=SSPI";
            else if (Program.DB == Program.MYSQL)
                connectionString = "Provider=MySQLProv;Data Source=giftaiddb;User Id=root;Password=javelin";
            //           string = "SERVER=localhost;Data Source=MyDatabase;user=root;PASSWORD=MyPassword;"
            else
                MessageBox.Show("Unknown specified database backend ! ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
  
            try
            {

                database = new OleDbConnection(connectionString);
                database.Open();

                // get the local shop name
                string queryString = "";
                OleDbCommand SQLQuery = new OleDbCommand();      
                SQLQuery.Connection = null;
  //              SQLQuery.CommandText = queryString;
  //              SQLQuery.Connection = database;
  //              localshop = Convert.ToString(SQLQuery.ExecuteScalar());

                // set shop to local shop on screen 
      

                // display next sheetno for insert
               
    //            MessageBox.Show("Max Sheetno is "+msno, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
  
    //            l_shopid.Text = " Local SVP Shop : "+localshop;

     //           MessageBox.Show("localshop => " + localshop);

                //SQL query to customers
                queryString = "SELECT id,fname,address,postcode, Telephone,mobile,nok,email,adultparent1,adultparent2,adultparent3,adultparent4,adultparent5,adultparent6,child1,dob1,school1,child2,dob2,school2,child3,dob3,school3,child4,dob4,school4,child5,dob5,school5,child6,dob6,school6,signed,house,church,prefcontact FROM family order by fname";

                loadDataGrid(queryString);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        #endregion

        #region get current maxmium sheetno for local shop
        private int get_NextId()
          {
            int maxsn;
 //           string queryString = "";
            string queryString;

            if (Program.DB == Program.ORACLE || Program.DB == Program.SQLSERVER || Program.DB == Program.MYSQL)
            { queryString = "SELECT max(id) from family "; }
            else if (Program.DB == Program.ACCESS || Program.DB == Program.ACCESSACE)
            { 
        //        queryString = "SELECT max(val(id)) from family ";
                queryString = "SELECT max(val(id)) from family "; 
            }
            else
            { MessageBox.Show("Unknown specified database backend ! ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); }

            OleDbCommand SQLQuery = new OleDbCommand();      
            SQLQuery.Connection = null;
            SQLQuery.CommandText = queryString;
            SQLQuery.Connection = database;
//            maxsn = Convert.ToString(SQLQuery.ExecuteScalar());
            try
            {
               maxsn = Convert.ToInt32(SQLQuery.ExecuteScalar());
  //              maxsn = (int)(SQLQuery.ExecuteScalar());
            } 
             catch(System.Exception)
            { maxsn = 0;}

            return maxsn;
           }
        
        #endregion 

        

        #region Load dataGrid
        public void loadDataGrid(string sqlQueryString) {

            OleDbCommand SQLQuery = new OleDbCommand();
            DataTable data = null;
            dataGridView1.DataSource = null;
            SQLQuery.Connection = null;
            OleDbDataAdapter dataAdapter = null;
            dataGridView1.Columns.Clear(); // <-- clear columns
           
            //---------------------------------
            SQLQuery.CommandText = sqlQueryString;
            SQLQuery.Connection = database;
            data = new DataTable();
            dataAdapter = new OleDbDataAdapter(SQLQuery);
            dataAdapter.Fill(data);
            dataGridView1.DataSource = data;
            dataGridView1.AllowUserToAddRows = false; // remove the null line
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 60;

            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[0].DisplayIndex = 1;

            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[1].DisplayIndex = 2;

            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[2].DisplayIndex = 4;

//            dataGridView1.Columns[3].Width = 75;
            dataGridView1.Columns[8].Width = 100;
            dataGridView1.Columns[9].Width = 100;
  //          dataGridView1.Columns[9].Width = 70;
 //           dataGridView1.Columns[6].Width = 70;
 //           dataGridView1.Columns[13].Width = 70;

            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
     //       dataGridView1.Columns[8].Visible = false;
    //        dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[13].Visible = false;
            dataGridView1.Columns[14].Visible = false;
            dataGridView1.Columns[15].Visible = false;
            dataGridView1.Columns[16].Visible = false;
            dataGridView1.Columns[17].Visible = false;
            dataGridView1.Columns[18].Visible = false;
            dataGridView1.Columns[19].Visible = false;
            dataGridView1.Columns[20].Visible = false;
            dataGridView1.Columns[21].Visible = false;
            dataGridView1.Columns[22].Visible = false;
            dataGridView1.Columns[23].Visible = false;
            dataGridView1.Columns[24].Visible = false;
            dataGridView1.Columns[25].Visible = false;
            dataGridView1.Columns[26].Visible = false;
            dataGridView1.Columns[27].Visible = false;
            dataGridView1.Columns[28].Visible = false;
            dataGridView1.Columns[29].Visible = false;
            dataGridView1.Columns[30].Visible = false;
            dataGridView1.Columns[31].Visible = false;
            dataGridView1.Columns[32].Visible = false;

 //           dataGridView1.Columns[33].Visible = false;
            dataGridView1.Columns[33].DisplayIndex = 3;

            dataGridView1.Columns[34].Visible = false;

            dataGridView1.Columns[35].Visible = false;

      
            


            // insert edit button into datagridview
            editButton = new DataGridViewButtonColumn();
            editButton.HeaderText = "Edit";
            editButton.Text = "Edit";
            editButton.UseColumnTextForButtonValue = true;
            editButton.Width = 80;
            dataGridView1.Columns.Add(editButton);
            // insert delete button to datagridview
            deleteButton = new DataGridViewButtonColumn();
            deleteButton.HeaderText = "Delete";
            deleteButton.Text = "Delete";
            deleteButton.UseColumnTextForButtonValue = true;
            deleteButton.Width = 80;
            dataGridView1.Columns.Add(deleteButton);


            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.HeaderCell.Value = String.Format("{0}", row.Index + 1);
            }

 //          dataGridView1.RowHeaderMouseClick = dataGridView1.RowHeaderMouseClick + MessageBox.Show("Gone outer of bounder", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

 //          this.dataGridView1.RowHeaderMouseClick += new System.EventHandler(this.clickRowNumber);
 

   //         MessageBox.Show("number of rows = "+ dataGridView1.Rows.Count , "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            // dislpay the number of records displayed

            lab_totrecdisplayed.Text = "Total number of Family records displayed = "+dataGridView1.Rows.Count.ToString();
            lab_totrecdisplayed.Font = new Font(lab_totrecdisplayed.Font, FontStyle.Bold);
    
        }
        #endregion

        private void izlazToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        #region Close database connection
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            database.Close();
        }
        #endregion

        #region refresh button
  //      private void button2_Click(object sender, EventArgs e)
 //       {
  //          textBox4.Clear();
  //          string queryString = "SELECT sheetno, title, surname, forename, barcode, postcode, Telephone,address,town,email,post_me,tele_me,email_me FROM customer";
   //         loadDataGrid(queryString);
   //     }
        #endregion

        #region Input
        private void button6_Click(object sender, EventArgs e)
        {

            int id_int = get_NextId() + 1;

    //        MessageBox.Show("Next id is "+ id_int, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
  

            string fname = textBox3.Text;
            string house = textBox7.Text;
            string address = textBox1.Text;
            string postcode = textBox8.Text;
            string telephone = textBox9.Text;
            string mobile = textBox12.Text;
            string nok = textBox41.Text;
            string church = comboBox1.Text;
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

            string prefcontact = comboBox4.Text;


            if ( fname == "" )
                 {
                     MessageBox.Show("You must enter a Family Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                     return;
                 }

            if (house == "")
            {
                MessageBox.Show("You must enter a House Name or Number ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (address == "")
              {
                MessageBox.Show("You must enter an Address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            // validate dob

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


//            string SQLString = "INSERT INTO family(id,fname,address,postcode, Telephone,mobile,nok,email,adultparent1,adultparent2,adultparent3,adultparent4,adultparent5,adultparent6,child1,dob1,school1,child2,dob2,school2,child3,dob3,school3,child4,dob4,school4,child5,dob5,school5,child6,dob6,school6,signed) VALUES(" + id + "','" + fname + "','" + address + "','" + postcode + "','" + telephone + "','" + mobile + "','" + nok + "','" + email + "','" + adultparent1 + "','" + adultparent2 + "','" + adultparent3 + "','" + adultparent4 + "','" + adultparent5 + "','" + adultparent6 + "','" + child1 + "','" + dob1 + "','" + school1 + "','" + child2 + "','" + dob2 + "','" + school2 + "','" + child3 + "','" + dob3 + "','" + school3 + "','" + child4 + "','" + dob4 + "','" + school4 + "','" + child5 + "','" + dob5 + "','" + school5 + "','" + child6 + "','" + dob6 + "','" + school6 + "','" + signed + "');";
            string SQLString = "INSERT INTO family(id,fname,address,postcode, Telephone,mobile,nok,email,adultparent1,adultparent2,adultparent3,adultparent4,adultparent5,adultparent6,child1,dob1,school1,child2,dob2,school2,child3,dob3,school3,child4,dob4,school4,child5,dob5,school5,child6,dob6,school6,signed,house,church,prefcontact) VALUES(" + id_int + ",'" + fname + "','" + address + "','" + postcode + "','" + telephone + "','" + mobile + "','" + nok + "','" + email + "','" + adultparent1 + "','" + adultparent2 + "','" + adultparent3 + "','" + adultparent4 + "','" + adultparent5 + "','" + adultparent6 + "','" + child1 + "','" + dob1 + "','" + school1 + "','" + child2 + "','" + dob2 + "','" + school2 + "','" + child3 + "','" + dob3 + "','" + school3 + "','" + child4 + "','" + dob4 + "','" + school4 + "','" + child5 + "','" + dob5 + "','" + school5 + "','" + child6 + "','" + dob6 + "','" + school6 + "','" + signed + "','" + house + "','" + church + "','" + prefcontact + "') ";

           OleDbCommand SQLCommand = new OleDbCommand();
           SQLCommand.CommandText = SQLString;
           SQLCommand.Connection = database;
           int response = -1;
           try
             {
                response = SQLCommand.ExecuteNonQuery();
             }
//             catch(DuplicateKeyException ex2)
             catch(DuplicateKeyException)
              {MessageBox.Show("Duplicate ID Key code entered , Barcode number already exists on system"); }
             catch (Exception ex)
               {
                   MessageBox.Show(ex.Message);
               }
           if (response >= 1)
             {
               MessageBox.Show("Customer is added to database","Successful",MessageBoxButtons.OK, MessageBoxIcon.Information);
               textBox1.Clear();
               textBox2.Clear();
               textBox3.Clear();
               textBox4.Clear();
               textBox5.Clear();
               textBox6.Clear();
               textBox7.Clear();
    

               textBox8.Clear();
               textBox9.Clear();
               textBox10.Clear();
               //              textBox7.Clear();
               textBox11.Clear();
               textBox12.Clear();
               textBox13.Clear();
               textBox14.Clear();
               textBox15.Clear();


               textBox16.Clear();
               textBox17.Clear();
               //              textBox7.Clear();
               textBox18.Clear();
               textBox19.Clear();
               textBox20.Clear();

               textBox21.Clear();
               textBox22.Clear();
               textBox23.Clear();
               textBox24.Clear();
               textBox25.Clear();
               textBox26.Clear();
               textBox27.Clear();

               textBox28.Clear();
               textBox29.Clear();
               textBox30.Clear();
               textBox31.Clear();
               textBox32.Clear();
               textBox33.Clear();
               textBox34.Clear();

               textBox35.Clear();
               textBox36.Clear();
               textBox37.Clear();
               textBox38.Clear();
               textBox39.Clear();
               textBox40.Clear();
               textBox41.Clear();
               
           

               comboBox3.ResetText();
               comboBox1.ResetText();
               comboBox13.ResetText();
               comboBox14.ResetText();
               comboBox15.ResetText();
               comboBox16.ResetText();
               comboBox17.ResetText();
               comboBox4.ResetText();

               textBox3.Focus();
    

            }
            else
            {
               MessageBox.Show("Error on Inserting Customer to database", "Warning",MessageBoxButtons.OK, MessageBoxIcon.Warning);
   //            textBox3.Clear();
    //           textBox3.Focus();
            }
        }

        #endregion

        #region Delete/Edit button handling
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0 )  
            {
  //              MessageBox.Show(" ColumnIndex value = " + e.ColumnIndex.ToString());

  //              string queryString = "SELECT sheetno, title, surname, forename, barcode, postcode, Telephone, address,town,email,post_me,tele_me,email_me,shop FROM customer order by surname";
                string queryString = "SELECT id,fname,address,postcode, Telephone,mobile,nok,email,adultparent1,adultparent2,adultparent3,adultparent4,adultparent5,adultparent6,child1,dob1,school1,child2,dob2,school2,child3,dob3,school3,child4,dob4,school4,child5,dob5,school5,child6,dob6,school6,signed,house,church,prefcontact FROM family order by fname";

                int currentRow = int.Parse(e.RowIndex.ToString());

                string id = dataGridView1[0, currentRow].Value.ToString(); // primary key

                string house = dataGridView1[33, currentRow].Value.ToString();
                string church = dataGridView1[34, currentRow].Value.ToString();
                string pcontact = dataGridView1[35, currentRow].Value.ToString();

                string fname = dataGridView1[1, currentRow].Value.ToString();
                string address = dataGridView1[2, currentRow].Value.ToString();
                string postcode = dataGridView1[3, currentRow].Value.ToString();
                string telephone = dataGridView1[4, currentRow].Value.ToString();
                string mobile = dataGridView1[5, currentRow].Value.ToString();
                string nok = dataGridView1[6, currentRow].Value.ToString();
                string em = dataGridView1[7, currentRow].Value.ToString();


                string ad1 = dataGridView1[8, currentRow].Value.ToString();
                string ad2 = dataGridView1[9, currentRow].Value.ToString();
                string ad3 = dataGridView1[10, currentRow].Value.ToString();
                string ad4 = dataGridView1[11, currentRow].Value.ToString();
                string ad5 = dataGridView1[12, currentRow].Value.ToString();
                string ad6 = dataGridView1[13, currentRow].Value.ToString();


                string c1 = dataGridView1[14, currentRow].Value.ToString();
                string d1 = dataGridView1[15, currentRow].Value.ToString();
                string s1 = dataGridView1[16, currentRow].Value.ToString();

                string c2 = dataGridView1[17, currentRow].Value.ToString();
                string d2 = dataGridView1[18, currentRow].Value.ToString();
                string s2 = dataGridView1[19, currentRow].Value.ToString();

                string c3 = dataGridView1[20, currentRow].Value.ToString();
                string d3 = dataGridView1[21, currentRow].Value.ToString();
                string s3 = dataGridView1[22, currentRow].Value.ToString();

                string c4 = dataGridView1[23, currentRow].Value.ToString();
                string d4 = dataGridView1[24, currentRow].Value.ToString();
                string s4 = dataGridView1[25, currentRow].Value.ToString();

                string c5 = dataGridView1[26, currentRow].Value.ToString();
                string d5 = dataGridView1[27, currentRow].Value.ToString();
                string s5 = dataGridView1[28, currentRow].Value.ToString();

                string c6 = dataGridView1[29, currentRow].Value.ToString();
                string d6 = dataGridView1[30, currentRow].Value.ToString();
                string s6 = dataGridView1[31, currentRow].Value.ToString();

                string sign = dataGridView1[32, currentRow].Value.ToString();
              

                // edit button 
                if (dataGridView1.Columns[e.ColumnIndex] == editButton && currentRow >= 0)
                {
                    // string address = dataGridView1[6, currentRow].Value.ToString();

                    //runs form 2 for editing    
                    f2 = new Form2();
                    f2.database2 = database;

                    f2.church = church;
                    f2.house = house;
                    f2.prefcontact = pcontact;

                    f2.id = id;
                    f2.fname = fname;
                    f2.address = address;
                    f2.postcode = postcode;
                    f2.telephone = telephone;
                    f2.mobile = mobile;
                    f2.em = em;
                    f2.nok = nok;
                    f2.ad1= ad1;
                    f2.ad2 = ad2;
                    f2.ad3 = ad3;
                    f2.ad4 = ad4;
                    f2.ad5 = ad5;
                    f2.ad6 = ad6;
                    f2.c1 =  c1;
                    f2.d1 = d1;
                    f2.s1 = s1;

                    f2.c2 =  c2;
                    f2.d2 = d2;
                    f2.s2 = s2;

                    f2.c3 =  c3;
                    f2.d3 = d3;
                    f2.s3 = s3;

                    f2.c4 =  c4;
                    f2.d4 = d4;
                    f2.s4 = s4;

                    f2.c5 =  c5;
                    f2.d5 = d5;
                    f2.s5 = s5;

                    f2.c6 =  c6;
                    f2.d6 = d6;
                    f2.s6 = s6;
                    
                    f2.sign= sign;

                    f2.ShowDialog();

                    loadDataGrid(queryString);

                    // go back to front screen inorder to refersh grid 
                    tabControl1.SelectTab(0);

                }
                // delete button
                else if (dataGridView1.Columns[e.ColumnIndex] == deleteButton && currentRow >= 0)
                {

 
                        if (MessageBox.Show("Are you sure you want to Remove this Family from the Census", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {

                            // delete sql query

                            int id_int = Convert.ToInt32(id);

                            string queryDeleteString = "DELETE FROM family where id=" + id;
                            //string queryDeleteString = null;
                            OleDbCommand sqlDelete = new OleDbCommand();
                            sqlDelete.CommandText = queryDeleteString;
                            sqlDelete.Connection = database;
                            sqlDelete.ExecuteNonQuery();
                            loadDataGrid(queryString); // refresh screen after delete
                        }
                    
  
                }

            }  // end of if 
         }
        #endregion
         
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        #region search by family Name
        private void button1_Click(object sender, EventArgs e)
        {
            string fname = textBox4.Text.ToString();
            if (fname != "")
            {
                string queryString = "SELECT id,fname,address,postcode, Telephone,mobile,nok,email,adultparent1,adultparent2,adultparent3,adultparent4,adultparent5,adultparent6,child1,dob1,school1,child2,dob2,school2,child3,dob3,school3,child4,dob4,school4,child5,dob5,school5,child6,dob6,school6,signed,house, church, prefcontact FROM family where fname LIKE '" + fname + "%' order by fname ";

  //              string queryString = "SELECT sheetno,title, surname, forename, barcode, postcode, Telephone, address,town,email,post_me,tele_me,email_me,shop FROM customer where postcode LIKE '" + postcode + "%' order by surname ";
                loadDataGrid(queryString);
            }
            else
            {
                MessageBox.Show("You must enter a Family Surname","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region search by address
        private void button5_Click(object sender, EventArgs e)
        {
 //           string postcode = textBox13.Text.ToString();
            string address = textBox13.Text.ToString();
            if (address != "")
            {
                string queryString = "SELECT id,fname,address,postcode, Telephone,mobile,nok,email,adultparent1,adultparent2,adultparent3,adultparent4,adultparent5,adultparent6,child1,dob1,school1,child2,dob2,school2,child3,dob3,school3,child4,dob4,school4,child5,dob5,school5,child6,dob6,school6,signed,house, church, prefcontact FROM family where address LIKE '%" + address + "%' order by fname ";

 //               string queryString = "SELECT sheetno, title, surname, forename, barcode, postcode, Telephone, address,town,email,post_me,tele_me,email_me,shop FROM customer where surname LIKE '" + surname + "%' order by surname";
                //"SELECT title, surname, forename, barcode, postcode, Telephone FROM customer";
                loadDataGrid(queryString);
            }
            else
            {
                MessageBox.Show("You must enter an Address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        
        }
        #endregion

        #region search by Child
        private void button4_Click(object sender, EventArgs e)
        {
            string child = textBox5.Text.ToString();
            if (child != "")
            {
                string queryString = "SELECT id,fname,address,postcode, Telephone,mobile,nok,email,adultparent1,adultparent2,adultparent3,adultparent4,adultparent5,adultparent6,child1,dob1,school1,child2,dob2,school2,child3,dob3,school3,child4,dob4,school4,child5,dob5,school5,child6,dob6,school6,signed,house, church, prefcontact FROM family where";
                queryString = queryString + " child1 LIKE '%" + child + "%' OR child2 LIKE '%" + child + "%' OR child3 LIKE '%" + child + "%' OR child4 LIKE '%" + child + "%' OR child5 LIKE '%" + child + "%' OR child6 LIKE '%" + child + "%' order by fname ";

 //               string queryString = "SELECT sheetno,title, surname, forename, barcode, postcode, Telephone, address,town,email,post_me,tele_me,email_me,shop FROM customer where forename LIKE '" + forename + "%' order by surname";
                loadDataGrid(queryString);
            }
            else
            {
                MessageBox.Show("You must enter a Childs' name ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

 
  //      }
        #endregion

        #region search House
        private void button3_Click(object sender, EventArgs e)
        {
           // string previewed;
           // if (radioButton3.Checked == true) previewed = "Yes";
           // else previewed = "No";
  //          string telephone = textBox6.Text.ToString();
            string house = textBox6.Text.ToString();
            if (house != "")
            {

  //              string queryString = "SELECT sheetno,title, surname, forename, barcode, postcode, Telephone, address, town,email,post_me,tele_me,email_me,shop FROM customer where house LIKE '" + house + "%' order by surname";
                string queryString = "SELECT id,fname,address,postcode, Telephone,mobile,nok,email,adultparent1,adultparent2,adultparent3,adultparent4,adultparent5,adultparent6,child1,dob1,school1,child2,dob2,school2,child3,dob3,school3,child4,dob4,school4,child5,dob5,school5,child6,dob6,school6,signed,house, church, prefcontact FROM family where house LIKE '" + house + "%' order by fname ";
                loadDataGrid(queryString);
            }
            else
            {
                MessageBox.Show("You must enter a House name or number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        private void button6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button6_Click(null, null);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
   //         string queryString = "SELECT movieID, Title, Publisher, Previewed, MovieYear, Type FROM movie,movieType WHERE movietype.typeID = movie.typeID";
            textBox13.Clear();
            textBox4.Clear();
            textBox6.Clear();
            textBox5.Clear();
            ent_search_bar.Clear();
            textBox42.Text = "";

            string queryString = "SELECT id,fname,address,postcode, Telephone,mobile,nok,email,adultparent1,adultparent2,adultparent3,adultparent4,adultparent5,adultparent6,child1,dob1,school1,child2,dob2,school2,child3,dob3,school3,child4,dob4,school4,child5,dob5,school5,child6,dob6,school6,signed,house, church, prefcontact FROM family order by fname";
            loadDataGrid(queryString);
        }

        void OnRowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            MessageBox.Show("Clicked RowHeader!");
        }

        void OnColHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
   //         MessageBox.Show("Clicked columnHeader!");
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.HeaderCell.Value = String.Format("{0}", row.Index + 1);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lab_search_bar_Click(object sender, EventArgs e)
        {

        }
        #region search school
        private void button7_Click(object sender, EventArgs e)
        {
            string school = ent_search_bar.Text.ToString();
            if (school != "")
            {
                string queryString = "SELECT id,fname,address,postcode, Telephone,mobile,nok,email,adultparent1,adultparent2,adultparent3,adultparent4,adultparent5,adultparent6,child1,dob1,school1,child2,dob2,school2,child3,dob3,school3,child4,dob4,school4,child5,dob5,school5,child6,dob6,school6,signed,house, church FROM family where";
                queryString = queryString + " school1 LIKE '%" + school + "%' OR school2 LIKE '%" + school + "%' OR school3 LIKE '%" + school + "%' OR school4 LIKE '%" + school + "%' OR school5 LIKE '%" + school + "%' OR school6 LIKE '%" + school + "%' order by fname ";

//                string queryString = "SELECT sheetno,title, surname, forename, barcode, postcode, Telephone, address,town,email,post_me,tele_me,email_me,shop FROM customer where barcode LIKE '" + barcode + "%' order by surname";
                loadDataGrid(queryString);
            }
            else
            {
                MessageBox.Show("You must enter a School", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

 
        private void tabPage4_Enter(object sender, EventArgs e)
        {
            textBox13.Clear();
        }

        private void tabControl1_Enter(object sender, EventArgs e)
        {
            textBox13.Clear();
            textBox4.Clear();
            textBox6.Clear();
            textBox5.Clear();
            ent_search_bar.Clear();
            textBox42.Text = "";
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void synvToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exportCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("I am sorry, This Functionality is under construction , it will be available in a Future release", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
  
          string createTableString = "";

          // drop original backup table if it exists

          if (Program.DB == Program.ORACLE || Program.DB == Program.MYSQL)
              createTableString = "drop table family_bck";
          else if (Program.DB == Program.ACCESS || Program.DB == Program.ACCESSACE || Program.DB == Program.SQLSERVER)
              createTableString = "drop table family_bck";
          else
              MessageBox.Show("Unknown specified database backend ! ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

          try
          {
              // create a copy of the customer table and data ;
              OleDbCommand sqlCreatetable = new OleDbCommand();
              sqlCreatetable.CommandText = createTableString;
              sqlCreatetable.Connection = database;
              sqlCreatetable.ExecuteNonQuery();

  //            MessageBox.Show("The Family Census have been Backed up ( table family_bck )", "", MessageBoxButtons.OK);
          }
          catch (Exception)
 //         catch (Exception ex)
          {
  //            MessageBox.Show(ex.Message);

          }

          if (Program.DB == Program.ORACLE  || Program.DB == Program.MYSQL)
            createTableString = "create table family_bck as select * from family";
          else if (Program.DB == Program.ACCESS || Program.DB == Program.ACCESSACE || Program.DB == Program.SQLSERVER) 
             createTableString = "select * into family_bck from family";
          else                 
               MessageBox.Show("Unknown specified database backend ! ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
 
            try
            {
                // create a copy of the customer table and data ;
                OleDbCommand sqlCreatetable = new OleDbCommand();
                sqlCreatetable.CommandText = createTableString;
                sqlCreatetable.Connection = database;
                sqlCreatetable.ExecuteNonQuery();

                MessageBox.Show("The Family Census have been Backed up ( table family_bck )", "", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
  
                
           //     return;
            }

   //         MessageBox.Show("Till in routine", "", MessageBoxButtons.OK);
    
        }

        private void exportCustomerDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("I am sorry, This Functionality is not available in this Release", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
 //           export fexp = new export();
 //           fexp.database = database;
 //           fexp.Show();
             
        }

        private void importCustomerDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("I am sorry, This Functionality is not available in this Release", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
 
  //          Import fimp = new Import();
  //          fimp.database = database;
  //          fimp.Show(); 
        }

        private void removeBacupOfCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string dropTableString = "drop table family_bck";

            try
            {
                // remove  backup of the customer table and data ;
                OleDbCommand sqltable = new OleDbCommand();
                sqltable.CommandText = dropTableString;
                sqltable.Connection = database;
                sqltable.ExecuteNonQuery();

                MessageBox.Show("Backup of Family Census has been removed", "", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void aboutGiftadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutGiftaid ga = new AboutGiftaid();
            ga.Show();
        }

        private void label18_Click_1(object sender, EventArgs e)
        {

        }

        #region search by AdultParent
        private void button2_Click(object sender, EventArgs e)
        {
            string adultparent = textBox42.Text.ToString();
            if (adultparent != "")
            {
                string queryString = "SELECT id,fname,address,postcode, Telephone,mobile,nok,email,adultparent1,adultparent2,adultparent3,adultparent4,adultparent5,adultparent6,child1,dob1,school1,child2,dob2,school2,child3,dob3,school3,child4,dob4,school4,child5,dob5,school5,child6,dob6,school6,signed,house, church,prefcontact FROM family where";
                queryString = queryString + " adultparent1 LIKE '" + adultparent + "%' OR adultparent2 LIKE '" + adultparent + "%' OR adultparent3 LIKE '" + adultparent + "%' OR adultparent4 LIKE '" + adultparent + "%' order by fname ";

                loadDataGrid(queryString);
            }
            else
            {
                MessageBox.Show("You must enter an Adult/Parent Forename  ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        
//            string queryString = "SELECT id,fname,address,postcode, Telephone,mobile,nok,email,adultparent1,adultparent2,adultparent3,adultparent4,adultparent5,adultparent6,child1,dob1,school1,child2,dob2,school2,child3,dob3,school3,child4,dob4,school4,child5,dob5,school5,child6,dob6,school6,signed FROM family order by fname";
//            loadDataGrid(queryString);
        }
        #endregion

        private void tabPage3_Enter(object sender, EventArgs e)
        {
            textBox4.Clear();
        }

        private void tabPage5_Enter(object sender, EventArgs e)
        {
            textBox6.Clear();
        }

        private void tabPage6_Enter(object sender, EventArgs e)
        {
            textBox5.Clear();
        }

        private void tabPage7_Enter(object sender, EventArgs e)
        {
            ent_search_bar.Clear();
        }

        private void tabPage8_Enter(object sender, EventArgs e)
        {
            textBox42.Text = "";
        }

        private void surnamesurtxtToolStripMenuItem_Click(object sender, EventArgs e)
        {

        
           OleDbCommand command = new OleDbCommand();
           OleDbDataAdapter adapter = new OleDbDataAdapter();
           DataSet dataset = new DataSet();
           Reports rep = new Reports();

           Reportformat rf = new Reportformat();

           rf.ShowDialog();

            if (rf.ok)
            {
                command.Connection = null;
                command.Connection = database;
  //              command.CommandText = "SELECT fname, house, address FROM family order by fname";
                command.CommandText = "SELECT id,fname,address,postcode, Telephone,mobile,nok,email,adultparent1,adultparent2,adultparent3,adultparent4,adultparent5,adultparent6,child1,dob1,school1,child2,dob2,school2,child3,dob3,school3,child4,dob4,school4,child5,dob5,school5,child6,dob6,school6,signed,house, church, prefcontact from family";
                adapter.SelectCommand = command;

                try
                { adapter.Fill(dataset, "family"); }
                catch (OleDbException)
                {
                    MessageBox.Show("Error occured while connecting to database.");
                    //               Application.Exit();
                }

                if (rf.repformatHTML)
                    rep.prod_repsurHtml(dataset, database);
                else if (rf.repformatTEXT)
                    rep.prod_repsurText(dataset, database);
                else
                    MessageBox.Show("ERROR: Unknown format specified ");
            }
        }

        private void byBarcodebartxtToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OleDbCommand command = new OleDbCommand();
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            DataSet dataset = new DataSet();
            Reports rep = new Reports();

            Reportformat rf = new Reportformat();

            rf.ShowDialog();

            if (rf.ok)
            {
                command.Connection = null;
                command.Connection = database;

                command.CommandText = "SELECT barcode, surname, forename, shop, sheetno FROM customer order by barcode";
                adapter.SelectCommand = command;

                try
                { adapter.Fill(dataset, "customer"); }
                catch (OleDbException)
                {
                    MessageBox.Show("Error occured while connecting to database.");
                    //               Application.Exit();
                }

                if (rf.repformatHTML)
                    rep.prod_repbarHtml(dataset, database);
                else if (rf.repformatTEXT)
                    rep.prod_repbarText(dataset, database);
                else
                    MessageBox.Show("ERROR: Unknown format specified ");

                    
            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            string repdir;  // directory for log book
            string repfile;   // file for log book

            Reports rep = new Reports();
            repdir = rep.get_reportdir(database);

            repfile = repdir + "\\LogBook.txt";
            Process.Start("notepad.exe", repfile);


        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void recoverCensusFromBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string createTableString;
            bool famTabBckExists = true;

            // check table family_bck exists

            if (Program.DB == Program.ORACLE || Program.DB == Program.MYSQL)
                createTableString = "select * from family_bck";
            else if (Program.DB == Program.ACCESS || Program.DB == Program.ACCESSACE || Program.DB == Program.SQLSERVER)
                createTableString = "select * from family_bck";
            else
                MessageBox.Show("Unknown specified database backend ! ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            try
            {
                // create a copy of the customer table and data ;
                OleDbCommand sqlCreatetable = new OleDbCommand();
                sqlCreatetable.CommandText = createTableString;
                sqlCreatetable.Connection = database;
                sqlCreatetable.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                famTabBckExists = false;
                MessageBox.Show(ex.Message);
                //     return;
            }

            // drop previous table family_before_drop if it exists

            if (Program.DB == Program.ORACLE || Program.DB == Program.MYSQL)
                createTableString = "drop table family_before_drop";
            else if (Program.DB == Program.ACCESS || Program.DB == Program.ACCESSACE || Program.DB == Program.SQLSERVER)
                createTableString = "drop table family_before_drop";
            else
                MessageBox.Show("Unknown specified database backend ! ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            try
            {
                // create a copy of the customer table and data ;
                OleDbCommand sqlCreatetable = new OleDbCommand();
                sqlCreatetable.CommandText = createTableString;
                sqlCreatetable.Connection = database;
                sqlCreatetable.ExecuteNonQuery();
            }
            catch (Exception)
 //           catch (Exception ex)
            {
 //               MessageBox.Show(ex.Message);
                //     return;
            }
         

            // backup existing family table to family_before_drop

            if (Program.DB == Program.ORACLE || Program.DB == Program.MYSQL)
                createTableString = "create table family_before_drop as select * from family";
            else if (Program.DB == Program.ACCESS || Program.DB == Program.ACCESSACE || Program.DB == Program.SQLSERVER)
                createTableString = "select * into family_before_drop from family";
            else
                MessageBox.Show("Unknown specified database backend ! ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            try
            {
                // create a copy of the customer table and data ;
                OleDbCommand sqlCreatetable = new OleDbCommand();
                sqlCreatetable.CommandText = createTableString;
                sqlCreatetable.Connection = database;
                sqlCreatetable.ExecuteNonQuery();

 //               MessageBox.Show("The Family Census have been Backed up ( table family_bck )", "", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //     return;
            }
            // if backup exists (family_bck) then drop family table else exit warn 'make a  backup'

            if (famTabBckExists)
            {
                createTableString = "";
                if (Program.DB == Program.ORACLE || Program.DB == Program.MYSQL)
                    createTableString = "drop table family";
                else if (Program.DB == Program.ACCESS || Program.DB == Program.ACCESSACE || Program.DB == Program.SQLSERVER)
                    createTableString = "drop table family";
                else
                    MessageBox.Show("Unknown specified database backend ! ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                try
                {
                    // create a copy of the customer table and data ;
                    OleDbCommand sqlCreatetable = new OleDbCommand();
                    sqlCreatetable.CommandText = createTableString;
                    sqlCreatetable.Connection = database;
                    sqlCreatetable.ExecuteNonQuery();

                    //               MessageBox.Show("The Family Census have been Backed up ( table family_bck )", "", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    //     return;
                }

                // create family table from table backup family_bck    i.e you recover from the backup table 

                createTableString = "";
                if (Program.DB == Program.ORACLE || Program.DB == Program.MYSQL)
                    createTableString = "create table family as select * from family_bck";
                else if (Program.DB == Program.ACCESS || Program.DB == Program.ACCESSACE || Program.DB == Program.SQLSERVER)
                    createTableString = "select * into family from family_bck";
                else
                    MessageBox.Show("Unknown specified database backend ! ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                try
                {
                    // create a copy of the customer table and data ;
                    OleDbCommand sqlCreatetable = new OleDbCommand();
                    sqlCreatetable.CommandText = createTableString;
                    sqlCreatetable.Connection = database;
                    sqlCreatetable.ExecuteNonQuery();

                    MessageBox.Show("The Family Census has been recovered from the Backup", "", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    //     return;
                }


                // donot drop table family_before_drop incase further use

            }
            else
            {
               MessageBox.Show("There is no Backup present of the Family Census to Recover from!,  Please do make a backup under the Tools Menu option.", "", MessageBoxButtons.OK);
            }
        }

        private void comboBox13_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }
    }
}