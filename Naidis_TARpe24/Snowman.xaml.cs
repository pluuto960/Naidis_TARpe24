using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Dispatching;

namespace Naidis_TARpe24;

public partial class Snowman : ContentPage
{
	Label lbl;
	VerticalStackLayout vsl;
    double opacityValue = 1.0;
    int snowmancolor=211;
    Picker picker;
	BoxView amber;
	Ellipse keha;
    Ellipse keha2;
    Ellipse pea;
    Slider sl;
	public Snowman()
	{
		lbl = new Label
		{
			FontSize = 36,
			FontFamily = "Corleone 400",
			TextColor = Colors.Black,
			Text = "Lumememm",
			HorizontalOptions = LayoutOptions.Center
		};
		//=======Keha joonis========
		pea = new Ellipse
		{
            WidthRequest = 75,
            HeightRequest = 75,
            Fill = new SolidColorBrush(Color.FromRgb(snowmancolor, snowmancolor, snowmancolor)), //kujundi värv brushi'i abil
            Stroke = Colors.Grey,//äärise värv
            StrokeThickness = 5,//äärise paksus
            HorizontalOptions = LayoutOptions.Center
        };
        keha = new Ellipse
        {
            WidthRequest = 120,
            HeightRequest = 120,
            Fill = new SolidColorBrush(Color.FromRgb(snowmancolor, snowmancolor, snowmancolor)), //kujundi värv brushi'i abil
            Stroke = Colors.Grey,//äärise värv
            StrokeThickness = 5,//äärise paksus
            HorizontalOptions = LayoutOptions.Center
        };
        keha2 = new Ellipse
        {
            WidthRequest = 150,
            HeightRequest = 150,
            Fill = new SolidColorBrush(Color.FromRgb(snowmancolor, snowmancolor, snowmancolor)),
            Stroke = Colors.Grey,//äärise värv
            StrokeThickness = 5,//äärise paksus
            HorizontalOptions = LayoutOptions.Center
        };
        amber = new BoxView
        {
            WidthRequest=50,
            HeightRequest=50,
            Color=Colors.DarkRed,
            BackgroundColor=Colors.Red,
            HorizontalOptions = LayoutOptions.Center
        };
        sl = new Slider
        {
            Minimum = 0,
            Maximum = 255,
            Value = 0,
            WidthRequest = 300,
            HorizontalOptions = LayoutOptions.Center,
            MinimumTrackColor = Color.FromRgb(0, 0, 0),
            MaximumTrackColor = Color.FromRgb(0, 0, 254),
            ThumbColor = Color.FromRgb(155, 155, 155),
        };
        sl.ValueChanged += Sl_ValueChanged;

        Button btnSlider = new Button
        {
            Text = "Slideri eemaldamine",
            FontSize = 22,
            BackgroundColor = Colors.LightBlue,
            HorizontalOptions = LayoutOptions.Center
        };
        btnSlider.Clicked += async (s, e) =>
        {
            vsl.Remove(sl);
            vsl.Remove(btnSlider);
        };


        var kasuList = new List<string>();
        kasuList.Add("Peida lumememm");
        kasuList.Add("Näita lumememme");
        kasuList.Add("Muuda lumememme värvi");
        kasuList.Add("Sulata memme");
        kasuList.Add("Tantsi");

        picker = new Picker
        {
            Title = "Tegevused",
            HorizontalOptions = LayoutOptions.Center
        };
        picker.ItemsSource = kasuList;
        picker.SelectedIndexChanged += (sender, e) =>
        {
            switch (picker.SelectedIndex)
            {
                case 0:
                    snowmancolor = 252;
                    keha.Opacity = 0;
                    keha2.Opacity = 0;
                    pea.Opacity = 0;
                    amber.Opacity = 0;
                    break;
                case 1:
                    snowmancolor = 211;
                    keha.Opacity = 1;
                    keha2.Opacity = 1;
                    pea.Opacity = 1;
                    amber.Opacity = 1;
                    break;
                case 2:
                    vsl.Add(sl);
                    vsl.Add(btnSlider);
                    break;
                case 3:
                    FadeSnowman();
                    break;
                case 4:
                    DanceSnowman();
                    break;
            }
        };



        vsl = new VerticalStackLayout
        {
            Padding = 20,
            //Spacing = 15,
            Children = { lbl, pea,keha,keha2, amber, picker },
            HorizontalOptions = LayoutOptions.Center
        };
        Content = vsl;
    }
    private void Sl_ValueChanged(object? sender, ValueChangedEventArgs e)
    {
        snowmancolor = (int)sl.Value;

        var newColor = Color.FromRgb(snowmancolor, snowmancolor, snowmancolor);

        pea.Fill = new SolidColorBrush(newColor);
        keha.Fill = new SolidColorBrush(newColor);
        keha2.Fill = new SolidColorBrush(newColor);

    }
    private async Task FadeSnowman()
    {
        await Task.WhenAll(
            keha.FadeTo(0, 2000),
            keha2.FadeTo(0, 2000),
            pea.FadeTo(0, 2000),
            amber.FadeTo(0, 2000)
        );
    }
    private async Task DanceSnowman()
    {
        for (int i = 0; i < 4; i++)
        {
            // tilt right + jump
            await Task.WhenAll(
                keha.RotateTo(15, 200),
                keha2.RotateTo(15, 200),
                pea.RotateTo(15, 200),
                amber.RotateTo(15, 200),

                keha.TranslateTo(0, -20, 200),
                keha2.TranslateTo(0, -20, 200),
                pea.TranslateTo(0, -20, 200),
                amber.TranslateTo(0, -20, 200)
            );

            // tilt left + down
            await Task.WhenAll(
                keha.RotateTo(-15, 200),
                keha2.RotateTo(-15, 200),
                pea.RotateTo(-15, 200),
                amber.RotateTo(-15, 200),

                keha.TranslateTo(0, 0, 200),
                keha2.TranslateTo(0, 0, 200),
                pea.TranslateTo(0, 0, 200),
                amber.TranslateTo(0, 0, 200)
            );
        }

        // reset rotation cleanly
        await Task.WhenAll(
            keha.RotateTo(0, 150),
            keha2.RotateTo(0, 150),
            pea.RotateTo(0, 150),
            amber.RotateTo(0, 150)
        );
    }
}