using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Win_Design.Cs.API.Json.Json;
using System.Windows;
using Win_Design.Cs.Custom_Type;
using System.IO;
using System.Windows.Controls;
using Win_Design.Cs.Project.Save_Project;

namespace Win_Design.Cs.API.Generate_Code
{
    internal class Make_Code
    {
        static Custom_Type.Make_Code_Window Make_Code_Windows = new Custom_Type.Make_Code_Window { 
            Include_Code = "#include <windows.h>\n\n",
            Window = "" +
            "LRESULT CALLBACK WndProc(HWND hwnd, UINT msg, WPARAM wParam, LPARAM lParam)\r\n" +
            "{\r\n" +
            "    switch (msg)\r\n" +
            "    {\r\n" +
            "        case WM_DESTROY:\r\n" +
            "        case WM_COMMAND:\r\n" +
            "        {\r\n" +
            "            break;\r\n" +
            "        }default:\r\n" +
            "            return DefWindowProc(hwnd, msg, wParam, lParam);\r\n" +
            "    }\r\n" +
            "    return 0;\r\n" +
            "}\r\n" +
            "int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpCmdLine, int nCmdShow)\r\n" +
            "{\r\n" +
            "    HWND hWnd = GetConsoleWindow();\r\n" +
            "    WNDCLASS wc = {0};\r\n" +
            "    wc.lpfnWndProc = WndProc;\r\n" +
            "    wc.hInstance = hInstance;\r\n" +
            "    wc.lpszClassName = \"Win32ControlsWindow\";\r\n" +
            "    RegisterClass(&wc);\r\n" +
            "    HWND hwnd = CreateWindow(wc.lpszClassName, \"${Title}\", WS_OVERLAPPEDWINDOW, 100, 100, ${Width},${Height},NULL, NULL, hInstance, NULL);\r\n" +
            "    \r\n" +
            "${Controls}" +
            "    \r\n"+
            "    ShowWindow(hwnd, nCmdShow);\r\n" +
            "    MSG msg = {0};\r\n" +
            "    while (GetMessage(&msg, NULL, 0, 0))\r\n" +
            "    {\r\n" +
            "        TranslateMessage(&msg);\r\n" +
            "        DispatchMessage(&msg);\r\n" +
            "    }\r\n" +
            "    return msg.wParam;\r\n" +
            "}",
            Label = "    CreateWindow(\"Static\", \"${Text}\", WS_CHILD | WS_VISIBLE | SS_CENTER,${X}, ${Y}, ${Width}, ${Height}, hwnd,(HMENU)0 ,hInstance, NULL);\n",
            Button = "    CreateWindow(\"Button\", \"${Text}\", WS_CHILD | WS_VISIBLE | BS_PUSHBUTTON,${X}, ${Y}, ${Width}, ${Height}, hwnd,(HMENU)0 ,hInstance, NULL);\n",
            TextBox = "    CreateWindow(\"Edit\", \"${Text}\", WS_CHILD | WS_VISIBLE | WS_BORDER | ES_AUTOHSCROLL,${X}, ${Y}, ${Width}, ${Height}, hwnd,(HMENU)0 ,hInstance, NULL);\n"
        };

        public static string Make_Cpp_Code()
        {
            List<Control> Items = new List<Control>();
            foreach (Control control in GL.design_window.Design_Grid.Children)
            {
                Items.Add(control);
            }
            Save_Project.Save_Design_File(Items);
            string Code = "";
            Code += Make_Code.Make_Code_Windows.Include_Code;
            Code += Make_Code.Make_Code_Windows.Window;

            Cs.API.Log.Logs.WriteLine($"开始读取项目设计文件");
            string json = File.ReadAllText(GL.Project_Path); // 将你的JSON字符串放在这里
            WindowConfig config = JsonConvert.DeserializeObject<Cs.API.Json.Json.WindowConfig>(json);
            Code=Code.Replace("${Title}", config.Title);
            Code = Code.Replace("${Width}", config.Size.Split('x')[0]);
            Code = Code.Replace("${Height}", config.Size.Split('x')[1]);
            Cs.API.Log.Logs.WriteLine($"设置大小...");
            string Control_Str = "";
            foreach (var item in config.Window)
            {
                Cs.API.Log.Logs.WriteLine("类型:" + item.Type);
                switch (item.Type)
                {
                    case "Label":
                        Control_Str += Make_Code_Windows.Label;
                        Control_Str = Control_Str.Replace("${Text}", item.Text);
                        Control_Str = Control_Str.Replace("${X}", item.X.ToString());
                        Control_Str = Control_Str.Replace("${Y}", item.Y.ToString());
                        Control_Str = Control_Str.Replace("${Width}", item.Wid.ToString());
                        Control_Str = Control_Str.Replace("${Height}", item.Hei.ToString());
                        break;
                    case "Button":
                        Control_Str += Make_Code_Windows.Button;
                        Control_Str = Control_Str.Replace("${Text}", item.Text);
                        Control_Str = Control_Str.Replace("${X}", item.X.ToString());
                        Control_Str = Control_Str.Replace("${Y}", item.Y.ToString());
                        Control_Str = Control_Str.Replace("${Width}", item.Wid.ToString());
                        Control_Str = Control_Str.Replace("${Height}", item.Hei.ToString());
                        break;
                    case "TextBox":
                        Control_Str += Make_Code_Windows.TextBox;
                        Control_Str=Control_Str.Replace("${Text}", item.Text);
                        Control_Str = Control_Str.Replace("${X}", item.X.ToString());
                        Control_Str = Control_Str.Replace("${Y}", item.Y.ToString());
                        Control_Str = Control_Str.Replace("${Width}", item.Wid.ToString());
                        Control_Str = Control_Str.Replace("${Height}", item.Hei.ToString());
                        break;
                    default:
                        Cs.API.Log.Logs.WriteLine($"报错?! 未知控件 {item.Name}\n类型 {item.Type}");
                        iNKORE.UI.WPF.Modern.Controls.
                            MessageBox.Show($"未知控件 {item.Name}\n类型 {item.Type}\n\n遇到此类问题请检查设计文件\n如无法排查请联系开发者或将软件更新到最新版本", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                }
            }
            Code=Code.Replace("${Controls}", Control_Str);

            return Code;
        }
    }
}
