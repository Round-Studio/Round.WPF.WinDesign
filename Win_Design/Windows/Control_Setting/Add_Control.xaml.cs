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
using Win_Design.Cs.Custom_Type;

namespace Win_Design.Windows.Control_Setting
{
    /// <summary>
    /// Add_Control.xaml 的交互逻辑
    /// </summary>
    public partial class Add_Control : Window
    {
        public Control Return_Control;
        Type type;
        public Add_Control(Type types)
        {
            InitializeComponent();

            type = types;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (type == typeof(Button))
            {
                Num num = new Num
                {
                    Name = Control_Name.Text,
                    Width = int.Parse(Control_Width.Text),
                    Height = int.Parse(Control_Height.Text),
                    X = int.Parse(Control_X.Text),
                    Y = int.Parse(Control_Y.Text),
                    Text = Control_Text.Text
                };
                Controls.Design_Controls.Demo_Controls.Button button = new Controls.Design_Controls.Demo_Controls.Button(num);
                Return_Control= button;
            }
            else if (type == typeof(TextBox))
            {
                Num num = new Num
                {
                    Name = Control_Name.Text,
                    Width = int.Parse(Control_Width.Text),
                    Height = int.Parse(Control_Height.Text),
                    X = int.Parse(Control_X.Text),
                    Y = int.Parse(Control_Y.Text),
                    Text = Control_Text.Text
                };
                Controls.Design_Controls.Demo_Controls.TextBox textBox = new Controls.Design_Controls.Demo_Controls.TextBox(num);
                Return_Control= textBox;
            }
            else if (type == typeof(Label)) {
                Num num = new Num
                {
                    Name = Control_Name.Text,
                    Width = int.Parse(Control_Width.Text),
                    Height = int.Parse(Control_Height.Text),
                    X = int.Parse(Control_X.Text),
                    Y = int.Parse(Control_Y.Text),
                    Text = Control_Text.Text
                };
                Controls.Design_Controls.Demo_Controls.Label label = new Controls.Design_Controls.Demo_Controls.Label(num);
                Return_Control = label;
            }
            Close();
        }
    }
}
