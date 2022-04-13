namespace Minesweeper2
{
    partial class Gameboard
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gameBoardPan = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.timerLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.gameMenu = new System.Windows.Forms.MenuStrip();
            this.gameActions = new System.Windows.Forms.ToolStripMenuItem();
            this.gameStats = new System.Windows.Forms.ToolStripMenuItem();
            this.restartGame = new System.Windows.Forms.ToolStripMenuItem();
            this.exitGame = new System.Windows.Forms.ToolStripMenuItem();
            this.helpActions = new System.Windows.Forms.ToolStripMenuItem();
            this.instructionsAction = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutAction = new System.Windows.Forms.ToolStripMenuItem();
            this.gameLenTimer = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1.SuspendLayout();
            this.gameMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // gameBoardPan
            // 
            this.gameBoardPan.AutoSize = true;
            this.gameBoardPan.BackColor = System.Drawing.SystemColors.Control;
            this.gameBoardPan.Cursor = System.Windows.Forms.Cursors.Default;
            this.gameBoardPan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameBoardPan.Location = new System.Drawing.Point(0, 24);
            this.gameBoardPan.Name = "gameBoardPan";
            this.gameBoardPan.Size = new System.Drawing.Size(512, 395);
            this.gameBoardPan.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.timerLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 419);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(512, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // timerLabel
            // 
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(39, 17);
            this.timerLabel.Text = "Time: ";
            // 
            // gameMenu
            // 
            this.gameMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameActions,
            this.helpActions});
            this.gameMenu.Location = new System.Drawing.Point(0, 0);
            this.gameMenu.Name = "gameMenu";
            this.gameMenu.Size = new System.Drawing.Size(512, 24);
            this.gameMenu.TabIndex = 0;
            this.gameMenu.Text = "menuStrip1";
            // 
            // gameActions
            // 
            this.gameActions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameStats,
            this.restartGame,
            this.exitGame});
            this.gameActions.Name = "gameActions";
            this.gameActions.Size = new System.Drawing.Size(50, 20);
            this.gameActions.Text = "Game";
            // 
            // gameStats
            // 
            this.gameStats.Name = "gameStats";
            this.gameStats.Size = new System.Drawing.Size(144, 22);
            this.gameStats.Text = "Game Stats";
            this.gameStats.Click += new System.EventHandler(this.gameStats_Click);
            // 
            // restartGame
            // 
            this.restartGame.Name = "restartGame";
            this.restartGame.Size = new System.Drawing.Size(144, 22);
            this.restartGame.Text = "Restart Game";
            this.restartGame.Click += new System.EventHandler(this.restartGame_Click);
            // 
            // exitGame
            // 
            this.exitGame.Name = "exitGame";
            this.exitGame.Size = new System.Drawing.Size(144, 22);
            this.exitGame.Text = "Exit";
            this.exitGame.Click += new System.EventHandler(this.exitGame_Click);
            // 
            // helpActions
            // 
            this.helpActions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.instructionsAction,
            this.aboutAction});
            this.helpActions.Name = "helpActions";
            this.helpActions.Size = new System.Drawing.Size(44, 20);
            this.helpActions.Text = "Help";
            // 
            // instructionsAction
            // 
            this.instructionsAction.Name = "instructionsAction";
            this.instructionsAction.Size = new System.Drawing.Size(180, 22);
            this.instructionsAction.Text = "Instructions";
            this.instructionsAction.Click += new System.EventHandler(this.instructionsAction_Click);
            // 
            // aboutAction
            // 
            this.aboutAction.Name = "aboutAction";
            this.aboutAction.Size = new System.Drawing.Size(180, 22);
            this.aboutAction.Text = "About";
            this.aboutAction.Click += new System.EventHandler(this.aboutAction_Click);
            // 
            // Gameboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(512, 441);
            this.Controls.Add(this.gameBoardPan);
            this.Controls.Add(this.gameMenu);
            this.Controls.Add(this.statusStrip1);
            this.MainMenuStrip = this.gameMenu;
            this.Name = "Gameboard";
            this.Text = "Minesweeper";
            this.Shown += new System.EventHandler(this.HideFormHandler);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.gameMenu.ResumeLayout(false);
            this.gameMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel gameBoardPan;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel timerLabel;
        private System.Windows.Forms.MenuStrip gameMenu;
        private System.Windows.Forms.ToolStripMenuItem gameActions;
        private System.Windows.Forms.ToolStripMenuItem restartGame;
        private System.Windows.Forms.ToolStripMenuItem exitGame;
        private System.Windows.Forms.ToolStripMenuItem helpActions;
        private System.Windows.Forms.ToolStripMenuItem instructionsAction;
        private System.Windows.Forms.ToolStripMenuItem aboutAction;
        private System.Windows.Forms.Timer gameLenTimer;
        private System.Windows.Forms.ToolStripMenuItem gameStats;
    }
}
