// using System;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using Leykoz.Business.Service.Interfaces;
// using Leykoz.Business.ViewModels;
// using Leykoz.Core.Entities;
// using Microsoft.AspNetCore.Identity;
//
// namespace Leykoz.Business.Service.Implementations
// {
//     public class UserService : IUserService
//     {
//         private readonly UserManager<ApplicationUser> _userManager;
//         private readonly SignInManager<ApplicationUser> _signInManager;
//         private readonly RoleManager<IdentityRole> _roleManager;
//
//         public UserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
//             RoleManager<IdentityRole> roleManager)
//         {
//             _userManager = userManager;
//             _signInManager = signInManager;
//             _roleManager = roleManager;
//         }
//
//          
//         public async Task Login(UserLoginVM userLoginVm)
//         {
//             var user = await _userManager.FindByEmailAsync(userLoginVm.EMail);
//             var signResult =
//                 await _signInManager.PasswordSignInAsync(user, userLoginVm.Password, userLoginVm.RememberMe, false);
//         }
//
//         public async Task LogOut()
//         {
//             await _signInManager.SignOutAsync();
//         }
//
//         
//
//         public async Task Create(UserPostVM userPostVM)
//         {
//             ApplicationUser newUser = new ApplicationUser
//             {
//                 Name = userPostVM.Name,
//                 LastName = userPostVM.LastName,
//                 UserName = userPostVM.UserName,
//                 Email = userPostVM.Email,
//                 IsActivated = true,
//                 CreatedAt = DateTime.Now
//             };
//
//             var IdentityResult = await _userManager.CreateAsync(newUser, userPostVM.Password);
//             if (!IdentityResult.Succeeded)
//             {
//                 foreach (var error in IdentityResult.Errors)
//                 {
//                     // ModelState.AddModelError("", error.Description);
//                     //return Json(error.Description);
//                 }
//             
//             }
//
//             // var Token = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
//             // var ConfirmationLink = Url.Action("ConfirmEmail", "Account",
//             //     new { userId = newUser.Id, token = Token }, Request.Scheme);
//
//
//             // EmailHelper.EmailContentBuilder(register.Email, ConfirmationLink, "Confirm Email");
//
//             // await _signInManager.SignInAsync(newUser, isPersistent: false);
//
//             // return RedirectToAction("Index", "Home");
//         }
//
//         public async Task Update(int id, UserPostVM userPostVM)
//         {
//             throw new System.NotImplementedException();
//         }
//
//         public async Task Remove(int id)
//         {
//             throw new System.NotImplementedException();
//         }
//
//         public async Task<int> getPageCount(int take)
//         {
//             throw new System.NotImplementedException();
//         }
//     }
// }