using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_MED.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }

        [StringLength(150)]
        public string CompanyName { get; set; }

        [StringLength(150)]
        public string PhoneNumber { get; set; }

        public virtual MaterialType MaterialTypeNavigation { get; set; }

    }
}
