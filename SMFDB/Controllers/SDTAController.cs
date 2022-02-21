using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SMFDB.Controllers
{
    public class SDTAController : Controller
    {
        public IActionResult Sdt_ax_main_view()
        {
            return View();
        }
    }
}
