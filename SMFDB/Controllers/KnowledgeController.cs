using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SMFDB.Models;

namespace SMFDB.Controllers
{
    public class KnowledgeController : Controller
    {
        private readonly ILogger<KnowledgeController> _logger;
        private readonly SQLQueryController _con_sql;
        private readonly IConfiguration config; // conection DB

        //DI
        public KnowledgeController(ILogger<KnowledgeController> logger, SQLQueryController _qr, IConfiguration config)
        {
            this._con_sql = _qr; _logger = logger; this.config = config;
        }
        public IActionResult Knowledge_center_view()
        {
            return View();
        }
 
        public IActionResult Detail_knowledge_center(string apply_id)
        {
            ViewBag.apply_id = apply_id;
            return View();
        }

        [HttpPost]
        public IActionResult get_knowleage_detail([FromBody] Params apply_id)
        {
            var data = _con_sql._query("SELECT DISTINCT [id],[project_no],[project_name],[project_description],[project_status],[file_ppt],[file_url] FROM tbSF_Knowleage_Center WHERE id = '" + apply_id.param1.ToString() + "' ");
            return data;
        }

        [HttpPost]
        public IActionResult get_vew_knowleage_project()
        {
            var data = _con_sql._query("SELECT DISTINCT * FROM tbSF_Knowleage_Center");

            return data;
        }

    }
}
