using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementCore.Models.enzan_model
{
    public class CompanyMaster
    {
        [Key]
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int company_id { get; set; } 

        [StringLength(50)]
        public string company_name { get; set; }

        public virtual List<SiteMaster> SiteMasters { get; set; }
    }
}
