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
    public class QuestionRepository : BaseRepository, IRepository<Question>
    {
        public QuestionRepository(DataContext dataContext) : base(dataContext)
        {

        }

        public Question Get(int id)
        {
            return _dataContext.Questions.Include(q => q.Answers).FirstOrDefault(q => q.Id == id);
        }

        public List<Question> GetAll()
        {
            return _dataContext.Questions.ToList();
        }

        public Question Save(Question entity)
        {
            _dataContext.Questions.Add(entity);
            _dataContext.SaveChanges();
            return entity;
        }

        public List<Question> Search(System.Linq.Expressions.Expression<Func<Question, bool>> searchMethode)
        {
            return _dataContext.Questions.Where(searchMethode).ToList();
        }

        public Question SearchOne(System.Linq.Expressions.Expression<Func<Question, bool>> searchMethode)
        {
            throw new NotImplementedException();
        }

        public bool Update()
        {
            return _dataContext.SaveChanges() > 0;
        }
    }
}
