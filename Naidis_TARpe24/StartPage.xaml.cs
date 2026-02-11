

namespace Naidis_TARpe24;

public partial class StartPage : ContentPage
{
    public List<ContentPage> Lehed = new List<ContentPage>() { new TextPage(), new FigurePage(), new Timer_Page(), new Valgusfoor() };
    public List<string> LeheNimed = new List<string> { "Tekst", "Kujund", "Timer", "Valgusfoor" };

    ScrollView sv;
    VerticalStackLayout vst;
	public StartPage()
	{
        //InitializeComponent();
        //Title = "Avaleht";
        vst = new VerticalStackLayout { Padding=20, Spacing=15 };
        for (int i = 0; i < Lehed.Count; i++)
        {
            Button nupp = new Button
            {
                Text = LeheNimed[i],
                BackgroundColor = Colors.MintCream,
                TextColor = Colors.Black,
                FontSize=36,
                FontFamily = "Corleone 400",
                CornerRadius = 10,
                ZIndex=i,
                HeightRequest=60
            };
            vst.Add(nupp);
            nupp.Clicked += (sender, e) =>
            {
                var valik = Lehed[nupp.ZIndex];
                Navigation.PushAsync(valik);
            };
        }
        sv = new ScrollView { Content = vst };
        Content = sv;
    }
}