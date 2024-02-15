using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private RotateTransform rotateTransform;

        /// <summary>
        /// 선택한 옵션
        /// </summary>
        private int SelectOption = 0;

        public MainWindow()
        {
            InitializeComponent();


            // Create a new RotateTransform and assign it to the Button
            rotateTransform = new RotateTransform();
            myButton.RenderTransform = rotateTransform;

            //myButton.RenderTransformOrigin = new Point(0.5, 0.5);
        }

        private void btnAtan_Select_Click(object sender, RoutedEventArgs e)
        {
            this.SelectOption = 0;
        }
        private void btnAtan2_Select_Click(object sender, RoutedEventArgs e)
        {
            this.SelectOption = 1;
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            // Get the position of the mouse relative to the Button
            Point mousePos = e.GetPosition(this.canvasMain);
            //var buttonSize = new Point(myButton.ActualWidth, myButton.ActualHeight);
            Point buttonSize = new Point(Canvas.GetLeft(myButton), Canvas.GetTop(myButton));

            switch (this.SelectOption)
            {
                case 0:
                    this.Atan(mousePos, buttonSize);
                    break;
                case 1:
                    this.Atan2(mousePos, buttonSize);
                    break;

            }
            
        }

        /// <summary>
        /// https://stackoverflow.com/a/963099/6725889
        /// </summary>
        private void Atan(Point mousePos, Point buttonSize)
        {
            
            // Compute the angle in radians
            // Calculate an angle
            double tan = (mousePos.Y - buttonSize.Y)
                        / (mousePos.X - buttonSize.X);
            double angle = Math.Atan(tan) * (180 / Math.PI);

            // Apply a 180 degree shift when X is negative so that we can rotate
            // all of the way around
            if (mousePos.X - buttonSize.X < 0)
            {
                angle += 180;
            }

            // Set the angle of the RotateTransform
            rotateTransform.Angle = angle;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mousePos"></param>
        /// <param name="buttonSize"></param>
        private void Atan2(Point mousePos, Point buttonSize)
        {
            // Compute the angle in radians
            var radian = Math.Atan2(mousePos.Y - buttonSize.Y / 2, mousePos.X - buttonSize.X / 2);

            // Normalize the angle to 0 - 2π
            if (radian < 0)
            {
                radian += 2 * Math.PI;
            }

            // Convert the angle to degrees
            var angle = radian * 180 / Math.PI;

            // Set the angle of the RotateTransform
            rotateTransform.Angle = angle;
        }



    }
}