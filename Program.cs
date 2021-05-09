using System;
using System.IO;
using System.Text;
using GRUPA_K13.Classes;
using GRUPA_K13.Classes.BusinessLogic;

namespace GRUPA_K13
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            User _oUser = new User
            {
                Login = "jkuzmicz",
                Password = "12pwd34",
                Persmission = 1
            };

            try
            {
                _oUser.ExportToFile("user.xml");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            */

            User _oUser = new User();

            try
            {
                if (_oUser.ImportFromFile("user.xml"))
                {
                    Console.WriteLine(_oUser);
                }
                else
                {
                    Console.WriteLine("Coś nie pykło...");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
