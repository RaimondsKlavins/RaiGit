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
using Serilog;
using Serilog.Sinks.File;
using System.IO;

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
            bool ok = int.TryParse(inputStr, out res2);

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
        private void RaiLog()
        {
            //string[] logLines = File.ReadAllLines(@"Logs\Log.txt");
            string[] logLines = File.ReadAllLines(@"c:\Logs\Log.txt");
            int lineCount = logLines.Length;
            //lineCount == 0 ? lineCount = 1;
            //if (lineCount == 0) { lineCount = 1; };

            var log = new LoggerConfiguration()
                .WriteTo.File(@"Logs\Log.txt", buffered: true, flushToDiskInterval: TimeSpan.FromMilliseconds(1000))
                .CreateLogger();

            Log.Logger = log;

            Log.Information("Log Line " + lineCount);
            Log.CloseAndFlush();

            ResTexBox.Text = "";
            foreach (string line in logLines)
            {
                ResTexBox.Text += line;
                ResTexBox.Text += "\r\n";
            }
        }
        #region Clicks

        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            Convert();
        }

        private void StrBuilderButton_Click(object sender, RoutedEventArgs e)
        {
            StrBuilder();
        }

        private void LogButton_Click(object sender, RoutedEventArgs e)
        {
            RaiLog();
        }
    #endregion

        public MainWindow()
        {
            InitializeComponent();
        }


    }
}
