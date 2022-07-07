using System;
using Xunit;

namespace GradeBook.Tests;

public delegate string WriteLogDelegate(string logMessage);

public class TypeTests
{

  [Fact]
  public void WriteLogDelegateCanPointToMethod()
  {
    WriteLogDelegate log;

    log = new WriteLogDelegate(ReturnMessage);
    // log = ReturnMessage can use this shorthand

    var result = log("Hello!");
    Assert.Equal("Hello!", result);
  }
  string ReturnMessage(string message)
  {
    return message;
  }

  /*
   * Can pass by reference and modify original "x" variable with the use of <ref> || <out>
   * */
  [Fact]
  public void ValueTypesCanPassByReferenceWithHelp()
  {
    var x = GetInt();
    SetInt(out x);

    Assert.Equal(42, x);
  }
  private void SetInt(out int x)
  {
    x = 42;
  }




  [Fact]
  public void ValueTypesAlsoPassByValue()
  {
    var x = GetInt();
    Console.WriteLine($"Number = {x}");
    SetInt(x);
    Console.WriteLine($"x after SetInt = {x}");

    Assert.Equal(3, x);

  }
  // the value "3" is copied into the (int x) parameter
  // passed by value

  private void SetInt(int x)
  {
    x = 42;
  }

  private int GetInt()
  {
    //var random = new Random();
    //int randomNumber = random.Next();
    //return randomNumber;
    return 3;
  }

  /*
  C# can pass by reference by using the <ref> key word.  Must apply <ref> to method call and method definition to make
  sure this is what you really want.
   */

  [Fact]
  public void CSharpCanPassByRef()
  {
    var book1 = GetBook("First Book");
    GetBooksSetName(ref book1, "Copy of First Book");
    Assert.Equal("Copy of First Book", book1.Name);
  }
  private void GetBooksSetName(ref Book book, string name)
  {
    book = new Book(name);
  }





  /*
  We made a copy of the value inside variable 'book' and storing a reference to the object
  in book1.  Storing value into new different memory location.  Value isn't going to change
  pass a variable to another method, we don't want new method to unexpectedly change the value or reference
  that is inside that variable.  That would be unexpected side effect.

  Always always always pass by value!
  */
  [Fact]
  public void CSharpIsPassByValue()
  {
    var book1 = GetBook("First Book");
    GetBooksSetName(book1, "Copy of First Book");


    Assert.Equal("First Book", book1.Name);

  }
  //c# block the modification of the original book1 object
  private void GetBooksSetName(Book book, string name)
  {
    book = new Book(name);

  }

  [Fact]
  public void CanSetNameFromReference()
  {
    var book1 = GetBook("First Book");

    Console.WriteLine($"book1 name = {book1.Name}");
    SetName(book1, "New Book");
    Console.WriteLine($"book1 name after= {book1.Name}");

    //book1.ThisName("New Book");
    Assert.Equal("New Book", book1.Name);

  }
  private void SetName(Book book, string name)
  {
    //book.ThisName(name);
    book.Name = name;
  }


  //Strings are immutable

  [Fact]
  public void StringsBehaveLikeValueTypes()
  {
    string name = "Atwood";
    string upper = MakeUpperCase(name);
    Console.WriteLine(name);
    Console.WriteLine(upper);
    Assert.Equal("Atwood", name);
    Assert.Equal("ATWOOD", upper);
  }

  private string MakeUpperCase(string name)
  {
    return name.ToUpper();
    // ToUpper returns a COPY of a string
  }

  [Fact]
  public void GetBookReturnsDifferentObjects()
  {
    var book1 = GetBook("Book 1");
    var book2 = GetBook("Book 2");

    Console.WriteLine($"book1 name = {book1.Name}");
    Console.WriteLine($"book2 name = {book2.Name}");

    //Assert.Equal("Book 1", book1.Name);
    //Assert.Equal("Book 2", book2.Name);

    Assert.NotSame(book1, book2);

  }

  [Fact]
  public void TwoVariablesReferenceSameObject()
  {
    var book3 = GetBook("Book 3");
    var book4 = book3;
    //book4.Name = "Hello";

    Console.WriteLine($"book3 name = {book3.Name}");
    Console.WriteLine($"book4 name = {book4.Name}");

    //Assert.Equal("Book 3", book3.Name);
    //Assert.Equal("Book 3", book4.Name);

    //Assert.Same(book3, book4);
    Assert.True(Object.ReferenceEquals(book3, book4));

  }

  Book GetBook(string name)
  {
    return new Book(name);
  }
}