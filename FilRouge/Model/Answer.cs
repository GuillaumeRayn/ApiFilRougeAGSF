using System;
using System.ComponentModel.DataAnnotations.Schema;

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

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public int UserId { get; set; }

        [ForeignKey("QuestionId")]
        public virtual Question Question { get; set; }

        public int QuestionId { get; set; }
    }
}
