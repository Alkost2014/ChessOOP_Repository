using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chess_2
{
    abstract class Figure // Базовый класс Фигура
    {
        private string figureImage;
        public string FigureImage
        {
            get { return figureImage; }
            //set { figureImage = value; }
        }
        
        private FigureColor figureColor;
        public FigureColor FigureColor
        {
            get { return figureColor; }
            //set { figureColor = value; }
        }

        // Пока лишнее!!!
        //private Coords figureCoords;
        //public Coords FigureCoords
        //{
        //    get { return figureCoords; }
        //    set { figureCoords = value; }
        //}

        // Пока лишнее!!!
        //protected Figure(string figureImage, FigureColor figureColor, Coords figureCoords)
        //{
        //    this.figureImage = figureImage;
        //    this.figureColor = figureColor;
        //    this.figureCoords = figureCoords;
        //}

        protected Figure(string figureImage, FigureColor figureColor)
        {
            this.figureImage = figureImage;
            this.figureColor = figureColor;
        }

        // Абстрактные методы базового класса
        // Проверить на правильность начальной позиции выбранной фигуры
        public abstract bool IsValidStartPosition(bool inputIsFirstPlayer, Coords currentCoords, Board board);
        // Проверить на правильность конечной позиции выбранной фигуры
        public abstract bool IsValidEndPosition(bool inputIsFirstPlayer, Coords currentCoords, Coords newCoords, Board board);
        // Проверить на занятость конечной позиции выбранной фигуры
        public abstract bool IsBusyEndPosition(Coords newCoords, Board board);
        // Сделать ход выбранной фигурой
        public abstract void Move(Coords currentCoords, Coords newCoords, bool inputIsFirstPlayer, Board board);
    }   
}
