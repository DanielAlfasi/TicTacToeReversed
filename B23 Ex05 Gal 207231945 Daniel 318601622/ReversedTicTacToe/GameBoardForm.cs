using Ex02;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReversedTicTacToe
{
    public partial class GameBoardForm : Form
    {
        private GameSettingsForm m_GameSettingsForm = new GameSettingsForm();
        private Label m_PlayerOneLabel = new Label();
        private Label m_PlayerTwoLabel = new Label();
        private Label m_PlayerOneScore = new Label();
        private Label m_PlayerTwoScore = new Label();
        private GameEngine gameEngine;
        private int m_GameBoardSize;
        private string m_PlayerOneName;
        private string m_PlayerTwoName;
        private eMark m_PlayerTurn;
        private int m_TurnsCounter = 0;


        public GameBoardForm()
        {
            bool isValidGameSettings = false;

            
            while (!isValidGameSettings)
            {
                isValidGameSettings = getGameSettings();
            }
            createGameBoard();
            createLabelsAndScores();

            this.gameEngine = new GameEngine(m_GameBoardSize, ePlayerType.Person);
            this.m_PlayerTurn = eMark.X;
            this.m_TurnsCounter = 0;
        }


        private void createGameBoard()
        {
            this.Height = m_GameBoardSize * 60;
            this.Width = m_GameBoardSize * 54;
            this.Text = "TicTacToe Game Board";

            for (int i = 0; i < m_GameBoardSize; i++)
            {
                for(int j = 0; j < m_GameBoardSize; j++)
                {
                    ButtonCell buttonCell = new ButtonCell(i, j);
                    buttonCell.Top = 50 *  (i) + 10;
                    buttonCell.Left = 50 * (j) + 10;
                    buttonCell.Click += ButtonCell_Click; // Subscribe to the Click event
                    this.Controls.Add(buttonCell);
                        
                }
            }


            this.CenterToScreen();
        }

        private void createLabelsAndScores()
        {
            m_PlayerOneLabel.Text = m_PlayerOneName + " : ";
            m_PlayerTwoLabel.Text = m_PlayerTwoName + " : ";

            m_PlayerOneScore.Text = "0";
            m_PlayerTwoScore.Text = "0";

            m_PlayerOneLabel.AutoSize = true;
            m_PlayerTwoLabel.AutoSize = true;
            m_PlayerOneScore.AutoSize = true;
            m_PlayerTwoScore.AutoSize = true;

            m_PlayerOneLabel.Location = new Point(10, this.ClientSize.Height - m_PlayerOneLabel.Height - 10);
            m_PlayerOneScore.Location = new Point(m_PlayerOneLabel.Right, this.ClientSize.Height - m_PlayerOneScore.Height - 10);
            m_PlayerTwoLabel.Location = new Point(m_PlayerOneScore.Right + 20, this.ClientSize.Height - m_PlayerTwoLabel.Height - 10);
            m_PlayerTwoScore.Location = new Point(m_PlayerTwoLabel.Right, this.ClientSize.Height - m_PlayerTwoScore.Height - 10);

            this.Controls.Add(m_PlayerOneLabel);
            this.Controls.Add(m_PlayerOneScore);
            this.Controls.Add(m_PlayerTwoLabel);
            this.Controls.Add(m_PlayerTwoScore);
        }

        private bool getGameSettings()
        {
            if (m_GameSettingsForm.ShowDialog() == DialogResult.OK)
            {
                this.m_PlayerOneName = m_GameSettingsForm.PlayerOneName;
                this.m_PlayerTwoName = m_GameSettingsForm.PlayerTwoName;
                this.m_GameBoardSize = m_GameSettingsForm.BoardSize;
                return true;
            }

            return false;
        }

        private void ButtonCell_Click(object sender, EventArgs e)
        {
            // This function will be called when a ButtonCell is clicked
            // You can add your logic here

            ButtonCell clickedButton = sender as ButtonCell; // Get the clicked button
            
            if (clickedButton.Mark == eMark.Empty)
            {
                clickedButton.Mark = m_PlayerTurn;
                if (m_PlayerTurn == eMark.O)
                {
                    m_PlayerTurn = eMark.X;
                } 
                else
                {
                    m_PlayerTurn = eMark.O;
                }


                gameEngine.PerformMove(clickedButton.RowIndex, clickedButton.ColumnIndex);
                checkGameStatus();

            }
        }

        private void checkGameStatus()
        {
            if(gameEngine.IsGameOver())
            {
                if(gameEngine.IsGameEndWithTie)
                {
                    gameEndWithTie();
                }
                else
                {
                    gameEndWithWinner();
                }
            }
        }

        private void gameEndWithTie()
        {
            DialogResult result = MessageBox.Show("Tie!\n Would you like to play another round?", "A Tie!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                gameEngine.ResetGame(); // update another round
            }
            else
            {
                this.Close();
            }
        }

        private void gameEndWithWinner()
        {
            // messege box
        }
    }
}
