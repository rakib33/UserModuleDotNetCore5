using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementCore.Models.enzan_model
{
    public class SlampHistory
    {
        public int site_id { get; set; }
        public DateTime recorded_at { get; set; }
        public double moisture_adjustment { get; set; }
        public double torque { get; set; }
        public double slamp { get; set; }
    }
}
