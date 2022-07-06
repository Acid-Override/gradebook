//using System;
//using System.Collections.Generic;
using static System.Console;
//using static System.Math;
using static System.String;

namespace GradeBook
{
  class Program
  {

    static void Main(string[] args) //main method
    {
      var book = new Book("The Grade Book");
      //book.grades.Add(101);
      book.AddGrade(89.1);
      book.AddGrade(90.5);
      book.AddGrade(88.3);
      book.AddGrade(94.3);
      
      //book.ListGrades();
      //book.Average();
      //book.ShowStatistics();

      string input = "A";

      while (!String.Equals(input, "Q"))
      {
        WriteLine("(E)nter score, (C)ompute Average, (S)how scores, (H)ighest grade, (L)owest grade, (ST)atistics, (GS)tats, (Q)uit ? ");
        input = ReadLine();
        System.Console.WriteLine($"input = {input}");
        if (input == "S")
        {
          book.ListGrades();
        }
        if (input == "C")
        {
          book.Average();
        }
        if (input == "E")
        {
          WriteLine("Enter a score in (XX.X)?");
          var number = ReadLine();
          if (!IsNullOrEmpty(number) && double.TryParse(number, out var currentGrade))
            book.AddGrade(currentGrade);
          book.ListGrades();
        }
        if (input == "N")
        {
          WriteLine("Name?");
          var nameInput = ReadLine();
          if (!IsNullOrEmpty(nameInput))
          {
            book.ThisName(nameInput);
          }
        }
        if (input == "H")
        {
          book.HighestGrade();
        }
        if (input == "L")
        {
          book.LowestGrade();
        }
        if (input == "ST")
        {
          book.ShowStatistics();
        }
        if ( input == "GS" )
                {
                    var stats = book.GetStats();
                    WriteLine($"{stats.Average}, {stats.High}, {stats.Low}");
                }
        }


      //var numbers = new[] {12.7, 10.3, 6.11, 15, 10};
      var grades = new List<double>() { 12.7, 10.3, 6.11, 4.1 };
      grades.Add(56.1);

      var result = 0.0;
      foreach (var number in grades)
      {
        //System.Console.WriteLine(number);
        result += number;
      }

      //var avg = grades.Average();
      result /= grades.Count;
      Console.WriteLine($"The student average is {result:N1}");

    }
  }

}





