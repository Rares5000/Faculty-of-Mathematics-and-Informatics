using Lab4_23.Models.Base;
namespace Lab4_23.Models.One_to_Many
{
    public class Post : BaseEntity
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; } = null!;
    }
}
