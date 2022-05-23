using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebBlog.Data;
using WebBlog.Models;

namespace WebBlog.Controllers
{
    public class PostController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PostController(ApplicationDbContext db)
        {
            _db = db;
        }
        //Get
        public IActionResult Index()
        {
            IEnumerable<User> objList = _db.Users;
            return View(objList);
        }

        //Get
        public IActionResult CreatePost()
        {
            return View();
        }

        //Post
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult CreatePost(Post post)
        {
            _db.Posts.Add(post);
            _db.SaveChanges();
            return RedirectToAction("AllPosts");
        }

        public IActionResult AllPosts()
        {
            IEnumerable<Post> objList = _db.Posts;
            return View(objList);
        }
    }
}
