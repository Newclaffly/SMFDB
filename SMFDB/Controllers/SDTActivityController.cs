using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMFDB.Controllers
{
    public class SDTActivityController : Controller
    {
        public IActionResult Sdt_activity_view()
        {
            return View();
        }
    }
}
