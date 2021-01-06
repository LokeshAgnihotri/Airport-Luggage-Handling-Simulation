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

namespace FollowPath
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();




            // Create a NameScope for the page so that
            // we can use Storyboards.
            NameScope.SetNameScope(this, new NameScope());

            //// Create the EllipseGeometry to animate.
            EllipseGeometry animatedEllipseGeometry =
                new EllipseGeometry(new Point(10, 100), 10, 10);

            RectangleGeometry rectangleGeometry = new RectangleGeometry(new Rect(10, 100, 200, 20));
            RectangleGeometry rectangleGeometry2 = new RectangleGeometry(new Rect(rectangleGeometry.Rect.X + rectangleGeometry.Rect.Width, 100, 200, 20));
            RectangleGeometry rectangleGeometry3 = new RectangleGeometry(new Rect(rectangleGeometry2.Rect.X + rectangleGeometry2.Rect.Width, rectangleGeometry2.Rect.Y, 20, 200));

            //// Register the EllipseGeometry's name with
            //// the page so that it can be targeted by a
            //// storyboard.
            this.RegisterName("AnimatedEllipseGeometry", animatedEllipseGeometry);

            //// Create a Path element to display the geometry.
            Path ellipsePath = new Path();
            ellipsePath.Data = animatedEllipseGeometry;
            ellipsePath.Fill = Brushes.Blue;
            ellipsePath.Margin = new Thickness(15);

            Path ellipsePath2 = new Path();
            ellipsePath2.Data = rectangleGeometry;
            ellipsePath2.Fill = Brushes.Transparent;
            ellipsePath2.StrokeThickness = 2;
            ellipsePath2.Stroke = Brushes.Black;
            ellipsePath2.Margin = new Thickness(15);

            Path ellipsePath3 = new Path();
            ellipsePath3.Data = rectangleGeometry2;
            ellipsePath3.Fill = Brushes.Transparent;
            ellipsePath3.StrokeThickness = 2;
            ellipsePath3.Stroke = Brushes.Black;
            ellipsePath3.Margin = new Thickness(15);

            Path ellipsePath4 = new Path();
            ellipsePath4.Data = rectangleGeometry3;
            ellipsePath4.Fill = Brushes.Transparent;
            ellipsePath4.StrokeThickness = 2;
            ellipsePath4.Stroke = Brushes.Black;
            ellipsePath4.Margin = new Thickness(15);
            
            this.canvas1.Children.Add(ellipsePath);
            this.canvas1.Children.Add(ellipsePath2);
            this.canvas1.Children.Add(ellipsePath3);
            this.canvas1.Children.Add(ellipsePath4);

            var uriSource = new Uri(@"/FollowPath;component/img/item2.png", UriKind.Relative);
            BitmapImage imageSource = new BitmapImage(uriSource);
            Image image = new Image();
            image.Width = 100;
            image.Height = 100;
            image.Source = imageSource;
            //image.MouseLeftButtonDown += new MouseButtonEventHandler(Image_MouseLeftButtonDown);
            //image.RaiseEvent(e);

            Image image2 = new Image();
            image.Width = 100;
            image.Height = 100;
            image.Source = imageSource;

            //Button btn = sender as Button;
            //int rowNumber = (int)btn.GetValue(Grid.RowProperty);
            //int columnNumber = (int)btn.GetValue(Grid.ColumnProperty);
            //var t = ((Image)this.lbxToolBox.SelectedItem);

            //Add image object to the selected cell
            //this.gridPath.Children.Add(image);
            //Grid.SetColumn(image, columnNumber);
            //Grid.SetRow(image, rowNumber);
            //Image image2 = new Image();
            //image.Width = 100;
            //image.Height = 100;
            //image.Source = imageSource;
            //// Create a Canvas to contain ellipsePath
            //// and add it to the page.
            //Canvas mainPanel = new Canvas();
            //mainPanel.Width = 400;
            //mainPanel.Height = 400;
            //mainPanel.Children.Add(ellipsePath);
            //mainPanel.Children.Add(image);
            //mainPanel.Children.Add(image2);

            //this.Content = mainPanel;
            ////< Image Height = "100" Canvas.Left = "-165" Canvas.Top = "214" Width = "100" Source = "img/item2.png" />
            //Component component1 = new Component(ComponentType.StraightPath, , )
            //System.Windows.Point p = e.GetPosition(image);
            //double pixelWidth = image.Source.Width;
            //double pixelHeight = image.Source.Height;
            //double x = pixelWidth * p.X / image.ActualWidth;
            //double y = pixelHeight * p.Y / image.ActualHeight;

            //System.Windows.Point p2 = e.GetPosition(image2);
            //double pixelWidth2 = image2.Source.Width;
            //double pixelHeight2 = image2.Source.Height;
            //double x2 = pixelWidth * p.X / image2.ActualWidth;
            //double y2 = pixelHeight * p.Y / image2.ActualHeight;
            //double left = Canvas.GetLeft(image);
            //double top = Canvas.GetTop(image);

            double left2 = Canvas.GetLeft(image2);
            double top2 = Canvas.GetTop(image2);
            double x = rectangleGeometry.Rect.X;
            double y = rectangleGeometry.Rect.Top + ((rectangleGeometry.Rect.Bottom - rectangleGeometry.Rect.Top) / 2);

            double x2 = rectangleGeometry2.Rect.X + rectangleGeometry2.Rect.Width;
            double y2 = rectangleGeometry2.Rect.Top + ((rectangleGeometry2.Rect.Bottom - rectangleGeometry2.Rect.Top) / 2);

            double x3 = rectangleGeometry3.Rect.X + ((rectangleGeometry3.Rect.Right - rectangleGeometry3.Rect.Left) / 2);
            double y3 = rectangleGeometry3.Rect.Y + rectangleGeometry3.Rect.Height;

            // Create the animation path.
            PathGeometry animationPath = new PathGeometry();
            PathFigure pFigure = new PathFigure();
            pFigure.StartPoint = new Point(x, y);
            PolyBezierSegment pBezierSegment = new PolyBezierSegment();
            pBezierSegment.Points.Add(new Point(x3, y2));
            pBezierSegment.Points.Add(new Point(x3, y2));
            pBezierSegment.Points.Add(new Point(x3, y3));
            pBezierSegment.Points.Add(new Point(x3, y3));
            //pBezierSegment.Points.Add(new Point(35, 100));
            //pBezierSegment.Points.Add(new Point(180, 100));
            //pBezierSegment.Points.Add(new Point(285, 100));
            //pBezierSegment.Points.Add(new Point(310, 100));
            pFigure.Segments.Add(pBezierSegment);
            animationPath.Figures.Add(pFigure);

            // Freeze the PathGeometry for performance benefits.
            animationPath.Freeze();

            // Create a PointAnimationgUsingPath to move
            // the EllipseGeometry along the animation path.
            PointAnimationUsingPath centerPointAnimation =
                new PointAnimationUsingPath();
            centerPointAnimation.PathGeometry = animationPath;
            centerPointAnimation.Duration = TimeSpan.FromSeconds(5);
            centerPointAnimation.SpeedRatio = 1;
            centerPointAnimation.RepeatBehavior = RepeatBehavior.Forever;

            // Set the animation to target the Center property
            // of the EllipseGeometry named "AnimatedEllipseGeometry".
            Storyboard.SetTargetName(centerPointAnimation, "AnimatedEllipseGeometry");
            Storyboard.SetTargetProperty(centerPointAnimation,
                new PropertyPath(EllipseGeometry.CenterProperty));

            // Create a Storyboard to contain and apply the animation.
            Storyboard pathAnimationStoryboard = new Storyboard();
            pathAnimationStoryboard.RepeatBehavior = RepeatBehavior.Forever;
            pathAnimationStoryboard.AutoReverse = true;
            pathAnimationStoryboard.Children.Add(centerPointAnimation);

            // Start the Storyboard when ellipsePath is loaded.
            ellipsePath.Loaded += delegate (object sender1, RoutedEventArgs e1)
            {
                // Start the storyboard.
                pathAnimationStoryboard.Begin(this);
            };

        }
    }
}
