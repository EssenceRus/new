using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_MED.Models
{
    public class Gender
    {
        [Key]
        public int GenderId { get; set; }

        [StringLength(3)]
        public string Code { get; set; } = null!;

        public virtual ICollection<Patient> Patients { get; } = new List<Patient>();
    }
}
