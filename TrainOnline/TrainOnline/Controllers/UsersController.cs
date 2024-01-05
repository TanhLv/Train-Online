using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainOnline.Data;
using TrainOnline.Models;

namespace TrainOnline.Controllers
{
    //[Authorize(Roles ="Admin")]
    public class UsersController : BaseeController
    {
        private readonly ApplicationDbContext _context;
        public UsersController(IHttpContextAccessor contextAccessor, UserManager<CustomUser> userName, RoleManager<IdentityRole> roleManager, ApplicationDbContext context) : base(contextAccessor, userName, roleManager)
        {
            _context= context;
        }

        public IActionResult Index()
        {
            var dsusser = _context.CustomUsers.ToList();
            return View(dsusser);
        }
        public async Task<IActionResult> ViewUpdate(string id)
        {
            var userCanTim = await _userName.FindByIdAsync(id);
            return PartialView(userCanTim);
        }

        [HttpPost]
        public async Task<IActionResult> doUpdate([Bind("Id,PhoneNumber,FullName,Email")] CustomUser user)
        {
            if (user != null)
            {
                var usercantim = await _userName.FindByIdAsync(user.Id);
                if (usercantim != null)
                {
                    usercantim.PhoneNumber = user.PhoneNumber;
                    usercantim.FullName = user.FullName;
                    //  usercantim.PhoneNumber = user.PhoneNumber;
                    usercantim.Email = user.Email;

                    await _userName.UpdateAsync(usercantim);
                    TempData["ThanhCong"] = "Cap Nhat Thanh Cong!";
                    return Redirect("/Users");

                }
            }
            return BadRequest();
        }

        public async Task<IActionResult> ViewSetRole(string id)
        {
            var userdcchon = await _userName.FindByIdAsync(id);
            var dsALLquyen = await _roleManager.Roles.ToListAsync();
            if (userdcchon != null)
            {
                var userRole = await _userName.GetRolesAsync(userdcchon);
                ViewBag.userRole = userRole.ToList();
                ViewBag.userId = id;
            }
            return View(dsALLquyen);
        }

        [HttpPost]
        public async Task<IActionResult> doSetRole(string userid, List<string> arrRole)
        {
            var userduocchon = await _userName.FindByIdAsync(userid);
            var dsAllQuyen = await _roleManager.Roles.ToListAsync();
            var arrstingQuyen = dsAllQuyen.Select(x => x.Name);
            if (userduocchon != null)
            {
                await _userName.RemoveFromRolesAsync(userduocchon, arrstingQuyen);
                await _userName.AddToRolesAsync(userduocchon, arrRole);

                TempData["ThanhCong"] = "Cap Nhat quyen Thanh Cong!";
                return Redirect("/Users");
            }
            return BadRequest();
        }
    }
}
