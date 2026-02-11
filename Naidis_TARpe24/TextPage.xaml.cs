namespace Naidis_TARpe24;

public partial class TextPage : ContentPage
{
	Label lbl;
	Editor editor;
	HorizontalStackLayout hsl;
	VerticalStackLayout vsl;
	List<string> nupud = new List<string> { "Tagasi", "Avaleht", "Edasi" };
	public TextPage()
	{
		lbl = new Label
		{
			Text = "Pealkiri",
			TextColor=Colors.Black,
			FontFamily="Corleone 400",
			FontAttributes=FontAttributes.Bold,
			TextDecorations=TextDecorations.Underline,
			FontSize=36,
		};
		editor = new Editor
		{
			Placeholder = "Sisesta tekst...",
			PlaceholderColor = Colors.Red,
			FontSize = 18,
			FontAttributes = FontAttributes.Italic,
			HorizontalOptions=LayoutOptions.Center,
		};
		editor.TextChanged += (sender, e) =>
		{
			lbl.Text = editor.Text;
		};
		hsl = new HorizontalStackLayout { Spacing = 20, HorizontalOptions = LayoutOptions.Center };
		for (int i = 0; i < nupud.Count; i++)
		{
			Button nupp = new Button
			{
				Text = nupud[i],
				FontSize=28,
				FontFamily="Corleone 400",
				TextColor=Colors.Violet,
				Background=Colors.LightGray,
				CornerRadius=10,
				HeightRequest=50,
				ZIndex=i
			};
			hsl.Add(nupp);
			nupp.Clicked += Liikumine;
		}
        Button tts = new Button //texttospeech
        {
            Text = "Räägi",
            FontSize = 28,
            FontFamily = "Corleone 400",
            TextColor = Colors.Violet,
            Background = Colors.LightGray,
            CornerRadius = 10,
            HeightRequest = 50
        };
		tts.Clicked += Btn_Clicked;
        vsl = new VerticalStackLayout
		{
			Padding=20,
			Spacing=15,
			Children = {lbl, editor, hsl, tts },
			HorizontalOptions=LayoutOptions.Center
		};
		Content = vsl;
	}
	private async void Liikumine(object? sender, EventArgs e)
	{
		Button nupp = sender as Button;
		if (nupp.ZIndex == 0)
		{
			Navigation.PopAsync();
		}
		else if (nupp.ZIndex == 1)
		{
			Navigation.PopToRootAsync();
		}
		else if (nupp.ZIndex == 2)
		{
			Navigation.PushAsync(new FigurePage());
		}
	}
	private async void Btn_Clicked(object? sender, EventArgs e)
	{
		IEnumerable<Locale> locales = await TextToSpeech.Default.GetLocalesAsync();

		SpeechOptions options = new SpeechOptions()
		{
			Pitch = 0.5f, // 0.0 - 2.0
			Volume = 0.75f,
			Locale = locales.FirstOrDefault()
		};
		var text = editor.Text;
		if (string.IsNullOrWhiteSpace(text))
		{
			await DisplayAlert("Viga", "Palun sisesta tekst", "Ok");
			return;
		}
		try
		{
			await TextToSpeech.SpeakAsync(text, options);
		}
		catch(Exception ex)
		{
			await DisplayAlert("TTS viga", ex.Message, "OK");
		}
	}
}