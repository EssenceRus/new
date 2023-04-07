using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_MED.Models
{
    public class DayOfWeek
    {
        [Key]
        public int DayOfWeekId { get; set; }

        [StringLength(100)]
        public string DayOfWeekName { get; set; }

        public virtual ICollection<WorkTime> WorkTimes { get; } = new List<WorkTime>();
    }
}
