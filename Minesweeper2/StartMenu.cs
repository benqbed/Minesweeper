using System;
using System.Windows.Forms;

namespace Minesweeper2
{
    public partial class StartMenu : Form
    {
        public StartMenu()
        {
            InitializeComponent();
        }

        public event EventHandler BtnClick;

        private void startBtn_Click(object sender, EventArgs e)
        {
            if (BtnClick != null)
            {
                BtnClick(this, null);
            }
        }
    }
}
