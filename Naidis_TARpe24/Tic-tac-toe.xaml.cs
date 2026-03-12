namespace Naidis_TARpe24;

public partial class Tic_tac_toe : ContentPage
{
    Grid gameGrid;
    bool isXTurn = true;
    Label label2;
    bool playVsBot = false;
    Label modeLabel;

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

        label2 = new Label
        {
            Text = "Käik: X",
            FontSize = 20,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center
        };

        modeLabel = new Label
        {
            Text = "Reþiim: Mängija vs Mängija",
            FontSize = 18,
            HorizontalOptions = LayoutOptions.Center
        };

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
                var cellLabel = new Label
                {
                    FontSize = 40,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center
                };

                var border = new Border
                {
                    Stroke = Colors.Gray,
                    StrokeThickness = 2,
                    Content = cellLabel
                };

                var tap = new TapGestureRecognizer();
                tap.CommandParameter = (cellLabel, index);
                tap.Tapped += OnCellTapped;

                border.GestureRecognizers.Add(tap);

                gameGrid.Add(border, col, row);

                index++;
            }
        }

        Button btnReset = new Button
        {
            Text = "Reseti väljak",
            FontSize = 22,
            BackgroundColor = Colors.Red,
            TextColor = Colors.White
        };

        btnReset.Clicked += (s, e) => ResetGame();

        Button btnReeglid = new Button
        {
            Text = "Mängu reeglid",
            FontSize = 22,
            BackgroundColor = Colors.Green,
            TextColor = Colors.White
        };
        btnReeglid.Clicked += (s, e) => M2nguReeglid();

        Button btnBot = new Button
        {
            Text = "Mängi boti vastu",
            FontSize = 22,
            BackgroundColor = Colors.Blue,
            TextColor = Colors.White
        };

        btnBot.Clicked += (s, e) =>
        {
            playVsBot = true;
            modeLabel.Text = "Reþiim: Mängija vs Bot";
            ResetGame();
        };

        Content = new VerticalStackLayout
        {
            Spacing = 20,
            Children = {
                new Label
                {
                    Text = "Trips Traps Trull",
                    FontSize = 28,
                    HorizontalOptions = LayoutOptions.Center
                },
                label2,
                modeLabel,
                gameGrid,
                btnReset,
                btnReeglid,
                btnBot
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


        isXTurn = !isXTurn;
        label2.Text = isXTurn ? "Käik: X" : "Käik: O";

        if (playVsBot && !isXTurn)
        {
            BotMove();
        }
        if (CheckWinner(player))
        {
            DisplayAlertAsync("Game Over", $"{player} wins!", "OK");
            playVsBot = false;
            modeLabel.Text = "Reþiim: Mängija vs Mängija";
            ResetGame();
            return;
        }
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
        label2.Text = "Käik: X";

        board = new string[9];

        foreach (var child in gameGrid.Children)
        {
            if (child is Border border && border.Content is Label label)
            {
                label.Text = "";
            }
        }
    }
    void M2nguReeglid()
    {
        DisplayAlertAsync("Trips-Traps-Trull reeglid",
           "1. Mängu mängivad kaks mängijat: X ja O.\n\n" +
           "2. Mängijad teevad käike kordamööda.\n\n" +
           "3. X alustab mängu.\n\n" +
           "4. Eesmärk on saada kolm sama märki (X või O) " +
           "horisontaalselt, vertikaalselt või diagonaalselt.\n\n" +
           "5. Kui kõik ruudud on täis ja keegi ei võida, on mäng viik.",
           "OK");
    }
    void BotMove()
    {
        Random rnd = new Random();

        List<int> free = new List<int>();

        for (int i = 0; i < board.Length; i++)
        {
            if (string.IsNullOrEmpty(board[i]))
                free.Add(i);
        }

        if (free.Count == 0)
            return;

        int move = free[rnd.Next(free.Count)];

        var border = (Border)gameGrid.Children[move];
        var label = (Label)border.Content;

        label.Text = "O";
        board[move] = "O";

        if (CheckWinner("O"))
        {
            DisplayAlertAsync("Mäng läbi", "Bot (O) võitis!", "OK");
            playVsBot = false;
            modeLabel.Text = "Reþiim: Mängija vs Mängija";
            ResetGame();
            return;
        }

        isXTurn = true;
        label2.Text = "Käik: X";
    }
}