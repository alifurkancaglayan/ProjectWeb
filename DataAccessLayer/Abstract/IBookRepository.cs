using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface IBookRepository : IEntityRepository<Book>
    {
        List<Book> GetListWithCategory();
    }
}
