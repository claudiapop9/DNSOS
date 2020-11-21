
using PacketDotNet;
using WifiAnalyzerRDSOS.Internet;

namespace WifiAnalyzerRDSOS
{
    public class MyEthernetPacket
    {
        public string DestinationHardwareAddress { get; set; }
        public IIpPacket PayloadPacket { get; set; }
        public string SourceHardwareAddress { get; set; }
        public string Type { get; set; }

        public MyEthernetPacket(PacketDotNet.EthernetPacket ethernetPacket)
        {
            DestinationHardwareAddress = ethernetPacket.DestinationHardwareAddress.ToString();
            SourceHardwareAddress = ethernetPacket.SourceHardwareAddress.ToString();
            Type = ethernetPacket.Type.ToString();
            if (Type.Equals("IPv4")) {
                PacketDotNet.IPPacket ipPacket2 = (PacketDotNet.IPPacket)ethernetPacket.Extract<IPPacket>();    
                PayloadPacket = new IpV4Packet(ipPacket2.Bytes);
            }
        }
    }
}
