namespace Naidis_TARpe24;

public partial class s6pradeKontaktandmed : ContentPage
{
    
    Entry email_phone;
    Entry message;
    Label label1;
    Label label2;
    List<string> To;
    Button btnSms;
    Button btnEmail;
    public s6pradeKontaktandmed()
    {
        label1 = new Label
        {
            Text="Sisesta oma andmed"
        };
        email_phone = new Entry
        {
            Placeholder = "Sisesta email või tel. number",
            Keyboard = Keyboard.Default
        };
        label2 = new Label
        {
            Text="Sisesta oma sõnum"
        };
        message = new Entry
        {
            Placeholder = "Sisesta oma sõnum",
            Keyboard = Keyboard.Default
        };

        Button btnSms = new Button
        {
            Text = "Saada sms",
            FontSize = 22,
            BackgroundColor = Colors.Blue,
            TextColor = Colors.White
        };
        btnSms.Clicked += Saada_sms_Clicked;

        Button btnEmail = new Button
        {
            Text = "Saada Email",
            FontSize = 22,
            BackgroundColor = Colors.Blue,
            TextColor = Colors.White
        };
        btnEmail.Clicked += Saada_email_Clicked;


        Content = new VerticalStackLayout{
            Spacing = 20,
            Children = {
                new Label
                {
                    Text = "Kontaktiraamat",
                    FontSize = 28,
                    HorizontalOptions = LayoutOptions.Center
                },
                label1,
                email_phone,
                label2,
                message,
                btnSms,
                btnEmail

            }
        };
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