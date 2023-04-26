using System;

class Program {
  static void Main(string[] args) {
    Console.Write("Enter the number of stalls: ");
    int numOfStalls = int.Parse(Console.ReadLine());

    bool[] stalls = new bool[numOfStalls + 1]; 

    while (true) {
      Console.Write("Enter stall number 1: ");
      int stall1 = int.Parse(Console.ReadLine());
      Console.Write("Enter stall number 2: ");
      int stall2 = int.Parse(Console.ReadLine());

      if (stall1 <= 0 || stall2 <= 0) {
        Console.WriteLine("You need to enter a valid stall number.");
      } else if (stall1 == stall2) {
        if (stalls[stall1]) {
          Console.WriteLine("The stall is reserved.");
        } else {
          stalls[stall1] = true;
          DisplayStalls(stalls);
        }
      } else {
        bool canReserve = true;
        for (int i = Math.Min(stall1, stall2); i <= Math.Max(stall1, stall2); i++) {
          if (stalls[i]) {
            canReserve = false;
            Console.WriteLine("The entrance can't be reserved.");
            break;
          }
        }
        if (canReserve) {
          for (int i = Math.Min(stall1, stall2); i <= Math.Max(stall1, stall2); i++) {
            stalls[i] = true;
          }
          DisplayStalls(stalls);
        }
      }

      bool allReserved = true;
      for (int i = 1; i <= numOfStalls; i++) {
        if (!stalls[i]) {
          allReserved = false;
          break;
        }
      }
      if (allReserved) {
        Console.WriteLine("All stall are reserved.");
        break;
      }
    }
  }

  static void DisplayStalls(bool[] stalls) {
    foreach (bool s in stalls) {
      Console.Write(s ? "X" : "_");
    }
    Console.WriteLine();
  }
}