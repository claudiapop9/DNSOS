using System;
using WifiAnalyzerRDSOS.Internet;
using WifiAnalyzerRDSOS.Transport;

namespace WifiAnalyzerRDSOS
{
    /// <summary>
    ///    0                   1                   2                   3
    ///    0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1
    ///   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
    ///   |          Source Port          |       Destination Port        |
    ///   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
    ///   |                        Sequence Number                        |
    ///   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
    ///   |                    Acknowledgment Number                      |
    ///   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
    ///   |  Data | Res |N|C|E|U|A|P|R|S|F|                               |
    ///   | Offset| erv |S|W|C|R|C|S|S|Y|I|            Window             |
    ///   |       | ed  | |R|E|G|K|H|T|N|N|                               |
    ///   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
    ///   |           Checksum            |         Urgent Pointer        |
    ///   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
    ///   |                    Options                    |    Padding    |
    ///   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
    ///   |                             Data                              |
    ///   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
    /// 
    /// </summary>
    public class TcpPacket : ITransportPacket, IHasPorts
    {
        public short SourcePort { get; }

        public short DestinationPort { get; }

        public int SequenceNumber { get; }

        public int AcknowledgmentNumber { get; }

        public short DataOffset { get; }

        public TcpControlFlags ControlFlags { get; }

        public short Window { get; }

        public short Checksum { get; }

        public short UrgentPointer { get; }

       byte[] Payload { get; }

        public byte[] RawData { get; }

        public TcpPacket(IIpPacket ipPacket)
        {
            if (ipPacket == null) throw new ArgumentNullException(nameof(ipPacket));
            if (ipPacket.Protocol != IpProtocol.TCP) throw new ArgumentOutOfRangeException(nameof(ipPacket.Protocol));

            RawData = ipPacket.Payload;

            SourcePort = BitConverter.ToInt16(RawData, Offsets.SourcePort);
            
        }
 
        // Byte offsets
        private static class Offsets
        {
            public const int SourcePort = 0;
            public const int DestinationPort = 2;
            public const int SequenceNumber = 4;
            public const int AcknowledgmentNumber = 8;
            public const int DataOffsetAndFlags = 12;
            public const int Window = 14;
            public const int Checksum = 16;
            public const int UrgentPointer = 18;
            public const int Options = 20;
        }
    }
}
