using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Win_Design.Controls.Design_Controls.Demo_Controls;
using Win_Design.Cs.Custom_Type;
using Win_Design.Windows.Work;
using static Win_Design.Cs.API.Json.Json;

namespace Win_Design.Cs.Project.Save_Project
{
    class Save_Project
    {
        public static void Save_Design_File(List<System.Windows.Controls.Control> Items)
        {
            Export_Design export_Design = new Export_Design();
            export_Design.Set_JD_Value_Init(Items.Count);
            Task.Run(() =>
            {
                Thread.Sleep(300);
                List<WindowItem> windowItems = new List<WindowItem>();
                foreach (System.Windows.Controls.Control item in Items)
                {
                    Cs.API.Log.Logs.WriteLine("类型:"+item.ToString());
                    switch (item.GetType().ToString().Replace("Win_Design.Controls.Design_Controls.Demo_Controls.", ""))
                    {
                        case "Button":
                            Controls.Design_Controls.Demo_Controls.Button button = (Controls.Design_Controls.Demo_Controls.Button)item;
                            button.Dispatcher.Invoke(new Action(() =>
                            {
                                Num num = button.GetNum();
                                windowItems.Add(new WindowItem
                                {
                                    Name = num.Name,
                                    Text = num.Text,
                                    Type = "Button",
                                    X = (int)num.X,
                                    Y = (int)num.Y,
                                    Wid = (int)num.Width,
                                    Hei = (int)num.Height
                                });
                            }));
                            break;
                        case "TextBox":
                            Controls.Design_Controls.Demo_Controls.TextBox textBox = (Controls.Design_Controls.Demo_Controls.TextBox)item;
                            textBox.Dispatcher.Invoke(new Action(() =>
                            {
                                Num num = textBox.GetNum();
                                windowItems.Add(new WindowItem
                                {
                                    Name = num.Name,
                                    Text = num.Text,
                                    Type = "TextBox",
                                    X = (int)num.X,
                                    Y = (int)num.Y,
                                    Wid = (int)num.Width,
                                    Hei = (int)num.Height
                                });
                            }));
                            break;
                        case "Label":
                            Controls.Design_Controls.Demo_Controls.Label label = (Controls.Design_Controls.Demo_Controls.Label)item;
                            label.Dispatcher.Invoke(new Action(() =>
                            {
                                Num num = label.GetNum();
                                windowItems.Add(new WindowItem
                                {
                                    Name = num.Name,
                                    Text = num.Text,
                                    Type = "Label",
                                    X = (int)num.X,
                                    Y = (int)num.Y,
                                    Wid = (int)num.Width,
                                    Hei = (int)num.Height
                                });
                            }));
                            break;
                    }
                    export_Design.Set_JD_Value_Add();
                    Thread.Sleep(10);
                }
                

                GL.design_window.Dispatcher.Invoke(new Action(() =>
                {
                    string temp = GL.design_window.Get_Message();
                    WindowConfig config = new WindowConfig
                    {
                        Title = temp.Split('|')[1],
                        Size = temp.Split('|')[0],
                        Window = windowItems
                    };

                    // 将对象序列化为JSON字符串
                    string json = JsonConvert.SerializeObject(config, Formatting.Indented);
                    File.WriteAllText(GL.Project_Path, json);
                }));
                Thread.Sleep(800);
                export_Design.Dispatcher.Invoke(new Action(() =>
                {
                    export_Design.Close();
                }));
            });
            export_Design.ShowDialog();
        }
    }
}
