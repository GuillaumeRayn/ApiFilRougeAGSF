using System;

namespace FilRouge.Model
{
    public class Answer
    {
        private int id;
        private string content;
        private string codeContent;
        private int vote;
        private DateTime dateCreation;

        public int Id { get { return id; } set { id = value; } }
        public string Content { get { return content; } set { content = value; } }
        public int Vote { get { return vote; } set { vote = value; } }
        public DateTime DateCreation { get { return dateCreation; } set { dateCreation = value; } }

        public string CodeContent { get { return codeContent; } set { codeContent = value; } }

        public virtual Question Question { get; set; }

    }
}
