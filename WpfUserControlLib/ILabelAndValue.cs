using System;
using System.Windows;
using System.Windows.Media;

namespace WpfUserControlLib
{
    public interface ILabelAndValue
    {
        #region Color_properties
        SolidColorBrush LabelAndDataBorderBrush { set; }
        SolidColorBrush LabelForegroundBrush { set; }
        SolidColorBrush LabelBackgroundBrush { set; }
        SolidColorBrush ValueForegroundBrush { set; }
        SolidColorBrush ValueBackgroundBrush { set; }
        #endregion

        #region geometrical_properties
        double WindowHeight { set; }

        /// <summary>
        /// (Label width + Value width) / (Line height)
        /// </summary>
        double WidthPerLineHeight { set; }
        double LabelWidthPerWholeWidth { set; }
        HeightClass HeightClass { set; }
        bool IsBoldBorder { set; }
        HorizontalAlignment LabelAlignment { set; }
        HorizontalAlignment ValueAlignment { set; }
        #endregion

        #region data_model_properties
        string LabelText { set; }
        string ValueText { set; }
        double ValueDouble { set; }
        long ValueLong { set; }
        bool ValueBool { set; }
        D2s FormatDouble { set; }
        L2s FormatLong { set; }
        B2s FormatBool { set; }
        /// <summary>
        /// normal and selected are the same condition. Only disabled is different.
        /// </summary>
        TristateControlState ControlState { set; }
        #endregion
    }

    public interface ILabelAndValue2
    {
        string LabelText1 { set; }
        string ValueText1 { set; }
        double ValueDouble1 { set; }
        long ValueLong1 { set; }
        bool ValueBool1 { set; }
        D2s FormatDouble1 { set; }
        L2s FormatLong1 { set; }
        B2s FormatBool1 { set; }
    }

    public interface ILabelAndValue3 : ILabelAndValue2
    {
        string LabelText3 { set; }
        string ValueText3 { set; }
        double ValueDouble3 { set; }
        long ValueLong3 { set; }
        bool ValueBool3 { set; }
        D2s FormatDouble3 { set; }
        L2s FormatLong3 { set; }
        B2s FormatBool3 { set; }
    }
    public interface ILabelAndValue4 : ILabelAndValue3
    {
        string LabelText4 { set; }
        string ValueText4 { set; }
        double ValueDouble4 { set; }
        long ValueLong4 { set; }
        bool ValueBool4 { set; }
        D2s FormatDouble4 { set; }
        L2s FormatLong4 { set; }
        B2s FormatBool4 { set; }
    }

}
