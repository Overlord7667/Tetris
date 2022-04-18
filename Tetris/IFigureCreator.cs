using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    interface IFigureCreator
    {
        Figures CreateFigure(string filePath);
    }
}
