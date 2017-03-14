using System;
using Microsoft.Win32;

namespace TelProtocolHandlerSetup {
	internal static class Program {
		private static void Main( string[] args ) {
			// Register as the default handler for the tel: protocol.
			const string protocolValue = "TEL:Telephone Invocation";
			WriteString( @"HKEY_CLASSES_ROOT\tel", string.Empty, protocolValue );
			WriteString( @"HKEY_CLASSES_ROOT\tel", "URL Protocol", String.Empty );

			const string binaryName = "tel.exe";
			string command = $"\"{AppDomain.CurrentDomain.BaseDirectory}{binaryName}\" \"%1\"";
			WriteString( @"HKEY_CLASSES_ROOT\tel\shell\open\command", string.Empty, command );

			// For Windows 8+, register as a choosable protocol handler.

			// Version detection from http://stackoverflow.com/a/17796139/259953
			Version win8Version = new Version( 6, 2, 9200, 0 );
			if( Environment.OSVersion.Platform == PlatformID.Win32NT &&
			    Environment.OSVersion.Version >= win8Version ) {
				WriteString(
					@"HKEY_LOCAL_MACHINE\SOFTWARE\Classes\TelProtocolHandler",
					string.Empty,
					protocolValue );
				WriteString(
					@"HKEY_LOCAL_MACHINE\SOFTWARE\Classes\TelProtocolHandler\shell\open\command",
					string.Empty,
					command );

				WriteString(
					@"HKEY_LOCAL_MACHINE\SOFTWARE\TelProtocolHandler\Capabilities\URLAssociations",
					"tel",
					"TelProtocolHandler" );
				WriteString(
					@"HKEY_LOCAL_MACHINE\SOFTWARE\RegisteredApplications",
					"TelProtocolHandler",
					@"SOFTWARE\TelProtocolHandler\Capabilities" );
			}
		}

		private static void WriteString( string where, string name, string value ) {
			Console.WriteLine( "{0} → {1} = {2}", @where, name, value );
			Registry.SetValue( where, name, value, RegistryValueKind.String );
		}
	}
}