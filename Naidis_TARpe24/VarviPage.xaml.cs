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
        sl = new Slider
        {
            Minimum = 0,
            Maximum = 100,
            Value = 25,
            MinimumTrackColor=Color.FromRgb(0,0,0),
            MaximumTrackColor=Color.FromRgb(255,255,255),
            ThumbColor=Color.FromRgb(155,155,155),
        };

    }
}