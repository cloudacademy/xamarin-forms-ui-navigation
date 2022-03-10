using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xaml_UI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StackLayoutView : ContentView
    {
        public StackLayoutView()
        {
            InitializeComponent();
        }

        private async void ReturnButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}