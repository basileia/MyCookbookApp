using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyCookbook.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MealPlansController : BaseController
    {
        
    }
}
