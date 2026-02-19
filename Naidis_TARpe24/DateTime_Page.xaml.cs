using Microsoft.Maui.Layouts;

namespace Naidis_TARpe24;

public partial class DateTime_Page : ContentPage
{
	Label lbl;
	DatePicker dp;
	TimePicker tp;
	AbsoluteLayout abs;
	Picker picker;
	public DateTime_Page()
	{
		lbl = new Label
		{
			BackgroundColor = Color.FromRgb(120, 44, 133),
			Text = "Vali mingi kuupäev või aeg"
		};
		dp = new DatePicker
		{
			MinimumDate = DateTime.Now.AddDays(-10),
			MaximumDate = DateTime.Now.AddDays(10),
			Format = "D"
		};
		dp.DateSelected += Kuupaeva_valik;
		tp = new TimePicker
		{
			Time = new TimeSpan(12, 0, 0)
		};
        picker = new Picker
        {
            Title = "Vali värv",
            ItemsSource = new List<string> { "Sinine", "Hall", "Valge" },
            HorizontalOptions = LayoutOptions.Center
        };
        picker.SelectedIndexChanged += (sender, e) =>
        {
            switch (picker.SelectedIndex)
            {
                case 0:
                    this.BackgroundColor = Colors.LightBlue;
                    break;
                case 1:
                    this.BackgroundColor = Colors.Grey;
                    break;
                case 2:
                    this.BackgroundColor = Colors.White;
                    break;
            }
        };
        dp.PropertyChanged += Aja_valik;
		abs = new AbsoluteLayout { Children = { lbl, dp, tp, picker } };
		AbsoluteLayout.SetLayoutBounds(lbl, new Rect(10, 10, 200, 50));
		AbsoluteLayout.SetLayoutBounds(dp, new Rect(0.2, 0.2, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
		AbsoluteLayout.SetLayoutFlags(dp, AbsoluteLayoutFlags.PositionProportional);
		AbsoluteLayout.SetLayoutBounds(tp, new Rect(0.2, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
		AbsoluteLayout.SetLayoutFlags(tp, AbsoluteLayoutFlags.PositionProportional);
        AbsoluteLayout.SetLayoutBounds(picker, new Rect(0.2, 0.7, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
        AbsoluteLayout.SetLayoutFlags(picker, AbsoluteLayoutFlags.PositionProportional);

        Content = abs;

		
		
		


	}
	
	private void Aja_valik(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
	{
		lbl.Text = "Oli valitud aeg: " + tp.Time.ToString();
	}

	private void Kuupaeva_valik(object? sender,DateChangedEventArgs e)
	{
		lbl.Text = "Oli valitud kuupäev: " + e.NewDate.ToString();
	}
}