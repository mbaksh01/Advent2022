using Advent2022.Days;

(int first, int second, int third) = Day1.GetTopThreeCalories();

Console.WriteLine($"Day 1 part 1 result - {first}");
Console.WriteLine($"Day 1 part 2 result - {first + second + third}");

Console.WriteLine($"Day 2 part 1 result - {Day2.GetTotalScore()}");
Console.WriteLine($"Day 2 part 2 result - {Day2.GetTotalScore2()}");

Console.WriteLine($"Day 3 part 1 result - {Day3.GetPrioritySum()}");
Console.WriteLine($"Day 3 part 2 result - {Day3.GetGroupedPrioritySum()}");

Console.WriteLine($"Day 4 part 1 result - {Day4.GetContainedPairsCount()}");
Console.WriteLine($"Day 4 part 2 result - {Day4.GetOverlappingPairsCount()}");

Console.WriteLine($"Day 5 part 1 result - {Day5.GetCrateOrder(9000)}");
Console.WriteLine($"Day 5 part 1 result - {Day5.GetCrateOrder(9001)}");
