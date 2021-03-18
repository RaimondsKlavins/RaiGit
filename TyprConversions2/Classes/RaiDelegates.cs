using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TyprConversions2.Classes
{
    class RaiDelegates
    {
        public delegate void RaiVoidDelegate();

        public delegate void RaiStringDelegate(string text);

        public delegate string RaiOutStringDelegate(string text);

        public delegate void RaiButtonDelegate(object sender, RoutedEventArgs e);
    }
}
