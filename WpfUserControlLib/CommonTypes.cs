using System;
using System.Windows.Media;

namespace WpfUserControlLib
{
    /// <summary>
    /// Text line height class enumerator for digital signage like GUI
    /// </summary>
    public enum HeightClass
    {
        _20Lines, // small font text for auxiliary notification
        _10Lines, // standard size font text for most use
        _5Lines // large size font text mainly for titles and warnings
    };

    public enum TristateControlState
    {
        normal, // normal display state
        selected, // mouse button pressed or touched on a touch panel
        disabled // disabled but shown
    };

    /// <summary>
    /// Color pair for text display object
    /// </summary>
    public struct ForegroundAndBackground
    {
        public Color foreground_;
        public Color background_;
    }

    /// <summary>
    /// 
    /// </summary>
    public struct ButtonDataModel
    {
        public string caption_; // Text rendered on a button
        public int code_; // key-code returned by click event
        public TristateControlState state_; // current state of an GUI element
    }

    /// <summary>
    /// A helper class to manipulate text sizes proportional to a height of a window hosting the text.
    /// </summary>
    public class SizeConfiguration
    {
        #region constants
        public static readonly double FontSizePerLineHeight = 0.7;
        public static readonly double CornerRadiusPerLineHeight = 0.05;
        public static readonly double[] LineHeightsPerWindowHeight = { 1.0 / 20.0, 1.0 / 10.0, 1.0 / 5.0 };
        public static readonly double[] FontSizesPerWindowHeight =
        {
            FontSizePerLineHeight * LineHeightsPerWindowHeight[0],
            FontSizePerLineHeight * LineHeightsPerWindowHeight[1],
            FontSizePerLineHeight * LineHeightsPerWindowHeight[2]
        };
        public static readonly double BorderThicknessPerFontSize = 1.0 / 30.0;
        public static readonly double[] NormalBorderThicknessPerWindowHeight =
        {
            BorderThicknessPerFontSize * FontSizesPerWindowHeight[0],
            BorderThicknessPerFontSize * FontSizesPerWindowHeight[1],
            BorderThicknessPerFontSize * FontSizesPerWindowHeight[2]
        };
        public static readonly double BorderThickenssBoldNormalRatio = 2.0;
        public static readonly double[] BoldBorderThicknessPerWindowHeight =
        {
            BorderThickenssBoldNormalRatio * NormalBorderThicknessPerWindowHeight[0],
            BorderThickenssBoldNormalRatio * NormalBorderThicknessPerWindowHeight[1],
            BorderThickenssBoldNormalRatio * NormalBorderThicknessPerWindowHeight[2]
        };

        public static readonly double HeightPerWidthVGA = 480.0 / 640.0;
        public static readonly double WidthPerHeightVGA = 640.0 / 480.0;
        public static readonly double HeightPerWidthFHD = 1080.0 / 1920.0;
        public static readonly double WidthPerHeightFHD = 1920.0 / 1080.0;
        public static readonly double HeightVGA = 480.0;
        public static readonly double HeightSVGA = 768.0;
        public static readonly double HeightFHD = 1080.0;
        #endregion

        #region private_data
        double heightPerWidth_; // (window height) / (window width)
        HeightClass heightClass_; // ID of line height class (20 lines per page, 10 lines per page, 5 lines per page)
        double windowHeight_;
        bool isBoldBorder_;
        #endregion

        #region functional_properties
        public double ThinnestLineThickness
        {
            get
            {
                double shorterScreenEdge = Math.Min(WindowHeight, WindowWidth);
                return (shorterScreenEdge < 500.0) ? 1.0 : shorterScreenEdge / 500.0;
            }
        }
        public SizeConfiguration(HeightClass heightClass, double heightPerWidth, double windowHeight,
            bool isBoldBorder = false)
        {
            heightClass_ = heightClass;
            heightPerWidth_ = heightPerWidth;
            windowHeight_ = windowHeight;
            isBoldBorder_ = isBoldBorder;
        }

        public HeightClass HeightClass
        {
            get => heightClass_;
            set => heightClass_ = value;
        }

        public double HeightPerWidth
        {
            get => heightPerWidth_;
            set => heightPerWidth_ = value;
        }

        public double WindowHeight
        {
            get => windowHeight_;
            set => windowHeight_ = value;
        }

        public double WindowWidth
        {
            get => windowHeight_ / heightPerWidth_;
            set => windowHeight_ = value * heightPerWidth_;
        }
        public double LineHeight
        {
            get => LineHeightsPerWindowHeight[(int)heightClass_] * windowHeight_;
        }

        public double FontSize
        {
            get => FontSizesPerWindowHeight[(int)heightClass_] * windowHeight_;
        }
        public double CornerRadius
        {
            get => CornerRadiusPerLineHeight * LineHeight;
        }
        public bool IsBoldBorder
        {
            get => isBoldBorder_;
            set => isBoldBorder_ = value;
        }
        public double BorderThickness
        {
            get => windowHeight_ * (
                (IsBoldBorder) ? 
                BoldBorderThicknessPerWindowHeight[(int)heightClass_] :
                NormalBorderThicknessPerWindowHeight[(int)heightClass_]);
        }
        #endregion
    }

    public static class ColorHelper
    {
        public static readonly Color NumberKeyForeground = System.Windows.Media.Color.FromArgb(255, 0, 0, 0);
        public static readonly Color NumberKeyBackground = System.Windows.Media.Color.FromArgb(255, 180, 180, 180);

        #region private_helper_functions
        static byte Dimmer(byte colorChannel)
        {
            return (byte)(0.7 * (double)colorChannel);
        }
        static byte Grayed(byte colorChannel)
        {
            int whiteMinusColorChannel = 255 - colorChannel;
            return (byte)(255 - (whiteMinusColorChannel >> 2));
        }
        public static Color Dimmer(Color color)
        {
            return new Color()
            {
                A = color.A,
                R = Dimmer(color.R),
                G = Dimmer(color.G),
                B = Dimmer(color.B)
            };
        }
        public static Color Grayed(Color color)
        {
            return new Color()
            {
                A = color.A,
                R = Grayed(color.R),
                G = Grayed(color.G),
                B = Grayed(color.B)
            };
        }

        #endregion

        /// <summary>
        /// Create a modified color for UI component in selected mode
        /// </summary>
        /// <param name="normalColor"></param>
        public static Color ToSelectedColor(Color normalColor)
        {
            Color selected = new Color()
            {
                A = normalColor.A,
                R = Dimmer(normalColor.R),
                G = Dimmer(normalColor.G),
                B = Dimmer(normalColor.B),
            };
            return selected;
        }

        /// <summary>
        /// Create a modified color for UI component in disabled mode
        /// </summary>
        /// <param name="normalColor"></param>
        /// <returns></returns>
        public static Color ToDisabledColor(Color normalColor)
        {
            Color disabled = new Color()
            {
                A = normalColor.A,
                R = Grayed(normalColor.R),
                G = Grayed(normalColor.G),
                B = Grayed(normalColor.B),
            };
            return disabled;
        }

        /// <summary>
        /// It is used to create a color group selection index for two-color state objects.
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public static int TristateControlStateToBinary(TristateControlState state)
        {
            return (state == TristateControlState.disabled) ? 1 : 0;
        }
    }
}
