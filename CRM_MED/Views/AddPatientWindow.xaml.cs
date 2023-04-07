using CRM_MED.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CRM_MED.Views
{
    /// <summary>
    /// Логика взаимодействия для AddPatientWindow.xaml
    /// </summary>
    public partial class AddPatientWindow : Window
    {
        bool redact = false;
        public Gender Gender { get; set; }
        public List<Gender> genders { get; set; }
        public bool isUpdate = false;
        public Patient patient = new Patient();
        public AddPatientWindow()
        {
            InitializeComponent();
            var context = new CRMmedContext();
            genders = context.Genders.ToList();
            BtnText.Text = "Добавить";
            DataContext = this;
        }
        public AddPatientWindow(Patient pat)
        {
            InitializeComponent();
            var context = new CRMmedContext();
            BtnText.Text = "Изменить";
            FillTextBox(pat);
            genders = context.Genders.ToList();
            redact = true;
            DataContext = this;
        }
        public void FillTextBox(Patient pat)
        {
            var context = new CRMmedContext();
            name.Text = pat.Name;
            surname.Text = pat.Surname;
            patronymic.Text = pat.Patronymic;
            phone.Text = pat.PhoneNumber;
            hronick.Text = pat.ChronicDiseases;
            pass.Text = pat.Passport;
            snils.Text = pat.Passport;
            photo.Text = pat.PhotoPath;
            policy.Text = pat.PolicyNumber;
            reg.Text = pat.PlaceOfRegistration;
            birthday.Text = pat.BirthDay.ToString();
            //gender.SelectedItem = context.Genders.FirstOrDefault(g =>g.GenderId == pat.GenderCodeNavigation.GenderId);


        }


        private void AddBtn(object sender, RoutedEventArgs e)
        {
            if (grid.Children.OfType<TextBox>().Any(tb => tb.Text.Trim() == string.Empty) || phone.Text.Contains("_") )
            {
                MessageBox.Show("Заполнены не все поля");
            }
            else
            {
                var context = new CRMmedContext();

                {
                    patient.Name = name.Text;
                    patient.Surname = surname.Text;
                    patient.Patronymic = patronymic.Text;
                    patient.GenderCodeNavigation = Gender;
                    patient.PhoneNumber = phone.Text;
                    patient.ChronicDiseases = hronick.Text;
                    patient.Passport = pass.Text;
                    patient.SNILS = snils.Text;
                    patient.PhotoPath = photo.Text;
                    patient.PolicyNumber = policy.Text;
                    patient.PlaceOfRegistration = reg.Text;
                    patient.BirthDay = Convert.ToDateTime(birthday.Text);
                    context.Attach(Gender);
                    context.Patients.Add(patient);
                };
                if (redact == false)
                {

                    context.SaveChanges();
                    isUpdate = true;
                    Close();
                }
                else
                {
                    var pat = context.Patients.Where(p => p.Passport == pass.Text).FirstOrDefault();
                    pat.Name = name.Text;
                    pat.Surname = surname.Text;
                    pat.Patronymic = patronymic.Text;
                    pat.GenderCodeNavigation = Gender;
                    pat.PhoneNumber = phone.Text;
                    pat.ChronicDiseases = hronick.Text;
                    pat.Passport = pass.Text;
                    pat.SNILS = snils.Text;
                    pat.PhotoPath = photo.Text;
                    pat.PolicyNumber = policy.Text;
                    pat.PlaceOfRegistration = reg.Text;
                    pat.BirthDay = Convert.ToDateTime(birthday.Text);
                    //context.Attach(Gender);
                    context.Update(pat);
                    context.SaveChanges();

                    Close();
                }
            }
        }

        private void validNoNum(object sender, TextCompositionEventArgs e)
        {
            char inp = e.Text[0];
            if (inp < 'А' || inp > 'Я' && inp < 'а' || inp > 'я')
            {
                e.Handled = true;
            }
        }
    }
}
