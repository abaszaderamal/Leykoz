using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Leykoz.Business.Service.Interfaces;
using Leykoz.Business.Utilities;
using Leykoz.Business.Utilities.Helpers;
using Leykoz.Business.ViewModels;
using Leykoz.Core.Abstract;
using Leykoz.Core.Entities;
using Leykoz.Data.DAL;
using Microsoft.AspNetCore.Hosting;

namespace Leykoz.Business.Service.Implementations
{
    public class NewsService : INewsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _environment;


        public NewsService(IUnitOfWork unitOfWork, IWebHostEnvironment environment)
        {
            _unitOfWork = unitOfWork;
            _environment = environment;
        }

        public async Task Create(NewsPostVM newsPostVm)
        {
            string imageFile = await newsPostVm.Image.SaveFileAsync(_environment.WebRootPath, "src", "img");

            News news = new News
            {
                Name = newsPostVm.Name,
                Title = newsPostVm.Title,
                Contetnt = newsPostVm.Contetnt,
                CreatedDate = DateTime.Now,
                ImageFile = imageFile
            };
            await _unitOfWork.NewsRepository.CreateAsync(news);
            await _unitOfWork.SaveAsync();
        }

        public async Task Update(int id, NewsPutVM newsPutVm)
        {
            News dbNew = await _unitOfWork.NewsRepository
                .GetAsync(p => p.Id == id);
            // bool isExsistFile = true;
            // if (newsPutVm.Image == null)
            // {
            //     newsPutVm.ImageFile = dbNew.ImageFile;
            //     isExsistFile = false;
            // }
            if (newsPutVm.Image != null)
            {
                FileHelper.RemoveFile(_environment.WebRootPath, dbNew.ImageFile, "src", "img");
                string imageFile = await newsPutVm
                    .Image
                    .SaveFileAsync(_environment.WebRootPath, "src", "img");
                dbNew.ImageFile = imageFile;
            }

            dbNew.Name = newsPutVm.Name;
            dbNew.Title = newsPutVm.Title;
            dbNew.Contetnt = newsPutVm.Contetnt;
            dbNew.CreatedDate = DateTime.Now;
            _unitOfWork.NewsRepository.Update(dbNew);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            News dbNevs = await _unitOfWork.NewsRepository.GetAsync(p => p.Id == id);
            dbNevs.IsDeleted = true;
            await _unitOfWork.SaveAsync();
        }

        public async Task<News> DetailAsync(int id)
        {
            return await _unitOfWork.NewsRepository.GetAsync(p => p.Id == id);
        }

        public async Task<News> GetByIdAsync(int id)
        {
            return await _unitOfWork.NewsRepository.GetAsync(p => p.Id == id && p.IsDeleted == false);
        }

        public async Task<List<News>> GetLastNews(int count)
        {
            // var news = (await _unitOfWork.NewsRepository.GetPageCountAsync(10)) - 2;
            // return await _unitOfWork.NewsRepository.GetAllPaginatedAsync(news);
            return await _unitOfWork.NewsRepository.GetLastNews(count);
        }

        public async Task<Paginate<News>> GetAllPaginatedAsync(int page,int size)
        {
            // List<News> dbNews = await _context
            //     .News
            //     .OrderByDescending(p => p.Id)
            //     .AsNoTracking()
            //     .Where(p => p.IsDeleted == false)
            //     .Skip((page - 1) * 9)
            //     .Take(9)
            //     .ToListAsync();
            List<News> news = await _unitOfWork
                .NewsRepository
                .GetPaginatedByDesending(page, size,p=>p.IsDeleted==false);
            Paginate<News> paginateFast = new Paginate<News>()
            {
                Items =news,
                CurrentPage = page,
                AllPageCount = await _unitOfWork.NewsRepository.GetPageCountAsync(9)
            };
            return paginateFast;
        }


        // public async Task<int> getPageCount(int take)
        // {
        //     int count = await _context
        //         .News
        //         .AsNoTracking()
        //         .Where(p => p.IsDeleted == false).CountAsync();
        //     return (int) Math.Ceiling(((decimal) count / take));
        // }
    }
}