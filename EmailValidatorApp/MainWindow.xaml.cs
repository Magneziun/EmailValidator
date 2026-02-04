using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace EmailValidatorApp
{
    public partial class MainWindow : Window
    {
        private Point startPoint;

        public MainWindow()
        {
            InitializeComponent();
            this.MouseDown += MainWindow_MouseDown;
            this.MouseMove += MainWindow_MouseMove;
        }

        private void ValidateButton_Click(object sender, RoutedEventArgs e)
        {
            var result = EmailValidator.EmailValidator.ValidateEmail(EmailBox.Text);

            ResultText.Text = result.Message;
            ResultText.Foreground = result.IsValid ?
                new SolidColorBrush(Color.FromRgb(29, 185, 84)) : // Spotify Green
                new SolidColorBrush(Color.FromRgb(231, 76, 60));  // Красный для ошибки
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MainWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                startPoint = e.GetPosition(this);
                this.CaptureMouse();
            }
        }

        private void MainWindow_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && IsMouseCaptured)
            {
                var currentPoint = e.GetPosition(this);
                this.Left += currentPoint.X - startPoint.X;
                this.Top += currentPoint.Y - startPoint.Y;
            }
        }

        protected override void OnMouseUp(MouseButtonEventArgs e)
        {
            base.OnMouseUp(e);
            this.ReleaseMouseCapture();
        }
    }
}