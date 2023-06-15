using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IBookService
    {
        List<Book> GetAllBookAsync(bool trackChanges);
        Book GetBookByIdAsync(int id, bool trackChanges);
        void CreateOneBook(Book entity);
        void UpdateOneBook(Book entity);
        void DeleteOneBook(Book entity);
        List<Book> GetBookListWithCategory();
    }
}
