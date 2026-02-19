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
    AbsoluteLayout abs;
    BoxView yleminekast;
    BoxView yleminekast2;
    BoxView yleminekast3;
    public VarviPage()
	{
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
        sl.ValueChanged += Sl_ValueChanged;
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
        sl.ValueChanged += Sl_ValueChanged;


        abs = new AbsoluteLayout { Children = { yleminekast, yleminekast2, yleminekast3, sl, sl2, sl3 } };
        List<View> controls = new List<View> { yleminekast, yleminekast2, yleminekast3, sl, sl2, sl3 };
        for (int i=0; i<controls.Count;i++)
        {
            double yKoht = 0.2 + i * 0.15;
            AbsoluteLayout.SetLayoutBounds(controls[i], new Rect(0.5, yKoht, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            AbsoluteLayout.SetLayoutFlags(controls[i], AbsoluteLayoutFlags.PositionProportional);
        }
        ScrollView scroll = new ScrollView
        {
            Content = abs
        };

        Content = scroll;
    }
    private void Sl_ValueChanged(object? sender, ValueChangedEventArgs e)
    {
        
    }
}