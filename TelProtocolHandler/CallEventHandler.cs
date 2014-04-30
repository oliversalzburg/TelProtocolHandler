using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using JulMar.Tapi3;

namespace TelProtocolHandler {
    public static class CallEventHandler {

        public static void CreateCall (string[] args) {
            string phoneNumber = CallEventHandler.NumberToCall(args);   // Phone number to call
            Configuration.Load();                                       // Loads configuration file
            InitializeTAPI();                                           // Initialize TAPI
            CheckForTAPILineErrors();                                   // Checks for line errors
            InitiateCall(phoneNumber);                                  // Initiates call
        }

        public static string NumberToCall (string[] args) {
            string Protocol = "tel:";
            string phoneNumber = "";

            if (args.Length < 1) {
                Debug.WriteLine("No arguments given.");
                if (MessageBox.Show("No arguments given.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK) {
                    Environment.Exit(0);
                }
            }
            else {
                phoneNumber = args[0];
                if (!phoneNumber.StartsWith(Protocol)) {
                    Debug.WriteLine(String.Format("Unexpected input. Expected argument to start with '{0}'.", Protocol));
                    if (MessageBox.Show(String.Format("Unexpected input. Expected argumet to start with '{0}'", Protocol), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK) {
                        Environment.Exit(0);
                    }    
                }

                phoneNumber = phoneNumber.Substring(Protocol.Length);
                // Replace + prefix with a 00
                if (phoneNumber.StartsWith("+")) {
                    phoneNumber = "00" + phoneNumber.Substring(1);
                }
            }

            return phoneNumber;
        }

        private static TTapi tapi = new TTapi();
        private static void InitializeTAPI () {
            tapi.Initialize();
        }

        private static void CheckForTAPILineErrors () {
            if (string.IsNullOrEmpty(Configuration.Container.lineToUse)) {
                Debug.WriteLine("No line configuration value set. Starting settings application...");
                CallTAPILineConfiguration();
                return;
            }

            string lineToUse = Configuration.Container.lineToUse;

            if (string.IsNullOrEmpty(lineToUse)) {
                Debug.WriteLine("No TAPI line selected!");
                if (MessageBox.Show("No TAPI line selected!\nDo you wish to select a new TAPI line?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes) {
                    CallTAPILineConfiguration();
                }
                else {
                    Environment.Exit(0);
                }
                return;
            }

            TAddress line = tapi.Addresses.SingleOrDefault(a => a.AddressName == lineToUse);
            if (null == line) {
                Debug.WriteLine(String.Format("Unable to find TAPI line with name '{0}'!", lineToUse));
                if (MessageBox.Show(String.Format("Unable to find TAPI line with name '{0}'!\nDo you wish to select another TAPI line?", lineToUse), "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes) {
                    CallTAPILineConfiguration();
                    return;
                }
                else {
                    Environment.Exit(0);
                }
            }
        }

        private static void CallTAPILineConfiguration () {
            Application.Run(new SelectTAPIForm());
            CheckForTAPILineErrors();
        }

        private static void InitiateCall (string phoneNumber) {
            string lineToUse = Configuration.Container.lineToUse;
            Debug.WriteLine(String.Format("Creating call via line '{0}'.", lineToUse));
            TAddress line = tapi.Addresses.SingleOrDefault(a => a.AddressName == lineToUse);

            // Always assumes 0 prefix is needed to dial out.
            TCall call = line.CreateCall("0" + phoneNumber, LINEADDRESSTYPES.PhoneNumber, TAPIMEDIATYPES.AUDIO);
            try {
                call.Connect(false);
            }
            catch (TapiException ex) {
                Debug.WriteLine(ex.Message);
                return;
            }

            Debug.WriteLine(String.Format("Calling '{0}'...", phoneNumber));
        }
    }
}
