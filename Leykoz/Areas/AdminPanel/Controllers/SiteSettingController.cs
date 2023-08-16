using System.Threading.Tasks;
using Leykoz.Business.Service.Interfaces;
using Leykoz.Business.Validators.Setting;
using Leykoz.Business.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Leykoz.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize]
    public class SiteSettingController : Controller
    {
        private readonly IUnitOfWorkService _unitOfWorkService;

        public SiteSettingController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }

        #region FriendMessage

        [HttpGet]
        public async Task<IActionResult> FriendMsg()
        {
            string DbValue = await _unitOfWorkService.SiteSettingService.GetValueByKeyAsync("fmsg");
            return View(new SettingVM { Value = DbValue });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FriendMsg(SettingVM settingVm)
        {
            if (ModelState.IsValid)
            {
                //algo
                await _unitOfWorkService.SiteSettingService.SetValueByKeyAsync("fmsg", settingVm.Value);
                return RedirectToAction(nameof(FriendMsg));
            }

            return View(settingVm);
        }

        #endregion

        #region Cards

        [HttpGet]
        public async Task<IActionResult> Cards()
        {
            CardSettingVM settingVm = new CardSettingVM()
            {
                Value1 = await _unitOfWorkService.SiteSettingService.GetValueByKeyAsync("card1"),
                Value2 = await _unitOfWorkService.SiteSettingService.GetValueByKeyAsync("card2"),
                Value3 = await _unitOfWorkService.SiteSettingService.GetValueByKeyAsync("card3")
            };
            return View(settingVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cards(CardSettingVM cardSettingVm)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWorkService.SiteSettingService.SetValueByKeyAsync("card1", cardSettingVm.Value1);
                await _unitOfWorkService.SiteSettingService.SetValueByKeyAsync("card2", cardSettingVm.Value2);
                await _unitOfWorkService.SiteSettingService.SetValueByKeyAsync("card3", cardSettingVm.Value3);
                return RedirectToAction(nameof(Cards));
            }

            return View(cardSettingVm);
        }

        #endregion

        #region Mission

        [HttpGet]
        public async Task<IActionResult> Mission()
        {
            string DbValue = await _unitOfWorkService.SiteSettingService.GetValueByKeyAsync("mission");
            return View(new SettingVM { Value = DbValue });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Mission(SettingVM settingVm)
        {
            if (ModelState.IsValid)
            {
                //algo
                await _unitOfWorkService.SiteSettingService.SetValueByKeyAsync("mission", settingVm.Value);
                return RedirectToAction(nameof(Mission));
            }

            return View(settingVm);
        }

        #endregion

        #region others

        [HttpGet]
        public async Task<IActionResult> Others()
        {
            otherVM linkVm = new otherVM
            {
                Address = await _unitOfWorkService.SiteSettingService.GetValueByKeyAsync("address"),
                Phone = await _unitOfWorkService.SiteSettingService.GetValueByKeyAsync("phone"),
                FooterTxt =  await _unitOfWorkService.SiteSettingService.GetValueByKeyAsync("footertxt")
            };

            return View(linkVm);
        } 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Others(otherVM otherVm)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWorkService.SiteSettingService.SetValueByKeyAsync("address", otherVm.Address);
                await _unitOfWorkService.SiteSettingService.SetValueByKeyAsync("phone", otherVm.Phone);
                await _unitOfWorkService.SiteSettingService.SetValueByKeyAsync("footertxt", otherVm.FooterTxt); 

                return RedirectToAction(nameof(Others));
            }

            return View(otherVm);
        }


        #endregion
        #region Links

        [HttpGet]
        public async Task<IActionResult> Links()
        {
            LinkVM linkVm = new LinkVM
            {
                Value1 = await _unitOfWorkService.SiteSettingService.GetValueByKeyAsync("besupportivelink"),
                Value2 = await _unitOfWorkService.SiteSettingService.GetValueByKeyAsync("videoplink"),
                Email = await _unitOfWorkService.SiteSettingService.GetValueByKeyAsync("email"),
                Fb = await _unitOfWorkService.SiteSettingService.GetValueByKeyAsync("fb"),
                Insta = await _unitOfWorkService.SiteSettingService.GetValueByKeyAsync("insta"),
                Linkedin = await _unitOfWorkService.SiteSettingService.GetValueByKeyAsync("linkedin"),
                Twit = await _unitOfWorkService.SiteSettingService.GetValueByKeyAsync("twit"),
                Yt = await _unitOfWorkService.SiteSettingService.GetValueByKeyAsync("youtube"),
                SiteYtVideo = await _unitOfWorkService.SiteSettingService.GetValueByKeyAsync("youtublelink")
            };

            return View(linkVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Links(LinkVM linkVm)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWorkService.SiteSettingService.SetValueByKeyAsync("besupportivelink", linkVm.Value1);
                await _unitOfWorkService.SiteSettingService.SetValueByKeyAsync("videoplink", linkVm.Value2);
                await _unitOfWorkService.SiteSettingService.SetValueByKeyAsync("email", linkVm.Email);
                await _unitOfWorkService.SiteSettingService.SetValueByKeyAsync("fb", linkVm.Fb);
                await _unitOfWorkService.SiteSettingService.SetValueByKeyAsync("insta", linkVm.Insta);
                await _unitOfWorkService.SiteSettingService.SetValueByKeyAsync("linkedin", linkVm.Linkedin);
                await _unitOfWorkService.SiteSettingService.SetValueByKeyAsync("twit", linkVm.Twit);
                await _unitOfWorkService.SiteSettingService.SetValueByKeyAsync("youtube", linkVm.Yt);
                await _unitOfWorkService.SiteSettingService.SetValueytvideo(linkVm.SiteYtVideo);

                return RedirectToAction(nameof(Links));
            }

            return View(linkVm);
        }

        #endregion

        #region About

        [HttpGet]
        public async Task<IActionResult> About()
        {
            string DbValue = await _unitOfWorkService.SiteSettingService.GetValueByKeyAsync("about");
            return View(new SettingVM { Value = DbValue });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> About(SettingVM settingVm)
        {
            if (ModelState.IsValid)
            {
                //algo
                await _unitOfWorkService.SiteSettingService.SetValueByKeyAsync("about", settingVm.Value);
                return RedirectToAction(nameof(About));
            }

            return View(settingVm);
        }

        #endregion
    }
}