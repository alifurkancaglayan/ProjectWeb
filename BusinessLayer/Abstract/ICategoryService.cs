using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAllCategoryAsync(bool trackChanges);
        Category GetCategoryByIdAsync(int id, bool trackChanges);
        void CreateOneCategory(Category entity);
        void UpdateOneCategory(Category entity);
        void DeleteOneCategory(Category entity);
    }
}
