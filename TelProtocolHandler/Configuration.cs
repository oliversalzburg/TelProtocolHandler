using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace TelProtocolHandler {
    public static class Configuration {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType );

        private static ConfigContainer _container;

        public static ConfigContainer Container {
            get {
                if( null == _container ) {
                    _container = new ConfigContainer();
                }
                return _container;
            }
            set { _container = value; }
        }

        public static void Load() {
            XmlSerializer xmlSerializer = new XmlSerializer( typeof( ConfigContainer ) );
            try {
                string configFilename = Path.Combine( AppDomain.CurrentDomain.BaseDirectory, "Config.xml" );
                using( FileStream stream = File.OpenRead( configFilename ) ) {
                    Container = (ConfigContainer)xmlSerializer.Deserialize( stream );
                }
            } catch( FileNotFoundException ) {
                log.Warn( "Configuration file not found. Using standard settings." );
            } catch( InvalidOperationException ) {
                log.Warn( "Could not read configuration file. Using standard settings. (check XML format?)" );
            }
        }

        public static void Save() {
            XmlSerializer xSerializer = new XmlSerializer( typeof( ConfigContainer ) );
            try {
                string configFilename = Path.Combine( AppDomain.CurrentDomain.BaseDirectory, "Config.xml" );
                using( XmlWriter writer = XmlWriter.Create( configFilename ) ) {
                    xSerializer.Serialize( writer, Container );
                }
            } catch( UnauthorizedAccessException ) {
                log.Error( "Could not write file 'Config.xml'. Settings will not be saved." );
                MessageBox.Show( "Could not write file 'Config.xml'. Settings will not be saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }

        public class ConfigContainer {
            public string LineToUse;

            public ConfigContainer() {
                LineToUse = string.Empty;
            }
        }
    }
}