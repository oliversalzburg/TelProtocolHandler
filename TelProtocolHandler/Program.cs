using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using JulMar.Tapi3;

namespace TelProtocolHandler {
  internal class Program {
    [System.Runtime.InteropServices.DllImport("user32.dll")]
    static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    private static string Protocol = "tel:";

    private static void Main( string[] args ) {
      if( args.Length < 1 ) {
        Console.WriteLine( "No arguments given." );
      } else {
        string phoneNumberInput = args[ 0 ];

        if( !phoneNumberInput.StartsWith( Protocol ) ) {
          Console.WriteLine( string.Format( "Unexpected input. Expected argument to start with '{0}'.", Protocol ) );
          return;
        }

        var currentProcess = System.Diagnostics.Process.GetCurrentProcess();
        Console.WriteLine(currentProcess.MainWindowTitle);

        IntPtr hWnd = currentProcess.MainWindowHandle;
        if( !Debugger.IsAttached && hWnd != IntPtr.Zero ) {
          //Hide the window
          ShowWindow( hWnd, 0 ); // 0 = SW_HIDE
        }

        string phoneNumber = phoneNumberInput.Substring( Protocol.Length );

        // TODO: Replace with configuration value
        string lineToFind = "Aastra";
        string lineToUse = null;

        TTapi tapi = new TTapi();
        if( !string.IsNullOrEmpty( lineToFind ) ) {
          int foundDevices = tapi.Initialize();
          Console.WriteLine( "{0} devices found", foundDevices );
          foreach( TAddress addr in tapi.Addresses ) {
            Console.WriteLine( addr.AddressName );
            if( -1 < addr.AddressName.IndexOf( lineToFind ) ) {
              lineToUse = addr.AddressName;
            }
          }
        }

        if( string.IsNullOrEmpty( lineToUse ) ) {
          Console.WriteLine( "Unable to find suitable TAPI line!" );
          return;
        }

        // Replace + prefix with a 00
        if( phoneNumber.StartsWith( "+" ) ) {
          phoneNumber = "00" + phoneNumber.Substring( 1 );
        }

        TAddress line = tapi.Addresses.SingleOrDefault(a => a.AddressName == lineToUse);
        if( null == line ) {
          Console.WriteLine( "Unable to find TAPI line with name '{0}'!", lineToUse );
          return;
        }

        // Always assumes 0 prefix is needed to dial out.
        TCall call = line.CreateCall( "0" + phoneNumber, LINEADDRESSTYPES.PhoneNumber, TAPIMEDIATYPES.AUDIO );
        call.Connect( false );

        Console.WriteLine( "Calling '{0}'...", phoneNumber );
      }
    }
  }
}