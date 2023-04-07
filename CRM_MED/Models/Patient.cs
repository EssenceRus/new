using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_MED.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Surname { get; set; }

        [StringLength(71)]
        public string Patronymic{ get; set; }

        public virtual Gender GenderCodeNavigation { get; set; } = null!;

        [StringLength(150)]
        public string PhoneNumber { get; set; }

        [StringLength(500)]
        public string ChronicDiseases { get; set; }

        [StringLength(15)]
        public string Passport { get; set; }

        [StringLength(25)]
        public string SNILS { get; set; }

        [StringLength(600)]
        public string PhotoPath { get; set; }

        [StringLength(32)]
        public string PolicyNumber { get; set; }

        [StringLength(400)]
        public string PlaceOfRegistration { get; set; }
        public DateTime BirthDay { get; set; }

        public virtual ICollection<MedicalCard> MedicalCards { get; } = new List<MedicalCard>();

        public virtual ICollection<Reception> Receptions { get; } = new List<Reception>();

        public virtual ICollection<StorageLog> StorageLogs { get; } = new List<StorageLog>();

    }
}
