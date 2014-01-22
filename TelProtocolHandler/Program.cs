using System;
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
        if (hWnd != IntPtr.Zero) {
          //Hide the window
          ShowWindow(hWnd, 0); // 0 = SW_HIDE
        }

        string phoneNumber = phoneNumberInput.Substring( Protocol.Length );

        // TODO: Replace with configuration value
        const string lineToUse = "Obelix (Aastra5370/5370ip)";

        TTapi tapi = new TTapi();
        int foundDevices = tapi.Initialize();
        Console.WriteLine( "{0} devices found", foundDevices );
        foreach( TAddress addr in tapi.Addresses ) {
          Console.WriteLine( addr.AddressName );
        }

        TAddress line = tapi.Addresses.SingleOrDefault(a => a.AddressName == lineToUse);
        TCall call = line.CreateCall("0" + phoneNumber, LINEADDRESSTYPES.PhoneNumber, TAPIMEDIATYPES.AUDIO);
        call.Connect(false);

        Console.WriteLine( "Calling '{0}'...", phoneNumber );
      }
    }
  }
}