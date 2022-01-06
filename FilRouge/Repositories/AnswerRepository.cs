using FilRouge.Interfaces;
using FilRouge.Model;
using FilRouge.Tools;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilRouge.Repositories
{
    public class AnswerRepository : BaseRepository, IRepository<Answer>
    {
        public AnswerRepository(DataContext dataContext) : base(dataContext)
        {

        }

        public Answer Get(int id)
        {
            return _dataContext.Answers.Include(a => a.User).FirstOrDefault(a => a.Id == id);
        }

        public List<Answer> GetAll()
        {
            return _dataContext.Answers.ToList();
        }

        public Answer Save(Answer entity)
        {
            _dataContext.Answers.Add(entity);
            _dataContext.SaveChanges();
            return entity;
        }

        public List<Answer> Search(System.Linq.Expressions.Expression<Func<Answer, bool>> searchMethode)
        {
            return _dataContext.Answers.Where(searchMethode).ToList();
        }

        public Answer SearchOne(System.Linq.Expressions.Expression<Func<Answer, bool>> searchMethode)
        {
            throw new NotImplementedException();
        }

        public bool Update()
        {
            return _dataContext.SaveChanges() > 0;
        }
    }
}
