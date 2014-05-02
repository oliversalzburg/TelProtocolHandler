using System;
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
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public SelectTAPIForm () {
            InitializeComponent();
            TTapi tapi = new TTapi();

            int foundDevices = tapi.Initialize();
            log.Info("Searching for TAPI devices...");
            log.Info(String.Format("{0} devices found", foundDevices));
            foreach (TAddress addr in tapi.Addresses) {
                log.Info(String.Format("\t{0}", addr.AddressName));
                comboBox1.Items.Add(addr.AddressName);
            }
        }

        private void Form1_Load (object sender, EventArgs e) {

        } 

        private void button1_Click (object sender, EventArgs e) {
            try {
                Configuration.Container.lineToUse = comboBox1.SelectedItem.ToString();
                Configuration.Save();

                this.Close();
            }
            catch { }
        }
    }
}