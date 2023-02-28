using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementCore.Models.enzan_model
{
    public class PlantAlartHistory
    {
        public int site_id { get; set; }
        public DateTime recorded_at { get; set; }
        public int batch_number { get; set; }
        public int composition_id { get; set; }

        public bool is_power_on { get; set; }
        public bool is_mixer_rotating { get; set; }
        public bool is_auto_operating { get; set; }
        public int error_id { get; set; }
    }
}
