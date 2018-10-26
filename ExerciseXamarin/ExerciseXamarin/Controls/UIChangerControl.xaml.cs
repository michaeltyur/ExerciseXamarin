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
                                     typeof(int),
                                     typeof(UIChangerControl),
                                     default(int),
                                     BindingMode.TwoWay);
        public int SliderValueTextColor
        {
            get
            {
                return (int)GetValue(SliderValueTextColorProperty);
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
                                   typeof(int),
                                   typeof(UIChangerControl),
                                   default(int),
                                   BindingMode.TwoWay);
        public int SliderValueBackColor
        {
            get
            {
                return (int)GetValue(SliderValueBackColorProperty);
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
            textColorSlider.ValueChanged += TextColorSlider_ValueChanged;                   
            backColorSlider.ValueChanged += BackColorSlider_ValueChanged;
        }

        private void TextColorSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            SliderValueTextColor = (int)textColorSlider.Value;
        }

        private void BackColorSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            SliderValueBackColor = (int)backColorSlider.Value;
        }

        private void TextEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextEntry = textEntry.Text;
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            //Labels
            if (propertyName == TextEntryLabelProperty.PropertyName)
            {
                textEntryLabel.Text = TextEntryLabel;
            }
            if (propertyName == BackColorSliderLabelProperty.PropertyName)
            {
                backColorSliderLabel.Text = BackColorSliderLabel;
            }
            if (propertyName == TextColorSliderLabelProperty.PropertyName)
            {
                textColorSliderLabel.Text = TextColorSliderLabel;
            }

            if (propertyName == TextEntryProperty.PropertyName)
            {
                textEntry.Text = TextEntry;
            }
            if (propertyName == SliderValueTextColorProperty.PropertyName)
            {
                textColorSlider.Value = SliderValueTextColor;
            }
            if (propertyName == SliderValueBackColorProperty.PropertyName)
            {
                backColorSlider.Value = SliderValueBackColor;
            }
        }
    }
    
}