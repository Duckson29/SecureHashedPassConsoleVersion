using Intro;
using Microsoft.EntityFrameworkCore.Internal;
using SecurePassWordXMLStore.Models;
using System;
using System.Linq;
using SecurePassWordXMLStore.HashIng;

namespace SecurePassWordXMLStore
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("1.Login\n2.Create User");
            int input = int.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:
                    Console.Clear();
                    Console.Write("Username: ");
                    string username = Console.ReadLine();
                    Console.Clear();
                    Console.Write("Password: ");
                    string pass = Console.ReadLine();
                    bool auth = new DataController().CheckPassword(username,pass);
                    Console.WriteLine("Can login? "+auth);

                    break;
                case 2:
                    Console.Clear();
                    Console.Write("New Username: ");
                    string usernameNew = Console.ReadLine();
                    Console.Clear();
                    Console.Write("New Password: ");
                    string passn = Console.ReadLine();
                    new DataController().CreateUser(usernameNew,passn);
                    break;
                default:
                    break;
            }

            
        }
    }
}
