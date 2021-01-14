using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Ozow.GameOfLife.Domain.Services;
using Ozow.Sorting.Domain.Services;
using Ozow.GameOfLife.Domain.Services.Abstract;
using Ozow.Sorting.Domain.Services.Abstract;

namespace Ozow.Client.DependencyInjection
{
  public static class ClientConfigurer
  {
    public static IServiceCollection ConfigureServices()
    {
      IServiceCollection services = new ServiceCollection();
      services.AddSingleton<IConwaysGameOfLifeService, ConwaysGameOfLifeService>();
      services.AddSingleton<ISortingService, SortingService>();
      services.AddSingleton<GameOfLifeProgram>();
      services.AddSingleton<SortingProgram>();
      
      return services;
    }
  }
}
