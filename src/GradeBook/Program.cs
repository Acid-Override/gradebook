﻿//using System;
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

      while (true)
      {
        WriteLine("\n(E)nter score \n(C)ompute Average\n (S)how scores\n (H)ighest grade\n " +
            "(L)owest grade\n (ST)atistics\n (GS)tats\n (LG)Enter Letter Grade\n (SLG) Show Letter Grade\n (N)ame\n (Q)uit ? ");
        var input = ReadLine();
        if(input == null)
        {
          throw new ArgumentException($"Invalid code :  {nameof(input)}");
        }
        //System.Console.WriteLine($"input = {input}");
        if (input == "q" || input == "Q")
        {
          break;
        }
        if (input == "s" || input == "S")
        {
          book.ListGrades();
        }
        if (input == "c" || input == "C")
        {
          book.Average();
        }
        if (input == "e" || input == "E")
        {
          WriteLine("Enter a score in (XX.X)?");
          input = Console.ReadLine();
          if(input == null)
          {
            throw new ArgumentException($"Invalid code :  {nameof(input)}");
          }

          try
          {
            var grade = double.Parse(input);
            book.AddGrade(grade);
          }
          catch (ArgumentException ex)
          {
            System.Console.WriteLine(ex.Message);
          }
          catch (FormatException ex)
          {
            System.Console.WriteLine(ex.Message);
          }
          finally
          {
            System.Console.WriteLine("Finally Block of Code");
          }
          // if (!IsNullOrEmpty(number) && double.TryParse(number, out var currentGrade))
          // {
          //   book.AddGrade(currentGrade);
          //   //book.ListGrades();
          // }
          // else
          // {
          //   WriteLine("Invalid input");
          // }

        }
        if (input == "lg" || input == "LG")
        {
          WriteLine("Enter a Letter grade (A,B,C,D,F):");
          var letter = ReadLine();

          if (!IsNullOrEmpty(letter))
          {
            char c = char.Parse(letter);
            book.AddGrade(c);
          }
          else
          {
            WriteLine("Invalid Input");
          }
        }
        if (input == "slg" || input == "SLG")
        {
          book.ShowLetterGrade();
        }
        if (input == "n" || input == "N")
        {
          WriteLine("Name?");
          var nameInput = ReadLine();
          if (!IsNullOrEmpty(nameInput))
          {
            book.ThisName(nameInput);
          }
        }
        if (input == "h" || input == "H")
        {
          book.HighestGrade();
        }
        if (input == "l" || input == "L")
        {
          book.LowestGrade();
        }
        if (input == "st" || input == "ST")
        {
          book.ShowStatistics();
        }
        if (input == "gs" || input == "GS")
        {
          var stats = book.GetStats();
          System.Console.WriteLine(Book.CATEGORY);
          WriteLine($"{stats.Average}, {stats.High}, {stats.Low}");
        }
      }
    }
  }

}





