using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace GRUPA_K13.Classes.BusinessLogic
{
    [DataContract]
    public class User : XmlStorage<User>
    {
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string Password { get; set; }

        public override bool InitializeFromObject(User Object)
        {
            this.Login = Object.Login;
            this.Password = Object.Password;

            return true;
        }
    }
}
