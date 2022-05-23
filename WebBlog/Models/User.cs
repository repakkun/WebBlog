using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebBlog.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
       // [Required]
        [DisplayName("Имя пользователя")]
        public string UserName { get; set; }
       // [Required]
        [DisplayName("Пароль")]
        public string Password { get; set; }

        public DateTime EntryTime { get; set; }
        
    }
}
