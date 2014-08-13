using LogHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VizzitLogFetcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            fromDatePicker.SelectedDate = DateTime.Now.AddDays(-1);
            toDatePicker.SelectedDate = DateTime.Now.AddDays(-1);

            customerIdTb.Text = GetCustomerIdFromSettings();
            logDirTb.Text = GetLogDirFromSettings();
        }

        private string GetCustomerIdFromSettings()
        {
            if (!String.IsNullOrEmpty(Properties.Settings.Default["CustomerId"].ToString()))
                return Properties.Settings.Default["CustomerId"].ToString();
            else
                return "";
        }

        private string GetLogDirFromSettings()
        {
            if (!String.IsNullOrEmpty(Properties.Settings.Default["LogDir"].ToString()))
                return Properties.Settings.Default["LogDir"].ToString();
            else
                return "";
        }

        private void SaveSettings(string logDir, string customerId)
        {
            Properties.Settings.Default["CustomerId"] = customerId;
            Properties.Settings.Default["LogDir"] = logDir;
            Properties.Settings.Default.Save();
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            SaveSettings(logDirTb.Text, customerIdTb.Text);
        }

        private void RunJob(DateTime from, DateTime to)
        {
            RunVizzitJob runJob;

            errorTextBox.Text = "";

            List<DateTime> allDates = new List<DateTime>();

            for (DateTime date = from; date <= to; date = date.AddDays(1))
                allDates.Add(date);

            List<string> dateArray = new List<string>();

            foreach (DateTime dt in allDates)
            {
                dateArray.Add(dt.ToString("yyMMdd"));
            }

            try
            {
                runJob = new RunVizzitJob(Properties.Settings.Default["LogDir"].ToString(), Properties.Settings.Default["CustomerId"].ToString(), dateArray);
                errorTextBox.Text = "Jobb klart";
            }
            catch (Exception ex)
            {
                errorTextBox.Text = ex.Message;
            }
        }

        private void runJobBtn_Click(object sender, RoutedEventArgs e)
        {
            RunJob(fromDatePicker.SelectedDate.Value, toDatePicker.SelectedDate.Value);
        }
    }
}
