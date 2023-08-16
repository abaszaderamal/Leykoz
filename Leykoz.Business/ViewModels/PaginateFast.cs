using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Leykoz.Business.ViewModels
{
    public class PaginateFast<T>
    {
        public PaginateFast()
        {
        }

        public PaginateFast(List<T> items, int currentPage, int pageCount, int allPageCount)
        {
            Items = items;
            CurrentPage = currentPage;
            PageCount = pageCount;
            AllPageCount = allPageCount;
        }

        public List<T> Items { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }

        public int AllPageCount { get; set; }

        //for post some data
        public T Item { get; set; }
        public string search { get; set; }
        public string IsNumber { get; set; }
        public string IsFullName { get; set; }
        public string IsEmail { get; set; }
    }
}