using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JulMar.Tapi3;

namespace TelProtocolHandler {
    public partial class SelectTAPIForm : Form {
        public SelectTAPIForm () {
            InitializeComponent();
            TTapi tapi = new TTapi();

            int foundDevices = tapi.Initialize();
            Debug.WriteLine("{0} devices found", foundDevices);
            foreach (TAddress addr in tapi.Addresses) {
                Debug.WriteLine(addr.AddressName);
                comboBox1.Items.Add(addr.AddressName);
            }
        }

        private void Form1_Load (object sender, EventArgs e) {

        } 

        private void button1_Click (object sender, EventArgs e) {
            try {
                XElement xmlFile = XElement.Load(@"Config.xml");
                xmlFile.Element("lineToUse").Value = comboBox1.SelectedItem.ToString();
                xmlFile.Save(@"Config.xml");

                this.Close();
            }
            catch { }
        }
    }
}