using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Win_Design.Cs.API.Json
{
    class Json
    {
        public class WindowConfig
        {
            public string Title { get; set; }
            public string Size { get; set; }
            public List<WindowItem> Window { get; set; }
        }

        public class WindowItem
        {
            public string Name { get; set; }
            public string Text { get; set; }
            public string Type { get; set; }
            public int FontSize { get; set; }
            public int X { get; set; } // C#中属性名通常不使用小写字母开头
            public int Y { get; set; }
            public int Wid { get; set; }
            public int Hei { get; set; }
        }

        public class ControlItem
        {
            public string Name { get; set; }
            public string Text { get; set; }
            public string Type { get; set; }
            public int FontSize { get; set; }
            public int x { get; set; }
            public int y { get; set; }
            public int Wid { get; set; }
            public int Hei { get; set; }
            public string Command { get; set; }
        }
    }
}
