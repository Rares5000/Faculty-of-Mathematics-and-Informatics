using Lab4_23.Models.Base;

namespace Lab4_23.Models.One_to_Many
{
    public class Blog : BaseEntity
    {
        public int Id { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
