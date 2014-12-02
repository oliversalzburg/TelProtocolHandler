using JulMar.Tapi3;
using System;
using System.Linq;
using System.Windows.Forms;

namespace TelProtocolHandler {
    public static class CallEventHandler {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType );

        public static void CreateCall( string[] args ) {
            if( args.Length < 1 ) {
                AppSetup(); // Add registry entry and start setup if application starts without arguments
            } else {
                string phoneNumber = CallEventHandler.NumberToCall( args ); // Phone number to call
                Configuration.Load(); // Loads configuration file
                InitializeTAPI(); // Initialize TAPI
                CheckForTAPILineErrors(); // Checks for line errors
                InitiateCall( phoneNumber ); // Initiates call
            }
        }

        private static void AppSetup() {
            log.Info( "Application runs without arguments. Starting setup..." );

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            process.StartInfo.FileName = "TelProtocolHandlerSetup.exe";
            process.StartInfo.Verb = "runas";
            process.Start();

            log.Info( "Registry has been set up." );
            Application.Run( new SelectTAPIForm() );
            log.Info( "Standard line has been set up. TelProtocolHandler is ready to use." );
            MessageBox.Show( "TelProtocolHandler is now ready to use.", "TelProtocolHandler", MessageBoxButtons.OK, MessageBoxIcon.Information );
        }

        private static string NumberToCall( string[] args ) {
            string Protocol = "tel:";
            string phoneNumber = "";

            if( args.Length < 1 ) {
                log.Error( "No arguments given." );
                if( MessageBox.Show( "No arguments given.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error ) == DialogResult.OK ) {
                    Environment.Exit( 0 );
                }
            } else {
                phoneNumber = args[ 0 ];
                if( !phoneNumber.StartsWith( Protocol ) ) {
                    log.Error( String.Format( "Unexpected input. Expected argument to start with '{0}'.", Protocol ) );
                    if( MessageBox.Show( String.Format( "Unexpected input. Expected argument to start with '{0}'", Protocol ), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error ) == DialogResult.OK ) {
                        Environment.Exit( 0 );
                    }
                }

                phoneNumber = phoneNumber.Substring( Protocol.Length );
                // Replace + prefix with a 00
                if( phoneNumber.StartsWith( "+" ) ) {
                    phoneNumber = "00" + phoneNumber.Substring( 1 );
                }
            }

            return phoneNumber;
        }

        private static TTapi tapi = new TTapi();

        private static void InitializeTAPI() {
            tapi.Initialize();
        }

        private static void CheckForTAPILineErrors() {
            if( string.IsNullOrEmpty( Configuration.Container.lineToUse ) ) {
                log.Info( "No line configuration value set. Starting settings application..." );
                CallTAPILineConfiguration();
                return;
            }

            string lineToUse = Configuration.Container.lineToUse;

            if( string.IsNullOrEmpty( lineToUse ) ) {
                log.Error( "No TAPI line selected!" );
                if( MessageBox.Show( "No TAPI line selected!\nDo you wish to select a new TAPI line?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error ) == DialogResult.Yes ) {
                    CallTAPILineConfiguration();
                } else {
                    Environment.Exit( 0 );
                }
                return;
            }

            TAddress line = tapi.Addresses.SingleOrDefault( a => a.AddressName == lineToUse );
            if( null == line ) {
                log.Error( String.Format( "Unable to find TAPI line with name '{0}'!", lineToUse ) );
                if( MessageBox.Show(
                    String.Format( "Unable to find TAPI line with name '{0}'!\nDo you wish to select another TAPI line?", lineToUse ), "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error )
                    == DialogResult.Yes ) {
                    CallTAPILineConfiguration();
                    return;
                } else {
                    Environment.Exit( 0 );
                }
            }
        }

        private static void CallTAPILineConfiguration() {
            Application.Run( new SelectTAPIForm() );
            CheckForTAPILineErrors();
        }

        private static void InitiateCall( string phoneNumber ) {
            string lineToUse = Configuration.Container.lineToUse;
            log.Info( String.Format( "Creating call via line '{0}'.", lineToUse ) );
            TAddress line = tapi.Addresses.SingleOrDefault( a => a.AddressName == lineToUse );

            // Always assumes 0 prefix is needed to dial out.
            TCall call = line.CreateCall( "0" + phoneNumber, LINEADDRESSTYPES.PhoneNumber, TAPIMEDIATYPES.AUDIO );
            try {
                call.Connect( false );
            } catch( TapiException ex ) {
                log.Error( "TapiException: ", ex );
                return;
            }

            log.Info( String.Format( "Calling '{0}'...", phoneNumber ) );
        }
    }
}