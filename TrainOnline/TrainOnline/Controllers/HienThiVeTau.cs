using Microsoft.AspNetCore.Mvc;
using TrainOnline.Data;

namespace TrainOnline.Controllers
{

    public class HienThiVeTau : Controller
    {
        public ApplicationDbContext _db;
        public HienThiVeTau(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult hienThiVe()
        {
            var item = _db.Tickets.ToList();
            return View("hienThiVe", item);
        }
    }
}
