using System;
using System.Net;
using WifiAnalyzerRDSOS.Internet;
using WifiAnalyzerRDSOS.Transport;

namespace WifiAnalyzerRDSOS
{
    public interface IIpPacket
    {
        DateTime CaptureTime { get; }

        /// IP Protocol Version (e.g. IPv4 or IPv6)
        IpVersion Version { get; }

        IpProtocol Protocol { get; }

        IPAddress SourceAddress { get; }

        IPAddress DestinationAddress { get; }

        /// Transport-layer packet contained within the payload</summary>
        ITransportPacket TransportPacket { get; }

        /// The packet payload
        byte[] Payload { get; }

        /// The full, raw data that comprises the packet</summary>
        byte[] RawData { get; }
    }
}
