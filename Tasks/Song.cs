using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    class Song
    {
        string name; 
        string author; 
        Song prev; //связь с предыдущей песней
        public Song(string Name, string Author)
        {
            name = Name;
            author = Author;
        }
        public Song(string Name, string Author, Song Prev) : this(Name, Author)
        {
            prev = Prev;
        }
        public void SetName(string Name)
        {
            name = Name;
        }
        public void SetAutor(string Author)
        {
            author = Author;
        }
        public void SetPrev(Song Prev)
        {
            prev = Prev;
        }
        public string Title()
        {
            return name + " " + author;
        }
        public override bool Equals(object d) //сравнение 2 объектов песни
        {
            if (d is Song)
            {
                if (name != ((Song)d).name)
                    return false;
                if (author != ((Song)d).author)
                    return false;
                return true;
            }
            return false;
        }
    }
}
