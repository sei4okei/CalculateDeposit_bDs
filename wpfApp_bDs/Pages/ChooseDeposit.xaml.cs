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
    /// Логика взаимодействия для Choosedeposit.xaml
    /// </summary>
    public partial class ChooseDeposit : Window
    {
        CalculateDeposit win = new CalculateDeposit();

        public ChooseDeposit()
        {
            InitializeComponent();
            Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            win.Owner = this;
            this.Hide();
            win.Show();
        }
    }
}
