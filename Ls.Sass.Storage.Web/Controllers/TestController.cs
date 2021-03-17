using Ls.Sass.Storage.Web.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Ls.Sass.Storage.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TestController : ControllerBase
    {
        private readonly IDBCom _dBCom;

        public TestController(IDBCom dBCom)
        {
            _dBCom = dBCom;
        }

        [HttpGet]
        public IActionResult Trans()
        {
            var tt = _dBCom.Tjs_Company.GetById(20170659594240);

            return new JsonResult(tt);
        }
    }
}
