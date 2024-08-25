using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics;
using WebTestCoreEntity.Data;
using WebTestCoreEntity.Models;

namespace WebTestCoreEntity.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            // ดึงข้อมูลจากตาราง Activities ใน SQL Server
            var chartData = _context.AssetType
                .Select(a => new { a.Code, a.sumInsurance })
                .ToList();

            // ส่งข้อมูลในรูปแบบ JSON ไปยัง View
            ViewData["ChartData"] = JsonConvert.SerializeObject(chartData);


            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
