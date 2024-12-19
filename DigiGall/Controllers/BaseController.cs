using DigiGall.Data;
using DigiGall.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DigiGall.Controllers
{
    public class BaseController : Controller
    {
        protected readonly ApplicationDbContext _dbContext;
        protected readonly UserContextService _userContextService;
        protected User? currentUser = null;

        public BaseController(UserContextService userContextService, ApplicationDbContext dbContext)
        {
            _userContextService = userContextService;
            _dbContext = dbContext;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var userId = HttpContext.Session.GetString("UserId");
            if (!string.IsNullOrEmpty(userId))
            {
                currentUser = _dbContext.User.FirstOrDefault(u => u.Id == userId);
                if (currentUser != null)
                {
                    _userContextService.Name = currentUser.Name;
                    _userContextService.Galleon = currentUser.Galleon;
                    _userContextService.Id = currentUser.Id;
                    _userContextService.Password = currentUser.Password;
                    _userContextService.Rank = currentUser.Rank;
                    _userContextService.Phone = currentUser.Phone;
                    _userContextService.House = currentUser.House;
                    _userContextService.UserQuestIds = currentUser.UserQuestIds;
                }
            };

            base.OnActionExecuting(context);
        }
    }
}
