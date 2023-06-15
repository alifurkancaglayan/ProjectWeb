using EntityLayer.Abstract;

namespace EntityLayer.Concrete
{
    public class OperationClaim : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
