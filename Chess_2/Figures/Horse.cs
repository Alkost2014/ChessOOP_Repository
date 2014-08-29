using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chess_2
{
    class Horse : Figure // Производный класс Конь
    {
        // Пока лишнее!!!
        //public Horse(string figureImage, FigureColor figureColor, Coords figureCoords) : base(figureImage, figureColor, figureCoords)
        //{

        //}

        public Horse(string figureImage, FigureColor figureColor) : base(figureImage, figureColor)
        {

        }
        
        // Переопределенные методы базового класса
        public override bool IsValidStartPosition(bool inputIsFirstPlayer, Coords currentCoords, Board board)
        {
            if (inputIsFirstPlayer)
            {
                if ((board[currentCoords.y - 1, currentCoords.x - 1] == null) || (board[currentCoords.y - 1, currentCoords.x - 1].FigureColor != FigureColor.Green))
                {
                    return false;
                }
            }
            else
            {
                if ((board[currentCoords.y - 1, currentCoords.x - 1] == null) || (board[currentCoords.y - 1, currentCoords.x - 1].FigureColor != FigureColor.Red))
                {
                    return false;
                }
            }

            return true;
        }

        public override bool IsValidEndPosition(bool inputIsFirstPlayer, Coords currentCoords, Coords newCoords, Board board)
        {
            if ((newCoords.x == currentCoords.x) && (newCoords.y == currentCoords.y))
            {
                return false;
            }

            if ((newCoords.x == currentCoords.x) || (newCoords.y == currentCoords.y) ||
                (((Math.Abs(newCoords.x - currentCoords.x) != 1) || (Math.Abs(newCoords.y - currentCoords.y) != 2)) &&
                (((Math.Abs(newCoords.x - currentCoords.x) != 2) || (Math.Abs(newCoords.y - currentCoords.y) != 1)))) || 
                (newCoords.y < 1) || (newCoords.y > 8) || (newCoords.x < 1) || (newCoords.x > 8))
            {
                return false;
            }

            return true;
        }

        public override bool IsBusyEndPosition(Coords newCoords, Board board)
        {
            if (board[newCoords.y - 1, newCoords.x - 1] != null)
            {
                return true;
            }

            return false;
        }

        public override void Move(Coords currentCoords, Coords newCoords, bool inputIsFirstPlayer, Board board)
        {
            if (inputIsFirstPlayer)
            {
                board[currentCoords.y - 1, currentCoords.x - 1] = null;
                board[newCoords.y - 1, newCoords.x - 1] = new Horse("к", FigureColor.Green);
            }
            else
            {
                board[currentCoords.y - 1, currentCoords.x - 1] = null;
                board[newCoords.y - 1, newCoords.x - 1] = new Horse("к", FigureColor.Red);
            }
        }
    }
}
