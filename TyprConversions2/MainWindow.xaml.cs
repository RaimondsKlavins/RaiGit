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
using TyprConversions2.Classes;

namespace TyprConversions2
{

    public partial class MainWindow : Window
    {
        #region Variables
        StringBuilder myStringBuilder = new StringBuilder();
        int[] numList = { 1, 2, 3, 10, 20, 30, 40, 100, 1000 };
        int[] numList2 = { 3, 5, 7, 5, 34, 54, 345, 3478, 234 };
        int[] numList3 = { 3, 2, 7, 5, 1, 54, 10, 3478, 234, 3, 5, 100, 30, 34, 10, 345, 3478, 1000 };
        string[] stringList = { "fgutfmftua","fm6ftmfma","mf78g78ga","bgdhrudjnft6a","sn5a","s5n64s56a","eea","a","6en7567na","4564564564a","foigdhfoi oidhfioghdiaof oid oidfo","234ewa" };
        #endregion

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

        private void RaiLINQ1()
        {
            int inputInt = 0;

            var inputText = InputTexBox.Text;
            try
            {
                inputInt = int.Parse(inputText);

                var res =
                    from num in numList
                    where num > inputInt
                    select num;

                ResTexBox.Text = "";
                foreach (int num in res)
                {
                    ResTexBox.Text += num;
                    ResTexBox.Text += "\r\n";
                }
            }
            catch (Exception ex)
            {
                ResTexBox.Text = "ERROR : " + ex.Message;
            }
        }

        private void RaiLINQ2()
        {
            int inputInt = 0;

            var inputText = InputTexBox.Text;
            try
            {
                inputInt = int.Parse(inputText);

                var res = numList.Where(n => n > inputInt);

                ResTexBox.Text = "";
                foreach (int num in res)
                {
                    ResTexBox.Text += num;
                    ResTexBox.Text += "\r\n";
                }
            }
            catch (Exception ex)
            {
                ResTexBox.Text = "ERROR : " + ex.Message;
            }
        }

        private void RaiLINQ3()
        {
            int inputInt = 0;
            int numCount1 = 0;
            int numCount2 = 0;
            int numCount3 = 0;

            var inputText = InputTexBox.Text;
            try
            {
                inputInt = int.Parse(inputText);

                var res = numList.Where(n => n == inputInt);
                var res2 = numList2.Where(n => n == inputInt);
                var res3 = numList3.Where(n => n == inputInt);

                ResTexBox.Text = "";
                foreach (int num in res)
                {
                    numCount1 += 1;
                }
                foreach (int num in res2)
                {
                    numCount2 += 1;
                }
                foreach (int num in res3)
                {
                    numCount3 += 1;
                }

                ResTexBox.Text += "Number of Occurrences in list 1: " + numCount1;
                ResTexBox.Text += "\r\n";
                ResTexBox.Text += "Number of Occurrences in list 2: " + numCount2;
                ResTexBox.Text += "\r\n";
                ResTexBox.Text += "Number of Occurrences in list 3: " + numCount3;
                ResTexBox.Text += "\r\n";
                ResTexBox.Text += "Number of Occurrences in all lists: " + (numCount1 + numCount2 + numCount3);
            }
            catch (Exception ex)
            {
                ResTexBox.Text = "ERROR : " + ex.Message;
            }
        }

        private void RaiLINQ4()
        {
            int inputInt = 0;

            var inputText = InputTexBox.Text;
            try
            {
                inputInt = int.Parse(inputText);

                var res = stringList.Where(s => s.Length > inputInt);

                ResTexBox.Text = "";
                foreach (string str in res)
                {
                    ResTexBox.Text += str;
                    ResTexBox.Text += "\r\n";
                }
            }
            catch (Exception ex)
            {
                ResTexBox.Text = "ERROR : " + ex.Message;
            }
        }

        private void RaiLINQ5()
        {
            var inputText = InputTexBox.Text;

            var res = stringList.Where(s => s.Contains(inputText));
            var res2 = stringList.All(s => s.Contains(inputText));

            ResTexBox.Text = "";
            //bool res = stringList.All(s => s.Contains(inputText)) ? ResTexBox.Text += "Contains input string" : ResTexBox.Text += "Does not contain input string";
            //if (res.Count !== 0) Error given by this for some reason
            //{
            //    ResTexBox.Text += "Do contain input string";
            //}
            //else
            //{
            //    ResTexBox.Text += "Do not contain input string";
            //}
            //ResTexBox.Text += "\r\n";

            if (res2)
            {
                ResTexBox.Text += "All contain input string";
            }
            else
            {
                ResTexBox.Text += "All do not contain input string";
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

        private void LINQ1Button_Click(object sender, RoutedEventArgs e)
        {
            RaiLINQ1();
        }

        private void LINQ2Button_Click(object sender, RoutedEventArgs e)
        {
            RaiLINQ2();
        }

        private void LINQ3Button_Click(object sender, RoutedEventArgs e)
        {
            RaiLINQ3();
        }

        private void LINQ4Button_Click(object sender, RoutedEventArgs e)
        {
            RaiLINQ4();
        }

        private void LINQ5Button_Click(object sender, RoutedEventArgs e)
        {
            RaiLINQ5();
        }
        #endregion

        public MainWindow()
        {
            InitializeComponent();
        }


    }
}
