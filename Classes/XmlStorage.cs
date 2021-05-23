using GRUPA_K13.Classes.System;
using GRUPA_K13.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;

namespace GRUPA_K13.Classes
{
    public static class XmlStorageTypes
    {
        private static readonly List<Type> KnownTypes = new List<Type>();

        static XmlStorageTypes()
        {
            using var _log = Log.DET("XmlStorageTypes", "XmlStorageTypes");

            Register<Object>();
            Register<Exception>();

            foreach (var _type in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (!_type.IsGenericType)
                {
                    foreach (var _attr in _type.GetCustomAttributes())
                    {
                        if (_attr.GetType() == typeof(DataContractAttribute))
                        {
                            Register(_type);
                            break;
                        }
                    }
                }
            }
        }

        public static void Initialize()
        {
            using var _log = Log.DET("XmlStorageTypes", "Initialize");
        }

        public static void Register<T>()
        {
            Register(typeof(T));
        }

        public static void Register(Type _oType)
        {
            using var _log = Log.DET("XmlStorageTypes", "Register");

            if (!KnownTypes.Contains(_oType))
            {
                _log.PR_DET($"Register:{_oType}");

                KnownTypes.Add(_oType);
            }
        }

        public static Type[] GetArray() => KnownTypes.ToArray();
    }

    [DataContract]
    public abstract class XmlStorage<T> : IXmlStorage where T : class
    {
        public virtual bool FromXml(Stream a_oStream)
        {
            DataContractSerializer _oSerializer = new DataContractSerializer(typeof(T), XmlStorageTypes.GetArray());

            using var _oReader = XmlDictionaryReader.CreateTextReader(a_oStream, new XmlDictionaryReaderQuotas());

            return InitializeFromObject((T)_oSerializer.ReadObject(_oReader, false));
        }

        public virtual MemoryStream ToXml()
        {
            DataContractSerializer _oSerializer = new DataContractSerializer(typeof(T), XmlStorageTypes.GetArray());

            using var _oStream = new MemoryStream();

            using var _oWriter = XmlDictionaryWriter.CreateTextWriter(_oStream, Encoding.UTF8);

            _oSerializer.WriteObject(_oWriter, this);

            return _oStream;
        }
        public abstract bool InitializeFromObject(T Object);
    }
}
