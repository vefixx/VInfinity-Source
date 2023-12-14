using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using VExtra.Animations;
using VExtra.Data;
using VExtra.Modules;
using VExtra.UserControls;
using Forms = System.Windows.Forms;
namespace VExtra
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        OpacityAnimations opacityAnim = new OpacityAnimations();
        MoveAnimations moveAnim = new MoveAnimations();
        Forms.NotifyIcon notifyIcon;

        public Main()
        {
            setIconBuild();

            InitializeComponent();
            Loaded += (s, e) =>
            {
                CC.Content = new MainMenuControl();
                CC.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityIn);
            };
        }

        private void Close_win()
        {
            App.Current.Shutdown();
            notifyIcon.Visible = false;
            notifyIcon.Dispose();
        }

        public void setIconBuild()
        {
            notifyIcon = new Forms.NotifyIcon();
            notifyIcon.Icon = new System.Drawing.Icon("Resources\\iconLogo.ico");
            notifyIcon.Text = "V.INFINITY";
            notifyIcon.Click += NotifyIcon_Click;

            notifyIcon.ContextMenuStrip = new Forms.ContextMenuStrip();
            notifyIcon.ContextMenuStrip.Items.Add("Открыть", null, OnOpenClicked);
            notifyIcon.ContextMenuStrip.Items.Add("Закрыть", null, OnCloseClicked);


            notifyIcon.Visible = true;
        }

        private void OnCloseClicked(object sender, EventArgs e)
        {
            Close_win();
        }

        private void OnOpenClicked(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = WindowState.Normal;
            this.Activate();
        }

        private void NotifyIcon_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = WindowState.Normal;
            this.Activate();
        }

        private void btn_WindowMinimized_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btn_WindowClose_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();

            notifyIcon.ShowBalloonTip(3000, "V.INFINITY уведомление", "Приложение скрыто в трей. Открыть его можно в любой момент", Forms.ToolTipIcon.Info);
        }

        private void WindowDrag(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void bth_MainMenu_Hover(object sender, MouseEventArgs e)
        {
            Autoposter_btn.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityOut);
            Parser_btn.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityOut);
            Notifications_btn.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityOut);
            Logs_btn.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityOut);
            Settings_btn.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityOut);
        }

        private void btn_MainMenu_UnHover(object sender, MouseEventArgs e)
        {
            Autoposter_btn.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityIn);
            Parser_btn.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityIn);
            Notifications_btn.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityIn);
            Logs_btn.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityIn);
            Settings_btn.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityIn);
        }

        private void btn_Autoposter_Hover(object sender, MouseEventArgs e)
        {
            MainMenu_btn.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityOut);
            Parser_btn.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityOut);
            Notifications_btn.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityOut);
            Logs_btn.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityOut);
            Settings_btn.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityOut);
        }

        private void btn_Autoposter_UnHover(object sender, MouseEventArgs e)
        {
            MainMenu_btn.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityIn);
            Parser_btn.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityIn);
            Notifications_btn.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityIn);
            Logs_btn.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityIn);
            Settings_btn.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityIn);
        }

        private void btn_Parser_Hover(object sender, MouseEventArgs e)
        {
            MainMenu_btn.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityOut);
            Autoposter_btn.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityOut);
            Notifications_btn.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityOut);
            Logs_btn.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityOut);
            Settings_btn.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityOut);
        }

        private void btn_Parser_UnHover(object sender, MouseEventArgs e)
        {
            MainMenu_btn.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityIn);
            Autoposter_btn.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityIn);
            Notifications_btn.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityIn);
            Logs_btn.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityIn);
            Settings_btn.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityIn);
        }

        private void btn_Notifications_Hover(object sender, MouseEventArgs e)
        {
            MainMenu_btn.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityOut);
            Autoposter_btn.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityOut);
            Parser_btn.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityOut);
            Logs_btn.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityOut);
            Settings_btn.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityOut);
        }

        private void btn_Notification_UnHover(object sender, MouseEventArgs e)
        {
            MainMenu_btn.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityIn);
            Autoposter_btn.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityIn);
            Parser_btn.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityIn);
            Logs_btn.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityIn);
            Settings_btn.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityIn);
        }

        private void btn_Logs_Hover(object sender, MouseEventArgs e)
        {
            MainMenu_btn.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityOut);
            Autoposter_btn.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityOut);
            Parser_btn.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityOut);
            Notifications_btn.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityOut);
            Settings_btn.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityOut);
        }

        private void btn_Logs_UnHover(object sender, MouseEventArgs e)
        {
            MainMenu_btn.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityIn);
            Autoposter_btn.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityIn);
            Parser_btn.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityIn);
            Notifications_btn.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityIn);
            Settings_btn.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityIn);
        }

        private void btn_CFG_Hover(object sender, MouseEventArgs e)
        {
            MainMenu_btn.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityOut);
            Autoposter_btn.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityOut);
            Parser_btn.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityOut);
            Notifications_btn.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityOut);
            Logs_btn.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityOut);
        }

        private void btn_CFG_UnHover(object sender, MouseEventArgs e)
        {
            MainMenu_btn.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityIn);
            Autoposter_btn.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityIn);
            Parser_btn.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityIn);
            Notifications_btn.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityIn);
            Logs_btn.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityIn);
        }

        private void btn_MainMenu_Click(object sender, RoutedEventArgs e)
        {
            CC.Content = new MainMenuControl();
            CC.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityIn);
            CC.BeginAnimation(FrameworkElement.HeightProperty, moveAnim.moveUp);
        }

        private void btn_SettingsMenu_Click(object sender, RoutedEventArgs e)
        {
            CC.Content = new SettingsMenuControl();
            CC.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityIn);
            CC.BeginAnimation(FrameworkElement.HeightProperty, moveAnim.moveUp);
        }

        private void btn_NotificationMenu_Click(object sender, RoutedEventArgs e)
        {
            CC.Content = new NotificationMenuControl();
            CC.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityIn);
            CC.BeginAnimation(FrameworkElement.HeightProperty, moveAnim.moveUp);
        }

        private void btn_LogsMenu_Click(object sender, RoutedEventArgs e)
        {
            CC.Content = new LogsMenuControl();
            CC.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityIn);
            CC.BeginAnimation(FrameworkElement.HeightProperty, moveAnim.moveUp);
        }

        private void btn_ParserMenu_Click(object sender, RoutedEventArgs e)
        {
            CC.Content = new ParserMenuControl();
            CC.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityIn);
            CC.BeginAnimation(FrameworkElement.HeightProperty, moveAnim.moveUp);
        }

        private void btn_AutoPosterMenu_Click(object sender, RoutedEventArgs e)
        {
            CC.Content = new AutoPosterControl();
            CC.BeginAnimation(UIElement.OpacityProperty, opacityAnim.opacityIn);
            CC.BeginAnimation(FrameworkElement.HeightProperty, moveAnim.moveUp);
        }
    }
}
