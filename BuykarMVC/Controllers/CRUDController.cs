using BuykarMVC.Models;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;

namespace BuykarMVC.Controllers
{
    public class CRUDController : Controller
    {
        private readonly UserDb _data;
        public CRUDController(UserDb data)
        {
            _data = data;
        }

        public IActionResult Index()
        {
           List<User> Ulist= _data.UserTable.ToList();
            return View(Ulist);
        }
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(User a)
        {
            if(_data.UserTable.Any(x=>x.Name == a.Name))
            {
                ViewBag.Notification = "This User Name already exists.!";
                return View();
            }  
            else if(_data.UserTable.Any(x=>x.Email == a.Email))
            {
                ViewBag.Notification = "This Email Id has already exists.!";
                return View();
            }
            else if(ModelState.IsValid)
            {
                _data.UserTable.Add(a);
                _data.SaveChanges();
                return RedirectToAction(nameof(Index));

            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var a = _data.UserTable.Find(id);
            return View(a);
        }
        [HttpPost]
        public IActionResult Edit(User edata)
        {
            _data.UserTable.Update(edata);
            _data.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)

        {
           var a = _data.UserTable.Find(id);
            _data.UserTable.Remove(a);
            _data.SaveChanges();
            return RedirectToAction("Index");
        }
/*        [HttpGet]
*/      public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User a)
        {
            if (_data.UserTable.Any(x => x.Name == a.Name && x.Password == a.Password))
            {
                TempData["Name"] = a.Name;

                return RedirectToAction("Index", "Home");
            } 
            else if (_data.UserTable.Any(x => x.Name != a.Name && x.Password != a.Password))
            {
                ViewBag.Notification = "The User Name or Password doesn't match";
                return View();

            }
            else
            {
                return View();
            }
        }

    }
}