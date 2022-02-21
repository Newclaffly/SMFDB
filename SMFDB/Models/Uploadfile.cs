using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMFDB.Models
{
    public class Uploadfile
    {
        public string FileCaption { set; get; }
        public string FileDescription { set; get; }
        public IFormFile MyImage { set; get; }
    }
}
