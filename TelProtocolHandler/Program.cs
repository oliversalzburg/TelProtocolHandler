using System;
using System.Threading;

namespace TelProtocolHandler {
  internal class Program {
    private static void Main( string[] args ) {
      if( args.Length < 1 ) {
        Console.WriteLine( "No arguments given." );
      } else {
        Console.WriteLine( "Calling '{0}'...", args[ 0 ] );
      }

      Thread.Sleep( TimeSpan.FromSeconds( 5.0 ) );
    }
  }
}