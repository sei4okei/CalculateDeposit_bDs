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
using System.Windows.Shapes;

namespace wpfApp_bDs.Pages
{
    /// <summary>
    /// Логика взаимодействия для CalculateDeposit.xaml
    /// </summary>
    public partial class CalculateDeposit : Window
    {

        const double stable = 0.08;
        const double optim = 0.05;
        const double stand = 0.06;

        public string stableProfit { get; set; }
        public string optimProfit { get; set; }
        public string standProfit { get; set; }

        public CalculateDeposit()
        {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((Slider)sender).SelectionEnd = e.NewValue;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                MathDeposit();
            }
            
        }

        public void MathDeposit()
        {
            stableProfit = (Math.Round((Convert.ToDouble(slValue1.Value)/30 * Convert.ToDouble(slValue2.Value) + Convert.ToDouble(slValue.Value)) * ((Convert.ToDouble(slValue1.Value)/ 30 / 12) * stable))).ToString();
            StableText.Text = stableProfit;
            stableProfit = (Math.Round((Convert.ToDouble(slValue1.Value) / 30 * Convert.ToDouble(slValue2.Value) + Convert.ToDouble(slValue.Value)) * ((Convert.ToDouble(slValue1.Value) / 30 / 12) * optim))).ToString();
            OptimText.Text = stableProfit;
            standProfit = (Math.Round((Convert.ToDouble(slValue1.Value) / 30 * Convert.ToDouble(slValue2.Value) + Convert.ToDouble(slValue.Value)) * ((Convert.ToDouble(slValue1.Value) / 30 / 12) * stand))).ToString();
            StandText.Text = stableProfit;
        }
    }
}
