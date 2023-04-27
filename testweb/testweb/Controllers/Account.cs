using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using System.Data.Common;
using testweb.Areas.Identity.Data;
using testweb.Data;
using testweb.ViewModel;

namespace testweb.Controllers
{
    public class Account : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult SignInSignUp() => View();

        public async Task<IActionResult> RegisterConfirm(RegisterViewModel models, [FromServices] UserManager<ApplicationUser> userManager)
        {
            ApplicationUser user = await userManager.FindByNameAsync(models.username);
            if (user == null)
            {
                user = new ApplicationUser()
                {
                    firstName = models.firstName,
                    lastName=models.lastname,
                    UserName = models.username,
                    Email = models.username,
                    EmailConfirmed = true
                };
                var status = await userManager.CreateAsync(user, models.password);
                if (status.Succeeded)
                {
                    if (await userManager.IsInRoleAsync(user, "customer") == false)
                    {
                        await userManager.AddToRoleAsync(user, "customer");
                    }
                    return RedirectToAction("Login");
                }

            }
            return RedirectToAction("Register");
        }

        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> LoginConfirm(LoginViewModel model, [FromServices] UserManager<ApplicationUser> userManager, [FromServices] SignInManager<ApplicationUser> signInManager, [FromServices] dbfinal1 db)
        {

            //CaptchaServiceResult s = captchaService.VerifyCaptcha(this);
            //if (s != CaptchaServiceResult.Human)
            //    return RedirectToAction("LoginConfirm","Account");

            ApplicationUser user = await userManager.FindByNameAsync(model.username);
            if (user != null)
            {
                var status = await signInManager.PasswordSignInAsync(user, model.password, false, false);
                if (status.Succeeded)
                {

                    List<string> lstRole = new List<string>();
                    var userRole = db.UserRoles.Where(x => x.UserId == user.Id).ToList();
                    userRole.ForEach(x =>
                    {
                        var roles = db.Roles.Where(y => y.Id == x.RoleId).ToList();
                        roles.ForEach(z =>
                        {
                            lstRole.Add(z.Name);
                        });
                    });
                    if (lstRole.Contains("admin"))
                    {
                        return RedirectToAction("index", "admin");
                    }
                    else
                    {
                        return RedirectToAction("index", "Home");
                    }
                }
                else
                {
                    return RedirectToAction("Register");
                }
            }
            return RedirectToAction("Register");

        }

        public async Task<IActionResult> SignOut([FromServices] SignInManager<ApplicationUser> signInManager)
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
