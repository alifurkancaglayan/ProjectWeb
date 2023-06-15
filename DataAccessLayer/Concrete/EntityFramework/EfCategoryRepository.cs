using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfCategoryRepository : EfEntityRepository<Category>, ICategoryRepository
    {
        public EfCategoryRepository(ProjectWebContext context) : base(context)
        {
        }
    }
}
