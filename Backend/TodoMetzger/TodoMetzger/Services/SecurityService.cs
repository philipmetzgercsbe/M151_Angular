using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace TodoMetzger.Services
{
    public static class SecurityService
    {
        public static bool CanAuthenticate(byte[] inputPassword, byte[] storedPassword)
        {
            for (int i = 0; i < inputPassword.Length; i++)
            {
                if (inputPassword[i] != storedPassword[i]) return false;
            }
            return true;
        }
        public static byte[] HashPassword(byte[] inputToHash,byte[] saltBytes)
        {

            byte[] salt = SetSalt();
            byte[] hashedInput;
            byte[] password = CreatePassword(inputToHash, salt);
            using (SHA256 sha256 = SHA256.Create())
            {
                hashedInput = sha256.ComputeHash(password);
            }
            return hashedInput;

        }


        private static byte[] CreatePassword(byte[] userPassword, byte[] salt)
        {
            
            byte[] dMagician = Encoding.Default.GetBytes("nesridi"); ;//This a part of each password stored in the DB
            byte[] actualPassword = new byte[userPassword.Length + salt.Length + dMagician.Length];
            Buffer.BlockCopy(dMagician,0,actualPassword,0,dMagician.Length);
            Buffer.BlockCopy(userPassword, 0, actualPassword, 0, userPassword.Length);
            Buffer.BlockCopy(salt, 0, actualPassword, 0, salt.Length);
            return actualPassword; //Now the Password is nesridi + password + salt

        }

        public static byte[] SetSalt()
        {
           return new byte[DateTime.Now.TimeOfDay.Milliseconds];
        }

        
    }
}
