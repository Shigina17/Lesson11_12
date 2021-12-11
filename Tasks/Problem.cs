using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    public enum Sector
    {
        Системный_сектор = 1,
        Сектор_разработки_и_сопровождения = 2
    }
    class Problem
    {
        public Sector Sector;
        public Person Appointing;
        public Person Appointee;

        public Problem(Sector Sector, Person Appointing, Person Appointee)
        {
            this.Sector = Sector;
            this.Appointing = Appointing;
            this.Appointee = Appointee;
        }
        public override string ToString()
        {
            return $"{Sector}, {Appointing.Name} -> {Appointee.Name}";
        }
    }
}

