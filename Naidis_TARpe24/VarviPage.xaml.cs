using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Layouts;


namespace Naidis_TARpe24;

public partial class VarviPage : ContentPage
{
    Label lbl;
    Slider sl;
    Slider sl2;
    Slider sl3;
    Stepper st;
    VerticalStackLayout vsl;
    int R;
    int G;
    int B;
    AbsoluteLayout abs;
    BoxView ColorBox;
    BoxView yleminekast;
    BoxView yleminekast2;
    BoxView yleminekast3;
    public VarviPage()
	{
        lbl = new Label
        {
            FontSize = 36,
            FontFamily = "Corleone 400",
            TextColor = Colors.Black,
            Text = "RGB Mudel", 
            HorizontalOptions = LayoutOptions.Center
        };
        // =======Ülemised kastid=======
        yleminekast = new BoxView
        {
            WidthRequest = 50,
            HeightRequest = 50,            
            HorizontalOptions = LayoutOptions.Center
        };
        yleminekast2 = new BoxView
        {
            WidthRequest = 50,
            HeightRequest = 50,
            HorizontalOptions = LayoutOptions.Center
        };
        yleminekast3 = new BoxView
        {
            WidthRequest = 50,
            HeightRequest = 50,
            HorizontalOptions = LayoutOptions.Center
        };

        //=======Sliderid=======
        sl = new Slider
        {
            Minimum = 0,
            Maximum = 255,
            Value = 0,
            WidthRequest = 300,
            HorizontalOptions =LayoutOptions.Center,
            MinimumTrackColor = Color.FromRgb(0, 0, 0),
            MaximumTrackColor = Color.FromRgb(254, 0, 0),
            ThumbColor = Color.FromRgb(155, 155, 155),
        };
        sl.ValueChanged += Sl_ValueChanged;
        sl2 = new Slider
        {
            Minimum = 0,
            Maximum = 255,
            Value = 0,
            WidthRequest=300,
            HorizontalOptions = LayoutOptions.Center,
            MinimumTrackColor = Color.FromRgb(0, 0, 0),
            MaximumTrackColor = Color.FromRgb(0, 254, 0),
            ThumbColor = Color.FromRgb(155, 155, 155),
        };
        sl2.ValueChanged += Sl_ValueChanged;
        sl3 = new Slider
        {
            Minimum = 0,
            Maximum = 255,
            Value = 0,
            WidthRequest = 300,
            HorizontalOptions = LayoutOptions.Center,
            MinimumTrackColor = Color.FromRgb(0, 0, 0),
            MaximumTrackColor = Color.FromRgb(0, 0, 254),
            ThumbColor = Color.FromRgb(155, 155, 155),
        };
        sl3.ValueChanged += Sl_ValueChanged;
        ColorBox = new BoxView
        {
            Color = Color.FromRgb(R, G, B),
            WidthRequest = 200,
            HeightRequest = 200,
            HorizontalOptions = LayoutOptions.Center,
            BackgroundColor = Color.FromRgba(0, 0, 0, 0),
            CornerRadius = 15,
        };
        vsl = new VerticalStackLayout
        {
            Padding = 20,
            Spacing = 15,
            Children = { lbl, yleminekast, sl, yleminekast2, sl2, yleminekast3, sl3, ColorBox },
            HorizontalOptions = LayoutOptions.Center
        };

        //abs = new AbsoluteLayout { Children = { yleminekast, sl, yleminekast2, sl2, yleminekast3, sl3, ColorBox } };
        //List<View> controls = new List<View> { yleminekast, sl, yleminekast2, sl2, yleminekast3, sl3, ColorBox };
        //for (int i=0; i<controls.Count;i++)
        //{
        //    double yKoht = 0.2 + i * 0.15;
        //    AbsoluteLayout.SetLayoutBounds(controls[i], new Rect(0.5, yKoht, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
        //    AbsoluteLayout.SetLayoutFlags(controls[i], AbsoluteLayoutFlags.PositionProportional);
        //}
        //ScrollView scroll = new ScrollView
        //{
        //    Content = abs
        //};

        Content = vsl;
    }
    private void Sl_ValueChanged(object? sender, ValueChangedEventArgs e)
    {
        R = (int)sl.Value;
        G = (int)sl2.Value;
        B = (int)sl3.Value;
        sl.MinimumTrackColor = Color.FromRgb(R, 0, 0);
        sl.MaximumTrackColor = Color.FromRgb((255 - R), 0, 0);
        sl2.MinimumTrackColor = Color.FromRgb(0, G, 0);
        sl2.MaximumTrackColor = Color.FromRgb(0, (255 - G), 0);
        sl3.MinimumTrackColor = Color.FromRgb(0, 0, B);
        sl3.MaximumTrackColor = Color.FromRgb(0, 0, (255 - B));
        yleminekast.BackgroundColor = Color.FromRgb(R, 0, 0);
        yleminekast2.BackgroundColor = Color.FromRgb(0, G, 0);
        yleminekast3.BackgroundColor = Color.FromRgb(0, 0, B);
        ColorBox.Color = Color.FromRgb(R, G, B);
    }
}