using System;
using Microsoft.Extensions.DependencyInjection;
using Ozow.Client.DependencyInjection;

namespace Ozow.Client
{
  class Program
  {
    static void Main(string[] args)
    {
      // Create service collection and configure our services
      var services = ClientConfigurer.ConfigureServices();

      // Generate a provider
      var serviceProvider = services.BuildServiceProvider();

      Console.WriteLine("Please select which program to execute 1 for SortingProgram and 2 for GameOfLifeProgram");

      var program = Console.ReadLine();

      int.TryParse(program, out int programNumber);
      while(programNumber != 1 && programNumber != 2)
      {
        Console.WriteLine("Invalid Selection,Please Select 1 for SortingProgram OR 2 for GameOfLifeProgram");
        program = Console.ReadLine();
        int.TryParse(program, out int programNumberReTry);
        programNumber = programNumberReTry;
      }

      if (programNumber == 1)
        serviceProvider.GetService<SortingProgram>().Execute();
      if (programNumber == 2)
        serviceProvider.GetService<GameOfLifeProgram>().Execute();     
       
    }
  }
}
