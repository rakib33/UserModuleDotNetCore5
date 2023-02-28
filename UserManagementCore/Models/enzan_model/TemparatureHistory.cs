using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementCore.Models.enzan_model
{
    public class TemparatureHistory
    {
        public int site_id { get; set; }
        public DateTime recorded_at { get; set; }
        public int batch_number { get; set; }
        public double setting_temperature { get; set; }
        public double concrete_temperature { get; set; }
        public double sand_temperature { get; set; }
        public double gravel_temperature { get; set; }
        public double cement_temperature { get; set; }
        public double warm_water_temperature { get; set; }
        public double raw_water_temperature { get; set; }
        public double indoor_temperature { get; set; }
        public double outdoor_temperature { get; set; }
    }
}
