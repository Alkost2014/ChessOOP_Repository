using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chess_2
{
    class Pawn : Figure // Производный класс Пешка
    {
        // Пока лишнее!!!
        //public Pawn(string figureImage, FigureColor figureColor, Coords figureCoords) : base(figureImage, figureColor, figureCoords)
        //{

        //}

        public Pawn(string figureImage, FigureColor figureColor) : base(figureImage, figureColor)
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
            if (inputIsFirstPlayer)
            {
                if ((newCoords.x != currentCoords.x) || (newCoords.y <= 2) || ((newCoords.y - currentCoords.y) != 1) || (newCoords.y > 8))
                {
                    return false;
                }
            }
            else
            {
                if ((newCoords.x != currentCoords.x) || (newCoords.y >= 7) || ((currentCoords.y - newCoords.y) != 1) || (newCoords.y < 1))
                {
                    return false;
                }
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
                board[newCoords.y - 1, newCoords.x - 1] = new Pawn("п", FigureColor.Green);
            }
            else
            {
                board[currentCoords.y - 1, currentCoords.x - 1] = null;
                board[newCoords.y - 1, newCoords.x - 1] = new Pawn("п", FigureColor.Red);
            }
        }
    }
}
