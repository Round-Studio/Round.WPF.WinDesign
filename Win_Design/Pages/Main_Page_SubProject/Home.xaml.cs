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
                    iNKORE.UI.WPF.Modern.Controls.MessageBox.Show($"未找到文件：{fileName}", "插件加载错误", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch(Exception ex){
                iNKORE.UI.WPF.Modern.Controls.MessageBox.Show($"{ex}", "插件加载错误", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
