using System;
using System.Collections.Generic;
using System.Text;

namespace BeiDream.SbsAbp.Zero.Sessions.Dto
{
    public class ThemeLoginInfoDto
    {
        /// <summary>
        /// 显示Tab页签
        /// </summary>
        public  bool ShowPageTab { get; set; }
        public bool ShowHeaderMenus { get; set; }
        public int MaxTabCount { get; set; }
    }
}
