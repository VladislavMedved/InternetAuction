using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using MvcPL.Models;
using System;

namespace MvcPL.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService service;
        public HomeController(IUserService service )
        {
            this.service = service;
        }
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles="Admin")]
        public ActionResult ViewUsers()
        {
            var l = service.GetAllEntities();
            return View(service.GetAllEntities()
                .Select(user => new UserViewModel()
                {
                    Name = user.Login
                }));
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult About()
        {

            return View();
        }
    }
}