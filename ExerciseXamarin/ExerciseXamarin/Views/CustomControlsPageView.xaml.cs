using ExerciseXamarin.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExerciseXamarin.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CustomControlsPageView : ContentPage, IPage
	{
		public CustomControlsPageView()
		{
			InitializeComponent ();
		}
	}
}