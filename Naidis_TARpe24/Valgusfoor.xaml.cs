using Microsoft.Maui.Controls.Shapes;

namespace Naidis_TARpe24;

public partial class Valgusfoor : ContentPage
{
    BoxView boxView;
    Ellipse pall;
    Ellipse pall2;
    Ellipse pall3;
    Polygon kolmnurk;
    Random rnd = new Random();
    HorizontalStackLayout hsl;
    List<string> nupud = new List<string>() { "Tˆˆle", "Avaleht", "V‰lja" };
    VerticalStackLayout vsl;
    bool on_off;
    bool on_off2;
    bool on_off3;
    public Valgusfoor()
    {
        bool on_off = false;
        bool on_off2 = false;
        bool on_off3 = false;

        //InitializeComponent();
        TapGestureRecognizer tap = new TapGestureRecognizer();
        TapGestureRecognizer tap2 = new TapGestureRecognizer();
        TapGestureRecognizer tap3 = new TapGestureRecognizer();
       
        
        tap.Tapped += (sender, e) =>
        {
            if (on_off==false)
            {
                pall.Fill = new SolidColorBrush(Colors.Red);
                on_off = true;
            }
            else if (on_off == true)
            {
                pall.Fill = new SolidColorBrush(Colors.Grey);
                on_off = false;
            }
        };
        tap2.Tapped += (sender, e) =>
        {
            if (on_off2 == false)
            {
                pall2.Fill = new SolidColorBrush(Colors.Yellow);
                on_off2 = true;
            }
            else if (on_off2 == true)
            {
                pall2.Fill = new SolidColorBrush(Colors.Grey);
                on_off2 = false;
            }
        };
        tap3.Tapped += (sender, e) =>
        {
            if (on_off3 == false)
            {
                pall3.Fill = new SolidColorBrush(Colors.Green);
                on_off3 = true;
            }
            else if (on_off3 == true)
            {
                pall3.Fill = new SolidColorBrush(Colors.Grey);
                on_off3 = false;
            }
        };


        pall = new Ellipse
        {
            WidthRequest = 200,
            HeightRequest = 200,
            Fill = new SolidColorBrush(Colors.Grey), //kujundi v‰rv brushi'i abil
            Stroke = Colors.Black,//‰‰rise v‰rv
            StrokeThickness = 5,//‰‰rise paksus
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center
        };
        pall.GestureRecognizers.Add(tap);

        pall2 = new Ellipse
        {
            WidthRequest = 200,
            HeightRequest = 200,
            Fill = new SolidColorBrush(Colors.Grey), //kujundi v‰rv brushi'i abil
            Stroke = Colors.Black,//‰‰rise v‰rv
            StrokeThickness = 5,//‰‰rise paksus
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center
        };
        pall2.GestureRecognizers.Add(tap2);

        pall3 = new Ellipse
        {
            WidthRequest = 200,
            HeightRequest = 200,
            Fill = new SolidColorBrush(Colors.Grey), //kujundi v‰rv brushi'i abil
            Stroke = Colors.Black,//‰‰rise v‰rv
            StrokeThickness = 5,//‰‰rise paksus
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center
        };
        pall3.GestureRecognizers.Add(tap3);

        vsl = new VerticalStackLayout
        {
            Padding = 20,
            Spacing = 15,
            Children = { pall, pall2, pall3, hsl },
            HorizontalOptions = LayoutOptions.Center
        };


        for (int j = 0; j < nupud.Count; j++)
        {
            Button nupp = new Button
            {
                Text = nupud[j],
                FontSize = 28,
                FontFamily = "Corleone 400",
                TextColor = Colors.Chocolate,
                BackgroundColor = Colors.Beige,
                CornerRadius = 10,
                HeightRequest = 50,
                ZIndex = j
            };
            vsl.Add(nupp);
           // nupp.Clicked += Liikumine;
        }


        
        Content = vsl;
    }

    //private void Liikumine(object? sender, EventArgs e)
    //{
    //    Button nupp = sender as Button;
    //    if (nupp.ZIndex == 0)
    //    {
    //        Navigation.PushAsync();
    //    }
    //    else if (nupp.ZIndex == 1)
    //    {
    //        Navigation.PushAsync(new StartPage());
    //    }
    //    else if (nupp.ZIndex == 2)
    //    {
    //        Navigation.PushAsync(); 
    //    }
    //}
}