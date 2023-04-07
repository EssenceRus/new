using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_MED.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        [StringLength(8)]
        public string Password { get; set; }
    }
}
