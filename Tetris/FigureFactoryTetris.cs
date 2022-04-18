using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class FigureFactoryTetris : IFigureFactory
    {
        List<Figures> figures;
        IFigureCreator figureFromFile;
        public FigureFactoryTetris()
        {
            figureFromFile = new FigureFromFile();
            figures = new List<Figures>()
            {
                figureFromFile.CreateFigure("D:\\C#\\Tetris\\Tetris\\TFigure.txt"), //создаём фигуру
                figureFromFile.CreateFigure("D:\\C#\\Tetris\\Tetris\\LFigure.txt"), //создаём фигуру
                figureFromFile.CreateFigure("D:\\C#\\Tetris\\Tetris\\L2Figure.txt"), //создаём фигуру
                figureFromFile.CreateFigure("D:\\C#\\Tetris\\Tetris\\ZFigure.txt"), //создаём фигуру
                figureFromFile.CreateFigure("D:\\C#\\Tetris\\Tetris\\Z2Figure.txt"), //создаём фигуру
                figureFromFile.CreateFigure("D:\\C#\\Tetris\\Tetris\\KFigure.txt"), //создаём фигуру
                figureFromFile.CreateFigure("D:\\C#\\Tetris\\Tetris\\IFigure.txt") //создаём фигуру
            };
        }

        public int GetCount()//сколько фигур у нас
        {
            return figures.Count;
        }

        public Figures GetFigures(int num)//запрашиваем фигуру
        {
            return figures[num % figures.Count];
        }
    }
}
