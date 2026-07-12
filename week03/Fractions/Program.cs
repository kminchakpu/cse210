using System;

// Verify Constructor with no parameters (initializes to 1/1)
Fraction f1 = new Fraction();
Console.WriteLine(f1.GetFractionString());
Console.WriteLine(f1.GetDecimalValue());

//Verify Constructor with one parameter (initializes to 5/1)
Fraction f2 = new Fraction(5);
Console.WriteLine(f2.GetFractionString());
Console.WriteLine(f2.GetDecimalValue());

//Verify Constructor with two parameters (3/4)
Fraction f3 = new Fraction(3, 4);
Console.WriteLine(f3.GetFractionString());
Console.WriteLine(f3.GetDecimalValue());

//Verify Constructor with alternative values (1/3)
Fraction f4 = new Fraction(1, 3);
Console.WriteLine(f4.GetFractionString());
Console.WriteLine(f4.GetDecimalValue());