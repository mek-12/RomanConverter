using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    }
}
