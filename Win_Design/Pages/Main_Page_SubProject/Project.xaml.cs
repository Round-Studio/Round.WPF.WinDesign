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
using Win_Design.Cs;
using Win_Design.Cs.Project.Open_Project;
using Win_Design.Pages.Main_Page_SubProject.Project_SubProject;
using Win_Design.Windows;

namespace Win_Design.Pages.Main_Page_SubProject
{
    /// <summary>
    /// Project.xaml 的交互逻辑
    /// </summary>
    public partial class Project : Page
    {
        public Project()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Cs.API.Log.Logs.WriteLine("新建项目...");
            Add_Project project = new Add_Project();
            project.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Cs.API.Log.Logs.WriteLine("打开项目...");
            string path = Open_Project.Open_Window_Return_Project_File();
            Cs.API.Log.Logs.WriteLine($"返回:{path}");
            if (path != "notfile")
            {
                Cs.API.Log.Logs.WriteLine($"初始化设计器");
                Design_Page design_Page = new Design_Page();
                Main_Page.project = design_Page;
                Cs.API.Log.Logs.WriteLine($"初始化页面");
                Main_Page.Frames_Main.Navigate(design_Page);
                Cs.API.Log.Logs.WriteLine($"载入页面");
                Open_Project.Open_Project_Make_Design_Window(path);
                Cs.API.Log.Logs.WriteLine($"打开项目...");
            }
        }
    }
}
