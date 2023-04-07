using CRM_MED.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для DoctorWindow.xaml
    /// </summary>
    public partial class DoctorWindow : Window
    {

        public Doctor doctor { get; set; }

        public DoctorWindow()
        {
            InitializeComponent();
            Application.Current.MainWindow.Visibility = Visibility.Collapsed;
            DataContext = this;
        }

        private void PatientPage(object sender, RoutedEventArgs e)
        {

        }

        private void ReceptionPage(object sender, RoutedEventArgs e)
        {

        }

        private void WorkTimePage(object sender, RoutedEventArgs e)
        {

        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Visibility = Visibility.Visible;
            Close();
        }
    }
}
