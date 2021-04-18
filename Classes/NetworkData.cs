using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using GRUPA_K13.Classes.Exceptions;

namespace GRUPA_K13.Classes
{
    public class NetworkData
    {
        public const byte EMPTY = 0;

        private readonly byte[] m_oBuffer;

        public NetworkData(int a_iBufferSize)
        {
            if (a_iBufferSize < 1)
                throw new NetworkDataBufferLessThan1();

            m_oBuffer = new byte[a_iBufferSize];

            Clear();
        }

        public void Clear()
        {
            Array.Fill<byte>(m_oBuffer, EMPTY);
        }

        public int BufferLength => m_oBuffer?.Length ?? -1;
        
        /* kod realizujacy to samo zagadnienie co wyzej
        public int BufferLength
        {
            get
            {
                if (m_oBuffer == null)
                    return -1;

                return m_oBuffer.Length;
            }
        }
        */

        public int DataLength(bool a_bWithZero = false)
        {
            return m_oBuffer.ToList().FindIndex(x => x == EMPTY) + (a_bWithZero ? 1 : 0);
        }

        public bool HasAnyData => DataLength() > 1;

        public byte[] Buffer
        {
            get => m_oBuffer;
            set
            {
                if (value == null)
                    throw new NetworkDataBufferToSmall("Bufor danych wejsciowych", BufferLength - 1, 0);

                if (value.Length > BufferLength - 1)
                    throw new NetworkDataBufferToSmall("Bufor danych NetworkData", BufferLength - 1, value.Length);

                Clear();

                Array.Copy(value, m_oBuffer, value.Length);
            }
        }

    }
}
