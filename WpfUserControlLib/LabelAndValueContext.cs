using System;
using System.Windows;
using System.Windows.Media;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace WpfUserControlLib
{
    public class LabelAndValueContext : ObservableObject, ILabelAndValueContext
    {
        #region private_data
        #region private const
        public const string Lbrace = "{";
        public const string Rbrace = "}";
        #endregion
        #region private variables
        protected LabelColorSet seen_;
        protected LabelColorSet[] colors_;
        protected SizeConfiguration sizeConf_;
        protected double widthPerLineHeight_;
        protected double labelWidthPerWholeWidth_;
        protected LabelAndValueDataModel dataModel_;
        protected HorizontalAlignment labelAlignment_;
        protected HorizontalAlignment valueAlignment_;
        protected Thickness paddingPerLineHeight_;
        #endregion
        #endregion

        public LabelAndValueContext() : base()
        {
            seen_ = new LabelColorSet();
            colors_ = new LabelColorSet[2]
            {
                new LabelColorSet(),
                new LabelColorSet()
            };
            colors_[1].border_ = ColorHelper.Grayed(
                colors_[0].border_ = Color.FromArgb(255, 0, 0, 0)); // black border
            colors_[1].label_.foreground_ = ColorHelper.Grayed(
                colors_[0].label_.foreground_ = Color.FromArgb(255, 128, 128, 255)); // light blue text
            colors_[1].label_.background_ = ColorHelper.Grayed(
                colors_[0].label_.background_ = Color.FromArgb(255, 0, 128, 128)); // dark blue green
            colors_[1].value_.foreground_ = ColorHelper.Grayed(
                colors_[0].value_.foreground_ = Color.FromArgb(255, 0, 0, 64)); // dark red text
            colors_[1].value_.background_ = ColorHelper.Grayed(
                colors_[0].value_.background_ = Color.FromArgb(255, 255, 255, 255)); // white background
            seen_ = colors_[0];
            dataModel_ = new LabelAndValueDataModel(1);
            sizeConf_ = new SizeConfiguration(HeightClass._20Lines, SizeConfiguration.HeightPerWidthVGA, SizeConfiguration.HeightVGA);
            widthPerLineHeight_ = 20;
            labelWidthPerWholeWidth_ = 0.5;
            paddingPerLineHeight_ = new Thickness(0.5, 0.0, 0.5, 0.0);
            labelAlignment_ = HorizontalAlignment.Right;
            valueAlignment_ = HorizontalAlignment.Left;
        }

        #region color_properties
        public SolidColorBrush BorderBrush
        {
            get => new SolidColorBrush(seen_.border_);
            set
            {
                colors_[0].border_ = value.Color;
                colors_[1].border_ = ColorHelper.Grayed(value.Color);
                OnPropertyChanged(nameof(BorderBrush));
            }
        }
        public SolidColorBrush LabelForegroundBrush
        {
            get => new SolidColorBrush(seen_.label_.foreground_);
            set
            {
                colors_[0].label_.foreground_ = value.Color;
                colors_[1].label_.foreground_ = ColorHelper.Grayed(value.Color);
                OnPropertyChanged(nameof(LabelForegroundBrush));
            }
        }
        public SolidColorBrush LabelBackgroundBrush
        {
            get => new SolidColorBrush(seen_.label_.background_);
            set
            {
                colors_[0].label_.background_ = value.Color;
                colors_[1].label_.background_ = ColorHelper.Grayed(value.Color);
                OnPropertyChanged(nameof(LabelBackgroundBrush));
            }
        }
        public SolidColorBrush ValueForegroundBrush
        {
            get => new SolidColorBrush(seen_.value_.foreground_);
            set
            {
                colors_[0].value_.foreground_ = value.Color;
                colors_[1].value_.foreground_ = ColorHelper.Grayed(value.Color);
                OnPropertyChanged(nameof(ValueForegroundBrush));
            }
        }
        public SolidColorBrush ValueBackgroundBrush
        {
            get => new SolidColorBrush(seen_.value_.background_);
            set
            {
                colors_[0].value_.background_ = value.Color;
                colors_[1].value_.background_ = ColorHelper.Grayed(value.Color);
                OnPropertyChanged(nameof(ValueBackgroundBrush));
            }
        }

        #endregion

        #region geometrical_properties
        void OnAllChanged()
        {
            OnPropertyChanged(nameof(LineHeight));
            OnPropertyChanged(nameof(LabelWidth));
            OnPropertyChanged(nameof(ValueWidth));
            OnPropertyChanged(nameof(FontSize));
        }
        public double WindowHeight
        {
            set
            {
                sizeConf_.WindowHeight = value;
                OnAllChanged();
            }

        }
        public double WidthPerLineHeight
        {
            set
            {
                widthPerLineHeight_ = value;
                OnPropertyChanged(nameof(LabelWidth));
                OnPropertyChanged(nameof(ValueWidth));
            }
        }
        public double LabelWidthPerWholeWidth
        {
            set
            {
                labelWidthPerWholeWidth_ = value;
                OnPropertyChanged(nameof(LabelWidth));
                OnPropertyChanged(nameof(ValueWidth));
            }
        }
        public HeightClass HeightClass
        {
            get => sizeConf_.HeightClass;
            set
            {
                sizeConf_.HeightClass = value;
                OnPropertyChanged(nameof(LineHeight));
            }
        }
        public double LineHeight
        {
            get => sizeConf_.LineHeight;
        }
        public double LineWidth
        {
            get => sizeConf_.LineHeight * widthPerLineHeight_;
        }
        public double LabelWidth
        {
            get => labelWidthPerWholeWidth_ * widthPerLineHeight_ * sizeConf_.LineHeight;
        }
        public double ValueWidth
        {
            get => (1.0 - labelWidthPerWholeWidth_) * widthPerLineHeight_ * sizeConf_.LineHeight;
        }
        public double FontSize
        {
            get => sizeConf_.FontSize;
        }
        public CornerRadius LabelCornerRadius
        {
            get => new CornerRadius(sizeConf_.CornerRadius, 0.0, 0.0, sizeConf_.CornerRadius);
        }
        public CornerRadius ValueCornerRadius
        {
            get => new CornerRadius(0.0, sizeConf_.CornerRadius, sizeConf_.CornerRadius, 0.0);
        }


        public bool IsBoldBorder
        {
            get => sizeConf_.IsBoldBorder;
            set => sizeConf_.IsBoldBorder = value;
        }
        public Thickness LabelBorderThickness
        {
            get => new Thickness(
                sizeConf_.BorderThickness, sizeConf_.BorderThickness, 
                Math.Min(sizeConf_.BorderThickness, sizeConf_.ThinnestLineThickness),
                sizeConf_.BorderThickness);
        }
        public Thickness ValueBorderThickness
        {
            get => new Thickness(
                0.0, sizeConf_.BorderThickness, sizeConf_.BorderThickness, sizeConf_.BorderThickness);
        }
        public Thickness PaddingPerLineHeight
        {
            set
            {
                double rcpLineHeight = 1.0 / LineHeight;
                paddingPerLineHeight_ = new Thickness(
                    value.Left * rcpLineHeight,
                    value.Top * rcpLineHeight,
                    value.Right * rcpLineHeight,
                    value.Bottom * rcpLineHeight);
                OnPropertyChanged(nameof(LabelPadding));
                OnPropertyChanged(nameof(ValuePadding));
            }
        }
        public Thickness LabelPadding
        {
            get
            {
                var padding = new Thickness(0.0);
                if (labelAlignment_ == HorizontalAlignment.Left)
                {
                    padding.Left += paddingPerLineHeight_.Left * LineHeight + sizeConf_.CornerRadius;
                }
                else if (labelAlignment_ == HorizontalAlignment.Right)
                {
                    padding.Right += paddingPerLineHeight_.Right * LineHeight;
                }
                return padding;
            }
        }
        public Thickness ValuePadding 
        {
            get
            {
                var padding = new Thickness(0.0);
                if (valueAlignment_ == HorizontalAlignment.Left)
                {
                    padding.Left += paddingPerLineHeight_.Left * LineHeight;
                }
                else if (labelAlignment_ == HorizontalAlignment.Right)
                {
                    padding.Right += paddingPerLineHeight_.Right * LineHeight + sizeConf_.CornerRadius;
                }
                return padding;
            }
        }
        public HorizontalAlignment LabelAlignment 
        {
            get => labelAlignment_;
            set => SetProperty(ref labelAlignment_, value, nameof(LabelAlignment));
        }
        public HorizontalAlignment ValueAlignment
        {
            get => valueAlignment_;
            set => SetProperty(ref valueAlignment_, value, nameof(valueAlignment_));
        }
        #endregion
        public string LabelText
        {
            get => dataModel_.labels_[0];
            set => SetProperty(ref dataModel_.labels_[0], value, nameof(LabelText));
        }
        public string ValueText
        {
            get => dataModel_.values_[0];
            set => SetProperty(ref dataModel_.values_[0], value, nameof(ValueText));
        }
        public double ValueDouble
        {
            set => SetProperty(ref dataModel_.values_[0], dataModel_.formatDouble_[0](value), nameof(ValueText));
        }
        public long ValueLong
        {
            set => SetProperty(ref dataModel_.values_[0], dataModel_.formatLong_[0](value), nameof(ValueText));
        }
        public bool ValueBool
        {
            set => SetProperty(ref dataModel_.values_[0], dataModel_.formatBool_[0](value), nameof(ValueText));
        }
        public D2s FormatDouble
        {
            set => dataModel_.formatDouble_[0] = value;
        }
        public L2s FormatLong
        {
            set => dataModel_.formatLong_[0] = value;
        }
        public B2s FormatBool
        {
            set => dataModel_.formatBool_[0] = value;
        }
        public TristateControlState ControlState
        {
            get => dataModel_.controlState_;
            set
            {
                if (dataModel_.controlState_ != value)
                {
                    dataModel_.controlState_ = value;
                    OnPropertyChanged(nameof(BorderBrush));
                    OnPropertyChanged(nameof(LabelForegroundBrush));
                    OnPropertyChanged(nameof(LabelBackgroundBrush));
                    OnPropertyChanged(nameof(ValueForegroundBrush));
                    OnPropertyChanged(nameof(ValueBackgroundBrush));
                }
            }
        }
        #region data_model_properties

        #endregion
    }
}
