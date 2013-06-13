using System;
using System.Threading;

namespace TelProtocolHandler {
  internal class Program {
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

        string phoneNumber = phoneNumberInput.Substring( Protocol.Length );

        Console.WriteLine( "Calling '{0}'...", phoneNumber );
      }

      Thread.Sleep( TimeSpan.FromSeconds( 5.0 ) );
    }
  }
}