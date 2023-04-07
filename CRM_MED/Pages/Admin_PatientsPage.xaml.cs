using CRM_MED.Models;
using CRM_MED.Views;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CRM_MED.Pages
{
    /// <summary>
    /// Логика взаимодействия для Admin_PatientsPage.xaml
    /// </summary>
    public partial class Admin_PatientsPage : Page
    {
        public ObservableCollection<Patient> patients { get; set; }
        public double pagesCount;
        public int selectedPage = 1;
        public int patientsCount;
        private int pageCountElements = 10;
        public Admin_PatientsPage()
        {
            InitializeComponent();
            var context = new CRMmedContext();
            patientsCount = context.Patients.Count();
            patients = new ObservableCollection<Patient>(context.Patients.Include(cs => cs.GenderCodeNavigation).ToList().OrderBy(p => p.Surname).Take(pageCountElements));
            
            
            pagesCount = Math.Ceiling((double)context.Patients.Count() / pageCountElements);
            DbCountPageElements.Text = pagesCount.ToString();
            NumberPage.Text = selectedPage.ToString();
            LViewPatient.ItemsSource = patients;
        }
        private void TBFind_change(object sender, TextChangedEventArgs e)
        {
            var context = new CRMmedContext();
            //var patients = context.Patients.Where(p => p.Surname.ToLower().Contains(TBFind.Text.ToLower())).ToList();
            LViewPatient.ItemsSource = patients;
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            AddPatientWindow add = new AddPatientWindow();
            add.Show();
        }

        private void SC(object sender, SelectionChangedEventArgs e)
        {
            var context = new CRMmedContext();
            var item = (ListView)sender;
            var pat = (Patient)item.SelectedItem;
            //var patient = context.Patients.Where(p => p.Name == pat.Name).ToList();

            PatienDialogWindow infoPatient = new PatienDialogWindow();
            infoPatient.ShowDialog();

            bool? selected = infoPatient.select;
            if (selected == true)
            {
                AddPatientWindow apw = new AddPatientWindow(pat);
                apw.ShowDialog();
                ApplyFilters();
            }
             if (selected == false)
            {
                ReceptionWindow receptionWindow = new ReceptionWindow(pat);
                receptionWindow.ShowDialog();
                
            }

        }

        private void search_textbox_changed(object sender, TextChangedEventArgs e)
        {
            
                NumberPage.Text = "1";
                ApplyFilters();
            
        }

        private void GoToBackPageElements(object sender, RoutedEventArgs e)
        {
            int NumberPageInt = int.Parse(NumberPage.Text) - 1;
            selectedPage = NumberPageInt;
            NumberPage.Text = NumberPageInt.ToString();
        }

        private void GoToNextPageElements(object sender, RoutedEventArgs e)
        {
            int NumberPageInt = int.Parse(NumberPage.Text) + 1;
            selectedPage = NumberPageInt;
            NumberPage.Text = NumberPageInt.ToString();
        }

        private void NumberPage_previewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox tbne = sender as TextBox;
            if ((!Char.IsDigit(e.Text, 0)) && (e.Text != ","))
            {
                { e.Handled = true; }
            }
            else
                if ((e.Text == ",") && ((tbne.Text.IndexOf(",") != -1) || (tbne.Text == "")))
            { e.Handled = true; }
        }

        private void PageElements_textbox_changed(object sender, TextChangedEventArgs e)
        {
            if (patients.Count() > 0)
            {
                if (NumberPage.Text != string.Empty)
                {
                    selectedPage = int.Parse(NumberPage.Text);
                    ApplyFilters();
                }
            }
        }

        private void ApplyFilters()
        {
            var context = new CRMmedContext();
            if (patientsCount > 1)
            {
                patients.Clear();

                if (selectedPage <= 1)
                {
                    selectedPage = 1;
                    NumberPage.Text = "1";
                }
                else if (selectedPage > pagesCount)
                {
                    selectedPage = (int)pagesCount;
                    NumberPage.Text = pagesCount.ToString();
                }
                var AllSearchDb = context.Patients.Where(d => d.Surname.Contains(search_textBox.Text)).ToList();
                pagesCount = Math.Ceiling((double)AllSearchDb.Count() / pageCountElements);
                patients = new ObservableCollection<Patient>(AllSearchDb.Skip((selectedPage - 1) * pageCountElements).Take(pageCountElements));
                LViewPatient.ItemsSource = patients;
                DataContext = null;
                DataContext = this;
            }
            else
            {
                selectedPage = 1;
                NumberPage.Text = "1";
            }



        }

        private void GoToBackPageElementsTen(object sender, RoutedEventArgs e)
        {
            int NumberPageInt = int.Parse(NumberPage.Text) - 10;
            selectedPage = NumberPageInt;
            NumberPage.Text = NumberPageInt.ToString();
        }

        private void GoToNextPageElementsTen(object sender, RoutedEventArgs e)
        {
            int NumberPageInt = int.Parse(NumberPage.Text) + 10;
            selectedPage = NumberPageInt;
            NumberPage.Text = NumberPageInt.ToString();
        }

        private void AddPatient(object sender, RoutedEventArgs e)
        {
            var context = new CRMmedContext();
            AddPatientWindow apw = new AddPatientWindow();
            apw.ShowDialog();

            if (apw.isUpdate)
            {
                
                patients.Add(apw.patient);
            }
        }
    }
}
