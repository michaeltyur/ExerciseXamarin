using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ExerciseXamarin.Helpers
{
   public class CurrentDeviceInfo
    {
        public static string GetDeviceInfo()
        {
            string Title = string.Empty;

            if (Device.RuntimePlatform == Device.Android)
            {
                Title = "Android";
            }
            else if (Device.RuntimePlatform == Device.UWP)
            {
                Title = "Universal Windows";
            }

            if (Device.Idiom == TargetIdiom.Desktop)
            {
                Title += " Desktop Platform";
            }
            else if (Device.Idiom == TargetIdiom.Phone)
            {
                Title = " Phone Platform";
            }
            else if (Device.Idiom == TargetIdiom.Tablet)
            {
                Title = " Tablet Platform";
            }
          
            return Title;
        }
    }
}
