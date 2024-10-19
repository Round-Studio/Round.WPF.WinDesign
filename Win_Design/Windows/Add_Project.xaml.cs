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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Win_Design.Cs;
using Win_Design.Cs.Project.Open_Project;
using Win_Design.Pages.Main_Page_SubProject.Project_SubProject;
using Win_Design.Pages;

namespace Win_Design.Windows
{
    /// <summary>
    /// Add_Project.xaml 的交互逻辑
    /// </summary>
    public partial class Add_Project : Window
    {
        public Add_Project()
        {
            InitializeComponent();
            List<string> strings = new List<string>();
            strings.Add("C++");
            foreach(string s in strings)
            {
                Project_Type.Items.Add(s);
            }
            Project_Type.SelectedIndex = 0;

            Project_Path.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GL.Project_Path = Project_Path.Text + "\\" + Name.Text + ".WDPro";
            File.WriteAllText(GL.Project_Path, "{\r\n    \"Title\": \"Main Window\",\r\n    \"Size\": \"320x250\",\r\n    \"Window\": []\r\n  }");
            Cs.API.Log.Logs.WriteLine($"初始化设计器");
            Design_Page design_Page = new Design_Page();
            Main_Page.project = design_Page;
            Cs.API.Log.Logs.WriteLine($"载入设计器");
            Main_Page.Frames_Main.Navigate(design_Page);
            Cs.API.Log.Logs.WriteLine($"载入页面");
            Open_Project.Open_Project_Make_Design_Window(GL.Project_Path);
            Close();
        }
    }
}
