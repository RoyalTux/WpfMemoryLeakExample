using System;
using System.Windows;
using System.Windows.Threading;

namespace WpfMemoryLeakExample
{
    /// <summary>
    /// Interaction logic for Clock.xaml
    /// </summary>
    public partial class Clock : Window
    {
        private readonly DispatcherTimer _timer;

        public Clock()
        {
            InitializeComponent();
            _timer = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 1)
            };

            _timer.Start();
            _timer.Tick += UpdateTime;
        }

        private void UpdateTime(object sender, EventArgs e)
        {
            TimerText.Content = DateTime.Now.ToLongTimeString();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            // Uncomment below lines to stop memory leak
            // _timer.Tick -= UpdateTime;
            // _timer.Stop();
        }
    }
}
