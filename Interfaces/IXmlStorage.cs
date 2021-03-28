using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GRUPA_K13.Interfaces
{
    public interface IXmlStorage
    {
        bool FromXml(Stream Stream);
        MemoryStream ToXml();
    }
}
