using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    class Task
    {
        public enum State
        {
            Назначена,
            Делегирование,
            Отклонение,
            В_работе,
            На_проверке,
            Выполнена,
        }
        public string Description;
        public Member Initiator;
        public Member Performer;
        public Stack<Report> Reports;
        public State Status;

        public Task(string description)
        {
            Description = description;
            Status = State.Назначена;
            Reports = new Stack<Report>();
        }
        public override string ToString()
        {
            return $"{Description}. {Performer.Name} : {Status}";
        }
    }
}
