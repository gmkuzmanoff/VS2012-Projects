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
using System.Windows.Media.Animation;

namespace Scoring_system
{
    
    public partial class MainWindow : Window
    {
        int result1 = 0;
        int result2 = 0;
        
        int game_result1;
        int game_result2;
        TextBox tbox1 = new TextBox()
             {
                 BorderBrush = null,
                 BorderThickness = new Thickness(0),
                 TextAlignment = TextAlignment.Center,
                 Background = null,
                 Width = 45,
                 Height = 30,
                 MaxLength = 3,
                 FontSize = 20,
                 Foreground = Brushes.Red,
                 FontFamily = new FontFamily("Segoe Print")
             };
        TextBox tbox2 = new TextBox()
        {
            BorderBrush = null,
            BorderThickness = new Thickness(0),
            TextAlignment = TextAlignment.Center,
            Background = null,
            Width = 45,
            Height = 30,
            MaxLength = 3,
            FontSize = 20,
            Foreground = Brushes.Blue,
            FontFamily = new FontFamily("Segoe Print")
        };
        StackPanel SP1 = new StackPanel()
            {
                Orientation = Orientation.Horizontal
            };
        StackPanel SP2 = new StackPanel()
            {
                Orientation = Orientation.Horizontal
            };
        TextBlock tblock1 = new TextBlock();
        TextBlock tblock2 = new TextBlock();   
            
            
        public MainWindow()
        {
            InitializeComponent();
            
            DoubleAnimation animation = new DoubleAnimation(0,1, TimeSpan.FromSeconds(2));
            mainGrid.BeginAnimation(Grid.OpacityProperty, animation);
            
                
                   tblock1. Text = result1 + " - ";
                   tblock1. FontSize = 20;
                   tblock1. Foreground = Brushes.Red;
                   tblock1. FontFamily = new FontFamily("Segoe Print");
                
            
            
               tblock2. Text = result1 + " - ";
               tblock2. FontSize = 20;
               tblock2. Foreground = Brushes.Blue;
               tblock2.FontFamily = new FontFamily("Segoe Print");
            

            SP1.Children.Insert(0,tblock1 );
            SP1.Children.Insert(1, tbox1);
            SP2.Children.Insert(0,tblock2 );
            SP2.Children.Insert(1, tbox2);
            
            lb_team1.Items.Add(SP1);
            lb_team2.Items.Add(SP2);
            tbox1.KeyDown+=tbox1_KeyDown;
            tbox2.KeyDown+=tbox2_KeyDown;
        }

        private void tbox2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Enter)
            {
                try
                {
                    game_result2 = Convert.ToInt16(tbox2.Text);
                }
                catch
                {
                    MessageBox.Show("Въведете цифра!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                    tbox2.Text = null;
                    return;
                }
                TextBlock res = new TextBlock();
                res.Foreground = Brushes.Blue;
                res.FontFamily = new FontFamily("Segoe Print");
                res.Text = result2 + " - " + tbox2.Text;
                res.FontSize = 20;
                lb_team2.Items.Insert(lb_team2.Items.Count - 1, res);
                result2 = result2 + game_result2;
                tblock2.Text = result2.ToString() + " - ";
                tbox2.Text = null;
                if (result2 >= 151)
                {
                    if (MessageBox.Show("Играта приключи ли?", "Потвърждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        lb_team1.Items.Clear();
                        lb_team2.Items.Clear();
                        result1 = 0;
                        result2 = 0;
                        int mainscore2 = Convert.ToInt16(tb_mainscore2.Text);
                        DoubleAnimation animation = new DoubleAnimation(0, 1, TimeSpan.FromSeconds(1));
                        tb_mainscore2.BeginAnimation(TextBlock.OpacityProperty, animation);
                        mainscore2++;
                        tb_mainscore2.Text = mainscore2.ToString();
                        lb_team1.Items.Add(SP1);
                        lb_team2.Items.Add(SP2);
                        tblock1.Text = result1.ToString() + " - ";
                        tblock2.Text = result1.ToString() + " - ";
                        tbox1.Text = null;
                        tbox2.Text = null;
                    }
                } 
            }
        }

        private void tbox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Enter)
            {
                try
                {
                    game_result1 = Convert.ToInt16(tbox1.Text);
                }
                catch
                {
                    MessageBox.Show("Въведете цифра!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                    tbox1.Text = null;
                    return;
                }
                TextBlock res = new TextBlock();
                res.Foreground = Brushes.Red;
                res.FontFamily = new FontFamily("Segoe Print");
                res.Text = result1 + " - " + tbox1.Text;
                res.FontSize = 20;
                lb_team1.Items.Insert(lb_team1.Items.Count - 1, res);
                result1 = result1 + game_result1;
                tblock1.Text = result1.ToString() + " - ";
                tbox1.Text = null;
                if (result1 >= 151)
                {
                    if (MessageBox.Show("Играта приключи ли?", "Потвърждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        lb_team1.Items.Clear();
                        lb_team2.Items.Clear();
                        result1 = 0;
                        result2 = 0;
                        int mainscore1 = Convert.ToInt16(tb_mainscore1.Text);
                        DoubleAnimation animation = new DoubleAnimation(0, 1, TimeSpan.FromSeconds(1));
                        tb_mainscore1.BeginAnimation(TextBlock.OpacityProperty, animation);
                        mainscore1++;
                        tb_mainscore1.Text = mainscore1.ToString();
                        lb_team1.Items.Add(SP1);
                        lb_team2.Items.Add(SP2);
                        tblock1.Text = result1.ToString() + " - ";
                        tblock2.Text = result1.ToString() + " - ";
                        tbox1.Text = null;
                        tbox2.Text = null;
                    }
                } 
                
            }
        }
    }
}
