using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SMFDB.Controllers
{
    public class AsixController : Controller
    {
        public IActionResult Main_asix_view()
        {
            return View();
        }
        public IActionResult Mrp_asix_view()
        {
            return View();
        }
        public IActionResult Project_action_plan_asix_view()
        {
            return View();
        }
    }
}
