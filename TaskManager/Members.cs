using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    class Member
    {
        public string Name;
        public PerfomType Type;
        public enum PerfomType
        {
            Заказчик = 1,
            Тимлид,
            Исполнитель
        }
        public Member(string name)
        {
            Name = name;
        }
    }
}
