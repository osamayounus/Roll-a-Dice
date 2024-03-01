using System.Collections;
using System.Threading.Tasks;

namespace Roll_a_Die
{
    public partial class MainPage : ContentPage
    {
        Random num = new Random();
        int num_of_die = 6;
        int num_of_die2 = 6;
        bool theme = false;
        bool two_dice = false;
        public MainPage()
        {
            InitializeComponent();

            Application.Current.UserAppTheme = AppTheme.Dark;
            themebtn.ImageSource = "dark.png";
            num_of_dice.ImageSource = "dice2_red.png";
            img.Source = "dicew_" + num_of_die + ".png";
            theme = false;
        }

        private async void rollbtn_Clicked(object sender, EventArgs e)
        {
            if(two_dice)
            {
                img.Opacity = 0;
                img2.Opacity = 0;
                num_of_die = num.Next(1, 7);
                num_of_die2 = num.Next(1, 7);
            }
            else
            {
                img.Opacity = 0;
                img2.Opacity = 0;
                num_of_die = num.Next(1, 7);
                num_of_die2 = -1;
            }
            
            if (theme)
            {
                if (num_of_die2 != -1)
                {
                    img.Source = "dice_" + num_of_die + ".png";
                    img2.Source = "dice_" + num_of_die2 + ".png";
                }
                else
                {
                    img.Source = "dice_" + num_of_die + ".png";
                }
                
            }
            else
            {
                if (num_of_die2 != -1)
                {
                    img.Source = "dicew_" + num_of_die + ".png";
                    img2.Source = "dicew_" + num_of_die2 + ".png";
                }
                else
                {
                    img.Source = "dicew_" + num_of_die + ".png";
                }
            }
                
            img.FadeTo(1, 500);
            await img2.FadeTo(1, 500);
        }

        private void Themebtn_Clicked(object sender, EventArgs e)
        {
            
            if (!theme)
            {
                Application.Current.UserAppTheme = AppTheme.Light;
                themebtn.ImageSource = "day.png";
                img.Source = "dice_" + num_of_die + ".png";
                img2.Source = "dice_" + num_of_die2 + ".png";
                if(two_dice) { num_of_dice.ImageSource = "dice1_white.png";}
                else { num_of_dice.ImageSource = "dice2_white.png"; }
                theme = true;
            }
            else
            {
                Application.Current.UserAppTheme = AppTheme.Dark;
                themebtn.ImageSource = "dark.png";
                img.Source = "dicew_" + num_of_die + ".png";
                img2.Source = "dicew_" + num_of_die2 + ".png";
                if (two_dice) { num_of_dice.ImageSource = "dice1_red.png";}
                else { num_of_dice.ImageSource = "dice2_red.png"; }
                theme = false;
            }
        }


        private async void ExitBtn_Clicked(object sender, EventArgs e)
        {
            var R = await DisplayAlert("Exit", "Are you sure about that ?", "Yes", "No");

            if (R == true)
            {
                App.Current.Quit();
            }
        }

        private void num_of_dice_Clicked(object sender, EventArgs e)
        {
            if(num_of_dice.Text == "2 dices")
            {
                two_dice = true;
                num_of_dice.Text = "1 dice";
                if(theme)
                {
                    num_of_dice.ImageSource = "dice1_white.png";
                    img.Source = "dice_6.png";
                    img2.Source = "dice_6.png";
                }
                else
                {
                    num_of_dice.ImageSource = "dice1_red.png";
                    img.Source = "dicew_6.png";
                    img2.Source = "dicew_6.png";
                }
                img.MaximumHeightRequest = 130;
                img.MaximumWidthRequest = 130;
                img2.MaximumWidthRequest = 130;
                img2.MaximumHeightRequest = 130;
            }
            else
            {
                two_dice = false;
                num_of_dice.Text = "2 dices";
                if (theme)
                {
                    num_of_dice.ImageSource = "dice2_white.png";
                    img.Source = "dice_6.png";
                    img2.Source = null;
                }
                else
                {
                    num_of_dice.ImageSource = "dice2_red.png";
                    img.Source = "dicew_6.png";
                    img2.Source = "dicew_6.png";
                }
                img.MaximumHeightRequest = 260;
                img.MaximumWidthRequest = 260;
                img2.MaximumWidthRequest = 0;
                img2.MaximumHeightRequest = 0;
            }
        }
    }
}