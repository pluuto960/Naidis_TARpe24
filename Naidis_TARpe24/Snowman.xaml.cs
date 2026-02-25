using Microsoft.Maui.Controls.Shapes;

namespace Naidis_TARpe24;

public partial class Snowman : ContentPage
{
	Label lbl;
	VerticalStackLayout vsl;
    int snowmancolor=211;
    Picker picker;
	BoxView amber;
	Ellipse keha;
    Ellipse keha2;
    Ellipse pea;
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
            Fill = new SolidColorBrush(Color.FromRgb(snowmancolor, snowmancolor, snowmancolor)), //kujundi v‰rv brushi'i abil
            Stroke = Colors.Grey,//‰‰rise v‰rv
            StrokeThickness = 5,//‰‰rise paksus
            HorizontalOptions = LayoutOptions.Center
        };
        keha = new Ellipse
        {
            WidthRequest = 120,
            HeightRequest = 120,
            Fill = new SolidColorBrush(Color.FromRgb(snowmancolor, snowmancolor, snowmancolor)), //kujundi v‰rv brushi'i abil
            Stroke = Colors.Grey,//‰‰rise v‰rv
            StrokeThickness = 5,//‰‰rise paksus
            HorizontalOptions = LayoutOptions.Center
        };
        keha2 = new Ellipse
        {
            WidthRequest = 150,
            HeightRequest = 150,
            Fill = new SolidColorBrush(Color.FromRgb(snowmancolor, snowmancolor, snowmancolor)),
            Stroke = Colors.Grey,//‰‰rise v‰rv
            StrokeThickness = 5,//‰‰rise paksus
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

        var kasuList = new List<string>();
        kasuList.Add("Peida lumememm");
        kasuList.Add("N‰ita lumememme");
        kasuList.Add("Muuda lumememme v‰rvi");
        kasuList.Add("Sulata memme");
        kasuList.Add("Tantsi");

        picker = new Picker
        {
            Title = "Tegevused",
            HorizontalOptions = LayoutOptions.Center
        };
        picker.ItemsSource = kasuList;



        vsl = new VerticalStackLayout
        {
            Padding = 20,
            //Spacing = 15,
            Children = { lbl, pea,keha,keha2, amber, picker },
            HorizontalOptions = LayoutOptions.Center
        };
        Content = vsl;
    }
}