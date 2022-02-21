using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMFDB.Controllers
{
    public class SFogzController : Controller
    {
        public IActionResult Sfogz_view()
        {
            return View();
        }
    }
}
