using System.Windows;
using System.Windows.Media;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace WpfUserControlLib
{
    class PrettyButtonContext : ObservableObject, IPrettyButtonContext
    {
        #region private_backend_data
        ForegroundAndBackground seen_;
        ForegroundAndBackground[] colors_;
        SizeConfiguration sizeConf_;
        double heightPerWidth_;
        double widthPerHeight_;
        ButtonDataModel dataModel_;
        #endregion

        public PrettyButtonContext()
        {
            colors_ = new ForegroundAndBackground[3];
            colors_[(int)TristateControlState.normal] = new ForegroundAndBackground()
            {
                foreground_ = ColorHelper.NumberKeyForeground,
                background_ = ColorHelper.NumberKeyBackground
            };
            colors_[(int)TristateControlState.selected] = new ForegroundAndBackground()
            {
                foreground_ = ColorHelper.ToSelectedColor(colors_[(int)TristateControlState.normal].foreground_),
                background_ = ColorHelper.ToSelectedColor(colors_[(int)TristateControlState.normal].background_)
            };
            colors_[(int)TristateControlState.disabled] = new ForegroundAndBackground()
            {
                foreground_ = ColorHelper.ToDisabledColor(colors_[(int)TristateControlState.normal].foreground_),
                background_ = ColorHelper.ToDisabledColor(colors_[(int)TristateControlState.normal].background_)
            };
            seen_ = colors_[(int)TristateControlState.normal];
            sizeConf_ = new SizeConfiguration(HeightClass._10Lines, SizeConfiguration.HeightPerWidthVGA, SizeConfiguration.HeightVGA);
            widthPerHeight_ = heightPerWidth_ = 1.0;
            dataModel_ = new ButtonDataModel()
            {
                caption_ = "1",
                code_ = 0x31,
                state_ = TristateControlState.normal
            };
        }

        #region color_proerpties
        public SolidColorBrush ForegroundBrush 
        { 
            get => new SolidColorBrush(seen_.foreground_);
            set
            {
                colors_[(int)TristateControlState.normal].foreground_ = value.Color;
                colors_[(int)TristateControlState.selected].foreground_ = ColorHelper.Dimmer(value.Color);
                colors_[(int)TristateControlState.disabled].foreground_ = ColorHelper.Grayed(value.Color);
                seen_ = colors_[(int)ControlState];
                OnPropertyChanged(nameof(ForegroundBrush));
            }
        }
        public SolidColorBrush BackgroundBrush 
        {
            get => new SolidColorBrush(seen_.background_);
            set
            {
                colors_[(int)TristateControlState.normal].background_ = value.Color;
                colors_[(int)TristateControlState.selected].background_ = ColorHelper.Dimmer(value.Color);
                colors_[(int)TristateControlState.disabled].background_ = ColorHelper.Grayed(value.Color);
                seen_ = colors_[(int)ControlState];
                OnPropertyChanged(nameof(BackgroundBrush));
            }
        }
        #endregion

        #region dimensional_properties
        private void OnAllDimensionsChanged()
        {
            OnPropertyChanged(nameof(Height));
            OnPropertyChanged(nameof(Width));
            OnPropertyChanged(nameof(FontSize));
        }
        public double WindowHeight
        {
            set
            {
                sizeConf_.WindowHeight = value;
                OnAllDimensionsChanged();
            }
        }

        public HeightClass HeightClass
        {
            set
            {
                sizeConf_.HeightClass = value;
                OnAllDimensionsChanged();
            }
        }
        public double Height 
        {
            get => sizeConf_.LineHeight;
        }
        public double Width 
        {
            get => Height * widthPerHeight_;
        }
        public double FontSize
        {
            get => sizeConf_.FontSize;
        }
        public CornerRadius CornerRadius
        {
            get
            {
                double eachCornerRadius = sizeConf_.CornerRadius;
                return new CornerRadius(eachCornerRadius, eachCornerRadius, eachCornerRadius, eachCornerRadius);
            }
        }
        public double WidthPerHeight
        {
            get => widthPerHeight_;
            set
            {
                widthPerHeight_ = value;
                heightPerWidth_ = 1.0 / value;
                OnPropertyChanged(nameof(Width));
            }
        }
        #endregion

        #region data_model_properties
        public string Caption 
        {
            get => dataModel_.caption_;
            set => SetProperty(ref dataModel_.caption_, value, nameof(Caption));
        }
        public int ButtonKeyCode 
        {
            get => dataModel_.code_;
            set => SetProperty(ref dataModel_.code_, value, nameof(ButtonKeyCode));
        }

        void NotifyStateChange()
        {
            OnPropertyChanged(nameof(ControlState));
            OnPropertyChanged(nameof(ForegroundBrush));
            OnPropertyChanged(nameof(BackgroundBrush));
        }
        public TristateControlState ControlState 
        {
            get => dataModel_.state_;
            set
            {
                if (ControlState != value)
                {
                    dataModel_.state_ = value;
                    seen_ = colors_[(int)value];
                    NotifyStateChange(); // notify lister object of state change and color changes.
                }
            }
        }
        #endregion
    }
}
