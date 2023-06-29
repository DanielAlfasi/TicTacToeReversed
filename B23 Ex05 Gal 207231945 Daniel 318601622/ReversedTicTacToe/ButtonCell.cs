using Ex02;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReversedTicTacToe
{
    public sealed partial class ButtonCell : Button
    {
        private eMark m_Mark;
        private readonly int r_ColumnIndex;
        private readonly int r_RowIndex;

        public ButtonCell(int i_RowIndex, int i_ColumnIndex)
        {
            this.r_ColumnIndex = i_ColumnIndex;
            this.r_RowIndex = i_RowIndex;
            this.m_Mark = eMark.Empty;
            this.Height = 50;
            this.Width = 50;
            this.Text = string.Empty;
            this.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        }

        public eMark Mark
        { 
            get { return this.m_Mark; } 
            set 
            { 
                this.m_Mark = value;
                this.Text = value.ToString();
            }
        }

        public int RowIndex
        {
            get { return this.r_RowIndex; }
        }

        public int ColumnIndex
        {
            get { return this.r_ColumnIndex; }
        }


    }
}
