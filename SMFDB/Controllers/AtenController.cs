using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SMFDB.Controllers
{
    public class AtenController : Controller
    {
        public IActionResult Main_aten_view()
        {
            return View();
        }
        public IActionResult Mrp_aten_view()
        {
            return View();
        }
        public IActionResult Project_action_plan_aten_view()
        {
            return View();
        }
    }
}
