using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_MED.Models
{
    public class Speciality
    {
        [Key]
        public int SpecialityId { get; set; }

        [StringLength(200)]
        public string SpecialityTitle { get; set; }

        public virtual ICollection<Doctor> Doctors { get; } = new List<Doctor>();
    }
}
