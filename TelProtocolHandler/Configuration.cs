using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;

namespace TelProtocolHandler {
    public static class Configuration {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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
            catch (FileNotFoundException) {
                log.Info("Configuration file not found. Using standard settings.");
            }
            catch (InvalidOperationException) {
                log.Info("Could not read configuration file. Using standard settings. (check XML format?)");
            }
        }

        public static void Save () {
            XmlSerializer xSerializer = new XmlSerializer(typeof(ConfigContainer));
            try {
                using (XmlWriter writer = XmlWriter.Create(@"Config.xml")) {
                    xSerializer.Serialize(writer, Container);
                }
            }
            catch (UnauthorizedAccessException) {
                log.Info("Could not write file 'Config.xml'. Settings will not be saved.");
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
