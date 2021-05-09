using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace GRUPA_K13.Classes
{
    [DataContract]
    public class AutoInitXmlStorage<T> : XmlStorage<T> where T : class
    {
        public override bool InitializeFromObject(T Object)
        {
            foreach (var _property in typeof(T).GetProperties())
            {
                _property.SetValue(this, _property.GetValue(Object));
            }

            foreach (var _field in typeof(T).GetFields())
            {
                _field.SetValue(this, _field.GetValue(Object));
            }

            return true;
        }
    }
}
