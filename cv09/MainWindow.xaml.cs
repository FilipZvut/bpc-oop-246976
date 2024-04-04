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
            Pamet.Text = calculator.Pamet;

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            calculator.Tlacitko((sender as Button).Content.ToString());
            Display.Text = calculator.Display;
            Pamet.Text = calculator.Pamet;

        }
    }
}
