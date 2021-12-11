using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            Member[] team =
            {
                new Member("Клава"),
                new Member("Дженни"),
                new Member("Джейкоб"),
                new Member("Боб"),
                new Member("Лео"),
                new Member("Мая"),
                new Member("Варя"),
                new Member("Сэм"),
                new Member("Лили"),
                new Member("Стив"),
                new Member("Джинни"),
                new Member("Мишель")
            };

            int taskNumber = 0;

            Console.Write("Введите количество задач: ");
            taskNumber = Convert.ToInt32(Console.ReadLine());
            Project project001 = new Project("001", new DateTime(), team[0], team[1], taskNumber);

            Console.Write("Ответственный назначает задачи");
            for (int i = 0, j = 2; i < project001.Tasks.Count; i++, j++)
            {
                project001.Tasks[i].Initiator = project001.Initiator;
                project001.Tasks[i].Performer = team[j];
                if (j == team.Length - 1)
                {
                    j = 2;
                }
                TimerTick(200);
                Console.Write(".");
            }

            Console.WriteLine("\n" + project001.GetCurrentTasks());
            Console.WriteLine("Задачи распределены!");

            project001.Status++;

            int progress = 0;
            int speed = 1000;
            bool notDeleted = true;
            while (progress < project001.Tasks.Count)
            {
                Console.WriteLine("\nОбновление информации...");
                for (int i = 0; i < project001.Tasks.Count; i++)
                {
                    TimerTick(speed);

                    if (project001.Tasks[i].Status == Task.State.Назначена)
                    {
                        if (Randomizer(10))
                        {
                            if (Randomizer(50))
                            {
                                project001.Tasks[i].Status = Task.State.Делегирование;
                            }
                            else
                            {
                                project001.Tasks[i].Status = Task.State.Отклонение;
                            }
                        }
                        else
                        {
                            project001.Tasks[i].Status = Task.State.В_работе;
                        }
                    }
                    else if (project001.Tasks[i].Status == Task.State.В_работе)
                    {
                        if (Randomizer(50))
                        {
                            project001.Tasks[i].Reports.Push(new Report(project001.Tasks[i].Description + " ~отчёт~", project001.Tasks[i].Performer));
                            project001.Tasks[i].Status = Task.State.На_проверке;
                        }
                    }
                    else if (project001.Tasks[i].Status == Task.State.На_проверке)
                    {
                        if (Randomizer(50))
                        {
                            Console.WriteLine($"{project001.Tasks[i].Reports.Peek()} утверждён.");
                            project001.Tasks[i].Status = Task.State.Выполнена;
                            progress++;
                        }
                    }
                    else if (project001.Tasks[i].Status == Task.State.Делегирование)
                    {
                        project001.Tasks[i].Performer = team[rnd.Next(2, team.Length - 1)];
                        project001.Tasks[i].Status = Task.State.Назначена;
                    }
                    else if (project001.Tasks[i].Status == Task.State.Отклонение)
                    {
                        if (Randomizer(50))
                        {
                            project001.Tasks[i].Performer = team[rnd.Next(2, team.Length - 1)];
                            project001.Tasks[i].Status = Task.State.Назначена;
                        }
                        else
                        {
                            project001.Tasks.RemoveAt(i);
                            i--;
                            Console.WriteLine($"{project001.Tasks[i].Description}. (задача удалена)");
                            notDeleted = false;
                        }
                    }

                    if (notDeleted) Console.WriteLine(project001.Tasks[i]);
                    notDeleted = true;

                    TimerTick(speed);
                }
            }

            project001.Status++;

            Console.WriteLine($"\nВсе задачи выполнены.\nПроект {project001.Description} закрыт.");

            Console.ReadLine();
        }
        static void TimerTick(int mSeconds)
        {
            DateTime startPosition = DateTime.Now;
            while ((DateTime.Now - startPosition).TotalMilliseconds < mSeconds) { }
        }
        static bool Randomizer(int chance)
        {
            return (rnd.Next(0, 100 / chance) == 0) ? true : false;
        }
    }
}

