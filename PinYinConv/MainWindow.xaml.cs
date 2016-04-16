using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using PinYinConv.src.util;

namespace PinYinConv
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private delegate void setListBoxAnswerGate(string str);
        private void setListBoxAnswer(string str)
        {
            if (ListBoxAnswer.Dispatcher.Thread != Thread.CurrentThread)
            {
                setListBoxAnswerGate sg = new setListBoxAnswerGate(setListBoxAnswer);
                Dispatcher.Invoke(sg, new object[] { str });
            }
            else
            {
                ListBoxAnswer.Items.Add(str);
            }
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonFirst_Click(object sender, RoutedEventArgs e)
        {
            ListBoxAnswer.Items.Clear();
            string str = TextBoxCh.Text;
            if (string.IsNullOrWhiteSpace(str))
            {
                return;
            }
            string[] strs = PinYinUtils.strToFirst(str);
            foreach (string s in strs)
            {
                setListBoxAnswer(s);
            }
        }

        private void ButtonFull_Click(object sender, RoutedEventArgs e)
        {
            ListBoxAnswer.Items.Clear();
            string str = TextBoxCh.Text;
            if (string.IsNullOrWhiteSpace(str))
            {
                return;
            }
            string[] strs = PinYinUtils.strToFull(str);
            foreach (string s in strs)
            {
                setListBoxAnswer(s);
            }
        }
    }
}
