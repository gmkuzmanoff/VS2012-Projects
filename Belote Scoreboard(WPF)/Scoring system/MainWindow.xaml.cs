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
        int result1=0;
        int result2 = 0;
        int game_result1;
        int game_result2;
       
        public MainWindow()
        {
            InitializeComponent();
            DoubleAnimation animation = new DoubleAnimation(1, TimeSpan.FromSeconds(2));
            mainGrid.BeginAnimation(Grid.OpacityProperty, animation);
            lb_team1.Items.Add(new TextBlock()
                {
                    Text = result1 + " - ",
                    FontSize = 22,
                    Foreground=Brushes.Red,
                    FontFamily=new FontFamily("Segoe Print")
                });
            lb_team2.Items.Add(new TextBlock()
            {
                Text = result1 + " - ",
                FontSize = 22,
                Foreground = Brushes.Blue,
                FontFamily = new FontFamily("Segoe Print")
            });
        }

        private void tbox_team1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Enter)
            {
                try
                {
                    game_result1 = Convert.ToInt16(tbox_team1.Text);
                }
                catch
                {
                    MessageBox.Show("Въведете цифра!","Внимание",MessageBoxButton.OK,MessageBoxImage.Warning);
                    tbox_team1.Text = null;
                    return;
                }
                TextBlock res = new TextBlock();
                res.Text = result1 + " + " + tbox_team1.Text;
                res.FontSize = 15;
                lb_team1.Items.Add(res);
                result1 = result1 + game_result1;
                lb_team1.Items.Add(new TextBlock()
                {
                    Text = result1 + " - ",
                    FontSize = 22,
                    Foreground=Brushes.Red,
                    FontFamily = new FontFamily("Segoe Print")
                });
                tbox_team1.Text = null;
                if (result1 >= 151)
                {
                    if (MessageBox.Show("Играта приключи ли?", "Потвърждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        lb_team1.Items.Clear();
                        lb_team2.Items.Clear();
                        result1 = 0;
                        result2 = 0;
                        int mainscore1 = Convert.ToInt16(tb_mainscore1.Text);
                        DoubleAnimation animation = new DoubleAnimation(0,1, TimeSpan.FromSeconds(1));
                        tb_mainscore1.BeginAnimation(TextBlock.OpacityProperty, animation);
                        mainscore1++;
                        tb_mainscore1.Text = mainscore1.ToString();
                        lb_team1.Items.Add(new TextBlock()
                        {
                            Text = result1 + " - ",
                            FontSize = 22,
                            Foreground = Brushes.Red,
                            FontFamily = new FontFamily("Segoe Print")
                        });
                        lb_team2.Items.Add(new TextBlock()
                        {
                            Text = result2 + " - ",
                            FontSize = 22,
                            Foreground = Brushes.Blue,
                            FontFamily = new FontFamily("Segoe Print")
                        });
                        tbox_team1.Text = null;

                    }
                } 
            }
        }

        private void tbox_team2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                try
                {
                    game_result2 = Convert.ToInt16(tbox_team2.Text);
                }
                catch
                {
                    MessageBox.Show("Въведете цифра!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                    tbox_team2.Text = null;
                    return;
                }
                TextBlock res = new TextBlock();
                res.Text = result2 + " + " + tbox_team2.Text;
                res.FontSize = 15;
                lb_team2.Items.Add(res);
                result2 = result2 + game_result2;
                lb_team2.Items.Add(new TextBlock()
                {
                    Text = result2 + " - ",
                    FontSize = 22,
                    Foreground = Brushes.Blue,
                    FontFamily = new FontFamily("Segoe Print")
                });
                tbox_team2.Text = null;
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
                        lb_team1.Items.Add(new TextBlock()
                        {
                            Text = result1 + " - ",
                            FontSize = 22,
                            Foreground = Brushes.Red,
                            FontFamily = new FontFamily("Segoe Print")
                        });
                        lb_team2.Items.Add(new TextBlock()
                        {
                            Text = result2 + " - ",
                            FontSize = 22,
                            Foreground = Brushes.Blue,
                            FontFamily = new FontFamily("Segoe Print")
                        });
                        tbox_team1.Text = null;

                    }
                }
            }
        }
    }
}
