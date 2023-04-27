using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.DotNet.Scaffolding.Shared.Project;
using Microsoft.EntityFrameworkCore;
using Microsoft.SharePoint.Client;
using NuGet.Protocol;
using NuGet.Protocol.Plugins;
using System;
using System.Runtime.InteropServices;
using testweb.Areas.Identity.Data;
using testweb.Data;
using testweb.Models;
using testweb.ViewModel;

namespace testweb.Controllers
{

    [Authorize(Policy = "AdminPolicy")]
    public class Admin : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> DeleteUser(string id, [FromServices] UserManager<ApplicationUser> userManager, [FromServices] dbfinal1 db)
        {
            ApplicationUser user = await userManager.FindByIdAsync(id);


            if (user != null)
            {
                userManager.DeleteAsync(user);
                return RedirectToAction("users", "Admin");
            }
            else
            {
                return RedirectToAction("users", "Admin");
            }
        }

        public async Task<IActionResult> ProductsControl([FromServices] dbfinal1 db)
        {

            var p = db.Products.Include(x => x.Brand).Include(x => x.ProductImages).ToList();
            return View(p);
        }

        public async Task<IActionResult> DeletebyId(int id, [FromServices,] dbfinal1 db)
        {
            var p = db.Products.Find(id);
            if (p != null)
            {
                db.Remove(p);
                db.SaveChanges();
            }

            return RedirectToAction("ProductsControl", "Admin");
        }

        public async Task<IActionResult> Edit([FromServices] dbfinal1 db, int id, ProductViewModel model)
        {
            ViewData["Brands"] = db.Brands.ToList();
            var p = db.Products.Include(x => x.ProductImages).ToList().FirstOrDefault(x => x.Id == id);

            model.name = p.name;
            model.englishname = p.englishname;
            model.price = p.price;
            model.count = p.conunt;
            model.BrandId = p.BrandId;
            model.descreption = p.descreption;

            HttpContext.Session.SetInt32("ProductId", model.Id);

            return View(model);
        }

        public async Task<IActionResult> UpdateProduct(ProductViewModel model, [FromServices] dbfinal1 db)
        {
            var p = db.Products.Find(model.Id);
            p.name = model.name;
            p.englishname = model.englishname;
            p.price = model.price;
            p.conunt = model.count;
            p.BrandId = model.BrandId;
            p.descreption = model.descreption;

            db.Update(p);
            db.SaveChanges();
            return RedirectToAction("ProductsControl", "Admin", new { productId = p.Id });
        }
        public IActionResult EditProductImage([FromServices] dbfinal1 db, ProductImageViewModel imgModel, ProductViewModel model)
        {
            var p = db.Products.Include(x => x.Brand).ToList();
            return View(p);



        }
        public IActionResult UpdateProductImageConfirm(ProductImageViewModel model, [FromServices] dbfinal1 db)
        {

            ProductImage productImage = new ProductImage();

            //productImage.img = ImageToByteArray(model.imgbytes);

            int productId = HttpContext.Session.GetInt32("productid").Value;
            productImage.ProductId = productId;
            db.Update(productImage);
            db.SaveChanges();
            return RedirectToAction("EditProductImage", "Admin", new { productId = productId });


        }


        public IActionResult users([FromServices] UserManager<ApplicationUser> userManager,
           [FromServices] RoleManager<IdentityRole> roleManager, [FromServices] dbfinal1 db)
        {
            List<UsersViewModels> lstUsers = new List<UsersViewModels>();
            var users = db.Users.ToList();
            users.ForEach(x =>
            {
                var userRoleId = db.UserRoles.Where(y => y.UserId == x.Id).ToList();
                userRoleId.ForEach(k =>
                {
                    var roles = db.Roles.Where(z => z.Id == k.RoleId).ToList();
                    roles.ForEach(u =>
                    {
                        UsersViewModels usersView = new UsersViewModels();
                        usersView.firstName = x.firstName;
                        usersView.lastName = x.lastName;
                        usersView.Email = x.Email;
                        usersView.id = x.Id;
                        usersView.username = x.UserName;
                        usersView.RoleName = u.Name;
                        lstUsers.Add(usersView);
                    });
                });
            });
            return View(lstUsers);
        }

        public async Task<IActionResult> EditUsers([FromServices] UserManager<ApplicationUser> userManager, [FromServices] dbfinal1 db, int id, UsersViewModels model, [FromServices] RoleManager<IdentityRole> roleManager)
        {
            ViewData["roles"] = db.Roles.ToList();
            ApplicationUser p = await userManager.FindByIdAsync(model.id);
            var role = roleManager.FindByIdAsync(p.Id);

            var userRoleId = db.UserRoles.Where(y => y.UserId == model.id).ToList();

            userRoleId.ForEach(k =>
            {
                var roles = db.Roles.Where(z => z.Id == k.RoleId).ToList();
                roles.ForEach(u =>
                {
                    model.RoleName = u.Name;

                });
            });
            model.firstName = p.firstName;
            model.lastName = p.lastName;
            model.username = p.UserName;
            model.Email = p.Email;
            model.Roleid = Convert.ToString(role.Id);
            return View(model);
        }


        public async Task<IActionResult> UpdateUsers([FromServices] dbfinal1 db, UsersViewModels model, [FromServices] UserManager<ApplicationUser> userManager,
            [FromServices] RoleManager<IdentityRole> roleManager)
        {

            ApplicationUser user = await userManager.FindByIdAsync(model.id);
            var rolename = await roleManager.FindByIdAsync(model.RoleName);
            if (user != null)
            {

                var oldrole = await userManager.RemoveFromRoleAsync(user, model.oldRole);
                var newrole = await userManager.AddToRoleAsync(user, rolename.Name);
                var status = await userManager.UpdateAsync(user);

                return RedirectToAction("users");
            }


            return RedirectToAction("users");

        }



    }
}
