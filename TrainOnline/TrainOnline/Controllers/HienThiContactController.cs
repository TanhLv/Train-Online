using Microsoft.AspNetCore.Mvc;
using TrainOnline.Data;

namespace TrainOnline.Controllers
{
	public class HienThiContactController : Controller
	{
		public ApplicationDbContext db;
		public HienThiContactController(ApplicationDbContext db)
		{
			db = db;
		}
		public IActionResult Index()
		{

			return View();
		}
	}
}
