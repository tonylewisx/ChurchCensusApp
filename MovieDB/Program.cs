using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GiftaidDB
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        public const string ACCESSACE= "4";
        public const string MYSQL = "3";
        public const string SQLSERVER = "2";
        public const string ORACLE = "1";
        public const string ACCESS = "0";
        public const string DB = "4"; // Specify which DB backend to use 

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new KeyAccess());
 //           Application.Run(new Form1());
        }
    }
}