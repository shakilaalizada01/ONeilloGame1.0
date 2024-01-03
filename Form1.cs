using System;// Namespaces used in the code
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using Newtonsoft.Json;

namespace O_Neillo_Game
{
    public partial class Form1 : Form
    {
        // Game state object to store and manage the game state
        private GameState gameState;

    
        // Labels and controls for the game

        private bool isEditingPlayer1Name = false;
        private bool isEditingPlayer2Name = false;

        // Game data
        private int[,] board;
        private int currentPlayer;
        private PictureBox[,] pictureBoxes;

        private bool speakEnabled = false;
        private bool informationPanelVisible = true;

        // Constructor for the main form
        public Form1()
        {
            InitializeComponent();
            LoadApplicationSettings();  // Call to load application settings
            InitializeGUI();  // Call the method to initialize the game UI
            gameState = new GameState();  // Create a new game state object
            InitializePlayerNameLabels();  // Initialize player name labels
        }

        // Method to initialize player name labels and make them clickable
        private void InitializePlayerNameLabels()
        {
            // Display player names
            player1name.Text = gameState.CurrentSnapshot.Player1Name;
            player2name.Text = gameState.CurrentSnapshot.Player2Name;

            // Make player name labels clickable
            player1name.Click += PlayerNameLabel_Click;
            player2name.Click += PlayerNameLabel_Click;
        }

        // Event handler for player name label click
        private void PlayerNameLabel_Click(object sender, EventArgs e)
        {
            Label playerNameLabel = (Label)sender;

            if (playerNameLabel == player1name)
            {
                isEditingPlayer1Name = !isEditingPlayer1Name;
                player1name.BorderStyle = isEditingPlayer1Name ? BorderStyle.FixedSingle : BorderStyle.None;

                if (isEditingPlayer1Name)
                {
                    PromptAndSetName(player1name);
                }
            }
            else if (playerNameLabel == player2name)
            {
                isEditingPlayer2Name = !isEditingPlayer2Name;
                player2name.BorderStyle = isEditingPlayer2Name ? BorderStyle.FixedSingle : BorderStyle.None;

                if (isEditingPlayer2Name)
                {
                    PromptAndSetName(player2name);
                }
            }
        }

        private void PromptAndSetName(Label playerNameLabel)
        {
            // Show a message box asking the user to enter a name or continue with the default
            DialogResult result = MessageBox.Show("Please enter a name or click 'Default' to continue with the default name.", "Enter Name", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                string enteredName = PromptForPlayerName(playerNameLabel.Text);
                playerNameLabel.Text = enteredName;
            }
            else
            {
                // User clicked Cancel, revert to default name
                playerNameLabel.Text = "Player " + (playerNameLabel == player1name ? "1" : "2");
            }

            // Stop editing
            isEditingPlayer1Name = false;
            isEditingPlayer2Name = false;

            // Remove the border
            player1name.BorderStyle = BorderStyle.None;
            player2name.BorderStyle = BorderStyle.None;
        }

        // Method to initialize the game UI
        private void InitializeGUI()
        {
            // Title bar
            this.Text = "O'Neillo Game";

            // Menu bar
            MenuStrip menuStrip = new MenuStrip();

            // Game menu
            ToolStripMenuItem gameMenu = new ToolStripMenuItem("Game");
            gameMenu.DropDownItems.Add("New Game", null, NewGame_Click);
            gameMenu.DropDownItems.Add("Save Game", null, SaveGame_Click);
            gameMenu.DropDownItems.Add("Restore Game", null, RestoreGame_Click);
            
            gameMenu.DropDownItems.Add("Exit", null, Exit_Click);

            // Settings menu
            ToolStripMenuItem settingsMenu = new ToolStripMenuItem("Settings");
            ToolStripMenuItem speakMenuItem = new ToolStripMenuItem("Speak");
            speakMenuItem.CheckOnClick = true;
            speakMenuItem.Checked = speakEnabled;
            speakMenuItem.Click += SpeakMenuItem_Click;
            settingsMenu.DropDownItems.Add(speakMenuItem);

            // Information Panel setting
            ToolStripMenuItem informationPanelMenuItem = new ToolStripMenuItem("Information Panel");
            informationPanelMenuItem.CheckOnClick = true;
            informationPanelMenuItem.Checked = informationPanelVisible;
            informationPanelMenuItem.Click += InformationPanelMenuItem_Click;
            settingsMenu.DropDownItems.Add(informationPanelMenuItem);

            // Help menu
            ToolStripMenuItem helpMenu = new ToolStripMenuItem("Help");
            helpMenu.DropDownItems.Add("About", null, About_Click);

            menuStrip.Items.Add(gameMenu);
            menuStrip.Items.Add(settingsMenu);
            menuStrip.Items.Add(helpMenu);

            // Add the menu strip to the form
            this.Controls.Add(menuStrip);

            // Set the initial visibility of the information panel
            panel1.Visible = informationPanelVisible;

            // Gameplay area without TableLayoutPanel
            pictureBoxes = new PictureBox[8, 8];
            board = new int[8, 8];

            int cellSize = 50;

            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    pictureBoxes[row, col] = new PictureBox
                    {
                        Size = new Size(cellSize, cellSize),
                        Location = new Point(col * cellSize + (ClientSize.Width - 8 * cellSize) / 2, row * cellSize + (ClientSize.Height - 8 * cellSize) / 2),
                        SizeMode = PictureBoxSizeMode.StretchImage,
                    };

                    pictureBoxes[row, col].Click += CellClicked;
                    Controls.Add(pictureBoxes[row, col]);
                }
            }

            // Initialize starting positions on the game board
            board[3, 3] = 2;
            board[4, 4] = 2;
            board[3, 4] = 1;
            board[4, 3] = 1;

            currentPlayer = 1;
            UpdateBoardUI();

            // Set the initial player's turn
            SpeakPlayerTurn();
        }

        // Event handler for the Speak menu item
        private void SpeakMenuItem_Click(object sender, EventArgs e)
        {
            speakEnabled = !speakEnabled;
            MessageBox.Show($"Speak is {(speakEnabled ? "enabled" : "disabled")}");
        }

        // Event handler for the Information Panel menu item
        private void InformationPanelMenuItem_Click(object sender, EventArgs e)
        {
            informationPanelVisible = !informationPanelVisible;
            panel1.Visible = informationPanelVisible;
            MessageBox.Show($"Information Panel is {(informationPanelVisible ? "visible" : "hidden")}");
        }

        // Method to prompt the user for a player's name
        private string PromptForPlayerName(string playerLabel)
        {
            string playerName = "";

            using (var prompt = new Form())
            {
                prompt.Width = 300;
                prompt.Height = 150;
                prompt.Text = $"Enter {playerLabel}'s name:";

                var label = new Label() { Left = 50, Top = 20, Text = $"{playerLabel}'s Name:" };
                var textBox = new TextBox() { Left = 50, Top = 50, Width = 200 };
                var confirmation = new Button() { Text = "Ok", Left = 50, Width = 200, Top = 70 };

                confirmation.Click += (sender, e) => { playerName = textBox.Text; prompt.Close(); };

                prompt.Controls.Add(label);
                prompt.Controls.Add(textBox);
                prompt.Controls.Add(confirmation);

                prompt.ShowDialog();
            }

            return playerName;
        }

        // Method to update the UI based on the current state of the game board
        private void UpdateBoardUI()
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    PictureBox cell = pictureBoxes[row, col];

                    // Set the image of the PictureBox based on the value in the game board
                    if (board[row, col] == 0)
                    {
                        cell.Image = Properties.Resources.green;
                    }
                    else if (board[row, col] == 1)
                    {
                        cell.Image = Properties.Resources.black;
                    }
                    else if (board[row, col] == 2)
                    {
                        cell.Image = Properties.Resources.white;
                    }
                }
            }

            // Update the PlayerMarker label with the current player's name
            string currentPlayerName = (currentPlayer == 1) ? player1name.Text : player2name.Text;
            if (currentPlayer == 1)
            {
                PlayerMarker1.Visible = true;
                PlayerMarker2.Visible = false;
            }
            else
            {
                PlayerMarker1.Visible = false;
                PlayerMarker2.Visible = true;
            }

            int player1TokenCount = CountTokens(1);
            int player2TokenCount = CountTokens(2);

            // Assuming you've named your labels player1token and player2token in the designer
            player1token.Text = $"{player1TokenCount} X";
            player2token.Text = $"{player2TokenCount} X";
        }

        // Method to check if there are valid moves left for the current player
        private bool HasValidMoves()
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (board[row, col] == 0 && IsValidMove(row, col))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        // Event handler for cell click
        private void CellClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(player1name.Text) || string.IsNullOrEmpty(player2name.Text))
            {
                MessageBox.Show("Please enter names for both players before starting the game.");
                return;
            }

            PictureBox cell = (PictureBox)sender;
            int row = (cell.Location.Y - (ClientSize.Height - 8 * cell.Height) / 2) / cell.Height;
            int col = (cell.Location.X - (ClientSize.Width - 8 * cell.Width) / 2) / cell.Width;

            if (IsValidMove(row, col))
            {
                labelassist.Text = "";
                board[row, col] = currentPlayer;
                FlipOpponentPieces(row, col);

                currentPlayer = (currentPlayer == 1) ? 2 : 1;
                UpdateBoardUI();

                SpeakPlayerTurn();

                if (!HasValidMoves())
                {
                    labelassist.Text = "";
                    DisplayGameResult();
                }
            }
            else
            {
                labelassist.Text = "Player " + currentPlayer + " Invalid move. Try again.";
            }
        }

        // Method to count the tokens of a specific player on the board
        private int CountTokens(int player)
        {
            int count = 0;

            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (board[row, col] == player)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        // Async method to speak the current player's turn
        private async void SpeakPlayerTurn()
        {
            if (speakEnabled)
            {
                string currentPlayerName = (currentPlayer == 1) ? player1name.Text : player2name.Text;

                using (SpeechSynthesizer synthesizer = new SpeechSynthesizer())
                {
                    synthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult);

                    if (!HasValidMoves())
                    {
                        // Speak game over message
                        await Task.Run(() => synthesizer.Speak($"Game over. {GetWinner()} wins!"));
                    }
                    else if (labelassist.Text.Contains("Invalid"))
                    {
                        // Speak invalid move message
                        await Task.Run(() => synthesizer.Speak("Invalid move. Try again."));
                    }
                    else
                    {
                        // Normal player's turn message
                        await Task.Run(() => synthesizer.Speak($"{currentPlayerName}'s turn"));
                    }
                }
            }
        }


        // Method to check if a move is valid
        private bool IsValidMove(int row, int col)
        {
            if (board[row, col] != 0)
            {
                return false;
            }

            for (int rowIncrement = -1; rowIncrement <= 1; rowIncrement++)
            {
                for (int colIncrement = -1; colIncrement <= 1; colIncrement++)
                {
                    if (rowIncrement == 0 && colIncrement == 0)
                        continue;

                    if (CanFlipInDirection(row, col, rowIncrement, colIncrement))
                    {
                        int newRow = row + rowIncrement;
                        int newCol = col + colIncrement;

                        if (newRow >= 0 && newRow < 8 && newCol >= 0 && newCol < 8 && board[newRow, newCol] != currentPlayer)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        // Method to check if opponent's pieces can be flipped in any direction from a given cell



        // Method to check if opponent's pieces can be flipped in a specific direction from a given cell
        private bool CanFlipInDirection(int startRow, int startCol, int rowIncrement, int colIncrement)
        {
            int currentPlayer = board[startRow, startCol];
            int opponentPlayer = (currentPlayer == 1) ? 2 : 1;

            int row = startRow + rowIncrement;
            int col = startCol + colIncrement;

            while (row >= 0 && row < 8 && col >= 0 && col < 8)
            {
                if (board[row, col] == opponentPlayer)
                {
                    while (row >= 0 && row < 8 && col >= 0 && col < 8)
                    {
                        if (board[row, col] == currentPlayer)
                        {
                            return true;
                        }
                        else if (board[row, col] == 0)
                        {
                            break;
                        }

                        row += rowIncrement;
                        col += colIncrement;
                    }
                }
                else if (board[row, col] == currentPlayer)
                {
                    break;
                }

                row += rowIncrement;
                col += colIncrement;
            }

            return false;
        }

        // Method to flip opponent's pieces in all directions from a given cell
        private void FlipOpponentPieces(int row, int col)
        {
            FlipInDirection(row, col, 0, 1);
            FlipInDirection(row, col, 1, 0);
            FlipInDirection(row, col, 1, 1);
            FlipInDirection(row, col, 1, -1);
            FlipInDirection(row, col, 0, -1);
            FlipInDirection(row, col, -1, 0);
            FlipInDirection(row, col, -1, -1);
            FlipInDirection(row, col, -1, 1);
        }

        // Method to flip opponent's pieces in a specific direction from a given cell
        private async void FlipInDirection(int startRow, int startCol, int rowIncrement, int colIncrement)
        {
            int currentPlayer = board[startRow, startCol];
            int opponentPlayer = (currentPlayer == 1) ? 2 : 1;

            int row = startRow + rowIncrement;
            int col = startCol + colIncrement;

            bool validMove = false;

            while (row >= 0 && row < 8 && col >= 0 && col < 8)
            {
                if (board[row, col] == opponentPlayer)
                {
                    row += rowIncrement;
                    col += colIncrement;
                }
                else if (board[row, col] == currentPlayer)
                {
                    validMove = true;
                    break;
                }
                else if (board[row, col] == 0)
                {
                    break;
                }
                else
                {
                    break;
                }
            }

            if (validMove)
            {
                row = startRow + rowIncrement;
                col = startCol + colIncrement;

                while (board[row, col] == opponentPlayer)
                {
                    board[row, col] = currentPlayer;
                    UpdateBoardUI(); // Update UI during each piece flip
                    await Task.Delay(100); // Introduce a delay for a smoother transition
                    row += rowIncrement;
                    col += colIncrement;
                }
            }
        }

        // Method to check if the game is over
        private bool IsGameOver()
        {
            // Logic to check if the game is over (e.g., no valid moves left or the board is completely filled)
            return false;
        }

        // Method to display the game result
        private void DisplayGameResult()
        {
            // Logic to determine the game result (e.g., calculate scores, find the winner, etc.)
            // Update labelassist with the game result
            labelassist.Text = "Game Over. " + GetWinner() + " wins!";
        }

        private string GetWinner()
        {
            int player1TokenCount = CountTokens(1);
            int player2TokenCount = CountTokens(2);

            if (player1TokenCount > player2TokenCount)
                return player1name.Text;
            else if (player2TokenCount > player1TokenCount)
                return player2name.Text;
            else
                return "It's a draw";
        }

        
        // Event handler for the New Game menu item
        private void NewGame_Click(object sender, EventArgs e)
        {
            if (IsGameInProgress())
            {
                PromptToSaveGame();
            }

            gameState.Reset();
            ClearBoard();

            board[3, 3] = 2;
            board[4, 4] = 2;
            board[3, 4] = 1;
            board[4, 3] = 1;

            currentPlayer = 1;
            UpdateBoardUI();
            InitializePlayerNameLabels();

            SpeakPlayerTurn();
        }

        // Event handler for the Exit menu item
        private void Exit_Click(object sender, EventArgs e)
        {
            if (IsGameInProgress())
            {
                bool shouldSaveGame = PromptToSaveGame();

                if (shouldSaveGame)
                {
                    SaveGameState();
                }
            }

            Close();
        }
        private bool IsGameInProgress()
        {
            // Check if any cell on the board has a non-zero value
            return board.Cast<int>().Any(cellValue => cellValue != 0);
        }

        // Event handler for the Save Game menu item
        private void SaveGame_Click(object sender, EventArgs e)
        {
            // Check if a game is in progress
            if (IsGameInProgress())
            {
                // Prompt the user to save the present game's state
                PromptToSaveGame();
            }
        }
        // Method to prompt the user to save the present game's state
        private bool PromptToSaveGame()
        {
            DialogResult result = MessageBox.Show("Do you want to save the current game state?", "Save Game", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                SaveGameState();
                return true;
            }

            return false;
        }
        private void SaveGameState()
        {
            // Create a new GameSnapshot with the current state of the game
            GameSnapshot currentSnapshot = new GameSnapshot
            {
                Player1Name = player1name.Text,
                Player2Name = player2name.Text,
                CurrentPlayer = currentPlayer
            };

            // Copy the current state of the game board
            currentSnapshot.Board = new int[8, 8];
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    currentSnapshot.Board[row, col] = board[row, col];
                }
            }

            // Save the current game state to the list of saved states
            gameState.SavedGameStates.Add(currentSnapshot);

            // Use the Newtonsoft.Json library to serialize the game state to JSON
            string jsonGameState = JsonConvert.SerializeObject(gameState.CurrentSnapshot);

            try
            {
                // Save the JSON data to a file (you can modify the path as needed)
                File.WriteAllText("game_data.json", jsonGameState);
                MessageBox.Show("Game state saved successfully.", "Save Game");

                // Save the application settings
                SaveApplicationSettings();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving game state: {ex.Message}", "Save Game Error");
            }
        }

        // Method to save application settings
        private void SaveApplicationSettings()
        {
            // Save the application settings to a file (you can modify the path as needed)
            string jsonSettings = JsonConvert.SerializeObject(new { SpeakEnabled = speakEnabled, InformationPanelVisible = informationPanelVisible });

            try
            {
                File.WriteAllText("app_settings.json", jsonSettings);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving application settings: {ex.Message}", "Save Settings Error");
            }
        }

        private void RestoreGame_Click(object sender, EventArgs e)
        {
            if (gameState.SavedGameStates.Count == 0)
            {
                MessageBox.Show("No saved game states available.", "Restore Game");
                return;
            }
            else if (gameState.SavedGameStates.Count == 1)
            {
                // Restore the game to the only available state
                RestoreGameState(gameState.SavedGameStates[0]);
            }
            else
            {
                // Display a dialog to choose the game state to restore
                var restoreForm = new RestoreGameForm(gameState.SavedGameStates);

                // Show the RestoreGameForm as a dialog
                if (restoreForm.ShowDialog() == DialogResult.OK)
                {
                    RestoreGameState(restoreForm.SelectedGameState);
                }
            }
        }

        // Method to restore the game state
        private void RestoreGameState(GameSnapshot gameSnapshot)
        {
            // Clear existing board and player names
            ClearBoard();
            player1name.Text = gameSnapshot.Player1Name;
            player2name.Text = gameSnapshot.Player2Name;

            // Apply the game state to the UI
            LoadGameStateToUI(gameSnapshot);

            MessageBox.Show("Game state restored successfully.", "Restore Game");
        }

        // Method to clear the game board
        private void ClearBoard()
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    board[row, col] = 0;
                }
            }
        }

        private void LoadGameStateToUI(GameSnapshot gameSnapshot)
        {
            // Update player names
            player1name.Text = gameSnapshot.Player1Name;
            player2name.Text = gameSnapshot.Player2Name;

            // Update the game board
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    board[row, col] = gameSnapshot.Board[row, col];
                }
            }

            // Update the current player
            currentPlayer = gameSnapshot.CurrentPlayer;

            // Update other UI elements as needed
            UpdateBoardUI();
        }



        // Method to save application settings
     

        // Method to load application settings
        private void LoadApplicationSettings()
        {
            try
            {
                if (File.Exists("app_settings.json"))
                {
                    // Load the application settings from the file
                    string jsonSettings = File.ReadAllText("app_settings.json");
                    var settings = JsonConvert.DeserializeAnonymousType(jsonSettings, new { SpeakEnabled = false, InformationPanelVisible = true });

                    // Apply the loaded settings
                    speakEnabled = settings.SpeakEnabled;
                    informationPanelVisible = settings.InformationPanelVisible;

                    // Update the UI based on the loaded settings
                    
                    UpdateUIBasedOnSettings();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading application settings: {ex.Message}", "Load Settings Error");
            }
        }

        // Event handler for the About menu item
        private void About_Click(object sender, EventArgs e)
        {
            // Open the About Us form
            AboutUsForm aboutUsForm = new AboutUsForm();
            aboutUsForm.ShowDialog();
        }

        // Method to update the UI based on loaded settings
        private void UpdateUIBasedOnSettings()
        {
           
        }


        // Event handler for the Speak menu item
        private void Speak_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Speak Clicked");
        }

        // Event handler for the Information Panel menu item
        private void InformationPanel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Information Panel Clicked");
        }

    
     



        // Event handler for the PlayerMarker Click event
        private void PlayerMarker_Click(object sender, EventArgs e)
        {

        }

        // Event handler for the panel Paint event
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void labelassist_Click(object sender, EventArgs e)
        {

        }
    }
}