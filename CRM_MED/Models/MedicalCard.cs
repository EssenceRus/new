using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_MED.Models
{
    public class MedicalCard
    {
        [Key]
        public int MedicalCardId { get; set; }

        public DateTime DateOfCompletion { get; set; }

        [StringLength(153)]
        public string Complaints { get; set; }

        [StringLength(150)]
        public string Diagnosis { get; set; }

        [StringLength(800)]
        public string CourseOfTreatment { get; set; }

        [StringLength(300)]
        public string DoctorComment { get; set; }

        [StringLength(300)]
        public string Treatment { get; set; }

        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }

        public virtual Doctor Doctor { get; set; } = null!;

    }
}
