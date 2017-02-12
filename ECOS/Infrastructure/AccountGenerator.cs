using ECOS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ECOS.Broker
{
   public static class AccountGenerator
    {
        private static string generate_login(dynamic user, string role)
        {
            Random rand = new Random();
            int random = rand.Next(1000, 9999);
            string temp = user.First_name.Substring(0,4);
            string temp1 = user.Last_name.Substring(0,3);
            string user_name = temp + temp1 + random.ToString() + role.Substring(0,1);
            return user_name;
        }
        private static string generate_password(int maxSize)
        {
            char[] chars = new char[62];
            chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetBytes(data);
            data = new byte[maxSize];
            crypto.GetBytes(data);
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }


        public static void generate_account(ref string user_name, ref string password, object user,string role )
        {
            user_name = generate_login(user, role);
            string pass = generate_password(10);

            MessageBox.Show(string.Format("For the user are generated following login and password \n\n  -Login: {0} \n  -Password: {1}", user_name, pass), "Account creating", MessageBoxButton.OK, MessageBoxImage.Information);
            password = pass;
        }
        private static string MD5Hash(string input)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();

        }
    }
}
