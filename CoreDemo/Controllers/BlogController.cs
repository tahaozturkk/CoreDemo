using BusinessLayer.Concrete;
using BusinessLayer.EntityFramework;
using DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CoreDemo.Controllers
{
    public class BlogController : Controller
    {
        readonly IConfiguration _configuration;
        public BlogController(IConfiguration configuration )
        {
            _configuration = configuration;
        }
        BlogManager bm = new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {
            var v1 = _configuration.GetSection("Isim");
            var values = bm.GetBlogListWithCategory();
            return View(values);
        }
        public IActionResult BlogReadAll(int id)
        {
            var values = bm.GetBlogById(id);
            return View(values);
        }
    }
}
