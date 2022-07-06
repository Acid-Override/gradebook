//using System.Collections.Generic;

namespace GradeBook
{
  public class Book
  {
    public Book(string name)
    {
      grades = new List<double>();
      this.Name = name;
    }
    public void AddGrade(double grade)
    {

      grades.Add(grade);
      foreach (var item in grades)
      {
        System.Console.WriteLine($"The current number is = {item}");
      }
      System.Console.WriteLine(grades.Count);

    }
    public void ListGrades()
    {
      foreach (var item in grades)
      {
        System.Console.WriteLine($"ListGrades says your number is = {item}");
      }
    }

    public void ShowStatistics()
    {
      //throw new NotImplementedException();
      Console.WriteLine("Statistics are:");
      Average();
      LowestGrade();
      HighestGrade();

    }

    public void Average()
    {
      var avg = grades.Average();
      System.Console.WriteLine($"Average = {avg}");
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

            foreach ( var grade in grades )
            {
                result.Low = Math.Min(grade, result.Low);
                result.High = Math.Max(grade, result.High);
                result.Average += grade;
            }
            result.Average /= grades.Count;

            Console.WriteLine($"Average = {result.Average}");
            Console.WriteLine($"High = {result.High}");
            Console.WriteLine($"Low = {result.Low}");
            Console.WriteLine(Name);

            return result;


        }

    //List<double> grades = new List<double>();
    private List<double> grades;
    public string Name;
  }
}