using Lazy.Captcha.Core;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace MatoriaForms.Api.Controllers;
[ApiController]
[Route("api/[controller]/[action]")]
public class CaptchaController(ICaptcha captcha, IHttpContextAccessor httpContextAccessor) : ControllerBase {

    public readonly string SessionSuffix = "Simple";

    // GET: api/captcha/get
    [HttpGet("{captchaId}")]
    [ActionName("get")]
    public ActionResult<string> Get(string captchaId) {
        var info = captcha.Generate(captchaId);
        return Ok(info.Base64);
    }
    // GET: api/captcha/get-image
    [HttpGet("{captchaId}")]
    [ActionName("get-image")]
    public ActionResult GetImage(string captchaId) {
        var info = captcha.Generate(captchaId);
        var stream = new MemoryStream(info.Bytes);

        return File(stream, "image/gif");
    }

    // POST: api/captcha/verify
    [HttpGet()]
    [ActionName("verify")]
    public bool Verify(string captchaId, string captchaCode) {
        return captcha.Validate(captchaId, captchaCode, false, false);
    }
}
