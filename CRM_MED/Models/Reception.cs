using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_MED.Models
{
    public class Reception
    {
        [Key]
        public int ReceptionId { get; set; }

        public virtual Patient Patient { get; set; } = null!;

        public virtual Doctor Doctor { get; set; } = null!;

        public DateTime StartTime { get; set; }
    }
}
