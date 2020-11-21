using System;

namespace WifiAnalyzerRDSOS.Transport
{
    public class RawPacket : ITransportPacket
    {
        /// The full, raw data that comprises the packet
        public byte[] RawData { get; }

        public RawPacket(IIpPacket ipPacket)
        {
            if (ipPacket == null) throw new ArgumentNullException(nameof(ipPacket));

            RawData = ipPacket.Payload;
        }

    }
}
