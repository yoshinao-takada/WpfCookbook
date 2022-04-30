using System.Windows;
using System.Windows.Media;

namespace WpfUserControlLib
{
    interface IPrettyButtonContext
    {
        #region color_proerpties
        SolidColorBrush ForegroundBrush { get; set; }
        SolidColorBrush BackgroundBrush { get; set; }
        #endregion

        #region geometrial_properties
        double WindowHeight { set; }
        HeightClass HeightClass { set; }
        double Height { get; }
        double Width { get; }
        double FontSize { get; }
        CornerRadius CornerRadius { get; }
        double WidthPerHeight { get; set; } // object width / height
        #endregion

        #region data_model_properties
        string Caption { get; set; }
        int ButtonKeyCode { get; set; }
        TristateControlState ControlState { get; set; }
        #endregion
    }
}
