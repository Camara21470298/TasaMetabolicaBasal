using System;
using Microsoft.Maui.Controls;

namespace YourNamespace
{
    public partial class MainPage : ContentPage
    {
        public string selectedGender = string.Empty;

        public MainPage()
        {
            InitializeComponent();
        }

      
        public void OnGenderSelected(object sender, EventArgs e)
        {
            var button = sender as Button;
            selectedGender = button.CommandParameter.ToString();

            
            if (selectedGender == "Female")
            {
                button.BackgroundColor = Colors.Purple;
            }
            else if (selectedGender == "Male")
            {
                button.BackgroundColor = Colors.Blue;
            }
        }

        
        private void OnCalculateClicked(object sender, EventArgs e)
        {
            try
            {
                double weight = double.Parse(WeightEntry.Text);
                double height = double.Parse(HeightEntry.Text);
                int age = int.Parse(AgeEntry.Text);

               
                double bmr;
                if (selectedGender == "Female")
                {
                    bmr = 10 * weight + 6.25 * height - 5 * age - 161; 
                }
                else if (selectedGender == "Male")
                {
                    bmr = 10 * weight + 6.25 * height - 5 * age + 5;
                }
                else
                {
                    throw new Exception("Seleccione un género.");
                }

                ResultLabel.Text = $"{bmr:F2}";
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

     
        private void OnClearClicked(object sender, EventArgs e)
        {
            WeightEntry.Text = string.Empty;
            HeightEntry.Text = string.Empty;
            AgeEntry.Text = string.Empty;
            ResultLabel.Text = "0.00";
            selectedGender = string.Empty;
        }
    }
}
