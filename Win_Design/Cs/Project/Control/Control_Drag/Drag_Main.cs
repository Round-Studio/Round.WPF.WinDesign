using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Win_Design.Windows.Control_Setting;

namespace Win_Design.Cs.Project.Control.Control_Drag
{
    class Drag_Main
    {
        System.Windows.Controls.Control Controlss = null;
        public void Drag_Control(System.Windows.Controls.Control controls)
        {
            controls.MouseDown += Button_MouseDown;
            controls.MouseUp += Button_MouseUp;
            controls.MouseMove += Button_MouseMove;
            Cs.API.Log.Logs.WriteLine($"控件移动设置");
            Controlss = controls;
        }

        private Point _mouseDownPosition;
        private bool _isDragging = false;

        private void Button_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == Mouse.LeftButton)
            {
                // 记录鼠标按下时的位置
                _mouseDownPosition = e.GetPosition(null); // 获取相对于整个窗口的位置

                // 设置一个标志，表示开始拖拽
                _isDragging = true;
                Mouse.Capture(Controlss); // 开始捕获鼠标事件
            }
            else
            {
                Setting_Control setting_Control = new Setting_Control(Controlss);
                setting_Control.ShowDialog();
            }
        }

        private void Button_MouseMove(object sender, MouseEventArgs e)
        {
            // 如果鼠标被按下并移动
            if (_isDragging)
            {
                Point mousePosition = e.GetPosition(null); // 获取当前鼠标位置

                // 计算鼠标移动的距离
                Vector mouseDelta = mousePosition - _mouseDownPosition;

                // 更新控件的位置
                Controlss.Margin = new Thickness(
                    Controlss.Margin.Left + mouseDelta.X,
                    Controlss.Margin.Top + mouseDelta.Y,
                    0, 0);

                // 更新鼠标按下位置
                _mouseDownPosition = mousePosition;
            }
        }

        private void Button_MouseUp(object sender, MouseButtonEventArgs e)
        {
            // 鼠标释放时，结束拖拽
            _isDragging = false;
            Mouse.Capture(null); // 停止捕获鼠标事件
        }
    }
}
