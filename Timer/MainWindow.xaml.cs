using System;
using System.Diagnostics;
using System.Windows;
using System.Threading;
using System.Windows.Threading;
using System.IO;
using System.Windows.Media;

namespace Timer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static DispatcherTimer timer = new DispatcherTimer();
        public static int a1 = 0, a2 = 0, a3 = 0, a4 = 0, a5 = 0, a6 = 0, count = 0, CountSavings = 0;
        public static string output = "", StrCount = "", come = "", StartCount = "", StopCount = "";
        public static string path = @"C:\Users\user\Desktop\С#\Timer\records.txt";
        public static string PathToCountSavings = @"C:\Users\user\Desktop\С#\Timer\CountSavings.txt";
        public static string ComeAchieve = @"C:\Users\user\Desktop\С#\Timer\ComeAchieve.txt";
        public static string StartAchieve = @"C:\Users\user\Desktop\С#\Timer\CountStart.txt";
        public static string StopAchieve = @"C:\Users\user\Desktop\С#\Timer\CountStop.txt";
        public MainWindow()
        {
            InitializeComponent();
            StopCount = File.ReadAllText(StopAchieve);
            if (StopCount.Length >= 25)
            {
                SeventhElipse.Fill = Brushes.MediumVioletRed;
                if (StopCount.Length >= 100)
                {
                    EightsElipse.Fill = Brushes.MediumVioletRed;
                    if (StopCount.Length >= 200)
                    {
                        NinethElipse.Fill = Brushes.MediumVioletRed;
                    }
                }
            }
            CurrentProgress2.Text = "Текущий прогресс: " + StopCount.Length;
            StartCount = File.ReadAllText(StartAchieve);
            CurrentProgress1.Text = "Текущий прогресс: " + StartCount.Length;
            if (StartCount.Length >= 25)
            {
                FourthElipse.Fill = Brushes.MediumVioletRed;
                if (StartCount.Length >= 100)
                {
                    FifthElipse.Fill = Brushes.MediumVioletRed;
                    if (StartCount.Length >= 200)
                    {
                        SixElipse.Fill = Brushes.MediumVioletRed;
                    }
                }
            }
            come = File.ReadAllText(ComeAchieve);
            come += "1";
            CurrentProgress.Text = "Текущий прогресс: " + come.Length;
            if (come.Length == 10)
            {
                MessageBox.Show("Получена новая ачивка!");
            }
            if (come.Length >= 10)
            {
                if (come.Length >= 50)
                {
                    SecondElipse.Fill = Brushes.MediumVioletRed;
                    if (come.Length >= 100)
                    {
                        ThirdElipse.Fill = Brushes.MediumVioletRed;
                    }
                    if (come.Length == 100)
                    {
                        MessageBox.Show("Получена новая ачивка!");
                    }
                }
                if (come.Length == 50)
                {
                    MessageBox.Show("Получена новая ачивка!");
                }
                FirstElipse.Fill = Brushes.MediumVioletRed;
            }
            File.WriteAllText(ComeAchieve, "" + come);
            StrCount = File.ReadAllText(PathToCountSavings);
            if (StrCount != "")
            {
                UnfortText.Text = "";
            }
            RecordText.Text = File.ReadAllText(path);
        }
        void timer_Tick(object sender, EventArgs e)
        {
            a1++;
            if (a1 == 10)
            {
                a2++;
                a1 = 0;
            }
            if (a2 == 10)
            {
                a2 = 0;
                a3++;
            }
            if (a3 == 6)
            {
                a3 = 0;
                a4++;
            }
            if (a4 == 10)
            {
                a4 = 0;
                a5++;
            }
            if (a5 == 6)
            {
                a5 = 0;
                a6++;
            }
            output = "" + a6 + ":" + a5 + a4 + ":" + a3 + a2 + ":" + a1;
            TimerText.Text = output;
        }
        private void Click_Start(object sender, RoutedEventArgs e)
        {
            count++;
            timer.Interval = TimeSpan.FromSeconds(0.1);
            if (count > 1)
            {
                timer.Tick -= timer_Tick;
            }
            StartCount += "1";
            if (StartCount.Length == 25)
            {
                MessageBox.Show("Получена новая ачивка!");
            }
            if (StartCount.Length == 100)
            {
                MessageBox.Show("Получена новая ачивка!");
            }
            if (StartCount.Length == 200)
            {
                MessageBox.Show("Получена новая ачивка!");
            }
            File.WriteAllText(StartAchieve, StartCount);
            timer.Tick += timer_Tick;
            timer.Start();
        }
        private void Click_Stop(object sender, RoutedEventArgs e)
        {
            StopCount += "1";
            if (StopCount.Length == 25)
            {
                MessageBox.Show("Получена новая ачивка!");
            }
            if (StopCount.Length == 100)
            {
                MessageBox.Show("Получена новая ачивка!");
            }
            if (StopCount.Length == 200)
            {
                MessageBox.Show("Получена новая ачивка!");
            }
            File.WriteAllText(StopAchieve, StopCount);
            timer.Stop();
        }
        private void Click_Record(object sender, RoutedEventArgs e)
        {
            
            File.AppendAllText(path, "" + output + "\n");
            CountSavings++;
            File.WriteAllText(PathToCountSavings, "" + CountSavings);
        }
        private void Click_Restart(object sender, RoutedEventArgs e)
        {
            a1 = 0; a2 = 0; a3 = 0; a4 = 0; a5 = 0; a6 = 0;
            timer.Stop();
            TimerText.Text = output = "0:00:00:0";
        }
    }
}
