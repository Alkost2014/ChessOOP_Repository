using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chess_2
{
    class Program
    {
        private static Board board;
        private const int max = 8;
        private static Coords currentCoords = new Coords();
        private static Coords newCoords = new Coords();
        private static Player whitePlayer, blackPlayer;
        private static Figure selectedFigure;

        private static void Main(string[] args)
        {
            StartGame();
        }

        private static void StartGame()
        {
            whitePlayer = new Player("Player 1", FigureColor.Green);
            blackPlayer = new Player("Player 2", FigureColor.Red);

            board = new Board(max, max);

            StartAction();
        }

        // ----------------------------------------------------------------------------------------------------------

        private static void StartAction()
        {
            bool isError = false;
            bool isBusy = false;

            while (true)
            {
                board.Show();

                Console.WriteLine();
                Console.WriteLine("0 - Выход из программы.");

                if (isError)
                {
                    Console.WriteLine("Недопустимые координаты! Попробуйте еще раз...");
                    isError = false;
                }

                if (isBusy)
                {
                    //Console.WriteLine("Ход невозможен! Находится фигура соперника! Попробуйте сделать ход другой фигурой...");
                    Console.WriteLine("Ход невозможен! Находится другая фигура! Попробуйте сделать другой ход...");
                    isBusy = false;
                }

                if (whitePlayer.IsActive)
                {
                    Console.WriteLine("Ваш ход (игрок №1).");
                }
                else
                {
                    Console.WriteLine("Ваш ход (игрок №2).");
                }

                Console.Write("Начальная позиция: ");
                string positionFrom = Console.ReadLine();
                if (positionFrom == "0")
                    return; // Выход из программы!!!

                if (!ParseCoords(positionFrom, ref currentCoords))
                {
                    isError = true;
                    continue;
                }

                selectedFigure = whitePlayer.SelectFigure(currentCoords, board);
                if (selectedFigure == null)
                {
                    isError = true;
                    continue;
                }

                if (!selectedFigure.IsValidStartPosition(whitePlayer.IsActive, currentCoords, board))
                {
                    isError = true;
                    continue;
                }

                Console.Write("Конечная позиция: ");
                string positionTo = Console.ReadLine();
                if (positionTo == "0")
                    return; // Выход из программы!!!

                if (!ParseCoords(positionTo, ref newCoords))
                {
                    isError = true;
                    continue;
                }

                if (!selectedFigure.IsValidEndPosition(whitePlayer.IsActive, currentCoords, newCoords, board))
                {
                    isError = true;
                    continue;
                }
                
                if (selectedFigure.IsBusyEndPosition(newCoords, board))
                {
                    isBusy = true;
                    continue;
                }

                selectedFigure.Move(currentCoords, newCoords, whitePlayer.IsActive, board);

                if (CheckEndOfGame())
                {
                    break; // Конец игры!!!
                }

                ChangePlayers(); // Сменить игроков.
            }

            board.Show();
            Console.WriteLine();
            Console.WriteLine("Конец игры!!! Для выхода из программы нажмите Enter...");
            Console.ReadKey();
        }

        private static bool ParseCoords(string inputPosition, ref Coords coords)
        {
            string[] inputCoords = inputPosition.Split(' ');
            try
            {
                coords.x = int.Parse(inputCoords[0]);
                coords.y = int.Parse(inputCoords[1]);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // Проверка на конец игры (в разработке)!!!
        private static bool CheckEndOfGame()
        {
            // Сохранение сделанного хода игрока
            MoveCoords protocolRecord = new MoveCoords(currentCoords, newCoords);

            if (whitePlayer.IsActive)
            {
                whitePlayer.AddProtocolRecord(protocolRecord);
            }
            else
            {
                blackPlayer.AddProtocolRecord(protocolRecord);
            }

            // В разработке!!!

            return false;
        }

        private static void ChangePlayers()
        {
            whitePlayer.IsActive = !whitePlayer.IsActive;
            blackPlayer.IsActive = !blackPlayer.IsActive;
        }
    }
}
