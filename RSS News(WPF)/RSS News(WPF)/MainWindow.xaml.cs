using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Threading;
using System.Windows.Media.Animation;

namespace RSS_News_WPF_
{
    
    public partial class MainWindow : Window
    {

        DoubleAnimation anim = new DoubleAnimation(0, 1, TimeSpan.FromSeconds(1.5));
    
        public MainWindow()
        {
            InitializeComponent();
            lb_main.BeginAnimation(OpacityProperty, anim);
            clockstart();
        }


        private void clockstart()
        {
            DispatcherTimer clock = new DispatcherTimer();
            clock.Interval = TimeSpan.FromSeconds(1);
            clock.Tick+=clock_Tick;
            clock.Start();
        }

        private void clock_Tick(object sender, EventArgs e)
        {
            //tb_clock.Text = DateTime.Now.ToString(@"HH\:mm");
            tb_date.Text = DateTime.Now.ToString(@"dd\.MM\.yyyy г.");
          
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(e.Uri.AbsoluteUri);
        }
      
    }
}
