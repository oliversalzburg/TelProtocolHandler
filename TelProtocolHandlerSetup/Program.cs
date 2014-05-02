using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelProtocolHandlerSetup {
    class Program {
        static void Main (string[] args) {
            string registryKey = @"HKEY_CLASSES_ROOT\tel";
            string registryValue = "TEL:Telephone Invocation";
            Microsoft.Win32.Registry.SetValue(registryKey, string.Empty, registryValue, Microsoft.Win32.RegistryValueKind.String);
            Microsoft.Win32.Registry.SetValue(registryKey, "URL Protocol", String.Empty, Microsoft.Win32.RegistryValueKind.String);

            registryKey = @"HKEY_CLASSES_ROOT\tel\shell\open\command";
            registryValue = "\"" + AppDomain.CurrentDomain.BaseDirectory + "TelProtocolHandler.exe\" \"%1\"";
            Microsoft.Win32.Registry.SetValue(registryKey, string.Empty, registryValue, Microsoft.Win32.RegistryValueKind.String);
        }
    }
}
