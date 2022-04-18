using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    interface IFigureFactory
    {
        Figures GetFigures(int num);

        int GetCount();
    }
}
