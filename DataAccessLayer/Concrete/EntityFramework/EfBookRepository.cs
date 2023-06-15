using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete
{
    public class EfBookRepository : EfEntityRepository<Book>, IBookRepository
    {
        public EfBookRepository(ProjectWebContext context) : base(context)
        {
        }

        public List<Book> GetListWithCategory()
        {
            using (var c = new ProjectWebContext())
            {
                return c.Books.Include(x => x.Category).ToList();
            }

        }
    }
}
