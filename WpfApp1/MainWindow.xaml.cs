using System.Windows;
using RomanConvertApp.BLL;

namespace RomanConvertApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            var input = InputNumber.Text.Replace(" ", string.Empty);
            bool isNumber = false;
            bool isRomanNum = false;

            if(input != "")
            {

                isNumber = BooleanManager.IsANumber(input);

                if (isNumber)
                {
                    StatusLabel.Content = "Yes, this is a integer.";
                    if(input.Length >4)
                    {
                        Result.Content = "Min 4 digit";
                        return;
                    }
                    Result.Content = RomanConverter.ConvertToRoman(input);
                    return;
                }

                isRomanNum = BooleanManager.IsARomanNumber(input);

                if (isRomanNum)
                {
                    StatusLabel.Content = "Yes, this is a roman number.";
                    Result.Content = RomanConverter.ConvertToNumber(" " +input);
                    return;
                }
                StatusLabel.Content = "Please enter in integer or roman";
                return;
            }
            StatusLabel.Content = "Is No valid. Try again.";
            return;
            
        }

        private void InputNumber_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            InputNumber.Text = "";
            Result.Content = "";
            StatusLabel.Content = "";
        }
    }
}
