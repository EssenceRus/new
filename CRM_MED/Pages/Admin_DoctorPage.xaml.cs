using CRM_MED.Models;
using CRM_MED.Views;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Provider;
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
    /// Логика взаимодействия для Admin_DoctorPage.xaml
    /// </summary>
    public partial class Admin_DoctorPage : Page
    {
        public ObservableCollection<Doctor> doctors { get; set; }
        private int pageCountElements = 10;
        public double pagesCount;
        public int selectedPage = 1;
        public int doctorsCount;
        public Admin_DoctorPage()
        {
            InitializeComponent();
            var context = new CRMmedContext();
            doctors = new ObservableCollection<Doctor>(context.Doctors.Include(d => d.SpecialityNavigation).Take(pageCountElements));
            doctorsCount = context.Doctors.Count();
            pagesCount = Math.Ceiling((double)context.Doctors.Count()/pageCountElements);
            DbCountPageElements.Text = pagesCount.ToString();
            NumberPage.Text = selectedPage.ToString();
            DataContext = this;
        }

        private void AddDoctor(object sender, RoutedEventArgs e)
        {
            DoctorAddWindow daw = new DoctorAddWindow(null);
            daw.ShowDialog();
            if(daw.isUpdate)
            {
                doctors.Add(daw._currentDoctor);
            }
            
        }


        private void goToUpdateDoctor(object sender, RoutedEventArgs e)
        {
            DoctorAddWindow daw = new DoctorAddWindow((sender as Button).DataContext as Doctor);
            daw.ShowDialog();
            
        }

        

        private void search_textbox_changed(object sender, TextChangedEventArgs e)
        {
            if(doctors.Count()>0)
            {
                NumberPage.Text = "1";
                ApplyFilters();
            }
            
            
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

            if (doctors.Count() > 0)
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
            if (doctorsCount>1)
            {    
                doctors.Clear();
               
                if (selectedPage <= 1)
                {
                    selectedPage = 1;
                    NumberPage.Text = "1";
                }
                else if(selectedPage > pagesCount)
                {
                    selectedPage = (int)pagesCount;
                    NumberPage.Text = pagesCount.ToString();
                }
                var AllSearchDb = context.Doctors.Include(d=>d.SpecialityNavigation).Where(d => d.Surname.Contains(search_textBox.Text)).ToList();
                pagesCount = Math.Ceiling((double)AllSearchDb.Count() / pageCountElements);
                doctors =  new ObservableCollection<Doctor>(AllSearchDb.Skip((selectedPage - 1) * pageCountElements).Take(pageCountElements));
                DataContext = null;
                DataContext = this;
            }
            else
            {
                selectedPage = 1;
                NumberPage.Text = "1";
            }



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

        private void goToDoctorTimeTable(object sender, RoutedEventArgs e)
        {
           DoctorTimeTableWindow daw = new DoctorTimeTableWindow((sender as Button).DataContext as Doctor);
            daw.ShowDialog();
        }

        
    }
}
