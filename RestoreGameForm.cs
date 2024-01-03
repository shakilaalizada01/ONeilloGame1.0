using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace O_Neillo_Game
{
    public partial class RestoreGameForm : Form
    {
        private ListBox listBoxGameStates;
        private Button buttonOK;
        private List<GameSnapshot> gameStates;

        public GameSnapshot SelectedGameState { get; private set; }

        public RestoreGameForm(List<GameSnapshot> gameStates)
        {
            InitializeComponent();  // Initialize the components
            this.gameStates = gameStates;

            // Populate the ListBox with available game states
            PopulateListBox(gameStates);
        }
        private void PopulateListBox(List<GameSnapshot> savedGameStates)
        {
            listBoxGameStates.Items.Clear();

            for (int i = 0; i < savedGameStates.Count; i++)
            {
                listBoxGameStates.Items.Add($"Game State {i + 1} - {savedGameStates[i].Timestamp}");
            }
        }


        private void buttonOK_Click(object sender, EventArgs e)
        {
            // Check if an item is selected in the ListBox
            if (listBoxGameStates.SelectedIndex != -1)
            {
                // Set the SelectedGameState based on the selected index
                SelectedGameState = gameStates[listBoxGameStates.SelectedIndex];
                DialogResult = DialogResult.OK;

                // Close the form
                Close();
            }
            else
            {
                MessageBox.Show("Please select a game state.", "Error");
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void InitializeComponent()
        {
            this.listBoxGameStates = new System.Windows.Forms.ListBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxGameStates
            // 
            this.listBoxGameStates.FormattingEnabled = true;
            this.listBoxGameStates.Location = new System.Drawing.Point(13, 13);
            this.listBoxGameStates.Name = "listBoxGameStates";
            this.listBoxGameStates.Size = new System.Drawing.Size(259, 199);
            this.listBoxGameStates.TabIndex = 0;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(104, 226);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // Attach the Click event handler to the button
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // RestoreGameForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.listBoxGameStates);
            this.Name = "RestoreGameForm";
            this.Load += new System.EventHandler(this.RestoreGameForm_Load);
            this.ResumeLayout(false);
        }

        private void RestoreGameForm_Load(object sender, EventArgs e)
        {

        }

    }
}
