using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    class Report
    {
        public string Text;
        public Member Performer;
        public Report(string text, Member performer)
        {
            Text = text;
            Performer = performer;
        }
        public override string ToString()
        {
            return $"{Text} by {Performer.Name}";
        }
    }
}
