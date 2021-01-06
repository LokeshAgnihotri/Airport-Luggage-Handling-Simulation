using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace CartsAnimation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer main_timer;
        DispatcherTimer sec_timer;
        List<Image> carts = new List<Image>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void createCarts(int num)
        {
            for(int i=1;i<=num;i++)
            {
                Image finalImage = new Image();
                finalImage.Width = 40;
                   // var uriSource = new Uri($@"/CartsAnimation;component/images/cart{i}.png", UriKind.Relative);
                var uriSource = new Uri($@"/CartsAnimation;component/images/cart2.png", UriKind.Relative);
                finalImage.Source = new BitmapImage(uriSource);
                Panel.Children.Add(finalImage);

                Grid.SetColumn(finalImage,i);
                Grid.SetRow(finalImage, 0);
                carts.Add(finalImage);
            }

            Image anotherImage = new Image();
            anotherImage.Width = 40;
            var anotherUriSource = new Uri(@"/CartsAnimation;component/images/cart1.png", UriKind.Relative);
            anotherImage.Source = new BitmapImage(anotherUriSource);
            Panel.Children.Add(anotherImage);
            Grid.SetColumn(anotherImage, 0);
            Grid.SetRow(anotherImage, 1);
            carts.Add(anotherImage);

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            createCarts(cmb.SelectedIndex+1);
            main_timer = new DispatcherTimer();
            sec_timer = new DispatcherTimer();
            sec_timer.Interval = TimeSpan.FromSeconds(1);
            sec_timer.Tick += new System.EventHandler(OnTimerEvent2);

            main_timer.Interval = TimeSpan.FromSeconds(1);
            main_timer.Tick += new System.EventHandler(OnTimerEvent);
            main_timer.Start();
        }


        private void OnTimerEvent(object sender, EventArgs e)
        {
            int max_position = carts.Count;
            foreach (Image p in carts)
            {
                if(Grid.GetColumn(p)>7)
                {
                    Dispatcher.BeginInvoke((Action)(() => Grid.SetRow(p, 0)));
                    Dispatcher.BeginInvoke((Action)(() => Grid.SetColumn(p, max_position)));
                }
                if (Grid.GetRow(p) == 1)
                {
                    int new_position = Grid.GetColumn(p) + 1;
                    Dispatcher.BeginInvoke((Action)(() => Grid.SetColumn(p, new_position)));                   
                }
                if (Grid.GetColumn(p) > 2 && Grid.GetColumn(p)<5)
                {
                    foreach (Image f in carts)
                    {
                        if (Grid.GetRow(f) == 0)
                        {
                            Grid.SetColumn(f, Grid.GetColumn(f) - 1);
                            if (Grid.GetColumn(f) == 0)
                            {
                                Grid.SetRow(f, 1);
                                Grid.SetColumn(f, 0);

                                sec_timer.Stop();
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void OnTimerEvent2(object sender, EventArgs e)
        {
           
        //    sec_timer.Stop();
           // main_timer.Start();
        }
    }
}