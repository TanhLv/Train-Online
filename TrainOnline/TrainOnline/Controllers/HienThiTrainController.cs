using Microsoft.AspNetCore.Mvc;
using TrainOnline.Data;

namespace TrainOnline.Areas.Controllers
{
    public class HienThiTrainController : Controller
    {
        private ApplicationDbContext _db;
        public HienThiTrainController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Train1()
        {
            var item = _db.Trains.ToList();
            return View("Train1", item);
        }

        public IActionResult LichTrinh()
        {
            var item = _db.Schedules.ToList();
            return View("LichTrinh", item);
        }
        
    }
}
