using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static CraftHub.Core.Constants.RoleConstants;

namespace CraftHub.Areas.Admin.Controllers
{
    [Area(AreaName)]
    [Authorize(Roles = AdminRole)]
    public class AdminBaseController : Controller
    {

    }
}
