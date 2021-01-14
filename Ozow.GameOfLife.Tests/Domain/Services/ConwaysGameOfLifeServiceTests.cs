using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Ozow.GameOfLife.Domain.Enums;
using Ozow.GameOfLife.Domain.Services;
using Ozow.GameOfLife.Domain.Services.Abstract;

namespace Ozow.GameOfLife.Tests.Domain.Services
{
  public class ConwaysGameOfLifeServiceTests
  {
    private IConwaysGameOfLifeService _ConwaysGameOfLifeService;

    [SetUp]
    public void Setup()
    {
      _ConwaysGameOfLifeService = new ConwaysGameOfLifeService();
    }

    [TestCase(0)]
    [TestCase(1)]
    public void GenerateCellState_WhenLiveCellHasLessThanTwoLiveNeighbors_Dies(int liveNeighbors)
    {
      // Any live cell with fewer than two live neighbors dies.
      // Arrange
      State currentState = State.Alive;

      // Act
      State result = _ConwaysGameOfLifeService.GenerateCellState(currentState, liveNeighbors);

      // Assert
      Assert.AreEqual(State.Dead, result);
    }

    [TestCase(2)]
    [TestCase(3)]
    public void GenerateCellState_WhenLiveCellHasTwoOrThreeLiveNeighbors_Lives(int liveNeighbors)
    {
      // Any live cell with two or three live neighbors lives.
      // Arrange
      State currentState = State.Alive;

      // Act
      State result = _ConwaysGameOfLifeService.GenerateCellState(currentState, liveNeighbors);

      // Assert
      Assert.AreEqual(State.Alive, result);
    }

    [TestCase(4)]
    [TestCase(5)]
    [TestCase(6)]
    [TestCase(7)]
    [TestCase(8)]
    public void GenerateCellState_WhenLiveCellHasMoreThanThreeLiveNeighbors_Dies(int liveNeighbors)
    {
      // Any live cell with more than 3 neighbors dies (over-crowding)
      // Arrange
      State currentCell = State.Alive;

      // Act
      currentCell = _ConwaysGameOfLifeService.GenerateCellState(currentCell, liveNeighbors);

      // Assert
      Assert.AreEqual(State.Dead, currentCell);
    }

    [TestCase(3)]
    public void GenerateCellState_WhenDeadCellHasExactlyThreeLiveNeighbors_Lives(int liveNeighbors)
    {
      // Any dead cell with exactly three live neighbors becomes a live cell.
      // Arrange
      State currentState = State.Dead;

      // Act
      State result = _ConwaysGameOfLifeService.GenerateCellState(currentState, liveNeighbors);

      // Assert
      Assert.AreEqual(State.Alive, result);
    }

    [TestCase(0)]
    [TestCase(1)]
    [TestCase(2)]
    public void GenerateCellState_WhenDeadCellHasLessThanThreeLiveNeighbors_Dies(int liveNeighbors)
    {
      // Any dead cell with exactly three live neighbors becomes a live cell.
      // Arrange
      State currentState = State.Dead;

      // Act
      State result = _ConwaysGameOfLifeService.GenerateCellState(currentState, liveNeighbors);

      // Assert
      Assert.AreEqual(State.Dead, result);
    }

    [TestCase(4)]
    [TestCase(5)]
    [TestCase(6)]
    [TestCase(7)]
    [TestCase(8)]
    public void GenerateCellState_WhenDeadCellHasMoreThanThreeLiveNeighbors_Dies(int liveNeighbors)
    {
      // Any dead cell with exactly three live neighbors becomes a live cell.
      // Arrange
      State currentState = State.Dead;

      // Act
      State result = _ConwaysGameOfLifeService.GenerateCellState(currentState, liveNeighbors);

      // Assert
      Assert.AreEqual(State.Dead, result);
    }
  }
}
