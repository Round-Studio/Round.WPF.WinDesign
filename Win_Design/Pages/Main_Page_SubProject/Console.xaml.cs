using iNKORE.UI.WPF.Modern.Controls;
using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Win_Design.Cs.API.Log;

namespace Win_Design.Pages.Main_Page_SubProject
{
    /// <summary>
    /// Console.xaml 的交互逻辑
    /// </summary>
    public partial class Console : System.Windows.Controls.Page
    {
        public Console()
        {
            InitializeComponent();
            Task.Run(() =>
            {
                while (true) {
                    try
                    {
                        Logs_Box.Dispatcher.Invoke(() =>
                        {
                            Logs_Box.Text = Logs.Get_Logs();
                        });
                    }
                    catch (Exception ex) { }
                    Thread.Sleep(100);
                }
            });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "日志文件|*.log";
            saveFileDialog.FileName = $"{DateTime.Now.ToString("yyyy.MM.dd HH时mm分ss秒")}_Win-Design_日志文件";
            saveFileDialog.Title = "保存文件";

            bool? res = saveFileDialog.ShowDialog();
            if (res == true) { 
                File.WriteAllText(saveFileDialog.FileName, Logs.Get_Logs());
                iNKORE.UI.WPF.Modern.Controls.MessageBox.Show($"日志已保存到 {saveFileDialog.FileName}","提示",MessageBoxButton.OK,MessageBoxImage.Information);
            }
        }
    }
}
