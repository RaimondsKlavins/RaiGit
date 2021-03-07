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

namespace TyprConversions2
{

    public partial class MainWindow : Window
    {
        StringBuilder myStringBuilder = new StringBuilder();

        private void Convert()
        {
            // .ToString() anything to string

            // string to anything 


            //ResTexBox.Text = InputTexBox.ToString();// "";
            //return;

            var inputStr = InputTexBox.Text;

            // Parse
            //int res1 = int.Parse(inputStr);
            //ResTexBox.Text = res1.ToString();

            try
            {
                int res1 = int.Parse(inputStr);
                ResTexBox.Text = res1.ToString();
            }
            catch (Exception ex)
            {
                ResTexBox.Text = "ERROR : " + ex.Message;
            }
            return;

            // TryParse
            int res2;
            bool ok = int.TryParse(inputStr,out res2);

            //if (ok)
            //{
            //    ResTexBox.Text = res2.ToString();
            //}
            //else
            //{
            //    ResTexBox.Text = "ERROR";
            //}

            ResTexBox.Text = ok ? res2.ToString() : "ERROR"; // = Condition ? true : false

            // Homework Parse & TryParse for (double, float, decimal ) -> double.Parse(inputStr);
        }

        private void StrBuilder()
        {
            var inputStr = InputTexBox.Text;

            //myStringBuilder.Append(inputStr);
            myStringBuilder.AppendLine(inputStr);

            ResTexBox.Text = myStringBuilder.ToString();
        }

        #region MyRegion

        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            Convert();
        }

        private void StrBuilderButton_Click(object sender, RoutedEventArgs e)
        {
            StrBuilder();
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        #endregion

    }
}
