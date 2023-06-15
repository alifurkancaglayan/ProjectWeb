using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfUserRepository : EfEntityRepository<User>, IUserRepository
    {
        private readonly ProjectWebContext _projectWebContext;
        public EfUserRepository(ProjectWebContext context) : base(context)
        {
            _projectWebContext = context;
        }

        public List<OperationClaim> GetClaims(int userId)
        {
            var result = from operationClaim in _projectWebContext.OperationClaims
                         join userOperationClaim in _projectWebContext.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                         where userOperationClaim.UserId == userId
                         select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
            return result.ToList();
        }
    }
}
