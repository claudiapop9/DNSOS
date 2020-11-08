namespace WifiAnalyzerRDSOS
{
    class WLANNetwork
    {
        public string SSID { get; set; }
        public string BSSNetworkType { get; set; }
        public string BSSIDsNo { get; set; }
        public bool Connectable { get; set; }
        public string SignalQuality { get; set; }
        public bool isSecurityEnabled { get; set; }
        public string AuthAlgorithm { get; set; }
        public string CipherAlgorithm { get; set; }
        public string Flags { get; set; }
    }
}
