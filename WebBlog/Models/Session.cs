using System;
using System.ComponentModel.DataAnnotations;
namespace WebBlog.Models
{
    public class Session
    {
        [Key]
        public int Id { get; set; }
        public DateTime ConnectionTime { get; set; }    
    }
}
