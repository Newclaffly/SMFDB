using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SMFDB.Controllers
{
    public class AthreeController : Controller
    {
        public IActionResult Main_athree_view()
        {
            return View();
        }
        public IActionResult Mrp_athree_view()
        {
            return View();
        }
        public IActionResult Project_action_plan_athree_view()
        {
            return View();
        }
    }
}
