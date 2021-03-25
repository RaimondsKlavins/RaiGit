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

namespace TyprConversions2.Controls
{
    /// <summary>
    /// Interaction logic for RaiControl.xaml
    /// </summary>
    public partial class RaiControl : UserControl
    {
        public RaiControl()
        {
            FontFamily = new FontFamily("Segoe UI Symbol");
            UpControlButton.Content = "\uE0E4";
            DownControlButton.Content = "\uE0E5";

            InitializeComponent();
        }

        private void DownControlButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpControlButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
