// ... (Your existing using statements)

using System.Windows.Forms;
using System;

namespace O_Neillo_Game
{
    public partial class AboutUsForm : Form
    {
        public AboutUsForm()
        {
            InitializeComponent();
            InitializeUI();
        }

        private void AboutUsForm_Load(object sender, EventArgs e)
        {

        }

        private void InitializeUI()
        {
            // Set the form properties
            this.Text = "About Our Game";
            this.Size = new System.Drawing.Size(600, 400);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // PictureBox for the game image
            PictureBox pictureBox = new PictureBox
            {
                Image = Properties.Resources.reversi, // Set your game image here
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new System.Drawing.Size(200, 300),
                Location = new System.Drawing.Point(20, 20)
            };

            // Add PictureBox to the form
            this.Controls.Add(pictureBox);

            // Description label for the game
            Label descriptionLabel = new Label
            {
                Text = "Welcome to O'Neillo Game!\n\n" +
                       "Description: O'Neillo is a captivating board game that combines strategy and skill. The game is played on an 8x8 grid " +
                       "where two players take turns placing their tokens on the board. The goal is to strategically outmaneuver your opponent " +
                       "by flipping their tokens to your color.\n\n" +
                       "Key Features:\n" +
                       "1. **Strategic Gameplay:** Plan your moves carefully to control the board and dominate your opponent.\n" +
                       "2. **Token Flipping:** Place your tokens to flip your opponent's tokens, changing their color to yours.\n" +
                       "3. **Dynamic Reversals:** The tide of the game can change rapidly as players execute clever moves.\n" +
                       "4. **Endgame Victory:** The player with the most tokens of their color at the end of the game is declared the winner.\n\n" +
                       "Enjoy an exciting and intellectually stimulating experience with O'Neillo. Challenge your friends or test your " +
                       "strategic prowess against the computer. Are you ready to master the art of O'Neillo?",
                Location = new System.Drawing.Point(240, 20),
                Size = new System.Drawing.Size(320, 300),
                AutoSize = true,
               
                MaximumSize = new System.Drawing.Size(320, 0) // Set maximum width to allow multiline text
            };

            // Add description label to the form
            this.Controls.Add(descriptionLabel);

            // OK button to close the form
            Button okButton = new Button
            {
                Text = "OK",
                Location = new System.Drawing.Point(350, 320),
                Size = new System.Drawing.Size(80, 30)
            };

            // Wire up the OK button click event
            okButton.Click += OkButton_Click;

            // Add the OK button to the form
            this.Controls.Add(okButton);
        }

        // Event handler for the OK button click event
        private void OkButton_Click(object sender, EventArgs e)
        {
            // Close the form when OK is clicked
            this.Close();
        }
    }
}
