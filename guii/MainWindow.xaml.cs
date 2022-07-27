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

namespace guii
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TestDemo.Control ctrl;
        public MainWindow()
        {
           
            InitializeComponent();
            ctrl = new TestDemo.Control();
            mainConsole.Text = ctrl.OutputCmd;
        }
        private void ClickOnEnter(object s, RoutedEventArgs a)
        {
            mainConsole.Text = "\n" + ctrl.InputCmd(cmdBox.Text);
            cmdBox.Clear();
        }
        private void Cmd_textChanged(object s, RoutedEventArgs a)
        {

        }
    }
}
