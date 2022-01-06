using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilRouge.Model
{
    public class Question
    {
        private int id;
        private string title;
        private string content;
        private string codeContent;

        public int Id { get { return id; } set { id = value; } }
        public string Title { get { return title; } set { title = value; } }
        public string Content { get { return content; } set { content = value; } }
        public string CodeContent { get { return codeContent; } set { codeContent = value; } }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public virtual List<Tag> Tags { get; set; }

        public virtual List<Answer> Answers { get; set; }
    }
}
