using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementCore.Models.enzan_model
{
    public class AnomalyMaster
    {
        public int site_id { get; set; }
        public int error_id { get; set; }

        [StringLength(50)]
        public string error_name { get; set; }
    }
}
