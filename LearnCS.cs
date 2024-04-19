using System;
using System.Text;
using FordsFords.Errs;

namespace FordsFords.LearnCS;

class LearnCS {
  StringBuilder Sb1;

  // Constructor
  public LearnCS() {
    // I don't like this use of target-typed "new" expressions.
    // https://github.com/fordsfords/cs_tst?tab=readme-ov-file#type-inference
    Sb1 = new("yuck");  // What type is Sb1??? You have to find it.
  }


  static int Main(string[] args) {
    if (args.Length == 0) {
      Console.WriteLine("Usage: LearnCS TestNum");
      return 1;
    }
    // args[0] is the first parameter, not the program name.

    int testNum = Int32.Parse(args[0]);
    Console.WriteLine($"Test sequence {testNum}");

    LearnCS l1 = new LearnCS();

    switch (testNum) {
      case 0: break;
      case 1: l1.Test1(args); break;
      case 2: l1.Test2(args); break;
      case 3: l1.Test3(args); break;
      case 4: l1.Test4(args); break;
      case 5: l1.Test5(args); break;
      case 6: l1.Test6(args); break;
      case 7: l1.Test7(args); break;
      case 8: l1.Test8(args); break;
      case 9: l1.Test9(args); break;
      case 10: l1.Test10(args); break;
      case 11: l1.Test11(args); break;
      default: Assrt.Fatal($"Invalid test {testNum}");
        Console.WriteLine("Should not get here!");
        break;
    }

    Console.WriteLine($"Test {testNum} OK");
    Console.WriteLine("Assrt Count: " + Assrt.GetAssrtCount());

    return 0;
  }  // Main


  // Test to demonstrate a failed assertion.
  void Test1(string[] args) {
    int i = Int32.Parse(args[0]);
    Assrt.IsTrue(i != 1);
    Assrt.Fatal("Should not get here!");
  }  // Test1


  public struct Point {
    public int X, Y;
  }

  public class PointC {
    public int X, Y;
  }

  // Test of value vs reference parameters.
  void Test2(string[] args) {
    int l1;
    int l2;

    l1 = 5;
    l2 = Test2Def1(l1);
    Assrt.IsTrue((l1 == 5) && (l2 == 6));
    l1 = 5;
    l2 = Test2Ref1(ref l1);
    Assrt.IsTrue((l1 == 6) && (l2 == 6));
    l1 = 5;
    l2 = Test2In1(in l1);
    Assrt.IsTrue((l1 == 5) && (l2 == 6));
    l1 = 5;
    l2 = Test2Out1(out l1);
    Assrt.IsTrue((l1 == 91) && (l2 == 91));

    int[] ia = {1, 2, 3, 4};
    Test2ArrayI(ia);
    Assrt.IsTrue(ia[0] == 1);
    Assrt.IsTrue(ia[1] == 3);
    Assrt.IsTrue(ia[2] == 3);

    Point p = new Point();
    p.X = 10;
    p.Y = 20;
    Test2StructPoint(p);  // Struct passed by value.
    Assrt.IsTrue(p.X == 10);
    Assrt.IsTrue(p.Y == 20);

    PointC pC = new PointC();
    pC.X = 10;
    pC.Y = 20;
    Test2StructPointC(pC);  // Class passed by reference.
    Assrt.IsTrue(pC.X == 10);
    Assrt.IsTrue(pC.Y == 21);
  }  // Test2

  int Test2Def1(int p1) {
    p1++;
    return p1;
  }

  int Test2Ref1(ref int p1) {
    p1++;
    return p1;
  }

  int Test2In1(in int p1) {
    // p1++;  // Cannot modify p1.
    return p1+1;
  }

  int Test2Out1(out int p1) {
    p1 = 90;  // Must initialize; can't use existing val.
    p1++;
    return p1;
  }

  void Test2ArrayI(int [] ia) {
    ia[1]++;
  }

  void Test2StructPoint(Point p) {
    p.Y++;
  }

  void Test2StructPointC(PointC pC) {
    pC.Y++;
  }


  // Test to demonstrate basic array operations.
  void Test3(string[] args) {
    int[] oddNatNums = new int[] {1, 3, 5, 7, 9};
    Assrt.IsTrue(oddNatNums.Length == 5);
    Assrt.IsTrue(oddNatNums.GetLength(0) == 5);
    Assrt.IsTrue(oddNatNums[^1] == 9);
    Assrt.IsTrue(oddNatNums[^2] == 7);
    Assrt.IsTrue(Test3Dim1Len(oddNatNums[..2]) == 2);
    Assrt.IsTrue(Test3Dim1Len(oddNatNums[2..]) == 3);
    Assrt.IsTrue(Test3Dim1Len(oddNatNums[1..2]) == 1);

    int[,] multiplicationTable = { { 0, 0, 0 },
                                   { 0, 1, 2 },
                                   { 0, 2, 4 } };
    Assrt.IsTrue(multiplicationTable.GetLength(0) == 3);
    Assrt.IsTrue(multiplicationTable.GetLength(1) == 3);
    Assrt.IsTrue(multiplicationTable.Length == 9);

    int[][] pascalsTriangle = { new int[] {1},
                                new int[] {1, 1},
                                new int[] {1, 2, 1},
                                new int[] {1, 3, 3, 1},
                                new int[] {1, 4, 6, 4, 1} };
    Assrt.IsTrue(pascalsTriangle.GetLength(0) == 5);
    Assrt.IsTrue(pascalsTriangle[0].GetLength(0) == 1);
    Assrt.IsTrue(pascalsTriangle[1].GetLength(0) == 2);
    Assrt.IsTrue(pascalsTriangle[2].GetLength(0) == 3);
    Assrt.IsTrue(pascalsTriangle[3].GetLength(0) == 4);
    Assrt.IsTrue(pascalsTriangle[4].GetLength(0) == 5);
    Assrt.IsTrue(Test3Dim1Len(pascalsTriangle[2]) == 3);
  }  // Test3

  int Test3Dim1Len(int[] nums) {
    return nums.Length;
  }


  // Test of some string stuff.
  void Test4(string[] args) {
    string vowels = "aeiou\n";
    string v = "aeiou\n";
    Assrt.IsTrue(vowels == v);

    v = @"\\server\user\sford";
    Assrt.IsTrue(v.Length == 19);
  }  // Test4


  // Test of some string stuff.
  void Test5(string[] args) {
    byte b = byte.MinValue;
    Assrt.IsTrue(b == 0);
    sbyte sb = sbyte.MinValue;
    Assrt.IsTrue(sb == -128);
    short s = short.MinValue;
    Assrt.IsTrue(s == -32768);
    ushort us = ushort.MinValue;
    Assrt.IsTrue(us == 0);
    int i = int.MinValue;
    Assrt.IsTrue(i == -2_147_483_648);
    uint ui = uint.MinValue;
    Assrt.IsTrue(ui == 0);  // suffix U.
    long l = long.MinValue;
    Assrt.IsTrue(l == -9_223_372_036_854_775_808);  // suffix L
    ulong ul = ulong.MinValue;
    Assrt.IsTrue(ul == 0);  // suffix UL

    float f = 0.1F;
    f = f + f + f + f + f + f + f + f + f + f;
    f -= 1.0F;
    Assrt.IsTrue(f != 0.0F);

    double d = 0.1;
    d = d + d + d + d + d + d + d + d + d + d;
    d -= 1.0;
    Assrt.IsTrue(d != 0.0);

    // Decimal is 128 bits
    decimal dd = 0.1M;
    dd = dd + dd + dd + dd + dd + dd + dd + dd + dd + dd;
    dd -= 1.0M;
    Assrt.IsTrue(dd == 0.0M);
    dd = 1M / 3M;
    dd = dd + dd + dd;
    dd -= 1M;
    Assrt.IsTrue(dd != 0);
  }  // Test5


  void Test6(string[] args) {
    Assrt.IsTrue(Test6Average(1.0, 2.0, 3.0, 4.0) == 2.5);

    Assrt.IsTrue(Test6Def([10.0, 20.0, 30.0, 40.0]) == 40.0);
    // Named parameters.
    Assrt.IsTrue(Test6Def(i:1, vals:[10.0, 20.0, 30.0, 40.0]) == 20.0);
    // Named combined with defaults: skip "i".
    Assrt.IsTrue(Test6Def(j:0.5, vals:[10.0, 20.0, 30.0, 40.0]) == 20.0);
  }  // Test6

  double Test6Average(params double[] vals) {
    int i;
    double sum = 0.0;
    for (i = 0; i < vals.Length; i++) {
      sum += vals[i];
    }
    return sum / (double)vals.Length;
  }

  double Test6Def(double[] vals, int i = 3, double j = 1.0) {
    return vals[i] * j;
  }


  // Local refs
  void Test7(string[] args) {
    Point p = new Point();
    p.X = 1;  p.Y = 2;
    ref int y = ref p.Y;
    Assrt.IsTrue(y == 2 && p.Y == 2);
    y++;
    Assrt.IsTrue(y == 3 && p.Y == 3);
  }  // Test7


  // target-typed "new" expressions
  void Test8(string[] args) {
    StringBuilder sbX = new StringBuilder();
    // Can leave off the class after "new".
    StringBuilder sbY = new("abc");
  }  // Test8


  // Null operators.
  void Test9(string[] args) {
    MyStack Stack9 = null;  // Compiler warning CS8600.

    Assrt.IsTrue(Stack9 == null);
    Test9Push(5);
    Assrt.IsTrue(Stack9.X == 5 && Stack9.Y == 0);  // Compiler warning CS8602.
    Test9Push(6);
    Assrt.IsTrue(Stack9.X == 6 && Stack9.Y == 5);
    // There are also some other null operators.

    void Test9Push(int val) {
      Stack9 ??= new();  // If null, Assign target-typed 'new'.
      Stack9.Y = Stack9.X;
      Stack9.X = val;
    }
  }  // Test9

  // switch
  void Test10(string[] args) {
    int i = 1;
    Assrt.IsTrue(Test10Switch(i) == "int 1");
    Assrt.IsTrue(Test10Switch(-i) == "int (negative) -1");
    long l = 2;
    Assrt.IsTrue(Test10Switch(l) == "long 2");
    uint ui = 3;
    Assrt.IsTrue(Test10Switch(ui) == "uint 3");
    double d = 4.0;
    Assrt.IsTrue(Test10Switch(d) == "double 4");
    string s = "5";
    Assrt.IsTrue(Test10Switch(s) == "string 5");
    StringBuilder sb = new("6");
    Assrt.IsTrue(Test10Switch(sb) == "StringBuilder 6");

    s = ui switch {
      1 => "one", 2 => "two", 3 => "three", _ => "duh"
    };
    Assrt.IsTrue(s == "three");
    s = d switch {
      1 => "one", 2 => "two", 3 => "three", _ => "duh"
    };
    Assrt.IsTrue(s == "duh");
  }  // Test10

  string Test10Switch(object o) {
    switch (o) {
      case int i when i < 0: return "int (negative) " + o.ToString();
      case int i: return "int " + o.ToString();
      case long l: return "long " + o.ToString();
      case uint ui: return "uint " + o.ToString();
      case double d: return "double " + o.ToString();
      case string s: return "string " + o.ToString();
      case StringBuilder sb: return "StringBuilder " + o.ToString();
      default: return "unknown " + ToString();
    }
  }


  // foreach
  void Test11(string[] args) {
  }  // Test11

}  // LearnCS


class MyStack {
  public int X;
  public int Y;
}
