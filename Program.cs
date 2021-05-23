using System;
using System.IO;
using System.Text;
using GRUPA_K13.Classes;
using GRUPA_K13.Classes.BusinessLogic;
using GRUPA_K13.Classes.Messages;

namespace GRUPA_K13
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlStorageTypes.Initialize();

            MessageFactory.Instance.Register<LoginMessage>();
            MessageFactory.Instance.Register<TextMessage>();

            Console.Write("Podaj model dzialania(1-serwer,2-klinet:)");

            switch (Console.ReadLine())
            {
                case "1":
                    new ServerModule().Run();
                    break;

                case "2":
                    new ClientModule().Run();
                    break;
            }

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

            /*
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
            */
        }
    }
}
