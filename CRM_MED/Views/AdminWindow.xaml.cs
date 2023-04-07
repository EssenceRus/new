using CRM_MED.Models;
using CRM_MED.Pages;
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
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            Application.Current.MainWindow.Visibility= Visibility.Collapsed;
        }

        private void PatientPage(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Admin_PatientsPage());
        }

        private void ReceptionPage(object sender, RoutedEventArgs e)
        {

        }

        private void DoctorPage(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Admin_DoctorPage());
        }

        private void StoragePage(object sender, RoutedEventArgs e)
        {

        }  
        private void Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Visibility = Visibility.Visible;
            Close();
        }
    }
}
