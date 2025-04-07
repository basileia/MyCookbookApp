using LanguageExt;
using Microsoft.AspNetCore.Mvc;
using MyCookbook.Results;
using MyCookbook.Results.Errors;

namespace MyCookbook.Controllers
{
    public class BaseController : ControllerBase
    {
        public ActionResult GetResponse<T, TError>(Result<T, TError> result, string actionName = null, object routeValues = null)
        {
            if (result.Error is NotFoundError)
            {
                return NotFound(result.Error);
            }

            if (!result.IsSuccess)
            {
                return BadRequest(result.Error);
            }

            if (typeof(T) == typeof(Unit))
            {
                return NoContent();
            }

            if (actionName != null && routeValues != null)
            {
                return CreatedAtAction(actionName, routeValues, result.Value);
            }

            return Ok(result.Value);
        }
    }
}
