using Microsoft.Win32;
using System;

namespace TelProtocolHandlerSetup {
    static class Program {
        static void Main( string[] args ) {
            const string protocolValue = "TEL:Telephone Invocation";
            Registry.SetValue( @"HKEY_CLASSES_ROOT\tel", string.Empty, protocolValue, RegistryValueKind.String );
            Registry.SetValue( @"HKEY_CLASSES_ROOT\tel", "URL Protocol", String.Empty, RegistryValueKind.String );

            string binaryName = AppDomain.CurrentDomain.FriendlyName;
            string command = string.Format( "\"{0}{1}\" \"%1\"", AppDomain.CurrentDomain.BaseDirectory, binaryName );
            Registry.SetValue( @"HKEY_CLASSES_ROOT\tel\shell\open\command", string.Empty, command, RegistryValueKind.String );
        }
    }
}
