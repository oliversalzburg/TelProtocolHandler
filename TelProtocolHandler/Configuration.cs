using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

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
            using(FileStream stream = File.OpenRead(@"Config.xml")) {
                Container = (ConfigContainer)xSerializer.Deserialize(stream);
            }
            
        }

        public static void Save () {
            XmlSerializer xSerializer = new XmlSerializer(typeof(ConfigContainer));
            using(XmlWriter writer = XmlWriter.Create(@"Config.xml")) {
                    xSerializer.Serialize(writer, Container); 
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
