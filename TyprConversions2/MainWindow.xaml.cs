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

        int[] ints = { 1, 2, 4, 8, 4, 2, 1 };
        int[] filter = { 1, 1, 2, 3, 5, 8 };
        List<string> strs = new List<string> { "first", "second", "third" };
        int[][] arrOfArr = {
                new[] {1, 2, 3},
                new[] {4},
                new[] {5, 6, 7, 8},
                new[] {12, 14}
            };
        string resStr = "";
        int resInt = 0;
        bool boolRes = false;
        IEnumerable<int> enumInt = null;
        IEnumerable<string> enumStr = null;
        int[] raiSingleInt = { 5 };

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

        private void LINQTest()
        {
            ResTexBox.Text = "";
            resInt = ints.First();
            ResTexBox.Text += ("resInt = ints.First(): " + resInt);
            ResTexBox.Text += "\r\n";
            resInt = ints.First(x => x > 1);
            ResTexBox.Text += ("resInt = ints.First(x => x > 1): " + resInt);
            ResTexBox.Text += "\r\n";
            resInt = ints.Last();
            ResTexBox.Text += ("resInt = ints.Last(): " + resInt);
            ResTexBox.Text += "\r\n";
            resInt = ints.Max();
            ResTexBox.Text += ("resInt = ints.Max(): " + resInt);
            ResTexBox.Text += "\r\n";
            resInt = ints.Min();
            ResTexBox.Text += ("resInt = ints.Min(): " + resInt);
            ResTexBox.Text += "\r\n";
            resInt = ints.Last(x => x > 4);
            ResTexBox.Text += ("resInt = ints.Last(x => x > 4): " + resInt);
            ResTexBox.Text += "\r\n";
            resInt = ints.ElementAt(2);
            ResTexBox.Text += ("resInt = ints.ElementAt(2): " + resInt);
            ResTexBox.Text += "\r\n";
            resInt = raiSingleInt.Single();
            ResTexBox.Text += ("resInt = raiSingleInt.Single(): " + resInt);
            ResTexBox.Text += "\r\n";
            resInt = ints.Single(x => x > 4);
            ResTexBox.Text += ("resInt = ints.Single(x => x > 4): " + resInt);
            ResTexBox.Text += "\r\n";
            resInt = ints.ElementAtOrDefault(8);
            ResTexBox.Text += ("resInt = ints.ElementAtOrDefault(8): " + resInt);
            ResTexBox.Text += "\r\n";
            resInt = ints.Count();
            ResTexBox.Text += ("resInt = ints.Count(): " + resInt);
            ResTexBox.Text += "\r\n";
            resInt = ints.Count(x => x > 1);
            ResTexBox.Text += ("resInt = ints.Count(x => x > 1): " + resInt);
            ResTexBox.Text += "\r\n";
            resInt = ints.Aggregate((a, b) => a + b);
            ResTexBox.Text += ("resInt = ints.Aggregate((a, b) => a + b): " + resInt);
            ResTexBox.Text += "\r\n";
            resInt = ints.Sum();//realisation of  Aggregate
            ResTexBox.Text += ("resInt = ints.Sum(): " + resInt);
            ResTexBox.Text += "\r\n";
            ResTexBox.Text += "\r\n";

            double dbRes = ints.Average();
            ResTexBox.Text += ("dbRes = ints.Average(): " + dbRes);
            ResTexBox.Text += "\r\n";
            ResTexBox.Text += "\r\n";


            boolRes = ints.Any(x => x < 8);  // If Exists with conditions
            ResTexBox.Text += ("boolRes = ints.Any(x => x < 8): " + boolRes);
            ResTexBox.Text += "\r\n";
            boolRes = ints.All(x => x >= 1); // All members fit condition
            ResTexBox.Text += ("boolRes = ints.All(x => x >= 1): " + boolRes);
            ResTexBox.Text += "\r\n";
            ResTexBox.Text += "\r\n";

            enumInt = ints.Take(3);
            ResTexBox.Text += ("enumInt = ints.Take(3): " + enumInt);
            ResTexBox.Text += "\r\n";
            enumInt = ints.TakeWhile(x => x != 4);//1,2
            ResTexBox.Text += ("enumInt = ints.TakeWhile(x => x != 4): " + enumInt);
            ResTexBox.Text += "\r\n";
            enumInt = ints.Skip(3);
            ResTexBox.Text += ("enumInt = ints.Skip(3): " + enumInt);
            ResTexBox.Text += "\r\n";
            enumInt = ints.SkipWhile(x => x != 4);//4,8,4,2,1
            ResTexBox.Text += ("enumInt = ints.SkipWhile(x => x != 4): " + enumInt);
            ResTexBox.Text += "\r\n";
            enumInt = ints.Distinct();// not repeated
            ResTexBox.Text += ("enumInt = ints.Distinct(): " + enumInt);
            ResTexBox.Text += "\r\n";
            enumInt = ints.Where(y => y == 2 || y == 4);
            ResTexBox.Text += ("enumInt = ints.Where(y => y == 2 || y == 4): " + enumInt);
            ResTexBox.Text += "\r\n";
            enumInt = ints.OrderBy(x => x);
            ResTexBox.Text += ("enumInt = ints.OrderBy(x => x): " + enumInt);
            ResTexBox.Text += "\r\n";
            enumInt = ints.OrderByDescending(x => x);
            ResTexBox.Text += ("enumInt = ints.OrderByDescending(x => x): " + enumInt);
            ResTexBox.Text += "\r\n";
            enumInt = ints.Cast<int>(); // match type 
            ResTexBox.Text += ("enumInt = ints.Cast<int>(): " + enumInt);
            ResTexBox.Text += "\r\n";
            enumInt = ints.Intersect(filter); //  1,2,8
            ResTexBox.Text += ("enumInt = ints.Intersect(filter): " + enumInt);
            ResTexBox.Text += "\r\n";
            enumInt = filter.ToArray().Reverse();
            ResTexBox.Text += ("enumInt = filter.ToArray().Reverse(): " + enumInt);
            ResTexBox.Text += "\r\n";
            enumInt = ints.Select(x => x);
            ResTexBox.Text += ("enumInt = ints.Select(x => x): " + enumInt);
            ResTexBox.Text += "\r\n";
            enumInt = strs.Select(x => x.Length);
            ResTexBox.Text += ("enumInt = strs.Select(x => x.Length): " + enumInt);
            ResTexBox.Text += "\r\n";
            enumInt = arrOfArr.SelectMany(x => x);
            ResTexBox.Text += ("enumInt = arrOfArr.SelectMany(x => x): " + enumInt);
            ResTexBox.Text += "\r\n";
            ResTexBox.Text += "\r\n";

            resStr = strs.FirstOrDefault(x => x.Length > 6);
            ResTexBox.Text += ("resStr = strs.FirstOrDefault(x => x.Length > 6): " + resStr);
            ResTexBox.Text += "\r\n";
            ResTexBox.Text += "\r\n";

            enumStr = strs.Select(x => x.ToUpper());
            ResTexBox.Text += ("enumStr = strs.Select(x => x.ToUpper()): " + enumStr);
            ResTexBox.Text += "\r\n";
            enumStr = strs.Where(x => x.Length > 3);
            ResTexBox.Text += ("enumStr = strs.Where(x => x.Length > 3): " + enumStr);
            ResTexBox.Text += "\r\n";
            ResTexBox.Text += "\r\n";

            enumStr =
                from x in strs        // specify the data source and take all the elements (they will be under the alias X) 
                where x.Length > 3    // selection condition 
                select x;             // what we will return to result 
            ResTexBox.Text += ("enumStr = x.Length > 3 SQL-like statement: " + enumStr);
            ResTexBox.Text += "\r\n";

            var result = arrOfArr
                .Select(x => x + ":" + x.Length) // one:3,two:3,three:5,four:4
                .Skip(2)
                .Sum(x => x.Length);
            ResTexBox.Text += ("result = arrOfArr... : " + result);
            ResTexBox.Text += "\r\n";
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
        private void LINQTestButton_Click(object sender, RoutedEventArgs e)
        {
            LINQTest();
        }        
        #endregion

        public MainWindow()
        {
            InitializeComponent();
        }


    }
}
