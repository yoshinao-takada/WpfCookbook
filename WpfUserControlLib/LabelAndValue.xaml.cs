using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfUserControlLib
{
    /// <summary>
    /// Interaction logic for LabelAndValue.xaml
    /// </summary>
    public partial class LabelAndValue : UserControl, ILabelAndValue
    {
        public LabelAndValue()
        {
            InitializeComponent();
        }

        #region settable_properties
        #region Color_properties
        public SolidColorBrush LabelAndDataBorderBrush
        {
            set => ((ILabelAndValueContext)DataContext).BorderBrush = value;
        }
        public SolidColorBrush LabelForegroundBrush
        {
            set => ((ILabelAndValueContext)DataContext).LabelForegroundBrush = value;
        }
        public SolidColorBrush LabelBackgroundBrush
        {
            set => ((ILabelAndValueContext)DataContext).LabelBackgroundBrush = value;
        }
        public SolidColorBrush ValueForegroundBrush
        {
            set => ((ILabelAndValueContext)DataContext).ValueForegroundBrush = value;
        }
        public SolidColorBrush ValueBackgroundBrush
        {
            set => ((ILabelAndValueContext)DataContext).ValueBackgroundBrush = value;
        }
        #endregion

        #region geometrical_properties
        public double WindowHeight
        {
            set => (DataContext as ILabelAndValueContext).WindowHeight = value;
        }

        /// <summary>
        /// (Label width + Value width) / (Line height)
        /// </summary>
        public double WidthPerLineHeight
        {
            set => (DataContext as ILabelAndValueContext).WidthPerLineHeight = value;
        }
        public double LabelWidthPerWholeWidth
        {
            set => (DataContext as ILabelAndValueContext).LabelWidthPerWholeWidth = value;
        }
        public HeightClass HeightClass
        {
            set => (DataContext as ILabelAndValueContext).HeightClass = value;
        }
        public bool IsBoldBorder
        {
            set => (DataContext as ILabelAndValueContext).IsBoldBorder = value;
        }
        public HorizontalAlignment LabelAlignment
        {
            set => (DataContext as ILabelAndValueContext).LabelAlignment = value;
        }
        public HorizontalAlignment ValueAlignment
        {
            set => (DataContext as ILabelAndValueContext).ValueAlignment = value;
        }
        #endregion

        #region data_model_properties
        public string LabelText
        {
            set => (DataContext as ILabelAndValueContext).LabelText = value;
        }
        public string ValueText 
        {
            set => (DataContext as ILabelAndValueContext).ValueText = value;
        }
        public double ValueDouble
        {
            set => (DataContext as ILabelAndValueContext).ValueDouble = value;
        }
        public long ValueLong
        {
            set => (DataContext as ILabelAndValueContext).ValueLong = value;
        }
        public bool ValueBool
        {
            set => (DataContext as ILabelAndValueContext).ValueBool = value;
        }
        public D2s FormatDouble
        {
            set => (DataContext as ILabelAndValueContext).FormatDouble = value;
        }
        public L2s FormatLong
        {
            set => (DataContext as ILabelAndValueContext).FormatLong = value;
        }
        public B2s FormatBool
        {
            set => (DataContext as ILabelAndValueContext).FormatBool = value;
        }
        /// <summary>
        /// normal and selected are the same condition. Only disabled is different.
        /// </summary>
        public TristateControlState ControlState
        {
            set => (DataContext as ILabelAndValueContext).ControlState = value;
        }
        #endregion
        #endregion
    }
}
