using System;

namespace WifiAnalyzerRDSOS.Transport
{
    public interface ITransportPacket
    {
        /// <summary>The full, raw data that comprises the packet</summary>
       byte[] RawData { get; }
    }

    public interface IHasPorts
    {
        short SourcePort { get; }
        short DestinationPort { get; }
    }
}
