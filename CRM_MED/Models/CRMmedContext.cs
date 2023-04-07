using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CRM_MED.Models
{
    public class CRMmedContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }

        public DbSet<DayOfWeek> DayOfWeeks { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Gender> Genders { get; set; }

        public DbSet<MaterialType> MaterialTypes { get; set; }

        public DbSet<MedicalCard> MedicalCards { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Reception> Receptions { get; set; }

        public DbSet<Storage> Storages { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Unit> Units { get; set; }

        public DbSet<WorkTime> WorkTimes { get; set; }

        public DbSet<Speciality> Specialitys { get; set; }

        public DbSet<StorageLog> StorageLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-DETR887\\SQLEXPRESS;Database=CRM_MED_DataBase;integrated security=true;TrustServerCertificate=True");
        }
    }
}
