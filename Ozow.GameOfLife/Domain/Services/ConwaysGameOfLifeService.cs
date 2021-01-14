using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ozow.GameOfLife.Domain.Enums;
using Ozow.GameOfLife.Domain.Models;
using Ozow.GameOfLife.Domain.Services.Abstract;

namespace Ozow.GameOfLife.Domain.Services
{
  public class ConwaysGameOfLifeService: IConwaysGameOfLifeService
  {
    public Board Generate(Board currentBoard)
    {
      var nextGeneration = currentBoard.Grid;

      // Loop through every cell 
      for (var row = 1; row < currentBoard.Length - 1; row++)
        for (var column = 1; column < currentBoard.Breadth - 1; column++)
        {
            // find your alive neighbors
          var aliveNeighbors = 0;
          for (var i = -1; i <= 1; i++)
          {
              for (var j = -1; j <= 1; j++)
              {
                  aliveNeighbors += currentBoard.Grid[row + i, column + j] == State.Alive ? 1 : 0;
              }
          }

          var currentCell = currentBoard.Grid[row, column];

          // The cell needs to be subtracted 
          // from its neighbors as it was  
          // counted before 
          aliveNeighbors -= currentCell == State.Alive ? 1 : 0;

          nextGeneration[row, column] = GenerateCellState(currentCell, aliveNeighbors);
        }
      currentBoard.Update(nextGeneration);
      return currentBoard;
    }

    public State GenerateCellState(State currentCellState, int aliveNeighbors)
    {
      switch (currentCellState)
      {
        case State.Alive:
            if (aliveNeighbors < 2 || aliveNeighbors > 3) return State.Dead; // Cell dies due to being alone or over population 
            break;
        case State.Dead:
            if (aliveNeighbors == 3) return State.Alive; // A new cell is born 
            break;

        default:
            throw new ArgumentOutOfRangeException(nameof(currentCellState), currentCellState, null);
      }

      return currentCellState; // Stays the same
    }
  }
}
