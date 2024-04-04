using System;
using System.Windows;
using System.Windows.Controls;

namespace cv09
{
    public partial class MainWindow : Window
    {
        private Calculator calculator = new Calculator();
        public MainWindow()
        {
            InitializeComponent();
            Display.Text = calculator.Display;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            calculator.Tlacitko(((Button)sender).Content.ToString());
            Display.Text = calculator.Display;
        }
    }
}
