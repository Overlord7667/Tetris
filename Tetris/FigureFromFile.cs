using System;
using System.IO;

namespace Tetris
{
    class FigureFromFile : IFigureCreator
    {
        public Figures CreateFigure(string filePath)
        {
            FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate);
            StreamReader reader = new StreamReader(fileStream);

            int n = Convert.ToInt32(reader.ReadLine());
            int count = Convert.ToInt32(reader.ReadLine());

            int[,,] buffer = new int[n, n, count];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    buffer[i, j, 0] = reader.Read()-48;

            for (int i = 0; i < count-1; i++)
                Rotate(buffer, n, i);

            fileStream.Close();
            return new Figures(buffer,n,count);//создаём фигуру
        }

        void Rotate(int[,,] m, int n, int layer)//Поворачивает фигуру
        {
            
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    m[i, j,layer+1] = m[n - j - 1, i,layer];
            
        }

    }
}
