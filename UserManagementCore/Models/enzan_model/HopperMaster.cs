using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementCore.Models.enzan_model
{
    public class HopperMaster
    {
        public int site_id { get; set; }
        public int hopper_id { get; set; }
        public string hopper_name { get; set; }
        public double gross_volume { get; set; }
        public double current_volume { get; set; }
        public double sensor_value { get; set; }
    
    }
}
