using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace TelProtocolHandler {
    internal class Program {

        [STAThread]
        private static void Main (string[] args) {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            CallEventHandler.CreateCall(args);
        }
    }
}