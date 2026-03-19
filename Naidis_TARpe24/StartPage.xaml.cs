

namespace Naidis_TARpe24;

public partial class StartPage : ContentPage
{
    public List<ContentPage> Lehed = new List<ContentPage>() { new TextPage(),
                                                                new FigurePage(),
                                                                new Timer_Page(),
                                                                new Valgusfoor(),
                                                                new DateTime_Page(),
                                                                new StepperSliderPage(),
                                                                new VarviPage(),
                                                                new Snowman(),
                                                                new Pop_Up_Page(),
                                                                new KorrutusTest(),
                                                                new PickerImagePage(),
                                                                new Tic_tac_toe(),
                                                                new Table_Page(),
                                                                new s6pradeKontaktandmed(),


                                                                };
    public List<string> LeheNimed = new List<string> { "Tekst", 
                                                        "Kujund", 
                                                        "Timer", 
                                                        "Valgusfoor", 
                                                        "Aeg/Kuupäev", 
                                                        "Liigur" , 
                                                        "Värvi Slider", 
                                                        "Lumememm", 
                                                        "Popup Page", 
                                                        "Korrutustabeli Test", 
                                                        "PickerImagePage",
                                                        "Trips-Traps-Trull",
                                                        "Table_Page",
                                                        "Kontaktiraamat",


                                                        };

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
        //Loome punase testnupu
        Button nulliNupp = new Button
        {
            Text="Nulli seaded (Testimiseks)",
            BackgroundColor=Colors.Red,
            TextColor=Colors.White,
            CornerRadius=10,
            HeightRequest=50,
            Margin=new Thickness(0,30,0,0) //Jätame veidi tühja ruumi üles
        };
        //Mis juhtub nupule vajutades?
        nulliNupp.Clicked += async (sender, e) =>
        {
            //Kustutame seadme mälust meie spetsiifilise võtme
            Preferences.Default.Remove("EsimeneKäivitamine");

            //Anname tagasisidet, et nullimine õnnestus
            await DisplayAlertAsync("Edukalt nullitud", "Mälu on tühjendatud. Kui sa lehe uuesti avad, käitub äpp nagu täiesti uus!", "OK");
        };
        vst.Add(nulliNupp);
        sv = new ScrollView { Content = vst };
        Content = sv;

    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // 1. Loeme seadme mälust muutuja "EsimeneKäivitamine".
        //Kui sellist muutujat pole (äpp on uus), annab see vaikimist väärtuseks 'true'.
        bool onEsimeneStart = Preferences.Default.Get("EsimeneKäivitamine", true);

        // 2. Kui on esimene start, kuvame dialoogiakna
        if (onEsimeneStart)
        {
            bool vastus = await DisplayAlertAsync("Tere tulemast!",
                                                "Tundub, et avasid selle rakenduse esimest korda. Kas soovid näha lühikest juhendit?",
                                                "Jah, palun",
                                                "Ei, saan ise hakkama");
            if (vastus)
            {
                await DisplayAlertAsync("Juhend", "Siin on sinu lühike juhend: vali menüüst sobiv teema ja uuri, kuidas elemendid töötavad!", "Selge");
            }
            //3. Salvestame info, et esimene käivitamine on tehtud.
            Preferences.Default.Set("EsimeneKäivitamine", false);
        }
    }
}