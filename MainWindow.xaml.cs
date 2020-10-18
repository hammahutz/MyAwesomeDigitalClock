using System;
using System.Windows;
using System.Windows.Threading;
using System.Globalization;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace MyAwesomeDigitalClock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Calendar calendar;
        DateTimeFormatInfo dateTimeFormatInfo;
        CalendarWeekRule calendarWeekRule;
        DayOfWeek dayOfWeek;

        NotifyIcon notifyIcon = null;


        public MainWindow()
        {
            InitializeComponent();
            notifyIcon = new NotifyIcon();
            notifyIcon.Click += new EventHandler(Notify_Click);
            notifyIcon.DoubleClick += new EventHandler(Notify_DoubleClick);
            //notifyIcon.Icon =
        }

        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GetCultureTime();
            StartTimer();
        }
        private void GetCultureTime()
        {
            calendar = CultureInfo.GetCultureInfo("sv-SE").Calendar;
            dateTimeFormatInfo = CultureInfo.GetCultureInfo("sv-SE").DateTimeFormat;
            calendarWeekRule = CultureInfo.GetCultureInfo("sv-SE").DateTimeFormat.CalendarWeekRule;
            dayOfWeek = CultureInfo.GetCultureInfo("sv-SE").DateTimeFormat.FirstDayOfWeek;
        }

        private void StartTimer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(0.1);
            timer.Tick += TimeTick;
            timer.Start();
        }



        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(1);
        }

        public void TimeTick(object sender, EventArgs e)
        {
            timeLable.Content = DateTime.Now.ToLongTimeString();
            dateLongLable.Content = dateTimeFormatInfo.GetDayName(DateTime.Now.DayOfWeek) + "en " + DateTime.Now.ToLongDateString();
            dateWeekLable.Content = "Vecka " + calendar.GetWeekOfYear(DateTime.Now, calendarWeekRule, dayOfWeek);
            dateShortLable.Content = DateTime.Now.ToShortDateString();
        }

        public void Notify_Click(object sender, EventArgs e)
        { 
        }

        public void Notify_DoubleClick(object sender, EventArgs e)
        {
        }
    }
}