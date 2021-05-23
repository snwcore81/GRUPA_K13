using GRUPA_K13.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GRUPA_K13.Classes.System
{
    public class ConsoleLogWriter : ILogWriter
    {
        private static readonly object LOCK_WRITE = new object();
        public void Write(string a_sText)
        {
            lock (LOCK_WRITE)
            {
                if (!string.IsNullOrEmpty(a_sText))
                    Console.WriteLine(a_sText);
            }
        }
    }
}
