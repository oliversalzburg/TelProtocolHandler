using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using log4net;
using log4net.Config;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]
namespace TelProtocolHandler {
    internal class Program {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [STAThread]
        private static void Main (string[] args) {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            log.Info("==============================");
            log.Info("      Starting new call.      ");
            log.Info("==============================");
            CallEventHandler.CreateCall(args);
        }
    }
}