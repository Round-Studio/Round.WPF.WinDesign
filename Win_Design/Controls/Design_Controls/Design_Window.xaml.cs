using iNKORE.UI.WPF.Helpers;
using iNKORE.UI.WPF.Modern.Controls;
using iNKORE.UI.WPF.Modern.Controls.Primitives;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
using Win_Design.Cs.API;
using Win_Design.Cs.API.Json;
using Win_Design.Cs.Custom_Type;
using Win_Design.Cs.Project.Control.Control_Drag;
using Win_Design.Windows.Work;
using static System.Net.Mime.MediaTypeNames;
using static Win_Design.Cs.API.Json.Json;

namespace Win_Design.Controls.Design_Controls
{
    /// <summary>
    /// Design_Window.xaml 的交互逻辑
    /// </summary>
    public partial class Design_Window : UserControl
    {
        public Design_Window()
        {
            InitializeComponent();
        }
        public void Add_Control(Control control)
        {
            Drag_Main drag_Main = new Drag_Main();
            drag_Main.Drag_Control(control);

            Design_Grid.Children.Add(control);
        }
        public void Init_Window(string path)
        {
            Cs.API.Log.Logs.WriteLine($"初始化设计器启动...");
            Design_Grid.Children.Clear();
            Title_Label.Content = "Main Window";
            Cs.API.Log.Logs.WriteLine($"窗口初始化完毕");

            Cs.API.Log.Logs.WriteLine($"开始读取项目设计文件");
            string json = File.ReadAllText(path); // 将你的JSON字符串放在这里
            WindowConfig config = JsonConvert.DeserializeObject<Json.WindowConfig>(json);
            Title_Label.Content = config.Title;
            /*Design_Grid.Width = double.Parse(config.Size.Split('x')[0]);
            Design_Grid.Height = double.Parse(config.Size.Split('x')[1]);

            Title_Grid.Width= double.Parse(config.Size.Split('x')[0]);*/
            this.Width = double.Parse(config.Size.Split('x')[0])+10;
            this.Height = double.Parse(config.Size.Split('x')[1])+10;
            Cs.API.Log.Logs.WriteLine($"设置大小...");
            foreach (var item in config.Window)
            {
                Cs.API.Log.Logs.WriteLine("类型:"+item.Type);
                switch (item.Type)
                {
                    case "Label":
                        Num label_num = new Num
                        {
                            Text = item.Text,
                            X = item.X,
                            Y = item.Y,
                            Width = item.Wid,
                            Height = item.Hei,
                            Name = item.Name,
                        };
                        Controls.Design_Controls.Demo_Controls.Label label = new Demo_Controls.Label(label_num);
                        Add_Control(label);
                        break;
                    case "Button":
                        Num button_nums = new Num
                        {
                            Text = item.Text,
                            X = item.X,
                            Y = item.Y,
                            Width = item.Wid,
                            Height = item.Hei,
                            Name = item.Name,
                        };
                        Controls.Design_Controls.Demo_Controls.Button button = new Demo_Controls.Button(button_nums);
                        Add_Control(button);
                        break;
                    case "TextBox":
                        Num label_nums = new Num
                        {
                            Text = item.Text,
                            X = item.X,
                            Y = item.Y,
                            Width = item.Wid,
                            Height = item.Hei,
                            Name= item.Name,
                        };
                        Controls.Design_Controls.Demo_Controls.TextBox textBox = new Demo_Controls.TextBox(label_nums);
                        Add_Control(textBox);
                        break;
                    default:
                        Cs.API.Log.Logs.WriteLine($"报错?! 未知控件 {item.Name}\n类型 {item.Type}");
                        iNKORE.UI.WPF.Modern.Controls.
                            MessageBox.Show($"未知控件 {item.Name}\n类型 {item.Type}\n\n遇到此类问题请检查设计文件\n如无法排查请联系开发者或将软件更新到最新版本", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                }
            }
        }

        public string Get_Message()
        {
            Cs.API.Log.Logs.WriteLine($"获取信息");
            return ((int)this.Width-10).ToString() + "x" + ((int)this.Height-10).ToString() + "|" + Title_Label.Content;
        }

        public void Set_Message(string message)
        {
            string size = message.Split('|')[0];
            string title = message.Split('|')[1];
            Title_Label.Content = title;
            this.Width = double.Parse(size.Split("x")[0]) + 10;
            this.Height = double.Parse(size.Split("x")[1]) + 10;
            Cs.API.Log.Logs.WriteLine($"设置信息");
        }

        private void Label_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Cs.API.Log.Logs.WriteLine($"设置设计器大小");
            Setting_Window setting = new Setting_Window();
            setting.ShowDialog();
        }
    }
}
