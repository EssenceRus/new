using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_MED.Models
{
    public class Storage
    {
        [Key]
        public int StorageId { get; set; }

        [StringLength(100)]
        public string MaterialName { get; set; }

        public virtual MaterialType MaterialTypeNavigation { get; set; }

        public virtual Unit UnitNavigation { get; set; }

        public int Count { get; set; }

        public DateTime ExpirationDate { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<StorageLog> StorageLogs { get; } = new List<StorageLog>();



    }
}
