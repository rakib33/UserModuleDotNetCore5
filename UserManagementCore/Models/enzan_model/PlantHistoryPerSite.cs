using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementCore.Models.enzan_model
{
    public class PlantHistoryPerSite
    {
        public int site_id { get; set; }
        public int item_id { get; set; }
        public DateTime recorded_at { get; set; }
        public int batch_number { get; set; }
        public int composition_id { get; set; }
        public double volume { get; set; } = 0;
        public double item_value { get; set; } = 0;
    }
}
