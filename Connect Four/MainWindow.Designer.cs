
namespace Connect_Four
{
    partial class frnGame
    {
        //************* 0 -> white ******************************
        //************* 1 -> Red   disabled******************************
        //************* 2 -> Black disabled******************************
        //************* 3 -> white enabled******************************

        private System.Windows.Forms.MainMenu mainMenu;
        private System.Windows.Forms.MenuItem menuSettings;
        private System.Windows.Forms.MenuItem menuToggleAI;
        private System.Windows.Forms.MenuItem menuFirstMove;
        private System.Windows.Forms.MenuItem menuFirstMoveRed;
        private System.Windows.Forms.MenuItem menuFirstMoveBlack;
        private System.Windows.Forms.MenuItem menuPlayAs;
        private System.Windows.Forms.MenuItem menuPlayAsRed;
        private System.Windows.Forms.MenuItem menuPlayAsBlack;
        private System.Windows.Forms.MenuItem menuDifficulty;
        //private System.Windows.Forms.ComboBox difficultyComboBox;

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

        public System.Windows.Forms.Button[] buttons = new System.Windows.Forms.Button[42];
        public int[] colourState= new int[42];
        System.Windows.Forms.Label lblPlayer;
        System.Windows.Forms.Label lblDifficulty;
        System.Windows.Forms.Button btnAI;
        System.Windows.Forms.Button btnAIFirst;
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code edi;tor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.menuSettings = new System.Windows.Forms.MenuItem();
            this.menuToggleAI = new System.Windows.Forms.MenuItem();
            this.menuFirstMove = new System.Windows.Forms.MenuItem();
            this.menuFirstMoveRed = new System.Windows.Forms.MenuItem();
            this.menuFirstMoveBlack = new System.Windows.Forms.MenuItem();
            this.menuPlayAs = new System.Windows.Forms.MenuItem();
            this.menuPlayAsBlack = new System.Windows.Forms.MenuItem();
            this.menuPlayAsRed = new System.Windows.Forms.MenuItem();
            this.menuDifficulty = new System.Windows.Forms.MenuItem();
            //this.difficultyComboBox = new System.Windows.Forms.ComboBox();

            System.Windows.Forms.Button currentButton;
            int x = 212;
            int y = 206;
            int counter = 1;
            for (int i = 1; i < 7; i++)
            {
                for (int j = 1; j < 8; j++)
                {
                    currentButton = new System.Windows.Forms.Button();
                    currentButton.Location = new System.Drawing.Point(x, y);
                    currentButton.Name = counter.ToString();
                    currentButton.Size = new System.Drawing.Size(28, 28);
                    currentButton.TabIndex = counter;
                    currentButton.BackColor = System.Drawing.Color.White;
                    colourState[counter - 1] = 3;
                    currentButton.UseVisualStyleBackColor = true;
                    currentButton.Click += new System.EventHandler(this.buttonClick);
                    if (i > 1)
                    {
                        currentButton.Enabled = false;
                        colourState[counter - 1] = 0;
                    }
                    this.Controls.Add(currentButton);
                    buttons[counter - 1]  = currentButton;
                    x -= 34;
                    counter += 1;
                }
                x = 212;
                y -= 34;
            }

            System.Windows.Forms.Button btnReset = new System.Windows.Forms.Button();
            btnReset.Location = new System.Drawing.Point(x-18, y);
            btnReset.Size = new System.Drawing.Size(50, 28);
            btnReset.Text = "Reset";
            btnReset.Click += new System.EventHandler(this.resetClick);
            this.Controls.Add(btnReset);

            //btnAI = new System.Windows.Forms.Button();
            //btnAI.Location = new System.Drawing.Point(5, y);
            //btnAI.Size = new System.Drawing.Size(50, 28);
            //btnAI.Text = "AI: On";
            //btnAI.Click += new System.EventHandler(this.aiClick);
            //this.Controls.Add(btnAI);

            //lblDifficulty = new System.Windows.Forms.Label();
            //lblDifficulty.Location = new System.Drawing.Point(10, y + 10);
            //lblDifficulty.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            //lblDifficulty.Size = new System.Drawing.Size(50, 50);
            //lblDifficulty.Text = "Difficulty:";
            //this.Controls.Add(lblDifficulty);

            //// 
            //// difficultyComboBox
            //// 
            //this.difficultyComboBox.FormattingEnabled = true;
            //this.difficultyComboBox.Location = new System.Drawing.Point(60, y+7);
            //this.difficultyComboBox.Size = new System.Drawing.Size(30, 21);
            //this.difficultyComboBox.DataSource = new int[] { 2, 3, 4, 5, 6, 7 };
            //this.difficultyComboBox.SelectedItem = 7;
            //this.difficultyComboBox.SelectedText = "7";
            //this.difficultyComboBox.SelectedValue = 7;
            //this.difficultyComboBox.Text = "7";
            //this.difficultyComboBox.Enabled = aiState;
            //this.Controls.Add(difficultyComboBox);

            lblPlayer = new System.Windows.Forms.Label();
            lblPlayer.Location = new System.Drawing.Point(80, y+10);
            lblPlayer.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            lblPlayer.Size = new System.Drawing.Size(100, 50);
            lblPlayer.Text = "Red's Turn";
            lblPlayer.ForeColor = System.Drawing.Color.Red;
            this.Controls.Add(lblPlayer);

            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuSettings});
            // 
            // menuSettings
            // 
            this.menuSettings.Index = 0;
            this.menuSettings.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuToggleAI,
            this.menuDifficulty,
            this.menuFirstMove,
            this.menuPlayAs});
            this.menuSettings.Text = "Settings";
            // 
            // menuToggleAI
            // 
            this.menuToggleAI.Index = 0;
            this.menuToggleAI.Text = "Toggle AI";
            this.menuToggleAI.Checked = aiState;
            this.menuToggleAI.Click += new System.EventHandler(this.aiClick);
            // 
            // menuDifficulty
            //   
            this.menuDifficulty.Index = 1;
            this.menuDifficulty.Text = "AI Difficulty";
            this.menuToggleAI.Enabled = aiState;
            // 
            // menuDifficulty Items
            // 
            System.Windows.Forms.MenuItem menuItemDifficulty;
            for (int i = 3; i < 9; i+=2)
            {
                menuItemDifficulty = new System.Windows.Forms.MenuItem();
                menuItemDifficulty.Index = i-3;

                string difficultyText="";
                switch (i) {
                    case 3:
                        difficultyText = "Easy";
                        break;
                    case 5:
                        difficultyText = "Average";
                        break;
                    case 7:
                        difficultyText = "Hard";
                        break;
                    case 8:
                        difficultyText = "Master";
                        break;
                }
                
                menuItemDifficulty.Text = difficultyText;
                menuItemDifficulty.Tag = i;
                menuItemDifficulty.Click += new System.EventHandler(this.difficultyClick);
                if (i == 8) menuItemDifficulty.Checked = true;
                this.menuDifficulty.MenuItems.Add(menuItemDifficulty);
                if (i == 7) i--;
            }
            // 
            // menuFirstMove
            // 
            this.menuFirstMove.Index = 2;
            this.menuFirstMove.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuFirstMoveRed,
            this.menuFirstMoveBlack});
            this.menuFirstMove.Text = "First move";
            // 
            // menuFirstMoveRed
            // 
            this.menuFirstMoveRed.Index = 0;
            this.menuFirstMoveRed.Text = "Red";
            this.menuFirstMoveRed.Checked = !blackFirst;
            this.menuFirstMoveRed.Click += new System.EventHandler(this.moveFirstClick);
            // 
            // menuFirstMoveBlack
            // 
            this.menuFirstMoveBlack.Index = 1;
            this.menuFirstMoveBlack.Text = "Black";
            this.menuFirstMoveBlack.Checked = blackFirst;
            this.menuFirstMoveBlack.Click += new System.EventHandler(this.moveFirstClick);
            // 
            // menuPlayAs
            // 
            this.menuPlayAs.Index = 3;
            this.menuPlayAs.Text = "Play as";
            this.menuPlayAs.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuPlayAsRed,
            this.menuPlayAsBlack});
            this.menuPlayAs.Enabled = aiState;
            // 
            // menuPlayAsRed
            // 
            this.menuPlayAsRed.Index = 0;
            this.menuPlayAsRed.Text = "Red";
            this.menuPlayAsRed.Checked = !playerBlackPlayAs;
            this.menuPlayAsRed.Click += new System.EventHandler(this.playAsClick);
            // 
            // menuPlayAsBlack
            // 
            this.menuPlayAsBlack.Index = 1;
            this.menuPlayAsBlack.Text = "Black";
            this.menuPlayAsBlack.Checked = playerBlackPlayAs;
            this.menuPlayAsBlack.Click += new System.EventHandler(this.playAsClick);


            this.Menu = this.mainMenu;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.MaximizeBox = false;
            this.ClientSize = new System.Drawing.Size(247, 241);
            
            this.Name = "frnGame";
            this.Text = "Connect Four";
            this.ResumeLayout(false);

        }

        #endregion

       
    }
}

