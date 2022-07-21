//using System.Collections.Generic;

namespace GradeBook
{

  // not expecting anything back, just anouncing to the world that a grade was added
  // similar to UDP internet protocol.

  public delegate void GradeAddedDelegate(object sender, EventArgs args);
  // can define delegate that takes in no parameters
  // could also pass in (double grade)

  public class Book
  {
    public Book(string name)
    {
      grades = new List<double>();
      this.Name = name;
    }
     public void AddGrade(char letter)
    {
      switch (letter)
      {
        case 'A':
          AddGrade(90);
          break;

        case 'B':
          AddGrade(80);
          break;

        case 'C':
          AddGrade(70);
          break;

        case 'D':
          AddGrade(60);
          break;

        case 'F':
          AddGrade(50);
          break;

        default:
          AddGrade(0);
          break;
      }
    }

    public void AddGrade(double grade)
    {
      if (grade <= 100 && grade >= 0)
      {
        grades.Add(grade);
        if(GradeAdded != null)
        {
          GradeAdded(this, new EventArgs());
        }
      }
      else
      {
        throw new ArgumentException($"Invalid code :  {nameof(grade)}");
      }
    }

    // need 'event' keyword
    // just a field on Book Class until "event" keyword added
    public event GradeAddedDelegate GradeAdded;

    public void ListGrades()
    {
      foreach (var item in grades)
      {
        System.Console.WriteLine($"ListGrades says your number is = {item}");
      }
    }

    public void ShowLetterGrade()
    {
      var avg = grades.Average();
      Console.WriteLine($"Average is : {avg}");

      switch (avg)
      {
        case var d when d > 90:
          Console.WriteLine("A");
          break;
        case var d when d > 80:
          Console.WriteLine("B");
          break;
        case var d when d > 70:
          Console.WriteLine("C");
          break;
        case var d when d > 60:
          Console.WriteLine("D");
          break;
        default:
          Console.WriteLine("F");
          break;
      }
    }

    public void ShowStatistics()
    {
      Console.WriteLine("Statistics are:\n");
      Average();
      LowestGrade();
      HighestGrade();
    }

    public void Average()
    {
      var avg = grades.Average();
      System.Console.WriteLine($"Average = {avg}");
    }

    public int GetCount()
    {
      return grades.Count;
    }

    public void ThisName(string newName)
    {
      System.Console.WriteLine($"First = {this.Name}");
      this.Name = newName;
      System.Console.WriteLine($"Second = {this.Name}");
    }

    public void HighestGrade()
    {
      var largest = double.MinValue;
      Console.WriteLine($"Max Grades = {grades.Max()}");
      foreach (var item in grades)
      {
        largest = Math.Max(largest, item);
      }
      System.Console.WriteLine($"Largest = {largest}");
    }

    public void LowestGrade()
    {
      var lowest = double.MaxValue;

      foreach (var item in grades)
      {
        lowest = Math.Min(lowest, item);
      }
      Console.WriteLine($"Lowest = {lowest}");
    }

    public Statistics GetStats() //return type of Statistics
    {
      var result = new Statistics();
      result.Average = 0.0;
      result.High = double.MinValue;
      result.Low = double.MaxValue;

      //foreach ( var grade in grades )
      //{
      //    result.Low = Math.Min(grade, result.Low);
      //    result.High = Math.Max(grade, result.High);
      //    result.Average += grade;
      //}

      var i = 0;
      do
      {
        result.Low = Math.Min(grades[i], result.Low);
        result.High = Math.Max(grades[i], result.High);
        result.Average += grades[i];
        i++;
      } while (i < grades.Count);

      result.Average /= grades.Count;

      switch (result.Average)
      {
        case var d when d > 90:
          result.Letter = 'A';
          break;
        case var d when d > 80:
          result.Letter = 'B';
          break;
        case var d when d > 70:
          result.Letter = 'C';
          break;
        case var d when d > 60:
          result.Letter = 'C';
          break;
        default:
          result.Letter = 'F';
          break;
      }

      Console.WriteLine($"For the book named {this.Name}");
      System.Console.WriteLine($"Category is : {Book.CATEGORY}");
      Console.WriteLine($"Average = {result.Average:N1}");
      Console.WriteLine($"High = {result.High}");
      Console.WriteLine($"Low = {result.Low}");
      Console.WriteLine($"Letter = {result.Letter}");
      Console.WriteLine(Name);

      return result;


    }

    //List<double> grades = new List<double>();
    private List<double> grades;

    public string Name
    {
      get;
      set;
    }

    public const string CATEGORY = "Science";
  }

}