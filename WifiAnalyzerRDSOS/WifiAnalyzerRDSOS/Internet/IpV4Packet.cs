using System;
using System.Net;
using WifiAnalyzerRDSOS.Transport;

namespace WifiAnalyzerRDSOS.Internet
{
    /// An IPv4 packet
    ///    0                   1                   2                   3
    ///    0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1
    ///   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
    ///   |Version|  IHL  |Type of Service|          Total Length         |
    ///   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
    ///   |         Identification        |Flags|      Fragment Offset    |
    ///   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
    ///   |  Time to Live |    Protocol   |         Header Checksum       |
    ///   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
    ///   |                       Source Address                          |
    ///   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
    ///   |                    Destination Address                        |
    ///   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
    ///   |                    Options                    |    Padding    |
    ///   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
    /// 
    class IpV4Packet : IIpPacket
    {
        public DateTime CaptureTime { get; }

        public IpVersion Version => IpVersion.Ipv4;
        public short HeaderLength { get; }
        public byte TypeOfService { get; }
        public short TotalLength { get; }

        public short Identification { get; }
        public FragmentationFlags FragmentationFlags { get; }
        public short FragmentOffset { get; }

        public byte TimeToLive { get; }
        public IpProtocol Protocol { get; }
        public short HeaderChecksum { get; }

        public IPAddress SourceAddress { get; }
        public IPAddress DestinationAddress { get; }

        /// <summary>Transport-layer packet contained within the payload</summary>
        public ITransportPacket TransportPacket { get; private set; }

        public byte[] Payload { get; }

        public byte[] RawData { get; }

        public IpV4Packet(byte[] data, DateTime? captureTime = null)
        {
            CaptureTime = captureTime ?? DateTime.UtcNow;
            RawData = data;

            TypeOfService = RawData[Offsets.TypeOfService];
            TotalLength = BitConverter.ToInt16(RawData, Offsets.TotalLength);

            Identification = BitConverter.ToInt16(RawData, Offsets.Identification);

            HeaderChecksum = BitConverter.ToInt16(RawData, Offsets.HeaderChecksum);

            var sAdress = BitConverter.ToInt32(RawData, Offsets.SourceAddress);
            SourceAddress = new IPAddress(sAdress);
            var dAdress = BitConverter.ToInt32(RawData, Offsets.DestinationAddress);
            DestinationAddress = new IPAddress(dAdress);
            //TransportPacket = new RawPacket(this);
        }

        private static class Offsets
        {
            public const int VersionAndHeaderLength = 0;
            public const int TypeOfService = 1;
            public const int TotalLength = 2;
            public const int Identification = 4;
            public const int FlagsAndOffset = 6;
            public const int Ttl = 8;
            public const int Protocol = 9;
            public const int HeaderChecksum = 10;
            public const int SourceAddress = 12;
            public const int DestinationAddress = 16;

            public const int Options = 20;
        }

    }
}

