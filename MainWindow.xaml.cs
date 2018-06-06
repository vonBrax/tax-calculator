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
using System.Diagnostics;

namespace TaxCalculator
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
    }

    public class DataClassMultiValueConverter: IMultiValueConverter
    {
        /*
        *  Return salary after tax dedution for a given period
        *  @param {object[]} values Values from the annual gross salary and the tax rate inputs
        *  @param {object} parameter Period in months (optinal, default = 1)
        *  @returns {object} The calculated salary income for the given period
        **/
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string salary = (string)values[0] == "" ? "0" : (string)values[0];
            string tax = (string)values[1] == "" ? "0" : (string)values[1];
            int period = (string)parameter != "" && parameter != null ? Int32.Parse((string)parameter) : 1;
            float result = float.Parse(salary) * ( (100 - float.Parse(tax))/100) / period;
            return result.ToString();
        }

        public object[] ConvertBack(object values, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException("Cannot convert back");
        }
    }
}
