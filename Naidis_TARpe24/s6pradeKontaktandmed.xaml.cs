namespace Naidis_TARpe24;

public partial class s6pradeKontaktandmed : ContentPage
{
    TableView tabelView;
    SwitchCell sc;
    ViewCell vc;
    public s6pradeKontaktandmed()
    {
        tabelView = new TableView
        {
            Root = new TableRoot
            {
                new TableSection("Kontaktandmed:")
                {
                    new EntryCell
                    {
                        Label="Nimi",
                        Placeholder="Sisesta nimi",
                        Keyboard=Keyboard.Default
                    },
                    new EntryCell
                    {
                        Label="Email",
                        Placeholder="Sisesta email",
                        Keyboard=Keyboard.Email
                    },
                    new EntryCell
                    {
                        Label="TelefoniNumber",
                        Placeholder="Sisesta tel. number",
                        Keyboard=Keyboard.Telephone
                    },
                    new EntryCell
                    {
                        Label="Kirjeldus",
                        Placeholder="Sisesta kirjeldus",
                        Keyboard=Keyboard.Default
                    },
                    sc
                }
            }
        };

        vc = new ViewCell
        {

        };

        Content = tabelView;


    }



    private async void Saada_sms_Clicked(object? sender, EventArgs e)
    {
        string phone = email_phone.Text;
        var message = "Tere tulemast! Saadan sõnumi";
        SmsMessage sms = new SmsMessage(message, phone);
        if (phone != null && Sms.Default.IsComposeSupported)
        {
            await Sms.Default.ComposeAsync(sms);
        }
    }
    private async void Saada_email_Clicked(object? sender, EventArgs e)
    {
        var message = "Tere tulemast! Saada email";
        EmailMessage e_mail = new EmailMessage
        {
            Subject = email_phone.Text,
            Body = message,
            BodyFormat = EmailBodyFormat.PlainText,
            To = new List<string>(new[] { email_phone.Text })
        };
        if (Email.Default.IsComposeSupported)
        {
            await Email.Default.ComposeAsync(e_mail);
        }
    }
}