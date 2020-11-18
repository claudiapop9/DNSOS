using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WifiAnalyzerRDSOS
{
    public partial class MainForm : Form
    {
        private IList<WLANInterface> interfaces;
        public MainForm()
        {
            interfaces = GetWLANInterfaces();
            InitializeComponent();
            PopulateInterfaceIndex();
        }

        private void interfaceGUIDlabel_Click(object sender, EventArgs e)
        {

        }

        private IList<WLANInterface> GetWLANInterfaces() {
            Service service = new Service();
            return service.GetWlanInterfacesInfo();
        }
                
        private void PopulateInterfaceIndex(){
            foreach (var item in interfaces)
            {
                interfacesComboBox.Items.Add(item.Index);
            }            
        }

        private void interfacesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var currentInterface = interfaces[interfacesComboBox.SelectedIndex];
            InterfaceGuidTextBox.Text = currentInterface.GUID.ToString();
            interfaceStatusTextBox.Text = currentInterface.State;
            interfaceDescriptionTextBox.Text = currentInterface.Description;
            availableNetworkEntriesTextBox.Text = currentInterface.AvailableNetworks.Count.ToString();
            PopulateAvailableNetworks(currentInterface);
        }

        private void PopulateAvailableNetworks(WLANInterface wlanInterface) {
            foreach (var availableItem in wlanInterface.AvailableNetworks) {
                networksComboBox.Items.Add(availableItem.SSID);
            }
        }

        private void networksComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            availableNetworksDataGridView.ColumnCount = 2;
            availableNetworksDataGridView.Columns[0].Name = "Name";
            availableNetworksDataGridView.Columns[1].Name = "Value";
            availableNetworksDataGridView.Columns[1].Width = 215;
            
            var currentInterface = interfaces[interfacesComboBox.SelectedIndex];
            var currentNetwork = currentInterface.AvailableNetworks[networksComboBox.SelectedIndex];

            availableNetworksDataGridView.Rows.Add("SSID:", currentNetwork.SSID);
            availableNetworksDataGridView.Rows.Add("BSSNetworkType:", currentNetwork.BSSNetworkType);
            availableNetworksDataGridView.Rows.Add("BSSIDsNo:", currentNetwork.BSSIDsNo);
            availableNetworksDataGridView.Rows.Add("Connectable:", currentNetwork.Connectable);
            availableNetworksDataGridView.Rows.Add("SignalQuality:", currentNetwork.SignalQuality);
            availableNetworksDataGridView.Rows.Add("isSecurityEnabled:", currentNetwork.isSecurityEnabled);
            availableNetworksDataGridView.Rows.Add("AuthAlgorithm:", currentNetwork.AuthAlgorithm);
            availableNetworksDataGridView.Rows.Add("CipherAlgorithm:", currentNetwork.CipherAlgorithm);
            availableNetworksDataGridView.Rows.Add("Flags:", currentNetwork.Flags);
        }

        private void availableNetworksListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void goToSnifferButton_Click(object sender, EventArgs e)
        {
            if (interfacesComboBox.SelectedIndex >= 0 && interfacesComboBox.SelectedIndex < interfacesComboBox.Items.Count)
            {
                SnifferForm openSnifferForm = new SnifferForm();
                this.Hide();
                openSnifferForm.Show();
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
