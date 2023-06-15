using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class TempManager : ITempService
    {
        private readonly ITempRepository _tempRepository;

        public TempManager(ITempRepository tempRepository)
        {
            _tempRepository = tempRepository;
        }

        public void CreateOneTemp(Temp entity)
        {
            _tempRepository.Create(entity);
        }

        public void DeleteOneTemp(Temp entity)
        {
            _tempRepository?.Delete(entity);
        }

        public List<Temp> GetAllTempAsync(bool trackChanges)
        {
            var data = _tempRepository.FindAll(trackChanges).ToList();
            return data;
        }

        public Temp GetTempByIdAsync(int id, bool trackChanges)
        {
            var tempData = _tempRepository.FindByCondition(x => x.Id == id, trackChanges).FirstOrDefault();
            return tempData;
        }

        public void UpdateOneTemp(Temp entity)
        {
            _tempRepository.Update(entity);
        }
    }
}
