using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace GiftaidDB
{
    class ScreenValidation
    {
        public string adp1;
        public string adp2;
        public string adp3;
        public string adp4;
        public string adp5;
        public string adp6;

        public string dob1;
        public string dob2;
        public string dob3;
        public string dob4;
        public string dob5;
        public string dob6;

        public string child;
        public string dob;
        public string sch;

        private const string _securityKey = "MyComplexKey";

        public ScreenValidation( string a1, string a2, string a3, string a4, string a5, string a6, string b1, string b2, string b3, string b4, string b5, string b6 )
        {
          adp1 = a1;
          adp2 = a2;
          adp3 = a3;
          adp4 = a4;
          adp5 = a5;
          adp6 = a6;

          dob1 = b1;
          dob2 = b2;
          dob3 = b3;
          dob4 = b4;
          dob5 = b5;
          dob6 = b6;
        }

        public ScreenValidation(string c, string d, string s)
        {
            child = c;
            dob = d;
            sch = s;
        }

        public ScreenValidation()
        {  }

        #region Validate DOB
        public bool vald_dob()
        {
            DateTime dt;
            bool reply = true;
            try
            {
      //          string date = "01/08/2008";

                if (dob1.Length > 0)
                {
 //                   MessageBox.Show("dob1 => "+ dob1, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
 
                    dt = Convert.ToDateTime(dob1); 
                }

                if (dob2.Length > 0)
                { dt = Convert.ToDateTime(dob2); }

                if (dob3.Length > 0)
                { dt = Convert.ToDateTime(dob3); }

                if (dob4.Length > 0)
                { dt = Convert.ToDateTime(dob4); }

                if (dob5.Length > 0)
                { dt = Convert.ToDateTime(dob5); }

                if (dob6.Length > 0)
                { dt = Convert.ToDateTime(dob6); }

            }
//            catch (Exception ex)
            catch (Exception)
            {
                reply = false;
            }

            return reply;
        }
        #endregion

        #region Validate Adult Parent
        public bool vald_adp()
        {
            bool reply = false;

            if ( (adp1.Length >0) || (adp2.Length > 0)|| (adp3.Length > 0) || (adp4.Length > 0) || (adp5.Length > 0) || (adp6.Length > 0))
               { reply = true; }

            return reply;

        }
        #endregion

        #region Validate Child
        public bool vald_child()
        {
            bool reply = true;

            if ((child.Length.Equals(0)) & ((dob.Length > 0) || (sch.Length > 0)))
              { reply = false; }

            return reply;
        }
        #endregion

        #region Encrypt

        // using Triple DES algorithm.

        public static string EncryptPlainTextToCipherText(string PlainText)    
         {            //Getting the bytes of Input String.          
           byte[] toEncryptedArray = UTF8Encoding.UTF8.GetBytes(PlainText);          
           MD5CryptoServiceProvider objMD5CryptoService = new MD5CryptoServiceProvider();     
           //Gettting the bytes from the Security Key and Passing it to compute the Corresponding Hash Value.   
           byte[] securityKeyArray = objMD5CryptoService.ComputeHash(UTF8Encoding.UTF8.GetBytes(_securityKey)); 
           //De-allocatinng the memory after doing the Job.       
           objMD5CryptoService.Clear();    
           var objTripleDESCryptoService = new TripleDESCryptoServiceProvider();   
           //Assigning the Security key to the TripleDES Service Provider.   
           objTripleDESCryptoService.Key = securityKeyArray;     
          //Mode of the Crypto service is Electronic Code Book.     
           objTripleDESCryptoService.Mode = CipherMode.ECB;        
           //Padding Mode is PKCS7 if there is any extra byte is added.      
           objTripleDESCryptoService.Padding = PaddingMode.PKCS7;    
           var objCrytpoTransform = objTripleDESCryptoService.CreateEncryptor(); 
          //Transform the bytes array to resultArray    
           byte[] resultArray = objCrytpoTransform.TransformFinalBlock(toEncryptedArray, 0, toEncryptedArray.Length); 
          //Releasing the Memory Occupied by TripleDES Service Provider for Encryption.    
          objTripleDESCryptoService.Clear();   
         //Convert and return the encrypted data/byte into string format.  
         return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

     #endregion

        #region Decrypt

        // using Triple DES algorithm.

       public static string DecryptCipherTextToPlainText(string CipherText)     
       {          
           byte[] toEncryptArray = Convert.FromBase64String(CipherText);  
           MD5CryptoServiceProvider objMD5CryptoService = new MD5CryptoServiceProvider(); 
           //Gettting the bytes from the Security Key and Passing it to compute the Corresponding Hash Value. 
           byte[] securityKeyArray = objMD5CryptoService.ComputeHash(UTF8Encoding.UTF8.GetBytes(_securityKey));
           //De-allocatinng the memory after doing the Job.       
           objMD5CryptoService.Clear();       
           var objTripleDESCryptoService = new TripleDESCryptoServiceProvider();    
           //Assigning the Security key to the TripleDES Service Provider.  
           objTripleDESCryptoService.Key = securityKeyArray; 
           //Mode of the Crypto service is Electronic Code Book.  
           objTripleDESCryptoService.Mode = CipherMode.ECB;   
           //Padding Mode is PKCS7 if there is any extra byte is added. 
           objTripleDESCryptoService.Padding = PaddingMode.PKCS7;    
           var objCrytpoTransform = objTripleDESCryptoService.CreateDecryptor();  
           //Transform the bytes array to resultArray       
           byte[] resultArray = objCrytpoTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);  
           //Releasing the Memory Occupied by TripleDES Service Provider for Decryption. 
           objTripleDESCryptoService.Clear();     
           //Convert and return the decrypted data/byte into string format.  
           return UTF8Encoding.UTF8.GetString(resultArray);     
       }


        #endregion
    }
}
