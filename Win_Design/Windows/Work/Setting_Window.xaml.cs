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
using Win_Design.Cs;

namespace Win_Design.Windows.Work
{
    /// <summary>
    /// Setting_Window.xaml 的交互逻辑
    /// </summary>
    public partial class Setting_Window : Window
    {
        public Setting_Window()
        {
            InitializeComponent();
            string message = GL.design_window.Get_Message();
            string size = message.Split('|')[0];
            string title = message.Split('|')[1];
            TitleBox.Text = title;
            WidthBox.Text = size.Split("x")[0];
            HeightBox.Text = size.Split("x")[1];
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string return_str = $"{WidthBox.Text}x{HeightBox.Text}|{TitleBox.Text}";
            GL.design_window.Set_Message(return_str);
            Close();
        }
    }
}
