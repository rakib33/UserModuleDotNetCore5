using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementCore.Models
{
    public class BaseEntity
    {
        //must save unix time
        [StringLength(36)]
        public string CreatedDate { get; set; } 

        [StringLength(450)]
        public string CreatedBy { get; set; }

        [StringLength(36)]
        public string UpdateDate { get; set; }

        [StringLength(450)]
        public string UpdateBy { get; set; }
    }
}
