using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SMFDB.Controllers
{
    public class AtwoController : Controller
    {
        public IActionResult Main_atwo_view()
        {
            return View();
        }
        public IActionResult Mrp_atwo_view()
        {
            return View();
        }
        public IActionResult Project_action_plan_atwo_view()
        {
            return View();
        }
    }
}
