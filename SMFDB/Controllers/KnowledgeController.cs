using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SMFDB.Controllers
{
    public class KnowledgeController : Controller
    {
        public IActionResult Knowledge_center_view()
        {
            return View();
        }
    }
}
