using iNKORE.UI.WPF.Modern.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Win_Design.Controls.Design_Controls;
using Win_Design.Cs;
using Win_Design.Cs.API;
using Win_Design.Cs.API.Generate_Code;
using Win_Design.Cs.API.Log;
using Win_Design.Cs.Project.Open_Project;
using Win_Design.Cs.Project.Save_Project;
using Win_Design.Windows;
using MessageBox = iNKORE.UI.WPF.Modern.Controls.MessageBox;

namespace Win_Design.Pages.Main_Page_SubProject.Project_SubProject
{
    /// <summary>
    /// Design_Page.xaml 的交互逻辑
    /// </summary>
    public partial class Design_Page : System.Windows.Controls.Page
    {
        public Design_Page()
        {
            InitializeComponent();
            Design_Window window = new Design_Window
            {
                Margin = new Thickness(10, 10, 0, 0),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
            };
            GL.design_window = window;
            Plane.Content = window;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (iNKORE.UI.WPF.Modern.Controls.MessageBox.Show("退出将会不保存当前所有进度！\n请保存后再退出！", "退出", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
            {
                Main_Page.project=new Project();
                Main_Page.Frames_Main.Navigate(Main_Page.project);
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            if (iNKORE.UI.WPF.Modern.Controls.MessageBox.Show("打开将会不保存当前所有进度！\n请打开后再打开！", "打开", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
            {
                string path = Open_Project.Open_Window_Return_Project_File();
                if (path != "notfile")
                {
                    Cs.API.Log.Logs.WriteLine($"初始化设计器");
                    Design_Page design_Page = new Design_Page();
                    Main_Page.project = design_Page;
                    Cs.API.Log.Logs.WriteLine($"载入设计器");
                    Main_Page.Frames_Main.Navigate(design_Page);
                    Cs.API.Log.Logs.WriteLine($"载入页面");
                    Open_Project.Open_Project_Make_Design_Window(path);
                }
            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            if (iNKORE.UI.WPF.Modern.Controls.MessageBox.Show("新建将会不保存当前所有进度！\n请保存后再新建！", "新建", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
            {
                Add_Project add_Project = new Add_Project();
                add_Project.ShowDialog();
            }
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            List<Control> Items = new List<Control>();
            foreach(Control control in GL.design_window.Design_Grid.Children)
            {
                Items.Add(control);
            }
            Save_Project.Save_Design_File(Items);
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            Logs.WriteLine("生成C文件...");

            string name = GL.Project_Path.Replace(".WDPro", ".cpp");
            File.WriteAllText(name, Make_Code.Make_Cpp_Code());
            MessageBox.Show($"文件已生成至 {name}","提示",MessageBoxButton.OK,MessageBoxImage.Information);
        }
    }
}
