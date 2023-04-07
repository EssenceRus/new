using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_MED.Models
{
    public class MaterialType
    {
        [Key]
        public int MaterialTypeId { get; set; }
        [StringLength(100)]
        public string MaterialTypeTitle { get; set; }

        public virtual ICollection<Storage> Storages { get; } = new List<Storage>();
        public virtual ICollection<Supplier> Suppliers { get; } = new List<Supplier>();
    }
}
