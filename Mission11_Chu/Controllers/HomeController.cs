using Microsoft.AspNetCore.Mvc;
using Mission11_Chu.Models;
using Mission11_Chu.Models.ViewModels;
using System.Diagnostics;

namespace Mission11_Chu.Controllers
{
    public class HomeController : Controller
    {
        private IBookRepo _context;

        public HomeController(IBookRepo temp)
        {
            _context = temp;
        }

        public IActionResult Index(int pageNum)
        {
            int pageSize = 10;

            var Blah = new BookListViewModel
            {
                Bookslist = _context.Books
                    .OrderBy(x => x.Title)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize),

                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = _context.Books.Count()
                }

            };

            return View(Blah);
        }



    }
}
