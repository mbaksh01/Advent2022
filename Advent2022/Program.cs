using Advent2022.Days;

var numbers = Day1.GetElfWithMostCalories();

Console.WriteLine($"Part 1 Ans - Highest Value = {numbers.first}");
Console.WriteLine($"Part 2 Ans - Top three total = {numbers.first + numbers.second + numbers.third}");