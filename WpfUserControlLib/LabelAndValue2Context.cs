using System;
using System.Windows;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace WpfUserControlLib
{
    public class LabelAndValue2Context : LabelAndValueContext, ILabelAndValue2Context
    {
        public LabelAndValue2Context() : base()
        {
            dataModel_ = new LabelAndValueDataModel(2);
        }

        #region geometrical_properties
        public double BlockHeight2
        {
            get => 2.0 * LineHeight;
        }
        public CornerRadius TopLeftCornerRadius
        {
            get => new CornerRadius(sizeConf_.CornerRadius, 0.0, 0.0, 0.0);
        }
        public CornerRadius BottomLeftCornerRadius 
        {
            get => new CornerRadius(0.0, 0.0, 0.0, sizeConf_.CornerRadius);
        }
        public CornerRadius TopRightCornerRadius
        {
            get => new CornerRadius(0.0, sizeConf_.CornerRadius, 0.0, 0.0);
        }
        public CornerRadius BottomRightCornerRadius
        {
            get => new CornerRadius(0.0, 0.0, sizeConf_.CornerRadius, 0.0);
        }
        public Thickness TopLeftBorderThickness
        {
            get
            {
                double outerBorderThickness = sizeConf_.BorderThickness;
                double innerBorderThickness = Math.Min(outerBorderThickness, sizeConf_.ThinnestLineThickness);
                return new Thickness(
                    outerBorderThickness, outerBorderThickness, innerBorderThickness, innerBorderThickness);
            }
        }
        public Thickness BottomLeftBorderThickness
        {
            get
            {
                double outerBorderThickness = sizeConf_.BorderThickness;
                double innerBorderThickness = Math.Min(outerBorderThickness, sizeConf_.ThinnestLineThickness);
                return new Thickness(outerBorderThickness, 0.0, innerBorderThickness, outerBorderThickness);
            }
        }
        public Thickness TopRightBorderThickness
        {
            get
            {
                double outerBorderThickness = sizeConf_.BorderThickness;
                double innerBorderThickness = Math.Min(outerBorderThickness, sizeConf_.ThinnestLineThickness);
                return new Thickness(0.0, outerBorderThickness, outerBorderThickness, innerBorderThickness);
            }
        }
        public Thickness BottomRightBorderThickness
        {
            get
            {
                double outerBorderThickness = sizeConf_.BorderThickness;
                return new Thickness(0.0, 0.0, outerBorderThickness, outerBorderThickness);
            }
        }
        #endregion

        #region data_model_properties
        public string LabelText1
        {
            get => dataModel_.labels_[1];
            set => SetProperty(ref dataModel_.labels_[1], value);
        }
        public string ValueText1
        {
            get => dataModel_.values_[1];
            set => SetProperty(ref dataModel_.values_[1], value);
        }
        public double ValueDouble1
        {
            set => ValueText1 = dataModel_.formatDouble_[1](value);
        }
        public long ValueLong1
        {
            set => ValueText1 = dataModel_.formatLong_[1](value);
        }
        public bool ValueBool1
        {
            set => ValueText1 = dataModel_.formatBool_[1](value);
        }
        public D2s FormatDouble1
        {
            set => SetProperty(ref dataModel_.formatDouble_[1], value, nameof(FormatDouble));
        }
        public L2s FormatLong1
        {
            set => SetProperty(ref dataModel_.formatLong_[1], value, nameof(FormatLong1));
        }
        public B2s FormatBool1
        {
            set => SetProperty(ref dataModel_.formatBool_[1], value, nameof(FormatBool1));
        }
        #endregion

    }
}
