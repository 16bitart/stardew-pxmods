using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StardewModdingAPI;

namespace PxMod.Utilities
{
    public class StardewLogger
    {
        private Action<string, LogLevel> OnLog;

        public StardewLogger(Action<string, LogLevel> onLog)
        {
            OnLog = onLog;
        }
        public void Log(string message, LogLevel logLevel = LogLevel.Info)
        {
            OnLog?.Invoke(message, logLevel);
        }
    }
}
