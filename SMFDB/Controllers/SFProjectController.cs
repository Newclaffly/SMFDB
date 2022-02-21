using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SMFDB.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SMFDB.Controllers
{
    public class SFProjectController : Controller
    {
        private readonly ILogger<SFProjectController> _logger;
        private readonly SQLQueryController _con_sql;
        private readonly IConfiguration config; // conection DB

        //DI
        public SFProjectController(ILogger<SFProjectController> logger, SQLQueryController _qr, IConfiguration config)
        {
            this._con_sql = _qr; _logger = logger; this.config = config;
        }

        public IActionResult Site_map_view()
        {
            return View();
        }

        public IActionResult Home_page_menu_view()
        {
            return View();
        }
        public IActionResult Sdt_porject_view()
        {
           
            return View();
        }
        public IActionResult Sdt_porject_progress_view()
        {
            return View();
        }

        public IActionResult Detail_project_view(string apply_id)
        {
            ViewBag.apply_id = apply_id;
            return View();
        }
        //public IActionResult get_receive_new()
        //{
        //    var data = _qr._sp("spl_receive_new");
        //    return data;
        //}
        //public IActionResult get_part_info()
        //{
        //    var data = _con_sql._query("select * from vew_Project");
        //     return data;
        //}
        [HttpPost]
        public IActionResult get_job_concern()
        {
            var data = _con_sql._query("SELECT Job_ID,Job_Name FROM tbSF_Master_JobConcern");

            return data;
        }
        [HttpPost]
        public IActionResult get_vew_porject()
        {
            var data = _con_sql._query("SELECT * FROM vw_detail_coverage WHERE Job_Name != 'YIELD'");

            //var data = _con_sql._query("select * from vew_Project where Job_Name is not null and Job_Name != 'YIELD'");
            return data;
        }

        [HttpPost]
        public IActionResult get_vew_porject_list()
        {
            var data = _con_sql._query("SELECT SF_No,TB_IS,HTPS,MOLED,SMOLED,LSI,FFP,TBBM FROM vew_Project WHERE Job_Name != 'YIELD'");

            //var data = _con_sql._query("select * from vew_Project where Job_Name is not null and Job_Name != 'YIELD'");
            return data;
        }

        [HttpPost]
        public IActionResult mst_biz_view()
        {
            var data = _con_sql._query("SELECT DISTINCT Biz FROM tbSF_JobConcern_Biz WHERE Biz IS NOT NULL ");

            //var data = _con_sql._query("select * from vew_Project where Job_Name is not null and Job_Name != 'YIELD'");
            return data;
        }

        [HttpPost]
        public IActionResult get_project_detail([FromBody] Params apply_id)
        {
            var data = _con_sql._query("SELECT DISTINCT [SF_No],[Project_Name],[Dev_ID],[Owner],[FY],[Group],[Status],[Files_URL],[To_Do],[Files_ppt],[Files_img],[Video_URL],[Dev_Name],[Incharge] FROM vw_project_detail WHERE SF_No = '" + apply_id.param1.ToString() + "' ");
            return data;
        }

        [HttpPost]
        public IActionResult get_data_news_annoucement()
        {
            var data = _con_sql._query("SELECT * FROM tbSF_News ");

            //var data = _con_sql._query("select * from vew_Project where Job_Name is not null and Job_Name != 'YIELD'");
            return data;
        }

        // [HttpGet]
        // GET: Movies/Details/5
        //public IActionResult Details()
        //{
        //    //if (id == null)
        //    //{
        //    //    return NotFound();
        //    //}

        //    var data = _context.get_vw_sdt_project
        //                .Where(m => m.SF_No == 1)
        //                .ToList();

        //    //var list = await data.ToListAsync().ConfigureAwait(false); // <-- notice the `await` here. And always use `ConfigureAwait`.

        //    //if (data == null)
        //    //{
        //    //    return NotFound();
        //    //}
        //    // return Json(Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(data));
        //    //return Json(new { result = data.ToString() });
        //    //return Json(new { name = "Fabio", age = 42, gender = "M" });
        //    return Json(data);
        //}

        //public JsonResult get_storage()
        //{
        //    var data = _qr._query(" select * from tbSF_JobConcern_Biz");
        //    return data;
        //}
        //public async Task<List<BalanceItemResource>> GetBalanceItems(int fyId)
        //{
        //    var query = // Ensure `query` is `IQueryable<T>` instead of using `IEnumerable<T>`. But this code has to use `var` because its type-argument is an anonymous-type.
        //        from r1 in _context.Requests
        //        join u1 in _context.Users
        //        on r1.ApproverId equals u1.Id
        //        join p1 in _context.Purchases
        //        on r1.PurchaseId equals p1.Id
        //        join o1 in _context.OfficeSymbols
        //        on u1.Office equals o1.Name
        //        where r1.FYId == fyId
        //        select new
        //        {
        //            r1.Id,
        //            p1.PurchaseDate,
        //            officeId = o1.Id,
        //            officeName = o1.Name,
        //            o1.ParentId,
        //            o1.Level,
        //            total = r1.SubTotal + r1.Shipp
        //        };

        //    var list = await query.ToListAsync().ConfigureAwait(false); // <-- notice the `await` here. And always use `ConfigureAwait`.

        //    // Convert the anonymous-type values to `BalanceItemResource` values:
        //    return list
        //        .Select(r => new BalanceItemResource()
        //        {
        //            PurchaseDate = p1.PurchaseDate,
        //            officeId = o1.Id,
        //            officeName = o1.Name,
        //            ParentId = o1.ParentId,
        //            Level = o1.Level,
        //            total = r1.SubTotal + r1.Shipp
        //        })
        //        .ToList();
        //}
    }
}
