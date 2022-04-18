using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Figures
    {
        public int[,,] Array { get; private set; }// массив фигуры
        public int N { get; private set; }//ширина и высота
        public int Count { get; private set; }//колличество слоёв, глубина
        public int Top { get; set; }
        public int Left { get; set; }
        public int Layer { get; private set; }
        public void NextLayer()
        {
            Layer++;
            Layer %= Count;
        }
        public Figures(int[,,]array,int n,int count)
        {
            Array = array;
            N = n;
            Count = count;
            Top = 0;
            Left = 0;
        }
    }
}
