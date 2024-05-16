using Microsoft.AspNetCore.Mvc;

namespace MatoriaForms.Api.Controllers;
[ApiController]
[Route("api/[controller]/[action]")]
public class GeneralController : Controller {
    // GET/POST: api/general/submit
    [ActionName("submit")]
    public ActionResult<string> Submit() {
        return Ok();
    }
}
