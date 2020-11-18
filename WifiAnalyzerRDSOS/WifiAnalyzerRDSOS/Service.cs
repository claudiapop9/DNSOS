using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace WifiAnalyzerRDSOS
{
    class Service
    {
        #region WLANInterface
        private enum WLAN_INTERFACE_STATE
        {
            wlan_interface_state_not_ready = 0,
            wlan_interface_state_connected = 1,
            wlan_interface_state_ad_hoc_network_formed = 2,
            wlan_interface_state_disconnecting = 3,
            wlan_interface_state_disconnected = 4,
            wlan_interface_state_associating = 5,
            wlan_interface_state_discovering = 6,
            wlan_interface_state_authenticating = 7
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct WLAN_INTERFACE_INFO
        {
            public Guid InterfaceGuid;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string strInterfaceDescription;
            public WLAN_INTERFACE_STATE isState;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct WLAN_INTERFACE_INFO_LIST
        {
            public int dwNumberOfItems;
            public int dwIndex;
            public WLAN_INTERFACE_INFO[] InterfaceInfo;

            public WLAN_INTERFACE_INFO_LIST(IntPtr pList)
            {
                int iByteCount = 0;

                dwNumberOfItems = Marshal.ReadInt32(pList, iByteCount);
                iByteCount += Marshal.SizeOf(dwNumberOfItems.GetType());

                dwIndex = Marshal.ReadInt32(pList, iByteCount);
                iByteCount += Marshal.SizeOf(dwIndex.GetType());

                int ifListStartOffset = iByteCount;

                int ifListItemSize = Marshal.SizeOf(typeof(Int32)) * 5 + 2 * 256; // Int32*4 + WCHAR[256] + Int32
                InterfaceInfo = new WLAN_INTERFACE_INFO[dwNumberOfItems];
                for (int i = 0; i < dwNumberOfItems; i++)
                {
                    // The offset of the array of structures is 8 bytes past the beginning. Then, take the index and multiply it by the number of bytes in the structure.
                    IntPtr pItemList = new IntPtr(pList.ToInt32() + (i * ifListItemSize) + iByteCount);

                    WLAN_INTERFACE_INFO wii = new WLAN_INTERFACE_INFO();
                    wii = (WLAN_INTERFACE_INFO)Marshal.PtrToStructure(pItemList, typeof(WLAN_INTERFACE_INFO));
                    InterfaceInfo[i] = wii;
                }
            }
        }
        #endregion

        #region Win32
        [DllImport("Wlanapi.dll")]
        private static extern int WlanOpenHandle(
           int dwClientVersion,
           IntPtr pReserved,
           out IntPtr pdwNegotiatedVersion,
           out IntPtr phClientHandle);

        [DllImport("Wlanapi.dll")]
        private static extern int WlanEnumInterfaces(
            IntPtr hClientHandle,
            IntPtr pReserved,
            out IntPtr ppInterfaceList
            );
        [DllImport("Wlanapi.dll")]
        public static extern void WlanFreeMemory(IntPtr pMemory);

        [DllImport("Wlanapi.dll")]
        public static extern uint WlanCloseHandle(
            IntPtr hClientHandle,
            IntPtr pReserved);
        #endregion

        #region AvailableNetworkList

        public const uint WLAN_AVAILABLE_NETWORK_INCLUDE_ALL_ADHOC_PROFILES = 0x00000001;
        public const uint WLAN_AVAILABLE_NETWORK_INCLUDE_ALL_MANUAL_HIDDEN_PROFILES = 0x00000002;

        public const uint ERROR_SUCCESS = 0;

        [DllImport("Wlanapi.dll")]
        public static extern uint WlanGetAvailableNetworkList(
            IntPtr hClientHandle,
            [MarshalAs(UnmanagedType.LPStruct)] Guid pInterfaceGuid,
            uint dwFlags,
            IntPtr pReserved,
            out IntPtr ppAvailableNetworkList);

        [StructLayout(LayoutKind.Sequential)]
        public struct WLAN_AVAILABLE_NETWORK_LIST
        {
            public uint dwNumberOfItems;
            public uint dwIndex;
            public WLAN_AVAILABLE_NETWORK[] Network;

            public WLAN_AVAILABLE_NETWORK_LIST(IntPtr ppAvailableNetworkList)
            {
                dwNumberOfItems = (uint)Marshal.ReadInt32(ppAvailableNetworkList, 0);
                dwIndex = (uint)Marshal.ReadInt32(ppAvailableNetworkList, 4 /* Offset for dwNumberOfItems */);
                Network = new WLAN_AVAILABLE_NETWORK[dwNumberOfItems];

                for (int i = 0; i < dwNumberOfItems; i++)
                {
                    var availableNetwork = new IntPtr(ppAvailableNetworkList.ToInt64()
                        + 8 /* Offset for dwNumberOfItems and dwIndex */
                        + (Marshal.SizeOf(typeof(WLAN_AVAILABLE_NETWORK)) * i) /* Offset for preceding items */);

                    Network[i] = Marshal.PtrToStructure<WLAN_AVAILABLE_NETWORK>(availableNetwork);
                }
            }
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct WLAN_AVAILABLE_NETWORK
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string strProfileName;

            public DOT11_SSID dot11Ssid;
            public DOT11_BSS_TYPE dot11BssType;
            public uint uNumberOfBssids;
            public bool bNetworkConnectable;
            public uint wlanNotConnectableReason;
            public uint uNumberOfPhyTypes;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public DOT11_PHY_TYPE[] dot11PhyTypes;

            public bool bMorePhyTypes;
            public uint wlanSignalQuality;
            public bool bSecurityEnabled;
            public DOT11_AUTH_ALGORITHM dot11DefaultAuthAlgorithm;
            public DOT11_CIPHER_ALGORITHM dot11DefaultCipherAlgorithm;
            public uint dwFlags;
            public uint dwReserved;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DOT11_SSID
        {
            public uint uSSIDLength;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public byte[] ucSSID;

            public byte[] ToBytes() => ucSSID?.Take((int)uSSIDLength).ToArray();

            private static Encoding _encoding =
                Encoding.GetEncoding(65001, // UTF-8 code page
                    EncoderFallback.ReplacementFallback,
                    DecoderFallback.ExceptionFallback);

            public override string ToString()
            {
                if (ucSSID == null)
                    return null;

                try
                {
                    return _encoding.GetString(ToBytes());
                }
                catch (DecoderFallbackException)
                {
                    return null;
                }
            }
        }

        public enum DOT11_BSS_TYPE
        {
            /// Infrastructure BSS network
            dot11_BSS_type_infrastructure = 1,

            /// Independent BSS (IBSS) network
            dot11_BSS_type_independent = 2,

            /// Either infrastructure or IBSS network
            dot11_BSS_type_any = 3,
        }

        public enum DOT11_PHY_TYPE : uint
        {
            dot11_phy_type_unknown = 0,
            dot11_phy_type_any = 0,
            dot11_phy_type_fhss = 1,
            dot11_phy_type_dsss = 2,
            dot11_phy_type_irbaseband = 3,
            dot11_phy_type_ofdm = 4,
            dot11_phy_type_hrdsss = 5,
            dot11_phy_type_erp = 6,
            dot11_phy_type_ht = 7,
            dot11_phy_type_vht = 8,
            dot11_phy_type_IHV_start = 0x80000000,
            dot11_phy_type_IHV_end = 0xffffffff
        }

        public enum DOT11_AUTH_ALGORITHM : uint
        {
            DOT11_AUTH_ALGO_80211_OPEN = 1,
            DOT11_AUTH_ALGO_80211_SHARED_KEY = 2,
            DOT11_AUTH_ALGO_WPA = 3,
            DOT11_AUTH_ALGO_WPA_PSK = 4,
            DOT11_AUTH_ALGO_WPA_NONE = 5,
            DOT11_AUTH_ALGO_RSNA = 6,
            DOT11_AUTH_ALGO_RSNA_PSK = 7,
            DOT11_AUTH_ALGO_IHV_START = 0x80000000,
            DOT11_AUTH_ALGO_IHV_END = 0xffffffff
        }

        public enum DOT11_CIPHER_ALGORITHM : uint
        {
            DOT11_CIPHER_ALGO_NONE = 0x00,
            DOT11_CIPHER_ALGO_WEP40 = 0x01,
            DOT11_CIPHER_ALGO_TKIP = 0x02,
            DOT11_CIPHER_ALGO_CCMP = 0x04,
            DOT11_CIPHER_ALGO_WEP104 = 0x05,
            DOT11_CIPHER_ALGO_WPA_USE_GROUP = 0x100,
            DOT11_CIPHER_ALGO_RSN_USE_GROUP = 0x100,
            DOT11_CIPHER_ALGO_WEP = 0x101,
            DOT11_CIPHER_ALGO_IHV_START = 0x80000000,
            DOT11_CIPHER_ALGO_IHV_END = 0xffffffff
        }

        #endregion

        public IList<WLANInterface> GetWlanInterfacesInfo()
        {
            IntPtr pdwNegotiatedVersion = IntPtr.Zero;
            IntPtr phClientHandle = IntPtr.Zero;
            IntPtr ppInterfaceList = IntPtr.Zero;
            IntPtr availableNetworkList = IntPtr.Zero;
            var wlanInterfaceCollection = new List<WLANInterface>();

            try
            {
                WlanOpenHandle(2, IntPtr.Zero, out pdwNegotiatedVersion, out phClientHandle);

                WlanEnumInterfaces(phClientHandle, IntPtr.Zero, out ppInterfaceList);

                WLAN_INTERFACE_INFO_LIST interfaceInfoList = new WLAN_INTERFACE_INFO_LIST(ppInterfaceList);

                foreach (var interfaceInfo in interfaceInfoList.InterfaceInfo)
                {
                    if (WlanGetAvailableNetworkList(
                        phClientHandle,
                        interfaceInfo.InterfaceGuid,
                        WLAN_AVAILABLE_NETWORK_INCLUDE_ALL_MANUAL_HIDDEN_PROFILES,
                        IntPtr.Zero,
                        out availableNetworkList) != ERROR_SUCCESS)
                        continue;

                    var wlanNetworks = new List<WLANNetwork>();
                    var networkList = new WLAN_AVAILABLE_NETWORK_LIST(availableNetworkList);

                    foreach (var network in networkList.Network)
                    {
                        var wlanNetwork = new WLANNetwork
                        {
                            SSID = network.dot11Ssid.ToString(),
                            BSSNetworkType = network.dot11BssType.ToString(),
                            BSSIDsNo = network.uNumberOfBssids.ToString(),
                            Connectable = network.bNetworkConnectable,
                            SignalQuality = network.wlanSignalQuality.ToString(),
                            isSecurityEnabled = network.bSecurityEnabled,
                            AuthAlgorithm = network.dot11DefaultAuthAlgorithm.ToString(),
                            CipherAlgorithm = network.dot11DefaultCipherAlgorithm.ToString(),
                            //Flags = network.dwFlags && WLAN_AVAILABLE_NETWORK_CONNECTED ? "Currently connected" : " Has profile"
                        };

                        wlanNetworks.Add(wlanNetwork);
                    }

                    var wlanInterface = new WLANInterface
                    {
                        Index = 0,
                        GUID = interfaceInfo.InterfaceGuid,
                        Description = interfaceInfo.strInterfaceDescription,
                        State = interfaceInfo.isState.ToString(),
                        AvailableNetworks = wlanNetworks
                    };

                    wlanInterfaceCollection.Add(wlanInterface);
                }
            }
            finally
            {
                if (ppInterfaceList != IntPtr.Zero)
                    WlanFreeMemory(ppInterfaceList);

                if (phClientHandle != IntPtr.Zero)
                    WlanCloseHandle(phClientHandle, IntPtr.Zero);

                if (availableNetworkList != IntPtr.Zero)
                    WlanFreeMemory(availableNetworkList);
            }

            return wlanInterfaceCollection;
        }

    }
}
