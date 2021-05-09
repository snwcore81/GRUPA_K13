using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;

namespace GRUPA_K13.Classes
{
    [DataContract]
    public class FileXmlStorage<T> : AutoInitXmlStorage<T> where T : class
    {
        public virtual void ExportToFile(string a_sFileName)
        {
            using (var _file = new StreamWriter(a_sFileName))
            {
                var _sStrBuff = Encoding.UTF8.GetString(ToXml().ToArray());

                _file.Write(_sStrBuff);
            }
        }

        public virtual bool ImportFromFile(string a_sFileName)
        {
            using (var _file = new StreamReader(a_sFileName))
            {
                var _sStrBuff = _file.ReadToEnd();

                var _oByteBuffer = Encoding.UTF8.GetBytes(_sStrBuff);

                return FromXml(new MemoryStream(_oByteBuffer));
            }
        }
    }
}
