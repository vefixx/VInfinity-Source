using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forms = System.Windows.Forms;

namespace VExtra.Data
{
    public class DataClass
    {
        public Forms.NotifyIcon notifyIcon { get; set; }
        

        public void ShowNotif()
        {
            notifyIcon.ShowBalloonTip(3000, "test", "test", Forms.ToolTipIcon.Info);
        }
    }
}
