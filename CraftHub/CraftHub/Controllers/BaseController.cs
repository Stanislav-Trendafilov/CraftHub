using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CraftHub.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {

    }
}
