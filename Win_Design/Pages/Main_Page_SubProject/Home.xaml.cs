using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Enumeration;
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
using Win_Design.Cs;

namespace Win_Design.Pages.Main_Page_SubProject
{
    /// <summary>
    /// Home.xaml 的交互逻辑
    /// </summary>
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
            GL.Home = Home_Grid;
            string pluginName = "default";
            string fileName = $"{pluginName}.json";
            try {
                if (File.Exists(fileName))
                {
                    Cs.Plug.Load_Home.Load_Home_For_Json(File.ReadAllText(fileName));
                }
                else
                {
                    if (pluginName == "default")
                    {
                        var fs = File.Create("default.json");
                        fs.Close();
                        File.WriteAllText("default.json", "{\r\n  \"Main\": [\r\n    {\r\n      \"Name\": \"Wellcome\",\r\n      \"Text\": \"欢迎使用 Win-Design 设计器\",\r\n      \"Type\": \"Label\",\r\n      \"FontSize\": 18,\r\n      \"x\": 230,\r\n      \"y\": 10,\r\n      \"Wid\": 500,\r\n      \"Hei\": 80\r\n    },\r\n    {\r\n      \"Name\": \"Help\",\r\n      \"Text\": \"创建项目和打开项目请前往\\\"项目\\\"选项卡\",\r\n      \"Type\": \"Label\",\r\n      \"FontSize\": 15,\r\n      \"x\": 10,\r\n      \"y\": 60,\r\n      \"Wid\": 500,\r\n      \"Hei\": 80\r\n    },\r\n    {\r\n      \"Name\": \"Bilibili\",\r\n      \"Text\": \"Bilibili\",\r\n      \"Type\": \"Button\",\r\n      \"FontSize\": 15,\r\n      \"Command\": \"start https://space.bilibili.com/1527364468\",\r\n      \"x\": 10,\r\n      \"y\": 90,\r\n      \"Wid\": 100,\r\n      \"Hei\": 30\r\n    }\r\n  ]\r\n\r\n}");
                        Cs.Plug.Load_Home.Load_Home_For_Json(File.ReadAllText(fileName));
                    }
                    else
                    {
                        iNKORE.UI.WPF.Modern.Controls.MessageBox.Show($"未找到文件：{fileName}", "插件加载错误", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch(Exception ex){
                iNKORE.UI.WPF.Modern.Controls.MessageBox.Show($"{ex}", "插件加载错误", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
