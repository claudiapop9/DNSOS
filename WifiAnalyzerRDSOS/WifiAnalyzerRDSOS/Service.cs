using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace WifiAnalyzerRDSOS
{
    class Service
    {
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

        public IList<WLANInterface> GetWlanInterfacesInfo() {

            IntPtr pdwNegotiatedVersion = IntPtr.Zero;
            IntPtr phClientHandle = IntPtr.Zero;
            int iSucces = WlanOpenHandle(2, IntPtr.Zero, out pdwNegotiatedVersion, out phClientHandle);

            IntPtr ppInterfaceList = IntPtr.Zero;
            iSucces = WlanEnumInterfaces(phClientHandle, IntPtr.Zero, out ppInterfaceList);

            WLAN_INTERFACE_INFO_LIST infoList = new WLAN_INTERFACE_INFO_LIST(ppInterfaceList);
            var wlanInterfaceCollection = new List<WLANInterface>();

            for (int i = 0; i < infoList.dwNumberOfItems; i++) {
                var wlanInterface = new WLANInterface
                {
                    Index = i,
                    GUID = infoList.InterfaceInfo[i].InterfaceGuid.ToString(),
                    Description = infoList.InterfaceInfo[i].strInterfaceDescription,
                    State = infoList.InterfaceInfo[i].isState.ToString()
                };
                wlanInterfaceCollection.Add(wlanInterface);
            }
            return wlanInterfaceCollection;
        }
    }
}
