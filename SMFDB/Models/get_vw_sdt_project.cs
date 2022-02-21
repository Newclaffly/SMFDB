using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SMFDB.Models
{
    public class get_vw_sdt_project
    {
        
       [Key]
        public int SF_No { get; set; }
        public string Project_Name { get; set; }
        // public IFormFile MyImage { get; set; }
        public string Dev_ID { get; set; }
        public string Owner { get; set; }
        public string FY { get; set; }
        public string Group { get; set; }
        public string Status { get; set; }
        public string Files_URL { get; set; }
        public string To_Do { get; set; }
        public string Files_ppt { get; set; }
        public string Files_img { get; set; }
        public string Job_Name { get; set; }
        public int TB_IS { get; set; }
        public int HTPS { get; set; }
        public int MOLED { get; set; }
        public int SMOLED { get; set; }
        public int LSI { get; set; }
        public int FFP { get; set; }
        public int TBBM { get; set; }

    }
}
