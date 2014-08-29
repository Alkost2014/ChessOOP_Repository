using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chess_2
{
    class Player // Класс Игрок
    {
        private string playerName;
        public string PlayerName
        {
            get { return playerName; }
            //set { playerName = value; }
        }

        private FigureColor playerFiguresColor;
        public FigureColor PlayerFiguresColor
        {
            get { return playerFiguresColor; }
            //set { playerFiguresColor = value; }
        }

        private bool isActive;
        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

        // Массив временно!!! Лучше использовать коллекцию!!!
        private MoveCoords[] protocolRecords;
        public MoveCoords[] GetProtocolRecords()
        {
            return this.protocolRecords;
        }
        public void AddProtocolRecord(MoveCoords moveCoords)
        {
            for (int i = 0; i < this.protocolRecords.Length; i++)
            {
                if ((this.protocolRecords[i].coordsFrom.x == 0) && (this.protocolRecords[i].coordsFrom.y == 0) && 
                    (this.protocolRecords[i].coordsTo.x == 0) && (this.protocolRecords[i].coordsTo.y == 0))
                {
                    this.protocolRecords[i] = moveCoords;
                    break;
                }
            }
        }

        private int figuresCount;
        public int FiguresCount
        {
            get { return figuresCount; }
            set { figuresCount = value; }
        }

        public Player(string playerName, FigureColor playerFiguresColor)
        {
            this.playerName = playerName;
            this.playerFiguresColor = playerFiguresColor;

            if (this.playerFiguresColor == FigureColor.Green)
            {
                this.isActive = true;
            } 
            else
            {
                this.isActive = false;
            }

            this.protocolRecords = new MoveCoords[200]; // Массив временно!!! Лучше использовать коллекцию!!!
            this.figuresCount = 16;
        }

        public Figure SelectFigure(Coords currentCoords, Board board) // Выбрать фигуру
        {
            Figure selectedFigure = board[currentCoords.y - 1, currentCoords.x - 1];
            if (selectedFigure != null)
            {
                return selectedFigure;
            }
            else
            {
                return null;
            }
        }
    }
}
