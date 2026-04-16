using System.Collections.ObjectModel;

namespace Naidis_TARpe24
{
    public class Riik
    {
        public string Nimi { get; set; }
        public string Pealinn { get; set; }
        public int Rahvaarv { get; set; }
        public string Lipp { get; set; }
    }

    public partial class RiigidPage : ContentPage
    {
        ObservableCollection<Riik> riigid;
        ListView list;

        Entry entryNimi, entryPealinn, entryRahvaarv, entryLipp;

        public RiigidPage()
        {
            Title = "Euroopa Riigid";

            riigid = new ObservableCollection<Riik>
            {
                new Riik { Nimi="Eesti", Pealinn="Tallinn", Rahvaarv=1300000, Lipp="estonia.png" }
            };

            entryNimi = new Entry { Placeholder = "Riigi nimi (nt Saksamaa)" };
            entryPealinn = new Entry { Placeholder = "Riigi pealinn (nt Tallinn)" };
            entryRahvaarv = new Entry { Placeholder = "Rahvaarv (nt 1300000)" };
            entryLipp = new Entry { Placeholder = "Pildi failinimi (nt estonia.png)" };

            Button btnLisa = new Button
            {
                Text = "Lisa riik",
                BackgroundColor = Colors.LightGreen
            };
            btnLisa.Clicked += BtnLisa_Clicked;

            Button btnKustuta = new Button
            {
                Text = "Kustuta valitud riik",
                BackgroundColor = Colors.LightPink
            };
            btnKustuta.Clicked += BtnKustuta_Clicked;

            list = new ListView
            {
                HasUnevenRows = true,
                ItemsSource = riigid,
                SelectionMode = ListViewSelectionMode.Single
            };

            list.ItemTapped += List_ItemTapped;

            list.ItemTemplate = new DataTemplate(() =>
            {
                Image img = new Image
                {
                    HeightRequest = 50,
                    WidthRequest = 50,
                    Aspect = Aspect.AspectFit,
                    Margin = new Thickness(0, 0, 10, 0)
                };
                img.SetBinding(Image.SourceProperty, "Lipp");

                Label lblNimi = new Label { FontSize = 18, FontAttributes = FontAttributes.Bold };
                lblNimi.SetBinding(Label.TextProperty, "Nimi");

                Label lblPealinn = new Label { TextColor = Colors.Gray };
                lblPealinn.SetBinding(Label.TextProperty, "Pealinn");

                Label lblRahvaarv = new Label { TextColor = Colors.DarkBlue };
                lblRahvaarv.SetBinding(Label.TextProperty, new Binding("Rahvaarv", stringFormat: "{0} elanikku"));

                var textLayout = new StackLayout
                {
                    Orientation = StackOrientation.Vertical,
                    Children = { lblNimi, lblPealinn, lblRahvaarv }
                };

                return new ViewCell
                {
                    View = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        Padding = new Thickness(10),
                        Children = { img, textLayout }
                    }
                };
            });

            Content = new StackLayout
            {
                Padding = new Thickness(10),
                Children =
                {
                    entryNimi,
                    entryPealinn,
                    entryRahvaarv,
                    entryLipp,
                    btnLisa,
                    btnKustuta,
                    list
                }
            };
        }

        private async void List_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Riik valitud = e.Item as Riik;

            if (valitud != null)
            {
                await DisplayAlert("Riigi info",
                    $"Nimi: {valitud.Nimi}\nPealinn: {valitud.Pealinn}\nRahvaarv: {valitud.Rahvaarv}",
                    "Sulge");
            }
        }

        private async void BtnKustuta_Clicked(object sender, EventArgs e)
        {
            Riik valitud = list.SelectedItem as Riik;

            if (valitud != null)
            {
                bool kinnitus = await DisplayAlert("Kustutamine",
                    $"Kas soovid kustutada riigi {valitud.Nimi}?",
                    "Jah", "Ei");

                if (kinnitus)
                {
                    riigid.Remove(valitud);
                    list.SelectedItem = null;
                }
            }
            else
            {
                await DisplayAlert("Viga", "Palun vali riik, mida kustutada.", "OK");
            }
        }

        private async void BtnLisa_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(entryNimi.Text) ||
                string.IsNullOrWhiteSpace(entryPealinn.Text))
            {
                await DisplayAlert("Viga", "Nimi ja pealinn peavad olema täidetud!", "OK");
                return;
            }

            int rahvaarv = 0;
            int.TryParse(entryRahvaarv.Text, out rahvaarv);

            string pilt = string.IsNullOrWhiteSpace(entryLipp.Text)
                ? "default.png"
                : entryLipp.Text;

            riigid.Add(new Riik
            {
                Nimi = entryNimi.Text,
                Pealinn = entryPealinn.Text,
                Rahvaarv = rahvaarv,
                Lipp = pilt
            });

            entryNimi.Text = "";
            entryPealinn.Text = "";
            entryRahvaarv.Text = "";
            entryLipp.Text = "";
        }
    }
}

