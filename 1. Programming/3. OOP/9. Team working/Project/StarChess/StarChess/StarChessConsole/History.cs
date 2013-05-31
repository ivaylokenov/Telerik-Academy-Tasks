using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StarChessConsole
{
    public class History
    {
        private List<string> history = new List<string>();

        public void Manage(string historyInput)
        {
            this.history.Add(historyInput);
            if (this.history.Count == 11)
            {
                this.history.RemoveAt(0);
            }
        }

        public void Clear()
        {
            this.history.Clear();
        }

        public int Count
        {
            get { return this.history.Count(); }
        }

        public string this[int index]
        {
            get { return this.history[index]; }
        }
    }
}
