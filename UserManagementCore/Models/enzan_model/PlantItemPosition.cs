using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementCore.Models.enzan_model
{
    public class PlantItemPosition
    {
        public int site_id { get; set; }
        public int grid_row { get; set; }
        public int grid_column { get; set; }
        public int item_id { get; set; }
    }
}
