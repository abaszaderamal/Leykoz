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

namespace Leykoz.Business.Service.Implementations
{
    public class SlideService : ISlideService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _env;
        private string _erorrMessage;

        public SlideService(IUnitOfWork unitOfWork, IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _env = env;
        }

        public async Task<List<Slide>> GetAllAsync()
        {
            return await _unitOfWork.SilideRepository.GetAllAsync();
        }

        public async Task Create(SlidePostVM slideVm)
        {
            if (!ChechkImageValid(slideVm.FormFiles))
            {
                throw new Exception(_erorrMessage);
            }

            foreach (var photo in slideVm.FormFiles)
            {
                string filename = await photo.SaveFileAsync(_env.WebRootPath, "src", "img");
                await _unitOfWork.SilideRepository.CreateAsync(new Slide() {ImageFile = filename});
                await _unitOfWork.SaveAsync();
            }
        }


        public async Task Remove(int id)
        {
            Slide slide = await _unitOfWork.SilideRepository.GetAsync(p => p.Id == id);
            if (slide == null) throw new Exception("Slide not found");
            FileHelper.RemoveFile(_env.WebRootPath, slide.ImageFile, "src", "img");
            _unitOfWork.SilideRepository.Remove(slide);
            await _unitOfWork.SaveAsync();
        }


        private bool ChechkImageValid(List<IFormFile> photos)
        {
            foreach (var photo in photos)
            {
                if (!photo.CheckFileType("image/"))
                {
                    _erorrMessage = $"{photo.FileName} must be  image type ";
                    return false;
                }

                if (!photo.CheckFileSize(2048))
                {
                    _erorrMessage = $"{photo.FileName} size must be less than 2mb ";
                    return false;
                }
            }

            return true;
        }
    }
}