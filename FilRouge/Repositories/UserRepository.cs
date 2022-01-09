using FilRouge.Interfaces;
using FilRouge.Model;
using FilRouge.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FilRouge.Repositories
{
    public class UserRepository : BaseRepository, IRepository<User>
    {
        public UserRepository(DataContext dataContext) : base(dataContext)
        {
        }
        public User Get(int id)
        {
            return _dataContext.Users.FirstOrDefault(u => u.Id == id);
        }

        public List<User> GetAll()
        {
            return _dataContext.Users.ToList();
        }

        public User Save(User entity)
        {
            _dataContext.Users.Add(entity);
            _dataContext.SaveChanges();
            return entity;
        }

        public List<User> Search(Expression<Func<User, bool>> searchMethode)
        {
            return _dataContext.Users.Where(searchMethode).ToList();
        }

        public User SearchOne(Expression<Func<User, bool>> searchMethode)
        {
            return _dataContext.Users.SingleOrDefault(searchMethode);
        }

        public bool Update()
        {
            return _dataContext.SaveChanges() > 0;
        }
    }
}
