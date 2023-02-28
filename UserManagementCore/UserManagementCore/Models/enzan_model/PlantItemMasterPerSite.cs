using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementCore.Models.enzan_model
{
    public class PlantItemMasterPerSite
    {
        public int site_id { get; set; }
        public int item_id { get; set; }
        public string item_name { get; set; }
        public string unit { get; set; }
    }
}
