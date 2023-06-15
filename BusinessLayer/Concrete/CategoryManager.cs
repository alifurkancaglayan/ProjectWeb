using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void CreateOneCategory(Category entity)
        {
            _categoryRepository.Create(entity);
        }

        public void DeleteOneCategory(Category entity)
        {
            _categoryRepository?.Delete(entity);
        }

        public List<Category> GetAllCategoryAsync(bool trackChanges)
        {
            var data = _categoryRepository.FindAll(trackChanges).ToList();
            return data;
        }

        public Category GetCategoryByIdAsync(int id, bool trackChanges)
        {
            var tempData = _categoryRepository.FindByCondition(x => x.Id == id, trackChanges).FirstOrDefault();
            return tempData;
        }

        public void UpdateOneCategory(Category entity)
        {
            _categoryRepository.Update(entity);
        }
    }
}
