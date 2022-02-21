using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMFDB.Controllers
{
    public class SDTDashboardController : Controller
    {
        public IActionResult Sdt_dashboard_view()
        {
            return View();
        }
    }
}
