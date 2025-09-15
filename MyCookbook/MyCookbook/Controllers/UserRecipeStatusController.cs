using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCookbook.Data.Contracts.Services;

namespace MyCookbook.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserRecipeStatusController : BaseController
    {
        private readonly IUserRecipeStatusService _userRecipeStatusService;

        public UserRecipeStatusController(IUserRecipeStatusService userRecipeStatusService)
        {
            _userRecipeStatusService = userRecipeStatusService;
        }

    }
}
