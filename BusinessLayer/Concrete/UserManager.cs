using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Add(User user)
        {
            throw new NotImplementedException();
        }

        public User GetById(int userId, bool trackChanges)
        {
            var user = _userRepository.FindByCondition(x => x.Id == userId, trackChanges).FirstOrDefault();
            return user;
        }

        public User GetByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public List<OperationClaim> GetClaims(int userId)
        {
            return _userRepository.GetClaims(userId);
        }

        public User Login(User user)
        {
            var result = _userRepository.FindByCondition(x => x.Email == user.Email && x.Password == user.Password, false).FirstOrDefault();

            return result;
        }

        public User Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
