using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class FigureController
    {
        GameBoy gameBoy;
        public FigureController(GameBoy gameBoy)
        {
            this.gameBoy = gameBoy;
        }
        public int CanMove(Figures figures, int Left, int Top)//Возвращает цифры
        {
            int ft = figures.Top;           
            int fl = figures.Left;
            int layer = figures.Layer;
            for (int i = 0; i < figures.N; i++)
            {
                for (int j = 0; j < figures.N; j++)
                {
                    if (figures.Array[i, j, layer] != 0)
                    {
                        if (!(ft + Top + i >= 0                      //проверка на предел массива                                   
                            && ft + Top + i < gameBoy.Height
                            && fl + Left + j >= 0
                            && fl + Left + j < gameBoy.Width))
                            return -1;
                        if (gameBoy.Area[ft + i + Top, fl + j + Left] != 0 &&  //проверяем на другие фигуры
                            gameBoy.Area[ft + i + Top, fl + j + Left] != figures.Array[i, j, layer])
                        {
                            return gameBoy.Area[ft + i + Top, fl + j + Left];//во что врезался
                        }
                    }
                }
            }
            return 0;
        }

        public void Move(Figures figures, int Left, int Top)
        {
            int ft = figures.Top;
            int fl = figures.Left;
            int layer = figures.Layer;

            for (int i = 0; i < figures.N; i++)//Обнуляет предыдущее положение
            {
                for (int j = 0; j < figures.N; j++)
                {
                    if(figures.Array[i,j,layer]!=0)
                    if(gameBoy.Area[i + ft, j + fl] == figures.Array[i, j, layer])
                    gameBoy.Area[i + ft, j + fl] = 0;
                }
            }
            figures.Left += Left;//пододвинули
            figures.Top += Top;
            for (int i = 0; i < figures.N; i++)//заного нарисовали
            {
                for (int j = 0; j < figures.N; j++)
                {
                    if (figures.Array[i, j, layer] != 0)
                    gameBoy.Area[i + figures.Top,j+figures.Left] = figures.Array[i, j, layer];
                }
            }
        }
    }
}
