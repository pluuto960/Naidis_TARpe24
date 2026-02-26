namespace Naidis_TARpe24;

public partial class Pop_Up_Page : ContentPage
{
	
	public Pop_Up_Page()
	{
		//1. Loome esimese nupu (Lihtne teade)
		Button alertButton = new Button
		{
			Text = "Teade",
			VerticalOptions=LayoutOptions.Start,
			HorizontalOptions=LayoutOptions.Center
		};
		// Seome nupu klikkimise sündmuse funktsioonidega
		alertButton.Clicked += AlertButton_Clicked;

		// 2. Loome teise nupu (kinnitus)
		Button alertYesNoButton = new Button
		{
			Text = "Jah või Ei",
            VerticalOptions = LayoutOptions.Start,
            HorizontalOptions = LayoutOptions.Center
        };
        alertYesNoButton.Clicked += AlertYesNoButton_Clicked;

		// 3. Loome kolmanda nupu (Valikmenyy)
		Button alertListButton = new Button
		{
            Text = "Valik",
            VerticalOptions = LayoutOptions.Start,
            HorizontalOptions = LayoutOptions.Center
        };
		alertListButton.Clicked += AlertListButton_Clicked;

        Button alertQuestButton = new Button
        {
            Text = "Küsimus",
            VerticalOptions = LayoutOptions.Start,
            HorizontalOptions = LayoutOptions.Center
        };
        alertQuestButton.Clicked += AlertQuestButton_Clicked;

		//4. Paigutame kõik nupud ekraanile üksteise alla
		Content = new VerticalStackLayout
		{
			Spacing = 20, //Jätab nuppude vahele 20 pikslit vaba ruumi
			Padding = new Thickness(0, 50, 0, 0), //Lükkab sisu veidi ülevalt alla
			Children = { alertButton, alertYesNoButton, alertListButton, alertQuestButton }
		};

    }
		// --- SYNDMUSTE FUNKTSIOONID (EVENTS) ---

		//1. Nupp: Lihtne teade
		private async void AlertButton_Clicked(object? sender, EventArgs e)
		{
			//Kuvab lihtsalt teate ja ootab, kuni kasutaja vajutab "OK"
			await DisplayAlertAsync("Teade", "Teil on uus teade", "OK");
		}

		//2. Nupp: Jah või ei valik
		private async void AlertYesNoButton_Clicked(object? sender, EventArgs e)
		{
			//Küsime kasutajalt kinnitust (tagastab true voi false)
			bool result = await DisplayAlertAsync("Kinnitus", "Kas oled kindel?", "Olen kindel", "Ei ole kindel");

			//Kuvame uue teate vastavalt sellele, mida kasutaja valis
			//(result ? "Jah : "Ei") tähendab: kui result on true, kirjuta "Jah", muidu "Ei".
			await DisplayAlertAsync("Teade", "Teie valik on: "+(result ? "Jah" : "Ei"),"OK");
		}

		//3. Nupp: Valikute nimekiri
		private async void AlertListButton_Clicked(object? sender, EventArgs e)
		{
			//Kuvab menyy ja salvestab kasutaja valitud teksti muutujasse 'action'
			string action = await DisplayActionSheetAsync("Mida teha?", "Loobu", "Kustutada", "Tantsida", "Laulda","Joonestada");

			// Kontrollime, et kasutaja ei vajutanud lihtsalt kõrvale ega valinud "Loobu"
			if (action != null && action != "Loobu")
			{
				await DisplayAlertAsync("Valik", "Sa valisid tegevuse: "+ action, "OK");
			}
		}
		// Valikvastustega
		private async void AlertQuestButton_Clicked(object sender, EventArgs e)
		{
		string result1 = await DisplayPromptAsync("Küsimus", "Kuidas läheb?", placeholder: "Tore!");
		string result2 = await DisplayPromptAsync("Vasta", "Millega võrdub 5+5?", initialValue:"10", maxLength:2, keyboard: Keyboard.Numeric);
		}

}