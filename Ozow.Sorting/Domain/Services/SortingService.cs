using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Ozow.Sorting.Domain.Services.Abstract;

namespace Ozow.Sorting.Domain.Services
{
  public class SortingService: ISortingService
  {
    public string SortArbitraryText(string inputText)
    {
      char tempChar;      
      var lowerCaseText = Regex.Replace(inputText, "[^a-zA-Z]", "").ToLower();       

      var charArrayText = lowerCaseText.ToCharArray();
      
      for (int i = 0; i < charArrayText.Length; i++)
      {
        for (int j = 0; j < lowerCaseText.Length - 1 ; j++)
        {
          if (charArrayText[j] > charArrayText[j + 1])
          {
            tempChar = charArrayText[j];
            charArrayText[j] = charArrayText[j + 1];
            charArrayText[j + 1] = tempChar;
          }
        }
      }
      return new string(charArrayText);
    }
  }
}
