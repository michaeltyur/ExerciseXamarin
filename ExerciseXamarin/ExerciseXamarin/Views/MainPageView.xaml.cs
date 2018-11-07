using ExerciseXamarin.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExerciseXamarin.Views
{
    public partial class MainPageView : ContentPage,IPage
    {
        public MainPageView()
        {
            InitializeComponent();
        }

        private void Grid_SizeChanged(object sender, EventArgs e)
        {
            GridSection.ColumnDefinitions = new ColumnDefinition();
            if (GridSection.Width<600)
            {
                HttpClientStack.Grid.Column
            }
        }
    }
 
}
