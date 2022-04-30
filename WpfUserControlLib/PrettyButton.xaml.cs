using System.Windows.Controls;
using System.Windows;
using System;
using System.Windows.Media;

namespace WpfUserControlLib
{
    /// <summary>
    /// Interaction logic for PrettyButton.xaml
    /// </summary>
    public partial class PrettyButton : UserControl
    {
        public PrettyButton()
        {
            InitializeComponent();
        }

        private void OnLoaded(object sender, System.Windows.RoutedEventArgs e)
        {
            var context = DataContext as IPrettyButtonContext;
        }

        event InputEventHandler ButtonClickEvent;

        private void MyButtonEventHandler(object sender, KeyButtonClickedEventArgs e)
        {
            string message = $"keycode = {e.KeyCode} @ MyButtonEventHundler()";
            MessageBox.Show(message);
            ButtonState = TristateControlState.disabled;
        }
        private void OnPressed(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var context = DataContext as IPrettyButtonContext;
            if (context.ControlState != TristateControlState.disabled)
            {
                context.ControlState = TristateControlState.selected;
            }
        }

        private void OnReleased(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var context = DataContext as IPrettyButtonContext;
            if (context.ControlState != TristateControlState.disabled)
            {
                context.ControlState = TristateControlState.normal;
                var keyEventArgs = new KeyButtonClickedEventArgs(e.Device, context.ButtonKeyCode);
                ButtonClickEvent?.Invoke(sender, keyEventArgs);
            }
        }

        #region Visual_properties
        public string Caption
        {
            get
            {
                var context = DataContext as IPrettyButtonContext;
                return context.Caption;
            }
            set
            {
                var context = DataContext as IPrettyButtonContext;
                context.Caption = value;
            }
        }
        public double WidthPerHeight
        {
            set
            {
                var context = DataContext as IPrettyButtonContext;
                context.WidthPerHeight = value;
            }
        }
        public TristateControlState ButtonState
        {
            get
            {
                var context = DataContext as IPrettyButtonContext;
                return context.ControlState;
            }
            set
            {
                var context = DataContext as IPrettyButtonContext;
                context.ControlState = value;
            }
        }
        public SolidColorBrush ButtonForeground
        {
            set
            {
                Console.WriteLine($"value = {value.ToString()} @ PrettyButton.Foreground set;");
                var context = DataContext as IPrettyButtonContext;
                context.ForegroundBrush = value;
                base.Foreground = value;
            }
        }
        public SolidColorBrush ButtonBackground
        {
            set
            {
                Console.WriteLine($"value = {value.ToString()} @ PrettyButton.Background set;");
                var context = DataContext as IPrettyButtonContext;
                context.BackgroundBrush = value;
                base.Background = value;
            }
        }
        public HeightClass HeightClass
        {
            set
            {
                Console.WriteLine($"value = {value.ToString()} @ PrettyButton.HeightClass set;");
                var context = DataContext as IPrettyButtonContext;
                context.HeightClass = value;
            }
        }
        #endregion
    }
}
