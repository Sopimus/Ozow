using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Ozow.GameOfLife.Domain.Enums;
using Ozow.GameOfLife.Domain.Models;
using Ozow.GameOfLife.Domain.Services;
using Ozow.GameOfLife.Domain.Services.Abstract;

namespace Ozow.Client
{
  public class GameOfLifeProgram
  {
    private readonly IConwaysGameOfLifeService _ConwaysGameOfLifeService;

    public GameOfLifeProgram(IConwaysGameOfLifeService conwaysGameOfLifeService)
    {
      _ConwaysGameOfLifeService = conwaysGameOfLifeService;
    }

    public void Execute()
    {
      Console.OutputEncoding = Encoding.Unicode; // Using Unicode characters to render the board
      string command = "";
      while (command != "Q" && command != "q")
      {
        Console.Clear();

        Console.WriteLine("Please configure the board.");
        var length = AskForNumericValue("Set the length of the board.");
        var breadth = AskForNumericValue("Set the breadth of the board.");
        var numberOfGenerations = AskForNumericValue("Set number of generations.");

        var board = new Board(length, breadth);

        Console.Clear();

        // Displaying the board 
        for (var i = 0; i < numberOfGenerations; i++)
        {
          PrintBoard(board);
          board = _ConwaysGameOfLifeService.Generate(board);
        }

        Console.WriteLine("Simulation done. Press Q to exit or  any key to run another simulation.");
        command = Console.ReadLine();        
      }
    }

    private static int AskForNumericValue(string message)
    {
      Console.WriteLine(message);
      var value = Console.ReadLine();

      var parsed = int.TryParse(value, out var units);

      return parsed ? units : AskForNumericValue(message);
    }

    private static void PrintBoard(Board board)
    {
      var stringBuilder = new StringBuilder();
      for (var row = 0; row < board.Length; row++)
      {
        for (var column = 0; column < board.Breadth; column++)
        {
          var cell = board.Grid[row, column];
          stringBuilder.Append(cell == State.Alive ? "■" : "□");
        }
        stringBuilder.Append("\n");
      }

      Console.CursorVisible = false;
      Console.SetCursorPosition(0, 0);
      Console.Write(stringBuilder.ToString());
      Thread.Sleep(500); 
    }
  }
}
