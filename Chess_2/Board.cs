using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chess_2
{
    class Board // Класс Доска
    {
        private int sizeX, sizeY;
        private Figure[,] figures;

        public Figure this[int i, int j]
        {
            get { return figures[i, j]; }
            set { figures[i, j] = value; }
        }

        public Board(int sizeX, int sizeY)
        {
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            this.figures = new Figure[sizeX, sizeY];
            Init();
        }
        
        
        private void Init() // Заполнить доску фигурами (начальная расстановка)
        {
            // Пешки
            Pawn pawn;
            for (int i = 0; i < sizeX; i++)
            {
                // Белые
                pawn = new Pawn("п", FigureColor.Green);
                AddFigure(pawn, i, 1);
                // Черные
                pawn = new Pawn("п", FigureColor.Red);
                AddFigure(pawn, i, 6);
            }

            // Ладьи
            Rook rook;
            // Белые
            rook = new Rook("л", FigureColor.Green);
            AddFigure(rook, 0, 0);
            rook = new Rook("л", FigureColor.Green);
            AddFigure(rook, 7, 0);
            // Черные
            rook = new Rook("л", FigureColor.Red);
            AddFigure(rook, 0, 7);
            rook = new Rook("л", FigureColor.Red);
            AddFigure(rook, 7, 7);

            // Кони
            Horse horse;
            // Белые
            horse = new Horse("к", FigureColor.Green);
            AddFigure(horse, 1, 0);
            horse = new Horse("к", FigureColor.Green);
            AddFigure(horse, 6, 0);
            // Черные
            horse = new Horse("к", FigureColor.Red);
            AddFigure(horse, 1, 7);
            horse = new Horse("к", FigureColor.Red);
            AddFigure(horse, 6, 7);

            // Слоны
            Elephant elephant;
            // Белые
            elephant = new Elephant("с", FigureColor.Green);
            AddFigure(elephant, 2, 0);
            elephant = new Elephant("с", FigureColor.Green);
            AddFigure(elephant, 5, 0);
            // Черные
            elephant = new Elephant("с", FigureColor.Red);
            AddFigure(elephant, 2, 7);
            elephant = new Elephant("с", FigureColor.Red);
            AddFigure(elephant, 5, 7);

            // Ферзи
            Queen queen;
            // Белый
            queen = new Queen("Ф", FigureColor.Green);
            AddFigure(queen, 3, 0);
            // Черный
            queen = new Queen("Ф", FigureColor.Red);
            AddFigure(queen, 3, 7);

            // Короли
            King king;
            // Белый
            king = new King("К", FigureColor.Green);
            AddFigure(king, 4, 0);
            // Черный
            king = new King("К", FigureColor.Red);
            AddFigure(king, 4, 7);
        }

        private void AddFigure(Figure figure, int x, int y) // Добавить фигуру
        {
            this.figures[y, x] = figure;
        }

        public void Show() // Показать доску с фигурами
        {
            Console.Clear();

            // На экран строки массива выводятся в обратном порядке.
            for (int i = this.sizeY - 1; i >= 0; i--)
            {
                for (int j = 0; j < this.sizeX; j++)
                {
                    if (this.figures[i, j] != null)
                    {
                        Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), this.figures[i, j].FigureColor.ToString());
                        Console.Write(" " + this.figures[i, j].FigureImage + " ");
                    } 
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" " + 0 + " ");
                    }
                }

                Console.WriteLine();
            }

            Console.ResetColor();
        }

        public void Clear() // Очистить доску
        {
            throw new NotImplementedException();
        }
    }
}
