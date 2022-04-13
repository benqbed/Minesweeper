namespace Minesweeper2
{
    partial class StartMenu
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
            this.welcomeLbl = new System.Windows.Forms.Label();
            this.chooseBoardSize = new System.Windows.Forms.ComboBox();
            this.qLbl = new System.Windows.Forms.Label();
            this.startBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // welcomeLbl
            // 
            this.welcomeLbl.AutoSize = true;
            this.welcomeLbl.Font = new System.Drawing.Font("Comic Sans MS", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.welcomeLbl.Location = new System.Drawing.Point(15, 9);
            this.welcomeLbl.Name = "welcomeLbl";
            this.welcomeLbl.Size = new System.Drawing.Size(379, 40);
            this.welcomeLbl.TabIndex = 0;
            this.welcomeLbl.Text = "Welcome to Minesweeper!";
            // 
            // chooseBoardSize
            // 
            this.chooseBoardSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chooseBoardSize.FormattingEnabled = true;
            this.chooseBoardSize.Items.AddRange(new object[] {
            "10 X 10",
            "14 X 14",
            "20 X 20"});
            this.chooseBoardSize.Location = new System.Drawing.Point(137, 142);
            this.chooseBoardSize.Name = "chooseBoardSize";
            this.chooseBoardSize.Size = new System.Drawing.Size(121, 23);
            this.chooseBoardSize.TabIndex = 1;
            // 
            // qLbl
            // 
            this.qLbl.AutoSize = true;
            this.qLbl.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.qLbl.Location = new System.Drawing.Point(24, 105);
            this.qLbl.Name = "qLbl";
            this.qLbl.Size = new System.Drawing.Size(355, 23);
            this.qLbl.TabIndex = 2;
            this.qLbl.Text = "What size would you like the gameboard to be?";
            // 
            // startBtn
            // 
            this.startBtn.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.startBtn.Location = new System.Drawing.Point(141, 193);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(110, 33);
            this.startBtn.TabIndex = 3;
            this.startBtn.Text = "Start Game";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // StartMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 268);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.qLbl);
            this.Controls.Add(this.chooseBoardSize);
            this.Controls.Add(this.welcomeLbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "StartMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StartMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label welcomeLbl;
        private System.Windows.Forms.ComboBox chooseBoardSize;
        private System.Windows.Forms.Label qLbl;
        private System.Windows.Forms.Button startBtn;
    }
}