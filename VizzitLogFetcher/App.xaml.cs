using LogHandler;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows;

namespace VizzitLogFetcher
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            CultureInfo ci = new CultureInfo(Thread.CurrentThread.CurrentCulture.Name);
            ci.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd";
            Thread.CurrentThread.CurrentCulture = ci;

            if (e.Args.Length > 0)
                RunJob();
        }

        private void RunJob()
        {
            RunVizzitJob runJob;
            List<string> dateList = new List<string>();

            string date = DateTime.Now.AddDays(-1).ToString("yyMMdd");

            dateList.Add(date);

            try
            {
                runJob = new RunVizzitJob(VizzitLogFetcher.Properties.Settings.Default["LogDir"].ToString(), VizzitLogFetcher.Properties.Settings.Default["CustomerId"].ToString(), dateList);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Application.Current.Shutdown();
        }
    }
}
