using YoutubeApi.Domain.Common;

namespace YoutubeApi.Domain.Entities
{
    public class Category : EntityBase, IEntityBase
    {
        public Category() { }

        public Category(int parentId, string name, int priority)
        {
            ParentId = parentId;
            Name = name;
            Priorty = priority;
        }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public int Priorty { get; set; }
        public ICollection<Detail> Details { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
