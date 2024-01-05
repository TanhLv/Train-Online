using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TrainOnline.Models;

namespace TrainOnline.Controllers
{
    public class BaseeController: Controller
    {

        protected readonly IHttpContextAccessor _contextAccessor;
        protected readonly UserManager<CustomUser> _userName;
        protected readonly RoleManager<IdentityRole> _roleManager;
        

        private UserManager<CustomUser> userName;


        public BaseeController(IHttpContextAccessor contextAccessor, UserManager<CustomUser> userName, RoleManager<IdentityRole> roleManager)
        {
            _contextAccessor = contextAccessor;
            _userName = userName;
            _roleManager = roleManager;
        }

        protected async Task<CustomUser> GetCurrentUserAsync()
        {
            var currentUser = _contextAccessor.HttpContext.User;
            var ht = "";
            var userId = "";
            if (currentUser.Identity.IsAuthenticated)
            {
                ht = currentUser.Identity.Name;
                var Usertimthay = await _userName.FindByNameAsync(currentUser.Identity.Name);
                return Usertimthay;

            }
            return null;

        }
    }
}
