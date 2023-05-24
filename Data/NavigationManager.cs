using courseproject.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace courseproject.Data
{
    static class NavigationManager
    {
        public static Frame MainFrame { get; set; }

        public static Frame SideMenuFrame { get; set; }

        public static Frame AddTabsFrame { get; set; }
    }
}
