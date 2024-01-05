using Microsoft.AspNetCore.Mvc;
using TrainOnline.Data;

namespace TrainOnline.ViewComponents
{
    public class Trains : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public Trains(ApplicationDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var item = _context.Trains.ToList();
            return View(item);
        }
    }
}
