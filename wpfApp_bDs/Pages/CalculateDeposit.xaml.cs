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
using wpfApp_bDs.Logic;

namespace wpfApp_bDs.Pages
{
    /// <summary>
    /// Логика взаимодействия для CalculateDeposit.xaml
    /// </summary>
    public partial class CalculateDeposit : Window
    {
        AnalasisDeposit win = new AnalasisDeposit();

        const double StablePercent = 0.08;
        const double OptimalPercent = 0.05;
        const double StandardPercent = 0.06;

        public CalculateDeposit()
        {
            InitializeComponent();
            Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((Slider)sender).SelectionEnd = e.NewValue;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            win.Owner = this;
            this.Hide();
            win.Show();
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (PeriodSlider.Value <= 90)
                {
                    Stable.Text = "Маленький срок";
                    Optimal.Text = "Маленький срок";
                    Standard.Text = "Маленький срок";

                }
                else if (PeriodSlider.Value <= 180)
                {
                    Stable.Text = (Calculate.Profit(SummarySlider.Value, PeriodSlider.Value, DepositsSlider.Value, StablePercent)).ToString() + " Руб.";
                    Optimal.Text = "Маленький срок";
                    Standard.Text = (Calculate.Profit(SummarySlider.Value, PeriodSlider.Value, DepositsSlider.Value, StandardPercent)).ToString() + " Руб.";

                    SendInfo();
                }
                else
                {
                    Stable.Text = (Calculate.Profit(SummarySlider.Value, PeriodSlider.Value, DepositsSlider.Value, StablePercent)).ToString() + " Руб.";
                    Optimal.Text = (Calculate.Profit(SummarySlider.Value, PeriodSlider.Value, DepositsSlider.Value, OptimalPercent)).ToString() + " Руб.";
                    Standard.Text = (Calculate.Profit(SummarySlider.Value, PeriodSlider.Value, DepositsSlider.Value, StandardPercent)).ToString() + " Руб.";

                    SendInfo();
                }
            }
        }

        private void SendInfo()
        {
            win.StableProfitView.Text = Stable.Text;
            if (PeriodSlider.Value >= 180)
            {
                win.OptimalProfitView.Text = Optimal.Text;
            }
            win.StandardProfitView.Text = Standard.Text;

            win.StableSummaryView.Text = (Convert.ToInt32((Stable.Text).Replace(" Руб.", "")) + Convert.ToInt32(Calculate.Summary(SummarySlider.Value, PeriodSlider.Value, DepositsSlider.Value))).ToString() + " Руб.";
            if (PeriodSlider.Value >= 180)
            {
                win.OptimalSummaryView.Text = (Convert.ToInt32((Optimal.Text).Replace(" Руб.", "")) + Convert.ToInt32(Calculate.Summary(SummarySlider.Value, PeriodSlider.Value, DepositsSlider.Value))).ToString() + " Руб.";
            }
            win.StandardSummaryView.Text = (Convert.ToInt32((Standard.Text).Replace(" Руб.", "")) + Convert.ToInt32(Calculate.Summary(SummarySlider.Value, PeriodSlider.Value, DepositsSlider.Value))).ToString() + " Руб.";

            win.StablePercentView.Text = (StablePercent * 100).ToString() + " % Руб.";
            if (PeriodSlider.Value >= 180)
            {
                win.OptimalPercentView.Text = (OptimalPercent * 100).ToString() + " % Руб.";
            }
            win.StandardPercentView.Text = (StandardPercent * 100).ToString() + " % Руб.";
        }
    }
}
