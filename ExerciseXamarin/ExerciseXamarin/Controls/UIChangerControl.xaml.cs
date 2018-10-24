using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExerciseXamarin.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UIChangerControl : ContentView
    {


        #region Text Entry Label
        public static readonly BindableProperty TextEntryLabelProperty =
                                     BindableProperty.Create(nameof(TextEntryLabel),
                                                             typeof(string),
                                                             typeof(UIChangerControl),
                                                             default(string),
                                                             BindingMode.TwoWay);
        public string TextEntryLabel
        {
            get
            {
                return (string)GetValue(TextEntryLabelProperty);
            }
            set
            {
                SetValue(TextEntryLabelProperty, value);
            }
        }
        #endregion

        #region Text Entry
        public static readonly BindableProperty TextEntryProperty =
                             BindableProperty.Create(nameof(TextEntry),
                                                     typeof(string),
                                                     typeof(UIChangerControl),
                                                     default(string),
                                                     BindingMode.TwoWay);
        public string TextEntry
        {
            get
            {
                return (string)GetValue(TextEntryProperty);
            }
            set
            {
                SetValue(TextEntryProperty, value);
                OnPropertyChanged();
            }
        }
        #endregion

        #region Text Color Slider Label
        public static readonly BindableProperty TextColorSliderLabelProperty =
                     BindableProperty.Create(nameof(TextColorSliderLabel),
                                             typeof(string),
                                             typeof(UIChangerControl),
                                             default(string),
                                             BindingMode.TwoWay);
        public string TextColorSliderLabel
        {
            get
            {
                return (string)GetValue(TextColorSliderLabelProperty);
            }
            set
            {
                SetValue(TextColorSliderLabelProperty, value);
                OnPropertyChanged();
            }
        }
        #endregion

        #region Slider Value Text Color
        public static readonly BindableProperty SliderValueTextColorProperty =
             BindableProperty.Create(nameof(SliderValueTextColor),
                                     typeof(double),
                                     typeof(UIChangerControl),
                                     default(double),
                                     BindingMode.TwoWay);
        public double SliderValueTextColor
        {
            get
            {
                return (double)GetValue(SliderValueTextColorProperty);
            }
            set
            {
                SetValue(SliderValueTextColorProperty, value);
                OnPropertyChanged();
            }
        }
        #endregion

        #region Back Color Slider Label
        public static readonly BindableProperty BackColorSliderLabelProperty =
             BindableProperty.Create(nameof(BackColorSliderLabel),
                                     typeof(string),
                                     typeof(UIChangerControl),
                                     default(string),
                                     BindingMode.TwoWay);
        public string BackColorSliderLabel
        {
            get
            {
                return (string)GetValue(BackColorSliderLabelProperty);
            }
            set
            {
                SetValue(BackColorSliderLabelProperty, value);
                OnPropertyChanged();
            }
        }
        #endregion

        #region Slider Value BackColor
        public static readonly BindableProperty SliderValueBackColorProperty =
           BindableProperty.Create(nameof(SliderValueBackColor),
                                   typeof(double),
                                   typeof(UIChangerControl),
                                   default(double),
                                   BindingMode.TwoWay);
        public double SliderValueBackColor
        {
            get
            {
                return (double)GetValue(SliderValueBackColorProperty);
            }
            set
            {
                SetValue(SliderValueBackColorProperty, value);
                OnPropertyChanged();
            }
        }
        #endregion

        public UIChangerControl()
        {
            InitializeComponent();
            textEntry.TextChanged += TextEntry_TextChanged;
        }

        private void TextEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextEntry = textEntry.Text;
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == TextEntryLabelProperty.PropertyName)
            {
                textEntryLabel.Text = TextEntryLabel;
            }
            if (propertyName == TextEntryProperty.PropertyName)
            {
                textEntry.Text = TextEntry;
            }
            if (propertyName == TextColorSliderLabelProperty.PropertyName)
            {
                textColorSliderLabel.Text = TextColorSliderLabel;
            }
            if (propertyName == SliderValueTextColorProperty.PropertyName)
            {
                textColorSlider.Value = SliderValueTextColor;
            }
            if (propertyName == BackColorSliderLabelProperty.PropertyName)
            {
                backColorSliderLabel.Text = BackColorSliderLabel;
            }
            if (propertyName == SliderValueBackColorProperty.PropertyName)
            {
                backColorSlider.Value = SliderValueBackColor;
            }
        }
    }
    
}