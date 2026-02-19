using Microsoft.Maui.Controls.Shapes;

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
            WidthRequest = 200,
            HeightRequest = 200,            
            HorizontalOptions = LayoutOptions.Center
        };


        sl = new Slider
        {
            Minimum = 0,
            Maximum = 100,
            Value = 25,
            MinimumTrackColor = Color.FromRgb(55, 55, 55),
            MaximumTrackColor = Color.FromRgb(0, 0, 0),
            ThumbColor = Color.FromRgb(155, 155, 155),
        };
        sl.ValueChanged += Sl_ValueChanged;

    }
    private void Sl_ValueChanged(object? sender, ValueChangedEventArgs e)
    {
        
    }
}