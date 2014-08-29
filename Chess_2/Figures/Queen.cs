using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chess_2
{
    class Queen : Figure // Производный класс Ферзь
    {
        // Пока лишнее!!!
        //public Queen(string figureImage, FigureColor figureColor, Coords figureCoords) : base(figureImage, figureColor, figureCoords)
        //{

        //}

        public Queen(string figureImage, FigureColor figureColor) : base(figureImage, figureColor)
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

            if (!(((newCoords.x == currentCoords.x) || (newCoords.y == currentCoords.y) ||
                (Math.Abs(newCoords.x - currentCoords.x) == Math.Abs(newCoords.y - currentCoords.y))) && 
                ((newCoords.y >= 1) && (newCoords.y <= 8) && (newCoords.x >= 1) && (newCoords.x <= 8))))
            {
                return false;
            }

            // --------------------------------------------------------------------------------------------------------
            
            // Проверка по прямым линиям

            if ((newCoords.x == currentCoords.x) && (newCoords.y > currentCoords.y))
            {
                for (int i = currentCoords.y + 1; i <= newCoords.y; i++)
                {
                    if (board[i - 1, newCoords.x - 1] != null)
                    {
                        return false;
                    }
                }

                return true; // !!!
            }

            if ((newCoords.x == currentCoords.x) && (newCoords.y < currentCoords.y))
            {
                for (int i = newCoords.y; i < currentCoords.y; i++)
                {
                    if (board[i - 1, newCoords.x - 1] != null)
                    {
                        return false;
                    }
                }

                return true; // !!!
            }

            if ((newCoords.y == currentCoords.y) && (newCoords.x > currentCoords.x))
            {
                for (int i = currentCoords.x + 1; i <= newCoords.x; i++)
                {
                    if (board[newCoords.y - 1, i - 1] != null)
                    {
                        return false;
                    }
                }

                return true; // !!!
            }

            if ((newCoords.y == currentCoords.y) && (newCoords.x < currentCoords.x))
            {
                for (int i = newCoords.x; i < currentCoords.x; i++)
                {
                    if (board[newCoords.y - 1, i - 1] != null)
                    {
                        return false;
                    }
                }

                return true; // !!!
            }

            // --------------------------------------------------------------------------------------------------------

            // Проверка по диагоналям

            if ((newCoords.x < currentCoords.x) && (newCoords.y < currentCoords.y))
            {
                for (int i = newCoords.x; i < currentCoords.x; i++)
                {
                    if (board[newCoords.y - 1, i - 1] != null)
                    {
                        return false;
                    }

                    newCoords.y++;
                }

                return true; // !!!
            }

            if ((newCoords.x < currentCoords.x) && (newCoords.y > currentCoords.y))
            {
                for (int i = newCoords.x; i < currentCoords.x; i++)
                {
                    if (board[newCoords.y - 1, i - 1] != null)
                    {
                        return false;
                    }

                    newCoords.y--;
                }

                return true; // !!!
            }

            if ((newCoords.x > currentCoords.x) && (newCoords.y > currentCoords.y))
            {
                currentCoords.y++;
                for (int i = currentCoords.x + 1; i <= newCoords.x; i++)
                {
                    if (board[currentCoords.y - 1, i - 1] != null)
                    {
                        return false;
                    }

                    currentCoords.y++;
                }

                return true; // !!!
            }

            if ((newCoords.x > currentCoords.x) && (newCoords.y < currentCoords.y))
            {
                currentCoords.y--;
                for (int i = currentCoords.x + 1; i <= newCoords.x; i++)
                {
                    if (board[currentCoords.y - 1, i - 1] != null)
                    {
                        return false;
                    }

                    currentCoords.y--;
                }

                return true; // !!!
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
                board[newCoords.y - 1, newCoords.x - 1] = new Queen("Ф", FigureColor.Green);
            }
            else
            {
                board[currentCoords.y - 1, currentCoords.x - 1] = null;
                board[newCoords.y - 1, newCoords.x - 1] = new Queen("Ф", FigureColor.Red);
            }
        }
    }
}
