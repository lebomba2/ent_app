using System.Collections.Generic;

namespace Entertainment_App.Models
{
    public abstract class Media
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public abstract void Display();
public abstract void Read();
public abstract List<string> Search(string Title);
    }
}
