using EntityLayer.Abstract;

namespace EntityLayer.Concrete
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Book>? Books { get; set; }
    }
}
