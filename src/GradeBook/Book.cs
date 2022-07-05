//using System.Collections.Generic;

namespace GradeBook
{
  class Book
  {
    public Book()
    {
      grades = new List<double>();
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
    List<double> grades;


  }
}