using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    class Hierarchy
    {
        public class Level
        {            
            public Dictionary<string, Person> CurrentPersons; //люди
        }

        public List<Level> Levels;
        public Dictionary<string, int> LevelOfPersons;
        public Hierarchy()
        {
            Levels = new List<Level>();
            LevelOfPersons = new Dictionary<string, int>();
        }
        public void AddLevel(string Tag, params Person[] Persons)
        {
            Levels.Add(new Level()); //создаем новый уровень и добавляем его в лист
            Levels[Levels.Count - 1].CurrentPersons = new Dictionary<string, Person>();
            foreach (Person person in Persons)
            {
                person.Tag = Tag;
                Levels[Levels.Count - 1].CurrentPersons.Add(person.Name, person);
                LevelOfPersons.Add(person.Name, Levels.Count - 1);
                if (person.DeputyPerson != null)
                {
                    Levels[Levels.Count - 1].CurrentPersons.Add(person.DeputyPerson.Name, person.DeputyPerson);
                    LevelOfPersons.Add(person.DeputyPerson.Name, Levels.Count - 1);
                    person.DeputyPerson.Tag = Tag;
                }
            }
        }
        public void AddLevel(string Tag, Person UnderPerson, params Person[] Persons)
        {
            Levels.Add(new Level());
            Levels[Levels.Count - 1].CurrentPersons = new Dictionary<string, Person>();
            foreach (Person person in Persons)
            {
                person.Tag = Tag;
                person.UnderPerson = UnderPerson;
                Levels[Levels.Count - 1].CurrentPersons.Add(person.Name, person);
                LevelOfPersons.Add(person.Name, Levels.Count - 1);
                if (person.DeputyPerson != null)
                {
                    Levels[Levels.Count - 1].CurrentPersons.Add(person.DeputyPerson.Name, person.DeputyPerson);
                    LevelOfPersons.Add(person.DeputyPerson.Name, Levels.Count - 1);
                    person.DeputyPerson.Tag = Tag;
                }
            }
        }
        public void AddLevel(params Person[] Persons)
        {
            Levels.Add(new Level());
            Levels[Levels.Count - 1].CurrentPersons = new Dictionary<string, Person>();
            foreach (Person person in Persons)
            {
                Levels[Levels.Count - 1].CurrentPersons.Add(person.Name, person);
                LevelOfPersons.Add(person.Name, Levels.Count - 1);
                if (person.DeputyPerson != null)
                {
                    Levels[Levels.Count - 1].CurrentPersons.Add(person.DeputyPerson.Name, person.DeputyPerson);
                    LevelOfPersons.Add(person.DeputyPerson.Name, Levels.Count - 1);
                }
            }
        }
        public void AddLevel(Person UnderPerson, params Person[] Persons)
        {
            Levels.Add(new Level());
            Levels[Levels.Count - 1].CurrentPersons = new Dictionary<string, Person>();
            foreach (Person person in Persons)
            {
                person.UnderPerson = UnderPerson;
                Levels[Levels.Count - 1].CurrentPersons.Add(person.Name, person);
                LevelOfPersons.Add(person.Name, Levels.Count - 1);
                if (person.DeputyPerson != null)
                {
                    Levels[Levels.Count - 1].CurrentPersons.Add(person.DeputyPerson.Name, person.DeputyPerson);
                    LevelOfPersons.Add(person.DeputyPerson.Name, Levels.Count - 1);
                }
            }
        }
        public void AddPersons(int numLevel, Person UnderPerson, params Person[] Persons)
        {
            foreach (Person person in Persons)
            {
                person.UnderPerson = UnderPerson;
                Levels[numLevel].CurrentPersons.Add(person.Name, person);
                LevelOfPersons.Add(person.Name, numLevel);
                if (person.DeputyPerson != null)
                {
                    Levels[numLevel].CurrentPersons.Add(person.DeputyPerson.Name, person.DeputyPerson);
                    LevelOfPersons.Add(person.DeputyPerson.Name, numLevel);
                }
            }
        }
    }
}
