using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_MED.Models
{
    public class Unit
    {
        [Key]
        public int UnitId { get; set; }

        [StringLength(50)]

        public string UnitName { get; set; }

        public virtual ICollection<Storage> Storages { get; } = new List<Storage>();
    }
}
