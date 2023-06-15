using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfUserOperationClaim : EfEntityRepository<UserOperationClaim>, IUserOperationClaimRepository
    {
        public EfUserOperationClaim(ProjectWebContext context) : base(context)
        {
        }
    }
}
