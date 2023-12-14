using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using VExtra.Data;
using VExtra.Modules;
using Forms = System.Windows.Forms;

namespace VExtra
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        EventMessages eventMessages;
        Forms.NotifyIcon notifyIcon;      


        protected override void OnStartup(StartupEventArgs e)
        {
            eventMessages = new EventMessages();

            base.OnStartup(e);
            

            eventMessages.Start("TOKEN");
        }

        public void ShowNotif()
        {
            notifyIcon.ShowBalloonTip(3000, "2", "2", Forms.ToolTipIcon.Info);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            eventMessages.Stop();
        }

        
    }
}
