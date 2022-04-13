namespace Minesweeper2
{
    partial class About
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
            this.abtNameLbl = new System.Windows.Forms.Label();
            this.nameLbl = new System.Windows.Forms.Label();
            this.abtWhenLbl = new System.Windows.Forms.Label();
            this.whenLbl = new System.Windows.Forms.Label();
            this.abtClassLbl = new System.Windows.Forms.Label();
            this.classLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // abtNameLbl
            // 
            this.abtNameLbl.AutoSize = true;
            this.abtNameLbl.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.abtNameLbl.Location = new System.Drawing.Point(23, 26);
            this.abtNameLbl.Name = "abtNameLbl";
            this.abtNameLbl.Size = new System.Drawing.Size(79, 23);
            this.abtNameLbl.TabIndex = 0;
            this.abtNameLbl.Text = "Made by:";
            // 
            // nameLbl
            // 
            this.nameLbl.AutoSize = true;
            this.nameLbl.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nameLbl.Location = new System.Drawing.Point(108, 26);
            this.nameLbl.Name = "nameLbl";
            this.nameLbl.Size = new System.Drawing.Size(90, 23);
            this.nameLbl.TabIndex = 1;
            this.nameLbl.Text = "Ben Bittles";
            // 
            // abtWhenLbl
            // 
            this.abtWhenLbl.AutoSize = true;
            this.abtWhenLbl.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.abtWhenLbl.Location = new System.Drawing.Point(12, 94);
            this.abtWhenLbl.Name = "abtWhenLbl";
            this.abtWhenLbl.Size = new System.Drawing.Size(97, 23);
            this.abtWhenLbl.TabIndex = 2;
            this.abtWhenLbl.Text = "When made:";
            // 
            // whenLbl
            // 
            this.whenLbl.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.whenLbl.Location = new System.Drawing.Point(108, 84);
            this.whenLbl.Name = "whenLbl";
            this.whenLbl.Size = new System.Drawing.Size(103, 62);
            this.whenLbl.TabIndex = 3;
            this.whenLbl.Text = "December 1st";
            this.whenLbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // abtClassLbl
            // 
            this.abtClassLbl.AutoSize = true;
            this.abtClassLbl.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.abtClassLbl.Location = new System.Drawing.Point(12, 162);
            this.abtClassLbl.Name = "abtClassLbl";
            this.abtClassLbl.Size = new System.Drawing.Size(95, 23);
            this.abtClassLbl.TabIndex = 4;
            this.abtClassLbl.Text = "What class:";
            // 
            // classLbl
            // 
            this.classLbl.AutoSize = true;
            this.classLbl.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.classLbl.Location = new System.Drawing.Point(122, 162);
            this.classLbl.Name = "classLbl";
            this.classLbl.Size = new System.Drawing.Size(76, 23);
            this.classLbl.TabIndex = 5;
            this.classLbl.Text = "CS 3020";
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(221, 229);
            this.Controls.Add(this.classLbl);
            this.Controls.Add(this.abtClassLbl);
            this.Controls.Add(this.whenLbl);
            this.Controls.Add(this.abtWhenLbl);
            this.Controls.Add(this.nameLbl);
            this.Controls.Add(this.abtNameLbl);
            this.Name = "About";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label abtNameLbl;
        private System.Windows.Forms.Label nameLbl;
        private System.Windows.Forms.Label abtWhenLbl;
        private System.Windows.Forms.Label whenLbl;
        private System.Windows.Forms.Label abtClassLbl;
        private System.Windows.Forms.Label classLbl;
    }
}