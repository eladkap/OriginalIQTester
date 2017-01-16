using System;

namespace Utilities
{
    public class LogEventArgs : EventArgs
    {
        public readonly string Message;

        internal LogEventArgs(string msg)
        {
            Message = msg;
        }
    }
}
