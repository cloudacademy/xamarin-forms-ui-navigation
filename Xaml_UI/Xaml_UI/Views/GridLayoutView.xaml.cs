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
    public partial class GridLayoutView : ContentView
    {
        private bool portrait;
  
        public GridLayoutView()
        {
            InitializeComponent();
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (width > 0)
            {
                ReconfigureLayout(height > width);
            }
        }

        private void ReconfigureLayout(bool _portrait)
        {
            portrait = _portrait;
            double scaleFactor = 1;
            if (portrait)
            {
                if (LayoutGrid.ColumnDefinitions.Count == 4)
                {
                    LayoutGrid.Children.Remove(BottomRed);
                    LayoutGrid.Children.Remove(BottomYellow);
                    LayoutGrid.Children.Remove(BottomBlue);
                    LayoutGrid.ColumnDefinitions.Remove(LayoutGrid.ColumnDefinitions[3]);
                    LayoutGrid.Children.Add(BottomRed, 0, 3);
                    LayoutGrid.Children.Add(BottomYellow, 1, 3);
                    LayoutGrid.Children.Add(BottomBlue, 2, 3);
                    LayoutGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                    LayoutGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                    LayoutGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                    BottomRed.Margin = new Thickness(10, 10, 0, 0);
                    BottomYellow.Margin = new Thickness(0, 10, 0, 0);
                    BottomBlue.Margin = new Thickness(0, 10, 10, 0);
                }
            }
            else
            {
                scaleFactor = (this.Width / this.Height);
                if (LayoutGrid.ColumnDefinitions.Count == 3)
                {
                    LayoutGrid.RowDefinitions.Remove(LayoutGrid.RowDefinitions[6]);
                    LayoutGrid.RowDefinitions.Remove(LayoutGrid.RowDefinitions[5]);
                    LayoutGrid.RowDefinitions.Remove(LayoutGrid.RowDefinitions[4]);
                    LayoutGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                    LayoutGrid.Children.Remove(BottomRed);
                    LayoutGrid.Children.Remove(BottomYellow);
                    LayoutGrid.Children.Remove(BottomBlue);
                    LayoutGrid.Children.Add(BottomRed, 3, 0);
                    LayoutGrid.Children.Add(BottomYellow, 3, 1);
                    LayoutGrid.Children.Add(BottomBlue, 3, 2);
                    BottomRed.Margin = new Thickness(0, 10, 0, 10);
                    BottomYellow.Margin = new Thickness(0, 10, 10, 10);
                    BottomBlue.Margin = new Thickness(0, 0, 10, 0);

                }
            }
            LayoutGrid.RowDefinitions[0].Height = new GridLength(0.7 * scaleFactor, GridUnitType.Star);
            LayoutGrid.RowDefinitions[1].Height = new GridLength(0.9 * scaleFactor, GridUnitType.Star);
            LayoutGrid.RowDefinitions[2].Height = new GridLength(0.6 * scaleFactor, GridUnitType.Star);
            LayoutGrid.RowDefinitions[3].Height = new GridLength(0.6 * scaleFactor, GridUnitType.Star);
        }
    }
}