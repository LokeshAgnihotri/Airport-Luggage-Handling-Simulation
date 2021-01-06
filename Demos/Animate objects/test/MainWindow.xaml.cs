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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Rect rectStraight;

        public MainWindow()
        {
            InitializeComponent();
            //this.rectStraight = new Rect();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //DoubleAnimation doubleAnimation = new DoubleAnimation(0,500, TimeSpan.FromSeconds(5));
            //doubleAnimation.EasingFunction = new QuadraticEase();
            //this.Rectangle1.BeginAnimation(WidthProperty, doubleAnimation);

            //StartAnimation
            //this.MoveLuggage();
            //Luggage
            //EllipseGeometry animatedEllipseGeometry = new EllipseGeometry(new Point(10, 100), 10, 10);
            //Path myPath1 = new Path();
            //myPath1.Data = animatedEllipseGeometry;
            //myPath1.Fill = Brushes.Blue;


            //// Create the rectangle.
            //// This RectangleGeometry specifies a rectangle that is 100 pixels high and
            //// 150 wide. The left side of the rectangle is 10 pixels from the left of the 
            //// Canvas and the top side of the rectangle is 100 pixels from the top of the Canvas.  
            //// Note: You could alternatively use the Rect Constructor to create this:
            //// Rect my Rect1 = new Rect(10,100,150,100");
            //Rect myRect1 = new Rect();
            //myRect1.Size = new Size(50, 200);
            //myRect1.Location = new Point(300, 100);
            //RectangleGeometry myRectangleGeometry1 = new RectangleGeometry();
            //myRectangleGeometry1.Rect = myRect1;

            //GeometryGroup myGeometryGroup1 = new GeometryGroup();
            //myGeometryGroup1.Children.Add(myRectangleGeometry1);

            //myPath1.Data = myGeometryGroup1;

            //Path myPath2 = new Path();
            //myPath2.Stroke = Brushes.Black;
            //myPath2.StrokeThickness = 1;
            //myPath2.Fill = mySolidColorBrush;

            //// Create the rectangle.
            //// This Rect uses the Size property to specify a height of 50 and width
            //// of 200. The Location property uses a Point value to determine the location of the
            //// top-left corner of the rectangle.
            //Rect myRect1 = new Rect();

            //RectangleGeometry myRectangleGeometry2 = new RectangleGeometry();
            //myRectangleGeometry2.Rect = myRect2;

            //GeometryGroup myGeometryGroup2 = new GeometryGroup();
            //myGeometryGroup2.Children.Add(myRectangleGeometry2);

            //myPath2.Data = myGeometryGroup2;

            //// Add path shape to the UI.
            //Canvas myCanvas = new Canvas();
            //myCanvas.Children.Add(myPath1);
            //myCanvas.Children.Add(myPath2);
            //this.Content = myCanvas;
        }



        private void MoveObjectStraight()
        {
            //double current = this.recStraight.X;
            //double destination = this.recStraight.X + 500;
            //TimeSpan duration = TimeSpan.FromSeconds(10);

            //DoubleAnimation doubleAnimation = new DoubleAnimation(this.recStraight.X, destination, duration);
            //doubleAnimation.EasingFunction = new QuadraticEase();

            //TranslateTransform translateTransform = new TranslateTransform();

            //for (int i = 0; i < duration.Seconds; i++)
            //{
            //    this.recStraight.X += 10;
            //    Thread.Sleep(1000);
            //}
        }

        private void MoveLuggage()
        {
            //Animate to move in a linear way
            //double t = Canvas.GetTop(this.ImageLuggage2);
            DoubleAnimation doubleAnimation = new DoubleAnimation(0, 500, TimeSpan.FromSeconds(10));
            //Make the animation more smooth
            doubleAnimation.EasingFunction = new QuadraticEase();


            //Move object using coordinates
            TranslateTransform translateTransform = new TranslateTransform();
            //Set translateTranform to object
            //this.ImageLuggage.RenderTransform = translateTransform;

            //Begin animation
            translateTransform.BeginAnimation(TranslateTransform.XProperty, doubleAnimation);


        }

        private void Button_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point screenPoint = new Point();
            if (sender is UIElement)
            {
                screenPoint = ElementPointToScreenPoint(sender as UIElement, new Point(0, 0));
                MessageBox.Show(screenPoint.X + " " + screenPoint.Y);
            }
            MessageBox.Show("test");
            Console.WriteLine(screenPoint.X + " " + screenPoint.Y);
        }

        public static Point ElementPointToScreenPoint(UIElement element, Point pointOnElement)
        {
            return element.PointToScreen(pointOnElement);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Button btn = (Button)sender;
            MouseEventArgs mBtn = (MouseEventArgs)e;
            MessageBox.Show(mBtn.GetPosition(btn).X + " " + mBtn.GetPosition(btn).Y);
            //    let rect = canvas.getBoundingClientRect();
            //    let x = mBtn.C - btn.left;
            //let y = event.clientY - rect.top;
            //console.log("Coordinate x: " + x,  
            //                "Coordinate y: " + y); 

        }

        private void Button_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            Point screenPoint = new Point();
            if (sender is UIElement)
            {
                screenPoint = ElementPointToScreenPoint(sender as UIElement, new Point(0, 0));
                MessageBox.Show(screenPoint.X + " " + screenPoint.Y);
            }
            MessageBox.Show("test");
            Console.WriteLine(screenPoint.X + " " + screenPoint.Y);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
            Point screenPoint = new Point();
            if (sender is UIElement)
            {
                screenPoint = ElementPointToScreenPoint(sender as UIElement, new Point(0, 0));
                MessageBox.Show(screenPoint.X + " " + screenPoint.Y);
            }
            MessageBox.Show("test");
            Console.WriteLine(screenPoint.X + " " + screenPoint.Y);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Point screenPoint = new Point();
            if (sender is UIElement)
            {
                screenPoint = ElementPointToScreenPoint(sender as UIElement, new Point(0, 0));
                MessageBox.Show(screenPoint.X + " " + screenPoint.Y);
            }
            MessageBox.Show("test");
            Console.WriteLine(screenPoint.X + " " + screenPoint.Y);
        }
    }
}
