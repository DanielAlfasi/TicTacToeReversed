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
    public partial class GameSettingsForm : Form
    {
        public GameSettingsForm()
        {
            InitializeComponent();
        }


        private void player2CheckBox_Clicked(object sender, EventArgs e)
        {
            if (this.Player2TextBox.Enabled == false)
            {
                this.Player2TextBox.Text = string.Empty;
                this.Player2TextBox.Enabled = true;
                this.Player2TextBox.Focus();
            }
            else
            {
                this.Player2TextBox.Enabled = false;
                this.Player2TextBox.Text = "[Computer]";
            }

        }


        private void RowsNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            this.ColsNumericUpDown.Value = this.RowsNumericUpDown.Value;
        }

        private void ColsNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            this.RowsNumericUpDown.Value = this.ColsNumericUpDown.Value;
        }

        public string PlayerOneName
        {
            get { return this.Player1TextBox.Text; }
        }

        public string PlayerTwoName
        {
            get { return this.Player2TextBox.Text; }
        }

        public int BoardSize
        {
            get { return int.Parse(this.RowsNumericUpDown.Text); }

        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
