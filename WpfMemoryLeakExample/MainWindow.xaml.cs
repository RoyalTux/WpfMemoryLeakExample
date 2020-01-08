using System.Collections.Generic;
using System.Windows;

namespace WpfMemoryLeakExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly List<Clock> _clocks = new List<Clock>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonStart_OnClick(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                var clock = new Clock();
                clock.Show();
                _clocks.Add(clock);
            }
        }

        private void ButtonStop_OnClick(object sender, RoutedEventArgs e)
        {
            foreach (var clock in _clocks)
            {
                clock.Close();
            }
            _clocks.Clear();
        }
    }
}
