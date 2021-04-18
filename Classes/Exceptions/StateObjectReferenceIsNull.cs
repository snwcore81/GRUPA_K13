using System;
using System.Collections.Generic;
using System.Text;

namespace GRUPA_K13.Classes.Exceptions
{
    public class StateObjectReferenceIsNull : Exception
    {
        public StateObjectReferenceIsNull() : base("Referencja do obiektu jest null!")
        {

        }
    }
}
