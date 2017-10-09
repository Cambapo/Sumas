using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page1 : ContentPage
	{
        private int index;
        private MainPage mnpg;
        private int score = 0;
        private int result;
        private int it = 1;
        private int answer;
        Entry antwort = new Entry { };


        public Page1 (int index)
		{
            this.index = index;
            Console.WriteLine(index + ""+ it);
			InitializeComponent ();
            game();
		}

        async private void game()
        {
            if (index == 0)
            {
                await DisplayAlert("Alert", "Tell me how many times or I won't budge >:(", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                Random rand1 = new Random();

                var label = new Label { Text = it.ToString() + " de " + index.ToString() };

                String expo;

                int frst = rand1.Next(100);
                int scnd = rand1.Next(100);
                int exp = rand1.Next(1);

                var layout = new StackLayout();
                this.Content = layout;
                //var label = new Label { Text = "Ich habe das Fernseher wechseln!" };

                if (exp == 0)
                {
                    expo = "+";
                    answer = frst + scnd;
                }
                else
                {
                    expo = "-";
                    answer = frst - scnd;
                }

                var operation = new Label { Text = frst.ToString() + expo + scnd.ToString() };

                var button = new Xamarin.Forms.Button
                {
                    Text = "Check",
                    VerticalOptions = LayoutOptions.Start,
                    HorizontalOptions = LayoutOptions.FillAndExpand
                };
                button.Clicked += Calculate;

                var backbttn = new Xamarin.Forms.Button
                {
                    Text = "Back again",
                    VerticalOptions = LayoutOptions.Start,
                    HorizontalOptions = LayoutOptions.FillAndExpand
                };
                backbttn.Clicked += Bttn;

                layout.Children.Add(label);
                layout.Children.Add(operation);
                layout.Children.Add(antwort);
                layout.Children.Add(button);
                layout.Children.Add(backbttn);

            }
        }

        async private void Calculate(object sender, EventArgs e)
        {
            if (it < index+1)
            {
                if (Convert.ToInt32(antwort.Text) == answer)
                {
                    score = score + 1;
                }
                antwort.Text = "";
                it = it + 1;
                game();
            }
            else
            {
                await DisplayAlert("Game over", score.ToString() + " correct over " + index.ToString(), "OK");
                score = 0;
                it = 1;
                await Navigation.PopAsync();
            }
        }

        async private void Bttn(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}