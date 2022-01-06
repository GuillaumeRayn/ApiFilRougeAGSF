using System;
using System.ComponentModel.DataAnnotations;

namespace FilRouge.Model
{
    public class User
    {
        private int id;
        private string username;
        private string password;
        private string email;
        private DateTime dateCreation;
        private string description;
        private string avatar;

        public int Id { get { return id; } set { id = value; } }

        public string UserName { get { return username; } set { username = value; } }
        
        [Required]
        public string Password { get { return password; } set { password = value; } }

        public DateTime DateCreation { get { return dateCreation; } set { dateCreation = value; } }

        [DataType(DataType.Text)]
        public string Description { get { return description; } set { description = value; } }

        public string Email { get { return email; } set { email = value; } }

        public string Avatar { get { return avatar; } set { avatar = value; } }

        
    }
}
