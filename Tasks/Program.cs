using System;
using System.Collections.Generic;
using System.Linq;

namespace Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Домашнее задание 8.2");
            List<Song> songs = new List<Song>(4);
            songs.Add(new Song("Macan", "Solo"));
            songs.Add(new Song("Roddy Ricch", "Uber", songs[0]));
            songs.Add(new Song("J.Cole", "No Role Modelz", songs[1]));
            songs.Add(new Song("Future feat. Drake", "Life Is Good", songs[2]));
            foreach (Song s in songs)
            {
                Console.WriteLine(s.Title());
            }
            if (songs[0].Equals(songs[1]))
            {
                Console.WriteLine("=");
            }
            Console.Read();


            Console.WriteLine("Задание про иерархию");
            Hierarchy company = new Hierarchy();

            company.AddLevel("Генеральный_директор", new Person[1] { new Person("Борис") });

            company.AddLevel("Директоры_отделов",
                company.Levels[company.Levels.Count - 1].CurrentPersons["Борис"],
                new Person("О Ильхам"),
                new Person("Рашид"),
                new Person("Лукас"));

            company.AddLevel("Отдел_информационных_технологий",
                company.Levels[company.Levels.Count - 1].CurrentPersons["О Ильхам"],
                new Person("Оркадий", new Person("Володя")));

            company.AddLevel(
                company.Levels[company.Levels.Count - 1].CurrentPersons["Оркадий"],
                new Person("Ильшат", "Системный_сектор"),
                new Person("Сергей", "Сектор_разработки_и_сопровождения"));

            company.AddLevel("Системный_сектор",
               company.Levels[company.Levels.Count - 1].CurrentPersons["Ильшат"],
               new Person("Иваныч"));

            company.AddLevel("Системный_сектор",
                company.Levels[company.Levels.Count - 1].CurrentPersons["Иваныч"],
                new Person("Илья"),
                new Person("Витя"),
                new Person("Женя"));

            company.AddPersons(company.Levels.Count - 2,
               company.Levels[company.Levels.Count - 3].CurrentPersons["Сергей"],
               new Person("Ляйсан", "Сектор_разработки_и_сопровождения"));

            company.AddPersons(company.Levels.Count - 1,
                company.Levels[company.Levels.Count - 2].CurrentPersons["Ляйсан"],
                new Person("Марат", "Сектор_разработки_и_сопровождения"),
                new Person("Дина", "Сектор_разработки_и_сопровождения"),
                new Person("Ильдар", "Сектор_разработки_и_сопровождения"),
                new Person("Антон", "Сектор_разработки_и_сопровождения"));

            List<Problem> problems = new List<Problem>();

            bool loop = true;
            while (loop)
            {
                Console.WriteLine("Введите признак (1 - системщики, 2 - разработчики, 0 - получить результат):");
                string tag_str = Console.ReadLine();
                if (tag_str == "0")
                {
                    loop = false;
                }
                else
                {
                    Console.WriteLine("Введите назначающего:");
                    string appointing = Console.ReadLine();
                    Console.WriteLine("Введите назначенца:");
                    string appointee = Console.ReadLine();
                    int tag;
                    if (int.TryParse(tag_str, out tag))
                    {
                        if (tag == 1 || tag == 2)
                        {
                            if (company.LevelOfPersons.Keys.Contains(appointing) && company.LevelOfPersons.Keys.Contains(appointee))
                            {
                                problems.Add(new Problem((Sector)tag,
                                    company.Levels[company.LevelOfPersons[appointing]].CurrentPersons[appointing],
                                    company.Levels[company.LevelOfPersons[appointee]].CurrentPersons[appointee]));
                                Console.WriteLine("Задача добавлена.");
                            }
                        }
                    }
                }
            }
            int k = 0;
            foreach (Problem problem in problems)
            {
                bool result = false;

                Person linkPerson = problem.Appointee;

                if (problem.Sector.ToString().Equals(linkPerson.Tag))
                {
                    while (linkPerson != null)
                    {
                        if (linkPerson.DeputyPerson != null)
                        {
                            if (linkPerson.DeputyPerson.Name.Equals(problem.Appointing.Name))
                            {
                                result = true;
                                linkPerson = null;
                            }
                        }
                        if (!result)
                        {
                            if (linkPerson.Name.Equals(problem.Appointing.Name))
                            {
                                result = true;
                                linkPerson = null;
                            }
                            else
                            {
                                linkPerson = linkPerson.UnderPerson;
                            }
                        }
                    }
                }

                Console.WriteLine($"{++k}. {problem} : {result}");
            }

            Console.ReadKey();
        }
    }
}
