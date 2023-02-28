using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementCore.Models.enzan_model
{
    public class MixingMaster
    {
        public int site_id { get; set; }
        public int composition_id { get; set; }

        [StringLength(50)]
        public string composition_name { get; set; }
    }
}
