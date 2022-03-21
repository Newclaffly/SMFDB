using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SMFDB.Controllers
{
    public class AfourController : Controller
    {
        public IActionResult Main_afour_view()
        {
            return View();
        }
        public IActionResult Mrp_afour_view()
        {
            return View();
        }
        public IActionResult Project_action_plan_afour_view()
        {
            return View();
        }
    }
}
