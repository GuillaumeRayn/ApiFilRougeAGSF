using FilRouge.Tools;

namespace FilRouge.Repositories
{
    public class BaseRepository
    {
        protected DataContext _dataContext;

        public BaseRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
}
}
