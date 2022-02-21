using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMFDB.Controllers
{
    public class SDTConceptController : Controller
    {
        public IActionResult Sdt_concept_view()
        {
            return View();
        }
    }
}
