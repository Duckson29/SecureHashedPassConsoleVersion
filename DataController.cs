using Intro;
using SecurePassWordXMLStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecurePassWordXMLStore
{
    class DataController
    {

        public bool CheckPassword(string username, string password)
        {
            using (var db = new UserContext())
            {
                Users userResult = db.User.FirstOrDefault(x => x.Username == username);
                var passHash = new HashIng.Hashing().HashWithSalt(password, userResult.salt);
                if (Convert.ToBase64String(passHash) == userResult.Hashed)
                    return true;
                else
                    return false;

            }
        }
        public void CreateUser(string username, string password)
        {
            byte[] salt = new SecurePassWordXMLStore.HashIng.Hashing().CreateSalt(4);
            byte[] hashedPassword = new SecurePassWordXMLStore.HashIng.Hashing().HashWithSalt(password, Convert.ToBase64String(salt));

            using (var db = new UserContext())
            {

                db.Add(new Users {Username=username, Hashed = Convert.ToBase64String(hashedPassword), salt = Convert.ToBase64String(salt) });
                db.SaveChanges();

            }
        }
    }
}
