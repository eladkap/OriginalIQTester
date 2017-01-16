using System;
using System.Collections.Generic;

namespace Utilities
{
    public class Logger
    {
        public event EventHandler<LogEventArgs> LogArrived;

        private List<string> _eventsList;
        private bool _isNewLine;

        public Logger()
        {
            _eventsList = new List<string>();
            _isNewLine = true;
        }

        public int Count { get { return _eventsList.Count; } }

        public void Write(string msg)
        {
            WriteLine(msg);
            /*
            string newMsg;
            if (_isNewLine || IsEmpty())
            {
                _eventsList.Add(msg);
                newMsg = msg;
            }
            else
            {
                _eventsList[_eventsList.Count - 1] += msg;
                newMsg = _eventsList[_eventsList.Count - 1];
            }
            LogEventArgs data = new LogEventArgs(msg);
            OnLogArrived(data);
            _isNewLine = false;
            */
        }

        public void WriteLine(string msg)
        {
            string newMsg;
            if (_isNewLine || IsEmpty())
            {
                _eventsList.Add(msg);
                newMsg = msg;
            }
            else
            {
                _eventsList[_eventsList.Count - 1] += msg;
                newMsg = _eventsList[_eventsList.Count - 1];
            }
            LogEventArgs data = new LogEventArgs(msg);
            OnLogArrived(data);
            _isNewLine = true;
        }

        public void ClearLogger()
        {
            _eventsList.Clear();
        }

        public string GetMessage(int index)
        {
            return _eventsList[index];
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }

        public string GetLastMessage()
        {
            return _eventsList[_eventsList.Count - 1];
        }

        protected virtual void OnLogArrived(LogEventArgs e)
        {
            LogArrived?.Invoke(this, e);
        }
    }
}
