namespace Naidis_TARpe24;

public partial class Tic_tac_toe : ContentPage
{
    Grid gameGrid;
    bool isXTurn = true;

    // Board state
    string[] board = new string[9];

    // Winning combinations
    int[,] wins =
    {
        {0,1,2},
        {3,4,5},
        {6,7,8},
        {0,3,6},
        {1,4,7},
        {2,5,8},
        {0,4,8},
        {2,4,6}
    };

    public Tic_tac_toe()
    {
        Title = "Trips-Traps-Trull";

        gameGrid = new Grid
        {
            WidthRequest = 250,
            HeightRequest = 250,
            RowSpacing = 0,
            ColumnSpacing = 0,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center
        };

        // Create rows and columns
        for (int i = 0; i < 3; i++)
        {
            gameGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
            gameGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
        }

        // Create cells
        int index = 0;

        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                var label = new Label
                {
                    FontSize = 40,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center
                };

                var border = new Border
                {
                    Stroke = Colors.Gray,
                    StrokeThickness = 2,
                    Content = label
                };

                var tap = new TapGestureRecognizer();
                tap.CommandParameter = (label, index);
                tap.Tapped += OnCellTapped;

                border.GestureRecognizers.Add(tap);

                gameGrid.Add(border, col, row);

                index++;
            }
        }

        Content = new VerticalStackLayout
        {
            Spacing = 20,
            Children =
            {
                new Label
                {
                    Text = "Trips Traps Trull",
                    FontSize = 28,
                    HorizontalOptions = LayoutOptions.Center
                },
                gameGrid
            }
        };
    }

    void OnCellTapped(object sender, TappedEventArgs e)
    {
        var data = ((Label label, int index))e.Parameter;

        if (!string.IsNullOrEmpty(data.label.Text))
            return;

        string player = isXTurn ? "X" : "O";

        data.label.Text = player;
        board[data.index] = player;

        if (CheckWinner(player))
        {
            DisplayAlert("Game Over", $"{player} wins!", "OK");
            ResetGame();
            return;
        }

        isXTurn = !isXTurn;
    }

    bool CheckWinner(string player)
    {
        for (int i = 0; i < 8; i++)
        {
            if (board[wins[i, 0]] == player &&
                board[wins[i, 1]] == player &&
                board[wins[i, 2]] == player)
            {
                return true;
            }
        }

        return false;
    }

    void ResetGame()
    {
        isXTurn = true;
        board = new string[9];

        foreach (var child in gameGrid.Children)
        {
            if (child is Border border && border.Content is Label label)
            {
                label.Text = "";
            }
        }
    }
}