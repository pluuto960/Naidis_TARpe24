namespace Naidis_TARpe24;

public partial class KorrutusTest : ContentPage
{
    Label lbl;
	public KorrutusTest()
    {
		//? Korrutustabeli test
        //Esita kasutajale suvaline korrutustehe(DisplayPrompt) ja kontrolli vastust.

        lbl = new Label
        {
            FontSize = 36,
            FontFamily = "Corleone 400",
            TextColor = Colors.Black,
            Text = "Siin lehel saad testida oma teadmisi korrutustabeli testiga",
            HorizontalOptions = LayoutOptions.Center
        };
        Button startButton = new Button
        {
            Text = "Alusta testi",
            VerticalOptions = LayoutOptions.Start,
            HorizontalOptions = LayoutOptions.Center
        };
        startButton.Clicked += StartButton_Clicked;

        Content = new VerticalStackLayout
        {
            Spacing = 20, //Jätab nuppude vahele 20 pikslit vaba ruumi
            Padding = new Thickness(0, 50, 0, 0), //Lükkab sisu veidi ülevalt alla
            Children = { startButton }
        };

    }
}