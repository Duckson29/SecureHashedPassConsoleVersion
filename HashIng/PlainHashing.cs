using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace SecurePassWordXMLStore.HashIng
{
    public class Hashing
    {
        private HMAC mAC = new HMACSHA256();
        public byte[] HashWithSalt(string pass, string saltKey)
        {
            return mAC.ComputeHash(GetHash(pass + saltKey));

        }
        private byte[] GetHash(string pass)
        {
            return mAC.ComputeHash(Encoding.UTF8.GetBytes(pass));
        }
        public byte[] CreateSalt(int size)
        {
            //Generate a cryptographic random number.
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[size];
            rng.GetBytes(buff);            
            return buff;
        }
    }
}
