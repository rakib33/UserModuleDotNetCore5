using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementCore.Models.enzan_model
{
    public class HopperCapacityHistory
    {
        public int site_id { get; set; }
        public int hopper_id { get; set; }
        public DateTime recorded_at { get; set; }
        public int batch_number { get; set; }
        public bool is_delivery { get; set; }
        public double volume { get; set; }
        public double stock_volume { get; set; }
    }
}
