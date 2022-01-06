using System.Collections.Generic;

namespace FilRouge.Model
{
    public class Tag
    {
        private int id;
        private string name;
        private string description;
        private string image;

        public int Id { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Description { get { return description; } set { description = value; } }

        public string Image { get { return image; } set { image = value; } }

        public virtual List<Question> Questions { get; set; }
    }
}
