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
using Win_Design.Controls.Design_Controls.Demo_Controls;
using Win_Design.Cs;
using Win_Design.Cs.API.Log;
using Win_Design.Cs.Custom_Type;

namespace Win_Design.Windows.Control_Setting
{
    /// <summary>
    /// Setting_Control.xaml 的交互逻辑
    /// </summary>
    public partial class Setting_Control : Window
    {
        object sender;
        Control Controlss;
        public Setting_Control(Control control)
        {
            InitializeComponent();

            Controlss= control;
            string type = control.GetType().ToString().Replace("Win_Design.Controls.Design_Controls.Demo_Controls.","");

            Num num = new Num();
            switch (type) {
                case "Button":
                    Controls.Design_Controls.Demo_Controls.Button button = (Controls.Design_Controls.Demo_Controls.Button)control;
                    num = button.GetNum();
                    Controlss = button;
                    break;
                case "Label":
                    Controls.Design_Controls.Demo_Controls.Label label = (Controls.Design_Controls.Demo_Controls.Label)control;
                    num = label.GetNum();
                    Controlss=label;
                    break;
                case "TextBox":
                    Controls.Design_Controls.Demo_Controls.TextBox textbox = (Controls.Design_Controls.Demo_Controls.TextBox)control;
                    num = textbox.GetNum();
                    Controlss= textbox;
                    break;
            }

            Control_Name.Text = num.Name;
            Control_Text.Text = num.Text;
            Control_Width.Text = num.Width.ToString();
            Control_Height.Text = num.Height.ToString();
            Control_X.Text = num.X.ToString();
            Control_Y.Text = num.Y.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Num num = new Num
            {
                Name= Control_Name.Text,
                Text= Control_Text.Text,
                Width=int.Parse(Control_Width.Text),
                Height=int.Parse(Control_Height.Text),
                X=int.Parse(Control_X.Text),
                Y=int.Parse(Control_Y.Text)
            };
            string type = Controlss.GetType().ToString().Replace("Win_Design.Controls.Design_Controls.Demo_Controls.", "");
            Logs.WriteLine(Controlss.GetType()+"   |   "+ type);
            GL.design_window.Design_Grid.Children.Remove(Controlss);
            switch (type)
            {
                case "Button":
                    Controls.Design_Controls.Demo_Controls.Button button = new Controls.Design_Controls.Demo_Controls.Button(num);
                    GL.design_window.Add_Control(button);
                    break;
                case "Label":
                    Controls.Design_Controls.Demo_Controls.Label label = new Controls.Design_Controls.Demo_Controls.Label(num);
                    GL.design_window.Add_Control(label);
                    break;
                case "TextBox":
                    Controls.Design_Controls.Demo_Controls.TextBox textbox = new Controls.Design_Controls.Demo_Controls.TextBox(num);
                    GL.design_window.Add_Control(textbox);
                    break;
            }
            Close();
        }
    }
}
