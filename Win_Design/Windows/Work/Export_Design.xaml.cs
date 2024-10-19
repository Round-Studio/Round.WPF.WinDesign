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

namespace Win_Design.Windows.Work
{
    /// <summary>
    /// Export_Design.xaml 的交互逻辑
    /// </summary>
    public partial class Export_Design : Window
    {
        public Export_Design()
        {
            InitializeComponent();
        }
        public void Set_JD_Value_Init(int max)
        {
            JD_Bar.Maximum = max;
            JD_Bar.Minimum = 0;
        }
        public void Set_JD_Value_Add()
        {
            this.Dispatcher.Invoke(new Action(() =>
            {
                JD_Bar.Value = JD_Bar.Value + 1;
            }));
        }
    }
}
