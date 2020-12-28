using PacketDotNet;
using SharpPcap;
using SharpPcap.LibPcap;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using WifiAnalyzerRDSOS.Internet;

namespace WifiAnalyzerRDSOS
{
    public partial class SnifferForm : Form
    {
        LibPcapLiveDevice wifi_device;
        Dictionary<int, Packet> capturedPackets_list = new Dictionary<int, Packet>();

        int packetNumber = 1;
        string time_str = "", sourceIP = "", destinationIP = "", protocol_type = "", length = "";

        Thread sniffing;

        public SnifferForm()
        {
            InitializeComponent();
            LibPcapLiveDeviceList devices = LibPcapLiveDeviceList.Instance;
            foreach (LibPcapLiveDevice device in devices)
            {
                if (!device.Interface.Addresses.Exists(a => a != null && a.Addr != null && a.Addr.ipAddress != null)) continue;
                var devInterface = device.Interface;
                var friendlyName = devInterface.FriendlyName;
                if (friendlyName.Contains("Wi-Fi"))
                {
                    wifi_device = device;
                }
            }
        }

        private void stopSnifferButton_Click(object sender, EventArgs e)
        {
            sniffing.Abort();
            wifi_device.StopCapture();
            wifi_device.Close();
            startSnifferButton.Enabled = true;
            stopSnifferButton.Enabled = false;
        }

        private void startSnifferButton_Click(object sender, EventArgs e)
        {
            wifi_device.OnPacketArrival += new PacketArrivalEventHandler(Device_OnPacketArrival);
            sniffing = new Thread(new ThreadStart(sniffing_Proccess));
            sniffing.Start();
            startSnifferButton.Enabled = false;
            stopSnifferButton.Enabled = true;
        }

        public void Device_OnPacketArrival(object sender, CaptureEventArgs e)
        {

            DateTime time = e.Packet.Timeval.Date;
            time_str = (time.Hour + 1) + ":" + time.Minute + ":" + time.Second + ":" + time.Millisecond;
            length = e.Packet.Data.Length.ToString();


            var packet = Packet.ParsePacket(e.Packet.LinkLayerType, e.Packet.Data);

            if (!capturedPackets_list.ContainsKey(packetNumber))
            {
                capturedPackets_list.Add(packetNumber, packet);
            }

            //PacketDotNet.EthernetPacket ipPacket = (EthernetPacket)packet;

            PacketDotNet.IPPacket ipPacket = (PacketDotNet.IPPacket)packet.Extract<IPPacket>();
            if (ipPacket != null)
            {
                System.Net.IPAddress srcIp = ipPacket.SourceAddress;
                System.Net.IPAddress dstIp = ipPacket.DestinationAddress;
                protocol_type = ipPacket.Protocol.ToString();
                sourceIP = srcIp.ToString();
                destinationIP = dstIp.ToString();

                ListViewItem item = new ListViewItem(packetNumber.ToString());
                item.SubItems.Add(time_str);
                item.SubItems.Add(sourceIP);
                item.SubItems.Add(destinationIP);
                item.SubItems.Add(protocol_type);
                item.SubItems.Add(length);

                Action action = () => packetsListView.Items.Add(item);
                packetsListView.Invoke(action);

                ++packetNumber;
            }

        }

        private void sniffing_Proccess()
        {
            // Open the device for capturing
            int readTimeoutMilliseconds = 1000;
            wifi_device.Open(DeviceMode.Promiscuous, readTimeoutMilliseconds);

            // Start the capturing process
            if (wifi_device.Opened)
            {
                wifi_device.Capture();
            }
        }

        private void packetsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (packetsListView.SelectedItems.Count < 1) {
                return;
            }
            var lastSelected = packetsListView.SelectedIndices.Count - 1;
            var index = packetsListView.SelectedIndices[lastSelected];
            var item = packetsListView.Items[index];
            string protocol = item.SubItems[4].Text;
            int key = Int32.Parse(item.SubItems[0].Text);
            Packet packet;
            bool getPacket = capturedPackets_list.TryGetValue(key, out packet);

            switch (protocol)
            {
                case "Tcp":
                    if (getPacket)
                    {
                        var tcpPacket = (PacketDotNet.TcpPacket)packet.Extract<PacketDotNet.TcpPacket>();
                        if (tcpPacket != null)
                        {
                            int srcPort = tcpPacket.SourcePort;
                            int dstPort = tcpPacket.DestinationPort;
                            var checksum = tcpPacket.Checksum;

                            packetInfoTextBox.Text = "";
                            packetInfoTextBox.Text = "Packet number: " + key +
                                            " Type: TCP" +
                                            "\r\nSource port:" + srcPort +
                                            "\r\nDestination port: " + dstPort +
                                            "\r\nTCP header size: " + tcpPacket.DataOffset +
                                            "\r\nWindow size: " + tcpPacket.WindowSize + // bytes that the receiver is willing to receive
                                            "\r\nChecksum:" + checksum.ToString() + (tcpPacket.ValidChecksum ? ",valid" : ",invalid") +
                                            "\r\nTCP checksum: " + (tcpPacket.ValidTcpChecksum ? ",valid" : ",invalid") +
                                            "\r\nSequence number: " + tcpPacket.SequenceNumber.ToString() +
                                            "\r\nAcknowledgment number: " + tcpPacket.AcknowledgmentNumber + (tcpPacket.Acknowledgment ? ",valid" : ",invalid") +
                                            // flags
                                            "\r\nUrgent pointer: " + (tcpPacket.Urgent ? "valid" : "invalid") +
                                            "\r\nACK flag: " + (tcpPacket.Acknowledgment ? "1" : "0") + // indicates if the AcknowledgmentNumber is valid
                                            "\r\nPSH flag: " + (tcpPacket.Push ? "1" : "0") + // push 1 = the receiver should pass the data to the app immidiatly, don't buffer it
                                            "\r\nRST flag: " + (tcpPacket.Reset ? "1" : "0") + // reset 1 is to abort existing connection
                                                                                               // SYN indicates the sequence numbers should be synchronized between the sender and receiver to initiate a connection
                                            "\r\nSYN flag: " + (tcpPacket.Synchronize ? "1" : "0") +
                                            // closing the connection with a deal, host_A sends FIN to host_B, B responds with ACK
                                            // FIN flag indicates the sender is finished sending
                                            "\r\nFIN flag: " + (tcpPacket.Finished ? "1" : "0") +
                                            "\r\nECN flag: " + (tcpPacket.ExplicitCongestionNotificationEcho ? "1" : "0") +
                                            "\r\nCWR flag: " + (tcpPacket.CongestionWindowReduced ? "1" : "0") +
                                            "\r\nNS flag: " + (tcpPacket.NonceSum ? "1" : "0");
                        }
                    }
                    break;
                case "Udp":
                    if (getPacket)
                    {
                        var udpPacket = (UdpPacket)packet.Extract<UdpPacket>();
                        if (udpPacket != null)
                        {
                            int srcPort = udpPacket.SourcePort;
                            int dstPort = udpPacket.DestinationPort;
                            var checksum = udpPacket.Checksum;

                            packetInfoTextBox.Text = "";
                            packetInfoTextBox.Text = "Packet number: " + key +
                                            " Type: UDP" +
                                            "\r\nSource port:" + srcPort +
                                            "\r\nDestination port: " + dstPort +
                                            "\r\nChecksum:" + checksum.ToString() + " valid: " + udpPacket.ValidChecksum +
                                            "\r\nValid UDP checksum: " + udpPacket.ValidUdpChecksum;
                        }
                    }
                    break;

                default:
                    packetInfoTextBox.Text = "";
                    break;
            }
        }

    }
}
