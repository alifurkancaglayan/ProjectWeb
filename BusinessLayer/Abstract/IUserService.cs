using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(int userId);
        User Add(User user);
        User Update(User user);
        User GetByUsername(string username);
        User GetById(int userId, bool trackChanges);
        User Login(User user);
    }
}
