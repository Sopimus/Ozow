using NUnit.Framework;
using Ozow.Sorting.Domain.Services.Abstract;
using Ozow.Sorting.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ozow.Sorting.Tests.Domain.Services
{
  public class SortingServiceTests
  {
    private ISortingService _sortingService;

    [SetUp]
    public void Setup()
    {
      _sortingService = new SortingService();
    }

    [TestCase("Contrary to popular belief, the pink unicorn flies east", "aaabcceeeeeffhiiiiklllnnnnooooppprrrrssttttuuy")]
    [TestCase("Costingss aaaa ddd ccc uuu", "aaaaccccdddginossstuuu")]
    public void SortArbitraryText_OnlyAphabeticallyOrderedLowerCaseStringIsReturned(string inputText, string expected)
    {
      // Any text is sorted in aphabetical order ignoring spaces and special character, lower case string is returned 
      
      // Act
      var result = _sortingService.SortArbitraryText(inputText);

      // Assert
      Assert.AreEqual(expected, result);
    }
  }
}
