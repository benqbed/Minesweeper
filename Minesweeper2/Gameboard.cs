using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
#pragma warning disable CS8602
#pragma warning disable CS8618
#pragma warning disable CS8622
#pragma warning disable CS8602
#pragma warning disable CS0252
#pragma warning disable CS8600

namespace Minesweeper2
{
    public partial class Gameboard : Form
    {
        //Declare globals neccesary for application
        int upTickTimerCount = 0;
        Random rand = new Random();
        int buttonSize;
        int fontSize;

        //Declare arrays and lists for referencing game elements
        Button[,] buttons;
        Panel[,] panels;
        Label[,] labels;

        List<Button> buttonsList = new List<Button>();
        List<Button> mines = new List<Button>();
        
        public Gameboard()
        {
            InitializeComponent();
            RunGame();
        }

        /// <summary>
        /// Runs the game
        /// </summary>
        private void RunGame()
        {
            //Open a start menu to prompt user what kind of game they want
            StartMenu startMenu = new StartMenu();
            startMenu.Show();
            startMenu.BtnClick += StartHandler;
            startMenu.FormClosed += MenuExitHandler;
        }
        /// <summary>
        /// Closes the whole program when the menu is closed by the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuExitHandler(object sender, EventArgs e)
        {
            //Checks to see if the gameboard is visible before closing.
            //Shouldn't be neccessary but just wanted to be safe
            if (this.Visible == true)
            {
                return;
            }
            else if (this.Visible == false)
            {
                this.Close();
            }
        }
        /// <summary>
        /// Determines which gameboard user selected and builds the according board
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void StartHandler(object sender, EventArgs e)
        {
            //Get the board type that the user selected and build the appropriate game
            StartMenu form = (StartMenu)sender;
            if (form.Controls.OfType<ComboBox>().First().SelectedItem == "10 X 10")
            {
                tenBoard();
            }
            if (form.Controls.OfType<ComboBox>().First().SelectedItem == "14 X 14")
            {
                fourteenBoard();
            }
            if (form.Controls.OfType<ComboBox>().First().SelectedItem == "20 X 20")
            {
                twentyBoard();
            }
            this.Show();
            this.CenterToScreen();
            //Close the start menu
            form.Close();
        }
        /// <summary>
        /// Builds a 10x10 game board
        /// </summary>
        public void tenBoard()
        {
            //Set button, panel, and label to lists and set their size
            buttons = new Button[10,10];
            panels = new Panel[10,10];
            labels = new Label[10,10];
            buttonSize = 64;
            fontSize = 18;

            //Open gameboard on center of screen
            this.StartPosition = FormStartPosition.CenterScreen;

            //Set timer interval and subscribe it to a tick handler
            gameLenTimer.Interval = 1000;
            gameLenTimer.Tick += UpTickHandler;

            //Load gameboard components onto gameform and place mines
            LoadBoard();
            PlaceMines(10);
            
            //Start game timer
            gameLenTimer.Start();
        }
        /// <summary>
        /// Builds a 14x14 gameboard
        /// </summary>
        public void fourteenBoard()
        {
            //Set button, panel, and label to lists and set their size
            buttons = new Button[14,14];
            panels = new Panel[14, 14];
            labels = new Label[14, 14];
            buttonSize = 48;
            fontSize = 16;

            //Open gameboard on center of screen
            this.StartPosition = FormStartPosition.CenterScreen;

            //Set timer interval and subscribe it to a tick handler
            gameLenTimer.Interval = 1000;
            gameLenTimer.Tick += UpTickHandler;

            //Load gameboard components onto gameform and place mines
            LoadBoard();
            PlaceMines(40);

            //Start game timer
            gameLenTimer.Start();
        }
        /// <summary>
        /// Builds a 20x20 gameboard
        /// </summary>
        public void twentyBoard()
        {
            //Set button, panel, and label to lists and set their size
            buttons = new Button[20,20];
            panels = new Panel[20, 20];
            labels = new Label[20, 20];
            buttonSize = 32;
            fontSize = 10;

            //Open gameboard on center of screen
            this.StartPosition = FormStartPosition.CenterScreen;

            //Set timer interval and subscribe it to a tick handler
            gameLenTimer.Interval = 1000;
            gameLenTimer.Tick += UpTickHandler;

            //Load gameboard components onto gameform and place mines
            LoadBoard();
            PlaceMines(99);

            //Start game timer
            gameLenTimer.Start();
        }
        /// <summary>
        /// Loads gameboard onto form
        /// </summary>
        private void LoadBoard()
        {
            //Create panels with button and label controls on them for
            //the given size of gameboard
            for (int row = 0; row < buttons.GetLength(0); row++)
            {
                for (int col = 0; col < buttons.GetLength(1); col++)
                {
                    Panel tempPanel = LoadPanel(row, col);

                    Label minesLbl = LoadLabel(row, col, fontSize);

                    //Add button to button list and button array
                    Button tempBtn = LoadButton();
                    buttons[row, col] = tempBtn;
                    buttonsList.Add(tempBtn);

                    //Add the button and label to panel
                    tempPanel.Controls.Add(minesLbl);
                    tempPanel.Controls.Add(tempBtn);

                    //Make sure number of mines is below button
                    minesLbl.SendToBack();

                    //Add panel and label to respective arrays
                    panels[row, col] = tempPanel;
                    labels[row, col] = minesLbl;

                    //Add panel to gameboard
                    gameBoardPan.Controls.Add(tempPanel);
                }
            }
        }
        /// <summary>
        /// Returns a new button
        /// </summary>
        /// <returns></returns>
        public Button LoadButton()
        {
            //Set properties for button
            Button newBtn = new Button();
            newBtn.Size = new Size(buttonSize, buttonSize);
            newBtn.BackColor = Color.DarkGray;
            newBtn.FlatStyle = FlatStyle.Popup;
            newBtn.Tag = 0;

            //Subscribe button to left and right click events
            newBtn.Click += new EventHandler(OnClickHandler);
            newBtn.MouseDown += new MouseEventHandler(RightClickHandler);

            return newBtn;
        }
        /// <summary>
        /// Returns a new label
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public Label LoadLabel(int row, int col, int fSize)
        {
            //Set label properties
            Label newLabel = new Label();
            newLabel.Font = new Font("Comic Sans MS", fSize);
            newLabel.Text = 0.ToString();
            newLabel.Tag = ($"{row},{col}");
            newLabel.AutoSize = false;
            newLabel.TextAlign = ContentAlignment.MiddleCenter;
            newLabel.Dock = DockStyle.Fill;

            return newLabel;
        }
        /// <summary>
        /// Returns new panel
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public Panel LoadPanel(int row, int col)
        {
            //Set panel properties
            Panel newPanel = new Panel();
            newPanel.BackColor = Color.LightGray;
            newPanel.Size = new Size(buttonSize, buttonSize);
            newPanel.Location = new Point(col * buttonSize, row * buttonSize);

            return newPanel;
        }
        /// <summary>
        /// Places mines on gameboard and sets surrounding panels text for number of nearby mines
        /// </summary>
        /// <param name="numOfMines"></param>
        private void PlaceMines(int numOfMines)
        {
            for (int i = 0; i < numOfMines; i++)
            {
                bool flag = true;
                while (flag)
                {
                    //Generate random coordinates to place mine
                    int j = rand.Next(0, buttons.GetLength(0));
                    int k = rand.Next(0, buttons.GetLength(1));

                    //Check if mine already exists in spot
                    if (Convert.ToInt32(buttons[j, k].Tag) == 0)
                    {
                        //Set button tag and the button to mine list
                        buttons[j, k].Tag = "10";
                        mines.Add(buttons[j, k]);

                        //Increment the text in the surrounding panels to show how many
                        //nearby mines there are
                        int maxLen = buttons.GetLength(0) - 1;
                        if (j + 1 <= maxLen)
                        {
                            int temp = Convert.ToInt32(labels[(j + 1), k].Text);
                            temp += 1;
                            labels[(j + 1), k].Text = temp.ToString();
                        }
                        if (k + 1 <= maxLen)
                        {
                            int temp = Convert.ToInt32(labels[j, (k + 1)].Text);
                            temp += 1;
                            labels[j, (k + 1)].Text = temp.ToString();
                        }
                        if (j - 1 >= 0)
                        {
                            int temp = Convert.ToInt32(labels[(j - 1), k].Text);
                            temp += 1;
                            labels[(j - 1), k].Text = temp.ToString();
                        }
                        if (k - 1 >= 0)
                        {
                            int temp = Convert.ToInt32(labels[j, (k - 1)].Text);
                            temp += 1;
                            labels[j, (k - 1)].Text = temp.ToString();
                        }
                        if (j + 1 <= maxLen & k + 1 <= maxLen)
                        {
                            int temp = Convert.ToInt32(labels[(j + 1), (k + 1)].Text);
                            temp += 1;
                            labels[(j + 1), (k + 1)].Text = temp.ToString();
                        }
                        if (j - 1 >= 0 & k - 1 >= 0)
                        {
                            int temp = Convert.ToInt32(labels[(j - 1), (k - 1)].Text);
                            temp += 1;
                            labels[(j - 1), (k - 1)].Text = temp.ToString();
                        }
                        if (j - 1 >= 0 & k + 1 <= maxLen)
                        {
                            int temp = Convert.ToInt32(labels[(j - 1), (k + 1)].Text);
                            temp += 1;
                            labels[(j - 1), (k + 1)].Text = temp.ToString();
                        }
                        if (j + 1 <= maxLen & k - 1 >= 0)
                        {
                            int temp = Convert.ToInt32(labels[(j + 1), (k - 1)].Text);
                            temp += 1;
                            labels[(j + 1), (k - 1)].Text = temp.ToString();
                        }
                        flag = false;
                    }
                }
            }
        }
        /// <summary>
        /// Handles user button right click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void RightClickHandler(object sender, MouseEventArgs e)
        {
            Button clickedBtn = (Button)sender;

            //Change button background color when right clicked
            if (e.Button == MouseButtons.Right)
            {
                if (clickedBtn.BackColor != Color.Red)
                {
                    clickedBtn.BackColor = Color.Red;
                }
                else if (clickedBtn.BackColor == Color.Red)
                {
                    clickedBtn.BackColor = Color.DarkGray;
                }
            }
        }
        /// <summary>
        /// Saves the time the game took
        /// </summary>
        public void SaveTime()
        {            string existingTimes;
            //Create stats file if it doesnt exist
            if (!File.Exists("times.csv"))
            {
                using (StreamWriter sw = File.CreateText("times.csv"));
            }

            //Access time stats file and add new score to file
            using (StreamReader getScore = new StreamReader("times.csv"))
            {
                existingTimes = getScore.ReadLine();
                getScore.Close();
            }
            using (StreamWriter saveScore = File.AppendText("times.csv"))
            {
                if (existingTimes == null)
                {
                    saveScore.Write($"{upTickTimerCount}");
                }
                else
                {
                    saveScore.Write($",{upTickTimerCount}");
                }
                saveScore.Close();
            }
            
        }
        /// <summary>
        /// Saves the number of wins and losses user has
        /// </summary>
        /// <param name="winOrLose"></param>
        public void SaveWinLoss(int winOrLose)
        {
            //Access win/loss stats file and add the current score
            StreamReader getScore = new StreamReader("winLoss.csv");
            string[] score = getScore.ReadLine().Split(',');
            getScore.Close();
            
            if (winOrLose == 0)
            {
                File.WriteAllText("winLoss.csv", $"{Convert.ToInt32(score[0])},{Convert.ToInt32(score[1]) + 1}");
            }
            else if (winOrLose == 1)
            {
                File.WriteAllText("winLoss.csv", $"{Convert.ToInt32(score[0]) + 1},{Convert.ToInt32(score[1])}");
            }
        }
        /// <summary>
        /// Handles user button left click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnClickHandler(object sender, EventArgs e)
        {
            Button clickedBtn = (Button)sender;

            //Check if player hit mine and if so offer to restart
            if (clickedBtn.Tag == "10")
            {
                //Save stats
                SaveTime();
                SaveWinLoss(0);
                MineHit();
            }
            else
            {
                var btnParent = clickedBtn.Parent;

                //Set the label font colors. Not sure why im doing this
                //down here but I am I guess
                SetPanelColors(btnParent);

                //Remove button from panel
                btnParent.Controls.Remove(clickedBtn);
                buttonsList.Remove(clickedBtn);

                //Check to see if user has identified all mines
                if (mines.Count == buttonsList.Count)
                {
                    //Save stats
                    gameLenTimer.Stop();
                    SaveTime();
                    SaveWinLoss(1);

                    //Prompt user to restart
                    DialogResult usrResult = MessageBox.Show("You found all the mines! Would you like to restart?", "", MessageBoxButtons.YesNo);
                    if (usrResult == DialogResult.Yes)
                    {
                        Application.Restart();
                    }
                    if (usrResult == DialogResult.No)
                    {
                        Application.Exit();
                    }
                }
                //Check to see if user clicked panel with no nearby mines
                if (btnParent.Controls.OfType<Label>().First().Text == "0")
                {
                    clickThroughZeros(btnParent);
                }
            }
        }
        /// <summary>
        /// Handles when user hits a mine
        /// </summary>
        public void MineHit()
        {
            gameLenTimer.Stop();

            //Show where all mines are on the board indicated by an explanation mark
            foreach (Button mine in mines)
            {
                mine.Font = new Font("Comic Sans MS", fontSize);
                mine.Text = "!";
            }

            //Prompt user to restart
            DialogResult usrResult = MessageBox.Show("You hit a mine! Would you like to restart?", "", MessageBoxButtons.YesNo);
            if (usrResult == DialogResult.Yes)
            {
                Application.Restart();
            }
            if (usrResult == DialogResult.No)
            {
                Application.Exit();
            }
        }
        /// <summary>
        /// Sets the color of text for different numbers on panels
        /// </summary>
        /// <param name="pan"></param>
        public void SetPanelColors(Control pan)
        {
            switch (pan.Controls.OfType<Label>().First().Text)
            {
                case "0":
                    pan.Controls.OfType<Label>().First().ForeColor = Color.Green;
                    break;
                case "1":
                    pan.Controls.OfType<Label>().First().ForeColor = Color.Blue;
                    break;
                case "2":
                    pan.Controls.OfType<Label>().First().ForeColor = Color.SeaGreen;
                    break;
                case "3":
                    pan.Controls.OfType<Label>().First().ForeColor = Color.MediumPurple;
                    break;
                case "4":
                    pan.Controls.OfType<Label>().First().ForeColor = Color.Magenta;
                    break;
                case "5":
                    pan.Controls.OfType<Label>().First().ForeColor = Color.LightGoldenrodYellow;
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Clicks through all nearby zeros when user clicks a 0 mine panel
        /// </summary>
        /// <param name="pan"></param>
        public void clickThroughZeros(Control pan)
        {
            string[] nums = { "0", "1", "2", "3", "4", "5", "6", "7", "8" };

            //Get panel coordinates
            string panelCoord = pan.Controls.OfType<Label>().First().Tag.ToString();
            var coords = panelCoord.Split(',');
            int panRow = Convert.ToInt32(coords[0]);
            int panCol = Convert.ToInt32(coords[1]);

            //Check every surrounding panel to see if it is also not a mine
            //and if so click it.
            //I really didn't know how to simplify this and I feel like there
            //has to be a better solution
            if (panCol + 1 <= buttons.GetLength(0) - 1)
            {
                foreach (String minesNum in nums)
                {
                    if (panels[panRow, panCol + 1].Controls.OfType<Label>().FirstOrDefault().Text == minesNum)
                    {
                        try
                        {
                            OnClickHandler(panels[panRow, panCol + 1].Controls.OfType<Button>().First(), new EventArgs());
                        }
                        catch { }
                    }
                }
            }
            if (panCol - 1 >= 0)
            {
                foreach (String minesNum in nums)
                {
                    if (panels[panRow, panCol - 1].Controls.OfType<Label>().FirstOrDefault().Text == minesNum)
                    {
                        try
                        {
                            OnClickHandler(panels[panRow, panCol - 1].Controls.OfType<Button>().First(), new EventArgs());
                        }
                        catch { }
                    }
                }
            }
            if (panRow + 1 <= buttons.GetLength(1) - 1)
            {
                foreach (String minesNum in nums)
                {
                    if (panels[panRow + 1, panCol].Controls.OfType<Label>().FirstOrDefault().Text == minesNum)
                    {
                        try
                        {
                            OnClickHandler(panels[panRow + 1, panCol].Controls.OfType<Button>().First(), new EventArgs());
                        }
                        catch { }
                    }
                }
            }
            if (panRow - 1 >= 0)
            {
                foreach (String minesNum in nums)
                {
                    if (panels[panRow - 1, panCol].Controls.OfType<Label>().FirstOrDefault().Text == minesNum)
                    {
                        try
                        {
                            OnClickHandler(panels[panRow - 1, panCol].Controls.OfType<Button>().First(), new EventArgs());
                        }
                        catch { }
                    }
                }
            }
            if (panCol + 1 <= buttons.GetLength(0) - 1 & panRow + 1 <= buttons.GetLength(1) - 1)
            {
                foreach (String minesNum in nums)
                {
                    if (panels[panRow + 1, panCol + 1].Controls.OfType<Label>().FirstOrDefault().Text == minesNum)
                    {
                        try
                        {
                            OnClickHandler(panels[panRow + 1, panCol + 1].Controls.OfType<Button>().First(), new EventArgs());
                        }
                        catch { }
                    }
                }
            }
            if (panCol + 1 <= buttons.GetLength(0) - 1 & panRow - 1 >= 0)
            {
                foreach (String minesNum in nums)
                {
                    if (panels[panRow - 1, panCol + 1].Controls.OfType<Label>().FirstOrDefault().Text == minesNum)
                    {
                        try
                        {
                            OnClickHandler(panels[panRow - 1, panCol + 1].Controls.OfType<Button>().First(), new EventArgs());
                        }
                        catch { }
                    }
                }
            }
            if (panCol - 1 >= 0 & panRow + 1 <= buttons.GetLength(0) - 1)
            {
                foreach (String minesNum in nums)
                {
                    if (panels[panRow + 1, panCol - 1].Controls.OfType<Label>().FirstOrDefault().Text == minesNum)
                    {
                        try
                        {
                            OnClickHandler(panels[panRow + 1, panCol - 1].Controls.OfType<Button>().First(), new EventArgs());
                        }
                        catch { }
                    }
                }
            }
            if (panCol - 1 >= 0 & panRow - 1 >= 0)
            {
                foreach (String minesNum in nums)
                {
                    if (panels[panRow - 1, panCol - 1].Controls.OfType<Label>().FirstOrDefault().Text == minesNum)
                    {
                        try
                        {
                            OnClickHandler(panels[panRow - 1, panCol - 1].Controls.OfType<Button>().First(), new EventArgs());
                        }
                        catch { }
                    }
                }
            }
        }
        /// <summary>
        /// Handles game timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void UpTickHandler(object sender, EventArgs e)
        {
            //Update game timer and it's label
            upTickTimerCount++;
            timerLabel.Text = "Elapsed Time: " + upTickTimerCount;
        }
        /// <summary>
        /// Shows user gamestats
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gameStats_Click(object sender, EventArgs e)
        {
            //Pause timer
            int averageTime;
            gameLenTimer.Stop();

            //Check if user has stats. If so show them, otherwise tell them to play
            StreamReader getTime = new StreamReader("times.csv");
            if (getTime.ReadLine() == null)
            {
                MessageBox.Show("You don't have any stats yet! Play a game to save your stats!");
                return;
            }
            getTime.Close();

            //Get average player time
            averageTime = GetPlayerTimes();

            //Access game stats and display them to user
            StreamReader getScore = new StreamReader("winLoss.csv");
            string[] ratioStr = getScore.ReadLine().Split(',');
            getScore.Close();

            MessageBox.Show($"Average Game Time: {averageTime} seconds\nWin/Loss Ratio: {ratioStr[0]} Wins/{ratioStr[1]} Losses");

            //Unpause game timer once window is closed
            gameLenTimer.Start();
        }
        /// <summary>
        /// Get the average time per game
        /// </summary>
        /// <returns></returns>
        public int GetPlayerTimes()
        {
            int totalTime = 0;
            int averageTime;

            //Access time stats file and add all times to average
            StreamReader getTime = new StreamReader("times.csv");
            string[] timeStr = getTime.ReadLine().Split(',');
            foreach (string num in timeStr)
            {
                totalTime += Convert.ToInt32(num);
            }
            getTime.Close();

            //Average game time and return average time
            averageTime = totalTime / timeStr.Count();
            return averageTime;
        }
        /// <summary>
        /// Restarts the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void restartGame_Click(object sender, EventArgs e)
        {
            //Pause game and prompt user to restart
            gameLenTimer.Stop();
            DialogResult usrResult = MessageBox.Show("Are you sure you want to restart?", "", MessageBoxButtons.YesNo);
            if (usrResult == DialogResult.Yes)
            {
                Application.Restart();
            }

            //If user doesn't restart, restart timer
            gameLenTimer.Start();
        }
        /// <summary>
        /// Closes the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitGame_Click(object sender, EventArgs e)
        {
            //Pause game and prompt user to exit
            gameLenTimer.Stop();
            DialogResult usrResult = MessageBox.Show("Are you sure you want to exit?", "", MessageBoxButtons.YesNo);
            if (usrResult == DialogResult.Yes)
            {
                Application.Exit();
            }

            //If user doesn't exit, restart timer
            gameLenTimer.Start();
        }
        /// <summary>
        /// Hides the gameboard form when it's drawn to screen so it can load before being displayed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HideFormHandler(object sender, EventArgs e)
        {
            this.Hide();
        }
        /// <summary>
        /// Shows the instructions window for the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void instructionsAction_Click(object sender, EventArgs e)
        {
            //Pause game timer and display instructions form
            gameLenTimer.Stop();
            Instructions instructions = new Instructions();
            instructions.Show();
            //Start the timer when the instructions form is closed
            instructions.FormClosed += TimerStartHandler;
        }
        /// <summary>
        /// Shows the about window for the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutAction_Click(object sender, EventArgs e)
        {
            //Pause timer and display about form
            gameLenTimer.Stop();
            About about = new About();
            about.Show();
            //Start the timer when the instructions form is closed
            about.FormClosed += TimerStartHandler;
        }
        /// <summary>
        /// Starts the timer after the instructions or about window have been closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerStartHandler(object sender, EventArgs e)
        {
            //Hear me out

            //I know this is crazy to believe

            //But this starts the timer again
            gameLenTimer.Start();
        }
    }
}