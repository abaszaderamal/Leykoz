using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Leykoz.Business.Utilities.Helpers;
using Leykoz.Business.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Leykoz.Controllers
{
    public class AccountController : Controller
    {
        // private readonly IConfiguration _configuration;
        private UserManager<IdentityUser> _userManager { get; }
        private SignInManager<IdentityUser> _signInManager { get; }
        private RoleManager<IdentityRole> _roleManager;


        public AccountController(SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            /*IConfiguration configuration,*/
            RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            // _configuration = configuration;
            _roleManager = roleManager;
        }

        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Users()
        {
            // CreateRoll();
            return View(await _userManager
                .Users
                /* .OrderByDescending(p => p.Id)  */
                .ToListAsync());
        }

        [Authorize(Roles = "ADMIN")]
        public IActionResult Register()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Register(UserPostVM userregVM)
        {
            // CreateRoll();
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    Email = userregVM.Email,
                    UserName = userregVM.UserName,
                    EmailConfirmed = true,
                };
                bool isExistUsername = _userManager.Users.Any(us => us.UserName == user.UserName);
                if (isExistUsername)
                {
                    ModelState.AddModelError(String.Empty,
                        "Bu İstifadəçi adı artıq mövcuddur. Başqa İstifadəçi adı istifadə edin");
                    return View();
                }

                bool isExistEmail = _userManager.Users.Any(us => us.Email == user.Email);
                if (isExistEmail)
                {
                    ModelState.AddModelError(String.Empty, "Bu Email artıq mövcuddur. Başqa Email istifadə edin");
                    return View();
                }

                var result = await _userManager.CreateAsync(user, userregVM.Password);


                if (result.Succeeded)
                {
                    // await _userManager.AddToRoleAsync(user, "Member");
                    //await _userManager.AddToRoleAsync(user, "ADMIN");
                    return RedirectToAction("Users");
                }

                {
                    if (result.Errors.Count() > 0)
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }

                    return View(userregVM);
                }
            }

            return View(userregVM);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginVM userLogin, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(userLogin.Email);
                if (user == null)
                {
                    ModelState.AddModelError("Email", "Email tapılmadı");
                    return View(userLogin);
                }

                if (await _userManager.CheckPasswordAsync(user, userLogin.Password) == false)
                {
                    ModelState.AddModelError("Password", "Etibarsız parol");
                    return View(userLogin);
                }

                var result =
                    await _signInManager.PasswordSignInAsync(user.UserName, userLogin.Password, userLogin.RememberMe,
                        true);
                if (result.Succeeded)
                {
                    await _userManager.AddClaimAsync(user, new Claim("UserRole", "Admin"));
                    if (ReturnUrl != null)
                    {
                        return Redirect(ReturnUrl);
                    }

                    return Redirect("/adminpanel");
                    // return RedirectToAction("index", "Home");
                }
                else
                {
                    ModelState.AddModelError(" ", "Yanlış giriş cəhdi");
                    return View(userLogin);
                }
            }

            return View(userLogin);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("login", "account");
        }

        //GET-ForgotPassword
        public IActionResult ForgotPassword()
        {
            return View();
        }

        //Post-ForgotPassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordVM forgotPassword)
        {
            if (!ModelState.IsValid) return View(forgotPassword);
            var user = await _userManager.FindByEmailAsync(forgotPassword.Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "İstifadəçi tapılmadı");
                return View();
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var link = Url.Action("ResetPassword", "Account", new { token, email = user.Email }, Request.Scheme);


            bool emailResponse = EmailHelper.SendEmail(user.Email, link);

            if (emailResponse)
                return RedirectToAction("ForgotPasswordConfirmation");
            else
            {
                // log email failed 
            }

            return RedirectToAction(nameof(ForgotPasswordConfirmation));
        }

        //GET-ForgotPasswordConfirmation
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //GET-ResetPassword
        public IActionResult ResetPassword(string token, string email)
        {
            var model = new ResetPasswordVM { Token = token, Email = email };
            return View(model);
        }

        //Post-ResetPassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM resetPassword)
        {
            if (!ModelState.IsValid) return View(resetPassword);
            var user = await _userManager.FindByEmailAsync(resetPassword.Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "İstifadəçi tapılmadı");
                return View();
            }

            IdentityResult identityResult =
                await _userManager.ResetPasswordAsync(user, resetPassword.Token, resetPassword.Password);
            if (!identityResult.Succeeded)
            {
                foreach (var error in identityResult.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }

                return View(resetPassword);
            }

            return RedirectToAction(nameof(ResetPasswordConfirmation));
        }

        //GET-ResetPasswordConfirmation
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordVM password)
        {
            if (!ModelState.IsValid) return View(password);
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "İstifadəçi tapılmadı");
                return View();
            }

            var checkPasword = await _userManager.CheckPasswordAsync(user, password.CurrentPassword);
            if (!checkPasword)
            {
                ModelState.AddModelError(string.Empty, "Etibarsız parol");
                return View(password);
            }

            var result = await _userManager.ChangePasswordAsync(user, password.CurrentPassword,
                password.NewPassword);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View(password);
            }

            await _signInManager.RefreshSignInAsync(user);
            return RedirectToAction("Index", "Dashboard");
        }

        #region ChangeUserName

        // public IActionResult ChangeUsername()
        // {
        //     return View();
        // }
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> ChangeUsername(ChangeUsernameVM username)
        // {
        //     if (!ModelState.IsValid) return View(username);
        //     var user = await _userManager.GetUserAsync(User);
        //     if (user == null)
        //     {
        //         ModelState.AddModelError(string.Empty, "User is Not Found");
        //         return View(username);
        //     }
        //     var checkPasword = await _userManager.CheckPasswordAsync(user, username.Password);
        //     if (!checkPasword)
        //     {
        //         ModelState.AddModelError(string.Empty, "Incorrect Password");
        //         return View(username);
        //     }
        //     var result = await _userManager.SetUserNameAsync(user, username.NewUsername);
        //     if (!result.Succeeded)
        //     {
        //         foreach (var error in result.Errors)
        //         {
        //             ModelState.AddModelError(string.Empty, error.Description);
        //         }
        //         return View(username);
        //     }
        //     await _signInManager.RefreshSignInAsync(user);
        //     return RedirectToAction("Index", "Home");
        // }

        #endregion

        public async Task<IActionResult> AccountProfil()
        {
            IdentityUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            UserPostVM profile = new UserPostVM()
            {
                Email = user.Email,
                UserName = user.UserName
            };
            return View(profile);
        }

        public IActionResult AccessDenied()
        {
            return View();
        }


        public async Task<IActionResult> DeleteUser(string id)
        {
            IdentityUser user = await _userManager.FindByIdAsync(id);
            if (user is null)
            {
                return NotFound();
            }
            else
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
                // if (result.Succeeded)
                // {
                return RedirectToAction(nameof(Users));
                // }
            }
        }

        //Post-AccountSetting
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AccountProfil(string ReturnUrl)
        {
            if (ReturnUrl != null)
            {
                return LocalRedirect(ReturnUrl);
            }

            return View();
        }

        #region CreateRoll

        // public async Task CreateRoll()
        // {
        //     foreach (var UserRole in Enum.GetValues(typeof(RoleHelper.UserRoles)))
        //     {
        //         if (!await _roleManager.RoleExistsAsync(UserRole.ToString()))
        //         {
        //             await _roleManager.CreateAsync(new IdentityRole { Name = UserRole.ToString() });
        //         }
        //     }
        //
        //     Console.WriteLine("role done");
        // }

        #endregion
    }
}