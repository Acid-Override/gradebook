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

    //List<double> grades = new List<double>();
    private List<double> grades;
    private string name;


  }
}