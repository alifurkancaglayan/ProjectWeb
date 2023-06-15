using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface ITempService
    {
        List<Temp> GetAllTempAsync(bool trackChanges);
        Temp GetTempByIdAsync(int id, bool trackChanges);
        void CreateOneTemp(Temp entity);
        void UpdateOneTemp(Temp entity);
        void DeleteOneTemp(Temp entity);
    }

}
