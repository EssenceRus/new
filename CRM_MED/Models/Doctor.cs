using Azure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_MED.Models
{
    public class Doctor : IDataErrorInfo
    {
        public string this[string columnName]
        {
            get
            {
                string result = string.Empty;
                using (var context = new CRMmedContext())
                {

                    switch (columnName)
                    {
                        case "PhoneNumber":
                            if(PhoneNumber == null)
                            {
                                result = "Вместо место \"x\" должны быть цифры!";
                            }
                            if(PhoneNumber != null)
                            {
                                if (PhoneNumber.Contains('x'))
                                {
                                    result = "Вместо место \"x\" должны быть цифры!";
                                }
                                
                            }
                            break;
                        case "Name":
                            if(Name == null)
                            {
                                result = "Имя не должны быть пустым";
                            }
                            if(Name != null)
                            {
                                foreach(var n in Name)
                                {
                                    
                                    if(char.IsDigit(n))
                                    {
                                        result = "Имя не должно содержать цифры";
                                    }
                                }
                                if (string.IsNullOrWhiteSpace(Name))
                                {
                                    result = "Имя не должны быть пустым";
                                }

                            }
                            break;
                        case "Surname":
                           
                           if(Surname == null) 
                           {
                                result = "Фамилия не должна быть пустой";
                           }

                           if (Surname != null)
                           {
                                foreach (var n in Surname)
                                {
                                   
                                    if (char.IsDigit(n))
                                    {
                                        result = "Фамилия не должна содержать цифры";
                                    }

                                }
                                if (string.IsNullOrWhiteSpace(Surname))
                                {
                                    result = "Фамилия не должна быть пустой";
                                }

                            }
                            break;
                        case "Patronymic":
                            if (Patronymic == null)
                            {
                                result = "Отчество не должно быть пустым";
                            }
                            if (Patronymic != null)
                            {
                                foreach (var n in Patronymic)
                                {
                                    //if (n < 'А' || n > 'Я' && n < 'а' || n > 'я')
                                    //{
                                    //    result = "Отчечтво должно содержать только русские буквы";
                                    //}
                                    if (char.IsDigit(n))
                                    {
                                        result = "Отчество не должно содержать цифры";
                                    }
                                    
                                }
                                if (string.IsNullOrWhiteSpace(Patronymic))
                                {
                                    result = "Отчество не должно быть пустым";
                                }

                            }
                            break;
                        case "Login":
                            if (Login == null)
                            {
                                result = "Логин не должен быть пустым";
                            }
                            if (Login != null)
                            {
                             
                                if (Login.Length < 4)
                                {
                                    result = "Логин должен состоять минимум из 4 символов";
                                }
                                foreach (var n in Login)
                                {
                                    if (!char.IsDigit(n)&&n < 'A' || n > 'Z' && n < 'a' || n > 'z')
                                    {
                                        result = "Логин должен содержать только латинские буквы и цифры";
                                    }
                                }

                            }
                            break;
                        case "Password":
                            if (Password == null)
                            {
                                result = "Пароль не должен быть пустым";
                            }
                            if (Password != null)
                            {

                                if (Password.Length < 4)
                                {
                                    result = "Пароль должен состоять минимум из 4 символов";
                                }
                                foreach (var n in Password)
                                {
                                    if (!char.IsDigit(n) && n < 'A' || n > 'Z' && n < 'a' || n > 'z')
                                    {
                                        result = "Пароль должен содержать только латинские буквы и цифры";
                                    }
                                }

                            }
                            break;
                        case "Email":
                            if (Email == null)
                            {
                                result = "Email не должен быть пустым";
                            }
                            if(Email != null)
                            {
                                var trimmedEmail = Email.Trim();
                                if (trimmedEmail.EndsWith("."))
                                {
                                    return "Email не должен заканчиваться на \".\"";
                                }
                                try
                                {
                                    var addr = new System.Net.Mail.MailAddress(Email);
                                    
                                }
                                catch
                                {
                                    return "Формат Email не верный!";
                                }
                            }
                            break;
                    }
                    return result;
                }
            }
        }

        [Key]
        public int DoctorId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Surname { get; set; }

        [StringLength(71)]
        public string Patronymic { get; set; }
        [StringLength(150)]
        public string PhoneNumber { get; set; }

        [StringLength(150)]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(15)]
        public string Login { get; set; }

        [StringLength(8)]
        public string Password { get; set; }
        
        [StringLength(600)]
        public string? PhotoPath { get; set; }


        public virtual Speciality SpecialityNavigation { get; set; } = null!;

        public virtual ICollection<MedicalCard> MedicalCards { get; } = new List<MedicalCard>();

        public virtual ICollection<Reception> Receptions { get; } = new List<Reception>();

        public virtual ICollection<StorageLog> StorageLogs { get; } = new List<StorageLog>();

        public virtual ICollection<WorkTime> WorkTimes { get; } = new List<WorkTime>();


        public string Error
        {
            get { return null; }
        }
    }
}
