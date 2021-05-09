﻿using GRUPA_K13.Classes.Exceptions;
using GRUPA_K13.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace GRUPA_K13.Classes
{
    public sealed class MessageFactory
    {
        public static readonly MessageFactory Instance = new MessageFactory();

        private readonly Dictionary<string, Type> m_oMessages;

        private MessageFactory()
        {
            m_oMessages = new Dictionary<string, Type>();
        }
        public void Register<T>() where T : class
        {
            Type _Type = typeof(T);
            string _sTypeName = _Type.Name;

            if (!(_Type.GetInterfaces()?.ToArray()?.Contains(typeof(IMessage)) ?? false))
                throw new MessageFactoryIfaceNotFound(_sTypeName);

            if (!m_oMessages.ContainsKey(_sTypeName))
            {
                m_oMessages.Add(_sTypeName, _Type);
            }
        }
        public T Create<T>(string a_sTypeName) where T : class
        {
            if (m_oMessages.ContainsKey(a_sTypeName))
            {
                return (T)Activator.CreateInstance(m_oMessages[a_sTypeName]);
            }
            throw new MessageFactoryTypeNotFound(a_sTypeName);
        }

        public dynamic Create(string a_sTypeName) => Create<dynamic>(a_sTypeName);

        public dynamic Create(NetworkData a_oNetData)
        {
            if ((a_oNetData?.DataLength() ?? 0) < 1)
                throw new NetworkDataBufferLessThan1();

            var _oByteData = a_oNetData.Buffer.Take(a_oNetData.DataLength()).ToArray();

            return Create(_oByteData);
        }

        public dynamic Create(byte[] a_oData)
        {
            using var _oXmlReader = XmlReader.Create(new MemoryStream(a_oData));

            _oXmlReader.Read();

            string _sTypeName = _oXmlReader.Name;

            var _oMessage = Create<IXmlStorage>(_sTypeName);

            _oMessage.FromXml(new MemoryStream(a_oData));

            return _oMessage;
        }
    }
}
