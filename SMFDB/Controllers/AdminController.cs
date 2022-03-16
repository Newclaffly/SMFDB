using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SMFDB.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SMFDB.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly SQLQueryController _con_sql;
        private readonly IConfiguration config; // conection DB

        //DI
        public AdminController(ILogger<AdminController> logger, SQLQueryController _qr, IConfiguration config)
        {
            this._con_sql = _qr; _logger = logger; this.config = config;
        }
        public IActionResult Admin_panel_main_view()
        {
            return View();
        }
        public IActionResult Control_announcement()
        {
            return View();
        }
        /* PROJECT CONTROL */
        public IActionResult Control_sf_project()
        {
            ViewBag.Message = TempData["Message"];
            return View();
        }

        public IActionResult Control_sf_project_progress()
        {
            ViewBag.Message = TempData["Message"];
            return View();
        }

        public IActionResult Control_sf_concept()
        {
            ViewBag.Message = TempData["Message"];
            return View();
        }

        public IActionResult Control_sf_activity()
        {
            ViewBag.Message = TempData["Message"];
            return View();
        }

        public IActionResult Control_sf_organization()
        {
            ViewBag.Message = TempData["Message"];
            return View();
        }

        /* ZONE A9 */
        /* View */
        public IActionResult Control_sdt_anine_audit_customer_quality()
        {
            ViewBag.Message = TempData["Message"];
            return View();
        }

        public IActionResult Control_sdt_anine_audit_first_view()
        {
            ViewBag.Message = TempData["Message"];
            return View();
        }
        public IActionResult Control_sdt_anine_audit_second_view()
        {
            ViewBag.Message = TempData["Message"];
            return View();
        }
        public IActionResult Control_sdt_anine_audit_third_view()
        {
            ViewBag.Message = TempData["Message"];
            return View();
        }


        /* Method */

        /* ZONE Customer_Quality */
        [HttpPost]
        public IActionResult Add_file_upload_autdit_anine_customer_quality(IFormFile file_pdf)
        {
            Uploadfile tbl_News = new Uploadfile();
            if (file_pdf != null)
            {

                //Set Key Name
                var fileName = "Anine_customer_quality" + Path.GetExtension(file_pdf.FileName);

                //Get url To Save
                string SavePath = Path.Combine(Directory.GetCurrentDirectory(), "./wwwroot/PDF/QA_AX/A_nine/Customer_quality", fileName);

                using (var stream = new FileStream(SavePath, FileMode.Create))
                {
                    file_pdf.CopyTo(stream);
                }
                TempData["Message"] = "OK";
            }
            else
            {
                TempData["Message"] = "NOT_OK";
            }
            return RedirectToAction("Control_sdt_anine_audit_customer_quality", "Admin");
        }

        /* ZONE Audit_first */
        [HttpPost]
        public IActionResult Add_file_upload_autdit_anine_audit_first(IFormFile file_pdf)
        {
            Uploadfile tbl_News = new Uploadfile();
            if (file_pdf != null)
            {

                //Set Key Name
                var fileName = "Audit_anine_first_party" + Path.GetExtension(file_pdf.FileName);

                //Get url To Save
                string SavePath = Path.Combine(Directory.GetCurrentDirectory(), "./wwwroot/PDF/QA_AX/A_nine/Audit_first", fileName);

                using (var stream = new FileStream(SavePath, FileMode.Create))
                {
                    file_pdf.CopyTo(stream);
                }
                TempData["Message"] = "OK";
            }
            else
            {
                TempData["Message"] = "NOT_OK";
            }
            return RedirectToAction("Control_sdt_anine_audit_first_view", "Admin");
        }

        /*  Audit_second */
        [HttpPost]
        public IActionResult Add_file_upload_autdit_anine_audit_second(IFormFile file_pdf)
        {
            Uploadfile tbl_News = new Uploadfile();
            if (file_pdf != null)
            {

                //Set Key Name
                var fileName = "Audit_anine_second_party" + Path.GetExtension(file_pdf.FileName);

                //Get url To Save
                string SavePath = Path.Combine(Directory.GetCurrentDirectory(), "./wwwroot/PDF/QA_AX/A_nine/Audit_second", fileName);

                using (var stream = new FileStream(SavePath, FileMode.Create))
                {
                    file_pdf.CopyTo(stream);
                }
                TempData["Message"] = "OK";
            }
            else
            {
                TempData["Message"] = "NOT_OK";
            }
            return RedirectToAction("Control_sdt_anine_audit_second_view", "Admin");
        }

        /*  Audit_third */
        [HttpPost]
        public IActionResult Add_file_upload_autdit_anine_audit_third(IFormFile file_pdf)
        {
            Uploadfile tbl_News = new Uploadfile();
            if (file_pdf != null)
            {

                //Set Key Name
                var fileName = "Audit_anine_third_party" + Path.GetExtension(file_pdf.FileName);

                //Get url To Save
                string SavePath = Path.Combine(Directory.GetCurrentDirectory(), "./wwwroot/PDF/QA_AX/A_nine/Audit_third", fileName);

                using (var stream = new FileStream(SavePath, FileMode.Create))
                {
                    file_pdf.CopyTo(stream);
                }
                TempData["Message"] = "OK";
            }
            else
            {
                TempData["Message"] = "NOT_OK";
            }
            return RedirectToAction("Control_sdt_anine_audit_third_view", "Admin");
        }

        [HttpPost]
        public IActionResult get_list_option_sf_project()
        {
            var data = _con_sql._query("SELECT DISTINCT [SF_No],[Project_Name] FROM vw_project_detail");
            return data;
        }

        /*  Upload file SF Project */
        [HttpPost]
        public IActionResult add_file_upload_sf_project(IFormFile file_pdf, string topic_sf)
        {
            Uploadfile tbl_News = new Uploadfile();
            //var result_upload = "";
            if (file_pdf != null)
            {

                //Set Key Name
                var fileName = topic_sf + Path.GetExtension(file_pdf.FileName);

                //Get url To Save
                string SavePath = Path.Combine(Directory.GetCurrentDirectory(), "./wwwroot/PDF/SF_PROJECT/PROJECT", fileName);

                var data = _con_sql._query("UPDATE tbSF_Project SET Files_ppt = '/PDF/SF_PROJECT/PROJECT/" + fileName + "'  WHERE SF_No = '" + topic_sf + "' ");

                using (var stream = new FileStream(SavePath, FileMode.Create))
                {
                    //await files.CopyToAsync(stream);

                    file_pdf.CopyTo(stream);
                }
                TempData["Message"] = "OK";
            }
            else
            {
                TempData["Message"] = "NOT_OK";

            }
            return RedirectToAction("Control_sf_project", "Admin");
        }

        [HttpPost]
        public IActionResult get_data_news()
        {
            var data = _con_sql._query("SELECT * FROM tbSF_News");

            return data;
        }

        [HttpPost]
        public IActionResult update_data_news([FromBody] Params param)
        {
            var data = _con_sql._post_param2("[sp_annoucement_crud]", param.param1.ToString(), param.param2.ToString());
            return Ok(data);
        }

        [HttpPost]
        public IActionResult get_list_page_distinct()
        {
            var data = _con_sql._query("SELECT DISTINCT [flag_page] FROM tbSF_Control_Image WHERE [status_image] ='ACTIVE'");
            return data;
        }

        [HttpPost]
        public IActionResult get_list_img_project()
        {
            var data = _con_sql._query("SELECT DISTINCT [id],[image_url],[image_order],[flag_page] FROM tbSF_Control_Image WHERE [status_image] ='ACTIVE'");
            return data;
        }

        //list image each page
        [HttpPost]
        public async Task<IActionResult> Add_file_upload_img_page(IFormFile file_img, string flag_page, string id_row)
        {
            if (file_img != null)
            {
                //Set Key Name
                var fileName = flag_page + '_' + id_row + Path.GetExtension(file_img.FileName);

                //Get url To Save
                string SavePath = Path.Combine(Directory.GetCurrentDirectory(), "./wwwroot/img/img_control/" + flag_page + "", fileName);
                var path_sql = "/" + flag_page + "/" + fileName + "";
                _con_sql._query("UPDATE tbSF_Control_Image SET image_url = '" + path_sql + "' where id = '" + id_row + "' ");
                using (var stream = new FileStream(SavePath, FileMode.Create))
                {
                    await file_img.CopyToAsync(stream);

                    // file_img.CopyTo(stream);
                }
                TempData["Message"] = "OK";
            }
            else
            {
                TempData["Message"] = "NOT_OK";

            }
            return RedirectToAction("Control_sf_concept", "Admin");
        }


    }
}
