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

        internal void ShowStatistics()
        {
            //throw new NotImplementedException();
            Console.WriteLine("Statistics are:");
            this.Average();
            this.lowestGrade();
            this.highestGrade();

        }

        public void Average()
    {
            var avg = grades.Average();
      System.Console.WriteLine($"Average = {avg}");
    }

    public void ThisName(string newName)
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
            Console.WriteLine($"Lowest = {lowest}");
    }

    //List<double> grades = new List<double>();
    private List<double> grades;
    private string name;
  }
}