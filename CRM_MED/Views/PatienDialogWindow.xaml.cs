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
    /// Логика взаимодействия для PatienDialogWindow.xaml
    /// </summary>
    public partial class PatienDialogWindow : Window
    {
        public bool? select { get; set; }
        public PatienDialogWindow()
        {
            InitializeComponent();

        }

        private void GoToRedact(object sender, RoutedEventArgs e)
        {
            select = true;
            Close();
        }

        private void GoToReception(object sender, RoutedEventArgs e)
        {
            select = false;
            Close();
        }
    }
}
