using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace GRUPA_K13.Classes.BusinessLogic
{
    [DataContract]
    public class User : FileXmlStorage<User>
    {
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public int Persmission { get; set; }

        public override string ToString()
        {
            return $"[Login={Login}|Password=???|Persmission={Persmission}]";
        }
    }
}
