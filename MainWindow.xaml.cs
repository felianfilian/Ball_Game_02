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

namespace Ball_Game_02
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int counter = 0;
        public int ballForceX = 5;
        public int ballForceY = 5;

        private DispatcherTimer animTimer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();

            animTimer.Interval = TimeSpan.FromMilliseconds(10);
            animTimer.Tick += ballPosition;

        }

        private void ballPosition(object sender, EventArgs e)
        {
            var x = Canvas.GetLeft(Player01);

            if (x + Player01.Width >= PlayField.ActualWidth)
            {
                ballForceX = -5;
            } else if (x <= 0)
            {
                ballForceX = 5;
            }

            var y = Canvas.GetTop(Player01);

            if (y + Player01.Height >= PlayField.ActualHeight)
            {
                ballForceY = -5;
            }
            else if (y <= 0)
            {
                ballForceY = 5;
            }

            Canvas.SetLeft(Player01, x + ballForceX);
            Canvas.SetTop(Player01, y + ballForceY);
        }

        private void StartStop_Click(object sender, RoutedEventArgs e)
        {
            if (animTimer.IsEnabled)
            {
                animTimer.Stop();
            }
            else
            {
                animTimer.Start();
            }

            counter++;
            GameStat.Content = counter + " Clicks";
        }

        
        private void Player01_MouseUp(object sender, MouseButtonEventArgs e)
        {
            counter++;
            GameStat.Content = $"{counter} Clicks";
        }

        private void Player01_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F)
            {
                Player01.Fill = Brushes.Red;
            }
        }
    }
}
