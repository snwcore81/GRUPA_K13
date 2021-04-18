using System;
using System.Collections.Generic;
using System.Text;

namespace GRUPA_K13.Classes.Exceptions
{
    public class NetworkDataBufferLessThan1 : Exception
    {
        public NetworkDataBufferLessThan1() : base("Bufor danych mniejszy niz 1!")
        {
        }
    }
}
