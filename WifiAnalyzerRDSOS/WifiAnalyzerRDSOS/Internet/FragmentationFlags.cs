using System;

namespace WifiAnalyzerRDSOS.Internet
{
    [Flags]
    public enum FragmentationFlags : byte
    {
        DontFragment = 0x01,
        MoreFragments = 0x02
    }
}
