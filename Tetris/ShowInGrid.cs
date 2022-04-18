using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    static class ShowInGrid
    {
        static public void ShowGrid(DataGridView dataGridView1, GameBoy gameBoy)
        {
            for (int i = 0; i < gameBoy.Height; i++)
            {
                for (int j = 0; j < gameBoy.Width; j++)
                {
                    if (gameBoy.Area[i, j] == -1)
                        dataGridView1[j, i].Style.BackColor = Color.Black;
                    else if (gameBoy.Area[i, j] == 0)
                        dataGridView1[j, i].Style.BackColor = Color.White;
                    else
                        dataGridView1[j, i].Style.BackColor = Color.Red;
                }
            }
        }
    }
}
