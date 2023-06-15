using EntityLayer.Abstract;

namespace EntityLayer.Concrete
{
    public class Book : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Writer { get; set; }
        public byte[] BookImage { get; set; }
        public string About { get; set; }
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }
    }
}
