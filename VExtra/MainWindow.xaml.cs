using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Security.Policy;
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
using System.Windows.Threading;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Media.Animation;

namespace VExtra
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string response_status;
        public MainWindow()
        {
            InitializeComponent();

            progressbar.Width = 300;
            progressbar.Height = 5;

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += async (s, e) =>
            {
                progressbar.IsIndeterminate = true;
                timer.Stop();
                await StartLoading();
            };

            timer.Start();


        }

        private async Task StartLoading()
        {
            await Task.Delay(1000);
            textLoading.Text = "Проверяем соединение с интернетом";

            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync("http://www.google.com");
                response_status = response.StatusCode.ToString();
                
            }

            if (response_status == "OK")
                textLoading.Text = "Успешное соединение";
            else
            {               
                MessageBox.Show("Не удалось проверить соединение с интернетом. Убедитесь что интернет действительно подключен.\n\nПриложение будет закрыто", "Ошибка");
                this.Close();
            }
            await Task.Delay(1000);
            textLoading.Text = "Проверяем, чтобы ничего не сломалось :)";
            await Task.Delay(1500);
            textLoading.Text = "Наконец то запускаем приложение..";
            await Task.Delay(2000);
            textLoading.Text = "Приложение запущено";
            await Task.Delay(1000);
            DoubleAnimation startAnimation = new DoubleAnimation()
            {
                From = 1,
                To = 0,
                Duration = TimeSpan.FromMilliseconds(200)
            };
            startAnimation.Completed += (s, e) =>
            {
                this.Hide();
                Main mainwin = new Main();
                mainwin.Show();
            };
            BeginAnimation(UIElement.OpacityProperty, startAnimation);
            

        }
    }
}
