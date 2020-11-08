using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var currentInterface = interfaces[0];
            InterfaceGuidTextBox.Text = currentInterface.GUID;
            interfaceStatusTextBox.Text = currentInterface.State;
            interfaceDescriptionTextBox.Text = currentInterface.Description;
        }
    }
}
