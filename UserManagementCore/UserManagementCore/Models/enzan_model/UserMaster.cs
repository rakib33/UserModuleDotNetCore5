using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementCore.Models.enzan_model
{
    public class UserMaster
    {
        [Key]
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int user_id { get; set; }

        [StringLength(50)]
        public string user_name { get; set; }

        [StringLength(50)]
        public string login_id { get; set; }

        [StringLength(50)]
        public string login_password { get; set; }

        [StringLength(50)]
        public string mail_address { get; set; }

        public int company_id { get; set; }

        /// <summary>
        /// 0= system admin
        /// 1= Normal admin
        /// </summary>
        public int authority { get; set; }
    }
}
    