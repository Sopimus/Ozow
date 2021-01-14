using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Ozow.GameOfLife.Domain.Enums;

namespace Ozow.GameOfLife.Domain.Models
{
    public class Board
    {
        public int Length { get; private set; }
        public int Breadth { get; private set; }

        public State[,] Grid { get; private set; }

        public Board(int length, int breadth)
        {
            Length = length;
            Breadth = breadth;
            Grid = new State[Length, Breadth];

            var random = new Random();
            for (var row = 0; row < length; row++)
            {
                for (var column = 0; column < breadth; column++)
                {
                    Grid[row, column] = (State)random.Next(1, 3);
                }
            }
        }

        public void Update(State[,] newGrid)
        {
            Grid = newGrid;
        }
    }
}
