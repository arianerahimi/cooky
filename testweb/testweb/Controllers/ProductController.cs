using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.SharePoint.Client;
using System.Drawing;
using testweb.Data;
using testweb.Models;
using testweb.ViewModel;

namespace testweb.Controllers
{
    public class ProductController : Controller
    {
        int prdId;
        public IActionResult InsertProduct([FromServices] dbfinal1 db)
        {
            ViewData["Brands"] = db.Brands.ToList();
            //ViewData["ProductCategories"] = db.ProductCategories.ToList();
            return View();
        }
        public IActionResult InsertProductConfirm(ProductViewModel model, [FromServices] dbfinal1 db)
        {
            //Auto-Mapper
            Product product = new Product
            {
                name = model.name,
                price = model.price,
                conunt = model.count,
                descreption = model.descreption,
                englishname = model.englishname,
                BrandId = model.BrandId


            };
            db.Add(product);
            db.SaveChanges();
            prdId = product.Id;

            return RedirectToAction("InsertProductImage", "Product", new { productId = product.Id });
        }

        public IActionResult InsertProductImage(int ProductId, [FromServices] dbfinal1 db)
        {
            //Session
            Product product = db.Products.Include(x => x.Brand).FirstOrDefault(x => x.Id == ProductId);
            ViewData["product"] = product;
            //prdId = ProductId;
            HttpContext.Session.SetInt32("productid", ProductId);



            return View();
        }

        public IActionResult InsertProductImageConfirm(int prdid, ProductImageViewModel model, [FromServices] dbfinal1 db)
        {

            ProductImage productImage = new ProductImage();

            productImage.img = ImageToByteArray(model.imgbytes);
            productImage.title = model.title;
            int productId = HttpContext.Session.GetInt32("productid").Value;
            productImage.ProductId = productId;
            db.Add(productImage);
            db.SaveChanges();
            return RedirectToAction("InsertProduct", "Product", new { productId = productId });


        }

        private byte[] ImageToByteArray(IFormFile img)
        {
            byte[] fileBytes;
            if (img.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    img.CopyTo(ms);
                    fileBytes = ms.ToArray();
                    // s = Convert.ToBase64String(fileBytes);
                    // act on the Base64 data
                    return fileBytes;
                }
            }
            return null;
        }




    }
}
