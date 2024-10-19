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
using Win_Design.Cs.Custom_Type;
using static Win_Design.Controls.Design_Controls.Demo_Controls.TextBox;

namespace Win_Design.Controls.Design_Controls.Demo_Controls
{
    /// <summary>
    /// Button.xaml 的交互逻辑
    /// </summary>
    public partial class Button : UserControl
    {
        
        public Button(Num num)
        {
            InitializeComponent();
            InitializeComponent();
            Margin = new Thickness(num.X, num.Y, 0, 0);
            HorizontalAlignment = HorizontalAlignment.Left;
            VerticalAlignment = VerticalAlignment.Top;

            Width = num.Width;
            Height = num.Height;
            Texts.Content = num.Text;
            Name= num.Name;
        }
        public Num GetNum()
        {
            return new Num
            {
                Height = (int)this.Height,
                Width = (int)this.Width,
                Text = (string)Texts.Content,
                X = (int)Margin.Left,
                Y = (int)Margin.Top,
                Name = this.Name
            };
        }
    }
}
