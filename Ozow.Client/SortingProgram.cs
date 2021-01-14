using Ozow.Sorting.Domain.Services;
using Ozow.Sorting.Domain.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ozow.Client
{
  public class SortingProgram
  {
    private readonly ISortingService _sortingService;

    public SortingProgram(ISortingService sortingService)
    {
      _sortingService = sortingService;
    }

    public void Execute()
    {
      string command = "";
      while (command != "Q" && command != "q")
      {
        Console.Clear();
        Console.WriteLine("Please enter text to sort");
        var inputText = Console.ReadLine();

        var sortedText = _sortingService.SortArbitraryText(inputText.ToUpper());

        Console.WriteLine($"Sorted Text is : {sortedText}");
        Console.WriteLine("Press Q to quit or any key to run another sort ");
        command = Console.ReadLine();
      }
    }
  }
}
