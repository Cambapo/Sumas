using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App3
{
	public partial class MainPage : ContentPage
    {
        private Context context;
        public int index;
        

        public MainPage()
        {
            MainProcess();

        }

        private void MainProcess()
        {
            initialise();

        }

        private void initialise()
        {
            //InitializeComponent();
            var layout = new StackLayout();
            var label = new Label { Text = "Name?" };
            var namefield = new Entry { Text = "" };

            Picker male = new Picker
            {
                Title = "Male",
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            male.Items.Add("3");
            male.Items.Add("5");
            male.Items.Add("10");

            this.Content = layout;
            layout.Children.Add(label);
            layout.Children.Add(namefield);
            layout.Children.Add(male);

            male.SelectedIndexChanged += (sender, args) =>
            {
                switch (male.SelectedIndex)
                {
                    case 0:
                        index = 3;
                        break;
                    case 1:
                        index = 5;
                        break;
                    case 2:
                        index = 10;
                        break;

                }
                /*if (male.SelectedIndex == 0)
                {
                    index = 3;
                }
                else
                {

                }
                index = male.SelectedIndex;*/
            };

            var button = new Xamarin.Forms.Button
            {
                Text = "Hallo, presiona el button, please.",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            button.Clicked += Button_Clicked;
            layout.Children.Add(button);
        }


        async private void Button_Clicked(object sender, EventArgs e)
        {
            Page1 pgn = new Page1(index);
            await Navigation.PushAsync(pgn);
        }


    }
}
