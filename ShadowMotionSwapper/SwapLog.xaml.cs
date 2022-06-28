using System.Windows;

namespace ShadowMotionSwapper
{
    /// <summary>
    /// Interaction logic for SwapLog.xaml
    /// </summary>
    public partial class SwapLog : Window
    {
        public SwapLog(string log)
        {
            InitializeComponent();
            TextBox_SwapLog.Text = log;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
    }
}
