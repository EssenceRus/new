
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_MED.Models
{
    public class WorkTime
    {
        [Key]
        public int WorkTimeId { get; set; }

        public virtual DayOfWeek DayNavigation { get; set; } = null!;

        public string WorkStart { get; set; }

        public string WorkEnd { get; set; }

        public bool IsWorking { get; set; }

        public string LunchStart { get; set;}

        public string LunchEnd { get; set;}

        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        

    }
}
