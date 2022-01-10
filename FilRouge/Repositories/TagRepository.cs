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
    public class TagRepository : BaseRepository, IRepository<Tag>
    {
        public TagRepository(DataContext dataContext) : base(dataContext)
        {

        }

        public Tag Get(int id)
        {
            return _dataContext.Tags.Include(t => t.Questions).FirstOrDefault(t => t.Id == id);
        }

        public List<Tag> GetAll()
        {
            return _dataContext.Tags.ToList();
        }

        public Tag Save(Tag entity)
        {
            _dataContext.Tags.Add(entity);
            _dataContext.SaveChanges();
            return entity;
        }

        public List<Tag> Search(System.Linq.Expressions.Expression<Func<Tag, bool>> searchMethode)
        {
            return _dataContext.Tags.Where(searchMethode).ToList();
        }

        public Tag SearchOne(System.Linq.Expressions.Expression<Func<Tag, bool>> searchMethode)
        {
            return _dataContext.Tags.SingleOrDefault(searchMethode);
        }

        public bool Update()
        {
            return _dataContext.SaveChanges() > 0;
        }
    }
}
