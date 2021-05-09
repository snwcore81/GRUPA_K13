using System;
using System.Collections.Generic;
using System.Text;

namespace GRUPA_K13.Classes.Exceptions
{
    public class MessageFactoryTypeNotFound : Exception
    {
        public MessageFactoryTypeNotFound(string a_sTypeName) :
            base($"Nie odnaleziono w fabryce typu <{a_sTypeName}>!")
        {
        }
    }
}
