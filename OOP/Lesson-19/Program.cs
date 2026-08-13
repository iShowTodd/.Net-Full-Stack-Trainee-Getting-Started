

namespace Inheritance
{


  internal class Program
  {

    static void Main(string[] args)
    {
      Eagle e = new Eagle();
      e.Move();
      e.Fly();
      // e.something() // Error

      Animal a = e; // UpCasting 
      a.Move();
      // a.fly() // No longer an Eagle now it is converted to be only Animal


      Eagle e2 = (Eagle)a; // Downcasting 
      e2.Fly(); // Now it is an Eagle and can access Eagle stuff 

      Eagle e3 = new Eagle();
      Animal a2 = e3;
      // Falcon f = (Falcon)a2; // Invalid cast exception

      Falcon? f = a2 as Falcon;
      //or 
      if (a2 is Falcon)
      {
        // Do something
      }

      /*Another practice*/
      Eagle eagle = new Eagle();
      Animal animal = eagle;                   // upcast

      if (animal is Falcon falcon)             // downcast — skipped, not a Falcon
        animal = falcon;

      if (animal is Eagle e1)                   // downcast — succeeds
        Console.WriteLine("Still an Eagle");
      eagle.Move();




    }
  }


  abstract class Animal
  {
    public virtual void Move()
    {
      Console.WriteLine("Moving");
    }

    public abstract void AbstractImplement();
    public abstract void something();

    public override string ToString()
    {
      return $"This is an animal class";
    }
  }
  /*
    You can only inherit from one class
  
  */
  sealed class Eagle : Animal // will see everything public, Internal or  protected inside the Animal

  {

    /*
      Public : Everywhere 
      Private : Only within the same class
      Protected : Only within the same class and the interited classes
      Internal : Only within the same Assembly
    */
    public void Fly()
    {
      Console.WriteLine("Flying");
    }

    public override void Move()
    {
      base.Move(); // means use the same with the parent class
      Console.WriteLine("Moving the Eagle");
    }


    public override void AbstractImplement()
    {
      Console.WriteLine("Abstract members must be implemented in childs");
    }

    // protected void something()
    // {
    //   Console.WriteLine("Something protected");
    // }

    public sealed override void something()
    {
      Console.WriteLine("Something protected");
    }

  }

  // class AmericanEagle : Eagle
  // {
  // Can not inherit from sealed calss
  // }

  class Falcon : Animal
  {
    public override void AbstractImplement()
    {
      throw new NotImplementedException();
    }

    public override void something()
    {
      throw new NotImplementedException();
    }
  }


  class BaseClass
  {
    private int x;
    public BaseClass(int value)
    {
      this.x = value;
    }
  }

  class SubClass : BaseClass
  {

    public SubClass(int value) : base(value)
    {
    }

  }
}