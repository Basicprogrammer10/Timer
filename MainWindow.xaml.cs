using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace TimerProgram
{
    public partial class MainWindow : Window
    {
        DispatcherTimer dispatcherTimer;
        public Color BkHv = Color.FromRgb(67, 76, 94);
        public Color BkLv = Color.FromRgb(45, 51, 63);
        public static int runtime = 0;
        public bool running = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void start_MouseEnter(object sender, MouseEventArgs e)
        {
            start.Fill = new SolidColorBrush(BkHv);
        }

        private void start_MouseLeave(object sender, MouseEventArgs e)
        {
            start.Fill = new SolidColorBrush(BkLv);
        }

        private void toggleVis(bool toggle)
        {
            if (toggle)
            {
                PlayButtonIcon.Visibility = Visibility.Hidden;
                pauseA1.Visibility = Visibility.Visible;
                pauseA2.Visibility = Visibility.Visible;
                pauseA3.Visibility = Visibility.Visible;
                pauseB1.Visibility = Visibility.Visible;
                pauseB2.Visibility = Visibility.Visible;
                pauseB3.Visibility = Visibility.Visible;
            }
            else
            {
                PlayButtonIcon.Visibility = Visibility.Visible;
                pauseA1.Visibility = Visibility.Hidden;
                pauseA2.Visibility = Visibility.Hidden;
                pauseA3.Visibility = Visibility.Hidden;
                pauseB1.Visibility = Visibility.Hidden;
                pauseB2.Visibility = Visibility.Hidden;
                pauseB3.Visibility = Visibility.Hidden;
            }
        }

        private void start_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!running)
            {
                dispatcherTimer = new DispatcherTimer();
                dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
                dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
                dispatcherTimer.Start();
                running = true;
                toggleVis(true);
            }
            else
            {
                dispatcherTimer.Stop();
                running = false;
                toggleVis(false);
            }
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            runtime++;
            int sec = runtime - (runtime / 60) * 60;
            int min = (runtime / 60) - runtime / 60 / 60 * 60;
            int hor = runtime / 60 / 60;

            MainTime.Text = String.Format("{2}:{1}:{0}", sec.ToString().PadLeft(2, '0'), min.ToString().PadLeft(2, '0'), hor.ToString().PadLeft(2, '0'));
        }

        private void reset_MouseDown(object sender, MouseButtonEventArgs e)
        {

            if (running)
            {
                dispatcherTimer.Stop();
            }
            running = false;
            runtime = 0;
            MainTime.Text = "00:00:00";
            toggleVis(false);
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
                this.DragMove();
        }

        private void Exit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.Close();
        }

        private void Mini_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                WindowState = WindowState.Minimized;
        }
    }
}