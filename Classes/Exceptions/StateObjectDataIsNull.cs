using System;
using System.Collections.Generic;
using System.Text;

namespace GRUPA_K13.Classes.Exceptions
{
    public class StateObjectDataIsNull : Exception
    {
        public StateObjectDataIsNull() : base("Referencja do danych jest null!")
        {
        }
    }
}
