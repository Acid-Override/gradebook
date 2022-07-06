//using System.Collections.Generic;

namespace GradeBook
{
  class Book
  {
    public Book(string name)
    {
      grades = new List<double>();
      this.name = name;
    }
     public void AddGrade(double grade)
    {

      grades.Add(grade);
      foreach ( var item in grades )
      {
        System.Console.WriteLine($"The current number is = {item}");
      }
      System.Console.WriteLine(grades.Count);

    }
    public void ListGrades()
    {
      foreach ( var item in grades )
      {
        System.Console.WriteLine($"ListGrades says your number is = {item}");
      }
    }
    public void Average()
    {
      System.Console.WriteLine(grades.Average());
    }

    public void thisName(string newName)
    {
      System.Console.WriteLine(this.name);
      this.name = newName;
      System.Console.WriteLine(this.name);
    }
    public void highestGrade()
    {
      var largest = double.MinValue;
      foreach ( var item in grades )
      {
        largest = Math.Max(largest, item);
      }
        System.Console.WriteLine($"Largest = {largest}");
    }
    public void lowestGrade()
    {
            var lowest = double.MaxValue;

      foreach ( var item in grades )
            {
                lowest = Math.Min(lowest, item);
            }
            Console.WriteLine($"{lowest}");
    }

    //List<double> grades = new List<double>();
    private List<double> grades;
    private string name;
  }
}