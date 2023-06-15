using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;

namespace DataAccessLayer.Concrete
{
    public class EfTempRepository : EfEntityRepository<Temp>, ITempRepository
    {
        public EfTempRepository(ProjectWebContext context) : base(context)
        {
        }
    }
}
