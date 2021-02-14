using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace TimerProgram
{
    public partial class MainWindow
    {
        private static int _runtime;
        private readonly Color BkHv = Color.FromRgb(67, 76, 94);
        private readonly Color BkLv = Color.FromRgb(45, 51, 63);
        private DispatcherTimer DispatcherTimer;
        private bool Running;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void start_MouseEnter(object sender, MouseEventArgs e)
        {
            Start.Fill = new SolidColorBrush(BkHv);
        }

        private void start_MouseLeave(object sender, MouseEventArgs e)
        {
            Start.Fill = new SolidColorBrush(BkLv);
        }

        private void ToggleVis(bool toggle)
        {
            if (toggle)
            {
                PlayButtonIcon.Visibility = Visibility.Hidden;
                PauseA1.Visibility = Visibility.Visible;
                PauseA2.Visibility = Visibility.Visible;
                PauseA3.Visibility = Visibility.Visible;
                PauseB1.Visibility = Visibility.Visible;
                PauseB2.Visibility = Visibility.Visible;
                PauseB3.Visibility = Visibility.Visible;
            }
            else
            {
                PlayButtonIcon.Visibility = Visibility.Visible;
                PauseA1.Visibility = Visibility.Hidden;
                PauseA2.Visibility = Visibility.Hidden;
                PauseA3.Visibility = Visibility.Hidden;
                PauseB1.Visibility = Visibility.Hidden;
                PauseB2.Visibility = Visibility.Hidden;
                PauseB3.Visibility = Visibility.Hidden;
            }
        }

        private void start_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!Running)
            {
                DispatcherTimer = new DispatcherTimer();
                DispatcherTimer.Tick += dispatcherTimer_Tick;
                DispatcherTimer.Interval = new TimeSpan(0, 0, 1);
                DispatcherTimer.Start();
                Running = true;
                ToggleVis(true);
            }
            else
            {
                DispatcherTimer.Stop();
                Running = false;
                ToggleVis(false);
            }
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            _runtime++;
            var Sec = _runtime - _runtime / 60 * 60;
            var Min = _runtime / 60 - _runtime / 60 / 60 * 60;
            var Hor = _runtime / 60 / 60;

            MainTime.Text = string.Format("{2}:{1}:{0}", Sec.ToString().PadLeft(2, '0'), Min.ToString().PadLeft(2, '0'), Hor.ToString().PadLeft(2, '0'));
        }

        private void reset_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Running)
                DispatcherTimer.Stop();
            Running = false;
            _runtime = 0;
            MainTime.Text = "00:00:00";
            ToggleVis(false);
        }

        private void reset_MouseEnter(object sender, MouseEventArgs e)
        {
            Reset.Fill = new SolidColorBrush(BkHv);
        }

        private void reset_MouseLeave(object sender, MouseEventArgs e)
        {
            Reset.Fill = new SolidColorBrush(BkLv);
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        private void Exit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                Close();
        }

        private void Mini_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                WindowState = WindowState.Minimized;
        }

        private void info_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Made by Sigma#8214\nConnor@connorcode.com", "Sigma's Timer", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void info_MouseEnter(object sender, MouseEventArgs e)
        {
            ResetCopy.Fill = new SolidColorBrush(BkHv);
        }

        private void info_MouseLeave(object sender, MouseEventArgs e)
        {
            ResetCopy.Fill = new SolidColorBrush(BkLv);
        }
    }
}