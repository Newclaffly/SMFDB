using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SMFDB.Controllers
{
    public class AfiveController : Controller
    {
        public IActionResult Main_afive_view()
        {
            return View();
        }
        public IActionResult Mrp_afive_view()
        {
            return View();
        }
        public IActionResult Project_action_plan_afive_view()
        {
            return View();
        }
    }
}
