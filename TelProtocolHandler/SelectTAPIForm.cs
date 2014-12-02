using JulMar.Tapi3;
using System;
using System.Windows.Forms;

namespace TelProtocolHandler {
    public partial class SelectTAPIForm : Form {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType );

        /// <summary>
        /// Was the cancel button clicked?
        /// </summary>
        public bool WasCancelled { get; private set; }
        /// <summary>
        /// Which TAPI line was selected?
        /// </summary>
        public string LineToUse { get; private set; }

        public SelectTAPIForm( string lineToUse = "" ) {
            InitializeComponent();

            WasCancelled = false;
            LineToUse = lineToUse;

            log.Info( "Searching for TAPI devices…" );
            TTapi tapi = new TTapi();
            int foundDevices = tapi.Initialize();

            log.Info( String.Format( "{0} devices found", foundDevices ) );
            if( 0 == foundDevices ) {
                MessageBox.Show( "No available TAPI lines found.", "TAPI Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                Close();

            } else {
                foreach( TAddress addr in tapi.Addresses ) {
                    log.Info( String.Format( "\t{0}", addr.AddressName ) );
                    tapiSelectBox.Items.Add( addr.AddressName );
                    // If this is the previously selected line, select it in the UI as well.
                    if( addr.AddressName == lineToUse ) {
                        tapiSelectBox.SelectedItem = addr.AddressName;
                    }
                }
                // Select first item if nothing else is selected.
                if( tapiSelectBox.SelectedIndex < 0 ) {
                    tapiSelectBox.SelectedIndex = 0;
                }
            }
        }

        private void OkButtonClick( object sender, EventArgs e ) {
            Configuration.Container.LineToUse = tapiSelectBox.SelectedItem.ToString();
            Configuration.Save();

            LineToUse = tapiSelectBox.SelectedItem.ToString();
            Close();
        }

        private void CancelButtonClick( object sender, EventArgs e ) {
            WasCancelled = true;
            Close();
        }
    }
}