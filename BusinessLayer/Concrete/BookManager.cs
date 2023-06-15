using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class BookManager : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookManager(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public void CreateOneBook(Book entity)
        {
            _bookRepository.Create(entity);
        }

        public void DeleteOneBook(Book entity)
        {
            _bookRepository?.Delete(entity);
        }

        public List<Book> GetAllBookAsync(bool trackChanges)
        {
            var data = _bookRepository.FindAll(trackChanges).ToList();
            return data;
        }

        public List<Book> GetBookListWithCategory()
        {
            var data = _bookRepository.GetListWithCategory();
            return data;
        }

        public Book GetBookByIdAsync(int id, bool trackChanges)
        {
            var tempData = _bookRepository.FindByCondition(x => x.Id == id, trackChanges).FirstOrDefault();
            return tempData;
        }

        public void UpdateOneBook(Book entity)
        {
            _bookRepository.Update(entity);
        }
    }
}
