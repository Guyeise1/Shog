using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gosh.Models
{
    public class Password
    {
        public long ID { get; set; }
        public byte[] Hash { get; set; }
        public byte[] Salt { get; set; }

        [Index("IX_PWD_USER_UNIQUE", IsUnique = true)]
        public long UserID { get; set; }
        public User User { get; set; }
    
        public static Password Create(string ClearTextPassword)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] Salt = new byte[32];
            rng.GetBytes(Salt);
            byte[] Hash = HashPassword(ClearTextPassword, Salt);

            Password ret = new Password();
            ret.Hash = Hash;
            ret.Salt = Salt;
            return ret;
        }

        private static byte[] HashPassword(string ClearTextPassword, byte[] Salt)
        {

            HashAlgorithm algorithm = new SHA256Managed();

            byte[] pwdBytes = Encoding.ASCII.GetBytes(ClearTextPassword);

            byte[] SaltedPassword = new byte[Salt.Length + pwdBytes.Length];

            for (int i = 0; i < pwdBytes.Length; i++)
            {
                SaltedPassword[i] = pwdBytes[i];
            }

            for (int i = 0; i < Salt.Length; i++)
            {
                SaltedPassword[i + pwdBytes.Length] = Salt[i];
            }

            return algorithm.ComputeHash(SaltedPassword);


        }

        public static bool Check(string ClearTextPassword, Password pwd)
        {
            byte[] checkHash = HashPassword(ClearTextPassword, pwd.Salt);

            if(checkHash.Length != pwd.Hash.Length)
            {
                return false;
            }

            for (int i = 0; i < checkHash.Length; i++)
            {
                if(checkHash[i] != pwd.Hash[i])
                { 
                    return false;
                }
            }

            return true;
        }


    }
}