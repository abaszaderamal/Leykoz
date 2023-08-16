using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Leykoz.Business.Service.Interfaces;
using Leykoz.Business.Utilities;
using Leykoz.Business.Utilities.Helpers;
using Leykoz.Business.ViewModels;
using Leykoz.Core.Abstract;
using Leykoz.Core.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic;

namespace Leykoz.Business.Service.Implementations
{
    public class InfoSlideService : IInfoSlideService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _environment;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public InfoSlideService(IUnitOfWork unitOfWork, IWebHostEnvironment environment,
            IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _environment = environment;
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task<List<InfoSlide>> GetSlides(int page, int size)
        {
            return await _unitOfWork
                .InfoSlideRepository
                .GetAllPaginatedAsync(page, size, p => p.İsDeleted == false);
        }

        public async Task<InfoSlide> GetByIDAsync(int id)
        {
            return await _unitOfWork.InfoSlideRepository.GetAsync(p => p.Id == id && p.İsDeleted == false);
        }

        public async Task<Paginate<InfoSlide>> GetAllPaginatedAsync(int page)
        {
            List<InfoSlide> infoSlide = await _unitOfWork
                .InfoSlideRepository
                .GetPaginatedByDesending(page, 10, p => p.İsDeleted == false);

            Paginate<InfoSlide> result = new Paginate<InfoSlide>();
            result.Items = infoSlide;
            result.CurrentPage = page;
            result.AllPageCount = await getPageCount(10);
            return result;
            //jksdfjdjdsfjj
        }

        public async Task<int> getPageCount(int take)
        {
            List<InfoSlide> infoSlide = await _unitOfWork
                .InfoSlideRepository
                .GetAllAsync(p => p.İsDeleted == false);
            int productCount = infoSlide.Count;
            return (int)Math.Ceiling(((decimal)productCount / take));
        }

        public async Task Create(InfoSlidePostVM infoSlideVm)
        {
            string imageFile = await infoSlideVm.ImageFile.SaveFileAsync(_environment.WebRootPath, "src", "img");
            string imageName = "https://" + _httpContextAccessor.HttpContext.Request.Host.Value + "/src/img/" +
                               imageFile;
            InfoSlide infoSlide = new InfoSlide
            {
                FirstName = infoSlideVm.FirstName,
                LastName = infoSlideVm.LastName,
                Title = infoSlideVm.Title,
                Contetnt = infoSlideVm.Contetnt,
                MsgContetnt = infoSlideVm.MsgContetnt,
                CreatedDate = DateTime.Now,
                ImageFile = imageName,
                MsgTitleContetnt = infoSlideVm.MsgTitleContetnt
            };
            await _unitOfWork.InfoSlideRepository.CreateAsync(infoSlide);
            await _unitOfWork.SaveAsync();
        }

        public async Task Update(int id, InfoSlidePutVM infoSlideVm)
        {
            InfoSlide dbInfoSlide = await _unitOfWork.InfoSlideRepository
                .GetAsync(p => p.Id == id && p.İsDeleted == false);
            // bool isExsistFile = true;
            // if (infoSlideVm.Image == null)
            // {
            //     infoSlideVm.ImageFile = dbInfoSlide.ImageFile;
            //     isExsistFile = false;
            // }
            if (infoSlideVm.Image != null)
            {
                string resultRemoveImageUrl =
                    dbInfoSlide.ImageFile.Substring(17 + _httpContextAccessor.HttpContext.Request.Host.Value.Length);
                FileHelper.RemoveFile(_environment.WebRootPath, resultRemoveImageUrl, "src", "img");
                string imageFile = await infoSlideVm
                    .Image
                    .SaveFileAsync(_environment.WebRootPath, "src", "img");
                string imageName = "https://" + _httpContextAccessor.HttpContext.Request.Host.Value + "/src/img/" +
                                   imageFile;
                dbInfoSlide.ImageFile = imageName;
            }

            dbInfoSlide.FirstName = infoSlideVm.FirstName;
            dbInfoSlide.LastName = infoSlideVm.LastName;
            dbInfoSlide.Title = infoSlideVm.Title;
            dbInfoSlide.Contetnt = infoSlideVm.Contetnt;
            dbInfoSlide.MsgContetnt = infoSlideVm.MsgContetnt;
            dbInfoSlide.MsgTitleContetnt = infoSlideVm.MsgTitleContetnt;
            _unitOfWork.InfoSlideRepository.Update(dbInfoSlide);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            InfoSlide infoSlide = await _unitOfWork.InfoSlideRepository.GetAsync(p => p.Id == id);
            infoSlide.İsDeleted = true;
            await _unitOfWork.SaveAsync();
        }

        public async Task<List<InfoSlide>> GetAllAsync()
        {
            List<InfoSlide> infoSlide = await _unitOfWork.InfoSlideRepository.GetAllAsync();
            return infoSlide;
        }

        public async Task<List<InfoSlide>> GetAllRadAsync()
        {
            List<InfoSlide> infoSlides = await _unitOfWork
                .InfoSlideRepository.GetAllAsync(p => p.İsDeleted == false);
            List<InfoSlide> result = new List<InfoSlide>();
            for (int i = 0; i < infoSlides.Count; i++)
            {
                result.Add(new InfoSlide()
                {
                    Id = infoSlides[i].Id * 6,
                    FirstName = infoSlides[i].FirstName,
                    LastName = infoSlides[i].LastName,
                    Title = infoSlides[i].Title,
                    Contetnt = infoSlides[i].Contetnt,
                    CreatedDate = infoSlides[i].CreatedDate,
                    ImageFile = infoSlides[i].ImageFile,
                    MsgContetnt = infoSlides[i].MsgContetnt,
                    MsgTitleContetnt = infoSlides[i].MsgTitleContetnt
                });
            }

            result.Shuffle();
            return result;
        }
    }
}