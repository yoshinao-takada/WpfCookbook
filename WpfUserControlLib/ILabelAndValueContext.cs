using System.Windows;
using System.Windows.Media;

namespace WpfUserControlLib
{
    public class LabelColorSet
    {
        public Color border_;
        public ForegroundAndBackground label_;
        public ForegroundAndBackground value_;
    }
    public class LabelAndValueDataModel
    {
        public string[] labels_;
        public string[] values_;
        public D2s[] formatDouble_;
        public L2s[] formatLong_;
        public B2s[] formatBool_;
        public TristateControlState controlState_;

        public LabelAndValueDataModel(int itemCount)
        {
            labels_ = new string[itemCount];
            values_ = new string[itemCount];
            formatDouble_ = new D2s[itemCount];
            formatLong_ = new L2s[itemCount];
            formatBool_ = new B2s[itemCount];
            controlState_ = TristateControlState.normal;
            for (int i = 0; i < itemCount; i++)
            {
                labels_[i] = $"Label {i}";
                values_[i] = $"Value {i}";
                formatBool_[i] = StdFormatBool;
                formatLong_[i] = StdFormatLong;
                formatDouble_[i] = StdFormatDouble;
            }
        }
        
        public static string StdFormatBool(bool b)
        {
            return b.ToString();
        }

        public static string StdFormatLong(long l)
        {
            return l.ToString("C");
        }

        public static string StdFormatDouble(double d)
        {
            return d.ToString("F1");
        }
    }
    public interface ILabelAndValueContext
    {
        #region color_properties
        SolidColorBrush BorderBrush { get; set; }
        SolidColorBrush LabelForegroundBrush { get; set; }
        SolidColorBrush LabelBackgroundBrush { get; set; }
        SolidColorBrush ValueForegroundBrush { get; set; }
        SolidColorBrush ValueBackgroundBrush { get; set; }
        #endregion

        #region geometrical_properties
        double WindowHeight { set; }

        /// <summary>
        /// (Label width + Value width) / (Line height)
        /// </summary>
        double WidthPerLineHeight { set; }
        double LabelWidthPerWholeWidth { set; }
        HeightClass HeightClass { get; set; }
        double LineHeight { get; }
        double LineWidth { get; }
        double LabelWidth { get; }
        double ValueWidth { get; }
        double FontSize { get; }
        CornerRadius LabelCornerRadius { get; }
        CornerRadius ValueCornerRadius { get; }
        bool IsBoldBorder { set; get; }
        Thickness LabelBorderThickness { get; }
        Thickness ValueBorderThickness { get; }
        Thickness PaddingPerLineHeight { set; }
        Thickness LabelPadding { get; }
        Thickness ValuePadding { get; }
        HorizontalAlignment LabelAlignment { get; set; }
        HorizontalAlignment ValueAlignment { get; set; }
        #endregion

        #region model_data
        string LabelText { get; set; }
        string ValueText { get; set; }
        double ValueDouble { set; }
        long ValueLong { set; }
        bool ValueBool { set; }
        D2s FormatDouble { set; }
        L2s FormatLong { set; }
        B2s FormatBool { set; }
        /// <summary>
        /// normal and selected are the same condition. Only disabled is different.
        /// </summary>
        TristateControlState ControlState { get; set; }
        #endregion
    }
    
    /// <summary>
    /// Two line version of ILabelAndValueContext
    /// </summary>
    public interface ILabelAndValue2Context
    {
        #region geometrical_properties
        double BlockHeight2 { get; }
        CornerRadius TopLeftCornerRadius { get; }
        CornerRadius BottomLeftCornerRadius { get; }
        CornerRadius TopRightCornerRadius { get; }
        CornerRadius BottomRightCornerRadius { get; }
        Thickness TopLeftBorderThickness { get; }
        Thickness BottomLeftBorderThickness { get; }
        Thickness TopRightBorderThickness { get; }
        Thickness BottomRightBorderThickness { get; }
        #endregion

        #region data_model_properties
        string LabelText1 { get; set; }
        string ValueText1 { get; set; }
        double ValueDouble1 { set; }
        long ValueLong1 { set; }
        bool ValueBool1 { set; }
        D2s FormatDouble1 { set; }
        L2s FormatLong1 { set; }
        B2s FormatBool1 { set; }
        #endregion
    }
    /// <summary>
    /// Three line version of ILabelAndValueContext
    /// </summary>
    public interface ILabelAndValue3Context
    {
        #region geometrical_properties
        Thickness LeftBorderThickness { get; }
        Thickness RightBorderThickness { get; }
        #endregion

        #region data_model_properties
        string LabelText3 { get; set; }
        string ValueText3 { get; set; }
        double ValueDouble3 { set; }
        long ValueLong3 { set; }
        bool ValueBool3 { set; }
        D2s FormatDouble3 { set; }
        L2s FormatLong3 { set; }
        B2s FormatBool3 { set; }
        #endregion
    }

    /// <summary>
    /// Four line version of ILabelAndValueContext
    /// </summary>
    public interface ILabelAndValue4Context
    {
        string LabelText4 { get; set; }
        string ValueText4 { get; set; }
        double ValueDouble4 { set; }
        long ValueLong4 { set; }
        bool ValueBool4 { set; }
        D2s FormatDouble4 { set; }
        L2s FormatLong4 { set; }
        B2s FormatBool4 { set; }
    }
}
