using BLL.Interface.Services;
using BLL.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using MvcPL.Models;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using System.Web.Routing;

namespace MvcPL.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService service;
        private readonly IUserService userService;

        public ProductController(IProductService productService, IUserService userService)
        {
            this.service = productService;
            this.userService = userService;
        }

        [AllowAnonymous]
        public ActionResult Index(string searchString)
        {
            ViewBag.SearchString = searchString; 
            return View();
        }

        [AllowAnonymous]
        public ActionResult ProductSearch(string sortOrder, string currentFilter, string searchString, int? page)
        {
            var products = service.GetAllEntities();
            IEnumerable<ProductsViewModel> pwml = products.Select(p => new ProductsViewModel()
            {
                Id = p.Id,
                Auction_Cost = p.Auction_Cost,
                Description = p.Description,
                AuctionEnd = p.AuctionEnd,
                AuctionStart = p.AuctionStart
            });
            if (searchString != null)
                pwml = pwml.Where(p => p.Description.Contains(searchString));
            ViewBag.NameSortParam = String.IsNullOrEmpty(sortOrder) ? "description_desc" : "";
            ViewBag.PriceSortParam = sortOrder == "price" ? "price_desc" : "price";
            ViewBag.CurrentSort = sortOrder;
            ViewBag.SearchString = searchString;
            switch (sortOrder)
            {
                case "description_desc":
                    pwml = pwml.OrderByDescending(p => p.Description);
                    break;
                case "price":
                    pwml = pwml.OrderBy(p => p.Auction_Cost);
                    break;
                case "price_desc":
                    pwml = pwml.OrderByDescending(p => p.Auction_Cost);
                    break;
                default:
                    pwml = pwml.OrderBy(p => p.Description);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return PartialView("_ProductTablePartial", pwml.ToPagedList(pageNumber,pageSize));
        }

        private IEnumerable<ProductsViewModel> sort()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductsViewModel model)
        {
            if (ModelState.IsValid)
            {
                int currentUserId = userService.GetByPredicate(u => u.Login == User.Identity.Name).FirstOrDefault().Id;
                var product = new ProductEntity()
                {
                    Auction_Cost = model.Auction_Cost,
                    AuctionStart = DateTime.Now,
                    AuctionEnd = model.AuctionEnd,
                    Description = model.Description,
                    Seller_Id = currentUserId,
                    Customer_Id = currentUserId
                };
                service.Create(product);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Details()
        {
            string id = (string)RouteData.Values["id"];
            if (id == null)
                return RedirectToAction("Index");
            ProductEntity prodEntity = service.GetById(Int32.Parse(id));
            ProductsViewModel product = new ProductsViewModel()
            {
                Auction_Cost = prodEntity.Auction_Cost,
                AuctionEnd = prodEntity.AuctionEnd,
                Description = prodEntity.Description
            };
            return View(product);
        }

        [HttpGet]
        public ActionResult Delete()
        {
            string id = (string)RouteData.Values["id"];
            if (id == null)
                return RedirectToAction("Index");
            ProductEntity prodEntity = service.GetById(Int32.Parse(id));
            service.Delete(prodEntity);
            return RedirectToAction("Index");
        }
    }
}
