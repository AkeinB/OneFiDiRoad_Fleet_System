using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OneFiDiRoad_Fleet_System
{
    internal class Utils
    {
        
        // This method takes a password as input and returns its SHA256 hash as a hexadecimal string
        public static string HashPassword(string password)
        {
            SHA256 sha = SHA256.Create();

            //Convert the password to a byte array and hash it
            byte[] data = sha.ComputeHash(Encoding.UTF8.GetBytes(password));


            // Create a new StringBuilder to collect the bytes
            // and create a string
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        // This method returns the SHA256 hash of the default password "Password@123" as a hexadecimal string
        public static string DefaultHashPassword()
        {
            SHA256 sha = SHA256.Create();

            //Convert the password to a byte array and hash it
            byte[] data = sha.ComputeHash(Encoding.UTF8.GetBytes("Password@123"));


            // Create a new StringBuilder to collect the bytes
            // and create a string
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}
