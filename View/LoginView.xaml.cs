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
using System.Windows.Shapes;

namespace SellWoodTracker_ver2._0.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        private bool isResizing = false;
        private Point startPoint;
        public LoginView()
        {
            InitializeComponent();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Maximized;

                btnRestore.Content = new Image
                {
                    Source = new BitmapImage(new Uri("/Images/restore_down_window.png", UriKind.Relative)),
                    Height = 25,
                    Width = 25,
                };
            }
            else if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
                // Change the icon to indicate maximize
                btnRestore.Content = new Image
                {
                    Source = new BitmapImage(new Uri("/Images/maximize_window.png", UriKind.Relative)),
                    Height = 25,
                    Width = 25
                };
            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void ResizeWindowMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                isResizing = true;
                startPoint = e.GetPosition(this);
            }
        }

        private void ResizeWindowMouseMove(object sender, MouseEventArgs e)
        {
            if (isResizing)
            {
                Point endPoint = e.GetPosition(this);
                double deltaX = endPoint.X - startPoint.X;
                double deltaY = endPoint.Y - startPoint.Y;

                Width += deltaX;
                Height += deltaY;

                startPoint = endPoint;
            }
        }

        private void StopResizeWindow(object sender, MouseButtonEventArgs e)
        {
            isResizing = false;
        }

    }
}
