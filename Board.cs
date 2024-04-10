using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulationProject
{
    internal class Board
    {
        /// <summary>
        /// This class deals with creating the board and managing it
        /// </summary>

        string[,] board;
        Size gridSize = new Size(12, 12); // 12 cells wide and tall
        Size cellSize = new Size(40, 40); // each cell will be 40px wide/tall
        Point currentPoint;

        private void createGrid()
        {
            for (int row = 0; row < gridSize.Width; row++)
            {
                for (int col = 0; col < gridSize.Height; col++)
                {
                    board[row, col] = "";
                }
            }
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}
