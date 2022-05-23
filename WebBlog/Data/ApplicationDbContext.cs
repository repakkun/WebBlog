using WebBlog.Models;
using Microsoft.EntityFrameworkCore;

namespace WebBlog.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<UserPost> UserPosts { get; set; }
    }
}