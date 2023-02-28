using System.ComponentModel.DataAnnotations;

namespace UserManagementCore.Models
{
    public class Company : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [StringLength(150)]
        public string CompanyName { get; set; }

    }
}
