using Microsoft.AspNetCore.Mvc;
using System.Windows;
using System.Collections.Generic;
using WebBlog.Data;
using WebBlog.Models;
using Xunit;
using System;

namespace WebBlog.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;

        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        //Get-Registry
        public IActionResult Registry()
        {
            return View();
        }

        //Post-Registry
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registry(User user)
        {
            user.EntryTime = DateTime.Now;
            //Проверка: занято ли имя пользователя
            foreach (var obj in _db.Users)
            {
                if (obj.UserName == user.UserName)
                {
                    return RedirectToAction("BadRegistry");              
                }
                

            } 
            if (user.UserName == null || user.Password == null)
            {
               return RedirectToAction("BadRegistry");
            }          
            _db.Users.Add(user);
            _db.SaveChanges();                 
            return RedirectToAction("Index", "Post");
            
        }

        //Get-Authorization
        public IActionResult Authorization()
        {
            return View();
        }

        //Post-Authorization
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Authorization(User user)
        {
            //Проверка: подходят ли данные пользователя
            bool flag = false;
            foreach (var obj in _db.Users)
            {
                if (obj.UserName == user.UserName && obj.Password == user.Password)
                {
                    flag = true;                   
                    break;
                }              
            }

            if (flag == true)
            {
                user.EntryTime = DateTime.Now;
                _db.Users.Update(user);
                _db.SaveChanges(); 
                return RedirectToAction("Index", "Post");                 
            }
            return RedirectToAction("BadAuthorization");
        }
//--------------------------------------------------------------------------------------------
//                                   BAD VALIDATION (poxuy na OOP)
//--------------------------------------------------------------------------------------------

        //Get-BadRegistry
        public IActionResult BadRegistry()
        {
            return View();
        }

        //Post-BadRegistry
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BadRegistry(User user)
        {
            //Проверка: занято ли имя пользователя
            foreach (var obj in _db.Users)
            {
                if (obj.UserName == user.UserName)
                {
                    return View();
                }
                
            }
            if (user.UserName == null || user.Password == null)
            {
                return View();
            }
            user.EntryTime = DateTime.Now;
            _db.Users.Add(user);
            _db.SaveChanges();
            return RedirectToAction("Index", "Post");

        }

        //Get-BadAuthorization
        public IActionResult BadAuthorization()
        {
            return View();
            //IEnumerable<User> objList = _db.Users;
            //return View(objList);
        }

        //Post-BadAuthorization
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BadAuthorization(User user)
        {
            //Проверка: подходят ли данные пользователя
            bool flag = false;
            foreach (var obj in _db.Users)
            {
                if (obj.UserName == user.UserName && obj.Password == user.Password)
                {
                    flag = true;
                    break;
                }
            }
            if (flag == true)
            {
                user.EntryTime = DateTime.Now;
                _db.Users.Update(user);
                _db.SaveChanges();
                return RedirectToAction("Index", "Post");
            }
            
            return View();
        }
    }
}
