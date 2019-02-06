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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Windows.Threading;

namespace News_BG
{
    
    public partial class MainWindow : Window
    {
        string apiKey = "f8e8b82441ea475e8fb5d5d14707fc7b";
        string country;
        
        
        

        public MainWindow()
        {
            InitializeComponent();
            startclock();
            
        }

        private void startclock()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += tickevent;
            timer.Start();
        }

        private void tickevent(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //Date.Content = DateTime.Now.ToString(@"dd\.MM\.20yy");
            Clock.Content = DateTime.Now.ToString(@"hh\:mm");
        }

        private void BG_Click(object sender, RoutedEventArgs e)
        {
            lb_main.Visibility = Visibility.Visible;
            lb_main.BorderBrush = new SolidColorBrush(Colors.DarkGreen);
            lb_main.BorderThickness = new Thickness(5);
            Date.Content = DateTime.Now.ToString(@"dd\.MM\.20yy");
            country = "BG";
            Uri uri = new Uri("https://newsapi.org/v2/top-headlines?country=" + country + "&apiKey=" + apiKey);
            WebRequest request = WebRequest.Create(uri);
            try
            {
                request.GetResponse();
            }
            catch
            {
                lb_main.Visibility = Visibility.Hidden;
                MessageBox.Show("Internet connection problem!");
                return;
            }
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string responseData = reader.ReadToEnd();
            var outObject = JsonConvert.DeserializeObject<NewsData.RootObject>(responseData);

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_0.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[0].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[0].urlToImage == null)
                {
                    tb_urltoimage_0.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_0.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[0].urlToImage)));
                }
            }
            tb_name_0.Text = outObject.articles[0].source.name;
            tb_title_0.Text = outObject.articles[0].title;
            tb_description_0.Text = outObject.articles[0].description;
            tb_url_0.Text = outObject.articles[0].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_1.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[1].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[1].urlToImage == null)
                {
                    tb_urltoimage_1.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_1.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[1].urlToImage)));
                }
            }
            tb_name_1.Text = outObject.articles[1].source.name;
            tb_title_1.Text = outObject.articles[1].title;
            tb_description_1.Text = outObject.articles[1].description;
            tb_url_1.Text = outObject.articles[1].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_2.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[2].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[2].urlToImage == null)
                {
                    tb_urltoimage_2.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_2.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[2].urlToImage)));
                }
            }
            tb_name_2.Text = outObject.articles[2].source.name;
            tb_title_2.Text = outObject.articles[2].title;
            tb_description_2.Text = outObject.articles[2].description;
            tb_url_2.Text = outObject.articles[2].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_3.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[3].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[3].urlToImage == null)
                {
                    tb_urltoimage_3.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_3.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[3].urlToImage)));
                }
            }
            tb_name_3.Text = outObject.articles[3].source.name;
            tb_title_3.Text = outObject.articles[3].title;
            tb_description_3.Text = outObject.articles[3].description;
            tb_url_3.Text = outObject.articles[3].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_4.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[4].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[4].urlToImage == null)
                {
                    tb_urltoimage_4.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_4.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[4].urlToImage)));
                }
            }
            tb_name_4.Text = outObject.articles[4].source.name;
            tb_title_4.Text = outObject.articles[4].title;
            tb_description_4.Text = outObject.articles[4].description;
            tb_url_4.Text = outObject.articles[4].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_5.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[5].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[5].urlToImage == null)
                {
                    tb_urltoimage_5.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_5.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[5].urlToImage)));
                }
            }
            
            tb_name_5.Text = outObject.articles[5].source.name;
            tb_title_5.Text = outObject.articles[5].title;
            tb_description_5.Text = outObject.articles[5].description;
            tb_url_5.Text = outObject.articles[5].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_6.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[6].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[6].urlToImage == null)
                {
                    tb_urltoimage_6.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_6.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[6].urlToImage)));
                }
            }
            tb_name_6.Text = outObject.articles[6].source.name;
            tb_title_6.Text = outObject.articles[6].title;
            tb_description_6.Text = outObject.articles[6].description;
            tb_url_6.Text = outObject.articles[6].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_7.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[7].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[7].urlToImage == null)
                {
                    tb_urltoimage_7.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_7.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[7].urlToImage)));
                }
            }
            tb_name_7.Text = outObject.articles[7].source.name;
            tb_title_7.Text = outObject.articles[7].title;
            tb_description_7.Text = outObject.articles[7].description;
            tb_url_7.Text = outObject.articles[7].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_8.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[8].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[8].urlToImage == null)
                {
                    tb_urltoimage_8.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_8.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[8].urlToImage)));
                }
            }
            tb_name_8.Text = outObject.articles[8].source.name;
            tb_title_8.Text = outObject.articles[8].title;
            tb_description_8.Text = outObject.articles[8].description;
            tb_url_8.Text = outObject.articles[8].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_9.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[9].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[9].urlToImage == null)
                {
                    tb_urltoimage_9.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_9.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[9].urlToImage)));
                }
            }
            tb_name_9.Text = outObject.articles[9].source.name;
            tb_title_9.Text = outObject.articles[9].title;
            tb_description_9.Text = outObject.articles[9].description;
            tb_url_9.Text = outObject.articles[9].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_10.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[10].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[10].urlToImage == null)
                {
                    tb_urltoimage_10.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_10.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[10].urlToImage)));
                }
            }
            tb_name_10.Text = outObject.articles[10].source.name;
            tb_title_10.Text = outObject.articles[10].title;
            tb_description_10.Text = outObject.articles[10].description;
            tb_url_10.Text = outObject.articles[10].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_11.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[11].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[11].urlToImage == null)
                {
                    tb_urltoimage_11.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_11.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[11].urlToImage)));
                }
            }
            tb_name_11.Text = outObject.articles[11].source.name;
            tb_title_11.Text = outObject.articles[11].title;
            tb_description_11.Text = outObject.articles[11].description;
            tb_url_11.Text = outObject.articles[11].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_12.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[12].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[12].urlToImage == null)
                {
                    tb_urltoimage_12.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_12.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[12].urlToImage)));
                }
            }
            tb_name_12.Text = outObject.articles[12].source.name;
            tb_title_12.Text = outObject.articles[12].title;
            tb_description_12.Text = outObject.articles[12].description;
            tb_url_12.Text = outObject.articles[12].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_13.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[13].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[13].urlToImage == null)
                {
                    tb_urltoimage_13.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_13.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[13].urlToImage)));
                }
            }
            tb_name_13.Text = outObject.articles[13].source.name;
            tb_title_13.Text = outObject.articles[13].title;
            tb_description_13.Text = outObject.articles[13].description;
            tb_url_13.Text = outObject.articles[13].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_14.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[14].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[14].urlToImage == null)
                {
                    tb_urltoimage_14.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_14.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[14].urlToImage)));
                }
            }
            tb_name_14.Text = outObject.articles[14].source.name;
            tb_title_14.Text = outObject.articles[14].title;
            tb_description_14.Text = outObject.articles[14].description;
            tb_url_14.Text = outObject.articles[14].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_15.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[15].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[15].urlToImage == null)
                {
                    tb_urltoimage_15.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_15.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[15].urlToImage)));
                }
            }
            tb_name_15.Text = outObject.articles[15].source.name;
            tb_title_15.Text = outObject.articles[15].title;
            tb_description_15.Text = outObject.articles[15].description;
            tb_url_15.Text = outObject.articles[15].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_16.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[16].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[16].urlToImage == null)
                {
                    tb_urltoimage_16.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_16.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[16].urlToImage)));
                }
            }
            tb_name_16.Text = outObject.articles[16].source.name;
            tb_title_16.Text = outObject.articles[16].title;
            tb_description_16.Text = outObject.articles[16].description;
            tb_url_16.Text = outObject.articles[16].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_17.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[17].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[17].urlToImage == null)
                {
                    tb_urltoimage_17.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_17.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[17].urlToImage)));
                }
            }
            tb_name_17.Text = outObject.articles[17].source.name;
            tb_title_17.Text = outObject.articles[17].title;
            tb_description_17.Text = outObject.articles[17].description;
            tb_url_17.Text = outObject.articles[17].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_18.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[18].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[18].urlToImage == null)
                {
                    tb_urltoimage_18.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_18.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[18].urlToImage)));
                }
            }
            tb_name_18.Text = outObject.articles[18].source.name;
            tb_title_18.Text = outObject.articles[18].title;
            tb_description_18.Text = outObject.articles[18].description;
            tb_url_18.Text = outObject.articles[18].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_19.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[19].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[19].urlToImage == null)
                {
                    tb_urltoimage_19.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_19.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[19].urlToImage)));
                }
            }
            tb_name_19.Text = outObject.articles[19].source.name;
            tb_title_19.Text = outObject.articles[19].title;
            tb_description_19.Text = outObject.articles[19].description;
            tb_url_19.Text = outObject.articles[19].url;
           
          
        }

        private void US_Click(object sender, RoutedEventArgs e)
        {
            lb_main.Visibility = Visibility.Visible;
            lb_main.BorderBrush = new SolidColorBrush(Colors.DarkRed);
            lb_main.BorderThickness = new Thickness(5);
            country = "US";
            Date.Content = DateTime.Now.ToString(@"dd\.MM\.20yy");
            Uri uri = new Uri("https://newsapi.org/v2/top-headlines?country=" + country + "&apiKey=" + apiKey);
            WebRequest request = WebRequest.Create(uri);
            try
            {
                request.GetResponse();
            }
            catch
            {
                lb_main.Visibility = Visibility.Hidden;
                MessageBox.Show("Internet connection problem!");
                return;
            }
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string responseData = reader.ReadToEnd();
            var outObject = JsonConvert.DeserializeObject<NewsData.RootObject>(responseData);

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_0.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[0].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[0].urlToImage == null)
                {
                    tb_urltoimage_0.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_0.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[0].urlToImage)));
                }
            }
            tb_name_0.Text = outObject.articles[0].source.name;
            tb_title_0.Text = outObject.articles[0].title;
            tb_description_0.Text = outObject.articles[0].description;
            tb_url_0.Text = outObject.articles[0].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_1.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[1].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[1].urlToImage == null)
                {
                    tb_urltoimage_1.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_1.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[1].urlToImage)));
                }
            }
            tb_name_1.Text = outObject.articles[1].source.name;
            tb_title_1.Text = outObject.articles[1].title;
            tb_description_1.Text = outObject.articles[1].description;
            tb_url_1.Text = outObject.articles[1].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_2.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[2].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[2].urlToImage == null)
                {
                    tb_urltoimage_2.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_2.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[2].urlToImage)));
                }
            }
            tb_name_2.Text = outObject.articles[2].source.name;
            tb_title_2.Text = outObject.articles[2].title;
            tb_description_2.Text = outObject.articles[2].description;
            tb_url_2.Text = outObject.articles[2].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_3.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[3].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[3].urlToImage == null)
                {
                    tb_urltoimage_3.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_3.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[3].urlToImage)));
                }
            }
            tb_name_3.Text = outObject.articles[3].source.name;
            tb_title_3.Text = outObject.articles[3].title;
            tb_description_3.Text = outObject.articles[3].description;
            tb_url_3.Text = outObject.articles[3].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_4.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[4].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[4].urlToImage == null)
                {
                    tb_urltoimage_4.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_4.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[4].urlToImage)));
                }
            }
            tb_name_4.Text = outObject.articles[4].source.name;
            tb_title_4.Text = outObject.articles[4].title;
            tb_description_4.Text = outObject.articles[4].description;
            tb_url_4.Text = outObject.articles[4].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_5.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[5].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[5].urlToImage == null)
                {
                    tb_urltoimage_5.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_5.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[5].urlToImage)));
                }
            }

            tb_name_5.Text = outObject.articles[5].source.name;
            tb_title_5.Text = outObject.articles[5].title;
            tb_description_5.Text = outObject.articles[5].description;
            tb_url_5.Text = outObject.articles[5].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_6.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[6].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[6].urlToImage == null)
                {
                    tb_urltoimage_6.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_6.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[6].urlToImage)));
                }
            }
            tb_name_6.Text = outObject.articles[6].source.name;
            tb_title_6.Text = outObject.articles[6].title;
            tb_description_6.Text = outObject.articles[6].description;
            tb_url_6.Text = outObject.articles[6].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_7.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[7].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[7].urlToImage == null)
                {
                    tb_urltoimage_7.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_7.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[7].urlToImage)));
                }
            }
            tb_name_7.Text = outObject.articles[7].source.name;
            tb_title_7.Text = outObject.articles[7].title;
            tb_description_7.Text = outObject.articles[7].description;
            tb_url_7.Text = outObject.articles[7].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_8.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[8].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[8].urlToImage == null)
                {
                    tb_urltoimage_8.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_8.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[8].urlToImage)));
                }
            }
            tb_name_8.Text = outObject.articles[8].source.name;
            tb_title_8.Text = outObject.articles[8].title;
            tb_description_8.Text = outObject.articles[8].description;
            tb_url_8.Text = outObject.articles[8].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_9.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[9].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[9].urlToImage == null)
                {
                    tb_urltoimage_9.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_9.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[9].urlToImage)));
                }
            }
            tb_name_9.Text = outObject.articles[9].source.name;
            tb_title_9.Text = outObject.articles[9].title;
            tb_description_9.Text = outObject.articles[9].description;
            tb_url_9.Text = outObject.articles[9].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_10.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[10].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[10].urlToImage == null)
                {
                    tb_urltoimage_10.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_10.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[10].urlToImage)));
                }
            }
            tb_name_10.Text = outObject.articles[10].source.name;
            tb_title_10.Text = outObject.articles[10].title;
            tb_description_10.Text = outObject.articles[10].description;
            tb_url_10.Text = outObject.articles[10].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_11.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[11].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[11].urlToImage == null)
                {
                    tb_urltoimage_11.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_11.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[11].urlToImage)));
                }
            }
            tb_name_11.Text = outObject.articles[11].source.name;
            tb_title_11.Text = outObject.articles[11].title;
            tb_description_11.Text = outObject.articles[11].description;
            tb_url_11.Text = outObject.articles[11].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_12.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[12].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[12].urlToImage == null)
                {
                    tb_urltoimage_12.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_12.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[12].urlToImage)));
                }
            }
            tb_name_12.Text = outObject.articles[12].source.name;
            tb_title_12.Text = outObject.articles[12].title;
            tb_description_12.Text = outObject.articles[12].description;
            tb_url_12.Text = outObject.articles[12].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_13.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[13].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[13].urlToImage == null)
                {
                    tb_urltoimage_13.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_13.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[13].urlToImage)));
                }
            }
            tb_name_13.Text = outObject.articles[13].source.name;
            tb_title_13.Text = outObject.articles[13].title;
            tb_description_13.Text = outObject.articles[13].description;
            tb_url_13.Text = outObject.articles[13].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_14.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[14].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[14].urlToImage == null)
                {
                    tb_urltoimage_14.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_14.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[14].urlToImage)));
                }
            }
            tb_name_14.Text = outObject.articles[14].source.name;
            tb_title_14.Text = outObject.articles[14].title;
            tb_description_14.Text = outObject.articles[14].description;
            tb_url_14.Text = outObject.articles[14].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_15.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[15].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[15].urlToImage == null)
                {
                    tb_urltoimage_15.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_15.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[15].urlToImage)));
                }
            }
            tb_name_15.Text = outObject.articles[15].source.name;
            tb_title_15.Text = outObject.articles[15].title;
            tb_description_15.Text = outObject.articles[15].description;
            tb_url_15.Text = outObject.articles[15].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_16.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[16].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[16].urlToImage == null)
                {
                    tb_urltoimage_16.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_16.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[16].urlToImage)));
                }
            }
            tb_name_16.Text = outObject.articles[16].source.name;
            tb_title_16.Text = outObject.articles[16].title;
            tb_description_16.Text = outObject.articles[16].description;
            tb_url_16.Text = outObject.articles[16].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_17.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[17].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[17].urlToImage == null)
                {
                    tb_urltoimage_17.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_17.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[17].urlToImage)));
                }
            }
            tb_name_17.Text = outObject.articles[17].source.name;
            tb_title_17.Text = outObject.articles[17].title;
            tb_description_17.Text = outObject.articles[17].description;
            tb_url_17.Text = outObject.articles[17].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_18.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[18].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[18].urlToImage == null)
                {
                    tb_urltoimage_18.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_18.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[18].urlToImage)));
                }
            }
            tb_name_18.Text = outObject.articles[18].source.name;
            tb_title_18.Text = outObject.articles[18].title;
            tb_description_18.Text = outObject.articles[18].description;
            tb_url_18.Text = outObject.articles[18].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_19.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[19].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[19].urlToImage == null)
                {
                    tb_urltoimage_19.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_19.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[19].urlToImage)));
                }
            }
            tb_name_19.Text = outObject.articles[19].source.name;
            tb_title_19.Text = outObject.articles[19].title;
            tb_description_19.Text = outObject.articles[19].description;
            tb_url_19.Text = outObject.articles[19].url;
        }

        private void GB_Click(object sender, RoutedEventArgs e)
        {
            lb_main.Visibility = Visibility.Visible;
            lb_main.BorderBrush = new SolidColorBrush(Colors.DarkBlue);
            lb_main.BorderThickness = new Thickness(5);
            Date.Content = DateTime.Now.ToString(@"dd\.MM\.20yy");
            country = "GB";
            Uri uri = new Uri("https://newsapi.org/v2/top-headlines?country=" + country + "&apiKey=" + apiKey);
            WebRequest request = WebRequest.Create(uri);
            try
            {
                request.GetResponse();
            }
            catch
            {
                lb_main.Visibility = Visibility.Hidden;
                MessageBox.Show("Internet connection problem!");
                return;
            }
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string responseData = reader.ReadToEnd();
            var outObject = JsonConvert.DeserializeObject<NewsData.RootObject>(responseData);

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_0.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[0].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[0].urlToImage == null)
                {
                    tb_urltoimage_0.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_0.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[0].urlToImage)));
                }
            }
            tb_name_0.Text = outObject.articles[0].source.name;
            tb_title_0.Text = outObject.articles[0].title;
            tb_description_0.Text = outObject.articles[0].description;
            tb_url_0.Text = outObject.articles[0].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_1.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[1].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[1].urlToImage == null)
                {
                    tb_urltoimage_1.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_1.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[1].urlToImage)));
                }
            }
            tb_name_1.Text = outObject.articles[1].source.name;
            tb_title_1.Text = outObject.articles[1].title;
            tb_description_1.Text = outObject.articles[1].description;
            tb_url_1.Text = outObject.articles[1].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_2.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[2].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[2].urlToImage == null)
                {
                    tb_urltoimage_2.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_2.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[2].urlToImage)));
                }
            }
            tb_name_2.Text = outObject.articles[2].source.name;
            tb_title_2.Text = outObject.articles[2].title;
            tb_description_2.Text = outObject.articles[2].description;
            tb_url_2.Text = outObject.articles[2].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_3.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[3].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[3].urlToImage == null)
                {
                    tb_urltoimage_3.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_3.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[3].urlToImage)));
                }
            }
            tb_name_3.Text = outObject.articles[3].source.name;
            tb_title_3.Text = outObject.articles[3].title;
            tb_description_3.Text = outObject.articles[3].description;
            tb_url_3.Text = outObject.articles[3].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_4.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[4].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[4].urlToImage == null)
                {
                    tb_urltoimage_4.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_4.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[4].urlToImage)));
                }
            }
            tb_name_4.Text = outObject.articles[4].source.name;
            tb_title_4.Text = outObject.articles[4].title;
            tb_description_4.Text = outObject.articles[4].description;
            tb_url_4.Text = outObject.articles[4].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_5.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[5].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[5].urlToImage == null)
                {
                    tb_urltoimage_5.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_5.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[5].urlToImage)));
                }
            }

            tb_name_5.Text = outObject.articles[5].source.name;
            tb_title_5.Text = outObject.articles[5].title;
            tb_description_5.Text = outObject.articles[5].description;
            tb_url_5.Text = outObject.articles[5].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_6.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[6].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[6].urlToImage == null)
                {
                    tb_urltoimage_6.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_6.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[6].urlToImage)));
                }
            }
            tb_name_6.Text = outObject.articles[6].source.name;
            tb_title_6.Text = outObject.articles[6].title;
            tb_description_6.Text = outObject.articles[6].description;
            tb_url_6.Text = outObject.articles[6].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_7.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[7].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[7].urlToImage == null)
                {
                    tb_urltoimage_7.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_7.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[7].urlToImage)));
                }
            }
            tb_name_7.Text = outObject.articles[7].source.name;
            tb_title_7.Text = outObject.articles[7].title;
            tb_description_7.Text = outObject.articles[7].description;
            tb_url_7.Text = outObject.articles[7].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_8.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[8].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[8].urlToImage == null)
                {
                    tb_urltoimage_8.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_8.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[8].urlToImage)));
                }
            }
            tb_name_8.Text = outObject.articles[8].source.name;
            tb_title_8.Text = outObject.articles[8].title;
            tb_description_8.Text = outObject.articles[8].description;
            tb_url_8.Text = outObject.articles[8].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_9.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[9].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[9].urlToImage == null)
                {
                    tb_urltoimage_9.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_9.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[9].urlToImage)));
                }
            }
            tb_name_9.Text = outObject.articles[9].source.name;
            tb_title_9.Text = outObject.articles[9].title;
            tb_description_9.Text = outObject.articles[9].description;
            tb_url_9.Text = outObject.articles[9].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_10.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[10].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[10].urlToImage == null)
                {
                    tb_urltoimage_10.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_10.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[10].urlToImage)));
                }
            }
            tb_name_10.Text = outObject.articles[10].source.name;
            tb_title_10.Text = outObject.articles[10].title;
            tb_description_10.Text = outObject.articles[10].description;
            tb_url_10.Text = outObject.articles[10].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_11.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[11].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[11].urlToImage == null)
                {
                    tb_urltoimage_11.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_11.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[11].urlToImage)));
                }
            }
            tb_name_11.Text = outObject.articles[11].source.name;
            tb_title_11.Text = outObject.articles[11].title;
            tb_description_11.Text = outObject.articles[11].description;
            tb_url_11.Text = outObject.articles[11].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_12.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[12].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[12].urlToImage == null)
                {
                    tb_urltoimage_12.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_12.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[12].urlToImage)));
                }
            }
            tb_name_12.Text = outObject.articles[12].source.name;
            tb_title_12.Text = outObject.articles[12].title;
            tb_description_12.Text = outObject.articles[12].description;
            tb_url_12.Text = outObject.articles[12].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_13.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[13].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[13].urlToImage == null)
                {
                    tb_urltoimage_13.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_13.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[13].urlToImage)));
                }
            }
            tb_name_13.Text = outObject.articles[13].source.name;
            tb_title_13.Text = outObject.articles[13].title;
            tb_description_13.Text = outObject.articles[13].description;
            tb_url_13.Text = outObject.articles[13].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_14.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[14].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[14].urlToImage == null)
                {
                    tb_urltoimage_14.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_14.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[14].urlToImage)));
                }
            }
            tb_name_14.Text = outObject.articles[14].source.name;
            tb_title_14.Text = outObject.articles[14].title;
            tb_description_14.Text = outObject.articles[14].description;
            tb_url_14.Text = outObject.articles[14].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_15.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[15].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[15].urlToImage == null)
                {
                    tb_urltoimage_15.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_15.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[15].urlToImage)));
                }
            }
            tb_name_15.Text = outObject.articles[15].source.name;
            tb_title_15.Text = outObject.articles[15].title;
            tb_description_15.Text = outObject.articles[15].description;
            tb_url_15.Text = outObject.articles[15].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_16.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[16].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[16].urlToImage == null)
                {
                    tb_urltoimage_16.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_16.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[16].urlToImage)));
                }
            }
            tb_name_16.Text = outObject.articles[16].source.name;
            tb_title_16.Text = outObject.articles[16].title;
            tb_description_16.Text = outObject.articles[16].description;
            tb_url_16.Text = outObject.articles[16].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_17.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[17].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[17].urlToImage == null)
                {
                    tb_urltoimage_17.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_17.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[17].urlToImage)));
                }
            }
            tb_name_17.Text = outObject.articles[17].source.name;
            tb_title_17.Text = outObject.articles[17].title;
            tb_description_17.Text = outObject.articles[17].description;
            tb_url_17.Text = outObject.articles[17].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_18.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[18].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[18].urlToImage == null)
                {
                    tb_urltoimage_18.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_18.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[18].urlToImage)));
                }
            }
            tb_name_18.Text = outObject.articles[18].source.name;
            tb_title_18.Text = outObject.articles[18].title;
            tb_description_18.Text = outObject.articles[18].description;
            tb_url_18.Text = outObject.articles[18].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_19.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[19].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[19].urlToImage == null)
                {
                    tb_urltoimage_19.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_19.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[19].urlToImage)));
                }
            }
            tb_name_19.Text = outObject.articles[19].source.name;
            tb_title_19.Text = outObject.articles[19].title;
            tb_description_19.Text = outObject.articles[19].description;
            tb_url_19.Text = outObject.articles[19].url;
        }

        private void DE_Click(object sender, RoutedEventArgs e)
        {
            lb_main.Visibility = Visibility.Visible;
            lb_main.BorderBrush = new SolidColorBrush(Colors.DarkGoldenrod);
            lb_main.BorderThickness = new Thickness(5);
            Date.Content = DateTime.Now.ToString(@"dd\.MM\.20yy");
            country = "DE";
            Uri uri = new Uri("https://newsapi.org/v2/top-headlines?country=" + country + "&apiKey=" + apiKey);
            WebRequest request = WebRequest.Create(uri);
            try
            {
                request.GetResponse();
            }
            catch
            {
                lb_main.Visibility = Visibility.Hidden;
                MessageBox.Show("Internet connection problem!");
                return;
            }
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string responseData = reader.ReadToEnd();
            var outObject = JsonConvert.DeserializeObject<NewsData.RootObject>(responseData);

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_0.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[0].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[0].urlToImage == null)
                {
                    tb_urltoimage_0.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_0.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[0].urlToImage)));
                }
            }
            tb_name_0.Text = outObject.articles[0].source.name;
            tb_title_0.Text = outObject.articles[0].title;
            tb_description_0.Text = outObject.articles[0].description;
            tb_url_0.Text = outObject.articles[0].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_1.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[1].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[1].urlToImage == null)
                {
                    tb_urltoimage_1.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_1.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[1].urlToImage)));
                }
            }
            tb_name_1.Text = outObject.articles[1].source.name;
            tb_title_1.Text = outObject.articles[1].title;
            tb_description_1.Text = outObject.articles[1].description;
            tb_url_1.Text = outObject.articles[1].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_2.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[2].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[2].urlToImage == null)
                {
                    tb_urltoimage_2.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_2.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[2].urlToImage)));
                }
            }
            tb_name_2.Text = outObject.articles[2].source.name;
            tb_title_2.Text = outObject.articles[2].title;
            tb_description_2.Text = outObject.articles[2].description;
            tb_url_2.Text = outObject.articles[2].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_3.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[3].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[3].urlToImage == null)
                {
                    tb_urltoimage_3.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_3.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[3].urlToImage)));
                }
            }
            tb_name_3.Text = outObject.articles[3].source.name;
            tb_title_3.Text = outObject.articles[3].title;
            tb_description_3.Text = outObject.articles[3].description;
            tb_url_3.Text = outObject.articles[3].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_4.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[4].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[4].urlToImage == null)
                {
                    tb_urltoimage_4.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_4.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[4].urlToImage)));
                }
            }
            tb_name_4.Text = outObject.articles[4].source.name;
            tb_title_4.Text = outObject.articles[4].title;
            tb_description_4.Text = outObject.articles[4].description;
            tb_url_4.Text = outObject.articles[4].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_5.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[5].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[5].urlToImage == null)
                {
                    tb_urltoimage_5.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_5.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[5].urlToImage)));
                }
            }

            tb_name_5.Text = outObject.articles[5].source.name;
            tb_title_5.Text = outObject.articles[5].title;
            tb_description_5.Text = outObject.articles[5].description;
            tb_url_5.Text = outObject.articles[5].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_6.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[6].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[6].urlToImage == null)
                {
                    tb_urltoimage_6.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_6.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[6].urlToImage)));
                }
            }
            tb_name_6.Text = outObject.articles[6].source.name;
            tb_title_6.Text = outObject.articles[6].title;
            tb_description_6.Text = outObject.articles[6].description;
            tb_url_6.Text = outObject.articles[6].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_7.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[7].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[7].urlToImage == null)
                {
                    tb_urltoimage_7.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_7.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[7].urlToImage)));
                }
            }
            tb_name_7.Text = outObject.articles[7].source.name;
            tb_title_7.Text = outObject.articles[7].title;
            tb_description_7.Text = outObject.articles[7].description;
            tb_url_7.Text = outObject.articles[7].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_8.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[8].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[8].urlToImage == null)
                {
                    tb_urltoimage_8.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_8.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[8].urlToImage)));
                }
            }
            tb_name_8.Text = outObject.articles[8].source.name;
            tb_title_8.Text = outObject.articles[8].title;
            tb_description_8.Text = outObject.articles[8].description;
            tb_url_8.Text = outObject.articles[8].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_9.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[9].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[9].urlToImage == null)
                {
                    tb_urltoimage_9.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_9.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[9].urlToImage)));
                }
            }
            tb_name_9.Text = outObject.articles[9].source.name;
            tb_title_9.Text = outObject.articles[9].title;
            tb_description_9.Text = outObject.articles[9].description;
            tb_url_9.Text = outObject.articles[9].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_10.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[10].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[10].urlToImage == null)
                {
                    tb_urltoimage_10.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_10.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[10].urlToImage)));
                }
            }
            tb_name_10.Text = outObject.articles[10].source.name;
            tb_title_10.Text = outObject.articles[10].title;
            tb_description_10.Text = outObject.articles[10].description;
            tb_url_10.Text = outObject.articles[10].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_11.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[11].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[11].urlToImage == null)
                {
                    tb_urltoimage_11.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_11.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[11].urlToImage)));
                }
            }
            tb_name_11.Text = outObject.articles[11].source.name;
            tb_title_11.Text = outObject.articles[11].title;
            tb_description_11.Text = outObject.articles[11].description;
            tb_url_11.Text = outObject.articles[11].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_12.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[12].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[12].urlToImage == null)
                {
                    tb_urltoimage_12.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_12.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[12].urlToImage)));
                }
            }
            tb_name_12.Text = outObject.articles[12].source.name;
            tb_title_12.Text = outObject.articles[12].title;
            tb_description_12.Text = outObject.articles[12].description;
            tb_url_12.Text = outObject.articles[12].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_13.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[13].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[13].urlToImage == null)
                {
                    tb_urltoimage_13.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_13.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[13].urlToImage)));
                }
            }
            tb_name_13.Text = outObject.articles[13].source.name;
            tb_title_13.Text = outObject.articles[13].title;
            tb_description_13.Text = outObject.articles[13].description;
            tb_url_13.Text = outObject.articles[13].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_14.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[14].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[14].urlToImage == null)
                {
                    tb_urltoimage_14.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_14.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[14].urlToImage)));
                }
            }
            tb_name_14.Text = outObject.articles[14].source.name;
            tb_title_14.Text = outObject.articles[14].title;
            tb_description_14.Text = outObject.articles[14].description;
            tb_url_14.Text = outObject.articles[14].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_15.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[15].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[15].urlToImage == null)
                {
                    tb_urltoimage_15.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_15.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[15].urlToImage)));
                }
            }
            tb_name_15.Text = outObject.articles[15].source.name;
            tb_title_15.Text = outObject.articles[15].title;
            tb_description_15.Text = outObject.articles[15].description;
            tb_url_15.Text = outObject.articles[15].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_16.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[16].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[16].urlToImage == null)
                {
                    tb_urltoimage_16.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_16.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[16].urlToImage)));
                }
            }
            tb_name_16.Text = outObject.articles[16].source.name;
            tb_title_16.Text = outObject.articles[16].title;
            tb_description_16.Text = outObject.articles[16].description;
            tb_url_16.Text = outObject.articles[16].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_17.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[17].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[17].urlToImage == null)
                {
                    tb_urltoimage_17.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_17.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[17].urlToImage)));
                }
            }
            tb_name_17.Text = outObject.articles[17].source.name;
            tb_title_17.Text = outObject.articles[17].title;
            tb_description_17.Text = outObject.articles[17].description;
            tb_url_17.Text = outObject.articles[17].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_18.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[18].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[18].urlToImage == null)
                {
                    tb_urltoimage_18.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_18.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[18].urlToImage)));
                }
            }
            tb_name_18.Text = outObject.articles[18].source.name;
            tb_title_18.Text = outObject.articles[18].title;
            tb_description_18.Text = outObject.articles[18].description;
            tb_url_18.Text = outObject.articles[18].url;

            try//if (outObject.articles[3].urlToImage != null)
            {
                tb_urltoimage_19.Background = new ImageBrush(new BitmapImage(new Uri(outObject.articles[19].urlToImage)));
            }
            catch//else
            {
                if (outObject.articles[19].urlToImage == null)
                {
                    tb_urltoimage_19.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    tb_urltoimage_19.Background = new ImageBrush(new BitmapImage(new Uri(@"https:" + outObject.articles[19].urlToImage)));
                }
            }
            tb_name_19.Text = outObject.articles[19].source.name;
            tb_title_19.Text = outObject.articles[19].title;
            tb_description_19.Text = outObject.articles[19].description;
            tb_url_19.Text = outObject.articles[19].url;
        }

        private void DClick_lbi_0(object sender, MouseButtonEventArgs e)
        {
            string site = tb_url_0.Text;
            System.Diagnostics.Process.Start(site);
            
        }

        private void DClick_lbi_1(object sender, MouseButtonEventArgs e)
        {
            string site = tb_url_1.Text;
            System.Diagnostics.Process.Start(site);
        }

        private void DClick_lbi_2(object sender, MouseButtonEventArgs e)
        {
            string site = tb_url_2.Text;
            System.Diagnostics.Process.Start(site);
        }

        private void DClick_lbi_3(object sender, MouseButtonEventArgs e)
        {
            string site = tb_url_3.Text;
            System.Diagnostics.Process.Start(site);
        }

        private void DClick_lbi_4(object sender, MouseButtonEventArgs e)
        {
            string site = tb_url_4.Text;
            System.Diagnostics.Process.Start(site);
        }

        private void DClick_lbi_5(object sender, MouseButtonEventArgs e)
        {
            string site = tb_url_5.Text;
            System.Diagnostics.Process.Start(site);
        }

        private void DClick_lbi_6(object sender, MouseButtonEventArgs e)
        {
            string site = tb_url_6.Text;
            System.Diagnostics.Process.Start(site);
        }

        private void DClick_lbi_7(object sender, MouseButtonEventArgs e)
        {
            string site = tb_url_7.Text;
            System.Diagnostics.Process.Start(site);
        }

        private void DClick_lbi_8(object sender, MouseButtonEventArgs e)
        {
            string site = tb_url_8.Text;
            System.Diagnostics.Process.Start(site);
        }

        private void DClick_lbi_9(object sender, MouseButtonEventArgs e)
        {
            string site = tb_url_9.Text;
            System.Diagnostics.Process.Start(site);
        }

        private void DClick_lbi_10(object sender, MouseButtonEventArgs e)
        {
            string site = tb_url_10.Text;
            System.Diagnostics.Process.Start(site);
        }

        private void DClick_lbi_11(object sender, MouseButtonEventArgs e)
        {
            string site = tb_url_11.Text;
            System.Diagnostics.Process.Start(site);
        }

        private void DClick_lbi_12(object sender, MouseButtonEventArgs e)
        {
            string site = tb_url_12.Text;
            System.Diagnostics.Process.Start(site);
        }

        private void DClick_lbi_13(object sender, MouseButtonEventArgs e)
        {
            string site = tb_url_13.Text;
            System.Diagnostics.Process.Start(site);
        }

        private void DClick_lbi_14(object sender, MouseButtonEventArgs e)
        {
            string site = tb_url_14.Text;
            System.Diagnostics.Process.Start(site);
        }

        private void DClick_lbi_15(object sender, MouseButtonEventArgs e)
        {
            string site = tb_url_15.Text;
            System.Diagnostics.Process.Start(site);
        }

        private void DClick_lbi_16(object sender, MouseButtonEventArgs e)
        {
            string site = tb_url_16.Text;
            System.Diagnostics.Process.Start(site);
        }

        private void DClick_lbi_17(object sender, MouseButtonEventArgs e)
        {
            string site = tb_url_17.Text;
            System.Diagnostics.Process.Start(site);
        }

        private void DClick_lbi_18(object sender, MouseButtonEventArgs e)
        {
            string site = tb_url_18.Text;
            System.Diagnostics.Process.Start(site);
        }

        private void DClick_lbi_19(object sender, MouseButtonEventArgs e)
        {
            string site = tb_url_19.Text;
            System.Diagnostics.Process.Start(site);
        }

       
        
      
















        

       

       

       

        
       

        
        
       
        
            
        
        
    }
}
