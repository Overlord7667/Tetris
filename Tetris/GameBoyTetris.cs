using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    class GameBoyTetris : GameBoy //механика тетриса
    {
        Random random;
        Timer timer;
        public GameBoyTetris(DataGridView dataGridView, int height = 22, int width = 12) : base(height, width, dataGridView)
        {
            timer = new Timer();
            timer.Interval = 50;
            timer.Tick += Timer_Tick;
            random = new Random();
            FigureFactory = new FigureFactoryTetris();
            Figures.Add(FigureFactory.GetFigures(random.Next(FigureFactory.GetCount())));
            Figures[0].Left = Width / 2 - Figures[0].N / 2;//Появление фигуры в центре
            Figures[0].Top = 1;//Появление фигуры в верху.
            figureController.Move(Figures[0], 0, 0);//рисуем фигуру
                                                    // ShowInGrid.ShowGrid(dataGridView, this);//Обновление таблицы
            timer.Enabled = true;
        }

        private void Clear()
        {
            for (int i = 0; i < Figures[0].Count - 1; i++)//Проверка на поворот
                Figures[0].NextLayer();

            for (int i = 0; i < Figures[0].N; i++)//фиксирует фигуру
                for (int j = 0; j < Figures[0].N; j++)
                {
                    if (Figures[0].Array[i, j, Figures[0].Layer] != 0)
                        Area[Figures[0].Top + i, Figures[0].Left + j] = 0;//фигура которую не можем двигать
                }
            Figures[0].NextLayer();
        }
        private void Rotate()
        {
            Figures[0].NextLayer();
            if (figureController.CanMove(Figures[0], 0, 0) == 0)
            {
                Clear();
                figureController.Move(Figures[0], 0, 0);

            }
            else
            {
                for (int i = 0; i < Figures[0].Count - 1; i++)//проверка на поворот
                    Figures[0].NextLayer();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (figureController.CanMove(Figures[0], 0, 1) == 0)
                figureController.Move(Figures[0], 0, 1);
            else
            {
                for (int i = 0; i < Figures[0].N; i++)//фиксирует фигуру
                    for (int j = 0; j < Figures[0].N; j++)
                    {
                        if (Figures[0].Array[i, j, Figures[0].Layer] != 0)
                            Area[Figures[0].Top + i, Figures[0].Left + j] = 10;//фигура которую не можем двигать
                    }
                Figures[0] = (FigureFactory.GetFigures(random.Next(FigureFactory.GetCount())));
                Figures[0].Left = Width / 2 - Figures[0].N / 2;//Появление фигуры в центре
                Figures[0].Top = 1;//Появление фигуры в верху.
                figureController.Move(Figures[0], 0, 0);//рисуем фигуру
            }
            ShowInGrid.ShowGrid(dataGridView, this);//Обновление таблицы
        }

        public override void Controll(int key)
        {
            switch (key)
            {
                case 1:
                    //if (figureController.CanMove(Figures[0], 0, -1) == 0)
                    //    figureController.Move(Figures[0], 0, -1);
                    Rotate();
                    break;//вверх
                case 2:
                    if (figureController.CanMove(Figures[0], 0, 1) == 0)
                        figureController.Move(Figures[0], 0, 1);
                    break;//вниз
                case 3:
                    if (figureController.CanMove(Figures[0], 1, 0) == 0)
                        figureController.Move(Figures[0], 1, 0);
                    break;//вправо
                case 4:
                    if (figureController.CanMove(Figures[0], -1, 0) == 0)
                        figureController.Move(Figures[0], -1, 0);
                    break;//влево

            }
            ShowInGrid.ShowGrid(dataGridView, this);
        }
    }
}
