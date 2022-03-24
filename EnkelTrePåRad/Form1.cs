namespace EnkelTrePåRad
{
    public partial class GameBoard : Form
    {
        bool turn = true; // true = X turn, false = O turn.
        int turn_count = 0;

        public GameBoard()
        {
            InitializeComponent();
        }

        private void menuItemAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Laget av Christian Hansen", "Tic Tac Toe (Tre På Rad) portefølje applikasjon");
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button gameButton = (Button)sender;
            if (turn)
                gameButton.Text = "X";
            else
                gameButton.Text = "O";

            if(turn)
                gameButton.BackColor = Color.Green;
            else
                gameButton.BackColor = Color.Red;

            turn = !turn;
            gameButton.Enabled = false;
            turn_count++;

            checkForWinner();
        }

        private void checkForWinner()
        {
            bool isAWinner = false;

            // Checks horizontal.
            if((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
            {
                isAWinner = true;
            }
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
            {
                isAWinner = true;
            }
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
            {
                isAWinner = true;
            }

            // Checks vertical.
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
            {
                isAWinner = true;
            }
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
            {
                isAWinner = true;
            }
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
            {
                isAWinner = true;
            }

            // Checks diagonal.
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
            {
                isAWinner = true;
            }
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))
            {
                isAWinner = true;
            }


            if (isAWinner)
            {
                disableButtons();
                string winner = "";
                if (turn)
                    winner = "O";
                else
                    winner = "X";

                MessageBox.Show(winner + " Wins!", "TicTacToe");
            }
            else
            {
                if (turn_count == 9)
                    MessageBox.Show("This game is a draw!", "TicTacToe");
            }
        } // End Check for Winner!!

        private void disableButtons()
        {
            try
            {
                foreach (Control checkButton in Controls)
                {
                    Button disableButtons = (Button)checkButton;
                    disableButtons.Enabled = false;
                }
            }
            catch { }
        }

        private void menuItemNewGame_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}