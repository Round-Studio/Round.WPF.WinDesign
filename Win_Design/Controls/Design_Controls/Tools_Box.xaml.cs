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
using Win_Design.Cs.Project.Add_Control;

namespace Win_Design.Controls.Design_Controls
{
    /// <summary>
    /// Tools_Box.xaml 的交互逻辑
    /// </summary>
    public partial class Tools_Box : UserControl
    {
        public Tools_Box()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Add_Control.Add(typeof(Button));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Add_Control.Add(typeof(Label));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Add_Control.Add(typeof(TextBox));
        }
    }
}
