namespace O_Neillo_Game
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.PlayerMarker2 = new System.Windows.Forms.PictureBox();
            this.PlayerMarker1 = new System.Windows.Forms.PictureBox();
            this.PlayerMarker = new System.Windows.Forms.Label();
            this.pictureBoxplayer2 = new System.Windows.Forms.PictureBox();
            this.pictureBoxplayer1 = new System.Windows.Forms.PictureBox();
            this.player2token = new System.Windows.Forms.Label();
            this.player1token = new System.Windows.Forms.Label();
            this.player1name = new System.Windows.Forms.Label();
            this.player2name = new System.Windows.Forms.Label();
            this.labelassist = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerMarker2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerMarker1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxplayer2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxplayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkOrchid;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.PlayerMarker2);
            this.panel1.Controls.Add(this.PlayerMarker1);
            this.panel1.Controls.Add(this.PlayerMarker);
            this.panel1.Controls.Add(this.pictureBoxplayer2);
            this.panel1.Controls.Add(this.pictureBoxplayer1);
            this.panel1.Controls.Add(this.player2token);
            this.panel1.Controls.Add(this.player1token);
            this.panel1.Controls.Add(this.player1name);
            this.panel1.Controls.Add(this.player2name);
            this.panel1.Location = new System.Drawing.Point(61, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 90);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // PlayerMarker2
            // 
            this.PlayerMarker2.Image = global::O_Neillo_Game.Properties.Resources.toplay;
            this.PlayerMarker2.Location = new System.Drawing.Point(315, 44);
            this.PlayerMarker2.Name = "PlayerMarker2";
            this.PlayerMarker2.Size = new System.Drawing.Size(48, 41);
            this.PlayerMarker2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PlayerMarker2.TabIndex = 8;
            this.PlayerMarker2.TabStop = false;
            this.PlayerMarker2.Visible = false;
            // 
            // PlayerMarker1
            // 
            this.PlayerMarker1.BackColor = System.Drawing.Color.Transparent;
            this.PlayerMarker1.BackgroundImage = global::O_Neillo_Game.Properties.Resources.toplay;
            this.PlayerMarker1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PlayerMarker1.Image = global::O_Neillo_Game.Properties.Resources.toplay;
            this.PlayerMarker1.InitialImage = global::O_Neillo_Game.Properties.Resources.Icon;
            this.PlayerMarker1.Location = new System.Drawing.Point(25, 44);
            this.PlayerMarker1.Name = "PlayerMarker1";
            this.PlayerMarker1.Size = new System.Drawing.Size(48, 41);
            this.PlayerMarker1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PlayerMarker1.TabIndex = 7;
            this.PlayerMarker1.TabStop = false;
            this.PlayerMarker1.Visible = false;
            this.PlayerMarker1.WaitOnLoad = true;
            // 
            // PlayerMarker
            // 
            this.PlayerMarker.AutoSize = true;
            this.PlayerMarker.Location = new System.Drawing.Point(229, 55);
            this.PlayerMarker.Name = "PlayerMarker";
            this.PlayerMarker.Size = new System.Drawing.Size(0, 13);
            this.PlayerMarker.TabIndex = 6;
            this.PlayerMarker.Click += new System.EventHandler(this.PlayerMarker_Click);
            // 
            // pictureBoxplayer2
            // 
            this.pictureBoxplayer2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxplayer2.BackgroundImage")));
            this.pictureBoxplayer2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBoxplayer2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxplayer2.Image")));
            this.pictureBoxplayer2.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxplayer2.InitialImage")));
            this.pictureBoxplayer2.Location = new System.Drawing.Point(216, 22);
            this.pictureBoxplayer2.Name = "pictureBoxplayer2";
            this.pictureBoxplayer2.Size = new System.Drawing.Size(31, 33);
            this.pictureBoxplayer2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxplayer2.TabIndex = 5;
            this.pictureBoxplayer2.TabStop = false;
            // 
            // pictureBoxplayer1
            // 
            this.pictureBoxplayer1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxplayer1.BackgroundImage")));
            this.pictureBoxplayer1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBoxplayer1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxplayer1.Image")));
            this.pictureBoxplayer1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxplayer1.InitialImage")));
            this.pictureBoxplayer1.Location = new System.Drawing.Point(142, 21);
            this.pictureBoxplayer1.Name = "pictureBoxplayer1";
            this.pictureBoxplayer1.Size = new System.Drawing.Size(32, 34);
            this.pictureBoxplayer1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxplayer1.TabIndex = 4;
            this.pictureBoxplayer1.TabStop = false;
            // 
            // player2token
            // 
            this.player2token.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.player2token.AutoSize = true;
            this.player2token.BackColor = System.Drawing.Color.Transparent;
            this.player2token.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player2token.Location = new System.Drawing.Point(255, 23);
            this.player2token.Name = "player2token";
            this.player2token.Size = new System.Drawing.Size(44, 25);
            this.player2token.TabIndex = 3;
            this.player2token.Text = "2 X";
            // 
            // player1token
            // 
            this.player1token.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.player1token.AutoSize = true;
            this.player1token.BackColor = System.Drawing.Color.Transparent;
            this.player1token.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player1token.Location = new System.Drawing.Point(94, 22);
            this.player1token.Name = "player1token";
            this.player1token.Size = new System.Drawing.Size(44, 25);
            this.player1token.TabIndex = 2;
            this.player1token.Text = "2 X";
            // 
            // player1name
            // 
            this.player1name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.player1name.AutoSize = true;
            this.player1name.BackColor = System.Drawing.Color.White;
            this.player1name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.player1name.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player1name.Location = new System.Drawing.Point(17, 21);
            this.player1name.Name = "player1name";
            this.player1name.Size = new System.Drawing.Size(2, 20);
            this.player1name.TabIndex = 1;
            // 
            // player2name
            // 
            this.player2name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.player2name.AutoSize = true;
            this.player2name.BackColor = System.Drawing.Color.White;
            this.player2name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.player2name.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player2name.Location = new System.Drawing.Point(305, 21);
            this.player2name.Name = "player2name";
            this.player2name.Size = new System.Drawing.Size(2, 20);
            this.player2name.TabIndex = 0;
            // 
            // labelassist
            // 
            this.labelassist.BackColor = System.Drawing.Color.SpringGreen;
            this.labelassist.Font = new System.Drawing.Font("Modern No. 20", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelassist.ForeColor = System.Drawing.Color.DarkOrchid;
            this.labelassist.Location = new System.Drawing.Point(61, 596);
            this.labelassist.Name = "labelassist";
            this.labelassist.Size = new System.Drawing.Size(400, 51);
            this.labelassist.TabIndex = 4;
            this.labelassist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelassist.Click += new System.EventHandler(this.labelassist_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(522, 665);
            this.Controls.Add(this.labelassist);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerMarker2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerMarker1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxplayer2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxplayer1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label PlayerMarker;
        private System.Windows.Forms.PictureBox pictureBoxplayer2;
        private System.Windows.Forms.PictureBox pictureBoxplayer1;
        private System.Windows.Forms.Label player2token;
        private System.Windows.Forms.Label player1token;
        private System.Windows.Forms.Label player1name;
        private System.Windows.Forms.Label player2name;
        private System.Windows.Forms.PictureBox PlayerMarker2;
        private System.Windows.Forms.PictureBox PlayerMarker1;
        private System.Windows.Forms.Label labelassist;
    }
}

