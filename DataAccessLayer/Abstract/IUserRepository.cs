using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface IUserRepository : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(int userId);
    }
}
