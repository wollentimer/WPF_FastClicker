using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Clicker
{
    public partial class MainWindow : Window
    {
        private int counter = 0;
        private int increment = 0;
        DispatcherTimer dt = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += dtTicker;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            counter++;
            if (counter == 1)
            {
                dt.Start();
            }
            btn.Content = counter.ToString();

            if (counter >= 250)
            {
                tb.Text = "U'll be famous among girls!";
            }
        }

        private void Button_Click_Clear(object sender, RoutedEventArgs e)
        {
            btn.Content = "CLICK HERE!";
            tb.Text = "";
            timerLabel.Content = 0.ToString();
            counter = 0;
            increment = 0;
            btn.IsEnabled = true;
            dt.Stop();
        }

        private int timeSec = 0;
        private void dtTicker(object sender, EventArgs e)
        {
            if (increment != timeSec)
            {
                increment++;
                timerLabel.Content = increment.ToString();
            }
            else
            {
                btn.IsEnabled = false;
                dt.Stop();
                increment = 0;
            }
        }

        private void textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            timeSec = int.Parse(textbox.Text);
        }

    }
}
