using System;
using System.Collections.Generic;
//using System.Linq;
using System.IO;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics; 

namespace GiftaidDB
{
    public class Reports
    {
        public DateTime thisDay = DateTime.Today;

        #region get reports directory

        public string get_reportdir(OleDbConnection database)
        {
            string rdir; // value of report directory
            string REPDIR = "reportdir";  // parameter for report directory
            string queryString = "SELECT value from config where parameter='" + REPDIR + "' ";
            
            OleDbCommand SQLQuery = new OleDbCommand();
            SQLQuery.Connection = null;
            SQLQuery.CommandText = queryString;
            SQLQuery.Connection = database;
            rdir = Convert.ToString(SQLQuery.ExecuteScalar());

            return rdir;
        }
        #endregion

        #region get No Children 
        public int get_noChild(string a1, string a2, string a3, string a4, string a5, string a6)
        {
            int nc =0; // no of children

            if (a1.Length > 0) nc = nc + 1;
            if (a2.Length > 0) nc = nc + 1;
            if (a3.Length > 0) nc = nc + 1;
            if (a4.Length > 0) nc = nc + 1;
            if (a5.Length > 0) nc = nc + 1;
            if (a6.Length > 0) nc = nc + 1;
            return nc;
        }
        #endregion

        #region get No adults/Parents

        public int get_noadp(string a1, string a2, string a3, string a4, string a5, string a6)
        {
            int nc = 0; // no of adult/parent

            if (a1.Length > 0) nc = nc + 1;
            if (a2.Length > 0) nc = nc + 1;
            if (a3.Length > 0) nc = nc + 1;
            if (a4.Length > 0) nc = nc + 1;
            if (a5.Length > 0) nc = nc + 1;
            if (a6.Length > 0) nc = nc + 1;
            return nc;
        }
        #endregion

        #region Surname report in HTML

        public void prod_repsurHtml(System.Data.DataSet dataset, OleDbConnection database)
        {

            string shop;
            string surname;
            string forename;
            string barcode;
            string sheetno;


            string cust_rec;
            string nr;  // number of customers
            int inr;    // int number of customers
            string repdir;  // directory for reports
            string repfile;   // file for report

            inr = dataset.Tables["customer"].Rows.Count; // int number of rows
            nr = inr.ToString();

            repdir = get_reportdir(database);

            repfile = repdir + "\\report.html";


            FileStream fs = File.Create(@repfile);
            TextWriter writer = new StreamWriter(fs);
 
            writer.WriteLine(" <html>");
            writer.WriteLine("<head>");
            writer.WriteLine("<title>SVP GiftAid Report</title>");

            writer.WriteLine(" <style type=\"text/css\">");
            writer.WriteLine("<!--");
            writer.WriteLine(" #fontl {font-size:x-large;}");
            writer.WriteLine("#alr {text-align:right}");
            writer.WriteLine("--> ");
            writer.WriteLine("</style>");
            writer.WriteLine(" </head>");
            writer.WriteLine("<div id=\"allreport\" align=\"center\">");
            writer.WriteLine(" <h1> SVP GiftAid Customers </h1>");
            writer.WriteLine("<h2>     ( by Surname)</h2> ");
            writer.WriteLine(" ");
            writer.WriteLine("<h2><b> Number of Customers = "+nr+ "&nbsp&nbsp&nbsp Date : &nbsp"+thisDay.ToString("D") + "</b></h2>");
            writer.WriteLine("<p></p>");

            writer.WriteLine(" <table border=\"3\" id=\"fontl\">");
            writer.WriteLine("<tr>");

            writer.WriteLine("  <th>Surname</th><th>Forename</th><th>Shop</th><th>Barcode</th><th>Sheetno</th>");
            writer.WriteLine("</tr>");

            writer.WriteLine(" ");
            writer.WriteLine("");
            
 //           writer.WriteLine("".PadRight(20, '-') + "".PadRight(20, '-') + "".PadRight(20, '-') + "".PadRight(20, '-') + "".PadRight(20, '-'));

            for (int pos = 0; pos < inr; pos++)
            {
                DataRow row = dataset.Tables["customer"].Rows[pos];
                surname = row["surname"].ToString();
                forename = row["forename"].ToString();
                barcode = row["barcode"].ToString();
                sheetno = row["sheetno"].ToString();
                shop = row["shop"].ToString();

                cust_rec= "<tr><td><b>"+surname.PadRight(20)+"</b></td><td>"+ forename.PadRight(20)+"</td><td>"+shop.PadRight(12)+"</td><td>"+barcode.PadRight(12)+"</td><td id=\"alr\">"+sheetno.PadRight(6)+"</td></tr>";
                writer.WriteLine(cust_rec);
            }

            writer.WriteLine("</table>");
            writer.WriteLine("</div>");
            writer.WriteLine("</html>");

            writer.Close();
            fs.Close();

            Process.Start("explorer", repfile);

   //         MessageBox.Show("The Report has been produced successfully ", "", MessageBoxButtons.OK);
        }
        #endregion

        #region Surname report in Text

        public void prod_repsurText(System.Data.DataSet dataset, OleDbConnection database)
        {
            string address;
            string fname;
            string house;
            /**
            string a1;
            string a2;
            string a3;
            string a4;
            string a5;
            string a6;

            string c1;
            string c2;
            string c3;
            string c4;
            string c5;
            string c6;
    **/

            string cust_rec;
            string nr;  // number of customers
            int inr;    // int number of customers
            string repdir;  // directory for reports
            string repfile;   // file for report

            inr = dataset.Tables["family"].Rows.Count; // int number of row
            nr = inr.ToString();

            repdir = get_reportdir(database);
            
            repfile = repdir + "\\report.txt";


           FileStream fs = File.Create(@repfile);
            TextWriter writer = new StreamWriter(fs);

            writer.WriteLine("                             Family Census Report   ");
            writer.WriteLine("                           --------------------------");
            writer.WriteLine("                                  ( by name )");
            writer.WriteLine("");

            writer.WriteLine("         Total Number of Families = " + nr + "    date : " + thisDay.ToString("D"));
            writer.WriteLine("");

 //           writer.WriteLine("Surname".PadRight(20) + "Forename".PadRight(20) + "Shop".PadRight(12) + "Barcode".PadRight(16) + "Sheetno".PadRight(6));
            writer.WriteLine("Family Name".PadRight(20) + "House".PadRight(20) + "address".PadRight(35) + "Adults/Child".PadRight(12) );

            writer.WriteLine("".PadRight(18, '-') + "".PadRight(2, ' ') + "".PadRight(18, '-') + "".PadRight(2, ' ') + "".PadRight(33, '-') + "".PadRight(2, ' ') + "".PadRight(12, '-') + "".PadRight(2, ' '));

 //           foreach (DataTable table in dataset.Tables)
 //           {
 //               foreach (DataRow row in table.Rows)
 //               {
 //                   foreach (DataColumn column in table.Columns)
  //                  {
           
  //                      MessageBox.Show("Column name => " + column.ColumnName, "", MessageBoxButtons.OK);

     //                   Console.WriteLine(row[column]);
   //                 }
   //             }
  //          }

            for (int pos = 0; pos < inr; pos++)
            {
                DataRow row = dataset.Tables["family"].Rows[pos];
                fname = row["fname"].ToString();
                house = row["house"].ToString();
                address = row["address"].ToString();

                int nchild = get_noChild(row["child1"].ToString(), row["child2"].ToString(), row["child3"].ToString(), row["child4"].ToString(), row["child5"].ToString(), row["child6"].ToString());
                int nadp = get_noadp(row["adultparent1"].ToString(), row["adultparent2"].ToString(), row["adultparent3"].ToString(), row["adultparent4"].ToString(), row["adultparent5"].ToString(), row["adultparent6"].ToString());
                  cust_rec = fname.PadRight(20) + house.PadRight(20) + address.PadRight(40) + nadp.ToString().PadRight(2) + "/" + nchild.ToString().PadRight(2);


  //              cust_rec = fname.PadRight(20) + house.PadRight(20) + address.PadRight(20);
                writer.WriteLine(cust_rec);
            }

            writer.Close();
            fs.Close();

            Process.Start("notepad", repfile);

 //           MessageBox.Show("The Report has been produced successfully ", "", MessageBoxButtons.OK);


        }

        #endregion


        #region Barcode Text report

        public void prod_repbarText(System.Data.DataSet dataset, OleDbConnection database)
        {
            string shop;
            string surname;
            string forename;
            string barcode;
            string sheetno;


            string cust_rec;
            string nr;  // number of customers
            int inr;    // int number of customers
            string repdir;  // directory for reports
            string repfile;   // file for report

            inr = dataset.Tables["customer"].Rows.Count; // int number of rows
            nr = inr.ToString();

            repdir = get_reportdir(database);

            repfile = repdir + "\\report.txt";

            FileStream fs = File.Create(@repfile);
            TextWriter writer = new StreamWriter(fs);

            writer.WriteLine("                           GiftAid Customer Report   ");
            writer.WriteLine("                         --------------------------");
            writer.WriteLine("                                 ( by Barcode )");
            writer.WriteLine("");

            writer.WriteLine("           Total Number of Customers = " + nr + "    date : " + thisDay.ToString("D"));
            writer.WriteLine("");

            writer.WriteLine("Barcode".PadRight(16) + "Surname".PadRight(20) + "Forename".PadRight(20) + "Shop".PadRight(12) + "Sheetno".PadRight(6));
            writer.WriteLine("".PadRight(14, '-') + "".PadRight(2, ' ') + "".PadRight(18, '-') + "".PadRight(2, ' ') + "".PadRight(18, '-') + "".PadRight(2, ' ') + "".PadRight(10, '-') + "".PadRight(2, ' ') + "".PadRight(6, '-'));

            for (int pos = 0; pos < inr; pos++)
            {
                DataRow row = dataset.Tables["customer"].Rows[pos];
                surname = row["surname"].ToString();
                forename = row["forename"].ToString();
                barcode = row["barcode"].ToString();
                sheetno = row["sheetno"].ToString();
                shop = row["shop"].ToString();
                cust_rec = barcode.PadRight(16) + surname.PadRight(20) + forename.PadRight(20) + shop.PadRight(12)  + sheetno.PadRight(6);
                writer.WriteLine(cust_rec);
            }

            writer.Close();
            fs.Close();

            Process.Start("notepad", repfile);

 //           MessageBox.Show("The Report has been produced successfully ", "", MessageBoxButtons.OK);

        }

        #endregion


        #region Barcode report in HTML

        public void prod_repbarHtml(System.Data.DataSet dataset, OleDbConnection database)
        {
            string shop;
            string surname;
            string forename;
            string barcode;
            string sheetno;


            string cust_rec;
            string nr;  // number of customers
            int inr;    // int number of customers
            string repdir;  // directory for reports
            string repfile;   // file for report

            inr = dataset.Tables["customer"].Rows.Count; // int number of rows
            nr = inr.ToString();

            repdir = get_reportdir(database);

            repfile = repdir + "\\report.html";


            FileStream fs = File.Create(@repfile);
            TextWriter writer = new StreamWriter(fs);

            writer.WriteLine(" <html>");
            writer.WriteLine("<head>");
            writer.WriteLine("<title>SVP GiftAid Report</title>");

            writer.WriteLine(" <style type=\"text/css\">");
            writer.WriteLine("<!--");
            writer.WriteLine(" #fontl {font-size:x-large;}");
            writer.WriteLine("#alr {text-align:right}");
            writer.WriteLine("--> ");
            writer.WriteLine("</style>");
            writer.WriteLine(" </head>");
            writer.WriteLine("<div id=\"allreport\" align=\"center\">");
            writer.WriteLine(" <h1> SVP GiftAid Customers </h1>");
            writer.WriteLine("<h2>     ( by Barcode Descending order )</h2> ");
            writer.WriteLine(" ");
            writer.WriteLine("<h2><b> Number of Customers = " + nr + "&nbsp&nbsp&nbsp Date : &nbsp" + thisDay.ToString("D") + "</b></h2>");
            writer.WriteLine("<p></p>");

            writer.WriteLine(" <table border=\"3\" id=\"fontl\">");
            writer.WriteLine("<tr>");

            writer.WriteLine("  <th>Barcode</th><th>Surname</th><th>Forename</th><th>Shop</th><th>Sheetno</th>");
            writer.WriteLine("</tr>");

            writer.WriteLine(" ");
            writer.WriteLine("");

            for (int pos = 0; pos < inr; pos++)
            {
                DataRow row = dataset.Tables["customer"].Rows[pos];
                surname = row["surname"].ToString();
                forename = row["forename"].ToString();
                barcode = row["barcode"].ToString();
                sheetno = row["sheetno"].ToString();
                shop = row["shop"].ToString();

                cust_rec = "<tr><td><b>" + barcode.PadRight(12)+ "</b></td><td>" + surname.PadRight(20) + "</td><td>" + forename.PadRight(20) + "</td><td>" + shop.PadRight(12) + "</td><td id=\"alr\">" + sheetno.PadRight(6) + "</td></tr>";
                writer.WriteLine(cust_rec);
            }

            writer.WriteLine("</table>");
            writer.WriteLine("</div>");
            writer.WriteLine("</html>");

            writer.Close();
            fs.Close();

            Process.Start("explorer.exe", repfile);

 //           MessageBox.Show("The Report has been produced successfully ", "", MessageBoxButtons.OK);

        }

        #endregion

        #region  Print one Family
        public void prod_repcustText(ModelDTO.fam_rec c, OleDbConnection database)
        {
            
            string repdir;  // directory for reports
            string repfile;   // file for report

            repdir = get_reportdir(database);

            repfile = repdir + "\\report.txt";


            FileStream fs = File.Create(@repfile);
            TextWriter writer = new StreamWriter(fs);

            writer.WriteLine("                         Family Census Report   ");
            writer.WriteLine("                       --------------------------");
            writer.WriteLine("");
            writer.WriteLine("         Date : ".PadRight(16) + thisDay.ToString("D"));
            writer.WriteLine("");

            writer.WriteLine("Family Name: ".PadRight(16) + c.fname.PadRight(6));
            writer.WriteLine("House : ".PadRight(16) + c.house.PadRight(16));
            writer.WriteLine("Address: ".PadRight(16) + c.address.PadRight(16));
            writer.WriteLine("Next of kin: ".PadRight(16) + c.nok.PadRight(6));
 //           writer.WriteLine("Post me: ".PadRight(16) + c.postme.PadRight(6));
 
            writer.WriteLine("");
            writer.WriteLine("telephone: ".PadRight(16) + c.tele.PadRight(16));
            writer.WriteLine("Mobile: ".PadRight(16) + c.mobile.PadRight(24));
            writer.WriteLine("Email : ".PadRight(16) + c.email.PadRight(6));
            writer.WriteLine("");

            writer.WriteLine("Postcode: ".PadRight(16) + c.postcode.PadRight(16));
            writer.WriteLine("PrefContact: ".PadRight(16) + c.prefcontact.PadRight(16));

            writer.WriteLine("Adults/Parents: ".PadRight(16) + c.ap1.PadRight(16));
            writer.WriteLine("Adults/Parents: ".PadRight(16) + c.ap2.PadRight(16));
            writer.WriteLine("Adults/Parents: ".PadRight(16) + c.ap3.PadRight(16));
            writer.WriteLine("Adults/Parents: ".PadRight(16) + c.ap4.PadRight(16));
            writer.WriteLine("Adults/Parents: ".PadRight(16) + c.ap5.PadRight(16));
            writer.WriteLine("Adults/Parents: ".PadRight(16) + c.ap6.PadRight(16));
            
            
        
            writer.WriteLine("");
            writer.WriteLine("child: ".PadRight(16) + c.c1.PadRight(12));
            writer.WriteLine("DoB: ".PadRight(16) + c.dob1.PadRight(16));
            writer.WriteLine("School: ".PadRight(16) + c.s1.PadRight(16));
            writer.WriteLine("");
            writer.WriteLine("child: ".PadRight(16) + c.c2.PadRight(12));
            writer.WriteLine("DoB: ".PadRight(16) + c.dob2.PadRight(16));
            writer.WriteLine("School: ".PadRight(16) + c.s2.PadRight(16));
            writer.WriteLine("");
            writer.WriteLine("child: ".PadRight(16) + c.c3.PadRight(12));
            writer.WriteLine("DoB: ".PadRight(16) + c.dob3.PadRight(16));
            writer.WriteLine("School: ".PadRight(16) + c.s3.PadRight(16));
            writer.WriteLine("");
            writer.WriteLine("child: ".PadRight(16) + c.c4.PadRight(12));
            writer.WriteLine("DoB: ".PadRight(16) + c.dob4.PadRight(16));
            writer.WriteLine("School: ".PadRight(16) + c.s4.PadRight(16));
            writer.WriteLine("");
            writer.WriteLine("child: ".PadRight(16) + c.c5.PadRight(12));
            writer.WriteLine("DoB: ".PadRight(16) + c.dob5.PadRight(16));
            writer.WriteLine("School: ".PadRight(16) + c.s5.PadRight(16));
            writer.WriteLine("");
            writer.WriteLine("child: ".PadRight(16) + c.c6.PadRight(12));
            writer.WriteLine("DoB: ".PadRight(16) + c.dob6.PadRight(16));
            writer.WriteLine("School: ".PadRight(16) + c.s6.PadRight(16));


            writer.WriteLine("");
            
            

            writer.WriteLine("");
            writer.WriteLine("");

            writer.WriteLine("     -------------   END OF REPORT   -------------");

            writer.Close();
            fs.Close();

            Process.Start("Notepad", repfile);

            //           MessageBox.Show("The Report has been produced successfully ", "", MessageBoxButtons.OK);
        }


        #endregion
    }
}
