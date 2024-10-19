using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Diagnostics;

namespace Win_Design.Cs.Plug
{
    internal class Load_Home
    {
        public static void Load_Home_For_Json(string json)
        {
            GL.Home.Children.Clear();
            JObject jsonObject = JObject.Parse(json);
            JArray mainArray = (JArray)jsonObject["Main"];

            foreach (JObject controlObject in mainArray)
            {
                CreateControlFromJson(controlObject);
            }
        }
        private static void CreateControlFromJson(JObject controlObject)
        {
            string name = controlObject["Name"].ToString();
            string type = controlObject["Type"].ToString();
            int x = (int)controlObject["x"];
            int y = (int)controlObject["y"];
            int FontSize = (int)controlObject["FontSize"];
            int width = (int)controlObject["Wid"];
            int height = (int)controlObject["Hei"];

            Control control = null;
            switch (type)
            {
                case "Button":  
                    Button button = null;
                    string btn_text = controlObject["Text"].ToString();
                    string btn_command = controlObject["Command"].ToString();
                    button = new Button { Content = btn_text, Name = name, Width = width+10, Height = height+10,HorizontalAlignment=HorizontalAlignment.Center,VerticalAlignment=VerticalAlignment.Center,FontSize = FontSize };
                    button.Click += ((sender, equals) =>
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.UseShellExecute = false;
                        process.StartInfo.RedirectStandardOutput = true;
                        process.StartInfo.RedirectStandardInput = true;
                        process.StartInfo.CreateNoWindow = true;
                        process.Start();

                        process.StandardInput.WriteLine(btn_command);
                        process.StandardInput.Close();
                    });
                    control= button;
                    break;
                case "Label":
                    Control label = null;
                    string lab_text = controlObject["Text"].ToString();
                    label = new Label { Content = lab_text, Name = name, Width = width + 10, Height = height + 10, FontSize = FontSize };
                    control = label;
                    break;
                default:
                    iNKORE.UI.WPF.Modern.Controls.MessageBox.Show($"未知的控件:{type}","插件加载错误",MessageBoxButton.OK,MessageBoxImage.Error);
                    break;
            }

            if (control != null)
            {
                control.Margin = new Thickness(x, y, 680 - width - x, 450 - height - y);
                GL.Home.Children.Add(control);
            }
        }
    }
}
