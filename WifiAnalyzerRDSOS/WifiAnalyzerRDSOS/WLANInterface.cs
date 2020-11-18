using System;
using System.Collections.Generic;

namespace WifiAnalyzerRDSOS
{
    class WLANInterface
    {
        public int Index { get; set; }
        public Guid GUID { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
        public List<WLANNetwork> AvailableNetworks { get; set; }

        public WLANInterface()
        {

        }
        public WLANInterface(int index, Guid guid, string description, string state)
        {
            Index = index;
            GUID = guid;
            Description = description;
            State = state;
        }

    }
}
