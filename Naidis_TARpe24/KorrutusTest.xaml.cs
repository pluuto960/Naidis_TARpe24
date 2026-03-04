namespace Naidis_TARpe24;

public partial class KorrutusTest : ContentPage
{
    Random rnd = new Random();
    string kasutajaNimi = "";
    int oiged = 0;
    int kokku = 10;
    int raskusAste = 1;

    public KorrutusTest()
    {
        Label lbl = new Label
        {
            FontSize = 24,
            TextColor = Colors.Black,
            Text = "Siin lehel saad testida oma teadmisi korrutustabeli testiga",
            HorizontalOptions = LayoutOptions.Center
        };

        Button startButton = new Button
        {
            Text = "Alusta testi",
            HorizontalOptions = LayoutOptions.Center
        };

        startButton.Clicked += StartButton_Clicked;

        Content = new VerticalStackLayout
        {
            Spacing = 20,
            Padding = new Thickness(20, 50),
            Children = { lbl, startButton }
        };
    }

    private async void StartButton_Clicked(object? sender, EventArgs e)
    {
        oiged = 0;

        // Küsi nime
        string nimi = await DisplayPromptAsync("Kasutaja nimi", "Sisesta oma nimi:");

        if (string.IsNullOrWhiteSpace(nimi))
        {
            await DisplayAlertAsync("Viga", "Nimi peab olema sisestatud!", "OK");
            return;
        }

        kasutajaNimi = nimi;

        // Küsi raskusaste
        string raskus = await DisplayActionSheetAsync(
            "Vali raskusaste:",
            "Loobu",
            null,
            "1 - Lihtne (1-5)",
            "2 - Keskmine (1-10)",
            "3 - Raske (1-20)");

        if (raskus == "Loobu" || raskus == null)
            return;

        if (raskus.StartsWith("1"))
            raskusAste = 1;
        else if (raskus.StartsWith("2"))
            raskusAste = 2;
        else
            raskusAste = 3;

        bool valmis = await DisplayAlertAsync("Kinnitus",
            $"{kasutajaNimi}, kas oled valmis testi alustama?",
            "Alusta",
            "Loobu");

        if (!valmis)
            return;

        // Määra random range vastavalt raskusastmele
        int min = 1;
        int max = raskusAste switch
        {
            1 => 6,   // 1-5
            2 => 11,  // 1-10
            3 => 21,  // 1-20
            _ => 11
        };

        // 10 küsimust
        for (int i = 1; i <= kokku; i++)
        {
            int arv1 = rnd.Next(min, max);
            int arv2 = rnd.Next(min, max);
            int oigeVastus = arv1 * arv2;

            string vastus = await DisplayPromptAsync(
                $"Küsimus {i}/{kokku}",
                $"{kasutajaNimi}, kui palju on {arv1} × {arv2} ?",
                keyboard: Keyboard.Numeric);

            if (vastus == null)
            {
                await DisplayAlertAsync("Test katkestatud", "Sa katkestasid testi.", "OK");
                return;
            }

            if (int.TryParse(vastus, out int kasutajaVastus))
            {
                if (kasutajaVastus == oigeVastus)
                {
                    oiged++;
                }
            }
        }

        int valed = kokku - oiged;
        double protsent = (double)oiged / kokku * 100;

        string hinnang;

        if (protsent == 100)
            hinnang = "Suurepärane tulemus! 🏆";
        else if (protsent >= 70)
            hinnang = "Väga hea töö! 👏";
        else if (protsent >= 50)
            hinnang = "Pole paha, harjuta veel";
        else
            hinnang = "Soovitan korrutustabelit veel harjutada";

        await DisplayAlertAsync("Testi tulemus",
            $"{kasutajaNimi}, test on lõppenud!\n\n" +
            $"Õigeid vastuseid: {oiged}\n" +
            $"Valesid vastuseid: {valed}\n" +
            $"Tulemus: {protsent:F0}%\n\n" +
            hinnang,
            "OK");
    }
}