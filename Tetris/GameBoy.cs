using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    abstract class GameBoy
    {
        public int[,] Area { get;  set; }
        public int Score { get; protected set; }
        public int Level { get; protected set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        protected IFigureFactory FigureFactory { get; set; }
        protected FigureController figureController { get; set; }
        protected List<Figures> Figures { get; set; }
        protected DataGridView dataGridView { get; set; }

        public GameBoy(int height, int width, DataGridView dataGridView)
        {
            Figures = new List<Figures>();
            this.dataGridView = dataGridView;

            figureController = new FigureController(this);//фигуры могут двигаться
            Area = new int[height, width];
            Height = height;
            Width = width;
            Score = 0;
            Level = 1;

            for (int i = 0; i < height; i++)
            {
                Area[i, width - 1] = -1;
                Area[i, 0] = -1;
            }
            
            for (int i = 0; i < width; i++)
            {
                Area[ height - 1, i] = -1;
                Area[0, i] = -1;
            }
        }
        public abstract void Controll(int key);
    }
}
