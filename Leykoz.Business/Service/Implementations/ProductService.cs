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
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _environment;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProductService(IUnitOfWork unitOfWork, IWebHostEnvironment environment,
            IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _environment = environment;
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task Create(ProductVM productVm)
        {
            string imageFile = await productVm.Photo.SaveFileAsync(_environment.WebRootPath, "src", "img");
            // string imageName = "https://" + _httpContextAccessor.HttpContext.Request.Host.Value + "/src/img/" +
            //                    imageFile; https
            string imageName = "https://" + _httpContextAccessor.HttpContext.Request.Host.Value + "/src/img/" +
                               imageFile; //http
            Product product = new Product()
            {
                Title = productVm.Title,
                Description = productVm.Description,
                CreatedAt = DateTime.Now,
                Count = productVm.Count,
                Price = productVm.Price,
                ImageURL = imageName
                // Discount = !productVm.Discount,
                // DiscountPercent = productVm.DiscountPercent
            };
            await _unitOfWork.ProductRepository.CreateAsync(product);
            await _unitOfWork.SaveAsync();
        }

        public async Task Update(int id, ProductUpdateVM productVm)
        {
            Product dbProduct = await _unitOfWork.ProductRepository
                .GetAsync(p => p.Id == id);
            // bool isExsistFile = true;
            // if (productVm.Photo == null)
            // {
            //     productVm.ImageURL = dbProduct.ImageURL;
            //     isExsistFile = false;
            // }
            if (productVm.Photo != null)
            {
                // string resultRemoveImageUrl =
                //     dbProduct.ImageURL.Substring(17 + _httpContextAccessor.HttpContext.Request.Host.Value
                //         .Length); // https
                string resultRemoveImageUrl =
                    dbProduct.ImageURL.Substring(17 + _httpContextAccessor.HttpContext.Request.Host.Value.Length); //http


                FileHelper.RemoveFile(_environment.WebRootPath, resultRemoveImageUrl, "src", "img");
                string imageFile = await productVm
                    .Photo
                    .SaveFileAsync(_environment.WebRootPath, "src", "img");
                string imageName = "https://" + _httpContextAccessor.HttpContext.Request.Host.Value + "/src/img/" +
                                   imageFile; //https
                // string imageFile = await productVm
                //     .Photo
                //     .SaveFileAsync(_environment.WebRootPath, "src", "img");
                // string imageName = "http://" + _httpContextAccessor.HttpContext.Request.Host.Value + "/src/img/" +
                //                    imageFile; //http
                dbProduct.ImageURL = imageName;
            }

            dbProduct.Title = productVm.Title;
            // dbProduct.Discount = !productVm.Discount;
            dbProduct.Description = productVm.Description;
            dbProduct.Price = productVm.Price;
            dbProduct.Count = productVm.Count;
            // dbProduct.DiscountPercent = productVm.DiscountPercent;
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Product dbProduct = await _unitOfWork.ProductRepository.GetAsync(p => p.Id == id);
            dbProduct.IsDeleted = true;
            await _unitOfWork.SaveAsync();
        }

        public async Task<Paginate<Product>> GetAllPaginatedAsync(int page)
        {
            List<Product> products = await _unitOfWork
                .ProductRepository
                .GetAllPaginatedDesendingAsync(page, 10, p => p.IsDeleted == false);

            Paginate<Product> result = new Paginate<Product>();
            result.Items = products;
            result.CurrentPage = page;
            result.AllPageCount = await getPageCount(10);
            return result;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            List<Product> products = await _unitOfWork
                .ProductRepository.GetAllAsync();
            return products;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _unitOfWork.ProductRepository.GetAsync(p => p.Id == id && p.IsDeleted == false);
        }

        public async Task<List<Product>> GetAllRadAsync()
        {
            List<Product> products = await _unitOfWork
                .ProductRepository.GetAllByDesendingAsync();

            List<Product> result = new List<Product>();
            for (int i = 0; i < products.Count; i++)
            {
                result.Add(new Product()
                {
                    Id = products[i].Id * 6,
                    Title = products[i].Title,
                    Description = products[i].Description,
                    Count = products[i].Count,
                    CreatedAt = products[i].CreatedAt,
                    Price = products[i].Price,
                    ImageURL = products[i].ImageURL
                });
            }

            // result.Shuffle();
            return result;
        }

        public async Task<int> getPageCount(int take)
        {
            List<Product> products = await _unitOfWork
                .ProductRepository
                .GetAllAsync(p => p.IsDeleted == false);
            int productCount = products.Count;
            return (int)Math.Ceiling(((decimal)productCount / take));
        }
    }
}