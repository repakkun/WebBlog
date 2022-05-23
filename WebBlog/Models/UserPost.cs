using System.ComponentModel.DataAnnotations;
namespace WebBlog.Models
{
    public class UserPost
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
