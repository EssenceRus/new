using CRM_MED.Models;
using CRM_MED.Pages;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CRM_MED.Views
{
    /// <summary>
    /// Логика взаимодействия для DoctorAddWindow.xaml
    /// </summary>
    public partial class DoctorAddWindow : Window
    {


        public List<Models.DayOfWeek> DayOfWeekList { get; set; }

        public Doctor _currentDoctor = new Doctor();

        public string? path = null;

        private int errorCount = 0;

        public bool isUpdate = false;

        public DoctorAddWindow(Doctor doctor)
        {

            InitializeComponent();

            

            var context = new CRMmedContext();
            DayOfWeekList = context.DayOfWeeks.ToList();
            spec.ItemsSource = context.Specialitys.ToList();
            if (doctor != null)
            {
                _currentDoctor = doctor;
                spec.SelectedItem = context.Specialitys.FirstOrDefault(s => s.SpecialityId == _currentDoctor.SpecialityNavigation.SpecialityId);
                
            }
            else
            {
                _currentDoctor.SpecialityNavigation = context.Specialitys.First();
            }
            
            DataContext = _currentDoctor;

           
        }
        
        private void AddDoctorToBase(object sender, RoutedEventArgs e)
        {
            using (var context = new CRMmedContext()) 
            {
                if (_currentDoctor.DoctorId==0)
                {
                    if(errorCount<=0)
                    {
                        _currentDoctor.PhotoPath = path;
                        context.Attach(_currentDoctor.SpecialityNavigation);
                        context.Doctors.Add(_currentDoctor);
                        for (int i = 0; i < 7; i++)
                        {
                            context.Attach(DayOfWeekList[i]);
                            context.WorkTimes.Add(new WorkTime
                            {
                                DayNavigation = DayOfWeekList[i],
                                IsWorking = true,
                                WorkStart = "8:00",
                                WorkEnd = "20:00",
                                LunchStart = "12:00",
                                LunchEnd = "13:00",
                                Doctor = _currentDoctor
                            });

                            
                        }

                    }
                    else
                    {
                        MessageBox.Show("В полях имеются ошибки!");
                    }
                }
                else
                {
                    
                    _currentDoctor.PhotoPath = path;
                    context.Doctors.Update(_currentDoctor);
                    
                }
                try
                {

                    context.SaveChanges();
                    MessageBox.Show("Информация сохранена");
                    isUpdate = true;
                    Close();

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
                    
                    
                
               
            }
           
        }

        private void AddMainPhoto(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Png Images|*.png"
            };
            var result = dialog.ShowDialog();
            if (result != true)
            {
                return;
            }
            string newFilename = Guid.NewGuid().ToString().Replace("-", "") + ".png";
            string pathToCopy = $"Photos/{newFilename}";

            try
            {
                File.Copy(dialog.FileName, pathToCopy);
                path = newFilename;

                
            }
            catch
            {
                MessageBox.Show("Ошибка при копировании файла!");
            }
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
            {
                errorCount++;
                var errorToolTip = new ToolTip();
                errorToolTip.Content = e.Error.ErrorContent;
                (sender as TextBox).ToolTip = errorToolTip;
            }
            else if (e.Action == ValidationErrorEventAction.Removed)
            {
                errorCount--;
            }
        }
    }
}
