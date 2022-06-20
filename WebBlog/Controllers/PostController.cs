using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebBlog.Data;
using WebBlog.Models;
using System;
using System.Linq;

namespace WebBlog.Controllers
{
    public class PostController : Controller
    {
        private readonly ApplicationDbContext _db;
        
        //конструктор, на входе получаем контекст БД
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
        //Лента для незареганных юзеров
        public IActionResult NotAuthIndex()
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
        //Создание поста
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult CreatePost(Post post)
        {
            IEnumerable<User> objList = _db.Users;
            post.PostCreate = DateTime.Now;
            post.WhoPosted = _db.Users.OrderByDescending(u => u.EntryTime).Select(u => u.UserName).FirstOrDefault().ToString();
            _db.Posts.Add(post);
            _db.SaveChanges();
            return RedirectToAction("Validator", objList);
        }

        //выводит "ленту", где хранятся все статьи
        public IActionResult AllPosts()
        {
            IEnumerable<Post> objList = _db.Posts;
            return View(objList);
        }

        //Валидатор для подтягивания автора статьи
        public IActionResult Validator(Post post)
        {
            foreach (var a in _db.Posts)
            {
                if (a.WhoPosted == "")
                {
                    post.WhoPosted = _db.Users.OrderByDescending(u => u.EntryTime).Select(u => u.UserName).FirstOrDefault().ToString();
                    _db.Posts.Update(post);
                    _db.SaveChanges();
                }
            }
            
            return RedirectToAction("AllPosts");
        }

        /// <summary>
        /// Контроллеры с методом Get для каждого "сообщества"
        /// </summary>
        /// <returns>View("Имя вьюшки")</returns>
        public IActionResult CsharpForum()
        {
            IEnumerable<Post> objList = _db.Posts;
            return View(objList);
        }

        public IActionResult GitHubForum()
        {
            IEnumerable<Post> objList = _db.Posts;
            return View(objList);
        }

        public IActionResult FrontEndForum()
        {
            IEnumerable<Post> objList = _db.Posts;
            return View(objList);
        }

        public IActionResult AnalyticsForum()
        {
            IEnumerable<Post> objList = _db.Posts;
            return View(objList);
        }

        public IActionResult QaForum()
        {
            IEnumerable<Post> objList = _db.Posts;
            return View(objList);
        }

        public IActionResult AnythingForum()
        {
            IEnumerable<Post> objList = _db.Posts;
            return View(objList);
        }
    }
}
