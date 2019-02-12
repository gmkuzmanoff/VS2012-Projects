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
using System.Globalization;


namespace WpfJson
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        string city_name;
        string apiKey = "6cb23c001b737b040bca0e8f736f5548";
       

        

        private void Key_down_Click(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                city_name = Convert.ToString(tbox_name.Text);
                if (tbox_name.Text.Length == 0)
                {
                    return;
                }

                Uri uri = new Uri("http://api.openweathermap.org/data/2.5/weather?q=" + city_name + "&appid=" + apiKey);
                WebRequest webRequest = WebRequest.Create(uri);
                try
                {
                    webRequest.GetResponse();
                }
                catch //If exception thrown then couldn't get response from address
                {
                    /// The URL is incorrect
                    MessageBox.Show("Ooops...!\n\n1.Incorrect city name\n2.Check your internet connection");
                    return;
                }
                WebResponse response = webRequest.GetResponse();
                StreamReader streamReader = new StreamReader(response.GetResponseStream());
                String responseData = streamReader.ReadToEnd();
                try
                {
                    JsonConvert.DeserializeObject<WeatherData.RootObject>(responseData);
                }
                catch
                {
                    MessageBox.Show("Response data error!");
                    return;
                }
                var outObject = JsonConvert.DeserializeObject<WeatherData.RootObject>(responseData);

                tb_name.Text = outObject.name + " , " + outObject.sys.country;
                tb_temp.Text = Convert.ToInt32(outObject.main.temp - 273.15) + "°C";
                tb_coord.Text = "Lat: " + outObject.coord.lat + " , " + "Lon: " + outObject.coord.lon;
                tb_wind.Text = "Wind speed: " + Convert.ToInt16(outObject.wind.speed) + " m/s";
                tb_pressure.Text = "Pressure: " + outObject.main.pressure + " hpa";
                tb_humidity.Text = "Humidity: " + outObject.main.humidity + " %";
                tb_clouds.Text = "Cloudiness: " + outObject.weather[0].description;
                tb_temp_minmax.Text = "Max/Min: " + Convert.ToInt16(outObject.main.temp_max - 273.15) + "°C" + " / " + Convert.ToInt16(outObject.main.temp_min - 281.15) + "°C";
                //Setup weather icons and some backgrounds
                if (outObject.weather[0].id >= 200 && outObject.weather[0].id < 232 && outObject.weather[0].description == "thunderstorm with light rain" || outObject.weather[0].description == "thunderstorm with rain" || outObject.weather[0].description == "thunderstorm with heavy rain" || outObject.weather[0].description == "light thunderstorm" || outObject.weather[0].description == "thunderstorm" || outObject.weather[0].description == "heavy thunderstorm" || outObject.weather[0].description == "ragged thunderstorm" || outObject.weather[0].description == "thunderstorm with light drizzle" || outObject.weather[0].description == "thunderstorm with drizzle" || outObject.weather[0].description == "thunderstorm with heavy drizzle")
                {
                    tb_icon.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\User\Documents\Visual Studio 2012\Projects\WpfJson\WpfJson\Assets\icons\11d.png")));
                    Main_grid.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\User\Documents\Visual Studio 2012\Projects\WpfJson\WpfJson\Assets\thunderstorm.jpg")));
                }
                else if (outObject.weather[0].id >= 300 && outObject.weather[0].id < 321 && outObject.weather[0].description == "light intensity drizzle" || outObject.weather[0].description == "drizzle" || outObject.weather[0].description == "heavy intensity drizzle" || outObject.weather[0].description == "light intensity drizzle rain" || outObject.weather[0].description == "drizzle rain" || outObject.weather[0].description == "heavy intensity drizzle rain" || outObject.weather[0].description == "shower rain and drizzle" || outObject.weather[0].description == "shower drizzle")
                {
                    tb_icon.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\User\Documents\Visual Studio 2012\Projects\WpfJson\WpfJson\Assets\icons\09d.png")));
                    Main_grid.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\User\Documents\Visual Studio 2012\Projects\WpfJson\WpfJson\Assets\shower rain.jpg")));
                }
                else if (outObject.weather[0].id >= 500 && outObject.weather[0].id < 504 && outObject.weather[0].description == "light rain" || outObject.weather[0].description == "moderate rain" || outObject.weather[0].description == "heavy intensity rain" || outObject.weather[0].description == "very heavy rain" || outObject.weather[0].description == "extreme rain")
                {
                    tb_icon.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\User\Documents\Visual Studio 2012\Projects\WpfJson\WpfJson\Assets\icons\10d.png")));
                    Main_grid.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\User\Documents\Visual Studio 2012\Projects\WpfJson\WpfJson\Assets\shower rain.jpg")));
                }
                else if (outObject.weather[0].id >= 520 && outObject.weather[0].id < 531 && outObject.weather[0].description == "light intensity shower rain" || outObject.weather[0].description == "shower rain" || outObject.weather[0].description == "heavy intensity shower rain" || outObject.weather[0].description == "ragged shower rain")
                {
                    tb_icon.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\User\Documents\Visual Studio 2012\Projects\WpfJson\WpfJson\Assets\icons\09d.png")));
                    Main_grid.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\User\Documents\Visual Studio 2012\Projects\WpfJson\WpfJson\Assets\shower rain.jpg")));
                }
                else if (outObject.weather[0].id >= 600 && outObject.weather[0].id < 622 && outObject.weather[0].description == "light snow" || outObject.weather[0].description == "snow" || outObject.weather[0].description == "heavy snow" || outObject.weather[0].description == "sleet" || outObject.weather[0].description == "shower sleet" || outObject.weather[0].description == "light rain and snow" || outObject.weather[0].description == "rain and snow" || outObject.weather[0].description == "light shower snow" || outObject.weather[0].description == "shower snow" || outObject.weather[0].description == "heavy shower snow")
                {
                    tb_icon.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\User\Documents\Visual Studio 2012\Projects\WpfJson\WpfJson\Assets\icons\13d.png")));
                    Main_grid.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\User\Documents\Visual Studio 2012\Projects\WpfJson\WpfJson\Assets\snow.jpg")));
                }
                else if (outObject.weather[0].id >= 701 && outObject.weather[0].id < 781 && outObject.weather[0].description == "mist" || outObject.weather[0].description == "smoke" || outObject.weather[0].description == "haze" || outObject.weather[0].description == "sand, dust whirls" || outObject.weather[0].description == "fog" || outObject.weather[0].description == "sand" || outObject.weather[0].description == "dust" || outObject.weather[0].description == "volcanic ash" || outObject.weather[0].description == "squalls" || outObject.weather[0].description == "tornado")
                {
                    tb_icon.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\User\Documents\Visual Studio 2012\Projects\WpfJson\WpfJson\Assets\icons\50d.png")));
                    Main_grid.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\User\Documents\Visual Studio 2012\Projects\WpfJson\WpfJson\Assets\fog.jpg")));
                }
                else if (outObject.weather[0].id == 511 && outObject.weather[0].description == "freezing rain")
                {
                    tb_icon.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\User\Documents\Visual Studio 2012\Projects\WpfJson\WpfJson\Assets\icons\13d.png")));
                    Main_grid.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\User\Documents\Visual Studio 2012\Projects\WpfJson\WpfJson\Assets\freezing rain.jpg")));
                }
                else if (outObject.weather[0].id == 800 && outObject.weather[0].description == "clear sky")
                {
                    tb_icon.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\User\Documents\Visual Studio 2012\Projects\WpfJson\WpfJson\Assets\icons\01d.png")));
                    Main_grid.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\User\Documents\Visual Studio 2012\Projects\WpfJson\WpfJson\Assets\clear sky.jpg")));
                }
                else if (outObject.weather[0].id == 801 && outObject.weather[0].description == "few clouds")
                {
                    tb_icon.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\User\Documents\Visual Studio 2012\Projects\WpfJson\WpfJson\Assets\icons\02d.png")));
                    Main_grid.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\User\Documents\Visual Studio 2012\Projects\WpfJson\WpfJson\Assets\few clouds.jpg")));
                }
                else if (outObject.weather[0].id == 802 && outObject.weather[0].description == "scattered clouds")
                {
                    tb_icon.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\User\Documents\Visual Studio 2012\Projects\WpfJson\WpfJson\Assets\icons\03d.png")));
                    Main_grid.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\User\Documents\Visual Studio 2012\Projects\WpfJson\WpfJson\Assets\scattered clouds.jpg")));
                }
                else if (outObject.weather[0].id == 803 && outObject.weather[0].description == "broken clouds")
                {
                    tb_icon.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\User\Documents\Visual Studio 2012\Projects\WpfJson\WpfJson\Assets\icons\04d.png")));
                    Main_grid.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\User\Documents\Visual Studio 2012\Projects\WpfJson\WpfJson\Assets\broken clouds.jpg")));
                }

                else if (outObject.weather[0].id == 804 && outObject.weather[0].description == "overcast clouds")
                {
                    tb_icon.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\User\Documents\Visual Studio 2012\Projects\WpfJson\WpfJson\Assets\icons\04d.png")));
                    Main_grid.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\User\Documents\Visual Studio 2012\Projects\WpfJson\WpfJson\Assets\overcast clouds.jpg")));
                }
            }
        }

        
        
            
           
}
        

        
    
}
