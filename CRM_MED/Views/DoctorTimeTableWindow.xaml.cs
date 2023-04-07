using CRM_MED.Models;
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
using System.Windows.Shapes;

namespace CRM_MED.Views
{
    /// <summary>
    /// Логика взаимодействия для DoctorTimeTableWindow.xaml
    /// </summary>
    public partial class DoctorTimeTableWindow : Window
    {
        

        public Doctor _currentDoctor { get; set; }

        public ObservableCollection<WorkTime> workTimes;

        public List<string> timeList = new List<string>();
        public DoctorTimeTableWindow(Doctor doctor)
        {
            InitializeComponent();
            var context = new CRMmedContext();
            _currentDoctor = doctor;
            workTimes = new ObservableCollection<WorkTime>(context.WorkTimes.Include(w=>w.DayNavigation).Where(w => w.DoctorId == _currentDoctor.DoctorId).ToList());
            
            for (int j = 480; j < 1230; j += 30)
            {
                string hour = (j / 60).ToString();
                string minute = (j % 60).ToString();
                if (minute == "0")
                {
                    minute = "00";
                }
                timeList.Add(hour + ":" + minute);
                //timeList.Add(new DateTime(2000,1,1,int.Parse(hour),int.Parse(minute),0));
                
            }
            
            DG.ItemsSource = workTimes;
            CBworkstart.ItemsSource = timeList;
            CBworkend.ItemsSource = timeList;
            CBlaunchstart.ItemsSource = timeList;
            //CBlaunchend.ItemsSource = timeList;
            DataContext = this;
        }
        private void Load(object sender, RoutedEventArgs e)
        {
            var context = new CRMmedContext();
            //dayOfWeeks = context.DayOfWeeks.ToList();
            //var work = context.WorkTimes.ToList();
            
        }

        private void SaveTimeTable(object sender, RoutedEventArgs e)
        {
            
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 7; i++)
                {
                if (workTimes[i].IsWorking == true)
                {
                    var ws = DateTime.Parse(workTimes[i].WorkStart);
                    var we = DateTime.Parse(workTimes[i].WorkEnd);
                    var ls = DateTime.Parse(workTimes[i].LunchStart);
                    var le = ls.AddHours(1);
                    if (ws >= ls || we <= le)
                    {
                        sb.Append($"В {workTimes[i].DayNavigation.DayOfWeekName} не корректно выставлено время обеда\n");
                    }
                    if (ws > we)
                    {
                        sb.Append($"В {workTimes[i].DayNavigation.DayOfWeekName} время работы выставленно не корректно\n");
                    }
                    if (we.AddHours(-6) < ws)
                    {
                        sb.Append($"В {workTimes[i].DayNavigation.DayOfWeekName} меньше 5 рабочих часов\n");
                    }
                }
                
            }
            if (sb.Length > 0)
            {
                MessageBox.Show(sb.ToString());
            }
            else
            {
                for (int i = 0; i < 7; i++)
                {
                    var ls = DateTime.Parse(workTimes[i].LunchStart);
                    workTimes[i].LunchEnd = ls.AddHours(1).ToString();
                }
                using (var context = new CRMmedContext())
                {
                    context.WorkTimes.UpdateRange(workTimes);
                    context.SaveChanges();
                }
            }

        }
    }
}
