using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfOperationClaimRepository : EfEntityRepository<OperationClaim>, IOperationClaimRepository
    {
        public EfOperationClaimRepository(ProjectWebContext context) : base(context)
        {
        }
    }
}
