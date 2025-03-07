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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ClickChallangeGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int clicks;
        private DispatcherTimer Timer;
        private TimeSpan RemainingTime;
        public MainWindow()
        {
            InitializeComponent();
            Timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1),
            };
            Timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (RemainingTime.TotalSeconds > 0)
            {
                RemainingTime = RemainingTime.Subtract(TimeSpan.FromSeconds(1));
                TimerText.Text = RemainingTime.ToString(@"hh\:mm\:ss");
            }
            else
            {
                Timer.Stop();
                Clicking.IsEnabled = false;
                Clicking.Visibility = Visibility.Hidden;
                MessageBox.Show($"The stopper has stoped! \nYou have clicked the button {clicks} times!", "Info");
            }
        }

        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            clicks = 0;
            Times.Text = $"Times - {clicks}";
            RemainingTime = TimeSpan.Parse("00:00:10");
            Timer.Start();
            Clicking.IsEnabled = true;
            Clicking.Visibility = Visibility.Visible;
        }

        private void Clicking_Click(object sender, RoutedEventArgs e)
        {
            clicks += 1;
            Times.Text = $"Times - {clicks}";
        }
    }
}
