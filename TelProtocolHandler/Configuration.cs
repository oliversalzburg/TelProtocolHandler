using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace TelProtocolHandler {
    public static class Configuration {

        static ConfigContainer _container;
        public static ConfigContainer Container {
            get {
                if (null == _container) _container = new ConfigContainer();
                return _container;
            }
            set {
                _container = value;
            }
        }

        public static void Load () {
            XmlSerializer xSerializer = new XmlSerializer(typeof(ConfigContainer));
            try {
                using (FileStream stream = File.OpenRead(@"Config.xml")) {
                    Container = (ConfigContainer)xSerializer.Deserialize(stream);
                }
            }
            catch (FileNotFoundException e) {
                Debug.WriteLine("Configuration file not found.");
            }
            catch (InvalidOperationException e) {
                Debug.WriteLine("Could not read configuration file. (check XML format?)");
            }
        }

        public static void Save () {
            XmlSerializer xSerializer = new XmlSerializer(typeof(ConfigContainer));
            try {
                using (XmlWriter writer = XmlWriter.Create(@"Config.xml")) {
                    xSerializer.Serialize(writer, Container);
                }
            }
            catch (UnauthorizedAccessException e) {
                Debug.WriteLine("Could not write file 'Config.xml'.");
                if (MessageBox.Show("Could not write file 'Config.xml'. Settings will not be saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK) { }
                return;
            }
        }

        public class ConfigContainer {
            public string lineToUse;

            public ConfigContainer () {
                lineToUse = "";
            }
        }
    }
}
