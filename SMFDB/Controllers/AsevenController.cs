using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SMFDB.Controllers
{
    public class AsevenController : Controller
    {
        public IActionResult Main_aseven_view()
        {
            return View();
        }
        public IActionResult Mrp_aseven_view()
        {
            return View();
        }
        public IActionResult Project_action_plan_aseven_view()
        {
            return View();
        }
    }
}
