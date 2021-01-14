using Ozow.GameOfLife.Domain.Enums;
using Ozow.GameOfLife.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ozow.GameOfLife.Domain.Services.Abstract
{
  public interface IConwaysGameOfLifeService
  {
    /// <summary>
    /// Applies the Rules of Life to a board
    /// </summary>
    /// <param name="currentBoard"></param>
    /// <returns></returns>
    Board Generate(Board currentBoard);

    /// <summary>
    /// Applies the Rules of Life to a cell
    /// </summary>
    /// <param name="currentCellState"></param>
    /// <param name="numberOfAliveNeighbors"></param>
    /// <returns></returns>
    State GenerateCellState(State currentCellState, int numberOfAliveNeighbors);
  }
}
