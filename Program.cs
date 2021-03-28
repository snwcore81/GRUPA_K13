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
            XmlStorageTypes.Register<User>();

            /*
            User _oUser = new User
            {
                Login = "jacek",
                Password = "12jacek34"
            };

            var _oStream = _oUser.ToXml();

            string _sXML = Encoding.UTF8.GetString(_oStream.ToArray());
            */

            string _sXML = @"<User xmlns=""http://schemas.datacontract.org/2004/07/GRUPA_K13.Classes.BusinessLogic"" xmlns:i=""http://www.w3.org/2001/XMLSchema-instance""><Login>jacek</Login><Password>12jacek34</Password></User>";

            User _oUser = new User();

            _oUser.FromXml(new MemoryStream(Encoding.UTF8.GetBytes(_sXML)));

            Console.WriteLine(_sXML);

            Console.WriteLine($"Login={_oUser.Login} Password={_oUser.Password}");
        }
    }
}
