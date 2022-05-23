using System.ComponentModel.DataAnnotations;
namespace WebBlog.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string PostName { get; set; }
        public string PostTag { get; set; }
        public string PostBody { get; set; }
    }
}
