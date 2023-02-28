using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementCore.Models.enzan_model
{
    public class SiteMaster
    {
        [Key]
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int site_id { get; set; } 

        [StringLength(100)]
        public string site_name { get; set; }

        [StringLength(100)]
        public string contractor_name { get; set; }

        [StringLength(100)]
        public string jv_name { get; set; }

        [StringLength(50)]
        public string manager_name { get; set; }

        public int company_id { get; set; }
        public virtual CompanyMaster CompanyMaster { get; set; }
    }
}
