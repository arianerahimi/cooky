using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testweb.Areas.Identity.Data;
using testweb.Data;
using testweb.Models;
using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;

namespace testweb.Controllers
{
    public class Customer : Controller
    {


        public async Task<IActionResult> Index([FromServices] dbfinal1 db)
        {

            var products = db.Products.Include(x => x.ProductImages).ToList();
            return View(products);
        }
        public async Task<IActionResult> ShowImage(int id, [FromServices] dbfinal1 db)
        {

            byte[] b = db.ProductImages.Find(id).img;
            return File(b, "image/jpeg");
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        public async Task<IActionResult> AddtoPurchaseCart(int productId, [FromServices] UserManager<ApplicationUser> usermanager, [FromServices]
        dbfinal1 db)
        {
            string userId = (await usermanager.FindByNameAsync(User.Identity.Name)).Id;
            purchaseCart purchaseCart = db.PurchaseCarts.FirstOrDefault(x => x.UserId == userId && x.isOpen == true);
            if (purchaseCart == null)
            {
                purchaseCart = new purchaseCart();
                purchaseCart.isOpen = true;
                purchaseCart.createdDate = DateTime.Now;
                purchaseCart.UserId = userId;
            }
            db.Add(purchaseCart);
            db.SaveChanges();

            if (db.PurchaseCartItems.Any(x => x.PurchaseCartId == purchaseCart.Id && x.ProductId == productId) == false)
            {
                PurchaseCartItem purchaseCartItem = new PurchaseCartItem()
                {
                    ProductId = productId,
                    count = 1,
                    PurchaseCartId = purchaseCart.Id
                };
                db.Add(purchaseCartItem);
                db.SaveChanges();
            }
            return Json(true);
        }

        public async Task<IActionResult> PurchaseCartManagment([FromServices] dbfinal1 db, [FromServices] UserManager<ApplicationUser> userManager)
        {
            string userid = (await userManager.FindByNameAsync(User.Identity.Name)).Id;
            purchaseCart purchaseCart = db.PurchaseCarts.Include(x => x.PurchaseCartItems).ThenInclude(x => x.Product)
                .ThenInclude(x => x.ProductImages)
                .FirstOrDefault(x => x.UserId == userid && x.isOpen == true);
            ViewData["totalprice"] = $"{PurchaseCartTotalPrice(purchaseCart.Id):0,0}";

            HttpContext.Session.SetInt32("purchaseCartId", purchaseCart.Id);

            return View(purchaseCart);
        }

        private object PurchaseCartTotalPrice(int id)
        {
            throw new NotImplementedException();
        }

        public double PurchaseCartTotalPrice(int purchasecartid, [FromServices] dbfinal1 db)
        {
            var items = db.PurchaseCartItems
                .Where(x => x.PurchaseCartId == purchasecartid)
                 .Include(x => x.Product).ToList();

            double totalsum = items.Sum(x => x.count * x.Product.price);
            return totalsum;
        }

        public IActionResult ChangeCountPurchaseItem(int count, int purchaseitemid, [FromServices] dbfinal1 db)
        {
            int purchaseCartId = HttpContext.Session.GetInt32("purchaseCartId").Value;
            var item = db.Find<PurchaseCartItem>(purchaseitemid);
            if (item == null)
            {
                return Json(new
                {
                    status = false,
                });
            }
            else
            {
                item.count = count;
                db.SaveChanges();
                return Json(
                    new
                    {
                        status = true,
                        totalprice = $"{PurchaseCartTotalPrice(purchaseCartId):0,0}"
                    });
            }
        }

        public IActionResult RemoveFromPurchaseCart(int purchaseitemid, [FromServices] dbfinal1 db)
        {
            try
            {
                int purchaseCartId = HttpContext.Session.GetInt32("purchaseCartId").Value;
                db.PurchaseCartItems.Remove(db.Find<PurchaseCartItem>(purchaseitemid));
                db.SaveChanges();
                return Json(
                    new
                    {
                        status = true,
                        totalprice = $"{PurchaseCartTotalPrice(purchaseCartId):0,0}"
                    });
            }
            catch
            {
                return Json(
                     new
                     {
                         status = false,
                     });
            }
        }
    }
}
