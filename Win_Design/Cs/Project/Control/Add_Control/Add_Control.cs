using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Win_Design.Windows.Control_Setting;

namespace Win_Design.Cs.Project.Add_Control
{
    class Add_Control
    {
        public static void Add(Type Control_Type)
        {
            Cs.API.Log.Logs.WriteLine($"添加控件");
            Windows.Control_Setting.Add_Control add_Control = new Windows.Control_Setting.Add_Control(Control_Type);
            add_Control.ShowDialog();
            try
            {
                GL.design_window.Add_Control(add_Control.Return_Control);
            }
            catch (Exception ex) { }
        }
    }
}
