using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chess_2
{
    static class Helper
    {
        //
    }

    enum FigureColor
    {
        Green,
        Red
    }

    struct Coords
    {
        public int x;
        public int y;

        public Coords(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    struct MoveCoords
    {
        public Coords coordsFrom;
        public Coords coordsTo;

        public MoveCoords(Coords coordsFrom, Coords coordsTo)
        {
            this.coordsFrom = coordsFrom;
            this.coordsTo = coordsTo;
        }
    }
}
