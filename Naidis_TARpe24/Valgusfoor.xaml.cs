using Microsoft.Maui.Controls.Shapes;

namespace Naidis_TARpe24;

public partial class Valgusfoor : ContentPage
{
    Ellipse punane;
    Ellipse kollane;
    Ellipse roheline;

    bool punaneSees = false;
    bool kollaneSees = false;
    bool rohelineSees = false;

    public Valgusfoor()
    {
        // ===== PUNANE =====
        punane = new Ellipse
        {
            WidthRequest = 200,
            HeightRequest = 200,
            Fill = new SolidColorBrush(Colors.Grey),
            Stroke = Colors.Black,
            StrokeThickness = 5,
            HorizontalOptions = LayoutOptions.Center
        };

        TapGestureRecognizer tap1 = new TapGestureRecognizer();
        tap1.Tapped += (s, e) =>
        {
            punaneSees = !punaneSees;
            punane.Fill = new SolidColorBrush(punaneSees ? Colors.Red : Colors.Grey);
        };
        punane.GestureRecognizers.Add(tap1);

        // ===== KOLLANE =====
        kollane = new Ellipse
        {
            WidthRequest = 200,
            HeightRequest = 200,
            Fill = new SolidColorBrush(Colors.Grey),
            Stroke = Colors.Black,
            StrokeThickness = 5,
            HorizontalOptions = LayoutOptions.Center
        };

        TapGestureRecognizer tap2 = new TapGestureRecognizer();
        tap2.Tapped += (s, e) =>
        {
            kollaneSees = !kollaneSees;
            kollane.Fill = new SolidColorBrush(kollaneSees ? Colors.Yellow : Colors.Grey);
        };
        kollane.GestureRecognizers.Add(tap2);

        // ===== ROHELINE =====
        roheline = new Ellipse
        {
            WidthRequest = 200,
            HeightRequest = 200,
            Fill = new SolidColorBrush(Colors.Grey),
            Stroke = Colors.Black,
            StrokeThickness = 5,
            HorizontalOptions = LayoutOptions.Center
        };

        TapGestureRecognizer tap3 = new TapGestureRecognizer();
        tap3.Tapped += (s, e) =>
        {
            rohelineSees = !rohelineSees;
            roheline.Fill = new SolidColorBrush(rohelineSees ? Colors.Green : Colors.Grey);
        };
        roheline.GestureRecognizers.Add(tap3);

        // ===== NUPUD =====
        Button btnKoikToole = new Button
        {
            Text = "Kõik tööle",
            FontSize = 22,
            BackgroundColor = Colors.LightGreen
        };
        btnKoikToole.Clicked += (s, e) => KoikToole();

        Button btnAvaleht = new Button
        {
            Text = "Avaleht",
            FontSize = 22,
            BackgroundColor = Colors.LightBlue
        };
        btnAvaleht.Clicked += async (s, e) =>
        {
            await Navigation.PushAsync(new StartPage());
        };

        Button btnKoikValja = new Button
        {
            Text = "Kõik välja",
            FontSize = 22,
            BackgroundColor = Colors.IndianRed
        };
        btnKoikValja.Clicked += (s, e) => KoikValja();

        Button btnAutomaat = new Button
        {
            Text = "Automaat reziim",
            FontSize = 22,
            BackgroundColor = Colors.Blue
        };
        btnAutomaat.Clicked += (s, e) => Automaat();

        // ===== LAYOUT =====
        VerticalStackLayout layout = new VerticalStackLayout
        {
            Padding = 20,
            Spacing = 20,
            HorizontalOptions = LayoutOptions.Center,
            Children =
            {
                punane,
                kollane,
                roheline,
                btnKoikToole,
                btnAvaleht,
                btnKoikValja,
                btnAutomaat
            }
        };

        ScrollView scroll = new ScrollView
        {
            Content = layout
        };

        Content = scroll;
    }

    private void KoikToole()
    {
        punane.Fill = new SolidColorBrush(Colors.Red);
        kollane.Fill = new SolidColorBrush(Colors.Yellow);
        roheline.Fill = new SolidColorBrush(Colors.Green);

        punaneSees = true;
        kollaneSees = true;
        rohelineSees = true;
    }

    private void KoikValja()
    {
        punane.Fill = new SolidColorBrush(Colors.Grey);
        kollane.Fill = new SolidColorBrush(Colors.Grey);
        roheline.Fill = new SolidColorBrush(Colors.Grey);

        punaneSees = false;
        kollaneSees = false;
        rohelineSees = false;
    }
    private async void Automaat()
    {
        punane.Fill = new SolidColorBrush(Colors.Red);
        punaneSees = true;
        await Task.Delay(2000);
        punane.Fill = new SolidColorBrush(Colors.Grey);
        punaneSees = false;
        await Task.Delay(500);

        kollane.Fill = new SolidColorBrush(Colors.Yellow);
        kollaneSees = true;
        await Task.Delay(2000);
        kollane.Fill = new SolidColorBrush(Colors.Grey);
        kollaneSees = false;
        await Task.Delay(500);

        roheline.Fill = new SolidColorBrush(Colors.Green);
        rohelineSees = true;
        await Task.Delay(2000);
        roheline.Fill = new SolidColorBrush(Colors.Grey);
        rohelineSees = false;
        await Task.Delay(500);



    }
}
