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
    /// Логика взаимодействия для ReceptionWindow.xaml
    /// </summary>
    public partial class ReceptionWindow : Window
    {
        public Patient patient = new Patient();
        public Patient _currentPatient { get; set; }
        public ReceptionWindow(Patient patient)
        {
            InitializeComponent();
            _currentPatient = patient;
        }

        private void AddBtn(object sender, RoutedEventArgs e)
        {

        }
    }
}
