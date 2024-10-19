using iNKORE.UI.WPF.Modern.Controls;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Win_Design.Controls.Design_Controls;

namespace Win_Design.Cs.Project.Open_Project
{
    class Open_Project
    {
        public static string Open_Window_Return_Project_File()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "选择文件";
            openFileDialog.Filter = "Win-Design项目文件 (*.WDPro)|*.WDPro";

            bool? result = openFileDialog.ShowDialog();

            if (result == true)
            {
                string filePath = openFileDialog.FileName;
                GL.Project_Path = filePath;
                return filePath;
            }

            return "notfile";
        }

        public static bool Open_Project_Make_Design_Window(string Project_File_Path)
        {
            Cs.API.Log.Logs.WriteLine($"初始化控件...");
            GL.design_window.Init_Window(Project_File_Path);
            Cs.API.Log.Logs.WriteLine($"初始化控件完毕");
            return true;
        }
    }
}
